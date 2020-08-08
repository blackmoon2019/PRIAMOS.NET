
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim CN As New CN
        If CN.OpenConnection = False Then XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την σύνδεση στο PRIAMOS .NET", "PRIAMOS .NET", MessageBoxButtons.OK)
        If Debugger.IsAttached Then
            txtUN.Text = "blackmoon"
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
        sSQL = "select Realname,code from USR 
                where UN= '" & txtUN.Text & "' and pwd = '" & txtPWD.Text & "'"
        cmd = New SqlCommand(sSQL, CNDB)
        sdr = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            If sdr.IsDBNull(sdr.GetOrdinal("Realname")) = False Then
                sUserCode = sdr.GetInt32(sdr.GetOrdinal("code"))
                XtraMessageBox.Show("Καλως ήρθατε στο PRIAMOS .NET " & sdr.GetString(sdr.GetOrdinal("Realname")), "PRIAMOS .NET", MessageBoxButtons.OK)
            End If
            sdr.Close()
            frmMain.Show()
            Me.Close()

        End If

    End Sub
    Private Sub txtUN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUN.KeyDown
        If e.KeyCode = Keys.Enter Then txtPWD.Select()
    End Sub

    Private Sub txtPWD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPWD.KeyDown
        If e.KeyCode = Keys.Enter Then cmdLogin.Select()
    End Sub
End Class