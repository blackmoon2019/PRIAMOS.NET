Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmBatchCreateAnnments
    Private LoadForms As New FormLoader
    Private FillCbo As New FillCombos
    Private Sub dtFDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtFDate.EditValueChanged
        lbldate.Text = Convert.ToDateTime(dtFDate.EditValue).ToLongDateString
        If txtAfterDate.EditValue <> Nothing Then
            txtSample.EditValue = txtBefDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", "[]-[]") & txtAfterDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", Now.TimeOfDay.ToString)
        Else
            txtSample.EditValue = txtBefDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", "[]-[]")
        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmBatchCreateAnnments_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub frmBatchCreateAnnments_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.ANN_GRPS' table. You can move, or remove it, as needed.
        Me.ANN_GRPSTableAdapter.Fill(Me.Priamos_NETDataSet.ANN_GRPS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.ANN_GRPS' table. You can move, or remove it, as needed.
        'Me.ANN_GRPSTableAdapter.Fill(Me.Priamos_NETDataSet.ANN_GRPS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_INHNotCalculated' table. You can move, or remove it, as needed.
        Me.Vw_INHNotCalculatedTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INHNotCalculated)
        FillCbo.FillCheckedListANNGRPS(chkGroups, FormMode.NewRecord)
        dtFDate.EditValue = Date.Now
        lbldate.Text = Convert.ToDateTime(dtFDate.EditValue).ToLongDateString
        LoadForms.RestoreLayoutFromXml(GridView10, "vw_ANN_GRPS.xml")
        Me.CenterToScreen()
    End Sub

    Private Sub cboINH_EditValueChanged(sender As Object, e As EventArgs) Handles cboINH.EditValueChanged
        LoadInh()
    End Sub
    Private Sub LoadInh()
        Dim sSQL As New System.Text.StringBuilder
        Dim i As Integer = 0
        sSQL.Clear()
        sSQL.Append("SELECT * FROM VW_inh where annGroupID in(")
        For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In chkGroups.CheckedItems
            If i <> 0 Then sSQL.Append(",")
            sSQL.Append(toSQLValueS(item.Tag.ToString()))
            i = i + 1
        Next
        If i = 0 Then Exit Sub
        sSQL.Append(")")
        sSQL.Append(" and Calculated = 0 And reserveAPT = 0 And isManaged = 1 ")
        LoadForms.LoadDataToGrid(GridControl10, GridView10, sSQL.ToString)
        LoadForms.RestoreLayoutFromXml(GridView10, "vw_ANN_GRPS.xml")
    End Sub
    Private Sub txtBefDate_EditValueChanged(sender As Object, e As EventArgs) Handles txtBefDate.EditValueChanged
        txtSample.EditValue = txtBefDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", "[]-[]")
    End Sub

    Private Sub txtAfterDate_EditValueChanged(sender As Object, e As EventArgs) Handles txtAfterDate.EditValueChanged
        txtSample.EditValue = txtBefDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", "[]-[]") & txtAfterDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", Now.TimeOfDay.ToString)
    End Sub

    Private Sub GridView10_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView10.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView10, "vw_ANN_GRPS.xml",, "SELECT * FROM VW_INH")

    End Sub

    Private Sub chkGroups_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chkGroups.SelectedIndexChanged

    End Sub

    Private Sub cmdSaveANNGRP_Click(sender As Object, e As EventArgs) Handles cmdSaveANNGRP.Click
        Dim sSQL As String
        Dim sAnnouncment As String
        Dim sFTime As String, sTTime As String
        Try
            For i As Integer = 0 To GridView10.DataRowCount - 1
                sFTime = GridView10.GetRowCellValue(i, "tmIn").ToString : sTTime = GridView10.GetRowCellValue(i, "tmOut").ToString
                sAnnouncment = txtBefDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", sFTime & "-" & sTTime)
                sAnnouncment = sAnnouncment & txtAfterDate.Text
                If sAnnouncment = "" Then
                    sSQL = "UPDATE INH SET ANNOUNCEMENT = NULL WHERE ID = " & toSQLValueS(GridView10.GetRowCellValue(i, "ID").ToString)
                Else
                    sSQL = "UPDATE INH SET ANNOUNCEMENT = " & toSQLValueS(sAnnouncment) & " WHERE ID = " & toSQLValueS(GridView10.GetRowCellValue(i, "ID").ToString)
                End If

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next
            XtraMessageBox.Show("Η ενημέρωση ολοκληρώθηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadInh()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkGroups_SelectedValueChanged(sender As Object, e As EventArgs) Handles chkGroups.SelectedValueChanged
        LoadInh()
    End Sub
End Class