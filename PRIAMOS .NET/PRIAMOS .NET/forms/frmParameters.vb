Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraNavBar

Public Class frmParameters
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private Cls As New ClearControls
    Private Prog_Prop As New ProgProp
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

    Private Sub frmParameters_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        TablePanel1.Rows.Item(0).Visible = False
        TablePanel1.Rows.Item(1).Visible = False
    End Sub

    Private Sub frmParameters_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub navGen_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles navGen.LinkClicked
        TablePanel1.Rows.Item(0).Visible = False
        TablePanel1.Rows.Item(1).Visible = True
        'Δεκαδικά Προγράμματος
        txtDecimals.EditValue = Prog_Prop.GetProgDecimals()
        txtEmail.EditValue = Prog_Prop.GetProgTechSupportEmail

    End Sub

    Private Sub navDisplay_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles navDisplay.LinkClicked
        TablePanel1.Rows.Item(0).Visible = True
        TablePanel1.Rows.Item(1).Visible = False
    End Sub

    Private Sub txtDecimals_EditValueChanged(sender As Object, e As EventArgs) Handles txtDecimals.EditValueChanged
        'Δεκαδικά Προγράμματος
        Prog_Prop.SetProgDecimals(txtDecimals.EditValue)
    End Sub

    Private Sub txtEmail_EditValueChanged(sender As Object, e As EventArgs) Handles txtEmail.EditValueChanged
        'Email Support
        Prog_Prop.SetProgTechSupportEmail(txtEmail.EditValue)
    End Sub
End Class