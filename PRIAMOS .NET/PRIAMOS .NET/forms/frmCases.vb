Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
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
        If System.IO.File.Exists(Application.StartupPath & "\DSGNS\DEF\TASKS_def.xml") = True Then GridView3.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\TASKS_def.xml", OptionsLayoutBase.FullLayout)
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        My.Settings.frmCASES = Me.Location
        My.Settings.Save()
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
                    If Mode = FormMode.NewRecord Then Cls.ClearCtrls(LayoutControl1)
                    txtCode.Text = DBQ.GetNextId("CASES")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                    LayoutControl2.Enabled = True
                    cboCCT.EditValue = System.Guid.Parse(ProgProps.ADM)
                    dtVisitDate.EditValue = Date.Now
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmCases_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
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
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView3.CellValueChanged
        Dim mes As Decimal, mesB As Decimal, Dif As Decimal
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView3.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim menuItem As DevExpress.Utils.Menu.DXEditMenuItem
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()

            menuItem = menu.Items.Item("Μετονομασία Στήλης")
            'menu.Items.Clear()
            If menu.Column IsNot Nothing And menuItem Is Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnDetailEditValueChanged, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex
                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItemDetail("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnDetailColumnsColorChanged, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveView, Nothing, Nothing, Nothing, Nothing))

                '5nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Συγχρονισμός όψης από Server", AddressOf OnSyncView, Nothing, Nothing, Nothing, Nothing))



            End If
        End If

    End Sub
    Private Function CreateCheckItemDetail(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClickDetail))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    'Κλείδωμα Στήλης Detail
    Private Sub OnCanMoveItemClickDetail(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    Friend Class MenuColumnInfo
        Public Sub New(ByVal column As GridColumn)
            Me.Column = column
        End Sub
        Public Column As GridColumn
    End Class


    'Μετονομασία Στήλης Detail
    Private Sub OnDetailEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView3.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    'Αλλαγή Χρώματος Στήλης Detail
    Private Sub OnDetailColumnsColorChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView3.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub

    Private Sub OnSaveView(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView3.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\TASKS_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Μόνο αν ο Χρήστης είναι ο Παναγόπουλος
        If UserProps.ID.ToString.ToUpper = "E9CEFD11-47C0-4796-A46B-BC41C4C3606B" Or
           UserProps.ID.ToString.ToUpper = "526EAA73-3B21-4BEE-A575-F19BD2BC5FCF" Or
           UserProps.ID.ToString.ToUpper = "97E2CB01-93EA-4F97-B000-FDA359EC943C" Then
            If XtraMessageBox.Show("Θέλετε να γίνει κοινοποίηση της όψης? Εαν επιλέξετε 'Yes' όλοι οι χρήστες θα έχουν την ίδια όψη", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If My.Computer.FileSystem.FileExists(UserProps.ServerViewsPath & "DSGNS\DEF\TASKS_def.xml") = False Then GridView3.OptionsLayout.LayoutVersion = "v1"
                GridView3.SaveLayoutToXml(UserProps.ServerViewsPath & "DSGNS\DEF\TASKS_def.xml", OptionsLayoutBase.FullLayout)
            End If
        End If

    End Sub
    'Συγχρονισμός όψης από Server
    Private Sub OnSyncView(ByVal sender As System.Object, ByVal e As EventArgs)
        If XtraMessageBox.Show("Θέλετε να γίνει μεταφορά της όψης από τον server?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            ' Έλεγχος αν υπάρχει όψη με μεταγενέστερη ημερομηνία στον Server
            If System.IO.File.Exists(UserProps.ServerViewsPath & "DSGNS\DEF\TASKS_def.xml") = True Then
                My.Computer.FileSystem.CopyFile(UserProps.ServerViewsPath & "DSGNS\DEF\TASKS_def.xml", Application.StartupPath & "\DSGNS\DEF\TASKS_def.xml", True)
                GridView3.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\TASKS_def.xml", OptionsLayoutBase.FullLayout)
            End If
        End If
    End Sub

    Private Sub cmdRefreshTask_Click(sender As Object, e As EventArgs) Handles cmdRefreshTask.Click
        Me.Vw_TASKSTableAdapter.FillByCase(Me.Priamos_NETDataSet.vw_TASKS, System.Guid.Parse(sID))
    End Sub

    Private Sub cmdDeleteTask_Click(sender As Object, e As EventArgs) Handles cmdDeleteTask.Click
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφή η εγγραφή ?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM TASKS  WHERE ID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Me.Vw_TASKSTableAdapter.FillByCase(Me.Priamos_NETDataSet.vw_TASKS, System.Guid.Parse(sID))
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmAddTask_Click(sender As Object, e As EventArgs) Handles cmAddTask.Click
        Cls.ClearCtrls(LayoutControl2)
        cboCCT.EditValue = System.Guid.Parse(ProgProps.ADM)
        dtVisitDate.EditValue = Date.Now
    End Sub
End Class