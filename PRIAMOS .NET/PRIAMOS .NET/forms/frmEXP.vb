Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmEXP
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private Log As New Transactions
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Dim sGuid As String

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
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmEXP_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sSQL As New System.Text.StringBuilder
        'Κατηγορίες Εξόδων
        FillCbo.EXC(cboEXC)
        'Κατηγορίες Χιλιοστών
        FillCbo.MLC(cboMLC)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("EXP")
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_EXP where id ='" + sID + "'")
        End Select
        '  Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        My.Settings.frmEXP = Me.Location
        My.Settings.Save()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub frmEXP_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "EXP", LayoutControl1,,, sGuid)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "EXP", LayoutControl1,,, sID)
                End Select
                If sResult Then
                    'Καθαρισμός Controls
                    If Mode = FormMode.NewRecord Then Cls.ClearCtrls(LayoutControl1)
                    txtCode.Text = DBQ.GetNextId("EXP")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Dim form As New frmScroller
                    'form.LoadRecords("vw_EXP")
                    Valid.SChanged = False
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmEXP_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub


    Private Sub cboEXC_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboEXC.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboEXC.EditValue = Nothing : ManageEXC()
            Case 2 : If cboEXC.EditValue <> Nothing Then ManageEXC()
            Case 3 : cboEXC.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageEXC()
        Dim frmGen As frmGen = New frmGen
        frmGen.Text = "Κατηγορίες Εξόδων"
        frmGen.L1.Text = "Κωδικός"
        frmGen.L2.Text = "Κατηγορία"
        frmGen.DataTable = "EXC"
        frmGen.CallerControl = cboEXC
        frmGen.CalledFromControl = True
        If cboEXC.EditValue <> Nothing Then frmGen.ID = cboEXC.EditValue.ToString
        frmGen.MdiParent = frmMain
        If cboEXC.EditValue <> Nothing Then frmGen.Mode = FormMode.EditRecord Else frmGen.Mode = FormMode.NewRecord
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(frmGen), New Point(CInt(frmGen.Parent.ClientRectangle.Width / 2 - frmGen.Width / 2), CInt(frmGen.Parent.ClientRectangle.Height / 2 - frmGen.Height / 2)))
        frmGen.Show()
    End Sub

    Private Sub cboMLC_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboMLC.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboMLC.EditValue = Nothing : ManageMLC()
            Case 2 : If cboMLC.EditValue <> Nothing Then ManageMLC()
            Case 3 : cboMLC.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageMLC()
        Dim frmGen As frmGen = New frmGen
        frmGen.Text = "Κατηγορίες Χιλιοστών"
        frmGen.L1.Text = "Κωδικός"
        frmGen.L2.Text = "Κατηγορία"
        frmGen.DataTable = "MLC"
        frmGen.CallerControl = cboMLC
        frmGen.CalledFromControl = True
        If cboMLC.EditValue <> Nothing Then frmGen.ID = cboMLC.EditValue.ToString
        frmGen.MdiParent = frmMain
        If cboMLC.EditValue <> Nothing Then frmGen.Mode = FormMode.EditRecord Else frmGen.Mode = FormMode.NewRecord
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(frmGen), New Point(CInt(frmGen.Parent.ClientRectangle.Width / 2 - frmGen.Width / 2), CInt(frmGen.Parent.ClientRectangle.Height / 2 - frmGen.Height / 2)))
        frmGen.Show()
    End Sub
End Class