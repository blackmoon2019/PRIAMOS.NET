﻿Imports System.Data.SqlClient
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

        'Ανακοίνωση
        Prog_Prop.SetProgANNMENT(ANN_MENT.EditValue.ToString)

        'Path Εξόδων
        Prog_Prop.SetProgEX_PATHS(EX_FOLDER_PATH.EditValue.ToString, EX_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue.ToString)

        'Path Αποθεματικών
        Prog_Prop.SetProgDEP_PATHS(DEP_FOLDER_PATH.EditValue.ToString, DEP_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue.ToString)

        'Path Τιμολογίων Πετρελαίου
        Prog_Prop.SetProgOIL_PATHS(OIL_FOLDER_PATH.EditValue.ToString, OIL_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue.ToString)

        'Path Τιμολογίων Φυσ. Αερίου
        Prog_Prop.SetProgGAS_PATHS(GAS_FOLDER_PATH.EditValue.ToString, GAS_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue.ToString)

        'Path Αρχείων Πολυκατοικιών
        Prog_Prop.SetProgBDG_PATHS(BDG_FOLDER_PATH.EditValue.ToString, BDG_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue.ToString)

        XtraMessageBox.Show("Οι παράμετροι αποθηκεύτηκαν με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub frmParameters_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_ANN_MENTS' table. You can move, or remove it, as needed.
        Me.Vw_ANN_MENTSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_ANN_MENTS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet3.MAILS' table. You can move, or remove it, as needed.
        Me.MAILSTableAdapter.Fill(Me.Priamos_NETDataSet3.MAILS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_PARTNER_AND_WORKSHOP' table. You can move, or remove it, as needed.
        Me.Vw_PARTNER_AND_WORKSHOPTableAdapter.Fill(Me.Priamos_NETDataSet.vw_PARTNER_AND_WORKSHOP)

        cmdSaveGen.Enabled = UserProps.AllowEdit
        cmdSave2.Enabled = UserProps.AllowEdit
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
                'Ανακοίνωση
                ANN_MENT.EditValue = Prog_Prop.GetProgANNMENT
                'Path Εξόδων
                EX_FOLDER_PATH.EditValue = Prog_Prop.GetProgEXFolderPath
                EX_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue = Prog_Prop.GetProgEXFolderMoveOnSuccessPath
                'Path Αποθεματικών
                DEP_FOLDER_PATH.EditValue = Prog_Prop.GetProgDEPFolderPath
                DEP_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue = Prog_Prop.GetProgDEPFolderMoveOnSuccessPath
                'Path Τιμολογίων πετρελαίου
                OIL_FOLDER_PATH.EditValue = Prog_Prop.GetProgOILFolderPath
                OIL_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue = Prog_Prop.GetProgOILFolderMoveOnSuccessPath
                'Path Τιμολογίων Φυσ. Αερίου
                GAS_FOLDER_PATH.EditValue = Prog_Prop.GetProgGASFolderPath
                GAS_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue = Prog_Prop.GetProgGASFolderMoveOnSuccessPath
                'Path Αρχείων πολυκατοικιών
                BDG_FOLDER_PATH.EditValue = Prog_Prop.GetProgBDGFolderPath
                BDG_FOLDER_PATH_MOVE_ON_SUCCESS.EditValue = Prog_Prop.GetProgBDGFolderMoveOnSuccessPath

            Case 1
                'Email Έκδοσης Κοινοχρήστων
                Prog_Prop.GetProgInvoicesEmail()
                INVOICES_EMAIL.EditValue = Guid.Parse(ProgProps.InvoicesEmailID)
                BODY.EditValue = ProgProps.InvoicesBody
                BODY_RESEND.EditValue = ProgProps.InvoicesBodyResend
                BODY_RECREATE.EditValue = ProgProps.InvoicesBodyRecreate
                BODY_SYG.EditValue = ProgProps.InvoicesBodySYG
                BODY_RECEIPT.EditValue = ProgProps.InvoicesBodyRECEIPT
                UNPAID_INVOICES.EditValue = ProgProps.InvoicesUnpaidTable
                BODY_NOT_MANAGED.EditValue = ProgProps.InvoicesBodyNotManaged
                SUBJECT_NOT_MANAGED.EditValue = ProgProps.InvoicesSubjectNotManaged
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

    Private Sub cmdSave2_Click(sender As Object, e As EventArgs) Handles cmdSave2.Click
        'Παράμετροι email Έκδοσης Κοινοχρήστων
        Prog_Prop.SetProgInvoicesEmail(INVOICES_EMAIL.EditValue.ToString, BODY.EditValue, BODY_RESEND.EditValue, BODY_RECREATE.EditValue, BODY_SYG.EditValue,
                                       BODY_RECEIPT.EditValue, UNPAID_INVOICES.EditValue, BODY_NOT_MANAGED.EditValue, SUBJECT_NOT_MANAGED.EditValue)
        XtraMessageBox.Show("Οι παράμετροι αποθηκεύτηκαν με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cmdExit2_Click(sender As Object, e As EventArgs) Handles cmdExit2.Click
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class