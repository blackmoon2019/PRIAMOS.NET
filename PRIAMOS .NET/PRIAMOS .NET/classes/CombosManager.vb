Imports DevExpress.XtraEditors
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

End Class
