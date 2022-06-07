﻿Imports System.ComponentModel
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
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.YEARS' table. You can move, or remove it, as needed.
        Me.YEARSTableAdapter.Fill(Me.Priamos_NETDataSet.YEARS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.FillByIsManaged(Me.Priamos_NETDataSet.vw_BDG)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet2.vw_INH' table. You can move, or remove it, as needed.
        'Me.Vw_INHTableAdapter.FillBy(Me.Priamos_NETDataSet2.vw_INH)

        LoaderData()
        'TODO: This line of code loads data into the 'Priamos_NETDataSet2.vw_COLH' table. You can move, or remove it, as needed.
        'Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet2.vw_COL_BDG' table. You can move, or remove it, as needed.
        ' Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
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



        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_APT_def.xml") = False Then
            grdVBDG.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_APT_def.xml", OptionsLayoutBase.FullLayout)
        End If
        grdVAPT.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_APT_def.xml", OptionsLayoutBase.FullLayout)

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_APTCREDE_def.xml") = False Then
            GridView5.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_APTCREDE_def.xml", OptionsLayoutBase.FullLayout)
        End If
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_APTCREDE_def.xml") Then
            GridView5.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_APTCREDE_def.xml", OptionsLayoutBase.FullLayout)
        End If
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_D_CREDE_def.xml") Then
            GridView6.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_D_CREDE_def.xml", OptionsLayoutBase.FullLayout)
        End If

        grdVAPT.Columns.Item("dtCredit").OptionsColumn.AllowEdit = True
        grdVINH.Columns.Item("dtCredit").OptionsColumn.AllowEdit = True
        grdVAPT.DataController.CollapseDetailRowsOnReset = False
        grdVINH.DataController.CollapseDetailRowsOnReset = False
        grdVBDG.DataController.CollapseDetailRowsOnReset = False
        Level = 0
    End Sub


    Public Sub LoaderData(Optional ByVal bdgID As String = "")
        Dim strSql As String
        Dim Tbl As SqlDataAdapter
        Try
            ' Διαμερίσματα
            strSql = "SELECT   C.bdgID, aptID, a.ttl,a.ord, sum(debit) as debit , sum(credit) as credit , sum(C.bal) as bal,A.Bal as Aptbal  " &
                     "From COL C " &
                     "INNER Join INH I ON I.ID=C.inhID " &
                     "INNER Join APT A ON C.aptID = A.ID " &
                    "where Completed=0 " & IIf(bdgID.Length > 0, " And C.bdgID = " & toSQLValueS(bdgID), "") &
                    "group by C.bdgID, aptID, ttl,a.bal,a.ord"


            Tbl = New SqlDataAdapter(strSql, CNDB)
            Priamos_NETDataSet2.COL_APT.Clear()
            Tbl.Fill(Priamos_NETDataSet2.COL_APT)
            Tbl.Dispose()
            ' Παραστατικά
            strSql = "Select   aptID, c.bdgID, inhID, completeDate, SUM(debit) As debit, SUM(credit) As credit, SUM(c.bal) As bal, " &
                     "debitusrID, dtDebit, max(dtCredit) As dtCredit,YEAR(FDATE) AS Etos,MONTH(fDate) as  FromMonth,MONTH(tDate) as  ToMonth  " &
                     "From COL C " &
                     "INNER Join INH I ON I.ID=C.inhID " &
                     "INNER Join APT A ON C.aptID = A.ID " &
                     "where completed=0  " & IIf(bdgID.Length > 0, "  And c.bdgID = " & toSQLValueS(bdgID), "") &
                     "Group By aptID, c.BDGID, INHID, completeDate, debitusrID, dtDebit,YEAR(FDATE),MONTH(fDate),MONTH(tDate) "


            Tbl = New SqlDataAdapter(strSql, CNDB)
            Priamos_NETDataSet2.COL_INH.Clear()
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
            Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(cboBDG.EditValue.ToString))
            Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NETDataSet2.vw_INH, System.Guid.Parse(cboBDG.EditValue.ToString))
            LoaderData(cboBDG.EditValue.ToString)
        Else
            Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
            Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL)
            Me.Vw_INHTableAdapter.FillBy(Me.Priamos_NETDataSet2.vw_INH)
        End If
    End Sub

    Private Sub cmdExit_Click_1(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
    Private Sub RepositoryCOL_METHOD_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles Rep_COL_METHOD.ButtonPressed
        Select Case e.Button.Index
            Case 1 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "ColMethodID", "")
        End Select
    End Sub

    Private Sub RepositoryBANK_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles Rep_ΒΑΝΚ.ButtonPressed
        Select Case e.Button.Index
            Case 1 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "bankID", "")
        End Select
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



    Private Sub cboINH_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboINH.ButtonPressed
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
        Dim bdgID As String
        Try
            Select Case mode
                Case 0
                    If sField Is DBNull.Value Or sField = "NULL" Then
                        dtdebit = "NULL"
                    Else
                        dtdebit = toSQLValueS(CDate(Date.Now).ToString("yyyyMMdd"))
                    End If
            End Select

            Select Case grdBDG.FocusedView.Name
                Case "GridView1", "grdVBDG"
                    sSQL = "UPDATE [COL] SET debitusrID  = " & sField & ",dtdebit  = " & dtdebit &
                           " WHERE bdgID = " & toSQLValueS(grdVBDG.GetRowCellValue(grdVBDG.FocusedRowHandle, "bdgID").ToString)
                    bdgID = grdVBDG.GetRowCellValue(grdVBDG.FocusedRowHandle, "bdgID").ToString
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
                    bdgID = APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString
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
                    bdgID = INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString
                Case "GridView4"
                    sSQL = "UPDATE [COL] SET debitusrID  = " & sField & ",dtdebit  = " & dtdebit &
                           " WHERE ID = " & toSQLValueS(OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "ID").ToString)
                    bdgID = OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "bdgID").ToString
            End Select
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            LoaderData(bdgID)

            Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(bdgID))


            'Select Case GridControl2.FocusedView.Name
            '    Case "GridView1" : GridView1.SetMasterRowExpanded(0, True)
            '    Case "GridView2" : APTView.SetMasterRowExpanded(0, True)
            '    Case "GridView3" : INHView.SetMasterRowExpanded(0, True)
            '    Case "GridView4"
            'End Select
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Rep_DEBITUSR_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles Rep_DEBITUSR.ButtonPressed
        Select Case e.Button.Index
            Case 1 : grdVBDG.SetRowCellValue(grdVBDG.FocusedRowHandle, "debitusrID", "") : UpdateCOLS(0, "NULL")
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
                If tmpdebitusrID = "" Then Return False
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

    Private Sub GridView1_DetailTabStyle(sender As Object, e As DetailTabStyleEventArgs) Handles grdVBDG.DetailTabStyle
        e.Appearance.Header.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        e.Appearance.Header.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        e.ImageOptions.SvgImage = SvgImageCollection1("bo_address")
    End Sub

    Private Sub GridView2_DetailTabStyle(sender As Object, e As DetailTabStyleEventArgs) Handles grdVAPT.DetailTabStyle
        e.Appearance.Header.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        e.Appearance.Header.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        e.ImageOptions.SvgImage = SvgImageCollection1("bo_invoice")
    End Sub

    Private Sub GridView3_DetailTabStyle(sender As Object, e As DetailTabStyleEventArgs) Handles grdVINH.DetailTabStyle
        e.Appearance.Header.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        e.Appearance.Header.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        e.ImageOptions.SvgImage = SvgImageCollection1("bo_employee")
    End Sub


    Private Sub GridView1_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles grdVBDG.MasterRowExpanded
        Dim APTView2 = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        APTView = APTView2.GetDetailView(e.RowHandle, e.RelationIndex)

        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_APT_def.xml") = False Then
            APTView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_APT_def.xml", OptionsLayoutBase.FullLayout)
        End If
        APTView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_APT_def.xml", OptionsLayoutBase.FullLayout)
        APTView.DataController.CollapseDetailRowsOnReset = False
        Level = 1

    End Sub
    Private Sub GridView2_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles grdVAPT.MasterRowExpanded
        Dim INHView2 = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        INHView = INHView2.GetDetailView(e.RowHandle, e.RelationIndex)

        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_INH_def.xml") = False Then
            INHView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_INH_def.xml", OptionsLayoutBase.FullLayout)
        End If

        INHView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_INH_def.xml", OptionsLayoutBase.FullLayout)
        INHView.DataController.CollapseDetailRowsOnReset = False
        INHView.OptionsLayout.StoreAllOptions = True
        INHView.Columns.Item("dtCredit").OptionsColumn.AllowEdit = True
        Level = 2
    End Sub

    Private Sub GridView3_MasterRowExpanded(sender As Object, e As CustomMasterRowEventArgs) Handles grdVINH.MasterRowExpanded
        Dim OwnerTenantView2 = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        OwnerTenantView = OwnerTenantView2.GetDetailView(e.RowHandle, e.RelationIndex)

        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_OW_TEN_def.xml") = False Then
            OwnerTenantView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_OW_TEN_def.xml", OptionsLayoutBase.FullLayout)
        End If
        OwnerTenantView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_OW_TEN_def.xml", OptionsLayoutBase.FullLayout)
        OwnerTenantView.DataController.CollapseDetailRowsOnReset = False
        OwnerTenantView.Columns.Item("dtCredit").OptionsColumn.AllowEdit = True
        Level = 3
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles grdVBDG.CustomColumnDisplayText
        If IsNothing(e.Value) Then e.DisplayText = "*******"
    End Sub

    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles grdVAPT.CustomColumnDisplayText
        If IsNothing(e.Value) Then e.DisplayText = "*******"
    End Sub

    Private Sub GridView2_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles grdVAPT.ValidatingEditor
        Try
            Dim dtcredit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal
            Dim debitusrID As String, sAptID As String
            'Κολπάκι ώστε να πάρουμε το view των παραστατικών. Ανοιγοκλείνουμε χωρις να το παίρνει χαμπάρι ο χρήστης το Detail
            sender.SetMasterRowExpanded(sender.FocusedRowHandle, True)
            ' Επίτηδες έχει μπει το INHVIEW. Με ενδιαφέρει να ελένξω σε επίπεδο παραστατικού αν υπάρχει διαφορετικός χρήστης
            If sender.FocusedColumn.FieldName = "credit" And IsDebitUserUnique(INHView, debitusrID) = False Then
                e.ErrorText = "Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                sender.SetMasterRowExpanded(sender.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            ElseIf sender.FocusedColumn.FieldName = "credit" And IsDebitUserEmpty(INHView) = True Then
                e.ErrorText = "Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                sender.SetRowCellValue(sender.FocusedRowHandle, "credit", 0)
                sender.SetMasterRowExpanded(sender.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            ElseIf sender.FocusedColumn.FieldName = "credit" And Decimal.Parse(e.Value) = 0 Then
                e.Valid = False
                Exit Sub
            End If

            If debitusrID = "" Then
                e.ErrorText = "Δεν έχετε επιλέξει χρήστη χρέωσης "
                e.Valid = False
                Exit Sub
            End If

            ' Εαν η πίστωση είναι 0 τότε να μην κάνεις τίποτα
            debit = sender.GetRowCellValue(sender.FocusedRowHandle, "debit")
            If debit = 0 Then Exit Sub

            If sender.FocusedColumn.FieldName = "credit" Then
                If sender.GetRowCellValue(sender.FocusedRowHandle, "debit") Is DBNull.Value Then
                    debit = 0
                Else
                    debit = sender.GetRowCellValue(sender.FocusedRowHandle, "debit")
                End If
                credit = Decimal.Parse(e.Value)

                If sender.GetRowCellValue(sender.FocusedRowHandle, "bal") Is DBNull.Value Then
                    bal = 0
                Else
                    bal = sender.GetRowCellValue(sender.FocusedRowHandle, "bal")
                End If

                bal = Math.Abs(debit) - credit
                dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))

                sAptID=sender.GetRowCellValue(sender.FocusedRowHandle, "aptID").ToString.ToUpper
                'Ενημέρωση Header είσπραξης
                Using oCmd As New SqlCommand("col_Calculate", CNDB)
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.Parameters.AddWithValue("@debitusrID", debitusrID.ToUpper)
                    oCmd.Parameters.AddWithValue("@bdgID", sender.GetRowCellValue(sender.FocusedRowHandle, "bdgID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@aptID", sAptID)
                    oCmd.Parameters.AddWithValue("@inhID", Guid.Empty)
                    oCmd.Parameters.AddWithValue("@Givencredit", credit)
                    oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID)
                    oCmd.Parameters.AddWithValue("@ColMethodID", "75E3251D-077D-42B0-B79A-9F2886381A97") ' ΜΕΤΡΗΤΑ
                    oCmd.Parameters.AddWithValue("@TenantOwner", 2)
                    oCmd.Parameters.AddWithValue("@Agreed", 0)
                    oCmd.ExecuteNonQuery()
                End Using


                LoaderData(sender.GetRowCellValue(sender.FocusedRowHandle, "bdgID").ToString)
                Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(sender.GetRowCellValue(sender.FocusedRowHandle, "bdgID").ToString))
                sender.SetMasterRowExpanded(sender.FocusedRowHandle, False)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles grdVINH.ValidatingEditor
        Try
            Dim sSQL As String, dtcredit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal
            Dim debitusrID As String, sBdgID As String, sAptID As String
            'Κολπάκι ώστε να πάρουμε το view των παραστατικών. Ανοιγοκλείνουμε χωρις να το παίρνει χαμπάρι ο χρήστης το Detail
            sender.SetMasterRowExpanded(sender.FocusedRowHandle, True)
            If sender.FocusedColumn.FieldName = "credit" And IsDebitUserUnique(sender, debitusrID) = False Then
                e.ErrorText = "Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                sender.SetMasterRowExpanded(sender.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            ElseIf sender.FocusedColumn.FieldName = "credit" And IsDebitUserEmpty(sender) = True Then
                e.ErrorText = "Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                If sender.FocusedColumn.FieldName = "credit" Then
                    sender.SetRowCellValue(sender.FocusedRowHandle, "credit", 0)
                ElseIf sender.FocusedColumn.FieldName = "bankID" Then
                    sender.SetRowCellValue(sender.FocusedRowHandle, "bankID", DBNull.Value)
                ElseIf sender.FocusedColumn.FieldName = "ColMethodID" Then
                    sender.SetRowCellValue(sender.FocusedRowHandle, "ColMethodID", DBNull.Value)
                ElseIf sender.FocusedColumn.FieldName = "dtCredit" Then
                    sender.SetRowCellValue(sender.FocusedRowHandle, "dtCredit", DBNull.Value)
                End If
                sender.SetMasterRowExpanded(sender.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            ElseIf sender.FocusedColumn.FieldName = "credit" Then
                If sender.GetRowCellValue(sender.FocusedRowHandle, "debit") Is DBNull.Value Then
                    debit = 0
                Else
                    debit = sender.GetRowCellValue(sender.FocusedRowHandle, "debit")
                End If
                credit = e.Value
                If credit > debit Then
                    e.ErrorText = "Δεν μπορεί η πίστωση να είναι μεγαλύτερη από την χρέωση σε ενα παραστατικό."
                    e.Valid = False
                    Exit Sub
                End If
                If credit = 0 Then e.Valid = False : Exit Sub

            End If
            If debitusrID = "" Then
                e.ErrorText = "Δεν έχετε επιλέξει χρήστη χρέωσης "
                e.Valid = False
                Exit Sub
            End If

            If debit = 0 Or (debit = 0 And credit = 0) Then Exit Sub


            If sender.FocusedColumn.FieldName = "credit" Or sender.FocusedColumn.FieldName = "ColMethodID" Or sender.FocusedColumn.FieldName = "bankID" Then
                If sender.GetRowCellValue(sender.FocusedRowHandle, "debit") Is DBNull.Value Then
                    debit = 0
                Else
                    debit = sender.GetRowCellValue(sender.FocusedRowHandle, "debit")
                End If
                If sender.FocusedColumn.FieldName = "credit" Then
                    credit = e.Value
                Else
                    If sender.GetRowCellValue(sender.FocusedRowHandle, "credit") Is DBNull.Value Then
                        credit = 0
                    Else
                        credit = sender.GetRowCellValue(sender.FocusedRowHandle, "credit")
                    End If

                End If
                If sender.GetRowCellValue(sender.FocusedRowHandle, "bal") Is DBNull.Value Then
                    bal = 0
                Else
                    bal = sender.GetRowCellValue(sender.FocusedRowHandle, "bal")
                End If
                bal = Math.Abs(debit) - credit
                sender.SetRowCellValue(sender.FocusedRowHandle, "bal", bal)
                sBdgID = sender.GetRowCellValue(sender.FocusedRowHandle, "bdgID").ToString
                sAptID = sender.GetRowCellValue(sender.FocusedRowHandle, "aptID").ToString
                dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
                Using oCmd As New SqlCommand("col_Calculate", CNDB)
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.Parameters.AddWithValue("@debitusrID", sender.GetRowCellValue(sender.FocusedRowHandle, "debitusrID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@bdgID", sBdgID.ToUpper)
                    oCmd.Parameters.AddWithValue("@aptID", sAptID)
                    oCmd.Parameters.AddWithValue("@inhID", sender.GetRowCellValue(sender.FocusedRowHandle, "inhID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@Givencredit", credit)
                    oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID.ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@ColMethodID", "75E3251D-077D-42B0-B79A-9F2886381A97") ' ΜΕΤΡΗΤΑ 
                    oCmd.Parameters.AddWithValue("@TenantOwner", 2)
                    oCmd.Parameters.AddWithValue("@Agreed", 0)
                    oCmd.ExecuteNonQuery()
                End Using
                ' Ενημέρωση υπολοίπου διαμερίσματος
                'sSQL = "Update apt set apt.bal_adm = (select isnull(sum(col.bal),0) from col where completed=0 And aptID = " & toSQLValueS(sAptID) & ") where id = " & toSQLValueS(sAptID)
                'Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using

                LoaderData(sBdgID)
                Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(sBdgID))
                'Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NETDataSet2.vw_INH, System.Guid.Parse(sender.GetRowCellValue(sender.FocusedRowHandle, "bdgID").ToString))
                sender.SetMasterRowExpanded(sender.FocusedRowHandle, False)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView4_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles grdVO_T.ValidatingEditor
        Try
            Dim sSQL As String, dtcredit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal
            Dim debitusrID As String, sBdgID As String, sInhID As String, sAptID As String
            If sender.FocusedColumn.FieldName = "debit" Then Exit Sub
            'Κολπάκι ώστε να πάρουμε το view των παραστατικών. Ανοιγοκλείνουμε χωρις να το παίρνει χαμπάρι ο χρήστης το Detail
            sender.SetMasterRowExpanded(sender.FocusedRowHandle, True)
            If sender.FocusedColumn.FieldName = "credit" And IsDebitUserUnique(sender, debitusrID) = False Then
                'XtraMessageBox.Show("Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.ErrorText = "Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                sender.SetMasterRowExpanded(sender.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            ElseIf sender.FocusedColumn.FieldName = "credit" And IsDebitUserEmpty(sender) = True Then
                'XtraMessageBox.Show("Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.ErrorText = "Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                sender.SetRowCellValue(sender.FocusedRowHandle, "credit", 0)
                APTView.SetRowCellValue(APTView.FocusedRowHandle, "credit", 0)
                INHView.SetRowCellValue(INHView.FocusedRowHandle, "credit", 0)
                sender.SetMasterRowExpanded(sender.FocusedRowHandle, False)
                e.Valid = False
                Exit Sub
            ElseIf sender.FocusedColumn.FieldName = "credit" Then
                If sender.GetRowCellValue(sender.FocusedRowHandle, "debit") Is DBNull.Value Then
                    debit = 0
                Else
                    debit = sender.GetRowCellValue(sender.FocusedRowHandle, "debit")
                End If
                credit = e.Value
                If credit > debit Then
                    e.ErrorText = "Δεν μπορεί η πίστωση να είναι μεγαλύτερη από την χρέωση σε ενα παραστατικό."
                    e.Valid = False
                    Exit Sub
                End If
                If credit = 0 Then e.Valid = False : Exit Sub
            End If

            If debit = 0 And credit = 0 Then Exit Sub

            If sender.FocusedColumn.FieldName = "credit" Or sender.FocusedColumn.FieldName = "ColMethodID" Or sender.FocusedColumn.FieldName = "bankID" Then
                If sender.GetRowCellValue(sender.FocusedRowHandle, "debit") Is DBNull.Value Then
                    debit = 0
                Else
                    debit = sender.GetRowCellValue(sender.FocusedRowHandle, "debit")
                End If
                If sender.FocusedColumn.FieldName = "credit" Then
                    credit = e.Value
                Else
                    If sender.GetRowCellValue(sender.FocusedRowHandle, "credit") Is DBNull.Value Then
                        credit = 0
                    Else
                        credit = sender.GetRowCellValue(sender.FocusedRowHandle, "credit")
                    End If

                End If
                If sender.GetRowCellValue(sender.FocusedRowHandle, "bal") Is DBNull.Value Then
                    bal = 0
                Else
                    bal = sender.GetRowCellValue(sender.FocusedRowHandle, "bal")
                End If
                bal = Math.Abs(debit) - credit
                dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
                sBdgID = sender.GetRowCellValue(sender.FocusedRowHandle, "bdgID").ToString
                sInhID = sender.GetRowCellValue(sender.FocusedRowHandle, "inhID").ToString
                sAptID = sender.GetRowCellValue(sender.FocusedRowHandle, "aptID").ToString
                sender.SetRowCellValue(sender.FocusedRowHandle, "bal", bal)
                Using oCmd As New SqlCommand("col_Calculate", CNDB)
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.Parameters.AddWithValue("@debitusrID", sender.GetRowCellValue(sender.FocusedRowHandle, "debitusrID").ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@bdgID", sBdgID.ToUpper)
                    oCmd.Parameters.AddWithValue("@aptID", sAptID.ToUpper)
                    oCmd.Parameters.AddWithValue("@inhID", sInhID.ToUpper)
                    oCmd.Parameters.AddWithValue("@Givencredit", credit)
                    oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID.ToString.ToUpper)
                    oCmd.Parameters.AddWithValue("@ColMethodID", "75E3251D-077D-42B0-B79A-9F2886381A97") ' ΜΕΤΡΗΤΑ
                    oCmd.Parameters.AddWithValue("@TenantOwner", IIf(sender.GetRowCellValue(sender.FocusedRowHandle, "tenant") = False, 0, 1))
                    oCmd.Parameters.AddWithValue("@Agreed", 0)
                    oCmd.ExecuteNonQuery()
                End Using
                ' Ενημέρωση υπολοίπου διαμερίσματος
                'sSQL = "Update apt set apt.bal_adm = (select isnull(sum(col.bal),0) from col where completed=0 And aptID = " & toSQLValueS(sAptID) & ") where id = " & toSQLValueS(sAptID)
                'Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using

                LoaderData(sBdgID)
                Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(sBdgID))
                'If bal = 0 Then grdVO_T.DeleteRow(sender.FocusedRowHandle)
                'Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NETDataSet2.vw_INH, System.Guid.Parse(sBdgID))
                sender.SetMasterRowExpanded(sender.FocusedRowHandle, False)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Rep_Credit_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles Rep_Credit.ButtonPressed
        Try
            Dim GRD As GridView = grdBDG.FocusedView
            Select Case GRD.Name
                Case "GridView2" ' Διαμερίσματα
                    Select Case e.Button.Index
                        Case 0 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "credit", APTView.GetRowCellValue(APTView.FocusedRowHandle, "debit")) : APTView.ValidateEditor()
                        Case 1 : APTView.SetRowCellValue(APTView.FocusedRowHandle, "credit", 0)
                        Case 2
                            Dim frm As New frmCollectionsDet
                            frmCollectionsDet.BDGID = APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString.ToUpper
                            frmCollectionsDet.APTID = APTView.GetRowCellValue(APTView.FocusedRowHandle, "aptID").ToString.ToUpper
                            frmCollectionsDet.INHID = ""
                            frmCollectionsDet.CheckForTenant = False
                            frmCollectionsDet.ShowDialog()
                            LoaderData(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString)
                            Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString))
                            'Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NETDataSet2.vw_INH, System.Guid.Parse(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bdgID").ToString))
                    End Select

                Case "GridView3" ' Παραστατικα
                    Select Case e.Button.Index
                        Case 0 : INHView.SetRowCellValue(INHView.FocusedRowHandle, "credit", INHView.GetRowCellValue(INHView.FocusedRowHandle, "debit")) : INHView.ValidateEditor()
                        Case 1 : INHView.SetRowCellValue(INHView.FocusedRowHandle, "credit", 0)
                        Case 2
                            Dim frm As New frmCollectionsDet
                            frmCollectionsDet.BDGID = INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString.ToUpper
                            frmCollectionsDet.APTID = INHView.GetRowCellValue(INHView.FocusedRowHandle, "aptID").ToString.ToUpper
                            frmCollectionsDet.INHID = INHView.GetRowCellValue(INHView.FocusedRowHandle, "inhID").ToString.ToUpper
                            frmCollectionsDet.CheckForTenant = False
                            frmCollectionsDet.ShowDialog()
                            LoaderData(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString)
                            Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString))
                            'Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NETDataSet2.vw_INH, System.Guid.Parse(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString))

                    End Select

                Case "GridView4" ' Ένοικος/Ιδιοκτήτης
                    Select Case e.Button.Index
                        Case 0 : OwnerTenantView.SetRowCellValue(OwnerTenantView.FocusedRowHandle, "credit", OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "debit")) : OwnerTenantView.ValidateEditor()
                        Case 1 : OwnerTenantView.SetRowCellValue(OwnerTenantView.FocusedRowHandle, "credit", 0)
                        Case 2
                            Dim frm As New frmCollectionsDet
                            frmCollectionsDet.BDGID = OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "bdgID").ToString.ToUpper
                            frmCollectionsDet.APTID = OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "aptID").ToString.ToUpper
                            frmCollectionsDet.INHID = OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "inhID").ToString.ToUpper
                            frmCollectionsDet.TENANT = OwnerTenantView.GetRowCellValue(OwnerTenantView.FocusedRowHandle, "tenant")
                            frmCollectionsDet.CheckForTenant = True
                            frmCollectionsDet.ShowDialog()
                            LoaderData(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString)
                            Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString))
                            'Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NETDataSet2.vw_INH, System.Guid.Parse(INHView.GetRowCellValue(INHView.FocusedRowHandle, "bdgID").ToString))
                    End Select
            End Select

        Catch ex As Exception
            If ex.HResult <> -2146233088 Then XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cboDebitUsr_EditValueChanged(sender As Object, e As EventArgs) Handles cboDebitUsr.EditValueChanged
        If cboDebitUsr.EditValue <> Nothing Then
            Me.Vw_COL_BDGTableAdapter.FillBydebitusrID(Me.Priamos_NETDataSet2.vw_COL_BDG, System.Guid.Parse(cboDebitUsr.EditValue.ToString))
        Else
            Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
        End If
    End Sub
    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles grdVBDG.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, grdVBDG, "COL_BDG_def.xml")
    End Sub
    Private Sub GridView2_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles grdVAPT.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, grdVAPT, "COL_APT_def.xml")
    End Sub
    Private Sub GridView3_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles grdVINH.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, grdVINH, "COL_INH_def.xml")
    End Sub

    Private Sub GridView4_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles grdVO_T.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, grdVO_T, "COL_OW_TEN_def.xml")
    End Sub
    Private Sub GridView5_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView5.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView5, "COL_APTCREDE_def.xml")
    End Sub
    Private Sub GridView6_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView6.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView6, "COL_D_CREDE_def.xml")
    End Sub
    Private Sub cmdCol_Refresh_Click(sender As Object, e As EventArgs) Handles cmdCol_Refresh.Click
        Select Case TabbedControlGroup1.SelectedTabPageIndex
            Case 0
                If cboBDG.EditValue Is Nothing Then
                    LoaderData()
                    Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL)
                Else
                    LoaderData(cboBDG.EditValue.ToString)
                    Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(cboBDG.EditValue.ToString))
                    Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NETDataSet2.vw_INH, System.Guid.Parse(cboBDG.EditValue.ToString))
                End If

                'Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
            Case 1 : Me.COL_REPORTTableAdapter.Fill(Me.Priamos_NETDataSet2.COL_REPORT)
            Case 2
                If chkShowAgree.IsOn = True Then
                    Me.Vw_COL_DTableAdapter.FillByNotAgreed(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
                Else
                    Me.Vw_COL_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
                End If
                GridView6.SelectAll()
        End Select

    End Sub
    Private Sub cboINH_EditValueChanged_1(sender As Object, e As EventArgs) Handles cboINH.EditValueChanged
        If cboINH.EditValue <> Nothing Then
            Me.Vw_COL_BDGTableAdapter.FillByINH(Me.Priamos_NETDataSet2.vw_COL_BDG, System.Guid.Parse(cboINH.EditValue.ToString))
            Me.Vw_COLTableAdapter.FillByINH(Me.Priamos_NETDataSet2.vw_COL, System.Guid.Parse(cboINH.EditValue.ToString))
        Else
            Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
            Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL)
        End If
    End Sub
    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView5.CellValueChanged
        'Try
        '    Dim sSQL As String, dtcredit As String, dtdebit As String
        '    Dim credit As Decimal, debit As Decimal, bal As Decimal


        '    If APTView.GetRowCellValue(APTView.FocusedRowHandle, "dtCredit") Is DBNull.Value Then
        '        dtcredit = "NULL"
        '    Else
        '        dtcredit = toSQLValueS(CDate(APTView.GetRowCellValue(APTView.FocusedRowHandle, "dtCredit")).ToString("yyyyMMdd"))

        '    End If

        '    If APTView.GetRowCellValue(APTView.FocusedRowHandle, "dtDebit") Is DBNull.Value Then
        '        dtdebit = "NULL"
        '    Else
        '        dtdebit = toSQLValueS(CDate(APTView.GetRowCellValue(APTView.FocusedRowHandle, "dtDebit")).ToString("yyyyMMdd"))
        '    End If
        '    If APTView.GetRowCellValue(APTView.FocusedRowHandle, "ID") = Nothing Then Exit Sub
        '    If APTView.GetRowCellValue(APTView.FocusedRowHandle, "debit") Is DBNull.Value Then
        '        debit = 0
        '    Else
        '        debit = APTView.GetRowCellValue(APTView.FocusedRowHandle, "debit")
        '    End If
        '    If APTView.GetRowCellValue(APTView.FocusedRowHandle, "credit") Is DBNull.Value Then
        '        credit = 0
        '    Else
        '        credit = APTView.GetRowCellValue(APTView.FocusedRowHandle, "credit")
        '    End If
        '    If APTView.GetRowCellValue(APTView.FocusedRowHandle, "bal") Is DBNull.Value Then
        '        bal = 0
        '    Else
        '        bal = APTView.GetRowCellValue(APTView.FocusedRowHandle, "bal")
        '    End If

        '    Select Case e.Column.FieldName
        '        Case "credit"
        '            bal = debit - credit
        '            dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))
        '            sSQL = "UPDATE [COL] SET dtcredit  = " & dtcredit & ",dtdebit  = " & dtdebit &
        '                    ",credit = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "credit"), True) &
        '                    ",creditusrID  = " & toSQLValueS(UserProps.ID.ToString) &
        '                    ",bal = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bal"), True) &
        '                    " WHERE ID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ID").ToString)

        '            Using oCmd As New SqlCommand(sSQL, CNDB)
        '                oCmd.ExecuteNonQuery()
        '            End Using
        '            APTView.SetRowCellValue(APTView.FocusedRowHandle, "bal", bal)
        '            APTView.SetRowCellValue(APTView.FocusedRowHandle, "dtCredit", Date.Now.ToString("MM/dd/yyyy"))
        '            APTView.SetRowCellValue(APTView.FocusedRowHandle, "creditusrID", System.Guid.Parse(UserProps.ID.ToString))
        '            ' Ενημέρωση Header Είσπραξης
        '            Using oCmd As New SqlCommand("COL_Calculate", CNDB)
        '                oCmd.CommandType = CommandType.StoredProcedure
        '                oCmd.Parameters.AddWithValue("@colHid", APTView.GetRowCellValue(APTView.FocusedRowHandle, "colHID").ToString.ToUpper)
        '                oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID.ToString.ToUpper)
        '                oCmd.ExecuteNonQuery()
        '            End Using
        '        Case "ColMethodID"
        '            sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ColMethodID").ToString) &
        '                    " WHERE ID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ID").ToString)
        '            Using oCmd As New SqlCommand(sSQL, CNDB)
        '                oCmd.ExecuteNonQuery()
        '            End Using
        '        Case "bankID"
        '            sSQL = "UPDATE [COL] SET bankID  = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "bankID").ToString) &
        '                    " WHERE ID = " & toSQLValueS(APTView.GetRowCellValue(APTView.FocusedRowHandle, "ID").ToString)
        '            Using oCmd As New SqlCommand(sSQL, CNDB)
        '                oCmd.ExecuteNonQuery()
        '            End Using

        '    End Select
        'Catch ex As Exception
        '    XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
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
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles grdVBDG.CellValueChanged
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
    Private Sub GridView3_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles grdVINH.CellValueChanged
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
    Private Sub GridView4_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles grdVO_T.CellValueChanged
        Try
            Dim sSQL As String
            'Dim dtcredit As String, dtdebit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal
            'Dim debitUsrID As String

            '    '1st Level
            Select Case e.Column.FieldName
                Case "debit"
                    If e.Value Is DBNull.Value Then debit = 0 Else debit = e.Value
                    If sender.GetRowCellValue(sender.FocusedRowHandle, "credit") Is DBNull.Value Then
                        credit = 0
                    Else
                        credit = sender.GetRowCellValue(sender.FocusedRowHandle, "credit")
                    End If
                    bal = debit - credit

                    sSQL = "UPDATE [COL] SET debit = " & toSQLValueS(debit, True) & " , bal =  " & toSQLValueS(bal, True) &
                        " WHERE ID = " & toSQLValueS(sender.GetRowCellValue(sender.FocusedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                    sender.SetRowCellValue(sender.FocusedRowHandle, "bal", bal)
                    'Case "debitusrIDs"

                    'debitUsrID = toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "debitusrID").ToString)
                    'sSQL = "UPDATE [COL] SET debitusrID  = " & debitUsrID &
                    '        " WHERE bdgID = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bdgID").ToString)
                    'Using oCmd As New SqlCommand(sSQL, CNDB)
                    '    oCmd.ExecuteNonQuery()
                    'End Using
                    'Me.Vw_COL_BDGTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_BDG)
                    'Me.Vw_COL_APTTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_APT)
                    'Me.Vw_COL_INHTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_INH)
                    'Me.Vw_COLTableAdapter3.Fill(Me.Priamos_NETDataSet2.vw_COL)
            End Select


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

    Private Sub cmdConfirmation_Click(sender As Object, e As EventArgs) Handles cmdConfirmation.Click
        Dim sSQL As String
        Dim Credit As Decimal
        If chkShowAgree.IsOn = True Then
            If XtraMessageBox.Show("Θέλετε να επιβεβαιωθούν οι επιλεγμένες εγγραφές?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
        Else
            If XtraMessageBox.Show("Θέλετε να επαναφέρετε τις επιλεγμένες εγγραφές?Προσοχή οι εγγραφές αυτές θα διαγραφούν.", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
        End If
        Dim selectedRowHandles As Int32() = GridView6.GetSelectedRows()
        'For Each rowHandle As Integer In GridView6.GetSelectedRows
        For I = 0 To selectedRowHandles.Length - 1
            Dim selectedRowHandle As Int32 = selectedRowHandles(I)
            If GridView6.IsGroupRow(selectedRowHandle) = False Then
                If chkShowAgree.IsOn = True Then
                    sSQL = "UPDATE [COL_D] SET agreed=1  WHERE ID = " & toSQLValueS(GridView6.GetRowCellValue(selectedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                    sSQL = "Update apt set apt.bal_adm = apt.bal_adm -   (select isnull(col_d.credit,0) from col_d where col_d.agreed=1 And col_d.ID = " & toSQLValueS(GridView6.GetRowCellValue(selectedRowHandle, "ID").ToString) & ") " &
                        "where id = " & toSQLValueS(GridView6.GetRowCellValue(selectedRowHandle, "aptID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using

                Else
                    ' Από την στιγμή που διαγράφω κινήσεις είσπραξης θα πρέπει να γίνει Ενημέρωση υπολοίπου διαμερίσματος
                    ' Ενημέρωση υπολοίπου διαμερίσματος
                    sSQL = "Update apt set apt.bal_adm = apt.bal_adm +   (select isnull(col_d.credit,0) from col_d where col_d.agreed=1 And col_d.ID = " & toSQLValueS(GridView6.GetRowCellValue(selectedRowHandle, "ID").ToString) & ") " &
                        "where id = " & toSQLValueS(GridView6.GetRowCellValue(selectedRowHandle, "aptID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using
                    sSQL = "DELETE FROM COL_D WHERE ID = " & toSQLValueS(GridView6.GetRowCellValue(selectedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using
                    If GridView6.GetRowCellValue(selectedRowHandle, "inhID").ToString <> "" Then Credit = GridView6.GetRowCellValue(selectedRowHandle, "Credit") Else Credit = 0
                    ' Από την στιγμή που διαγράφω κινήσεις είσπραξης θα πρέπει να γίνει Ενημέρωση της είσπραξης
                    sSQL = "UPDATE COL SET completed=0,debit = debit +  " & toSQLValueS(Credit.ToString, True) &
                      ",bal=bal + " & toSQLValueS(Credit.ToString, True) & " where id = " & toSQLValueS(GridView6.GetRowCellValue(selectedRowHandle, "colID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using
                End If
            End If
        Next I
        If chkShowAgree.IsOn = True Then
            Me.Vw_COL_DTableAdapter.FillByNotAgreed(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
        Else
            Me.Vw_COL_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
        End If
    End Sub



    Private Sub TabbedControlGroup1_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabbedControlGroup1.SelectedPageChanged
        Select Case TabbedControlGroup1.SelectedTabPageIndex
            Case 0
            Case 1 : Me.COL_REPORTTableAdapter.Fill(Me.Priamos_NETDataSet2.COL_REPORT)
            Case 2
                If cboBDG.EditValue IsNot Nothing Then cboBDG1.EditValue = cboBDG.EditValue
                If chkShowAgree.IsOn Then
                    Me.Vw_COL_DTableAdapter.FillByNotAgreed(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
                Else
                    Me.Vw_COL_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
                End If
                GridView6.SelectAll()
            Case Else
        End Select
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

    Private Sub chkShowAgree_EditValueChanged(sender As Object, e As EventArgs) Handles chkShowAgree.EditValueChanged

    End Sub

    Private Sub chkShowAgree_IsOnChanged(sender As Object, e As EventArgs) Handles chkShowAgree.IsOnChanged

        If chkShowAgree.IsOn Then
            Me.Vw_COL_DTableAdapter.FillByNotAgreed(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
        Else
            Me.Vw_COL_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
        End If


        GridView6.SelectAll()
    End Sub

    Private Sub cboBDG1_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG1.EditValueChanged
        If chkShowAgree.IsOn Then
            Me.Vw_COL_DTableAdapter.FillByNotAgreed(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
        Else
            Me.Vw_COL_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet2.vw_COL_D, cboBDG1.EditValue)
        End If


        GridView6.SelectAll()
    End Sub

    Private Sub cboDebitUsr_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboDebitUsr.ButtonPressed
        Select Case e.Button.Index
            Case 1 : If cboDebitUsr.EditValue <> Nothing Then ManageUSR(cboBDG)
            Case 2 : cboDebitUsr.EditValue = Nothing
            Case 3
        End Select
    End Sub

    Private Sub cmdColAdd_Click(sender As Object, e As EventArgs) Handles cmdColAdd.Click
        Dim form1 As frmColEnanti = New frmColEnanti()
        form1.ShowDialog()
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

    Private Sub Rep_AddnewCOL_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles Rep_AddnewCOL.ButtonPressed
        Dim form1 As frmColEnanti = New frmColEnanti()
        Select Case e.Button.Index
            Case 0
                form1.BdgID = grdVBDG.GetRowCellValue(grdVBDG.FocusedRowHandle, "bdgID").ToString
                form1.BdgNam = grdVBDG.GetRowCellValue(grdVBDG.FocusedRowHandle, "BdgNam").ToString
                form1.ShowDialog()
        End Select
    End Sub

    Private Sub cboBDG1_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG1.ButtonPressed
        Select Case e.Button.Index
            Case 1 : If cboBDG1.EditValue <> Nothing Then ManageBDG(cboBDG1)
            Case 2 : cboBDG1.EditValue = Nothing
            Case 3
        End Select
    End Sub
End Class