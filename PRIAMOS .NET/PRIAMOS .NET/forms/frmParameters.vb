Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
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


    Private Sub cmdSaveGen_Click(sender As Object, e As EventArgs) Handles cmdSaveGen.Click
        'ΦΠΑ Προγράμματος
        Prog_Prop.SetProgVAT(txtVAT.EditValue)

        'Δεκαδικά Προγράμματος
        Prog_Prop.SetProgDecimals(txtDecimals.EditValue)

        'Email Support
        Prog_Prop.SetProgTechSupportEmail(txtEmail.EditValue)

        'Διαχείριση
        Prog_Prop.SetProgADM(ADM.EditValue.ToString)
    End Sub

    Private Sub frmParameters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_PARTNER_AND_WORKSHOP' table. You can move, or remove it, as needed.
        Me.Vw_PARTNER_AND_WORKSHOPTableAdapter.Fill(Me.Priamos_NETDataSet.vw_PARTNER_AND_WORKSHOP)
        ''ΦΠΑ
        'txtVAT.EditValue = Prog_Prop.GetProgvat()
        ''Δεκαδικά Προγράμματος
        'txtDecimals.EditValue = Prog_Prop.GetProgDecimals()
        ''Technical Support Email
        'txtEmail.EditValue = Prog_Prop.GetProgTechSupportEmail
        ''Διαχείριση
        'ADM.EditValue = Prog_Prop.GetProgADM
        Me.CenterToScreen()
    End Sub

    Private Sub TabPane2_SelectedPageChanged(sender As Object, e As SelectedPageChangedEventArgs) Handles TabPane2.SelectedPageChanged
        Select Case TabPane2.SelectedPageIndex
            Case 0
                'ΦΠΑ
                txtVAT.EditValue = Prog_Prop.GetProgvat()
                'Δεκαδικά Προγράμματος
                txtDecimals.EditValue = Prog_Prop.GetProgDecimals()
                'Technical Support Email
                txtEmail.EditValue = Prog_Prop.GetProgTechSupportEmail
                'Διαχείριση
                ADM.EditValue = Prog_Prop.GetProgADM
            Case 1
            Case 2
            Case 3
            Case Else
        End Select
    End Sub

    Private Sub ADM_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles ADM.ButtonClick
        Select Case e.Button.Index
            Case 1 : ADM.EditValue = Nothing : ManageCCT(False)
            Case 2 : If ADM.EditValue <> Nothing Then ManageCCT(False)
            Case 3 : ADM.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageCCT(ByVal isFromGrid As Boolean, Optional ByRef RecID As String = "")
        Dim form1 As frmCustomers = New frmCustomers()
        form1.Text = "Επαφές"
        If isFromGrid = False Then
            form1.CallerControl = ADM
            form1.CalledFromControl = True
            If ADM.EditValue <> Nothing Then
                form1.ID = ADM.EditValue.ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
                form1.chkWorkshop.Checked = True
                form1.chkPrivate.Checked = False
            End If
        End If
        form1.ShowDialog()
    End Sub
End Class