Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.Data.SqlClient

Public Class frmDBConnection
    Private CN As New CN
    Private Valid As New ValidateControls
    Private sDatabaseName As String
    Private Sub frmDBConnection_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboAuthentication.Properties.Items.Add("SQL Server Authentication")
        cboAuthentication.Properties.Items.Add("Windows Authentication")
        cmdConnect.Enabled = False

    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click

        Dim Auth As String
        If cboAuthentication.EditValue = "SQL Server Authentication" Then Auth = "True" Else Auth = "False"
        If CN.OpenConnectionWithParam(txtServerName.Text, Auth, txtLogin.Text, txtPWD.Text, cboDatabases.EditValue) = False Then
            XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την σύνδεση στο PRIAMOS .NET", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            XtraMessageBox.Show("Σύνδεση επιτυχής!! στο " & sDatabaseName, "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CNDB = CNDB2
        End If
    End Sub


    Private Sub cboDatabases_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboDatabases.ButtonPressed


        Select Case e.Button.Index
            Case 1
                If Valid.ValidateForm(LayoutControl1) Then
                    Dim Auth As String
                If cboAuthentication.EditValue = "SQL Server Authentication" Then Auth = "True" Else Auth = "False"
                    If CN.OpenConnectionWithParam(txtServerName.Text, Auth, txtLogin.Text, txtPWD.Text, "master") Then
                        Dim cmd As SqlCommand = New SqlCommand("sp_databases", CNDB2)
                        cmd.CommandType = CommandType.StoredProcedure
                        Dim sdr As SqlDataReader = cmd.ExecuteReader()
                        cboDatabases.Properties.DataSource = ""
                        cboDatabases.Properties.Columns.Clear()
                        cboDatabases.Properties.DataSource = sdr
                        cboDatabases.Properties.DisplayMember = "DATABASE_NAME"
                        cboDatabases.Properties.ValueMember = "DATABASE_NAME"
                        cboDatabases.Properties.PopulateColumns()
                        cboDatabases.Properties.Columns(0).Caption = "Βάσεις"
                        cboDatabases.Properties.Columns(1).Visible = False
                        cboDatabases.Properties.Columns(2).Visible = False
                        sdr.Close()
                    End If
                End If
                'Case 2 : cboCOU.EditValue = Nothing
        End Select

    End Sub

    Private Sub cboDatabases_EditValueChanged(sender As Object, e As EventArgs) Handles cboDatabases.EditValueChanged
        If sender.editvalue <> Nothing Then cmdConnect.Enabled = True : sDatabaseName = sender.editvalue
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class