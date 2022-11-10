Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPermissions
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private Log As New Transactions
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private LoadForms As New FormLoader
    Private Cls As New ClearControls
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property Scroller As DevExpress.XtraGrid.Views.Grid.GridView
        Set(value As DevExpress.XtraGrid.Views.Grid.GridView)
            Ctrl = value
        End Set
    End Property
    Public WriteOnly Property FormScroller As DevExpress.XtraEditors.XtraForm
        Set(value As DevExpress.XtraEditors.XtraForm)
            Frm = value
        End Set
    End Property

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmPermissions_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet3.FORMRIGHTS' table. You can move, or remove it, as needed.
        Me.FORMRIGHTSTableAdapter.Fill(Me.Priamos_NETDataSet3.FORMRIGHTS)
        Try
            ' Γεμίζω τους χρήστες στον Combo
            'FillCbo.USERS(cboUsers)

            Select Case Mode
                Case FormMode.EditRecord
                    'Γεμίζω την CheckList με τις φορμες
                    'FillCbo.FillCheckedListForms(chkLstUsers, FormMode.EditRecord, sID)
                    'LoadForms.LoadForm(LayoutControl1, "Select * from vw_RIGHTS where id ='" + sID + "'")
                    'cboUsers.ReadOnly = True
                    cmdSave.Enabled = UserProps.AllowEdit
                Case FormMode.NewRecord
                    'Γεμίζω την CheckList με τις φορμες
                    'FillCbo.FillCheckedListForms(chkLstUsers, FormMode.NewRecord)
                    cmdSave.Enabled = UserProps.AllowInsert
            End Select
            '        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
            If System.IO.File.Exists(Application.StartupPath & "\DSGNS\DEF\RIGHTS_def.xml") = True Then
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\RIGHTS_def.xml", OptionsLayoutBase.FullLayout)
            End If
            Me.CenterToScreen()
            My.Settings.frmUsers = Me.Location
            My.Settings.Save()

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            Using oCmd As New SqlCommand("AddNewFormRights", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@FormName ", txtFormName.EditValue)
                oCmd.ExecuteNonQuery()
                Me.FORMRIGHTSTableAdapter.ClearBeforeFill = True
                Me.FORMRIGHTSTableAdapter.Fill(Me.Priamos_NETDataSet3.FORMRIGHTS)
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        'Dim sSQL As String
        'Dim sGuid As String
        'Dim sResult As Boolean
        'Try
        '    If Valid.ValidateForm(LayoutControl1) Then
        '        Select Case Mode
        '            Case FormMode.NewRecord
        '                ' Καταχώρηση General Permissions
        '                sGuid = System.Guid.NewGuid.ToString
        '                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "RIGHTS", LayoutControl1,,, sGuid)
        '                If sResult Then
        '                    ' Καταχώρηση Permissions Per Form
        '                    'For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In chkLstUsers.CheckedItems
        '                    '    sSQL = "INSERT INTO FORM_RIGHTS ([RID],[FID],[modifiedBy],[createdOn])  
        '                    '            values (" & toSQLValueS(sGuid) & "," & toSQLValueS(item.Tag.ToString()) & "," &
        '                    '                        toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
        '                    '    Using oCmd As New SqlCommand(sSQL, CNDB)
        '                    '        oCmd.ExecuteNonQuery()
        '                    '    End Using
        '                    'Next
        '                End If
        '            Case FormMode.EditRecord
        '                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "RIGHTS", LayoutControl1,,, sID)
        '                If sResult Then
        '                    sSQL = "DELETE FROM FORM_RIGHTS where RID = '" & sID & "'"
        '                    Using oCmd As New SqlCommand(sSQL, CNDB)
        '                        oCmd.ExecuteNonQuery()
        '                    End Using
        '                    ' Καταχώρηση Permissions Per Form
        '                    'For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In chkLstUsers.CheckedItems
        '                    '    sSQL = "INSERT INTO FORM_RIGHTS ([RID],[FID],[modifiedBy],[createdOn])  
        '                    '        values (" & toSQLValueS(sID) & "," & toSQLValueS(item.Tag.ToString) & "," &
        '                    '                        toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
        '                    '    Using oCmd As New SqlCommand(sSQL, CNDB)
        '                    '        oCmd.ExecuteNonQuery()
        '                    '    End Using
        '                    'Next
        '                End If
        '        End Select
        '        'Dim form As New frmScroller
        '        'form.LoadRecords("vw_RIGHTS")
        '        If sResult Then
        '            'Καθαρισμός Controls
        '            Cls.ClearCtrls(LayoutControl1)
        '            XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Valid.SChanged = False
        '        End If
        '    End If
        'Catch ex As Exception
        '    XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Private Sub frmPermissions_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub frmPermissions_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'If Valid.SChanged Then
        '    If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '        Valid.SChanged = False
        '    Else
        '        e.Cancel = True
        '    End If
        'End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            Dim sSQL As String = "UPDATE FORM_RIGHTS  SET " &
                                " [view] =  " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "view")) &
                                " ,[insert] =  " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "insert")) &
                                " ,[edit] =  " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "edit")) &
                                " ,[delete] =  " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "delete")) &
                                " WHERE ID = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString)

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView1, "RIGHTS_def.xml")
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        Select Case e.KeyCode
            Case Keys.F2  'If UserProps.AllowInsert = True Then NewRecord()
            Case Keys.F3  'If UserProps.AllowEdit = True Then EditRecord()
            Case Keys.F5
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteRecord()
        End Select
    End Sub
    Private Sub DeleteRecord()
        Dim sSQL As String
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") = Nothing Then Exit Sub
        If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            sSQL = "DELETE FROM FORM_RIGHTS WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Me.FORMRIGHTSTableAdapter.ClearBeforeFill = True
            Me.FORMRIGHTSTableAdapter.Fill(Me.Priamos_NETDataSet3.FORMRIGHTS)

        End If
    End Sub
End Class