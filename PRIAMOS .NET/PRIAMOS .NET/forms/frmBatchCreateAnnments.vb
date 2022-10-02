Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmBatchCreateAnnments
    Private LoadForms As New FormLoader
    Private FillCbo As New FillCombos
    Private Valid As New ValidateControls
    Private Sub dtFDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtFDate.EditValueChanged
        lbldate.Text = Convert.ToDateTime(dtFDate.EditValue).ToLongDateString
        If txtBefDate.EditValue <> Nothing Then txtSample.EditValue = txtBefDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", "[]-[]")
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmBatchCreateAnnments_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub frmBatchCreateAnnments_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_ANN_MENTS' table. You can move, or remove it, as needed.
        Me.Vw_ANN_MENTSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_ANN_MENTS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.ANN_GRPS' table. You can move, or remove it, as needed.
        Me.ANN_GRPSTableAdapter.Fill(Me.Priamos_NETDataSet.ANN_GRPS)
        FillCbo.FillCheckedListANNGRPS(chkGroups, FormMode.NewRecord)
        FillCbo.FillINHNotCalculated(chkNotCalcInv, FormMode.NewRecord)
        cboAnnouncements.EditValue = Guid.Parse(ProgProps.ANNMENT)
        dtFDate.EditValue = Date.Now
        lbldate.Text = Convert.ToDateTime(dtFDate.EditValue).ToLongDateString
        LoadForms.RestoreLayoutFromXml(GridView10, "vw_ANN_GRPS.xml")
        Me.CenterToScreen()
    End Sub

    Private Sub cboINH_EditValueChanged(sender As Object, e As EventArgs)
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
        If i = 0 Then
            LoadForms.LoadDataToGrid(GridControl10, GridView10, "SELECT * FROM VW_inh where 1=0")
            LoadForms.RestoreLayoutFromXml(GridView10, "vw_ANN_GRPS.xml")
            Exit Sub
        End If
        sSQL.Append(") ")
        If chkNotCalcInv.CheckedItemsCount > 0 Then
            sSQL.Append(" and completedate in( ")

            i = 0
            For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In chkNotCalcInv.CheckedItems
                If i <> 0 Then sSQL.Append(",")
                sSQL.Append(toSQLValueS(item.Tag.ToString()))
                i = i + 1
            Next

            sSQL.Append(") ")
        End If
        'If cboINH.EditValue <> Nothing Then sSQL.Append(" and completedate = " & toSQLValueS(cboINH.Text.ToString))
        sSQL.Append(" and Calculated = 0 And reserveAPT = 0 And isManaged = 1 ")
        LoadForms.LoadDataToGrid(GridControl10, GridView10, sSQL.ToString)
        LoadForms.RestoreLayoutFromXml(GridView10, "vw_ANN_GRPS.xml")
    End Sub
    Private Sub txtBefDate_EditValueChanged(sender As Object, e As EventArgs) Handles txtBefDate.EditValueChanged
        If txtBefDate.EditValue = Nothing Then Exit Sub
        txtSample.EditValue = txtBefDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", "[]-[]")
    End Sub

    Private Sub txtAfterDate_EditValueChanged(sender As Object, e As EventArgs)
        txtSample.EditValue = txtBefDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", "[]-[]")
    End Sub

    Private Sub GridView10_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView10.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView10, "vw_ANN_GRPS.xml",, "SELECT * FROM VW_INH")

    End Sub



    Private Sub cmdSaveANNGRP_Click(sender As Object, e As EventArgs) Handles cmdSaveANNGRP.Click
        Dim sSQL As String
        Dim sAnnouncment As String
        Dim sFTime As String, sTTime As String
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                If txtBefDate.EditValue = Nothing Then txtBefDate.EditValue = ""
                For i As Integer = 0 To GridView10.DataRowCount - 1
                    sFTime = GridView10.GetRowCellValue(i, "tmIn").ToString : sTTime = GridView10.GetRowCellValue(i, "tmOut").ToString
                    sAnnouncment = txtBefDate.EditValue.ToString.Replace("[DATE]", lbldate.Text).Replace("[TIME]", sFTime & "-" & sTTime)
                    If sAnnouncment = "" Then
                        sSQL = "UPDATE INH SET modifiedBY = " & toSQLValueS(UserProps.ID.ToString) & ",modifiedOn=getdate(), COLANNOUNCEMENT = NULL WHERE ID = " & toSQLValueS(GridView10.GetRowCellValue(i, "ID").ToString)
                    Else
                        sSQL = "UPDATE INH SET modifiedBY = " & toSQLValueS(UserProps.ID.ToString) & ",modifiedOn=getdate(), COLANNOUNCEMENT = " & toSQLValueS(sAnnouncment) & " WHERE ID = " & toSQLValueS(GridView10.GetRowCellValue(i, "ID").ToString)
                    End If

                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                Next
                XtraMessageBox.Show("Η ενημέρωση ολοκληρώθηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadInh()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub chkGroups_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chkGroups.ItemCheck
        LoadInh()
    End Sub

    Private Sub GridView10_DoubleClick(sender As Object, e As EventArgs) Handles GridView10.DoubleClick
        If GridView10.IsGroupRow(GridView10.FocusedRowHandle) Then Exit Sub
        Dim fINH As frmINH = New frmINH()
        fINH.Text = "Παραστατικό"
        fINH.ID = GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "ID").ToString
        fINH.MdiParent = frmMain
        fINH.Mode = FormMode.EditRecord
        fINH.Scroller = GridView10
        fINH.FormScroller = Me
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(fINH.Parent.ClientRectangle.Width / 2 - fINH.Width / 2), CInt(fINH.Parent.ClientRectangle.Height / 2 - fINH.Height / 2)))
        fINH.Show()
    End Sub
    Private Sub cboAnnouncements_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboAnnouncements.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboAnnouncements.EditValue = Nothing : ManageAnnouncements()
            Case 2 : If cboAnnouncements.EditValue <> Nothing Then ManageAnnouncements()
            Case 3 : cboAnnouncements.EditValue = Nothing
        End Select
    End Sub

    Private Sub ManageAnnouncements()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Ανακοινώσεις"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Ανακοίνωση"
        form1.DataTable = "ANN_MENTS"
        form1.CalledFromControl = True
        form1.CallerControl = cboAnnouncements
        form1.CallerForm = Me
        form1.MdiParent = frmMain
        If cboAnnouncements.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            If cboAnnouncements.GetColumnValue("ID") Is Nothing Then Exit Sub
            form1.ID = cboAnnouncements.GetColumnValue("ID").ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub ' ...
    Private Sub cboAnnouncements_EditValueChanged(sender As Object, e As EventArgs) Handles cboAnnouncements.EditValueChanged
        txtBefDate.EditValue = cboAnnouncements.Text

    End Sub

    Private Sub chkNotCalcInv_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chkNotCalcInv.ItemCheck
        LoadInh()
    End Sub
End Class