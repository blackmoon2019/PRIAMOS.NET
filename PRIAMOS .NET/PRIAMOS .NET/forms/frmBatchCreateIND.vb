Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Localization

Public Class frmBatchCreateIND
    Private ManageCbo As New CombosManager
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Sub New()

        GridLocalizer.Active = New GridGreekLocalizer()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmBachCreateIND_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_INH.vw_INHNotCalculated' table. You can move, or remove it, as needed.
        Me.Vw_INHNotCalculatedTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_INHNotCalculated)
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_INH.vw_IND_BATCH' table. You can move, or remove it, as needed.
        Me.Vw_IND_BATCHTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_BATCH)
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_INH.vw_TTL' table. You can move, or remove it, as needed.
        Me.Vw_TTLTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_TTL)
        Me.Vw_CALC_CATTableAdapter.FillByAll(Me.Priamos_NET_DataSet_INH.vw_CALC_CAT)
        LoadForms.RestoreLayoutFromXml(GridView5, "vw_IND_BATCH.xml")
        Me.CenterToScreen()
    End Sub
    Private Sub cboRepname_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboRepname.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboRepname.EditValue = Nothing : ManageCbo.ManageTTL(cboRepname, FormMode.NewRecord)
            Case 2 : If cboRepname.EditValue <> Nothing Then ManageCbo.ManageTTL(cboRepname, FormMode.EditRecord)
            Case 3 : cboRepname.EditValue = Nothing
        End Select
    End Sub

    Private Sub cmdSaveINH_Click(sender As Object, e As EventArgs) Handles cmdSaveINH.Click
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                If XtraMessageBox.Show("Θέλετε να προχωρήσω στην δημιουργία εξόδων παραστατικών των πολυκατοικιών που είναι διαχειρίσης?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    Using oCmd As New SqlCommand("batch_create_ind", CNDB)
                        oCmd.CommandType = CommandType.StoredProcedure
                        oCmd.Parameters.AddWithValue("@RepName", cboRepname.Text)
                        oCmd.Parameters.AddWithValue("@CalcCatID", cboCalcCat.EditValue.ToString)
                        oCmd.Parameters.AddWithValue("@owner_tenant", cboOwnerTenant.SelectedIndex)
                        oCmd.Parameters.AddWithValue("@Paid", chkPaid.EditValue)
                        oCmd.Parameters.AddWithValue("@createdby", UserProps.ID.ToString)
                        oCmd.ExecuteNonQuery()
                    End Using
                    Me.Vw_IND_BATCHTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_BATCH)
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView5_ShownEditor(sender As Object, e As EventArgs) Handles GridView5.ShownEditor
        Dim view As ColumnView = DirectCast(sender, ColumnView)
        Try
            If GridView5.FocusedRowHandle < 0 Then Exit Sub
            Dim bdgID As String = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "bdgID").ToString()

            If view.FocusedColumn.FieldName = "calcCatID" And bdgID.Length > 0 Then
                Dim editor As LookUpEdit = CType(view.ActiveEditor, LookUpEdit)
                If bdgID.Length > 0 Then editor.Properties.DataSource = Me.Vw_CALC_CATTableAdapter.GetData(System.Guid.Parse(bdgID))

            ElseIf view.FocusedColumn.FieldName = "inhID" Then
                Dim editor As LookUpEdit = CType(view.ActiveEditor, LookUpEdit)
                If bdgID.Length > 0 Then
                    editor.Properties.DataSource = Me.Vw_INHNotCalculatedBYBDGTableAdapter.GetDataByBDG(System.Guid.Parse(bdgID))
                End If
            End If
        Catch ex As Exception
            'XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView5_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridView5.CustomDrawCell
        Dim GRD5 As GridView = sender
        If GRD5 Is Nothing Then Exit Sub
        If e.CellValue Is Nothing Then Exit Sub
        If e.Column.FieldName = "inhID" Then
            e.DisplayText = GRD5.GetRowCellValue(e.RowHandle, "completeDate").ToString()
        End If
    End Sub

    Private Sub RepINH_EditValueChanged(sender As Object, e As EventArgs) Handles RepINH.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim completeDate As String = ""
        If editor.EditValue Is Nothing Then GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "completeDate", "") : Exit Sub
        completeDate = editor.GetColumnValue("completeDate").ToString
        GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "completeDate", completeDate)
    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        Dim selectedRowHandles As Int32() = GridView5.GetSelectedRows()
        Dim I As Integer
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφούν η τρέχουσες εγγραφές?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                If GridView5.GetRowCellValue(selectedRowHandle, "ID") = Nothing Then Exit Sub
                sSQL = "DELETE FROM IND_BATCH WHERE ID = '" & GridView5.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next
            Me.Vw_IND_BATCHTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_BATCH)
            XtraMessageBox.Show("Η εγγραφές διαγράφηκαν με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Me.Vw_IND_BATCHTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_BATCH)
    End Sub

    Private Sub GridView5_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView5.ValidatingEditor

    End Sub

    Private Sub GridView5_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView5.ValidateRow
        Dim sSQL As New System.Text.StringBuilder
        Try
            sSQL.Clear()

            If GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "calcCatID").ToString = "" Then
                e.ErrorText = "Παρακαλώ επιλεξτε κατηγορία Χιλιοστών"
                e.Valid = False
                Exit Sub
            End If
            If GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "inhID").ToString = "" Then
                e.ErrorText = "Παρακαλώ επιλεξτε Παραστατικό"
                e.Valid = False
                Exit Sub
            End If
            If GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "amt").ToString = "" Then
                e.ErrorText = "Παρακαλώ πληκτρολογείστε ποσό"
                e.Valid = False
                Exit Sub
            End If

            sSQL.AppendLine("UPDATE ind_batch	SET calcCatID= " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "calcCatID").ToString) & ",")
            sSQL.AppendLine("inhID = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "inhID").ToString) & ",")
            sSQL.AppendLine("repName = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "repName").ToString) & ",")
            sSQL.AppendLine("owner_Tenant = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "owner_tenant").ToString) & ",")
            sSQL.AppendLine("Paid= " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "Paid").ToString) & ",")
            sSQL.AppendLine("amt = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "amt").ToString, True) & ",")
            sSQL.AppendLine("modifiedBY = " & toSQLValueS(UserProps.ID.ToString) & ",")
            sSQL.AppendLine("MachineName = " & toSQLValueS(UserProps.MachineName))
            sSQL.Append("WHERE ID = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString))
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
        Catch sqlEx As SqlException When sqlEx.Number = 2601
            XtraMessageBox.Show("Ύπάρχει ήδη εγγραφή καταχωρημένη με αυτά τα στοιχεία.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Valid = False
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView5_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView5.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView5, "vw_IND_BATCH.xml", "vw_IND_BATCH")
        ElseIf e.MenuType = GridMenuType.Row Then
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub frmBatchCreateIND_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdCreateIND_Click(sender As Object, e As EventArgs) Handles cmdCreateIND.Click
        Dim sSQL As New System.Text.StringBuilder
        Try
            sSQL.Clear()
            If XtraMessageBox.Show("Θέλετε να δημιουργηθούν τα έξοδα στα παραστατικά?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
            sSQL.AppendLine("INSERT INTO IND (ID,InhID,CalcCatID,repName,amt,owner_tenant,Paid,createdOn,createdBy,MachineName)")
            sSQL.AppendLine("SELECT ID,inhID,CalcCatID,repName,ISNULL(amt,0) AS amt,owner_tenant,Paid,createdOn,createdBy,MachineName")
            sSQL.AppendLine("FROM IND_BATCH")
            sSQL.AppendLine("WHERE amt<>0 and indCreated = 0 and CalcCatID IS NOT NULL AND InhID is Not Null")
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

            sSQL.Clear()
            sSQL.AppendLine("UPDATE IND_BATCH SET INDCREATED = 1")
            sSQL.AppendLine("WHERE indCreated = 0 and CalcCatID IS NOT NULL AND InhID is Not Null and amt <> 0")
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Me.Vw_IND_BATCHTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_BATCH)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BBOpenInh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBOpenInh.ItemClick
        Dim fINH As frmINH = New frmINH

        fINH.Text = "Κοινόχρηστα"
        fINH.ID = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "inhID").ToString
        fINH.MdiParent = frmMain
        fINH.Mode = FormMode.EditRecord
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
        fINH.Show()
    End Sub

    Private Sub BBOpenBdg_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBOpenBdg.ItemClick
        Dim fBDG As frmBDG = New frmBDG()
        fBDG.Text = "Πολυκατοικίες"
        fBDG.ID = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "bdgID").ToString
        fBDG.MdiParent = frmMain
        fBDG.Mode = FormMode.EditRecord
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fBDG), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
        fBDG.Show()
    End Sub

    Private Sub RepCalcCat_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepCalcCat.ButtonClick
        ' If e.Button.Index = 1 Then GridView5.ActiveEditor.EditValue = Nothing : 
    End Sub
End Class