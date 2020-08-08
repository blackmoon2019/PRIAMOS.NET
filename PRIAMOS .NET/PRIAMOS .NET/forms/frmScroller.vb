Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraBars

Public Class frmScroller
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private sDataTable As String
    Private settings = System.Configuration.ConfigurationManager.AppSettings
    Private Sub frmScroller_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadComboRecordValues()
        popSaveAsView.EditValue = BarViews.EditValue
        If BarViews.EditValue = "" Then popSaveView.Enabled = False : popDeleteView.Enabled = False
        'myCmd = CNDB.CreateCommand
        'myCmd.CommandText = "SELECT top " & BarRecords.EditValue & " * FROM iat"
        'myReader = myCmd.ExecuteReader()
        'grdMain.DataSource = myReader
    End Sub
    'Λίστα με τιμές για TOP RECORDS
    Private Sub LoadComboRecordValues()

        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("30")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("200")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("1000")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("10000")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("ALL")
        BarRecords.EditValue = My.Settings.Records

    End Sub
    'Φόρτωση όψεων Per User στο Combo
    Private Sub LoadViews()
        Dim files() As String = IO.Directory.GetFiles(Application.StartupPath & "\DSGNS\" & sDataTable, "*_" & sUserCode & "*")

        For Each sFile As String In files
            CType(BarViews.Edit, RepositoryItemComboBox).Items.Add(System.IO.Path.GetFileName(sFile))
        Next

    End Sub

    Private Sub BarRecords_EditValueChanged(sender As Object, e As EventArgs) Handles BarRecords.EditValueChanged
        myCmd = CNDB.CreateCommand
        If BarRecords.EditValue <> "ALL" Then
            myCmd.CommandText = "SELECT top " & BarRecords.EditValue & " * FROM " & sDataTable
        Else
            myCmd.CommandText = "SELECT  * FROM " & sDataTable
        End If
        If grdMain.DefaultView.DataRowCount <> 0 Then myReader.Close()
        myReader = myCmd.ExecuteReader()
        grdMain.DataSource = myReader
        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml") = False Then
            grdMain.DefaultView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml")
        End If
        'Εαν δεν υπάρχει Folder Σχεδίου για το συγκεκριμένο πίνακα δημιουργεί
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\DSGNS\" & sDataTable) = False Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\DSGNS\" & sDataTable)
        End If
        'Φόρτωση Σχεδίων στην Λίστα βάση επιλογής από το μενού
        LoadViews()

        My.Settings.Records = BarRecords.EditValue
        My.Settings.Save()

    End Sub
    Public WriteOnly Property DataTable As String
        Set(value As String)
            sDataTable = value
        End Set
    End Property

    Private Sub BarViews_EditValueChanged(sender As Object, e As EventArgs) Handles BarViews.EditValueChanged
        popSaveAsView.EditValue = BarViews.EditValue
        If BarViews.EditValue <> "" Then
            grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
            popSaveView.Enabled = True
            popDeleteView.Enabled = True
        End If
    End Sub
    Private Sub frmScroller_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        myReader.Close()
    End Sub

    Private Sub popDeleteView_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popDeleteView.ItemClick
        If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα όψη?", "PRIAMOS .NET", MessageBoxButtons.YesNo) = vbYes Then
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
            CType(BarViews.Edit, RepositoryItemComboBox).Items.Remove(BarViews.EditValue)
            BarViews.EditValue = ""
        End If

    End Sub

    Private Sub RepositoryPopSaveAsView_KeyDown(sender As Object, e As KeyEventArgs) Handles RepositoryPopSaveAsView.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdMain.DefaultView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & sender.EditValue & "_" & sUserCode & ".xml")
            CType(BarViews.Edit, RepositoryItemComboBox).Items.Add(sender.EditValue & "_" & sUserCode & ".xml")
            BarViews.EditValue = sender.EditValue & "_" & sUserCode & ".xml"
        End If
    End Sub

    Private Sub popSaveView_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popSaveView.ItemClick
        grdMain.DefaultView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & popSaveAsView.EditValue)
        XtraMessageBox.Show("Η όψη αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK)
    End Sub

    Private Sub popRestoreView_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popRestoreView.ItemClick
        grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml")
        BarViews.EditValue = "" : popSaveAsView.EditValue = "" : popSaveView.Enabled = False : popDeleteView.Enabled = False
    End Sub

End Class