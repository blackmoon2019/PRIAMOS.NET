Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmUsers
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
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
        Dim sSQL As String
        Try
            Select Case Mode
                Case FormMode.NewRecord
                    sSQL = "INSERT INTO USR ([UN],[PWD],[REALNAME],[MAILID],[modifiedBy],[createdOn] )" &
                            "values (" & toSQLValue(txtUN) & "," &
                                         toSQLValue(txtPWD) & "," &
                                         toSQLValue(txtRealName) & "," &
                                         toSQLValueS(cboMail.EditValue.ToString) & "," &
                                         toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                Case FormMode.EditRecord
                    If Valid.ValidateForm(LayoutControl1) Then
                        sSQL = "UPDATE USR set UN =  " & toSQLValue(txtUN) & "," &
                               "PWD = " & toSQLValue(txtPWD) & "," &
                               "RealName = " & toSQLValue(txtRealName) & "," &
                               "modifiedBy = " & toSQLValueS(UserProps.ID.ToString) & "," &
                               "MailID = " & toSQLValueS(cboMail.EditValue.ToString) &
                               " where id = '" & sID & "'"
                    End If
            End Select
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
                Dim form As frmScroller = Frm
                form.LoadRecords("vw_USR")
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FillCombo()
        Try
            Dim ds As DataSet = New DataSet
            Dim cmd As SqlCommand = New SqlCommand("Select id,Server from vw_MAILS", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            cboMail.Properties.DataSource = sdr
            cboMail.Properties.DisplayMember = "Server"
            cboMail.Properties.ValueMember = "id"
            cboMail.Properties.PopulateColumns()
            cboMail.Properties.Columns(0).Visible = False
            cboMail.Properties.Columns(1).Caption = "Email Account"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            FillCombo()
            Select Case Mode
                Case FormMode.EditRecord
                    Dim cmd As SqlCommand = New SqlCommand("Select * from vw_USR where id ='" + sID + "'", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        If sdr.IsDBNull(sdr.GetOrdinal("un")) = False Then txtUN.Text = sdr.GetString(sdr.GetOrdinal("un"))
                        If sdr.IsDBNull(sdr.GetOrdinal("pwd")) = False Then txtPWD.Text = sdr.GetString(sdr.GetOrdinal("pwd"))
                        If sdr.IsDBNull(sdr.GetOrdinal("realname")) = False Then txtRealName.Text = sdr.GetString(sdr.GetOrdinal("realname"))
                        If sdr.IsDBNull(sdr.GetOrdinal("MailID")) = False Then cboMail.EditValue = sdr.GetGuid(sdr.GetOrdinal("MailID"))
                        sdr.Close()
                    End If
                    cmdSave.Enabled = UserProps.AllowEdit
                Case FormMode.NewRecord
                    cmdSave.Enabled = UserProps.AllowInsert
            End Select
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