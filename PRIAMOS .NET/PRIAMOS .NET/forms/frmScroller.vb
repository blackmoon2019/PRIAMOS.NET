Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraPrinting
Imports DevExpress.Export
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Card

Public Class frmScroller
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private sDataTable As String
    Private sDataDetail As String
    Private CurrentView As String
    'Private settings = System.Configuration.ConfigurationManager.AppSettings
    Private Sub frmScroller_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Λίστα με τιμές για TOP RECORDS
        LoadComboRecordValues()
        popSaveAsView.EditValue = BarViews.EditValue
        If BarViews.EditValue = "" Then popSaveView.Enabled = False : popDeleteView.Enabled = False
        'Παίρνω το όνομα της όψης για τον συγκεκριμένο χρήστη και για τον συγκεκριμένο πίνακα 
        GetCurrentView(True)
        'Φόρτωση Εγγραφών
        LoadRecords()
        'Φόρτωση Σχεδίων στην Λίστα βάση επιλογής από το μενού
        LoadViews()
        'Κρύψιμο Στηλών
        'HideColumns(GridView1, "ID")
        'Δικαιώματα
        BarNewRec.Enabled = UserProps.AllowInsert
        BarDelete.Enabled = UserProps.AllowDelete
        BarEdit.Enabled = UserProps.AllowEdit
    End Sub

    'Λίστα με τιμές για TOP RECORDS
    'Φόρτωση Λίστας με εγγραφές 
    Private Sub LoadComboRecordValues()
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("30")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("200")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("1000")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("10000")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("ALL")
        BarRecords.EditValue = My.Settings.Records
    End Sub
    'Φόρτωση όψεων Per User στο Combo
    Private Sub LoadViews()
        Try
            BarViews.EditValue = ""
            'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml") = False Then
                GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)
            End If
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\" & sDataDetail & "_def.xml") = False Then
                If sDataDetail <> "" Then GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\" & sDataDetail & "_def.xml", OptionsLayoutBase.FullLayout)
            End If

            'Εαν δεν υπάρχει Folder Σχεδίου για το συγκεκριμένο πίνακα δημιουργεί
            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\DSGNS\" & sDataTable) = False Then _
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\DSGNS\" & sDataTable)

            'Εαν δεν υπάρχει Folder Σχεδίου για το Detail πίνακα δημιουργεί
            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\DSGNS\" & sDataDetail) = False Then _
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\DSGNS\" & sDataDetail)


            CType(BarViews.Edit, RepositoryItemComboBox).Items.Clear()
            'Ψάχνει όλα τα σχέδια  του συκεκριμένου χρήστη για τον συγκεκριμένο πίνακα
            Dim files() As String = IO.Directory.GetFiles(Application.StartupPath & "\DSGNS\" & sDataTable, "*_" & UserProps.Code & "*")
            For Each sFile As String In files
                CType(BarViews.Edit, RepositoryItemComboBox).Items.Add(System.IO.Path.GetFileName(sFile))
            Next
            BarViews.EditValue = CurrentView
            If CurrentView = "" Then
                'grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml")
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)
                If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataDetail & "_def.xml", OptionsLayoutBase.FullLayout)
            Else
                'grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
                If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataDetail & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Διαγραφλη Εγγραφής
    Private Sub DeleteRecord()
        Dim sSQL As String
        Dim sSQL2 As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Select Case sDataTable
                    Case "vw_USR" : sSQL = "DELETE FROM USR WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_MAILS" : sSQL = "DELETE FROM MAILS WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_RIGHTS" : sSQL = "DELETE FROM RIGHTS WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                        sSQL2 = "DELETE FROM FORM_RIGHTS WHERE RID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                End Select

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                If sSQL2 <> "" Then
                    Using oCmd As New SqlCommand(sSQL2, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If
                LoadRecords()
                    XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public WriteOnly Property DataTable As String
        Set(value As String)
            sDataTable = value
        End Set
    End Property
    Public WriteOnly Property DataDetail As String
        Set(value As String)
            sDataDetail = value
        End Set
    End Property
    'Επιλογή όψης
    Private Sub BarViews_EditValueChanged(sender As Object, e As EventArgs) Handles BarViews.EditValueChanged
        Try
            popSaveAsView.EditValue = BarViews.EditValue
            If BarViews.EditValue <> "" Then
                'grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
                If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataDetail & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
                CurrentView = BarViews.EditValue
                popSaveView.Enabled = True
                popDeleteView.Enabled = True
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Κλείσιμο Φόρμας
    Private Sub frmScroller_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Παίρνω το όνομα της όψης για τον συγκεκριμένο χρήστη και για τον συγκεκριμένο πίνακα και το αποθηκεύω στην βάση
        GetCurrentView(False)
        If sDataDetail = "" Then myReader.Close()
    End Sub
    'Διαγραφή όψης
    Private Sub popDeleteView_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popDeleteView.ItemClick
        If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα όψη?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If BarViews.EditValue <> "" Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
                If sDataDetail <> "" Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\" & sDataDetail & "\" & BarViews.EditValue)
                CType(BarViews.Edit, RepositoryItemComboBox).Items.Remove(BarViews.EditValue)
                BarViews.EditValue = "" : CurrentView = "" : popSaveView.Enabled = False
            End If
        End If

    End Sub
    'Αποθήκευση ως όψης
    Private Sub RepositoryPopSaveAsView_KeyDown(sender As Object, e As KeyEventArgs) Handles RepositoryPopSaveAsView.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & sender.EditValue & "_" & UserProps.Code & ".xml", OptionsLayoutBase.FullLayout)
                If sDataDetail <> "" Then GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataDetail & "\" & sender.EditValue & "_" & UserProps.Code & ".xml", OptionsLayoutBase.FullLayout)
                'grdMain.DefaultView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & sender.EditValue & "_" & UserProps.Code & ".xml")
                CType(BarViews.Edit, RepositoryItemComboBox).Items.Add(sender.EditValue & "_" & UserProps.Code & ".xml")

                BarViews.EditValue = sender.EditValue & "_" & UserProps.Code & ".xml"
                CurrentView = BarViews.EditValue
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Αποθήκευση όψης
    Private Sub popSaveView_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popSaveView.ItemClick
        If BarViews.EditValue <> "" Then
            'grdMain.DefaultView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
            GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
            If sDataDetail <> "" Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\" & sDataDetail & "\" & BarViews.EditValue)
                GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataDetail & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
            End If
            'GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
            XtraMessageBox.Show("Η όψη αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    'Επαναφορά Default όψης
    Private Sub popRestoreView_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popRestoreView.ItemClick
        grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)
        BarViews.EditValue = "" : popSaveAsView.EditValue = "" : popSaveView.Enabled = False : popDeleteView.Enabled = False
        CurrentView = ""
    End Sub

    Private Sub RepositoryBarViews_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepositoryBarViews.SelectedIndexChanged
        My.Settings.CurrentView = sender.EditValue
        My.Settings.Save()
    End Sub

    Private Sub RepositoryBarRecords_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepositoryBarRecords.SelectedIndexChanged
        My.Settings.Records = BarRecords.EditValue
        My.Settings.Save()
        LoadRecords()
    End Sub

    'Προσθήκη επιλογών στο Standar Header Menu
    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()

            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChanged, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex
                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItem("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChanged, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

            End If
        Else
            PopupMenuRows.ShowPopup(Control.MousePosition)
        End If
    End Sub
    'Προσθήκη επιλογών στο Standar Detail Menu
    Private Sub GridView2_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView2.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()

            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
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
            End If
        Else
            PopupMenuRowsDetail.ShowPopup(Control.MousePosition)
        End If
    End Sub
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView1.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Αλλαγή Χρώματος Στήλης Detail
    Private Sub OnDetailColumnsColorChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView2.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Μετονομασία Στήλης Master
    Private Sub OnEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView1.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    'Μετονομασία Στήλης Detail
    Private Sub OnDetailEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView2.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    'Κλείδωμα Στήλης Master
    Private Sub OnCanMoveItemClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    'Κλείδωμα Στήλης Detail
    Private Sub OnCanMoveItemClickDetail(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    Private Function CreateCheckItem(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    Private Function CreateCheckItemDetail(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClickDetail))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    'Print Preview
    Private Sub BarPrintPreview_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarPrintPreview.ItemClick
        GridView1.GridControl.ShowRibbonPrintPreview()
    End Sub
    'XLSX Export
    Private Sub BarExportXLSX_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarExportXLSX.ItemClick
        Dim options = New XlsxExportOptionsEx()
        options.UnboundExpressionExportMode = UnboundExpressionExportMode.AsFormula
        XtraSaveFileDialog1.Filter = "XLSX Files (*.xlsx*)|*.xlsx"
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView1.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
            Process.Start(XtraSaveFileDialog1.FileName)
        End If
    End Sub
    'PDF Export
    Private Sub BarPDFExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarPDFExport.ItemClick
        XtraSaveFileDialog1.Filter = "PDF Files (*.pdf*)|*.pdf"
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView1.GridControl.ExportToPdf(XtraSaveFileDialog1.FileName)
            Process.Start(XtraSaveFileDialog1.FileName)
        End If
    End Sub

    Friend Class MenuColumnInfo
        Public Sub New(ByVal column As GridColumn)
            Me.Column = column
        End Sub
        Public Column As GridColumn
    End Class
    ' Πάιρνω από την βάση την τρέχουσα όψη του χρήστη
    Private Sub GetCurrentView(ByVal GetVal As Boolean)
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Try
            If GetVal Then
                Cmd = New SqlCommand("SELECT currentview FROM USR_V WHERE USRID = '" & UserProps.ID.ToString & "' and  DATATABLE = '" & sDataTable & "'", CNDB)
                sdr = Cmd.ExecuteReader()
                If (sdr.Read() = True) Then
                    If sdr.IsDBNull(sdr.GetOrdinal("currentview")) = False Then CurrentView = sdr.GetString(sdr.GetOrdinal("currentview"))
                    'Έλεγχος αν το τελευταίο σχέδιο που έχει αποθηκευτεί στην βάση υπάρχει στον δίσκο
                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & CurrentView) = False Then CurrentView = ""
                Else
                    CurrentView = ""
                End If
                sdr.Close()

            Else
                If CurrentView <> "" Then
                    Cmd = CNDB.CreateCommand
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.Add(New SqlParameter("@sDataTable", sDataTable))
                    Cmd.Parameters.Add(New SqlParameter("@ID", UserProps.ID))
                    Cmd.Parameters.Add(New SqlParameter("@CurrentView", CurrentView))
                    Cmd.CommandText = "SetUserView"
                    Cmd.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If GetVal Then sdr.Close()
        End Try

    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        EditRecord()
    End Sub
    'Νέα Εγγραφή
    Private Sub BarNewRec_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarNewRec.ItemClick
        NewRecord()
    End Sub
    'Επεξεργασία Εγγραφής
    Private Sub BarEdit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarEdit.ItemClick
        EditRecord()
    End Sub
    'Διαγραφή Εγγραφής
    Private Sub BarDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarDelete.ItemClick
        DeleteRecord()
    End Sub
    'Ανανέωση εγγραφών
    Private Sub BarRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarRefresh.ItemClick
        LoadRecords()
    End Sub
    'Επεξεργασία Εγγραφής
    Private Sub EditRecord()
        Dim form As frmUsers = New frmUsers()
        Dim form2 As frmMailSettings = New frmMailSettings()
        Dim form3 As frmPermissions = New frmPermissions()
        Select Case sDataTable
            Case "vw_USR"
                form.Text = "Διαχείριση Χρηστών"
                form.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                form.MdiParent = frmMain
                form.Mode = FormMode.EditRecord
                form.Scroller = GridView1
                form.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                form.Show()
            Case "vw_MAILS"
                form2.Text = "Email Settings"
                form2.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                form2.MdiParent = frmMain
                form2.Mode = FormMode.EditRecord
                form2.Scroller = GridView1
                form2.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form2), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                form2.Show()
            Case "vw_RIGHTS"
                form3.Text = "Δικαιώματα"
                form3.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                form3.MdiParent = frmMain
                form3.Mode = FormMode.EditRecord
                form3.Scroller = GridView1
                form3.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form3), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                form3.Show()
        End Select
    End Sub
    'Νέα Εγγραφή
    Private Sub NewRecord()
        Dim form As frmUsers = New frmUsers()
        Dim form2 As frmMailSettings = New frmMailSettings()
        Dim form3 As frmPermissions = New frmPermissions()
        Select Case sDataTable
            Case "vw_USR"
                form.Text = "Διαχείριση Χρηστών"
                form.MdiParent = frmMain
                form.Mode = FormMode.NewRecord
                form.Scroller = GridView1
                form.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                form.Show()
            Case "vw_MAILS"
                form2.Text = "Email Settings"
                form2.MdiParent = frmMain
                form2.Mode = FormMode.NewRecord
                form2.Scroller = GridView1
                form2.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form2), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                form2.Show()
            Case "vw_RIGHTS"
                form3.Text = "Δικαιώματα"
                form3.MdiParent = frmMain
                form3.Mode = FormMode.NewRecord
                form3.Scroller = GridView1
                form3.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form3), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                form3.Show()
        End Select
    End Sub
    'Φορτώνω τις εγγραφές στο GRID
    Public Sub LoadRecords(Optional ByVal sDataTable2 As String = "")
        Dim sSQL As String
        Dim sSQL2 As String

        If BarRecords.EditValue <> "ALL" And BarRecords.EditValue <> "" Then
            sSQL = "SELECT top " & BarRecords.EditValue & " * FROM " & IIf(sDataTable = "", sDataTable2, sDataTable)
            If sDataDetail <> "" Then sSQL2 = "SELECT top " & BarRecords.EditValue & " * FROM " & sDataDetail
        Else
            sSQL = "SELECT  * FROM " & IIf(sDataTable = "", sDataTable2, sDataTable)
            If sDataDetail <> "" Then sSQL2 = "SELECT  * FROM " & sDataDetail
        End If

        If sDataDetail = "" Then
            myCmd = CNDB.CreateCommand
            myCmd.CommandText = sSQL
            GridView1.Columns.Clear()
            myReader = myCmd.ExecuteReader()
            grdMain.DataSource = myReader
        Else
            Select Case sDataDetail
                Case "vw_FORM_RIGHTS"
                    Dim AdapterMaster As New SqlDataAdapter(sSQL, CNDB)
                    Dim AdapterDetail As New SqlDataAdapter(sSQL2, CNDB)
                    Dim sdataSet As New DataSet()
                    AdapterMaster.Fill(sdataSet, IIf(sDataTable = "", sDataTable2, sDataTable))
                    AdapterDetail.Fill(sdataSet, sDataDetail)
                    Dim keyColumn As DataColumn = sdataSet.Tables(IIf(sDataTable = "", sDataTable2, sDataTable)).Columns("ID")
                    Dim foreignKeyColumn As DataColumn = sdataSet.Tables(sDataDetail).Columns("RID")
                    sdataSet.Relations.Add("Φόρμες", keyColumn, foreignKeyColumn)
                    GridView1.Columns.Clear()
                    GridView2.Columns.Clear()
                    grdMain.DataSource = sdataSet.Tables(IIf(sDataTable = "", sDataTable2, sDataTable))
                    grdMain.ForceInitialize()
            End Select
        End If
        grdMain.DefaultView.PopulateColumns()

        'Εαν δεν έχει data το Dataset αναγκαστικά προσθέτω μόνος μου τις στήλες
        If sDataDetail = "" Then
            If myReader.HasRows = False Then
                For i As Integer = 0 To myReader.FieldCount - 1
                    Dim C As New GridColumn
                    C.Name = myReader.GetName(i).ToString
                    C.Caption = myReader.GetName(i).ToString
                    C.Visible = True
                    GridView1.Columns.Add(C)
                Next i
            End If
        End If
        LoadViews()

        'If grdMain.DefaultView.DataRowCount <> 0 Then myReader.Close() 'myReader.Close()
    End Sub
    Private Sub grdMain_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMain.KeyDown
        Select Case e.KeyCode
            Case Keys.F2 : If UserProps.AllowInsert = True Then NewRecord()
            Case Keys.F3 : If UserProps.AllowEdit = True Then EditRecord()
            Case Keys.F5 : LoadRecords()
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteRecord()
        End Select
    End Sub

    Private Sub frmScroller_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If e.Column.FieldName.Contains("pwd") Then e.DisplayText = StrDup(e.DisplayText.Length, "*")

    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        Dim view As GridView = CType(sender, GridView)
        If e.Control AndAlso e.KeyCode = Keys.C Then
            If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
                Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
            End If
            e.Handled = True
        End If
    End Sub
    'Ορίζουμε το Detail View στο GridView2 που προσθέσαμε στο Design.  
    Private Sub grdMain_ViewRegistered(sender As Object, e As DevExpress.XtraGrid.ViewOperationEventArgs) Handles grdMain.ViewRegistered
        GridView2 = TryCast(e.View, GridView)
        GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridView2.OptionsBehavior.Editable = False
        GridView2.OptionsBehavior.ReadOnly = True
        GridView2.OptionsLayout.Columns.StoreAllOptions = True
        GridView2.OptionsLayout.Columns.StoreAppearance = True
        GridView2.OptionsLayout.StoreAllOptions = True
        GridView2.OptionsLayout.StoreAppearance = True
        GridView2.OptionsLayout.StoreFormatRules = True
        GridView2.OptionsPrint.PrintPreview = True
        GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView2.OptionsView.EnableAppearanceEvenRow = True
        If CurrentView = "" Then
            If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataDetail & "_def.xml", OptionsLayoutBase.FullLayout)
        Else
            If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataDetail & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
        End If
    End Sub
    'Αποθήκευση όψης ως Default
    Private Sub popSaveAsDefault_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popSaveAsDefault.ItemClick
        GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)
        If sDataDetail <> "" Then GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\" & sDataDetail & "_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    ' Copy Cell
    Private Sub BarCopyCell_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyCell.ItemClick
        Dim view As GridView = CType(GridView1, GridView)
        If View.GetRowCellValue(View.FocusedRowHandle, View.FocusedColumn) IsNot Nothing AndAlso View.GetRowCellValue(View.FocusedRowHandle, View.FocusedColumn).ToString() <> [String].Empty Then
            Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
        End If
    End Sub
    'Copy All
    Private Sub BarCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyAll.ItemClick
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        GridView1.OptionsSelection.MultiSelect = False
    End Sub
    'Copy Row
    Private Sub BarCopyRow_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyRow.ItemClick
        Dim view As GridView = CType(GridView1, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            GridView1.OptionsSelection.MultiSelect = True
            GridView1.SelectRow(view.FocusedRowHandle)
            GridView1.CopyToClipboard()
            GridView1.OptionsSelection.MultiSelect = False
        End If
    End Sub
    'Copy Row
    Private Sub BarCopyRow_D_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyRow_D.ItemClick
        Dim view As GridView = CType(GridView2, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            GridView2.OptionsSelection.MultiSelect = True
            GridView2.SelectRow(view.FocusedRowHandle)
            GridView2.CopyToClipboard()
            GridView2.OptionsSelection.MultiSelect = False
        End If
    End Sub
    'Copy All
    Private Sub BarCopyAll_D_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyAll_D.ItemClick
        GridView2.OptionsSelection.MultiSelect = True
        GridView2.SelectAll()
        GridView2.CopyToClipboard()
        GridView2.OptionsSelection.MultiSelect = False
    End Sub
    ' Copy Cell
    Private Sub BarCopyCell_D_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyCell_D.ItemClick
        Dim view As GridView = CType(GridView2, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
        End If
    End Sub

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        Dim view As GridView = CType(sender, GridView)
        If e.Control AndAlso e.KeyCode = Keys.C Then
            If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
                Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
            End If
            e.Handled = True
        End If
    End Sub
End Class