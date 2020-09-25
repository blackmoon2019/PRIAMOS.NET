Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Public Class FillCombos
    Public Sub AREAS(CtrlCombo As DevExpress.XtraEditors.LookUpEdit)
        Try
            Dim CouID As String = ""
            If CtrlCombo.EditValue <> Nothing Then CouID = CtrlCombo.EditValue.ToString
            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_AREAS  " & IIf(CouID.Length > 0, " where couid = " & toSQLValueS(CouID), "") & " order by name", CNDB)
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
End Class
