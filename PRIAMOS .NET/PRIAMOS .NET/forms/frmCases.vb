Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmCases
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private CtrlCombo As DevExpress.XtraEditors.LookUpEdit
    Private CalledFromCtrl As Boolean
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader

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
    Public WriteOnly Property CallerControl As DevExpress.XtraEditors.LookUpEdit
        Set(value As DevExpress.XtraEditors.LookUpEdit)
            CtrlCombo = value
        End Set
    End Property
    Public WriteOnly Property CalledFromControl As Boolean
        Set(value As Boolean)
            CalledFromCtrl = value
        End Set
    End Property



    Private Sub frmCases_Load(sender As Object, e As EventArgs) Handles Me.Load

        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_PARTNER_AND_WORKSHOP' table. You can move, or remove it, as needed.
        Me.Vw_PARTNER_AND_WORKSHOPTableAdapter.Fill(Me.Priamos_NETDataSet.vw_PARTNER_AND_WORKSHOP)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_TASKS_CAT' table. You can move, or remove it, as needed.
        Me.Vw_TASKS_CATTableAdapter.Fill(Me.Priamos_NETDataSet.vw_TASKS_CAT)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_USR' table. You can move, or remove it, as needed.
        Me.Vw_USRTableAdapter.Fill(Me.Priamos_NETDataSet.vw_USR)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.FillByIsManaged(Me.Priamos_NETDataSet.vw_BDG)
        Dim sSQL As New System.Text.StringBuilder
        'Πολυκατοικίες
        'FillCbo.BDG(cboBDG)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("CASES")
                LayoutControl2.Enabled = False
                cboUSR.EditValue = UserProps.ID
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_CASES where id ='" + sID + "'")
                Me.Vw_TASKSTableAdapter.FillByCase(Me.Priamos_NETDataSet.vw_TASKS, System.Guid.Parse(sID))
        End Select
        cboCCT.EditValue = System.Guid.Parse(ProgProps.ADM)
        dtVisitDate.EditValue = Date.Now
        LoadForms.RestoreLayoutFromXml(GridView3, "TASKS_def.xml")
        'Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)

    End Sub

    Private Sub frmCases_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "CASES", LayoutControl1,,, sGuid)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "CASES", LayoutControl1,,, sID)
                End Select
                If sResult Then
                    'Καθαρισμός Controls
                    If Mode = FormMode.NewRecord Then Mode = FormMode.EditRecord : sID = sGuid
                    'txtCode.Text = DBQ.GetNextId("CASES")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                    LayoutControl2.Enabled = True
                    cboCCT.EditValue = System.Guid.Parse(ProgProps.ADM)
                    dtVisitDate.EditValue = Date.Now
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmCases_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
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
    Private Sub cbotaskCat_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cbotaskCat.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cbotaskCat.EditValue = Nothing : ManageTASK(cbotaskCat)
            Case 2 : If cbotaskCat.EditValue <> Nothing Then ManageTASK(cbotaskCat)
            Case 3 : cbotaskCat.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageTASK(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Εργασίες"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Εργασία"
        form1.DataTable = "TASKS_CAT"
        form1.CalledFromControl = True
        form1.CallerControl = cbotaskCat
        form1.MdiParent = frmMain
        If cbotaskCat.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cbotaskCat.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Private Sub chkManage_CheckedChanged(sender As Object, e As EventArgs) Handles chkManage.CheckedChanged
        If chkManage.Checked = True Then dtCompleteDate.EditValue = Date.Now Else dtCompleteDate.EditValue = Nothing
    End Sub
    Private Sub cboCCT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboCCT.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboCCT.EditValue = Nothing : ManageCCT(False)
            Case 2 : If cboCCT.EditValue <> Nothing Then ManageCCT(False)
            Case 3 : cboCCT.EditValue = Nothing
        End Select
    End Sub

    Private Sub ManageCCT(ByVal isFromGrid As Boolean, Optional ByRef RecID As String = "")
        Dim form1 As frmCustomers = New frmCustomers()
        form1.Text = "Επαφές"
        If isFromGrid = False Then
            form1.CallerControl = cboCCT
            form1.CalledFromControl = True
            If cboCCT.EditValue <> Nothing Then
                form1.ID = cboCCT.EditValue.ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
                form1.chkWorkshop.Checked = True
                form1.chkPrivate.Checked = False
            End If
        End If
        form1.ShowDialog()
    End Sub
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdSaveTask_Click(sender As Object, e As EventArgs) Handles cmdSaveTask.Click
        Dim sResult As Boolean
        Dim sGuidTask As String
        Try
            If Valid.ValidateForm(LayoutControl2) Then
                sGuidTask = System.Guid.NewGuid.ToString
                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "TASKS", LayoutControl2,,, sGuidTask,, "caseID", toSQLValueS(sID))
                If sResult Then
                    'Καθαρισμός Controls
                    Cls.ClearCtrls(LayoutControl2)
                    Me.Vw_TASKSTableAdapter.FillByCase(Me.Priamos_NETDataSet.vw_TASKS, System.Guid.Parse(sID))
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView3.CellValueChanged
        Try
            'If e.Column.FieldName <> "description" Or e.Column.FieldName <> "dtVisit" Or e.Column.FieldName <> "cmt" Or e.Column.FieldName <> "cctID" Then Exit Sub
            If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID") = Nothing Then Exit Sub


            Dim sSQL As String



            sSQL = "UPDATE  TASKS SET description = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "description").ToString) &
                        ",cmt = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "cmt").ToString) &
                        ",cctID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "cctID").ToString) &
                        ",dtVisit = " & toSQLValueS(CDate(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "dtVisit")).ToString("yyyyMMdd")) &
                        " WHERE ID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString)

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView3.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView3, "TASKS_def.xml", "vw_TASKS")
    End Sub


    Private Sub cmdRefreshTask_Click(sender As Object, e As EventArgs) Handles cmdRefreshTask.Click
        Me.Vw_TASKSTableAdapter.FillByCase(Me.Priamos_NETDataSet.vw_TASKS, System.Guid.Parse(sID))
    End Sub

    Private Sub cmdDeleteTask_Click(sender As Object, e As EventArgs) Handles cmdDeleteTask.Click
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφή η εγγραφή ?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM TASKS  WHERE ID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Me.Vw_TASKSTableAdapter.FillByCase(Me.Priamos_NETDataSet.vw_TASKS, System.Guid.Parse(sID))
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmAddTask_Click(sender As Object, e As EventArgs) Handles cmAddTask.Click
        Cls.ClearCtrls(LayoutControl2)
        cboCCT.EditValue = System.Guid.Parse(ProgProps.ADM)
        dtVisitDate.EditValue = Date.Now
    End Sub
End Class