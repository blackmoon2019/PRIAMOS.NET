Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Pdf
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.PivotGrid.QueryMode
Imports DevExpress.XtraBars

Public Class frmFilePreviwer
    Private sID As String
    Private sPrintAllExp As Boolean = False
    Private LoadForms As New FormLoader
    Public sIDs As New List(Of String)
    Private Splash As DevExpress.XtraSplashScreen.SplashScreenManager
    Private UserPermissions As New CheckPermissions
    Public WriteOnly Property PrintAllExp As Boolean
        Set(value As Boolean)
            sPrintAllExp = value
        End Set
    End Property
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property Spl As DevExpress.XtraSplashScreen.SplashScreenManager
        Set(value As DevExpress.XtraSplashScreen.SplashScreenManager)
            Splash = value
        End Set
    End Property

    Private Sub frmFilePreviwer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If sPrintAllExp = True Then
            Dim sInhInds As New StringBuilder
            sInhInds.Clear()
            For i As Integer = 0 To sIDs.Count - 1
                sInhInds.Append(toSQLValueS(sIDs.Item(i)) & ",")
            Next i
            sInhInds.Remove(sInhInds.Length - 1, 1)
            Dim sSQL As String = "Select ID, indID, filename, comefrom, extension, code, repName, bdgNam, inhID, completeDate " &
                                  "From vw_IND_F Where inhID IN (" & sInhInds.ToString() & ") "
            Dim myCmd As SqlCommand
            Dim myReader As SqlDataReader
            GridView1.Columns.Clear()
            myCmd = CNDB.CreateCommand
            myCmd.CommandText = sSQL
            GridView1.Columns.Clear()
            myReader = myCmd.ExecuteReader()
            grdMain.DataSource = myReader
            LoadForms.RestoreLayoutFromXml(GridView1, "vw_IND_F.xml")
        Else
            'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_IND_F' table. You can move, or remove it, as needed.
            Me.Vw_IND_FTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_F, System.Guid.Parse(sID))
            Splash.CloseWaitForm()
            LoadForms.RestoreLayoutFromXml(GridView1, "vw_IND_F_OnebBDG.xml")
        End If
        UserPermissions.GetUserPermissions(Me.Text)
        BDeleteFile.Enabled = UserProps.AllowDelete
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
        Try
            If GridView1.IsGroupRow(GridView1.FocusedRowHandle) Then Exit Sub
            Dim sFilename = System.IO.Path.GetTempFileName().ToString().Replace(".tmp", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "extension"))
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "extension").ToString.ToUpper <> ".PDF" Then Exit Sub
            Dim fs As IO.FileStream = New IO.FileStream(sFilename, IO.FileMode.Create)
            Dim sFName As String
            Dim b() As Byte = GetFile(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString, sFName)
            fs.Write(b, 0, b.Length)
            PdfViewer1.LoadDocument(fs)
            fs.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub grdMain_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMain.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteRecord() : Me.Vw_IND_FTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_F, System.Guid.Parse(sID))
        End Select
    End Sub
    Private Sub DeleteRecord()
        Dim sSQL As String
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                sSQL = "DELETE FROM IND_F WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using

                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Dim sFName As String
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") Is DBNull.Value Then Exit Sub
        Dim b() As Byte = GetFile(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString, sFName)
        sFName = Path.GetFileName(sFName)
        If b Is Nothing Then XtraMessageBox.Show("Δεν έχει αντιστοιχηθεί αρχείο με την εγγραφή", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & sFName) Then My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & sFName)
        Try
            'Dim fs As IO.FileStream = New IO.FileStream(ProgProps.ServerPath & sFName, IO.FileMode.Create)
            Dim fs As IO.FileStream = New IO.FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & sFName, IO.FileMode.Create)
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & sFName)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function GetFile(ByVal sRowID As String, ByRef sFName As String) As Byte()
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim bytes As Byte()

        sSQL = "Select  filename,files From IND_F WHERE ID = " & toSQLValueS(sRowID)
        cmd = New SqlCommand(sSQL, CNDB) : sdr = cmd.ExecuteReader()
        If sdr.Read() = True Then
            bytes = DirectCast(sdr("files"), Byte())
            sFName = sdr("filename")
            Return bytes
        End If
        sdr.Close()

    End Function
    Private Sub ShellExecute(ByVal File As String)
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = File
        myProcess.StartInfo.UseShellExecute = True
        myProcess.StartInfo.RedirectStandardOutput = False
        myProcess.Start()
        myProcess.Dispose()
        myProcess.Close()
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            If sPrintAllExp Then
                LoadForms.PopupMenuShow(e, GridView1, "vw_IND_F.xml", "vw_IND_F")
            Else
                LoadForms.PopupMenuShow(e, GridView1, "vw_IND_F_OnebBDG.xml", "vw_IND_F")
            End If
        End If
    End Sub

    Private Sub BMergePDF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BMergePDF.ItemClick
        PdfViewer1.CloseDocument()
        Using pdfDocumentProcessor As New PdfDocumentProcessor()
            Dim PdfDataStream As New MemoryStream()
            pdfDocumentProcessor.CreateEmptyDocument(PdfDataStream)
            Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                Dim sFName As String
                If GridView1.GetRowCellValue(selectedRowHandle, "ID") IsNot Nothing Then
                    Dim PdfData() As Byte = GetFile(GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString, sFName)
                    Dim PdfDataFileStream As New MemoryStream(PdfData)
                    pdfDocumentProcessor.AppendDocument(PdfDataFileStream)
                    PdfDataFileStream.Dispose() : PdfDataFileStream.Close()
                End If
            Next I
            Dim PdfDataMerged As New MemoryStream()
            pdfDocumentProcessor.SaveDocument(PdfDataMerged)
            PdfViewer1.LoadDocument(PdfDataMerged)
            PdfDataStream.Dispose() : PdfDataStream.Close()
            PdfDataMerged.Dispose() : PdfDataMerged.Close()
        End Using

    End Sub
    'Διαγραφη Εγγραφών
    Private Sub DeleteBatchRecords()
        Dim sSQL As String
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
        Dim I As Integer
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφούν η τρέχουσες εγγραφές?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)

                If GridView1.GetRowCellValue(selectedRowHandle, "ID") = Nothing Then Exit Sub
                sSQL = "DELETE FROM IND_F WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next
            RefreshRecords()
            XtraMessageBox.Show("Η εγγραφές διαγράφηκαν με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RefreshRecords()
        If sPrintAllExp = True Then
            Dim sInhInds As New StringBuilder
            sInhInds.Clear()
            For i As Integer = 0 To sIDs.Count - 1
                sInhInds.Append(toSQLValueS(sIDs.Item(i)) & ",")
            Next i
            sInhInds.Remove(sInhInds.Length - 1, 1)
            Dim sSQL As String = "Select ID, indID, filename, comefrom, extension, code, repName, bdgNam, inhID, completeDate " &
                                  "From vw_IND_F Where inhID IN (" & sInhInds.ToString() & ") "
            Dim myCmd As SqlCommand
            Dim myReader As SqlDataReader
            GridView1.Columns.Clear()
            myCmd = CNDB.CreateCommand
            myCmd.CommandText = sSQL
            GridView1.Columns.Clear()
            myReader = myCmd.ExecuteReader()
            grdMain.DataSource = myReader
            LoadForms.RestoreLayoutFromXml(GridView1, "vw_IND_F.xml")
        Else
            'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_IND_F' table. You can move, or remove it, as needed.
            Me.Vw_IND_FTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_F, System.Guid.Parse(sID))
            LoadForms.RestoreLayoutFromXml(GridView1, "vw_IND_F_OnebBDG.xml")
        End If
    End Sub

    Private Sub BDeleteFile_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BDeleteFile.ItemClick
        DeleteBatchRecords()
    End Sub
End Class