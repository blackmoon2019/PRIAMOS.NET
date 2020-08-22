Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTabbedMdi
Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        XtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders
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
        Select Case XtraTabbedMdiManager1.ActiveFloatForm.Name
            Case "frmUsers"
                XtraTabbedMdiManager1.ActiveFloatForm.Width = 489 : XtraTabbedMdiManager1.ActiveFloatForm.Height = 166
                XtraTabbedMdiManager1.ActiveFloatForm.Location = My.Settings.frmUsers
            Case "frmMailSettings"
                XtraTabbedMdiManager1.ActiveFloatForm.Width = 520 : XtraTabbedMdiManager1.ActiveFloatForm.Height = 136
                XtraTabbedMdiManager1.ActiveFloatForm.Location = My.Settings.frmUsers
        End Select
    End Sub

    Private Sub BarClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarClose.ItemClick
        Application.Exit()
    End Sub

    Private Sub XtraTabbedMdiManager1_BeginFloating(sender As Object, e As FloatingCancelEventArgs) Handles XtraTabbedMdiManager1.BeginFloating
        'Select Case XtraTabbedMdiManager1.SelectedPage.MdiChild.Name
        '    Case "frmUsers"
        '        XtraTabbedMdiManager1.ActiveFloatForm.Width = 489 : XtraTabbedMdiManager1.ActiveFloatForm.Height = 166
        '    Case "frmMailSettings"
        '        XtraTabbedMdiManager1.ActiveFloatForm.Width = 520 : XtraTabbedMdiManager1.ActiveFloatForm.Height = 136
        '    Case "frmScroller"
        '        frmScroller.Width = 1037 : frmScroller.Height = 689

        'End Select
    End Sub
End Class