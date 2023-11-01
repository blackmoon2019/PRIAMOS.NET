Imports DevExpress.DataAccess
Imports DevExpress.Utils
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraNavBar
Imports PRIAMOS.NET.Main

Public Class CombosManager
    Public Sub ManageManager(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmCustomers = New frmCustomers()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Διαχειριστής"
        'form1.MdiParent = frmMain
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        If CallerControl.EditValue <> Nothing Then
            form1.ID = CallerControl.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
            form1.chkWorkshop.Checked = False
            form1.chkPrivate.Checked = True
        End If

        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
    End Sub
    Public Sub ManagePROFACT(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal FrmCaller As DevExpress.XtraEditors.XtraForm, Optional ByVal isFromGrid As Boolean = False, Optional ByVal grdView As GridView = Nothing)
        Dim fGen As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        fGen.Text = "Επαγγελματικές Δραστηριότητες"
        fGen.CallerControl = CallerControl
        fGen.CalledFromControl = True
        fGen.CallerForm = FrmCaller
        fGen.MdiParent = frmMain
        fGen.DataTable = "PROF_ACT"
        fGen.L1.Text = "Κωδικός"
        fGen.L2.Text = "Περιγραφή"
        fGen.chk1.Text = "Αυτόματη Καταχώρηση Είσπραξης"
        fGen.L8.Text = "Ποσό"
        fGen.L10.Text = "Ημερομηνία Έναρξης"
        fGen.chk1.Tag = "autoCreateCol,0,1,2"
        fGen.txtNum.Tag = "amt,0,1,2"
        fGen.txtNum.Properties.MaskSettings.MaskExpression = "c2"
        fGen.txtNum.Properties.DisplayFormat.FormatType = FormatType.Numeric
        fGen.txtNum.Properties.DisplayFormat.FormatString = "c"
        fGen.txtNum.Properties.EditFormat.FormatType = FormatType.Numeric
        fGen.txtNum.Properties.EditFormat.FormatString = "n2"
        fGen.txtNum.Text = "0,00€"
        fGen.L10.Control.Tag = "dtEvery,0,1,2"
        fGen.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.L8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.L10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        If isFromGrid = False Then
            If CallerControl.EditValue <> Nothing Then
                fGen.ID = CallerControl.EditValue.ToString
                fGen.Mode = FormMode.EditRecord
            Else
                fGen.Mode = FormMode.NewRecord
            End If
        Else
            If grdView.GetRowCellValue(grdView.FocusedRowHandle, "profActID").ToString <> Nothing Then
                fGen.ID = grdView.GetRowCellValue(grdView.FocusedRowHandle, "profActID").ToString
                fGen.Mode = FormMode.EditRecord
            Else
                fGen.Mode = FormMode.NewRecord
            End If
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(fGen.Parent.ClientRectangle.Width / 2 - fGen.Width / 2), CInt(fGen.Parent.ClientRectangle.Height / 2 - fGen.Height / 2)))
        fGen.Show()
    End Sub
    Public Sub ManageTTL(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, Optional ByVal CallerForm As Form = Nothing)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Λεκτικά Εκτυπώσεων"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Λεκτικό"
        form1.DataTable = "TTL"
        form1.CallerForm = CallerForm
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.GetColumnValue("ID").ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Public Sub ManageBDG(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmBDG = New frmBDG()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Πολυκατοικία"
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        form1.bManageID = CallerControl.GetColumnValue("bManageID").ToString
        If CallerControl.EditValue <> Nothing Then
            form1.ID = CallerControl.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        'form1.WindowState = FormWindowState.Maximized
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageHeatingInvoices(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal sbdgID As String)
        Dim form1 As frmBDG = New frmBDG()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Πολυκατοικία"
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        form1.Mode = FormMode.EditRecord
        form1.Maintab.SelectedTabPage = form1.tabHeatingInvoices
        form1.ID = sbdgID
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
        form1.HeatingInvoicesSelected()
    End Sub
    Public Sub ManageHeatingInvoicesCheckBox(ByVal CallerControl As CheckedComboBoxEdit, ByVal FrmMode As Byte, ByVal sbdgID As String)
        Dim form1 As frmBDG = New frmBDG()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Πολυκατοικία"
        form1.CallerControlCheckedComboBoxEdit = CallerControl
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        form1.Mode = FormMode.EditRecord
        form1.Maintab.SelectedTabPage = form1.tabHeatingInvoices
        form1.ID = sbdgID
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
        form1.HeatingInvoicesSelected()
    End Sub
    Public Sub ManageAHPB(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal sMDT As String, ByVal boiler As Boolean, ByVal sbdgID As String)
        Dim form1 As frmBDG = New frmBDG()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Πολυκατοικία"
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        form1.Mode = FormMode.EditRecord
        form1.ID = sbdgID
        form1.Maintab.SelectedTabPage = form1.tabHeating
        If boiler = False Then
            form1.RGTypeHeating.SelectedIndex = 0
        Else
            form1.RGTypeHeating.SelectedIndex = 1
        End If
        If CallerControl.EditValue <> Nothing Then form1.cboBefMes.EditValue = CDate(sMDT)
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
        form1.HeatingSelected()
    End Sub
    Public Sub ManageAnnouncements(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal FrmCaller As DevExpress.XtraEditors.XtraForm)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Ανακοινώσεις"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Ανακοίνωση"
        form1.DataTable = "ANN_MENTS"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.CallerForm = FrmCaller
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord

            If CallerControl.GetColumnValue("ID") Is Nothing Then Exit Sub
            form1.ID = CallerControl.GetColumnValue("ID").ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub ' ...
    Public Sub ManageColExtTypes(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal FrmCaller As DevExpress.XtraEditors.XtraForm)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Είδη Είσπραξης"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Είδος"
        form1.DataTable = "COL_EXT_TYPES"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.CallerForm = FrmCaller
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord

            If CallerControl.GetColumnValue("ID") Is Nothing Then Exit Sub
            form1.ID = CallerControl.GetColumnValue("ID").ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub ' .
    Public Sub KeysManager(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmCustomers = New frmCustomers()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Υπέυθυνος Κλειδιών"
        'form1.MdiParent = frmMain
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        If CallerControl.EditValue <> Nothing Then
            form1.ID = CallerControl.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
            form1.chkWorkshop.Checked = False
            form1.chkPrivate.Checked = True
        End If

        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
    End Sub
    Public Sub ManageADR(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Διευθύνσεις"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Διεύθυνση"
        form1.L3.Text = "Νομός"
        form1.L4.Text = "Περιοχές"
        form1.L7.Text = "ΤΚ"
        form1.L7.Control.Tag = "tk,0,1,2"
        form1.DataTable = "ADR"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        form1.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        form1.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        form1.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManagePUBLIC_S(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Υπηρεσίες(Εταιρίες)"
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        form1.DataTable = "PUBLIC_S"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Εταιρία"
        form1.L3.Text = "Είδος Υπηρεσίας"
        form1.L3.Control.Tag = "servicetypeID,0,1,2"
        form1.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageCOU(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Νομοί"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Νομός"
        form1.DataTable = "COU"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageANN_GRPS(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Κατηγορίες Ανακοινώσεων"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Κατηγορία"
        form1.DataTable = "ANN_GRPS"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Public Sub ManageAREAS(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Περιοχές"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Περιοχή"
        form1.L3.Text = "Νομός"
        form1.DataTable = "AREAS"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        form1.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageBtypes(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Τύποι Boiler"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τύπος"
        form1.DataTable = "BTYPES"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageCalcTypes(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, Optional ByVal GRD As GridView = Nothing)
        Dim fGen As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        fGen.Text = "Τύποι Υπολογισμού"
        fGen.MdiParent = frmMain
        fGen.Mode = FormMode.NewRecord
        fGen.Scroller = GRD
        fGen.DataTable = "CALC_TYPES"
        fGen.L1.Text = "Κωδικός"
        fGen.L2.Text = "Όνομα"
        fGen.chk1.Text = "Ενεργό"
        fGen.L7.Text = "Τύπος"
        fGen.txtL7.Tag = "type,0,1,2"
        fGen.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.CalledFromControl = True
        fGen.CallerControl = CallerControl
        If CallerControl.EditValue <> Nothing Then
            fGen.Mode = FormMode.EditRecord
            fGen.ID = CallerControl.EditValue.ToString
        Else
            fGen.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(fGen.Parent.ClientRectangle.Width / 2 - fGen.Width / 2), CInt(fGen.Parent.ClientRectangle.Height / 2 - fGen.Height / 2)))
        fGen.Show()

    End Sub
    Public Sub ManageCalcCat(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, Optional ByVal GRD As GridView = Nothing)
        Dim fGen As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        fGen.Text = "Κατηγορίες Υπολογισμών"
        fGen.MdiParent = frmMain
        fGen.Mode = FormMode.EditRecord
        fGen.Scroller = GRD
        fGen.DataTable = "CALC_CAT"
        fGen.L1.Text = "Κωδικός"
        fGen.L2.Text = "Όνομα"
        fGen.L3.Text = "Τύπος Υπολογισμού"
        fGen.L3.Control.Tag = "calcTypeID,0,1,2"
        fGen.L3.Tag = ""
        fGen.L3.ImageOptions.Image = Nothing
        fGen.L4.Text = "Κατηγορία Χιλιοστών"
        fGen.L4.Control.Tag = "mlcID,0,1,2"
        fGen.L4.Tag = ""
        fGen.L4.ImageOptions.Image = Nothing
        fGen.L7.Text = "Λεκτικό Εκτύπωσης"
        fGen.L7.Control.Tag = "repName,0,1,2"
        fGen.L7.Tag = ""
        fGen.L7.ImageOptions.Image = Nothing
        fGen.L8.Text = "Θέση Ταξινόμησης"
        fGen.txtNum.Tag = "ord,0,1,2"
        fGen.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.L8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.CalledFromControl = False
        If CallerControl.EditValue <> Nothing Then
            fGen.Mode = FormMode.EditRecord
            fGen.ID = CallerControl.EditValue.ToString
        Else
            fGen.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(fGen.Parent.ClientRectangle.Width / 2 - fGen.Width / 2), CInt(fGen.Parent.ClientRectangle.Height / 2 - fGen.Height / 2)))
        fGen.Show()

    End Sub
    Public Sub ManageHtypes(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Τύποι Θέρμανσης"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τύπος"
        form1.DataTable = "HTYPES"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageTechCatCategory(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Κατηγορίες Τεχνικής ποστήριξης"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Κατηγορία"
        form1.DataTable = "TECH_CAT"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageFtypes(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Τύποι Καυσίμων"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τύπος"
        form1.DataTable = "FTYPES"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManagePRF(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal isFromGrid As Boolean, Optional ByRef RecID As String = "", Optional ByVal GRD As GridView = Nothing)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Επαγγέλματα"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Επάγγελμα"
        form1.DataTable = "PRF"
        If isFromGrid = False Then
            form1.CallerControl = CallerControl
            form1.CalledFromControl = True
            If CallerControl.EditValue <> Nothing Then
                form1.ID = CallerControl.EditValue.ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
            End If
        Else
            If GRD.GetRowCellValue(GRD.FocusedRowHandle, "prfID").ToString <> Nothing Then
                form1.ID = GRD.GetRowCellValue(GRD.FocusedRowHandle, "prfID").ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
            End If
        End If

        'form1.MdiParent = frmMain

        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
        RecID = form1.RecID
    End Sub
    Public Sub ManageCUS(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmCustomers = New frmCustomers()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Πελάτες"
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.ID = CallerControl.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageSUP(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmCustomers = New frmCustomers()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Προμηθευτές"
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        form1.chkSupplier.Checked = True
        If CallerControl.EditValue <> Nothing Then
            form1.ID = CallerControl.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageCCT(ByVal isFromGrid As Boolean, Optional ByRef RecID As String = "", Optional ByVal CallerControl As LookUpEdit = Nothing, Optional ByVal grdView As GridView = Nothing)
        Dim form1 As frmCustomers = New frmCustomers()
        form1.Text = "Πελάτες"
        'form1.MdiParent = frmMain
        If isFromGrid = False Then
            form1.CallerControl = CallerControl
            form1.CalledFromControl = False
            If CallerControl.EditValue <> Nothing Then
                form1.ID = CallerControl.EditValue.ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
                form1.chkWorkshop.Checked = True
                form1.chkPrivate.Checked = False
            End If
        Else
            If grdView.GetRowCellValue(grdView.FocusedRowHandle, "cctID").ToString <> Nothing Then
                form1.ID = grdView.GetRowCellValue(grdView.FocusedRowHandle, "cctID").ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
                form1.chkWorkshop.Checked = True
                form1.chkPrivate.Checked = False
            End If
        End If

        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
    End Sub

    Public Sub ManageDOY(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "ΔΟΥ"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "ΔΟΥ"
        form1.DataTable = "DOY"
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        If CallerControl.EditValue <> Nothing Then form1.ID = CallerControl.EditValue.ToString
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then form1.Mode = FormMode.EditRecord Else form1.Mode = FormMode.NewRecord
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageFolderCat(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Κατηγορίες Φακέλων"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Κατηγορία"
        form1.DataTable = "FOLDER_CAT"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageUSR(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmUsers = New frmUsers()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Χρήστης"
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.ID = CallerControl.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageAPT(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal sbdgID As String)
        Dim form1 As frmAPT = New frmAPT()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Διαμέρισμα"
        form1.BDGID = sbdgID
        form1.CallerControl = CallerControl
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.ID = CallerControl.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageBANK(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal FrmCaller As DevExpress.XtraEditors.XtraForm)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Τράπεζες"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τράπεζα"
        form1.DataTable = "BANK"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.CallerForm = FrmCaller
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.GetColumnValue("ID").ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Public Sub ManageColMethod(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal FrmCaller As DevExpress.XtraEditors.XtraForm)
        Dim form1 As frmGen = New frmGen()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Τρόποι Πληρωμής"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τρόπος Πληρωμής"
        form1.DataTable = "COL_METHOD"
        form1.CalledFromControl = True
        form1.CallerControl = CallerControl
        form1.CallerForm = FrmCaller
        form1.MdiParent = frmMain
        If CallerControl.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = CallerControl.GetColumnValue("ID").ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
End Class
