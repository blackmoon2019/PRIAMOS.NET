Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmColExt
    Private sID As String
    Private sApolID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Dim sGuid As String
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property ApolID As String
        Set(value As String)
            sApolID = value
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
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmColExt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BANKS' table. You can move, or remove it, as needed.
        Me.Vw_BANKSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BANKS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COL_METHOD' table. You can move, or remove it, as needed.
        Me.Vw_COL_METHODTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COL_METHOD)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.FillByIsManaged(Me.Priamos_NETDataSet.vw_BDG)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.Collectors' table. You can move, or remove it, as needed.
        Me.CollectorsTableAdapter.Fill(Me.Priamos_NETDataSet.Collectors)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("COL_EXT")
                dtCredit.EditValue = Date.Now
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_COL_EXT where id = " & toSQLValueS(sID))
        End Select
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue = Nothing Then Exit Sub
        Me.Vw_APTTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_APT, System.Guid.Parse(cboBDG.EditValue.ToString))
    End Sub

    Private Sub frmColExt_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "COL_EXT", LayoutControl1,,, sGuid,, "credit,bal,creditusrID,dtDebit",
                                    toSQLValue(txtDebit, True) & "," & toSQLValue(txtDebit, True) & "," & toSQLValueS(UserProps.ID.ToString) & ",getdate()")
                    Case FormMode.EditRecord
                        If sApolID = Nothing Then
                            sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "COL_EXT", LayoutControl1,,, sID,,,,,
                                "credit=" & toSQLValue(txtDebit, True) & ",bal=" & toSQLValue(txtDebit, True) & ",creditusrID=" & toSQLValueS(UserProps.ID.ToString) & ",dtDebit=getdate()")
                        Else
                            sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "COL_EXT", LayoutControl1,,, sID,,,,,
                                "bal=bal - " & toSQLValue(txtDebit, True) & ",creditusrID=" & toSQLValueS(UserProps.ID.ToString) & ",dtDebit=getdate()")
                        End If
                End Select
                If sResult Then
                    'Καθαρισμός Controls
                    If Mode = FormMode.NewRecord Then Cls.ClearCtrls(LayoutControl1)
                    txtCode.Text = DBQ.GetNextId("COL_EXT")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmColExt_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub cboBDG_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboBDG.EditValue = Nothing : ManageBDG(cboBDG)
            Case 2 : If cboBDG.EditValue <> Nothing Then ManageBDG(cboBDG)
            Case 3 : cboBDG.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageBDG(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim form1 As frmBDG = New frmBDG()
        form1.Text = "Πολυκατοικία"
        form1.CallerControl = cbo
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        If cbo.EditValue <> Nothing Then
            form1.ID = cbo.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub cboCollector_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboCollector.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboCollector.EditValue = Nothing : ManageUSR(cboCollector)
            Case 2 : If cboCollector.EditValue <> Nothing Then ManageUSR(cboCollector)
            Case 3 : cboCollector.EditValue = Nothing
        End Select

    End Sub
    Private Sub ManageUSR(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim form1 As frmUsers = New frmUsers()
        form1.Text = "Χρήστης"
        form1.CallerControl = cbo
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        If cbo.EditValue <> Nothing Then
            form1.ID = cbo.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub cboColMethod_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboColMethod.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboColMethod.EditValue = Nothing : ManageColMethod(cboColMethod)
            Case 2 : If cboColMethod.EditValue <> Nothing Then ManageColMethod(cboColMethod)
            Case 3 : cboColMethod.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageColMethod(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Τρόποι Πληρωμής"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τρόπος Πληρωμής"
        form1.DataTable = "COL_METHOD"
        form1.CalledFromControl = True
        form1.CallerControl = cboColMethod
        form1.CallerForm = Me
        form1.MdiParent = frmMain
        If cboColMethod.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboColMethod.GetColumnValue("ID").ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub cboApt_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboApt.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboApt.EditValue = Nothing : ManageAPT(cboApt)
            Case 2 : If cboApt.EditValue <> Nothing Then ManageAPT(cboApt)
            Case 3 : cboApt.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageAPT(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim form1 As frmAPT = New frmAPT()
        form1.Text = "Διαμέρισμα"
        form1.BDGID = cboBDG.EditValue.ToString
        form1.CallerControl = cbo
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        If cbo.EditValue <> Nothing Then
            form1.ID = cbo.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub cboBank_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBank.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboBank.EditValue = Nothing : ManageBANK(cboBank)
            Case 2 : If cboBank.EditValue <> Nothing Then ManageBANK(cboBank)
            Case 3 : cboBank.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageBANK(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Τράπεζες"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τράπεζα"
        form1.DataTable = "BANK"
        form1.CalledFromControl = True
        form1.CallerControl = cboColMethod
        form1.CallerForm = Me
        form1.MdiParent = frmMain
        If cboColMethod.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboColMethod.GetColumnValue("ID").ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
End Class