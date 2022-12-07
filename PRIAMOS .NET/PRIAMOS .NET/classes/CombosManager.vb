Imports DevExpress.Utils
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraEditors
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Views.Grid

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
    Public Sub ManagePROFACT(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte, ByVal FrmCaller As DevExpress.XtraEditors.XtraForm)
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
        If CallerControl.EditValue <> Nothing Then
            fGen.ID = CallerControl.EditValue.ToString
            fGen.Mode = FormMode.EditRecord
        Else
            fGen.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(fGen.Parent.ClientRectangle.Width / 2 - fGen.Width / 2), CInt(fGen.Parent.ClientRectangle.Height / 2 - fGen.Height / 2)))
        fGen.Show()
    End Sub

    Public Sub ManageBDG(ByVal CallerControl As LookUpEdit, ByVal FrmMode As Byte)
        Dim form1 As frmBDG = New frmBDG()
        If FrmMode = FormMode.NewRecord Then CallerControl.EditValue = Nothing
        form1.Text = "Πολυκατοικία"
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
End Class
