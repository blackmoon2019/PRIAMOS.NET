Imports System.Data.SqlClient
Imports DevExpress.Spreadsheet
Imports DevExpress.Utils.VisualEffects
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Localization
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPrinting.Shape.Native

Public Class frmBatchCollectionInsert
    Private ManageCbo As New CombosManager
    Private LoadForms As New FormLoader
    Sub New()

        GridLocalizer.Active = New GridGreekLocalizer()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmBatchCollectionInsert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_BDG)
        AddHandler grdCollections.EmbeddedNavigator.ButtonClick, AddressOf Grid_EmbeddedNavigator_ButtonClick
        DevExpress.XtraGrid.Localization.GridLocalizer.Active = New GridGreekLocalizer()
        LoadForms.RestoreLayoutFromXml(GridView1, "tmpBatchCollections.xml")
        Me.CenterToScreen()
    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue <> Nothing Then
            Me.Vw_APTTableAdapter.FillByBDG(Me.Priamos_NET_DataSet_BDG.vw_APT, System.Guid.Parse(cboBDG.EditValue.ToString))
            Me.TmpBatchCollectionsTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.tmpBatchCollections, System.Guid.Parse(cboBDG.EditValue.ToString))
        End If
    End Sub
    Private Sub GridView1_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles GridView1.InvalidRowException
        'e.ExceptionMode = ExceptionMode.NoAction
    End Sub
    Private Sub Grid_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Select Case e.Button.ButtonType
            Case e.Button.ButtonType.Remove : If DeleteRecord() = vbYes Then e.Handled = False Else e.Handled = True
            Case e.Button.ButtonType.Append
                If cboBDG.EditValue = Nothing Then
                    XtraMessageBox.Show("Δεν έχετε επιλέξει πολυκατοικία.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Handled = True
                End If
            Case e.Button.ButtonType.EndEdit : cboBDG.Enabled = True
        End Select
    End Sub
    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Delete And UserProps.AllowDelete = True Then DeleteRecord()
        If e.KeyCode = Keys.Down And UserProps.AllowInsert Then
            If sender.FocusedRowHandle < 0 Then Exit Sub
            Dim viewInfo As GridViewInfo = TryCast(sender.GetViewInfo(), GridViewInfo)
            If sender.FocusedRowHandle = viewInfo.RowsInfo.Last().RowHandle Then
                If cboBDG.EditValue = Nothing Then
                    XtraMessageBox.Show("Δεν έχετε επιλέξει πολυκατοικία.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            End If
        End If
    End Sub
    Private Function DeleteRecord() As MsgBoxResult
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "aptID") = Nothing Then Return vbCancel
        If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim sSQL As String = "DELETE FROM tmpBatchCollections WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Me.TmpBatchCollectionsTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.tmpBatchCollections, System.Guid.Parse(cboBDG.EditValue.ToString))
            Return vbYes
        Else
            Return vbNo
        End If
    End Function
    Private Sub GridView1_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        Dim sSQL As New System.Text.StringBuilder
        Dim sDate As String, fDate As String, tDate As String
        Try
            sSQL.Clear()
            If e.RowHandle = grdCollections.NewItemRowHandle Then
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "aptID").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε διαμέρισμα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε Από Μήνα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε Έως Μήνα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "amt").ToString = "" Then
                    e.ErrorText = "Παρακαλώ πληκτρολογείστε ποσό"
                    e.Valid = False
                    Exit Sub
                End If
                If CheckIfDateIsValid() = False Then
                    e.ErrorText = "Δεν μπορεί η ""ΑΠΟ"" ημερομηνία να είναι μεγαλύτερη από την ""ΕΩΣ"""
                    e.Valid = False
                    Exit Sub
                End If
                fDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString
                tDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString
                Dim sCompleteDate As String = TranslateDatesRep(fDate, tDate)
                Dim sGuid As String = Guid.NewGuid.ToString
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "ID", sGuid)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "bdgID", cboBDG.EditValue.ToString)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "completeDate", sCompleteDate)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "createdBy", UserProps.ID.ToString)

                sSQL.AppendLine("INSERT INTO tmpBatchCollections (ID,bdgID,aptID,fDate,tDate,Amt,owner_tenant,completeDate,createdBy)")
                sSQL.AppendLine("Select " & toSQLValueS(sGuid) & ",")
                sSQL.AppendLine(toSQLValueS(cboBDG.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "aptID").ToString) & ",")
                sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString
                If sDate <> "" Then sDate = toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) Else sDate = "NULL"
                sSQL.AppendLine(sDate & ",")
                sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString
                If sDate <> "" Then sDate = toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) Else sDate = "NULL"
                sSQL.AppendLine(sDate & ",")
                sSQL.AppendLine(toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "amt").ToString, True) & ",")
                sSQL.AppendLine(toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "owner_tenant").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "completeDate").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Else
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "aptID").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε διαμέρισμα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε Από Μήνα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε Έως Μήνα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "amt").ToString = "" Then
                    e.ErrorText = "Παρακαλώ πληκτρολογείστε ποσό"
                    e.Valid = False
                    Exit Sub
                End If
                If CheckIfDateIsValid() = False Then
                    e.ErrorText = "Δεν μπορεί η ""ΑΠΟ"" ημερομηνία να είναι μεγαλύτερη από την ""ΕΩΣ"""
                    e.Valid = False
                    Exit Sub
                End If
                fDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString
                tDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString
                Dim sCompleteDate As String = TranslateDatesRep(fDate, tDate)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "completeDate", sCompleteDate)

                sSQL.AppendLine("UPDATE tmpBatchCollections	SET bdgID= " & toSQLValueS(cboBDG.EditValue.ToString) & ",")
                sSQL.AppendLine("aptID = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "aptID").ToString) & ",")
                sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString
                If sDate <> "" Then sDate = toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) Else sDate = "NULL"
                sSQL.AppendLine("fDate = " & sDate & ",")
                sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString
                If sDate <> "" Then sDate = toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) Else sDate = "NULL"
                sSQL.AppendLine("tDate = " & sDate & ",")
                sSQL.AppendLine("amt = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "amt").ToString, True) & ",")
                sSQL.AppendLine("owner_tenant= " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "owner_tenant").ToString) & ",")
                sSQL.AppendLine("completeDate = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "completeDate").ToString) & ",")
                sSQL.AppendLine("createdBy = " & toSQLValueS(UserProps.ID.ToString))
                sSQL.Append("WHERE ID = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            End If
        Catch sqlEx As SqlException When sqlEx.Number = 2601
            XtraMessageBox.Show("Ύπάρχει ήδη εγγραφή καταχωρημένη με αυτά τα στοιχεία.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Valid = False
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function CheckIfDateIsValid() As Boolean
        Dim sDate As String
        sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString
        Dim date1 As Date = Date.Parse(sDate)
        sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString
        Dim date2 As Date = Date.Parse(sDate)
        Dim LastDayInMonthDate As Date = New Date(date2.Year, date2.Month, Date.DaysInMonth(date2.Year, date2.Month))

        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "tDate", LastDayInMonthDate)
        If DateDiff(DateInterval.Month, date1, date2) < 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    Private Sub CreateColInh()
        Try
            If GridView1.RowCount = 0 Then Exit Sub
            Using oCmd As New SqlCommand("inv_CreateFromTransfer", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@bdgid", cboBDG.EditValue.ToString.ToUpper)
                oCmd.ExecuteNonQuery()
            End Using
            XtraMessageBox.Show("Τα παραστατικά και οι οφειλές δημιουργήθηκαν με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.TmpBatchCollectionsTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.tmpBatchCollections, System.Guid.Parse(cboBDG.EditValue.ToString))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cboBDG_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonPressed
        Select Case e.Button.Index
            Case 1 : If cboBDG.EditValue <> Nothing Then ManageCbo.ManageBDG(cboBDG, FormMode.EditRecord)
            Case 2
                If cboBDG.EditValue = Nothing Then Exit Sub
                Me.TmpBatchCollectionsTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.tmpBatchCollections, System.Guid.Parse(cboBDG.EditValue.ToString)) : cboBDG.EditValue = Nothing
        End Select
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        CreateColInh()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim fDate As String, tDate As String
        If e.Column.FieldName = "fDate" Or e.Column.FieldName = "tDate" Then
            fDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString
            tDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString
            If fDate = "" Or tDate = "" Then Exit Sub
            Dim sCompleteDate As String = TranslateDatesRep(fDate, tDate)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "completeDate", sCompleteDate)
        End If
    End Sub


    Private Sub GridView1_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        GridView1.SetRowCellValue(e.RowHandle, "amt", "0.00")
        GridView1.SetRowCellValue(e.RowHandle, "owner_tenant", False)
    End Sub

    Private Sub frmBatchCollectionInsert_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub grdCollections_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles grdCollections.ProcessGridKey
        If e.KeyCode = Keys.Insert Then grdCollections.EmbeddedNavigator.Buttons.DoClick(grdCollections.EmbeddedNavigator.Buttons.Append)
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView1, "tmpBatchCollections.xml", "tmpBatchCollections")
    End Sub
End Class