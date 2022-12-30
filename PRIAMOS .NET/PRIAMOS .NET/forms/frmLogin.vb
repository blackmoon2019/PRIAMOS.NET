
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports DevExpress.XtraEditors

Public Class frmLogin
    Private UserPermissions As New CheckPermissions
    Private Prog_Prop As New ProgProp
    Private CheckFUpdate As New CheckForUpdates
    Private FillCbo As New FillCombos

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim CN As New CN
        'MultipleActiveResultSets=True
        ProgProps.ProgTitle = "PRIAMOS .NET"
        UserProps.UNSave = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Priamos.NET", "UNSave", "2")
        UserProps.MachineName = Environment.MachineName

        chkRememberUN.Checked = UserProps.UNSave
        If CNDB.ConnectionString.ToString = "" Then
            If CN.OpenConnection = False Then XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την σύνδεση στο PRIAMOS .NET", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If Debugger.IsAttached = False Then
                'Έλεγχος νέας έκδοσης
                If CheckFUpdate.FindNewVersion Then

                End If
            End If
        End If
        FillCbo.USR(cboUN)
        UserProps.UN = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Priamos.NET", "UN", System.Guid.Empty.ToString)
        If UserProps.UNSave = "1" Then cboUN.EditValue = System.Guid.Parse(UserProps.UN)
        If Debugger.IsAttached Then
            'txtUN.Text = "blackmoon"
            cboUN.EditValue = System.Guid.Parse("E9CEFD11-47C0-4796-A46B-BC41C4C3606B")
            txtPWD.Text = "mavros1!"
            cmdLogin.Select()
        Else
            ' Assume we aren't running from the IDE
        End If


    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try

            sSQL = "select Realname,code,ID,M_UN,M_pwd,server,port,ssl from vw_USR 
                where UN= '" & cboUN.Text & "' and pwd = '" & txtPWD.Text & "'"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then
                If sdr.IsDBNull(sdr.GetOrdinal("Realname")) = False Then
                    UserProps.Code = sdr.GetInt32(sdr.GetOrdinal("code"))
                    UserProps.RealName = sdr.GetString(sdr.GetOrdinal("Realname"))
                    If sdr.IsDBNull(sdr.GetOrdinal("ID")) = False Then UserProps.ID = sdr.GetGuid(sdr.GetOrdinal("ID"))
                    If sdr.IsDBNull(sdr.GetOrdinal("M_un")) = False Then UserProps.Email = sdr.GetString(sdr.GetOrdinal("M_un"))
                    If sdr.IsDBNull(sdr.GetOrdinal("server")) = False Then UserProps.EmailServer = sdr.GetString(sdr.GetOrdinal("server"))
                    If sdr.IsDBNull(sdr.GetOrdinal("M_pwd")) = False Then UserProps.EmailPassword = sdr.GetString(sdr.GetOrdinal("M_pwd"))
                    If sdr.IsDBNull(sdr.GetOrdinal("port")) = False Then UserProps.EmailPort = sdr.GetInt32(sdr.GetOrdinal("port"))
                    If sdr.IsDBNull(sdr.GetOrdinal("ssl")) = False Then UserProps.EmailSSL = sdr.GetBoolean(sdr.GetOrdinal("ssl"))
                    'Δεκαδικά Προγράμματος
                    ProgProps.Decimals = Prog_Prop.GetProgDecimals
                    'Support Email
                    ProgProps.SupportEmail = Prog_Prop.GetProgTechSupportEmail
                    ProgProps.EXFolderPath = Prog_Prop.GetProgEXFolderPath
                    ProgProps.ADM = Prog_Prop.GetProgADM
                    ProgProps.ANNMENT = Prog_Prop.GetProgANNMENT
                    'Παράμετροι Email Κοινοχρήστων
                    Prog_Prop.GetProgInvoicesEmail()
                    sSQL = "UPDATE USR SET dtLogin = getdate(),Status = 1 where ID = " & toSQLValueS(UserProps.ID.ToString)
                    cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()

                    'Δημιουργία Κλειδιών

                    If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Priamos.NET") Is Nothing Then My.Computer.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Priamos.NET")
                    ProgProps.ServerViewsPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Priamos.NET", "SERVERVIEWS", "")
                    ProgProps.ServerPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Priamos.NET", "SERVER_PATH", "")
                    ProgProps.Records = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Priamos.NET", "Records", 0)
                    UserProps.UNSave = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Priamos.NET", "UNSave", "2")


                    If ProgProps.ServerPath = "" Then My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Priamos.NET", "SERVER_PATH", "\\192.168.1.52\TempFiles\")
                    If ProgProps.ServerViewsPath = "" Then My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Priamos.NET", "SERVERVIEWS", "\\192.168.1.52\priamos.net\CrmViews\")
                    If ProgProps.Records = 0 Then My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Priamos.NET", "Records", "30")
                    If chkRememberUN.CheckState = CheckState.Checked Then
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Priamos.NET", "UNSave", "1")
                    Else
                        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Priamos.NET", "UNSave", "0")
                    End If

                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Priamos.NET", "UN", cboUN.EditValue.ToString) : UserProps.UN = cboUN.EditValue.ToString

                    XtraMessageBox.Show("Καλως ήρθατε στο PRIAMOS .NET " & UserProps.RealName, ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)


                End If

                    'Progprops.ServerViewsPath = My.Settings.SERVERVIEWS
                    frmMain.Show()
                Me.Close()
            Else
                XtraMessageBox.Show("Πληκτρολογήσατε λάθος στοιχεία. Παρακαλώ προσπαθήστε ξανά.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtUN_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtPWD.Select()
    End Sub

    Private Sub txtPWD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPWD.KeyDown
        If e.KeyCode = Keys.Enter Then cmdLogin.Select()
    End Sub

    Private Sub chkRememberUN_CheckedChanged(sender As Object, e As EventArgs) Handles chkRememberUN.CheckedChanged
        If chkRememberUN.Checked = False Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Priamos.NET", "UNSave", "0")
            UserProps.UNSave = "0"
        Else
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Priamos.NET", "UNSave", "1")
            UserProps.UNSave = "1"
        End If

    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        frmDBConnection.Show()
        Me.Close()
    End Sub
End Class