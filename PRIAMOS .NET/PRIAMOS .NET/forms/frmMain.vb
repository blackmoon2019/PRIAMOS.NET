Imports DevExpress.XtraEditors
Imports DevExpress.XtraTabbedMdi
Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Private Sub MdiManager_PageAdded(sender As Object, e As MdiTabPageEventArgs)
        Dim page As XtraMdiTabPage = e.Page
        page.Tooltip = "Tooltip for the page " + page.Text
    End Sub
    Private Sub bbUsers_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbUsers.ItemClick
        Dim f As frmLogin = New frmLogin()

        f.Text = "Child Form "
        f.MdiParent = Me
        f.Show()
    End Sub
End Class