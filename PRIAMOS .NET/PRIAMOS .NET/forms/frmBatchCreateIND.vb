Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmBatchCreateIND
    Private ManageCbo As New CombosManager
    Private Valid As New ValidateControls
    Private Sub frmBachCreateIND_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_INH.vw_INHNotCalculated' table. You can move, or remove it, as needed.
        Me.Vw_INHNotCalculatedTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_INHNotCalculated)
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_INH.vw_IND_BATCH' table. You can move, or remove it, as needed.
        Me.Vw_IND_BATCHTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_BATCH)
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_INH.vw_TTL' table. You can move, or remove it, as needed.
        Me.Vw_TTLTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_TTL)
        Me.Vw_CALC_CATTableAdapter.FillByAll(Me.Priamos_NET_DataSet_INH.vw_CALC_CAT)

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
                        oCmd.Parameters.AddWithValue("@createdby", UserProps.ID.ToString)
                        oCmd.ExecuteNonQuery()
                    End Using
                    Me.Vw_IND_BATCHTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND_BATCH)
                    'XtraMessageBox.Show("Τα έξοδα δημιουργήθηκαν με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
End Class