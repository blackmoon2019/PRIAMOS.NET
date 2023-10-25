Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmBatchInsertAttachmentsEX
    Private DBQ As New DBQueries
    Private sBDGID As String = ""
    Public Shared ReadOnly MaxEntitiesCount As Integer = 80
    Private _currentPath As String
    Private LoadForms As New FormLoader
    Private ManageCbo As New CombosManager
    Public WriteOnly Property BDGID As String
        Set(value As String)
            sBDGID = value
        End Set
    End Property

    Private Sub frmBatchInsertAttachmentsEX_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_BDG.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.FillByIsManaged(Me.Priamos_NET_DataSet_BDG.vw_BDG)
        If sBDGID.Length > 0 Then
            cboBDG.EditValue = System.Guid.Parse(sBDGID)
        Else
            Me.Vw_INDTableAdapter.FillByIsManagedAndPaid(Me.Priamos_NETDataSet2.vw_IND, chkPaid.EditValue)
        End If
        Initialize()
        LoadForms.RestoreLayoutFromXml(GridView1, "INDF_BATCH.xml")
    End Sub
    Private Sub Initialize()
        Me._currentPath = ProgProps.EXFolderPath
        BreadCrumb.Path = Me._currentPath
        InitializeImageList()
    End Sub
    Private Sub InitializeImageList()

        ImageListBoxControl1.Items.Clear()
        If Directory.Exists(BreadCrumb.Path) = False Then Exit Sub
        For Each i In My.Computer.FileSystem.GetDirectories(BreadCrumb.Path)
            ImageListBoxControl1.Items.Add(i.Substring(i.LastIndexOf("\") + 1), 1)
        Next
        For Each i In My.Computer.FileSystem.GetFiles(BreadCrumb.Path)
            ImageListBoxControl1.Items.Add(i.Substring(i.LastIndexOf("\") + 1), GetExtensionIco(i))
            ImageListBoxControl1.Items.Item(ImageListBoxControl1.Items.Count - 1).Tag = BreadCrumb.Path & "\"
        Next
    End Sub
    Private Function GetExtensionIco(ByVal sFilename As String) As Integer
        Dim fi As New IO.FileInfo(sFilename)
        Select Case fi.Extension
            Case ".pdf" : Return 2
            Case ".xlsx", ".xls" : Return 3
            Case ".docx", ".doc" : Return 4
            Case Else : Return 0
        End Select
    End Function
    Protected ReadOnly Property StartupPath() As String
        Get
            Return Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End Get
    End Property
    Public ReadOnly Property BreadCrumb() As BreadCrumbEdit
        Get
            Return editBreadCrumb
        End Get
    End Property
    Private Sub breadCrumbEdit1_Properties_NewNodeAdding(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventArgs) Handles editBreadCrumb.Properties.NewNodeAdding
        e.Node.PopulateOnDemand = True
    End Sub
    Private Sub breadCrumbEdit1_Properties_ValidatePath(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.BreadCrumbValidatePathEventArgs) Handles editBreadCrumb.Properties.ValidatePath
        If (Not Directory.Exists(e.Path)) Then
            e.ValidationResult = DevExpress.XtraEditors.BreadCrumbValidatePathResult.Cancel
            Return
        End If
        e.ValidationResult = DevExpress.XtraEditors.BreadCrumbValidatePathResult.CreateNodes
    End Sub

    Private Sub breadCrumbEdit1_Properties_QueryChildNodes(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventArgs) Handles editBreadCrumb.Properties.QueryChildNodes
        'Add custom shortcuts to the 'Root' node
        If String.Equals(e.Node.Caption, "Root", StringComparison.Ordinal) Then
            InitBreadCrumbRootNode(e.Node)
            Return
        End If
        'Add local discs shortcuts to the 'Root' node
        If String.Equals(e.Node.Caption, "Computer", StringComparison.Ordinal) Then
            InitBreadCrumbComputerNode(e.Node)
            Return
        End If
        'Populate dynamic nodes
        Dim dir As String = e.Node.Path
        If (Not Directory.Exists(dir)) Then
            Return
        End If
        Dim subDirs As String() = GetSubFolders(dir)
        Dim i As Integer = 0
        Do While i < subDirs.Length
            e.Node.ChildNodes.Add(CreateNode(subDirs(i)))
            i += 1
        Loop

    End Sub

    Private Sub InitBreadCrumbRootNode(ByVal node As BreadCrumbNode)
        node.ChildNodes.Add(New BreadCrumbNode("Desktop", Environment.GetFolderPath(Environment.SpecialFolder.Desktop)))
        node.ChildNodes.Add(New BreadCrumbNode("Windows", Environment.GetFolderPath(Environment.SpecialFolder.Windows)))
        node.ChildNodes.Add(New BreadCrumbNode("Program Files", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)))
    End Sub
    Private Sub InitBreadCrumbComputerNode(ByVal node As BreadCrumbNode)
        For Each driveInfo As DriveInfo In GetFixedDrives()
            node.ChildNodes.Add(New BreadCrumbNode(driveInfo.Name, driveInfo.RootDirectory))
        Next driveInfo
    End Sub

    Protected Function CreateNode(ByVal path As String) As BreadCrumbNode
        Dim folderName As String = New DirectoryInfo(path).Name
        Return New BreadCrumbNode(folderName, folderName, True)
    End Function

    'Get the local drives list
    Public Shared Iterator Function GetFixedDrives() As IEnumerable(Of DriveInfo)
        For Each driveInfo As DriveInfo In DriveInfo.GetDrives()
            If driveInfo.DriveType <> DriveType.Fixed Then
                Continue For
            End If
            Yield driveInfo
        Next driveInfo
    End Function

    'Get all subfolders contained within the target directory
    Public Shared Function GetSubFolders(ByVal rootDir As String) As String()
        Dim subDirs As String() = GetSubDirs(rootDir)
        If subDirs Is Nothing Then
            Return New String() {}
        End If
        If subDirs.Length <= MaxEntitiesCount Then
            Return subDirs
        End If
        Dim res As String() = New String(MaxEntitiesCount - 1) {}
        Array.Copy(subDirs, res, res.Length)
        Return res
    End Function

    'Get the names of the subdirectories
    Public Shared Function GetSubDirs(ByVal dir As String) As String()
        Dim subDirs As String() = Nothing
        Try
            subDirs = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly)
        Catch
        End Try
        Return subDirs
    End Function

    Private Sub breadCrumbEdit1_PathChanged(ByVal sender As Object, ByVal e As BreadCrumbPathChangedEventArgs)

    End Sub

    Private Sub breadCrumbEdit1_Properties_PathChanged(ByVal sender As Object, ByVal e As BreadCrumbPathChangedEventArgs) Handles editBreadCrumb.Properties.PathChanged
        'label2.Text = editBreadCrumb.Path
        InitializeImageList()
    End Sub

    Private Sub ImageListBoxControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles ImageListBoxControl1.MouseClick
        Dim fi As New IO.FileInfo(editBreadCrumb.Path & "\" & ImageListBoxControl1.SelectedValue)
        If fi.Extension = ".pdf" Then PdfViewer1.LoadDocument(editBreadCrumb.Path & "\" & ImageListBoxControl1.SelectedValue)
    End Sub

    Private Sub ImageListBoxControl1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ImageListBoxControl1.MouseDoubleClick
        Dim sPath As String = BreadCrumb.Path & "\" & ImageListBoxControl1.SelectedValue
        BreadCrumb.Path = sPath

        If (My.Computer.FileSystem.DirectoryExists(sPath)) Then

            ImageListBoxControl1.Items.Clear()

            For Each i In My.Computer.FileSystem.GetDirectories((sPath))
                ImageListBoxControl1.Items.Add(i.Substring(i.LastIndexOf("\") + 1), 1)

            Next
            For Each i In My.Computer.FileSystem.GetFiles((sPath))
                Dim fi As New IO.FileInfo(i)
                ImageListBoxControl1.Items.Add(i.Substring(i.LastIndexOf("\") + 1), GetExtensionIco(i))
            Next
        Else
            'MsgBox("Its A File")
            System.Diagnostics.Process.Start(sPath)
        End If
    End Sub

    Private Sub frmBatchInsertAttachmentsEX_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            If GridView1.SelectedRowsCount = 0 Then
                XtraMessageBox.Show("Δεν έχετε επιλέξει έξοδο", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                If GridView1.GetRowCellValue(selectedRowHandle, "ID") IsNot Nothing Then
                    ' Αποθήκευση Αρχείων
                    If DBQ.InsertNewDataFilesFromListBox(ImageListBoxControl1, "IND_F", GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString, BreadCrumb.Path) = True Then

                    End If
                End If
            Next
            XtraMessageBox.Show("Η επισύναψη ολοκληρώθηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            PdfViewer1.CloseDocument()
            If cboBDG.EditValue = Nothing Then
                Me.Vw_INDTableAdapter.FillByIsManagedAndPaid(Me.Priamos_NETDataSet2.vw_IND, chkPaid.EditValue)
            Else
                Me.Vw_INDTableAdapter.FillByBDGAndPAid(Me.Priamos_NETDataSet2.vw_IND, System.Guid.Parse(cboBDG.EditValue.ToString), chkPaid.EditValue)
            End If
            ' Backup αρχείων
            BackupFiles()
            ' Ανανέωση αρχείων
            InitializeImageList()

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub BackupFiles()
        Dim MoveFiles As Boolean = False : Dim MoveFilesPath As String = ""
        If ProgProps.EXFolderMoveOnSuccessPath.Length > 0 Then MoveFiles = True : MoveFilesPath = ProgProps.EXFolderMoveOnSuccessPath
        If Debugger.IsAttached Then MoveFilesPath = "\\192.168.1.50\Share\PROOFS\UNFOLDERED\Finished"
        For Each item As DevExpress.XtraEditors.Controls.ImageListBoxItem In ImageListBoxControl1.SelectedItems
            Dim FileName As String = item.Value
            Try
                If MoveFiles Then
                    Dim sFilesPath As String = BreadCrumb.Path
                    Dim Found As Boolean = False
                    If File.Exists(MoveFilesPath & "\" & FileName) Then Found = True
                    My.Computer.FileSystem.MoveFile(sFilesPath & "\" & FileName, MoveFilesPath & "\" & IIf(Found, VBMath.Rnd.ToString.Replace(",", "") & "_" & FileName, FileName), True)
                    Found = False
                End If
            Catch exMove As Exception
                XtraMessageBox.Show(String.Format("Error: {0}" & "Η μεταφορά του αρχείου " & FileName & " στον φάκελλο " & MoveFilesPath & " Απέτυχε.", exMove.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView1, "INDF_BATCH.xml", "vw_IND")
        ElseIf e.MenuType = GridMenuType.Row Then
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub OpenPreviwer()
        Dim frmFilePreviwer As New frmFilePreviwer
        frmFilePreviwer.Text = "Προβολή Αρχείων"
        frmFilePreviwer.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
        frmFilePreviwer.Spl = SplashScreenManager1
        frmFilePreviwer.ShowDialog()
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If GridView1.IsGroupRow(GridView1.FocusedRowHandle) = False Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "HasFiles") = "True" Then
                SplashScreenManager1.ShowWaitForm()
                SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")
                OpenPreviwer()
            End If
        End If
    End Sub

    Private Sub BBOpenInh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBOpenInh.ItemClick
        OpenINH()
    End Sub
    Private Sub OpenINH()
        Dim fINH As frmINH = New frmINH

        fINH.Text = "Κοινόχρηστα"
        fINH.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "inhID").ToString
        fINH.MdiParent = frmMain
        fINH.Mode = FormMode.EditRecord
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
        fINH.Show()
    End Sub
    Private Sub BBOpenBdg_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBOpenBdg.ItemClick
        OpenBDG()
    End Sub
    Private Sub OpenBDG()
        Dim fBDG As frmBDG = New frmBDG()
        fBDG.Text = "Πολυκατοικίες"
        fBDG.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bdgID").ToString
        fBDG.bManageID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bManageID").ToString
        fBDG.MdiParent = frmMain
        fBDG.Mode = FormMode.EditRecord
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fBDG), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
        fBDG.Show()
    End Sub
    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue = Nothing Then Exit Sub
        Me.Vw_INDTableAdapter.FillByBDGAndPAid(Me.Priamos_NETDataSet2.vw_IND, System.Guid.Parse(cboBDG.EditValue.ToString), chkPaid.EditValue)
        Me.Vw_BDGTableAdapter.FillByIsManaged(Me.Priamos_NET_DataSet_BDG.vw_BDG)
        txtTotalDepositAmtR.EditValue = cboBDG.GetColumnValue("totDepositR")

    End Sub

    Private Sub chkPaid_CheckedChanged(sender As Object, e As EventArgs) Handles chkPaid.CheckedChanged
        If cboBDG.EditValue = Nothing Then
            Me.Vw_INDTableAdapter.FillByIsManagedAndPaid(Me.Priamos_NETDataSet2.vw_IND, chkPaid.EditValue)
        Else
            Me.Vw_INDTableAdapter.FillByBDGAndPAid(Me.Priamos_NETDataSet2.vw_IND, System.Guid.Parse(cboBDG.EditValue.ToString), chkPaid.EditValue)
        End If
    End Sub

    Private Sub BBDeleteFiles_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDeleteFiles.ItemClick
        DeleteFiles()
    End Sub
    Private Sub DeleteFiles()
        Dim sSQL As String
        Try
            Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            If GridView1.SelectedRowsCount = 0 Then
                XtraMessageBox.Show("Δεν έχετε επιλέξει έξοδο", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If XtraMessageBox.Show("Θέλετε να διαγραφούν τα αρχεία από τα επιλεγμένα έξοδα?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                For I = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                    If GridView1.GetRowCellValue(selectedRowHandle, "ID") IsNot Nothing Then
                        sSQL = "DELETE FROM IND_F WHERE indID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                    End If
                Next
            Else
                Exit Sub
            End If

            XtraMessageBox.Show("Η διαγραφή ολοκληρώθηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            If cboBDG.EditValue = Nothing Then
                Me.Vw_INDTableAdapter.FillByIsManagedAndPaid(Me.Priamos_NETDataSet2.vw_IND, chkPaid.EditValue)
            Else
                Me.Vw_INDTableAdapter.FillByBDGAndPAid(Me.Priamos_NETDataSet2.vw_IND, System.Guid.Parse(cboBDG.EditValue.ToString), chkPaid.EditValue)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BBUpdateEXtoUnpaid_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBUpdateEXtoUnpaid.ItemClick
        UpdatEXToUnpaid()
    End Sub
    Private Sub UpdatEXToUnpaid()
        Dim sSQL As String
        Try
            Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            If GridView1.SelectedRowsCount = 0 Then
                XtraMessageBox.Show("Δεν έχετε επιλέξει έξοδο", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If XtraMessageBox.Show("Θέλετε να ενημερωθούν τα επιλεγμένα έξοδα ως ""Απλήρωτα""?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                For I = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                    If GridView1.GetRowCellValue(selectedRowHandle, "ID") IsNot Nothing Then
                        sSQL = "UPDATE IND SET PAID = 0 WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                    End If
                    ' Ενημέρωση αποθεματικού
                    CalculateDepositA(GridView1.GetRowCellValue(selectedRowHandle, "bdgID").ToString)
                Next
            Else
                Exit Sub
            End If

            XtraMessageBox.Show("Η ενημέρωση ολοκληρώθηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            If cboBDG.EditValue = Nothing Then
                Me.Vw_INDTableAdapter.FillByIsManagedAndPaid(Me.Priamos_NETDataSet2.vw_IND, chkPaid.EditValue)
            Else
                Me.Vw_INDTableAdapter.FillByBDGAndPAid(Me.Priamos_NETDataSet2.vw_IND, System.Guid.Parse(cboBDG.EditValue.ToString), chkPaid.EditValue)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BBUpdateEXtopaid_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBUpdateEXtopaid.ItemClick
        UpdateEXToPaid()
    End Sub
    Private Sub UpdateEXToPaid()
        Dim sSQL As String
        Try
            Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            If GridView1.SelectedRowsCount = 0 Then
                XtraMessageBox.Show("Δεν έχετε επιλέξει έξοδο", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If XtraMessageBox.Show("Θέλετε να ενημερωθούν τα επιλεγμένα έξοδα ως ""Πληρωμένα""?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                For I = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                    If GridView1.GetRowCellValue(selectedRowHandle, "ID") IsNot Nothing Then
                        sSQL = "UPDATE IND SET PAID = 1 WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                        ' Ενημέρωση αποθεματικού
                        CalculateDepositA(GridView1.GetRowCellValue(selectedRowHandle, "bdgID").ToString)
                    End If
                Next
                XtraMessageBox.Show("Η ενημέρωση ολοκληρώθηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Exit Sub
            End If


            If cboBDG.EditValue = Nothing Then
                Me.Vw_INDTableAdapter.FillByIsManagedAndPaid(Me.Priamos_NETDataSet2.vw_IND, chkPaid.EditValue)
            Else
                Me.Vw_INDTableAdapter.FillByBDGAndPAid(Me.Priamos_NETDataSet2.vw_IND, System.Guid.Parse(cboBDG.EditValue.ToString), chkPaid.EditValue)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CalculateDepositA(ByVal sbdgID As String)
        Try
            Using oCmd As New SqlCommand("CalculateAndReturnDepositA", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@bdgID", sbdgID)
                oCmd.Parameters.Add("@Amt", SqlDbType.Decimal)
                oCmd.Parameters("@Amt").Direction = ParameterDirection.Output
                oCmd.ExecuteNonQuery()
            End Using
            'Υπολογισμός Διαθέσιμου υπολοίπου
            CalculateDepositR(sbdgID)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CalculateDepositR(ByVal sbdgID As String)
        Try
            Using oCmd As New SqlCommand("CalculateAndReturnDepositR", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@bdgID", sbdgID)
                oCmd.Parameters.Add("@totDepositR", SqlDbType.Decimal)
                oCmd.Parameters.Add("@UnchargableOil", SqlDbType.Decimal)
                oCmd.Parameters.Add("@UnpaidInd", SqlDbType.Decimal)
                oCmd.Parameters.Add("@PaidInd", SqlDbType.Decimal)
                oCmd.Parameters.Add("@AptBalAdm", SqlDbType.Decimal)
                oCmd.Parameters.Add("@totPrepayments", SqlDbType.Decimal)
                oCmd.Parameters.Add("@totDepositRAndPrepayments", SqlDbType.Decimal)
                oCmd.Parameters("@totDepositR").Direction = ParameterDirection.Output : oCmd.Parameters("@totDepositR").Precision = 18 : oCmd.Parameters("@totDepositR").Scale = 2
                oCmd.Parameters("@UnchargableOil").Direction = ParameterDirection.Output : oCmd.Parameters("@UnchargableOil").Precision = 18 : oCmd.Parameters("@UnchargableOil").Scale = 2
                oCmd.Parameters("@UnpaidInd").Direction = ParameterDirection.Output : oCmd.Parameters("@UnpaidInd").Precision = 18 : oCmd.Parameters("@UnpaidInd").Scale = 2
                oCmd.Parameters("@PaidInd").Direction = ParameterDirection.Output : oCmd.Parameters("@PaidInd").Precision = 18 : oCmd.Parameters("@PaidInd").Scale = 2
                oCmd.Parameters("@AptBalAdm").Direction = ParameterDirection.Output : oCmd.Parameters("@AptBalAdm").Precision = 18 : oCmd.Parameters("@AptBalAdm").Scale = 2
                oCmd.Parameters("@totPrepayments").Direction = ParameterDirection.Output : oCmd.Parameters("@totPrepayments").Precision = 18 : oCmd.Parameters("@totPrepayments").Scale = 2
                oCmd.Parameters("@totDepositRAndPrepayments").Direction = ParameterDirection.Output : oCmd.Parameters("@totDepositRAndPrepayments").Precision = 18 : oCmd.Parameters("@totDepositRAndPrepayments").Scale = 2
                oCmd.ExecuteNonQuery()
                txtTotalDepositAmtR.EditValue = oCmd.Parameters("@totDepositR").Value
                If txtTotalDepositAmtR.Text = "" Then txtTotalDepositAmtR.EditValue = "0.00"
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cboBDG_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonPressed
        Select Case e.Button.Index
            Case 1 : If cboBDG.EditValue <> Nothing Then ManageCbo.ManageBDG(cboBDG, FormMode.EditRecord)
            Case 2 : cboBDG.EditValue = Nothing : Me.Vw_INDTableAdapter.FillByIsManagedAndPaid(Me.Priamos_NETDataSet2.vw_IND, chkPaid.EditValue)
                txtTotalDepositAmtR.Text = "0.00"
        End Select
    End Sub
    Private Sub editBreadCrumb_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles editBreadCrumb.ButtonClick
        Select Case e.Button.Index
            Case 1 : InitializeImageList()
        End Select
    End Sub

    Private Sub cmdDeleteFiles_Click(sender As Object, e As EventArgs) Handles cmdDeleteFiles.Click
        DeleteFiles()
    End Sub

    Private Sub cmdOpenBdg_Click(sender As Object, e As EventArgs) Handles cmdOpenBdg.Click
        OpenBDG()
    End Sub

    Private Sub cmdOpenInh_Click(sender As Object, e As EventArgs) Handles cmdOpenInh.Click
        OpenINH()
    End Sub

    Private Sub cmdUpdateEXtopaid_Click(sender As Object, e As EventArgs) Handles cmdUpdateEXtopaid.Click
        UpdateEXToPaid()
    End Sub

    Private Sub cmdUpdateEXtoUnpaid_Click(sender As Object, e As EventArgs) Handles cmdUpdateEXtoUnpaid.Click
        UpdatEXToUnpaid()
    End Sub
End Class

