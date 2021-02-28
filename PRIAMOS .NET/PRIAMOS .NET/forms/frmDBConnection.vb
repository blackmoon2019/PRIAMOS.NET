Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.Data.SqlClient
Imports System.Configuration

Public Class frmDBConnection
    Private CN As New CN
    Private Valid As New ValidateControls
    Private sDatabaseName As String
    Private NewButtonPressed As Boolean = False
    Private Sub frmDBConnection_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboAuthentication.Properties.Items.Add("SQL Server Authentication")
        cboAuthentication.Properties.Items.Add("Windows Authentication")
        cmdConnect.Enabled = False
        Dim ConString = New System.Collections.Specialized.StringCollection
        ConString = My.Settings.ConStringServers
        If ConString Is Nothing Then Exit Sub
        cboSavedServers.Properties.Items.AddRange(ConString)
    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click

        Dim Auth As String
        If cboAuthentication.EditValue = "SQL Server Authentication" Then Auth = "True" Else Auth = "False"
        If CN.OpenConnectionWithParam(txtServerName.Text, Auth, txtLogin.Text, txtPWD.Text, cboDatabases.EditValue) = False Then
            XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την σύνδεση στο PRIAMOS .NET", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            XtraMessageBox.Show("Σύνδεση επιτυχής!! στο " & sDatabaseName, "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CNDB = CNDB2
            If NewButtonPressed Or cboSavedServers.EditValue Is Nothing Then
                If XtraMessageBox.Show("Θέλετε να σωθεί η σύνδεση για μελοντική χρήση?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    If My.Settings.ConString Is Nothing Then My.Settings.ConString = New Specialized.StringCollection
                    My.Settings.ConString.Add(CNDB.ConnectionString.ToString)
                    My.Settings.Save()
                    If My.Settings.ConStringServers Is Nothing Then My.Settings.ConStringServers = New Specialized.StringCollection
                    My.Settings.ConStringServers.Add(CNDB.DataSource)
                    My.Settings.Save()
                    Dim ConString = New System.Collections.Specialized.StringCollection
                    ConString = My.Settings.ConStringServers
                    cboSavedServers.Properties.Items.Clear()
                    cboSavedServers.Properties.Items.AddRange(ConString)
                End If
            End If
        End If
    End Sub


    Private Sub cboDatabases_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboDatabases.ButtonPressed


        Select Case e.Button.Index
            Case 1
                If Valid.ValidateForm(LayoutControl1) Then
                    Dim Auth As String
                If cboAuthentication.EditValue = "SQL Server Authentication" Then Auth = "True" Else Auth = "False"
                    If CN.OpenConnectionWithParam(txtServerName.Text, Auth, txtLogin.Text, txtPWD.Text, "master") Then
                        GetDatabases()
                    End If
                End If
                'Case 2 : cboCOU.EditValue = Nothing
        End Select

    End Sub
    Private Sub GetDatabases()
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

    End Sub
    Private Sub cboDatabases_EditValueChanged(sender As Object, e As EventArgs) Handles cboDatabases.EditValueChanged
        If sender.editvalue <> Nothing Then cmdConnect.Enabled = True : sDatabaseName = sender.editvalue
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        frmLogin.Show()
        Me.Close()
    End Sub

    Private Sub cboSavedServers_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboSavedServers.ButtonPressed
        Select Case e.Button.Index
            Case 1
                If XtraMessageBox.Show("Θέλετε να διαγραφή η σύνδεση?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    cboSavedServers.Properties.Items.Remove(cboSavedServers.SelectedItem)
                    My.Settings.ConStringServers.Remove(cboSavedServers.EditValue)
                    My.Settings.Save()
                    'My.Settings.ConString.Remove(cboSavedServers.EditValue)
                    'My.Settings.Save()

                End If
            Case 2
                NewButtonPressed = True
                txtPWD.Text = ""
                txtLogin.Text = ""
                txtServerName.Text = ""
                cboAuthentication.EditValue = Nothing
                cboDatabases.EditValue = Nothing
                cboSavedServers.EditValue = Nothing
                cmdConnect.Enabled = False

        End Select
    End Sub

    Private Sub cboSavedServers_EditValueChanged(sender As Object, e As EventArgs) Handles cboSavedServers.EditValueChanged
        Dim sCon As String
        Dim ConString = New System.Collections.Specialized.StringCollection
        ConString = My.Settings.ConString
        If cboSavedServers.EditValue = Nothing Then Exit Sub
        sCon = ConString.Item(cboSavedServers.SelectedIndex)

        Dim builder = New SqlConnectionStringBuilder(sCon)
        txtPWD.Text = builder.Password
        txtLogin.Text = builder.UserID
        txtServerName.Text = builder.DataSource
        If builder.PersistSecurityInfo = True Then
            cboAuthentication.SelectedIndex = 0
        End If
        If CN.OpenConnectionWithParam(txtServerName.Text, builder.PersistSecurityInfo.ToString, txtLogin.Text, txtPWD.Text, "master") Then
            GetDatabases()
        End If
        cboDatabases.EditValue = builder.InitialCatalog
        NewButtonPressed = False
    End Sub

    Private Sub cboAuthentication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAuthentication.SelectedIndexChanged
        Select Case cboAuthentication.SelectedIndex
            Case 0
                txtLogin.Enabled = True
                txtPWD.Enabled = True
            Case 1
                txtLogin.Enabled = False
                txtLogin.EditValue = ""
                txtPWD.Enabled = False
                txtPWD.EditValue = ""
        End Select
    End Sub
End Class