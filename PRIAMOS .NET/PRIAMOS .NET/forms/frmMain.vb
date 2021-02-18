Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraTabbedMdi
Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        XtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders
        bbDate.Caption = DateTime.Today
        bbUser.Caption = "Χρήστης: " & UserProps.RealName
        bbServer.Caption = "SQL Server: " & CNDB.DataSource.ToString
        bbDB.Caption = "Database: " & CNDB.Database.ToString
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
        form.Text = "Πελάτες"
        form.DataTable = "vw_CCT"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbHTypes_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbHTypes.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τύποι Θέρμανσης"
        form.DataTable = "vw_HTYPES"
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub bbBTypes_ItemClick(sender As Object, e As ItemClickEventArgs) Handles bbBTypes.ItemClick
        Dim form As frmScroller = New frmScroller()
        form.Text = "Τύποι Boiler"
        form.DataTable = "vw_BTYPES"
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

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
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
        form.Text = "Κατηγορίες Τεχνικής Υποστήριξης"
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
End Class