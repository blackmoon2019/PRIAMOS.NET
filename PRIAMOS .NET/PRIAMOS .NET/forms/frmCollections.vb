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
Public Event DetailTabStyle As EventHandler(Of DetailTabStyleEventArgs)
Public Class frmCollections

    Private sID As String, sbdgID As String, sinhID As String
    Private Level As Integer
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
    Private APTView As GridView
    Private INHView As GridView
    Private OwnerTenantView As GridView
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
        LoaderData()
        'TODO: This line of code loads data into the 'Priamos_NETDataSet2.vw_COLH' table. You can move, or remove it, as needed.
        Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet2.vw_COL_BDG' table. You can move, or remove it, as needed.
        Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_USR' table. You can move, or remove it, as needed.
        Me.Vw_USRTableAdapter.Fill(Me.Priamos_NETDataSet.vw_USR)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BANKS' table. You can move, or remove it, as needed.
        Me.Vw_BANKSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BANKS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COL_METHOD' table. You can move, or remove it, as needed.
        Me.Vw_COL_METHODTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COL_METHOD)


        AddHandler Rep_DEBITUSR.EditValueChanged, AddressOf Rep_DEBITUSR_Changed
        AddHandler Rep_COL_METHOD.EditValueChanged, AddressOf Rep_COL_METHOD_Changed
        AddHandler Rep_ΒΑΝΚ.EditValueChanged, AddressOf Rep_ΒΑΝΚ_Changed

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

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_APTCREDE_def.xml") Then
            GridView5.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_APTCREDE_def.xml", OptionsLayoutBase.FullLayout)
        End If

        GridView2.Columns.Item("dtCredit").OptionsColumn.AllowEdit = True
        GridView3.Columns.Item("dtCredit").OptionsColumn.AllowEdit = True
        GridView5.OptionsMenu.EnableFooterMenu = True
        GridView5.OptionsMenu.ShowConditionalFormattingItem = True
        GridView5.OptionsMenu.EnableGroupRowMenu = True
        GridView5.OptionsMenu.ShowGroupSummaryEditorItem = True
        GridView5.OptionsMenu.ShowAddNewSummaryItem = True
        GridView5.OptionsMenu.ShowSummaryItemMode = DefaultBoolean.True
        Level = 0
    End Sub


    Private Sub LoaderData()
        Dim strSql As String
        Dim Tbl As SqlDataAdapter
        Try
            ' Διαμερίσματα
            strSql = "SELECT   bdgID, aptID, ttl, sum(debit) as debit , sum(credit) as credit , sum(bal) as bal,sum(Aptbal) as Aptbal " &
                    "FROM  vw_COL 
                    group by bdgID, aptID, ttl"


            Tbl = New SqlDataAdapter(strSql, CNDB)
            Tbl.Fill(Priamos_NETDataSet2.COL_APT)
            Tbl.Dispose()

            ' Παραστατικά
            strSql = "Select   aptID, bdgID, inhID, completeDate, SUM(debit) As debit, SUM(credit) As credit, SUM(bal) As bal, " &
                     "debitusrID, dtDebit, dtCredit, bankID, ColMethodID,cmt  " &
                     "From vw_COL " &
                     "Group By aptID, BDGID, INHID, completeDate, debitusrID, dtDebit, dtCredit, bankID, ColMethodID,cmt "


            Tbl = New SqlDataAdapter(strSql, CNDB)
            Tbl.Fill(Priamos_NETDataSet2.COL_INH)
            Tbl.Dispose()

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub frmCollections_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue <> Nothing Then
            Me.Vw_COL_BDGTableAdapter.FillBy(Me.Priamos_NETDataSet2.vw_COL_BDG, System.Guid.Parse(cboBDG.EditValue.ToString))
            'Me.Vw_COLHTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COLH, System.Guid.Parse(cboBDG.EditValue.ToString))
            '    Me.Vw_INHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INH, System.Guid.Parse(cboBDG.EditValue.ToString))
        Else
            Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
            'Me.Vw_COLHTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COLH)
            '    Me.Vw_COLHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COLH)
            '    Me.Vw_INHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INH, System.Guid.Empty)
        End If
    End Sub

    Private Sub cmdExit_Click_1(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs)
        Try
            Dim sSQL As String, dtcredit As String, dtdebit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal


            If APTView.GetRowCellValue(APTView.FocusedRowHandle, "dtCredit") Is DBNull.Value Then
                dtcredit = "NULL"
            Else
                dtcredit = toSQLValueS(CDate(APTView.GetRowCellValue(APTView.FocusedRowHandle, "dtCredit")).ToString("yyyyMMdd"))

            End If

            If APTView.GetRowCellValue(APTView.FocusedRowHandle, "dtDebit") Is DBNull.Value Then
                dtdebit = "NULL"
            Else
                dtdebit = toSQLValueS(CDate(APTView.GetRowCellValue(APTView.FocusedRowHandle, "dtDebit")).ToString("yyyyMMdd"))
            End If
            If APTView.GetRowCellValue(APTView.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If APTView.GetRowCellValue(APTView.FocusedRowHandle, "debit") Is DBNull.Value Then
                debit = 0
            Else
                debit = APTView.GetRowCellValue(APTView.FocusedRowHandle, "debit")
            End If
            If APTView.GetRowCellValue(APTView.FocusedRowHandle, "credit") Is DBNull.Value Then
                credit = 0
            Else
                credit = APTView.GetRowCellValue(APTView.FocusedRowHandle, "credit")
            End If
            If APTView.GetRowCellValue(APTView.FocusedRowHandle, "bal") Is DBNull.Value Then
                bal = 0
            Else
                bal = APTView.GetRowCellValue(APTView.FocusedRowHandle, "bal")
            End If

            Select Case e.Column.FieldName
                Case "credit"
                    bal = debit - credit
                    dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
                    sSQL = "UPDATE [COL] SET dtcredit  = " & dtcredit & ",dtdebit  = " & dtdebit &
                            ",credit = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "credit"), True) &
                            ",creditusrID  = " & toSQLValueS(UserProps.ID.ToString) &
                            ",bal = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bal"), True) &
                            " WHERE ID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ID").ToString)

                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                    APTView.SetRowCellValue(APTView.FocusedRowHandle, "bal", bal)
                    APTView.SetRowCellValue(APTView.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))
                    APTView.SetRowCellValue(APTView.FocusedRowHandle, "creditusrID", System.Guid.Parse(UserProps.ID.ToString))
                    ' Ενημέρωση Header Είσπραξης
                    Using oCmd As New SqlCommand("COL_Calculate", CNDB)
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.Parameters.AddWithValue("@colHid", APTView.GetRowCellValue(APTView.FocusedRowHandle, "colHID").ToString.ToUpper)
                        oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID.ToString.ToUpper)
                        oCmd.ExecuteNonQuery()
                    End Using
                Case "ColMethodID"
                    sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ColMethodID").ToString) &
                            " WHERE ID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                Case "bankID"
                    sSQL = "UPDATE [COL] SET bankID  = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bankID").ToString) &
                            " WHERE ID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using

            End Select
            'Me.Vw_COLHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COLH)

            '    sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ColMethodID").ToString) &
            '        ",bankID  = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bankID").ToString) &
            '        ",debitusrID  = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "debitusrID").ToString) &
            '        ",creditusrID  = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "creditusrID").ToString) &
            '        ",dtcredit  = " & dtcredit &
            '        ",dtdebit  = " & dtdebit &
            '        ",credit = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "credit"), True) &
            '        ",bal = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bal"), True) &
            '" WHERE ID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ID").ToString)

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RepositoryCOL_METHOD_ButtonPressed(sender As Object, e As ButtonPressedEventArgs)
        Select Case e.Button.Index
            Case 1 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "ColMethodID", "")
        End Select
    End Sub

    Private Sub RepositoryBANK_ButtonPressed(sender As Object, e As ButtonPressedEventArgs)
        Select Case e.Button.Index
            Case 1 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "bankID", "")
        End Select
    End Sub

    Private Sub cboINH_EditValueChanged(sender As Object, e As EventArgs)
        'If cboINH.EditValue = Nothing Then
        '    Me.Vw_COLHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COLH)
        'Else
        '    Me.Vw_COLHTableAdapter.FillByINH(Me.Priamos_NETDataSet.vw_COLH, System.Guid.Parse(cboINH.EditValue.ToString))
        'End If

    End Sub

    'Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
    '    Dim sSQL As String
    '    Dim I As Integer
    '    Dim sDebitUsr As String
    '    Dim dtdebit As String
    '    For I = 0 To APTView.SelectedRowsCount - 1
    '        If cboDebitUsr.Text = "" Then sDebitUsr = "NULL" Else sDebitUsr = toSQLValueS(cboDebitUsr.EditValue.ToString)
    '        dtdebit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
    '        'If GridView5.GetRowCellValue(GridView5.GetSelectedRows(I), "debitusrID").ToString = GridView5.GetRowCellValue(GridView5.GetSelectedRows(I), "creditusrID").ToString Then
    '        If APTView.GetRowCellValue(APTView.GetSelectedRows(I), "dtCredit") Is DBNull.Value Then
    '            sSQL = "UPDATE COL SET DEBITUSRID = " & sDebitUsr &
    '                 ",CREDITUSRID = " & toSQLValueS(UserProps.ID.ToString) &
    '                 ",dtDebit= " & dtdebit &
    '                " WHERE ID = " & toSQLValueS(APTView.GetRowCellValue(APTView.GetSelectedRows(I), "ID").ToString)
    '            Using oCmd As New SqlCommand(sSQL, CNDB)
    '                oCmd.ExecuteNonQuery()
    '            End Using
    '            APTView.SetRowCellValue(APTView.GetSelectedRows(I), "debitusrID", System.Guid.Parse(sDebitUsr.Replace("'", "")))
    '            APTView.SetRowCellValue(APTView.GetSelectedRows(I), "creditsrID", System.Guid.Parse(sDebitUsr.Replace("'", "")))
    '        End If
    '        'End If
    '    Next

    '    If OwnersView IsNot Nothing Then
    '        For I = 0 To OwnersView.SelectedRowsCount - 1
    '            If cboDebitUsr.Text = "" Then sDebitUsr = "NULL" Else sDebitUsr = toSQLValueS(cboDebitUsr.EditValue.ToString)
    '            dtdebit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
    '            If OwnersView.GetRowCellValue(OwnersView.GetSelectedRows(I), "dtCredit") Is DBNull.Value Then
    '                sSQL = "UPDATE COL SET DEBITUSRID = " & sDebitUsr &
    '                 ",CREDITUSRID = " & toSQLValueS(UserProps.ID.ToString) &
    '                 ",dtDebit= " & dtdebit &
    '                " WHERE ID = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.GetSelectedRows(I), "ID").ToString)
    '                Using oCmd As New SqlCommand(sSQL, CNDB)
    '                    oCmd.ExecuteNonQuery()
    '                End Using
    '                OwnersView.SetRowCellValue(OwnersView.GetSelectedRows(I), "debitusrID", System.Guid.Parse(sDebitUsr.Replace("'", "")))
    '                OwnersView.SetRowCellValue(OwnersView.GetSelectedRows(I), "creditsrID", System.Guid.Parse(sDebitUsr.Replace("'", "")))
    '            End If
    '            'End If
    '        Next
    '    End If

    '    If cboBDG.EditValue <> Nothing Then
    '        Me.Vw_COLHTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_COLH, System.Guid.Parse(cboBDG.EditValue.ToString))
    '        Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_COL, System.Guid.Parse(cboBDG.EditValue.ToString))
    '    End If
    '    If cboINH.EditValue <> Nothing Then
    '        Me.Vw_COLHTableAdapter.FillByINH(Me.Priamos_NETDataSet.vw_COLH, System.Guid.Parse(cboINH.EditValue.ToString))
    '        Me.Vw_COLTableAdapter.FillByINH(Me.Priamos_NETDataSet.vw_COL, System.Guid.Parse(cboINH.EditValue.ToString))
    '    End If

    'End Sub

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
    Private Sub GridView5_ShowingEditor(sender As Object, e As CancelEventArgs)
        'If APTView.GetRowCellValue(APTView.FocusedRowHandle, "debitusrID").ToString <> APTView.GetRowCellValue(APTView.FocusedRowHandle, "creditusrID").ToString Or
        '    (APTView.GetRowCellValue(APTView.FocusedRowHandle, "debitusrID").ToString = "" And APTView.GetRowCellValue(APTView.FocusedRowHandle, "creditusrID").ToString = "") Then
        '    e.Cancel = True
        'Else
        '    '   GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))

        'End If
        'If APTView.GetRowCellValue(APTView.FocusedRowHandle, "debitusrID").ToString <> UserProps.ID.ToString Then
        '    e.Cancel = True
        'Else
        '   GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))

        'End If
    End Sub

    'Μετονομασία Στήλης Master
    Private Sub OnEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView5.Columns(item.Tag).Caption = item.EditValue
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
        GridView5.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
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
        GridView5.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_APTCREDE_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    'Εκτύπωση Όψης
    Private Sub OnPrintView(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView5.GridControl.ShowRibbonPrintPreview()
    End Sub

    Private Sub RepositoryUSRCredit_ButtonPressed(sender As Object, e As ButtonPressedEventArgs)
        Select Case e.Button.Index
            Case 1 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "creditusrID", "")
        End Select
    End Sub

    Private Sub RepositoryUSRDebit_ButtonPressed(sender As Object, e As ButtonPressedEventArgs)
        Select Case e.Button.Index
            Case 1 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "debitusrID", "")
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
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub GridView2_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles GridView2.MasterRowExpanded
        Dim INHView2 = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        INHView = INHView2.GetDetailView(e.RowHandle, e.RelationIndex)

        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_INH_def.xml") = False Then
            INHView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_INH_def.xml", OptionsLayoutBase.FullLayout)
        End If
        INHView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_INH_def.xml", OptionsLayoutBase.FullLayout)
        INHView.Columns.Item("dtCredit").OptionsColumn.AllowEdit = True
        Level = 2
    End Sub

    Private Sub cboINH_ButtonPressed(sender As Object, e As ButtonPressedEventArgs)
        Select Case e.Button.Index
            Case 1 : If cboINH.EditValue <> Nothing Then ManageINH(cboINH)
            Case 2 : cboINH.EditValue = Nothing
            Case 3
        End Select
    End Sub
    Friend Sub Rep_DEBITUSR_Changed(sender As Object, e As EventArgs)

        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim debitUsrID As String = toSQLValueS(editor.GetColumnValue("ID").ToString)
            'debitUsrName = editor.GetColumnValue("RealName").ToString()
            UpdateCOLS(0, debitUsrID)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Friend Sub Rep_COL_METHOD_Changed(sender As Object, e As EventArgs)

        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim colMethodID As String = toSQLValueS(editor.EditValue.ToString)
            'debitUsrName = editor.GetColumnValue("RealName").ToString()
            UpdateCOLS(1, colMethodID)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Friend Sub Rep_ΒΑΝΚ_Changed(sender As Object, e As EventArgs)

        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim bankID As String = toSQLValueS(editor.EditValue.ToString)
            'debitUsrName = editor.GetColumnValue("RealName").ToString()
            UpdateCOLS(2, bankID)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UpdateCOLS(ByVal mode As Byte, ByVal sField As String)
        Dim dtdebit As String
        Dim sSQL As String
        Try
            Select Case mode
                Case 0
                    If sField Is DBNull.Value Or sField = "NULL" Then
                        dtdebit = "NULL"
                    Else
                        dtdebit = toSQLValueS(CDate(Date.Now).ToString("yyyyMMdd"))
                    End If
            End Select

            Select Case GridControl2.FocusedView.Name
                Case "GridView1"
                    sSQL = "UPDATE [COL] SET debitusrID  = " & sField & ",dtdebit  = " & dtdebit &
                           " WHERE bdgID = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bdgID").ToString)
                Case "GridView2"
                    Select Case mode
                        Case 0
                            sSQL = "UPDATE [COL] SET debitusrID  = " & sField & ",dtdebit  = " & dtdebit &
                                   " WHERE bdgID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString) &
                                   " and aptID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "aptID").ToString)
                        Case 1
                            sSQL = "UPDATE [COL] SET colMethodID  = " & sField &
                                   " WHERE bdgID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString) &
                                   " and aptID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "aptID").ToString)
                        Case 2
                            sSQL = "UPDATE [COL] SET bankID  = " & sField &
                                   " WHERE bdgID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString) &
                                   " and aptID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "aptID").ToString)
                    End Select
                Case "GridView3"
                    Select Case mode
                        Case 0
                            sSQL = "UPDATE [COL] SET debitusrID  = " & sField & ",dtdebit  = " & dtdebit &
                                   " WHERE bdgID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString) &
                                   " and aptID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "aptID").ToString) &
                                   " and inhID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "inhID").ToString)
                        Case 1
                            sSQL = "UPDATE [COL] SET colMethodID  = " & sField &
                                   " WHERE bdgID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString) &
                                   " and aptID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "aptID").ToString) &
                                   " and inhID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "inhID").ToString)
                        Case 2
                            sSQL = "UPDATE [COL] SET bankID  = " & sField &
                                   " WHERE bdgID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString) &
                                   " and aptID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "aptID").ToString) &
                                   " and inhID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "inhID").ToString)
                    End Select
                Case "GridView4"
                    sSQL = "UPDATE [COL] SET debitusrID  = " & sField & ",dtdebit  = " & dtdebit &
                           " WHERE ID = " & toSQLValueS(OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "ID").ToString)
            End Select
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            LoaderData()
            Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL)

            Select Case GridControl2.FocusedView.Name
                Case "GridView1" : GridView1.SetMasterRowExpanded(0, True)
                Case "GridView2" : APTView.SetMasterRowExpanded(0, True)
                Case "GridView3" : INHView.SetMasterRowExpanded(0, True)
                Case "GridView4"
            End Select
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Rep_DEBITUSR_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles Rep_DEBITUSR.ButtonPressed
        Select Case e.Button.Index
            Case 1 : GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "debitusrID", "") : UpdateCOLS(0, "NULL")
        End Select
    End Sub
    'Function που ελέγχει αν ο χρήστης χρέωσης στα παραστατικά είναι μοναδικός
    Private Function IsDebitUserUnique(ByVal GrdView As GridView, Optional ByRef dbusrID As String = "") As Boolean
        Dim i As Integer
        Dim Row As DataRow
        Dim debitusrID As String, tmpdebitusrID As String
        Try
            For i = 0 To GrdView.DataRowCount - 1
                Row = GrdView.GetDataRow(i)
                tmpdebitusrID = Row.Item("debitusrID").ToString
                If tmpdebitusrID <> debitusrID Then
                    If debitusrID <> "" Then Return False Else debitusrID = tmpdebitusrID
                End If
            Next
            dbusrID = debitusrID
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    'Function που ελέγχει αν δεν υπάρχει κανένας χρήστης χρέωσης στα παραστατικά
    Private Function IsDebitUserEmpty(ByVal GrdView As GridView) As Boolean
        Dim i As Integer
        Dim Row As DataRow
        Dim debitusrID As String
        Try
            For i = 0 To GrdView.DataRowCount - 1
                Row = GrdView.GetDataRow(i)
                debitusrID = Row.Item("debitusrID").ToString
                If debitusrID <> "" Then Return False
            Next
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        'Try
        '    Dim sSQL As String, dtcredit As String, dtdebit As String
        '    Dim credit As Decimal, debit As Decimal, bal As Decimal
        '    Dim debitUsrID As String

        '    '1st Level
        '    Select Case e.Column.FieldName
        '        Case "debitusrIDs"

        '            debitUsrID = toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "debitusrID").ToString)
        '            sSQL = "UPDATE [COL] SET debitusrID  = " & debitUsrID &
        '                    " WHERE bdgID = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bdgID").ToString)
        '            Using oCmd As New SqlCommand(sSQL, CNDB)
        '                oCmd.ExecuteNonQuery()
        '            End Using
        '            Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
        '            Me.Vw_COL_APTTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_APT)
        '            Me.Vw_COL_INHTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_INH)
        '            Me.Vw_COLTableAdapter3.Fill(Me.Priamos_NETDataSet2.vw_COL)
        '    End Select


        'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "dtCredit") Is DBNull.Value Then
        '    dtcredit = "NULL"
        'Else
        '    dtcredit = toSQLValueS(CDate(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "dtCredit")).ToString("yyyyMMdd"))

        'End If

        'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "dtDebit") Is DBNull.Value Then
        '    dtdebit = "NULL"
        'Else
        '    dtdebit = toSQLValueS(CDate(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "dtDebit")).ToString("yyyyMMdd"))
        'End If
        'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID") = Nothing Then Exit Sub
        'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "debit") Is DBNull.Value Then
        '    debit = 0
        'Else
        '    debit = OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "debit")
        'End If
        'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "credit") Is DBNull.Value Then
        '    credit = 0
        'Else
        '    credit = OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "credit")
        'End If
        'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bal") Is DBNull.Value Then
        '    bal = 0
        'Else
        '    bal = OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bal")
        'End If

        'Select Case e.Column.FieldName
        '    Case "credit"
        '        bal = debit - credit
        '        dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
        '        sSQL = "UPDATE [COL] SET dtcredit  = " & dtcredit & ",dtdebit  = " & dtdebit &
        '                ",credit = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "credit"), True) &
        '                ",creditusrID  = " & toSQLValueS(UserProps.ID.ToString) &
        '                ",bal = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bal"), True) &
        '                " WHERE ID = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID").ToString)

        '        Using oCmd As New SqlCommand(sSQL, CNDB)
        '            oCmd.ExecuteNonQuery()
        '        End Using
        '        OwnersView.SetRowCellValue(OwnersView.FocusedRowHandle, "bal", bal)
        '        OwnersView.SetRowCellValue(OwnersView.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))
        '        OwnersView.SetRowCellValue(OwnersView.FocusedRowHandle, "creditusrID", System.Guid.Parse(UserProps.ID.ToString))
        '        ' Ενημέρωση Header Είσπραξης
        '        Using oCmd As New SqlCommand("COL_Calculate", CNDB)
        '            oCmd.CommandType = CommandType.StoredProcedure
        '            oCmd.Parameters.AddWithValue("@colHid", OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "colHID").ToString.ToUpper)
        '            oCmd.ExecuteNonQuery()
        '        End Using
        '    Case "ColMethodID"
        '        sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ColMethodID").ToString) &
        '                " WHERE ID = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID").ToString)
        '        Using oCmd As New SqlCommand(sSQL, CNDB)
        '            oCmd.ExecuteNonQuery()
        '        End Using
        '    Case "bankID"
        '        sSQL = "UPDATE [COL] SET bankID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bankID").ToString) &
        '                " WHERE ID = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID").ToString)
        '        Using oCmd As New SqlCommand(sSQL, CNDB)
        '            oCmd.ExecuteNonQuery()
        '        End Using

        'End Select


        '    sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ColMethodID").ToString) &
        '        ",bankID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bankID").ToString) &
        '        ",debitusrID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "debitusrID").ToString) &
        '        ",creditusrID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "creditusrID").ToString) &
        '        ",dtcredit  = " & dtcredit &
        '        ",dtdebit  = " & dtdebit &
        '        ",credit = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "credit"), True) &
        '        ",bal = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bal"), True) &
        '" WHERE ID = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID").ToString)

        'Catch ex As Exception
        '    XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub GridView5_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs)
        Dim view = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        INHView = view.GetDetailView(e.RowHandle, e.RelationIndex)
        If INHView Is Nothing Then Exit Sub
        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_OWNERS_def.xml") = False Then
            INHView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_OWNERS_def.xml", OptionsLayoutBase.FullLayout)
        End If
        INHView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_OWNERS_def.xml", OptionsLayoutBase.FullLayout)
        INHView.Columns.Item("dtCredit").OptionsColumn.AllowEdit = True

    End Sub

    'Private Sub GridView1_ShowingEditor(sender As Object, e As CancelEventArgs)
    '    'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "debitusrID").ToString <> OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "creditusrID").ToString Or
    '    '    (OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "debitusrID").ToString = "" And OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "creditusrID").ToString = "") Then
    '    '    e.Cancel = True
    '    'Else
    '    '    '   GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))

    '    'End If
    '    If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "debitusrID").ToString <> UserProps.ID.ToString Then
    '        e.Cancel = True
    '    Else
    '        '   GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))

    '    End If
    'End Sub

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
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChangedO, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex

                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItemO("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChangedO, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveViewO, Nothing, Nothing, Nothing, Nothing))

            End If
        End If
    End Sub
    'Μετονομασία Στήλης Master
    Private Sub OnEditValueChangedO(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        INHView.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Function CreateCheckItemO(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClickO))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChangedO(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        INHView.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Κλείδωμα Στήλης Master
    Private Sub OnCanMoveItemClickO(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    'Αποθήκευση όψης 
    Private Sub OnSaveViewO(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        INHView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_OWNERS_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub GridView1_DetailTabStyle(sender As Object, e As DetailTabStyleEventArgs) Handles GridView1.DetailTabStyle
        e.Appearance.Header.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        e.Appearance.Header.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        e.ImageOptions.SvgImage = SvgImageCollection1("bo_address")
    End Sub

    Private Sub GridView2_DetailTabStyle(sender As Object, e As DetailTabStyleEventArgs) Handles GridView2.DetailTabStyle
        e.Appearance.Header.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        e.Appearance.Header.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        e.ImageOptions.SvgImage = SvgImageCollection1("bo_invoice")
    End Sub

    Private Sub GridView3_DetailTabStyle(sender As Object, e As DetailTabStyleEventArgs) Handles GridView3.DetailTabStyle
        e.Appearance.Header.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        e.Appearance.Header.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        e.ImageOptions.SvgImage = SvgImageCollection1("bo_employee")
    End Sub



    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged

    End Sub

    Private Sub GridView1_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles GridView1.MasterRowExpanded
        Dim APTView2 = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        APTView = APTView2.GetDetailView(e.RowHandle, e.RelationIndex)

        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_APT_def.xml") = False Then
            APTView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_APT_def.xml", OptionsLayoutBase.FullLayout)
        End If
        APTView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_APT_def.xml", OptionsLayoutBase.FullLayout)
        Level = 1
    End Sub



    Private Sub GridView3_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles GridView3.MasterRowExpanded
        Dim OwnerTenantView2 = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        OwnerTenantView = OwnerTenantView2.GetDetailView(e.RowHandle, e.RelationIndex)

        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_OW_TEN_def.xml") = False Then
            OwnerTenantView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_OW_TEN_def.xml", OptionsLayoutBase.FullLayout)
        End If
        OwnerTenantView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_OW_TEN_def.xml", OptionsLayoutBase.FullLayout)
        OwnerTenantView.Columns.Item("dtCredit").OptionsColumn.AllowEdit = True
        Level = 3
    End Sub

    Private Sub GridView3_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView3.CellValueChanged
        'Try
        '    Dim sSQL As String, dtcredit As String, dtdebit As String
        '    Dim credit As Decimal, debit As Decimal, bal As Decimal
        '    Dim debitUsrID As String

        '    '2st Level
        '    Select Case e.Column.FieldName
        '        Case "debitusrID"
        '            debitUsrID = toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "debitusrID").ToString)
        '            sSQL = "UPDATE [COL] SET debitusrID  = " & debitUsrID &
        '                    " WHERE bdgID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString) &
        '                    " and aptID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "aptID").ToString)
        '            Using oCmd As New SqlCommand(sSQL, CNDB)
        '                oCmd.ExecuteNonQuery()
        '            End Using
        '            Me.Vw_COL_APTTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_APT)
        '            Me.Vw_COL_INHTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_INH)
        '            Me.Vw_COLTableAdapter3.Fill(Me.Priamos_NETDataSet2.vw_COL)
        '    End Select

        'Catch ex As Exception
        '    XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub GridView4_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView4.CellValueChanged
        Try
            Dim sSQL As String, dtcredit As String, dtdebit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal
            Dim debitUsrID As String

            '    '1st Level
            '    Select Case e.Column.FieldName
            '        Case "debitusrIDs"

            '            debitUsrID = toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "debitusrID").ToString)
            '            sSQL = "UPDATE [COL] SET debitusrID  = " & debitUsrID &
            '                    " WHERE bdgID = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bdgID").ToString)
            '            Using oCmd As New SqlCommand(sSQL, CNDB)
            '                oCmd.ExecuteNonQuery()
            '            End Using
            '            Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
            '            Me.Vw_COL_APTTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_APT)
            '            Me.Vw_COL_INHTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_INH)
            '            Me.Vw_COLTableAdapter3.Fill(Me.Priamos_NETDataSet2.vw_COL)
            '    End Select


            'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "dtCredit") Is DBNull.Value Then
            '    dtcredit = "NULL"
            'Else
            '    dtcredit = toSQLValueS(CDate(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "dtCredit")).ToString("yyyyMMdd"))

            'End If

            'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "dtDebit") Is DBNull.Value Then
            '    dtdebit = "NULL"
            'Else
            '    dtdebit = toSQLValueS(CDate(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "dtDebit")).ToString("yyyyMMdd"))
            'End If
            'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "debit") Is DBNull.Value Then
            '    debit = 0
            'Else
            '    debit = OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "debit")
            'End If
            'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "credit") Is DBNull.Value Then
            '    credit = 0
            'Else
            '    credit = OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "credit")
            'End If
            'If OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bal") Is DBNull.Value Then
            '    bal = 0
            'Else
            '    bal = OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bal")
            'End If

            'Select Case e.Column.FieldName
            '    Case "credit"
            '        bal = debit - credit
            '        dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
            '        sSQL = "UPDATE [COL] SET dtcredit  = " & dtcredit & ",dtdebit  = " & dtdebit &
            '                ",credit = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "credit"), True) &
            '                ",creditusrID  = " & toSQLValueS(UserProps.ID.ToString) &
            '                ",bal = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bal"), True) &
            '                " WHERE ID = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID").ToString)

            '        Using oCmd As New SqlCommand(sSQL, CNDB)
            '            oCmd.ExecuteNonQuery()
            '        End Using
            '        OwnersView.SetRowCellValue(OwnersView.FocusedRowHandle, "bal", bal)
            '        OwnersView.SetRowCellValue(OwnersView.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))
            '        OwnersView.SetRowCellValue(OwnersView.FocusedRowHandle, "creditusrID", System.Guid.Parse(UserProps.ID.ToString))
            '        ' Ενημέρωση Header Είσπραξης
            '        Using oCmd As New SqlCommand("COL_Calculate", CNDB)
            '            oCmd.CommandType = CommandType.StoredProcedure
            '            oCmd.Parameters.AddWithValue("@colHid", OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "colHID").ToString.ToUpper)
            '            oCmd.ExecuteNonQuery()
            '        End Using
            '    Case "ColMethodID"
            '        sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ColMethodID").ToString) &
            '                " WHERE ID = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID").ToString)
            '        Using oCmd As New SqlCommand(sSQL, CNDB)
            '            oCmd.ExecuteNonQuery()
            '        End Using
            '    Case "bankID"
            '        sSQL = "UPDATE [COL] SET bankID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bankID").ToString) &
            '                " WHERE ID = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID").ToString)
            '        Using oCmd As New SqlCommand(sSQL, CNDB)
            '            oCmd.ExecuteNonQuery()
            '        End Using

            'End Select


            '    sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ColMethodID").ToString) &
            '        ",bankID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bankID").ToString) &
            '        ",debitusrID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "debitusrID").ToString) &
            '        ",creditusrID  = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "creditusrID").ToString) &
            '        ",dtcredit  = " & dtcredit &
            '        ",dtdebit  = " & dtdebit &
            '        ",credit = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "credit"), True) &
            '        ",bal = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "bal"), True) &
            '" WHERE ID = " & toSQLValueS(OwnersView.GetRowCellValue(OwnersView.FocusedRowHandle, "ID").ToString)

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If IsNothing(e.Value) Then e.DisplayText = "*******"
    End Sub

    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles GridView2.CustomColumnDisplayText
        If IsNothing(e.Value) Then e.DisplayText = "*******"
    End Sub

    Private Sub GridView2_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView2.ValidatingEditor
        Try
            Dim sSQL As String, dtcredit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal
            Dim debitusrID As String
            'Κολπάκι ώστε να πάρουμε το view των παραστατικών. Ανοιγοκλείνουμε χωρις να το παίρνει χαμπάρι ο χρήστης το Detail
            APTView.SetMasterRowExpanded(APTView.FocusedRowHandle, True)
            If APTView.FocusedColumn.FieldName = "credit" And IsDebitUserUnique(INHView, debitusrID) = False Then
                'XtraMessageBox.Show("Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.ErrorText = "Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                APTView.SetMasterRowExpanded(APTView.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            ElseIf APTView.FocusedColumn.FieldName = "credit" And IsDebitUserEmpty(INHView) = True Then
                'XtraMessageBox.Show("Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.ErrorText = "Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                APTView.SetRowCellValue(APTView.FocusedRowHandle, "credit", 0)
                APTView.SetMasterRowExpanded(APTView.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            End If

            If debitusrID = "" Then
                e.ErrorText = "Δεν έχετε επιλέξει χρήστη χρέωσης "
                e.Valid = False
                Exit Sub
            End If

            If APTView.FocusedColumn.FieldName = "credit" Then
                If APTView.GetRowCellValue(APTView.FocusedRowHandle, "debit") Is DBNull.Value Then
                    debit = 0
                Else
                    debit = APTView.GetRowCellValue(APTView.FocusedRowHandle, "debit")
                End If
                credit = Decimal.Parse(e.Value)

                If APTView.GetRowCellValue(APTView.FocusedRowHandle, "bal") Is DBNull.Value Then
                    bal = 0
                Else
                    bal = APTView.GetRowCellValue(APTView.FocusedRowHandle, "bal")
                End If

                bal = Math.Abs(debit) - credit
                dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
                Using oCmd As New SqlCommand("col_Calculate", CNDB)
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.Parameters.AddWithValue("@debitusrID", APTView.GetRowCellValue(APTView.FocusedRowHandle, "debitusrID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@bdgID", APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@aptID", APTView.GetRowCellValue(APTView.FocusedRowHandle, "aptID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@inhID", Guid.Empty)
                    oCmd.Parameters.AddWithValue("@Givencredit", credit)
                    oCmd.ExecuteNonQuery()
                End Using


                'sSQL = "UPDATE [COL] SET dtcredit  = " & dtcredit &
                '        ",credit = " & toSQLValueS(credit, True) &
                '        ",creditusrID  = " & toSQLValueS(UserProps.ID.ToString) &
                '        ",bal = " & toSQLValueS(bal, True) &
                '        " WHERE aptID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "aptID").ToString) &
                '        " and  bdgID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString)

                'Using oCmd As New SqlCommand(sSQL, CNDB)
                '    oCmd.ExecuteNonQuery()
                'End Using
                'APTView.SetRowCellValue(APTView.FocusedRowHandle, "bal", bal)
                'APTView.SetRowCellValue(APTView.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))
                'APTView.SetRowCellValue(APTView.FocusedRowHandle, "creditusrID", System.Guid.Parse(UserProps.ID.ToString))
                LoaderData()
                Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView3.ValidatingEditor
        Try
            Dim sSQL As String, dtcredit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal
            'Κολπάκι ώστε να πάρουμε το view των παραστατικών. Ανοιγοκλείνουμε χωρις να το παίρνει χαμπάρι ο χρήστης το Detail
            INHView.SetMasterRowExpanded(INHView.FocusedRowHandle, True)
            If INHView.FocusedColumn.FieldName = "debit" And IsDebitUserUnique(INHView) = False Then
                'XtraMessageBox.Show("Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.ErrorText = "Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                INHView.SetMasterRowExpanded(INHView.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
                'ElseIf INHView.FocusedColumn.FieldName = "debit" And IsDebitUserEmpty(INHView) = True Then
            ElseIf IsDebitUserEmpty(INHView) = True Then
                'XtraMessageBox.Show("Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.ErrorText = "Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                If INHView.FocusedColumn.FieldName = "credit" Then
                    INHView.SetRowCellValue(INHView.FocusedRowHandle, "credit", 0)
                    APTView.SetRowCellValue(APTView.FocusedRowHandle, "credit", 0)
                ElseIf INHView.FocusedColumn.FieldName = "bankID" Then
                    INHView.SetRowCellValue(INHView.FocusedRowHandle, "bankID", DBNull.Value)
                ElseIf INHView.FocusedColumn.FieldName = "ColMethodID" Then
                    INHView.SetRowCellValue(INHView.FocusedRowHandle, "ColMethodID", DBNull.Value)
                ElseIf INHView.FocusedColumn.FieldName = "dtCredit" Then
                    INHView.SetRowCellValue(INHView.FocusedRowHandle, "dtCredit", DBNull.Value)
                End If
                INHView.SetMasterRowExpanded(INHView.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            End If
            If INHView.FocusedColumn.FieldName = "credit" Or INHView.FocusedColumn.FieldName = "ColMethodID" Or INHView.FocusedColumn.FieldName = "bankID" Then
                If INHView.GetRowCellValue(INHView.FocusedRowHandle, "debit") Is DBNull.Value Then
                    debit = 0
                Else
                    debit = INHView.GetRowCellValue(INHView.FocusedRowHandle, "debit")
                End If
                If INHView.FocusedColumn.FieldName = "credit" Then
                    credit = e.Value
                Else
                    If INHView.GetRowCellValue(INHView.FocusedRowHandle, "credit") Is DBNull.Value Then
                        credit = 0
                    Else
                        credit = INHView.GetRowCellValue(INHView.FocusedRowHandle, "credit")
                    End If

                End If
                If INHView.GetRowCellValue(INHView.FocusedRowHandle, "bal") Is DBNull.Value Then
                    bal = 0
                Else
                    bal = INHView.GetRowCellValue(INHView.FocusedRowHandle, "bal")
                End If
                bal = Math.Abs(debit) - credit
                dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
                Using oCmd As New SqlCommand("col_Calculate", CNDB)
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.Parameters.AddWithValue("@debitusrID", INHView.GetRowCellValue(INHView.FocusedRowHandle, "debitusrID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@bdgID", INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@aptID", INHView.GetRowCellValue(INHView.FocusedRowHandle, "aptID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@inhID", INHView.GetRowCellValue(INHView.FocusedRowHandle, "inhID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@Givencredit", credit)
                    oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID.ToString.ToUpper)
                    oCmd.ExecuteNonQuery()
                End Using

                sSQL = "UPDATE [COL] SET 
                        cmt  = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "cmt").ToString) &
                        ",ColMethodID  = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "ColMethodID").ToString) &
                        ",bankID  = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bankID").ToString) &
                        " WHERE aptID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "aptID").ToString) &
                        " and  bdgID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString) &
                        " and  inhID = " & toSQLValueS(INHView.GetRowCellValue(INHView.FocusedRowHandle, "inhID").ToString)

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                'INHView.SetRowCellValue(INHView.FocusedRowHandle, "bal", bal)
                '    INHView.SetRowCellValue(INHView.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))
                'INHView.SetRowCellValue(INHView.FocusedRowHandle, "creditusrID", System.Guid.Parse(UserProps.ID.ToString))
                LoaderData()
                Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL)

            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Rep_Credit_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles Rep_Credit.ButtonPressed
        Try
            Dim GRD As GridView = GridControl2.FocusedView
            Select Case GRD.Name
                Case "GridView2" ' Διαμερίσματα
                    Select Case e.Button.Index
                        Case 0 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "credit", APTView.GetRowCellValue(APTView.FocusedRowHandle, "debit"))
                        Case 1 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "credit", 0)
                    End Select
                    APTView.ValidateEditor()
                Case "GridView3" ' Παραστατικα
                    Select Case e.Button.Index
                        Case 0 : INHView.SetRowCellValue(INHView.FocusedRowHandle, "credit", INHView.GetRowCellValue(INHView.FocusedRowHandle, "debit"))
                        Case 1 : INHView.SetRowCellValue(INHView.FocusedRowHandle, "credit", 0)
                    End Select
                    INHView.ValidateEditor()
                Case "GridView4" ' Ένοικος/Ιδιοκτήτης
                    Select Case e.Button.Index
                        Case 0 : OwnerTenantView.SetRowCellValue(OwnerTenantView.FocusedRowHandle, "credit", OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "debit"))
                        Case 1 : OwnerTenantView.SetRowCellValue(OwnerTenantView.FocusedRowHandle, "credit", 0)
                    End Select
                    OwnerTenantView.ValidateEditor()
            End Select

        Catch ex As Exception
            If ex.HResult <> -2146233088 Then XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GridView5_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView5.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()
            Dim itemSaveView As New DXEditMenuItem()

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
                menu.Items.Add(New DXMenuItem("Εκτύπωση όψης", AddressOf OnPrintView, Nothing, Nothing, Nothing, Nothing))


                '5nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveView, Nothing, Nothing, Nothing, Nothing))
            End If

        End If
    End Sub

    Private Sub GridView4_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView4.ValidatingEditor
        Try
            Dim sSQL As String, dtcredit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal
            'Κολπάκι ώστε να πάρουμε το view των παραστατικών. Ανοιγοκλείνουμε χωρις να το παίρνει χαμπάρι ο χρήστης το Detail
            OwnerTenantView.SetMasterRowExpanded(OwnerTenantView.FocusedRowHandle, True)
            If OwnerTenantView.FocusedColumn.FieldName = "credit" And IsDebitUserUnique(OwnerTenantView) = False Then
                'XtraMessageBox.Show("Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.ErrorText = "Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                OwnerTenantView.SetMasterRowExpanded(OwnerTenantView.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            ElseIf OwnerTenantView.FocusedColumn.FieldName = "credit" And IsDebitUserEmpty(OwnerTenantView) = True Then
                'XtraMessageBox.Show("Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.ErrorText = "Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                OwnerTenantView.SetRowCellValue(OwnerTenantView.FocusedRowHandle, "credit", 0)
                APTView.SetRowCellValue(APTView.FocusedRowHandle, "credit", 0)
                INHView.SetRowCellValue(INHView.FocusedRowHandle, "credit", 0)
                OwnerTenantView.SetMasterRowExpanded(OwnerTenantView.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            End If
            If OwnerTenantView.FocusedColumn.FieldName = "credit" Or OwnerTenantView.FocusedColumn.FieldName = "ColMethodID" Or OwnerTenantView.FocusedColumn.FieldName = "bankID" Then
                If OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "debit") Is DBNull.Value Then
                    debit = 0
                Else
                    debit = OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "debit")
                End If
                If OwnerTenantView.FocusedColumn.FieldName = "credit" Then
                    credit = e.Value
                Else
                    If OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "credit") Is DBNull.Value Then
                        credit = 0
                    Else
                        credit = OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "credit")
                    End If

                End If
                If OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "bal") Is DBNull.Value Then
                    bal = 0
                Else
                    bal = OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "bal")
                End If
                bal = Math.Abs(debit) - credit
                dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
                Using oCmd As New SqlCommand("col_Calculate", CNDB)
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.Parameters.AddWithValue("@debitusrID", OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "debitusrID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@bdgID", OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "bdgID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@aptID", OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "aptID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@inhID", OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "inhID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@Givencredit", credit)
                    oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID.ToString.ToUpper)
                    oCmd.ExecuteNonQuery()
                End Using
                LoaderData()
                Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL)

            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GridView2_LayoutUpgrade(sender As Object, e As LayoutUpgradeEventArgs) Handles GridView2.LayoutUpgrade

    End Sub

    Friend Class MenuColumnInfo
        Public Sub New(ByVal column As GridColumn)
            Me.Column = column
        End Sub
        Public Column As GridColumn
    End Class
End Class