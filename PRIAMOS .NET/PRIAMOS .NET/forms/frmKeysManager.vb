Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmKeysManager
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private ManageCbo As New CombosManager

    Private Sub frmKeysManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)
        Me.Vw_CCTTableAdapter.FillByAll(Me.Priamos_NETDataSet.vw_CCT)
        LoadForms.RestoreLayoutFromXml(GridView1, "BDGKeysManager_def.xml")
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sSQL As String
        Dim sManagerID As String
        Try
            If XtraMessageBox.Show("Θέλετε να  ενημερώσετε  τις επιλεγμένες Πολυκατοικίες?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
            Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                If GridView1.IsGroupRow(selectedRowHandle) = False Then
                    If cboKeysManager.Text = "" Then sManagerID = "NULL" Else sManagerID = toSQLValueS(cboKeysManager.EditValue.ToString)
                    sSQL = "UPDATE BDG SET KeyManagerID= " & sManagerID & " WHERE ID = " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using

                End If
            Next I
            XtraMessageBox.Show("Η ενημέρωση έγινε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cboKeysManager_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboKeysManager.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.KeysManager(cboKeysManager, FormMode.NewRecord)
            Case 2 : ManageCbo.KeysManager(cboKeysManager, FormMode.EditRecord)
            Case 3 : cboKeysManager.EditValue = Nothing
        End Select

    End Sub
    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView1, "BDGKeysManager_def.xml", "vw_BDG")
    End Sub

    Private Sub frmKeysManager_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If GridView1.IsGroupRow(GridView1.FocusedRowHandle) Then
            Exit Sub
        Else
            Dim fBDG As frmBDG = New frmBDG()
            fBDG.Text = "Πολυκατοικίες"
            fBDG.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
            fBDG.bManageID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bManageID").ToString
            fBDG.MdiParent = frmMain
            fBDG.Mode = FormMode.EditRecord
            fBDG.Scroller = GridView1
            fBDG.FormScroller = Me
            'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fBDG), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
            fBDG.Show()
        End If
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)
    End Sub
End Class