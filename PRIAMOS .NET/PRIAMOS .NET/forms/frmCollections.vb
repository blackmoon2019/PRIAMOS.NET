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

Public Class frmCollections
    Private sID As String, sbdgID As String, sinhID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private FScrollerExist As Boolean = False
    Private Valid As New ValidateControls
    Private Log As New Transactions
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private LoadForms As New FormLoader
    Private Cls As New ClearControls
    Private Calendar As New InitializeCalendar
    Private sColor As Integer
    Private detailView As GridView
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property BDGID As String
        Set(value As String)
            sbdgID = value
        End Set
    End Property
    Public WriteOnly Property INHID As String
        Set(value As String)
            sinhID = value
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
    Public WriteOnly Property FormScrollerExist As Boolean
        Set(value As Boolean)
            FScrollerExist = value
        End Set
    End Property
    Private Sub cmdExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmCollections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COLH' table. You can move, or remove it, as needed.
        Me.Vw_COLHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COLH)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet1.vw_COLH' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_USR' table. You can move, or remove it, as needed.
        Me.Vw_USRTableAdapter.Fill(Me.Priamos_NETDataSet.vw_USR)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BANKS' table. You can move, or remove it, as needed.
        Me.Vw_BANKSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BANKS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COL_METHOD' table. You can move, or remove it, as needed.
        Me.Vw_COL_METHODTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COL_METHOD)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COL' table. You can move, or remove it, as needed.
        Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COL)
        Me.Vw_USR_creditTableAdapter1.FillBYID(Me.Priamos_NETDataSet.vw_USR_credit, System.Guid.Parse(UserProps.ID.ToString))

        If sbdgID <> Nothing Then
            cboBDG.EditValue = System.Guid.Parse(sbdgID)
            cboINH.EditValue = System.Guid.Parse(sinhID)
        End If
        Me.CenterToScreen()
        My.Settings.frmCollections = Me.Location
        My.Settings.Save()


        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_H_def.xml") = False Then
            GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_H_def.xml", OptionsLayoutBase.FullLayout)
        End If
        GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_H_def.xml", OptionsLayoutBase.FullLayout)

    End Sub

    Private Sub frmCollections_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue <> Nothing Then
            Me.Vw_COLHTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_COLH, System.Guid.Parse(cboBDG.EditValue.ToString))
            Me.Vw_INHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INH, System.Guid.Parse(cboBDG.EditValue.ToString))
        Else
            Me.Vw_COLHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COLH)
            Me.Vw_INHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INH, System.Guid.Empty)
        End If
    End Sub

    Private Sub cmdExit_Click_1(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView5.CellValueChanged
        Try
            Dim sSQL As String, dtcredit As String, dtdebit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal


            If detailView.GetRowCellValue(detailView.FocusedRowHandle, "dtCredit") Is DBNull.Value Then
                dtcredit = "NULL"
            Else
                dtcredit = toSQLValueS(CDate(detailView.GetRowCellValue(detailView.FocusedRowHandle, "dtCredit")).ToString("yyyyMMdd"))

            End If

            If detailView.GetRowCellValue(detailView.FocusedRowHandle, "dtDebit") Is DBNull.Value Then
                dtdebit = "NULL"
            Else
                dtdebit = toSQLValueS(CDate(detailView.GetRowCellValue(detailView.FocusedRowHandle, "dtDebit")).ToString("yyyyMMdd"))
            End If
            If detailView.GetRowCellValue(detailView.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If detailView.GetRowCellValue(detailView.FocusedRowHandle, "debit") Is DBNull.Value Then
                debit = 0
            Else
                debit = detailView.GetRowCellValue(detailView.FocusedRowHandle, "debit")
            End If
            If detailView.GetRowCellValue(detailView.FocusedRowHandle, "credit") Is DBNull.Value Then
                credit = 0
            Else
                credit = detailView.GetRowCellValue(detailView.FocusedRowHandle, "credit")
            End If
            If detailView.GetRowCellValue(detailView.FocusedRowHandle, "bal") Is DBNull.Value Then
                bal = 0
            Else
                bal = detailView.GetRowCellValue(detailView.FocusedRowHandle, "bal")
            End If

            Select Case e.Column.FieldName
                Case "credit"
                    bal = debit - credit
                    dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
                    sSQL = "UPDATE [COL] SET dtcredit  = " & dtcredit & ",dtdebit  = " & dtdebit &
                            ",credit = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "credit"), True) &
                            ",creditusrID  = " & toSQLValueS(UserProps.ID.ToString) &
                            ",bal = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "bal"), True) &
                            " WHERE ID = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "ID").ToString)

                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                    detailView.SetRowCellValue(detailView.FocusedRowHandle, "bal", bal)
                    detailView.SetRowCellValue(detailView.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))
                    detailView.SetRowCellValue(detailView.FocusedRowHandle, "creditusrID", System.Guid.Parse(UserProps.ID.ToString))
                    ' Ενημέρωση Header Είσπραξης
                    Using oCmd As New SqlCommand("COL_Calculate", CNDB)
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.Parameters.AddWithValue("@colHid", detailView.GetRowCellValue(detailView.FocusedRowHandle, "colHID").ToString.ToUpper)
                        oCmd.ExecuteNonQuery()
                    End Using
                Case "ColMethodID"
                    sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "ColMethodID").ToString) &
                            " WHERE ID = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                Case "bankID"
                    sSQL = "UPDATE [COL] SET bankID  = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "bankID").ToString) &
                            " WHERE ID = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

            End Select


            '    sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "ColMethodID").ToString) &
            '        ",bankID  = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "bankID").ToString) &
            '        ",debitusrID  = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "debitusrID").ToString) &
            '        ",creditusrID  = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "creditusrID").ToString) &
            '        ",dtcredit  = " & dtcredit &
            '        ",dtdebit  = " & dtdebit &
            '        ",credit = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "credit"), True) &
            '        ",bal = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "bal"), True) &
            '" WHERE ID = " & toSQLValueS(detailView.GetRowCellValue(detailView.FocusedRowHandle, "ID").ToString)

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RepositoryCOL_METHOD_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryCOL_METHOD.ButtonPressed
        Select Case e.Button.Index
            Case 1 : detailView.SetRowCellValue(detailView.FocusedRowHandle, "ColMethodID", "")
        End Select
    End Sub



    Private Sub RepositoryBANK_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryBANK.ButtonPressed
        Select Case e.Button.Index
            Case 1 : detailView.SetRowCellValue(detailView.FocusedRowHandle, "bankID", "")
        End Select
    End Sub

    Private Sub cboINH_EditValueChanged(sender As Object, e As EventArgs) Handles cboINH.EditValueChanged
        If cboINH.EditValue = Nothing Then
            Me.Vw_COLHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COLH)
        Else
            Me.Vw_COLHTableAdapter.FillByINH(Me.Priamos_NETDataSet.vw_COLH, System.Guid.Parse(cboINH.EditValue.ToString))
        End If

    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        Dim sSQL As String
        Dim I As Integer
        Dim sDebitUsr As String
        Dim dtdebit As String
        For I = 0 To detailView.SelectedRowsCount - 1
            If cboDebitUsr.Text = "" Then sDebitUsr = "NULL" Else sDebitUsr = toSQLValueS(cboDebitUsr.EditValue.ToString)
            dtdebit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
            'If GridView5.GetRowCellValue(GridView5.GetSelectedRows(I), "debitusrID").ToString = GridView5.GetRowCellValue(GridView5.GetSelectedRows(I), "creditusrID").ToString Then
            If detailView.GetRowCellValue(detailView.GetSelectedRows(I), "dtCredit") Is DBNull.Value Then
                sSQL = "UPDATE COL SET DEBITUSRID = " & sDebitUsr &
                     ",CREDITUSRID = " & toSQLValueS(UserProps.ID.ToString) &
                     ",dtDebit= " & dtdebit &
                    " WHERE ID = " & toSQLValueS(detailView.GetRowCellValue(detailView.GetSelectedRows(I), "ID").ToString)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            End If
            'End If
        Next

        If cboBDG.EditValue <> Nothing Then
            Me.Vw_COLHTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_COLH, System.Guid.Parse(cboBDG.EditValue.ToString))
            Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_COL, System.Guid.Parse(cboBDG.EditValue.ToString))
        End If
        If cboINH.EditValue <> Nothing Then
            Me.Vw_COLHTableAdapter.FillByINH(Me.Priamos_NETDataSet.vw_COLH, System.Guid.Parse(cboINH.EditValue.ToString))
            Me.Vw_COLTableAdapter.FillByINH(Me.Priamos_NETDataSet.vw_COL, System.Guid.Parse(cboINH.EditValue.ToString))
        End If

    End Sub

    Private Sub cboBDG_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonPressed
        Select Case e.Button.Index
            Case 1 : If cboBDG.EditValue <> Nothing Then ManageBDG(cboBDG)
            Case 2 : cboBDG.EditValue = Nothing
            Case 3
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
    Private Sub ManageINH(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim fINH As frmINH = New frmINH()
        fINH.Text = "Κοινόχρηστα"
        If cbo.EditValue <> Nothing Then
            fINH.ID = cbo.EditValue.ToString
            fINH.Mode = FormMode.EditRecord
        Else
            fINH.Mode = FormMode.NewRecord
        End If
        fINH.MdiParent = frmMain
        fINH.Mode = FormMode.EditRecord
        fINH.FormScroller = Me
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(fINH.Parent.ClientRectangle.Width / 2 - fINH.Width / 2), CInt(fINH.Parent.ClientRectangle.Height / 2 - fINH.Height / 2)))
        fINH.Show()
    End Sub
    'Απενεργοποιεί όλα τα κελιά  όταν ο χρήστης χρέωσης δεν είναι ίδιος με τον Χρήστη Πιστωσης
    Private Sub GridView5_ShowingEditor(sender As Object, e As CancelEventArgs) Handles GridView5.ShowingEditor
        If detailView.GetRowCellValue(detailView.FocusedRowHandle, "debitusrID").ToString <> detailView.GetRowCellValue(detailView.FocusedRowHandle, "creditusrID").ToString Or
            (detailView.GetRowCellValue(detailView.FocusedRowHandle, "debitusrID").ToString = "" And detailView.GetRowCellValue(detailView.FocusedRowHandle, "creditusrID").ToString = "") Then
            e.Cancel = True
        Else
            '   GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))

        End If
    End Sub

    Private Sub GridView5_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView5.PopupMenuShowing
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

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveView, Nothing, Nothing, Nothing, Nothing))

            End If
        End If
    End Sub

    'Μετονομασία Στήλης Master
    Private Sub OnEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        detailView.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Function CreateCheckItem(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        detailView.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
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
    'Αποθήκευση όψης 
    Private Sub OnSaveView(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        detailView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COLLECTIONS_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub RepositoryUSRCredit_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryUSRCredit.ButtonPressed
        Select Case e.Button.Index
            Case 1 : detailView.SetRowCellValue(detailView.FocusedRowHandle, "creditusrID", "")
        End Select
    End Sub

    Private Sub RepositoryUSRDebit_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryUSRDebit.ButtonPressed
        Select Case e.Button.Index
            Case 1 : detailView.SetRowCellValue(detailView.FocusedRowHandle, "debitusrID", "")
        End Select
    End Sub

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
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChangedH, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex

                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItemH("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChangedH, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveViewH, Nothing, Nothing, Nothing, Nothing))

            End If
        End If
    End Sub

    'Μετονομασία Στήλης Master
    Private Sub OnEditValueChangedH(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView2.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Function CreateCheckItemH(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClickH))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChangedH(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView2.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Κλείδωμα Στήλης Master
    Private Sub OnCanMoveItemClickH(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    'Αποθήκευση όψης 
    Private Sub OnSaveViewH(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_H_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub GridView2_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles GridView2.MasterRowExpanded

        Dim visibleDetailRelationIndex As Integer = GridView2.GetVisibleDetailRelationIndex(e.RowHandle)
        detailView = TryCast(GridView2.GetDetailView(e.RowHandle, visibleDetailRelationIndex), GridView)
        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COLLECTIONS_def.xml") = False Then
            detailView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COLLECTIONS_def.xml", OptionsLayoutBase.FullLayout)
        End If
        detailView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COLLECTIONS_def.xml", OptionsLayoutBase.FullLayout)
        'Dim cBox As New RepositoryItemComboBox()
        'cBox.Items.AddRange(New String() {"A", "B", "C", "D"})
        'masterView.Grid.RepositoryItems.Add(cBox)
        'detailView.Columns("Col2").ColumnEdit = cBox
    End Sub

    Private Sub cboINH_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboINH.ButtonPressed
        Select Case e.Button.Index
            Case 1 : If cboINH.EditValue <> Nothing Then ManageINH(cboINH)
            Case 2 : cboINH.EditValue = Nothing
            Case 3
        End Select
    End Sub



    Friend Class MenuColumnInfo
        Public Sub New(ByVal column As GridColumn)
            Me.Column = column
        End Sub
        Public Column As GridColumn
    End Class
End Class