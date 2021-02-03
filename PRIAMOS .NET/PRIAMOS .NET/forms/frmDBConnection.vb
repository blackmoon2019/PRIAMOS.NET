Imports Microsoft.SqlServer.Management.Sdk.Sfc
Imports Microsoft.SqlServer.Management.Smo
Imports System.Windows.Forms
Imports System.Data
Imports System
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.Data.SqlClient

Public Class frmDBConnection
    Private CN As New CN
    Private Sub frmDBConnection_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboAuthentication.Properties.Items.Add("SQL Server Authentication")
        cboAuthentication.Properties.Items.Add("Windows Authentication")

    End Sub
    Private Sub LoadSQLServers(ByVal sqlCombo As DevExpress.XtraEditors.LookUpEdit)

    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click

        Dim Auth As String
        If cboAuthentication.EditValue = "SQL Server Authentication" Then Auth = "True" Else Auth = "False"
        If CN.OpenConnectionWithParam(txtServerName.Text, Auth, txtLogin.Text, txtPWD.Text, cboDatabases.EditValue) = False Then
            XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την σύνδεση στο PRIAMOS .NET", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub cboDatabases_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboDatabases.ButtonPressed
        Dim Auth As String
        If cboAuthentication.EditValue = "SQL Server Authentication" Then Auth = "True" Else Auth = "False"
        If CN.OpenConnectionWithParam(txtServerName.Text, Auth, txtLogin.Text, txtPWD.Text, "master") Then
            Select Case e.Button.Index
                Case 0
                    Dim cmd As SqlCommand = New SqlCommand("SELECT name from sys.databases  order by name", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    cboDatabases.Properties.DataSource = sdr
                    cboDatabases.Properties.DisplayMember = "name"
                    cboDatabases.Properties.ValueMember = "name"
                    cboDatabases.Properties.PopulateColumns()
                    sdr.Close()
                    'Case 2 : cboCOU.EditValue = Nothing
            End Select
        End If
    End Sub
End Class