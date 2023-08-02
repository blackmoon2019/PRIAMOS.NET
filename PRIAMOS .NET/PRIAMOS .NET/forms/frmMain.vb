Imports DevExpress.LookAndFeel
Imports System.Configuration
Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraTabbedMdi
Public Class frmMain
    Private CheckFUpdate As New CheckForUpdates
    Private UserPermissions As New CheckPermissions
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        XtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders
        bbDate.Caption = DateTime.Today
        bbUser.Caption = "Χρήστης: " & UserProps.RealName
        bbServer.Caption = "SQL Server: " & CNDB.DataSource.ToString
        bbDB.Caption = "Database: " & CNDB.Database.ToString
        bbVersion.Caption = "Ver:" + My.Application.Info.Version.ToString
        Timer2.Stop()
        LoadCurrentSkin()
        'Η Καταχώριση έκδοσης εμφανίζεται μόνο σε μένα
        If UserProps.ID.ToString.ToUpper = "E9CEFD11-47C0-4796-A46B-BC41C4C3606B" Then BBVer.Visibility = BarItemVisibility.Always
    End Sub

    Private Sub MdiManager_PageAdded(sender As Object, e As MdiTabPageEventArgs)
    End Sub
    Private Sub bbUsers_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbUsers.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Χρήστες"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_USR"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbMailSettings_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbMailSettings.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Email Settings"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_MAILS"
        form.MdiParent = Me
        form.Show()

    End Sub

    Private Sub XtraTabbedMdiManager1_EndFloating(sender As Object, e As FloatingEventArgs) Handles XtraTabbedMdiManager1.EndFloating
        If XtraTabbedMdiManager1.ActiveFloatForm.Name = "frmScroller" Then
            XtraTabbedMdiManager1.ActiveFloatForm.Height = 800
            XtraTabbedMdiManager1.ActiveFloatForm.Width = 1500
            Dim form As frmScroller = XtraTabbedMdiManager1.ActiveFloatForm
            form.BarRefresh.PerformClick()
            form = Nothing
        End If
        'Select Case XtraTabbedMdiManager1.ActiveFloatForm.Name
        '    Case "frmUsers"
        '        XtraTabbedMdiManager1.ActiveFloatForm.Width = 489 : XtraTabbedMdiManager1.ActiveFloatForm.Height = 166
        '        XtraTabbedMdiManager1.ActiveFloatForm.Location = My.Settings.frmUsers
        '    Case "frmMailSettings"
        '        XtraTabbedMdiManager1.ActiveFloatForm.Width = 520 : XtraTabbedMdiManager1.ActiveFloatForm.Height = 136
        '        XtraTabbedMdiManager1.ActiveFloatForm.Location = My.Settings.frmUsers
        '    Case "frmParameters"
        '        XtraTabbedMdiManager1.ActiveFloatForm.Width = 520 : XtraTabbedMdiManager1.ActiveFloatForm.Height = 136
        '        XtraTabbedMdiManager1.ActiveFloatForm.Location = My.Settings.frmUsers

        'End Select
    End Sub

    Private Sub BarClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarClose.ItemClick
        Application.Exit()
    End Sub

    Private Sub XtraTabbedMdiManager1_BeginFloating(sender As Object, e As FloatingCancelEventArgs) Handles XtraTabbedMdiManager1.BeginFloating
        Select Case e.ChildForm.Name
            '    Case "frmUsers"
            '        XtraTabbedMdiManager1.ActiveFloatForm.Width = 489 : XtraTabbedMdiManager1.ActiveFloatForm.Height = 166
            '    Case "frmMailSettings"
            '        XtraTabbedMdiManager1.ActiveFloatForm.Width = 520 : XtraTabbedMdiManager1.ActiveFloatForm.Height = 136
            '    Case "frmScroller"
            '        frmScroller.Width = 1037 : frmScroller.Height = 689
            Case "frmParameters"

                'e.ChildForm.Width = 520 : e.ChildForm.Height = 136
                'e.ChildForm.Location = My.Settings.frmParameters
        End Select
    End Sub
    Private Sub bbRights_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbRights.ItemClick
        Dim form As frmPermissions = New frmPermissions()
        form.Text = "Δικαιώματα"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.MdiParent = Me
        form.Show()
    End Sub


    Private Sub bbLink_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles bbLink.HyperlinkClick
        Process.Start(bbLink.EditValue)
    End Sub

    Private Sub bbBDG_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbBDG.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Πολυκατοικίες"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_BDG"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbCOU_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCOU.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Νομοί"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_COU"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbAreas_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAreas.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Περιοχές"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_AREAS"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbADR_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbADR.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Διευθύνσεις"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_ADR"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbDOY_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbDOY.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "ΔΟΥ"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_DOY"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbPRF_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbPRF.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Επαγγέλματα"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_PRF"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbCCT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCCT.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Επαφές"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_CCT"
        form.MdiParent = Me
        form.Show()
    End Sub


    Private Sub bbFuelType_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbFuelType.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τύποι Καυσίμων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_FTYPES"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbParamaters_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbParamaters.ItemClick
        Dim form As frmParameters = New frmParameters()
        form.Text = "Γενικές Παράμετροι"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.MdiParent = Me
        form.Mode = FormMode.NewRecord
        Me.XtraTabbedMdiManager1.Float(Me.XtraTabbedMdiManager1.Pages(form), New Point(CInt(Me.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.ClientRectangle.Height / 2 - Me.Height / 2)))
        form.Show()
    End Sub

    Private Sub bbCalcTypes_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCalcTypes.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τύποι Υπολογισμού"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_CALC_TYPES"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbMLC.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Κατηγορίες Χιλιοστών"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_MLC"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBChangeUsr_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBChangeUsr.ItemClick
        frmLogin.Show()
        Me.Close()
    End Sub

    Private Sub bbTechnicalSupport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTechnicalSupport.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τεχνική Υποστήριξη"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_TECH_SUP"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbTechCateg_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTechCateg.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Κατηγορίες Τεχνικής Υποστήριξης"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_TECH_CAT"
        form.MdiParent = Me
        form.Show()
    End Sub


    'Private Sub bbEXP_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbEXP.ItemClick
    '    Dim form As frmScroller = New frmScroller()
    '    form.Text = "Κατηγορίες Εξόδων"
    '    form.DataTable = "vw_EXP"
    '    form.MdiParent = Me
    '    form.Show()
    'End Sub

    Private Sub bbParasts_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbParasts.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Κοινόχρηστα"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_INH"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbCalcCateg_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCalcCateg.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Κατηγορίες Υπολογισμών"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_CALC_CAT"
        form.MdiParent = Me
        form.Show()

    End Sub

    Private Sub bbTTL_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTTL.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Λεκτικά Εκτυπώσεων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_TTL"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbAnnouncements_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAnnouncements.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Ανακοινώσεις"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_ANN_MENTS"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBBatchFileEX_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBBatchFileEX.ItemClick
        Dim form As frmBatchInsertAttachmentsEX = New frmBatchInsertAttachmentsEX()
        form.Text = ""
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBIND_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBIND.ItemClick
        Dim form As frmIND = New frmIND()
        form.Text = "Χρεώσεις Πολυκατοικιών"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBApol_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBApol.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τύποι Απολύμανσης"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_APOL_TYPES"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBcalendarApol_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBcalendarApol.ItemClick
        Dim form As frmCalendarApol = New frmCalendarApol()
        form.Text = "Πρόγραμμα Απολυμάνσεων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBApolList_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBApolList.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Απολυμάνσεις"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_APOL"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBPriamosVer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBPriamosVer.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Εκδόσεις"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_PRIAMOSVER"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τράπεζες"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_BANKS"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBColMethod_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBColMethod.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τρόποι Είσπραξης"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_COL_METHOD"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBCol_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBCol.ItemClick
        'Dim form As frmScroller = New frmScroller()
        'form.Text = "Είσπραξεις"
        'form.DataTable = "vw_COL"
        'form.MdiParent = Me
        'form.Show()

        Dim form As frmCollections = New frmCollections()
        form.Text = "Είσπραξεις Κοινοχρήστων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.MdiParent = Me
        'form.DataTable = "vw_COL"
        'form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Έλεγχος νέας έκδοσης
        If CheckFUpdate.CheckForNewVersion Then
            BBUpdate.Visibility = BarItemVisibility.Always
            Timer2.Start()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If BBUpdate.Visibility = BarItemVisibility.Never Then BBUpdate.Visibility = BarItemVisibility.Always Else BBUpdate.Visibility = BarItemVisibility.Never
    End Sub

    Private Sub BBUpdate_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBUpdate.ItemClick
        Timer2.Stop()
        CheckFUpdate.FindNewVersion()
    End Sub

    Private Sub BBTasks_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBTasksCat.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Εργασίες"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_TASKS_CAT"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBCases_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBCases.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Υποθέσεις"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_CASES"
        form.DataDetail = "vw_TASKS"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBTechSup_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBTechSup.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τεχνική Υποστήριξη"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_TECH_SUP"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBCT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBCT.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Επαφές ανα επάγγελμα"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_CCT_PF"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBFolderCat_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBFolderCat.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Κατηγορίες Φακέλων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_FOLDER_CAT"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBCol2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBCol2.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Λοιπές Εισπράξεις"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_COL_EXT"
        form.MdiParent = Me
        form.Bar4.Visible = True
        form.Show()
    End Sub

    Private Sub BBVer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBVer.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Εκδόσεις"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_PRIAMOSVER"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbVersion_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbVersion.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Εκδόσεις"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_PRIAMOSVER"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBAbout_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBAbout.ItemClick
        Dim form As frmAbout = New frmAbout()
        form.Text = "Περί"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.MdiParent = Me
        Me.XtraTabbedMdiManager1.Float(Me.XtraTabbedMdiManager1.Pages(form), New Point(CInt(Me.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.ClientRectangle.Height / 2 - Me.Height / 2)))
        form.Show()
    End Sub

    Private Sub BBatchInsertINH_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBatchInsertINH.ItemClick
        Dim frmbatchCreateINH As frmbatchCreateINH = New frmbatchCreateINH()
        frmbatchCreateINH.ShowDialog()
    End Sub

    Private Sub BBatchInsertAnnment_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBatchInsertAnnment.ItemClick
        Dim form As frmBatchCreateAnnments = New frmBatchCreateAnnments()
        form.Text = "Μαζική Ενημέρωση Ανακοινώσεων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.MdiParent = Me
        Me.XtraTabbedMdiManager1.Float(Me.XtraTabbedMdiManager1.Pages(Form), New Point(CInt(Me.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.ClientRectangle.Height / 2 - Me.Height / 2)))
        Form.Show()

    End Sub

    Private Sub BBGrps_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBGrps.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Κατηγορίες Ανακοινώσεων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_ANN_GRPS"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BCCT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BCCT.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Επαφές Πολυκατοικιών"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "REPORT_3"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBBdgAptTrans_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBBdgAptTrans.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Καρτέλλα Κινήσεων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "REPORT_4"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBBalReport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBBalReport.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Καρτέλλα Προβληματικών Υπολοίπων Διαμερισμάτων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "REPORT_5"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBAPT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBAPT.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Διαμερίσματα Πολυκατοικιών"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "REPORT_6"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBKeysmanager_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBKeysmanager.ItemClick
        Dim form As frmKeysManager = New frmKeysManager()
        form.Text = "Μαζική ενημέρωση υπευθύνων κλειδιών"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.MdiParent = Me
        form.Show()

    End Sub

    Private Sub BBContacts_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBContacts.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Επικοινωνίες"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_CONTACTS"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBanksCol_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBanksCol.ItemClick
        Dim form As frmBankCollectionInsert = New frmBankCollectionInsert()
        form.Text = "Πιστώσεις Τραπεζών"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.MdiParent = Me
        'Me.XtraTabbedMdiManager1.Float(Me.XtraTabbedMdiManager1.Pages(form), New Point(CInt(Me.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.ClientRectangle.Height / 2 - Me.Height / 2)))
        form.Show()
        'form.ShowDialog()
    End Sub

    Private Sub BBReport7_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBReport7.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Ανεξόφλητα Παραστατικά"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "REPORT_7"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBProfActivities_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBProfActivities.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Επαγγελματικές Δραστηριότητες"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_PROF_ACT"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBProfActD_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBProfActD.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Εργασίες Πολυκατοικιών"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_PROF_ACT_D"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBColExtTypes.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Είδη Είσπραξης"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_COL_EXT_TYPES"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBatchCreateCollections_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBatchCreateCollections.ItemClick
        Dim form As frmBatchCollectionInsert = New frmBatchCollectionInsert()
        form.Text = "Μαζική δημιουργία οφειλών νέας διαχείρισης"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        Me.XtraTabbedMdiManager1.Float(Me.XtraTabbedMdiManager1.Pages(form), New Point(CInt(Me.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.ClientRectangle.Height / 2 - Me.Height / 2)))
        form.MdiParent = Me
        form.Show()
    End Sub
    Private Sub frmMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        SaveCurrentSkin()
    End Sub

    Sub SaveCurrentSkin()
        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        If config.AppSettings.Settings("Skin") Is Nothing Then
            config.AppSettings.Settings.Add("Skin", UserLookAndFeel.Default.ActiveSkinName)
        Else
            config.AppSettings.Settings("Skin").Value = UserLookAndFeel.Default.ActiveSkinName
        End If
        config.Save()

    End Sub
    Sub LoadCurrentSkin()
        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        If config.AppSettings.Settings("Skin") Is Nothing Then
            Return
        Else
            UserLookAndFeel.Default.ActiveLookAndFeel.SkinName = config.AppSettings.Settings("Skin").Value
        End If
    End Sub

    Private Sub BBParoches_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBParoches.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Στοιχεία Παροχών Πολυκατοικιών"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.DataTable = "vw_BMANAGE"
        form.MdiParent = Me
        form.Show()
    End Sub

    'Private Sub BBTasks_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BBTasks.ItemClick
    '    Dim form As frmScroller = New frmScroller()
    '    form.Text = "Εργασίες υποθέσεων"
    '    form.DataTable = "vw_TASKS"
    '    form.MdiParent = Me
    '    form.Show()
    'End Sub
End Class