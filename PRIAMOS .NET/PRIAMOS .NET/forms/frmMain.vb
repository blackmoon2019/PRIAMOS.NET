Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraTabbedMdi
Public Class frmMain
    Private CheckFUpdate As New CheckForUpdates
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        XtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders
        bbDate.Caption = DateTime.Today
        bbUser.Caption = "Χρήστης: " & UserProps.RealName
        bbServer.Caption = "SQL Server: " & CNDB.DataSource.ToString
        bbDB.Caption = "Database: " & CNDB.Database.ToString
        bbVersion.Caption = "Ver:" + My.Application.Info.Version.ToString
        Timer2.Stop()
    End Sub

    Private Sub MdiManager_PageAdded(sender As Object, e As MdiTabPageEventArgs)
    End Sub
    Private Sub bbUsers_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbUsers.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Χρήστες"
        form.DataTable = "vw_USR"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbMailSettings_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbMailSettings.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Email Settings"
        form.DataTable = "vw_MAILS"
        form.MdiParent = Me
        form.Show()

    End Sub

    Private Sub XtraTabbedMdiManager1_EndFloating(sender As Object, e As FloatingEventArgs) Handles XtraTabbedMdiManager1.EndFloating
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
        Dim form As frmScroller = New frmScroller()
        form.Text = "Δικαιώματα"
        form.DataTable = "vw_RIGHTS"
        form.DataDetail = "vw_FORM_RIGHTS"
        form.MdiParent = Me
        form.Show()
    End Sub


    Private Sub bbLink_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles bbLink.HyperlinkClick
        Process.Start(bbLink.EditValue)
    End Sub

    Private Sub bbBDG_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbBDG.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Πολυκατοικίες"
        form.DataTable = "vw_BDG"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbCOU_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCOU.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Νομοί"
        form.DataTable = "vw_COU"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbAreas_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAreas.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Περιοχές"
        form.DataTable = "vw_AREAS"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbADR_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbADR.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Διευθύνσεις"
        form.DataTable = "vw_ADR"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbDOY_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbDOY.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "ΔΟΥ"
        form.DataTable = "vw_DOY"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbPRF_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbPRF.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Επαγγέλματα"
        form.DataTable = "vw_PRF"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbCCT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCCT.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Επαφές"
        form.DataTable = "vw_CCT"
        form.MdiParent = Me
        form.Show()
    End Sub


    Private Sub bbFuelType_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbFuelType.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τύποι Καυσίμων"
        form.DataTable = "vw_FTYPES"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbParamaters_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbParamaters.ItemClick
        Dim form As frmParameters = New frmParameters()
        form.Text = "Παράμετροι"
        form.MdiParent = Me
        form.Mode = FormMode.NewRecord
        Me.XtraTabbedMdiManager1.Float(Me.XtraTabbedMdiManager1.Pages(form), New Point(CInt(Me.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.ClientRectangle.Height / 2 - Me.Height / 2)))
        form.Show()
    End Sub

    Private Sub bbCalcTypes_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCalcTypes.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τύποι Υπολογισμού"
        form.DataTable = "vw_CALC_TYPES"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbMLC.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Κατηγορίες Χιλιοσστών"
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
        form.DataTable = "vw_TECH_SUP"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbTechCateg_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTechCateg.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Κατηγορίες Τεχνικής Υποστήριξης"
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
        form.DataTable = "vw_INH"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbCalcCateg_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbCalcCateg.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Κατηγορίες Υπολογισμών"
        form.DataTable = "vw_CALC_CAT"
        form.MdiParent = Me
        form.Show()

    End Sub

    Private Sub bbTTL_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbTTL.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Λεκτικά Εκτυπώσεων"
        form.DataTable = "vw_TTL"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbAnnouncements_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbAnnouncements.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Ανακοινώσεις"
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
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBApol_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBApol.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τύποι Απολύμανσης"
        form.DataTable = "vw_APOL_TYPES"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBcalendarApol_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBcalendarApol.ItemClick
        Dim form As frmCalendarApol = New frmCalendarApol()
        form.Text = "Πρόγραμμα Απολυμάνσεων"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBApolList_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBApolList.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Απολυμάνσεις"
        form.DataTable = "vw_APOL"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBPriamosVer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBPriamosVer.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Ιστορικό Εκδόσεων"
        form.DataTable = "vw_PRIAMOSVER"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τράπεζες"
        form.DataTable = "vw_BANKS"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBColMethod_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBColMethod.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τρόποι Είσπραξης"
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
        form.DataTable = "vw_TASKS_CAT"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBCases_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBCases.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Υποθέσεις"
        form.DataTable = "vw_CASES"
        form.DataDetail = "vw_TASKS"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBTechSup_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBTechSup.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τεχνική Υποστήριξη"
        form.DataTable = "vw_TECH_SUP"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub BBCT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBCT.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Επαφές ανα επάγγελμα"
        form.DataTable = "vw_CCT_PF"
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