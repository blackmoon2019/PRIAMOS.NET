Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmUsers
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
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
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "USR", LayoutControl1)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "USR", LayoutControl1,,, sID)
                End Select
                Dim form As New frmScroller
                form.LoadRecords("vw_USR")
                If sResult Then
                    'Καθαρισμός Controls
                    Cls.ClearCtrls(LayoutControl1)
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FillCbo.MAIL(cboMail)
            Select Case Mode
                Case FormMode.EditRecord
                    LoadForms.LoadForm(LayoutControl1, "Select * from vw_USR where id ='" + sID + "'")
                    cmdSave.Enabled = UserProps.AllowEdit
                Case FormMode.NewRecord
                    cmdSave.Enabled = UserProps.AllowInsert
            End Select
            Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
            Me.CenterToScreen()
            My.Settings.frmUsers = Me.Location
            My.Settings.Save()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmUsers_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub txtPWD_GotFocus(sender As Object, e As EventArgs) Handles txtPWD.GotFocus
        frmMain.bbFields.Caption = "DB Field: USERS.pwd"
    End Sub

    Private Sub txtRealName_GotFocus(sender As Object, e As EventArgs) Handles txtRealName.GotFocus
        frmMain.bbFields.Caption = "DB Field: USERS.realname"
    End Sub

    Private Sub txtUN_GotFocus(sender As Object, e As EventArgs) Handles txtUN.GotFocus
        frmMain.bbFields.Caption = "DB Field: USERS.un"
    End Sub

    Private Sub cboMail_GotFocus(sender As Object, e As EventArgs) Handles cboMail.GotFocus
        frmMain.bbFields.Caption = "DB Field: USERS.mailid"
    End Sub

    Private Sub frmUsers_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                e.Cancel = True
            End If
        End If

    End Sub
    'Private Sub FillList()
    '    Dim ds As DataSet = New DataSet
    '    Dim cmd As SqlCommand = New SqlCommand("Select id,Server from vw_MAILS", CNDB)
    '    Dim sdr As SqlDataReader = cmd.ExecuteReader()
    '    'chkMail.DataSource = sdr
    '    'chkMail.DisplayMember = "Server"
    '    'chkMail.ValueMember = "id"
    '    While sdr.Read()
    '        chkMail.Items.Add(sdr.Item(1).ToString)
    '        chkMail.Items(chkMail.Items.Count - 1).Tag = sdr.Item(0).ToString
    '    End While
    '    sdr.Close()



    'End Sub
End Class