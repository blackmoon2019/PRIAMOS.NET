
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
        chkRememberUN.EditValue = My.Settings.UNSave
        If CN.OpenConnection = False Then XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την σύνδεση στο PRIAMOS .NET", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Έλεγχος νέας έκδοσης
        If CheckFUpdate.FindNewVersion Then

        Else
            FillCbo.USR(txtUN)
            If My.Settings.UNSave = True Then txtUN.EditValue = System.Guid.Parse(My.Settings.UN.ToString)
            If Debugger.IsAttached Then
                'txtUN.Text = "blackmoon"
                txtUN.EditValue = System.Guid.Parse("E9CEFD11-47C0-4796-A46B-BC41C4C3606B")
                txtPWD.Text = "mavros1!"
                cmdLogin.Select()
            Else
                ' Assume we aren't running from the IDE
            End If
        End If
    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try

            sSQL = "select Realname,code,ID,M_UN from vw_USR 
                where UN= '" & txtUN.Text & "' and pwd = '" & txtPWD.Text & "'"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then
                If sdr.IsDBNull(sdr.GetOrdinal("Realname")) = False Then
                    UserProps.Code = sdr.GetInt32(sdr.GetOrdinal("code"))
                    UserProps.RealName = sdr.GetString(sdr.GetOrdinal("Realname"))
                    UserProps.ID = sdr.GetGuid(sdr.GetOrdinal("ID"))
                    UserProps.Email = sdr.GetString(sdr.GetOrdinal("M_un"))
                    'Δεκαδικά Προγράμματος
                    ProgProps.Decimals = Prog_Prop.GetProgDecimals
                    'Support Email
                    ProgProps.SupportEmail = Prog_Prop.GetProgTechSupportEmail

                    'General Permissions
                    UserPermissions.GetUserPermissions()
                    sSQL = "UPDATE USR SET dtLogin = getdate(),Status = 1 where ID = " & toSQLValueS(UserProps.ID.ToString)
                    cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
                    XtraMessageBox.Show("Καλως ήρθατε στο PRIAMOS .NET " & UserProps.RealName, "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If My.Settings.UNSave = True Then My.Settings.UN = txtUN.EditValue : My.Settings.Save()
                End If
                frmMain.Show()
                Me.Close()
            Else
                XtraMessageBox.Show("Πληκτρολογήσατε λάθος στοιχεία. Παρακαλώ προσπαθήστε ξανά.", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtUN_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then txtPWD.Select()
    End Sub

    Private Sub txtPWD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPWD.KeyDown
        If e.KeyCode = Keys.Enter Then cmdLogin.Select()
    End Sub

    Private Sub chkRememberUN_CheckedChanged(sender As Object, e As EventArgs) Handles chkRememberUN.CheckedChanged
        My.Settings.UNSave = chkRememberUN.EditValue
        If My.Settings.UNSave = False Then
            My.Settings.UN = System.Guid.Parse("00000000-0000-0000-0000-000000000000")
            My.Settings.Save()
        End If
    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        frmDBConnection.Show()
    End Sub
End Class