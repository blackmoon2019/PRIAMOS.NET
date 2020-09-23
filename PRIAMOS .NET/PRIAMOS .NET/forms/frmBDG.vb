Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Public Class frmBDG
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private Log As New Transactions
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
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
    Private Sub FillComboCOU()
        Try
            Dim ds As DataSet = New DataSet
            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_COU order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            cboCOU.Properties.DataSource = sdr
            cboCOU.Properties.DisplayMember = "Name"
            cboCOU.Properties.ValueMember = "id"
            cboCOU.Properties.PopulateColumns()
            cboCOU.Properties.Columns(0).Visible = False
            cboCOU.Properties.Columns(1).Caption = "Νομοί"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub FillComboAREAS()
        Try
            Dim ds As DataSet = New DataSet
            Dim CouID As String = ""
            If cboCOU.EditValue <> Nothing Then CouID = cboCOU.EditValue.ToString
            Dim cmd As SqlCommand = New SqlCommand("Select id,Name from vw_AREAS  " & IIf(CouID.Length > 0, " where couid = " & toSQLValueS(CouID), "") & " order by name", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            cboAREAS.Properties.DataSource = ""
            cboAREAS.Properties.Columns.Clear()
            cboAREAS.Properties.DataSource = sdr
            cboAREAS.Properties.DisplayMember = "Name"
            cboAREAS.Properties.ValueMember = "id"
            cboAREAS.Properties.PopulateColumns()
            cboAREAS.Properties.Columns(0).Visible = False
            cboAREAS.Properties.Columns(1).Caption = "Περιοχές"
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmBDG_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillComboCOU()
        FillComboAREAS()
        Me.CenterToScreen()
        My.Settings.frmUsers = Me.Location
        My.Settings.Save()
    End Sub

    Private Sub frmBDG_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cboCOU_LostFocus(sender As Object, e As EventArgs) Handles cboCOU.LostFocus
        FillComboAREAS()
    End Sub
End Class