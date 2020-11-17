Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Public Class FillCombos
    Public Sub AREAS(CtrlCombo As DevExpress.XtraEditors.LookUpEdit, ByVal sSQL As System.Text.StringBuilder)
        Try

            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_AREAS  " & sSQL.ToString & " order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            CtrlCombo.Properties.DataSource = ""
            CtrlCombo.Properties.Columns.Clear()
            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Name"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Περιοχές"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub ADR(CtrlCombo As DevExpress.XtraEditors.LookUpEdit, ByVal sSQL As System.Text.StringBuilder)
        Try
            If sSQL.Length = 0 Then sSQL.AppendLine("Select id,Name from vw_ADR ")
            Dim cmd As SqlCommand = New SqlCommand(sSQL.ToString, CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            CtrlCombo.Properties.DataSource = ""
            CtrlCombo.Properties.Columns.Clear()
            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Name"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Διευθύνσεις"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CCT(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,Fullname from vw_CCT order by Fullname", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Fullname"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Επαφές"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub FLR(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,name from vw_FLR order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "name"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Ορόφοι"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub BDG(CtrlCombo As DevExpress.XtraEditors.LookUpEdit, ByVal sSQL As System.Text.StringBuilder)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,nam from vw_BDG  " & sSQL.ToString, CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "nam"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Πολυκατοικίες"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub BEF_MES(CtrlCombo As DevExpress.XtraEditors.LookUpEdit, ByVal sSQL As System.Text.StringBuilder)
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT DISTINCT CONVERT(VARCHAR(10), mdt, 103) AS mdt  FROM VW_AHPB   " & sSQL.ToString, CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "mdt"
            CtrlCombo.Properties.ValueMember = "mdt"
            CtrlCombo.Properties.PopulateColumns()

            'CtrlCombo.Properties.Columns(1).Visible = False
            CtrlCombo.Properties.Columns(0).Caption = "Προηγούμενες Μετρήσεις"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub COU(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_COU order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Name"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Νομοί"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub USERS(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,RealName from vw_USR", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "RealName"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Χρήστης"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub HTYPES(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_HTYPES order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Name"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Τύποι Θέρμανσης"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub FTYPES(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_FTYPES order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Name"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Τύποι Καυσίμων"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub BTYPES(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_BTYPES order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Name"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Τύποι Boiler"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DOY(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_DOY order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Name"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "ΔΟΥ"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub PRF(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_PRF order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Name"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Επαγγέλματα"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub MAIL(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim ds As DataSet = New DataSet
            Dim cmd As SqlCommand = New SqlCommand("Select id,Server from vw_MAILS", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            CtrlCombo.Properties.DataSource = sdr
            CtrlCombo.Properties.DisplayMember = "Server"
            CtrlCombo.Properties.ValueMember = "id"
            CtrlCombo.Properties.PopulateColumns()
            CtrlCombo.Properties.Columns(0).Visible = False
            CtrlCombo.Properties.Columns(1).Caption = "Email Account"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub FillCheckedListForms(CtrlList As DevExpress.XtraEditors.CheckedListBoxControl, ByVal mode As Byte, Optional ByVal sID As String = "")
        Try
            Dim sSQL As String
            If mode = FormMode.NewRecord Then
                sSQL = "Select id,name from vw_FORMS"
            Else
                sSQL = "SELECT F.id,F.name,isnull(( 
					    select case when VF.id is not null then 1 else 0 end as checked
					    from vw_FORMs VF
					    inner join vw_FORM_RIGHTS FR on FR.F_ID  = VF.ID 
					    inner join vw_RIGHTS R on R.ID  = FR.rID 
					    where R.ID = '" + sID + "'  and VF.ID=F.ID),0) as checked
                        from vw_FORMs F "
            End If
            Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            'chkLstUsers.DataSource = sdr
            CtrlList.DisplayMember = "name"
            CtrlList.ValueMember = "id"
            While sdr.Read()
                Dim chkLstItem As New DevExpress.XtraEditors.Controls.CheckedListBoxItem
                chkLstItem.Value = sdr.Item(1).ToString
                chkLstItem.Tag = sdr.Item(0).ToString
                If mode = FormMode.EditRecord Then chkLstItem.CheckState = sdr.Item(2).ToString

                CtrlList.Items.Add(chkLstItem)
            End While
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
