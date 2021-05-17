Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public Class frmINH
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Dim sGuid As String

    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
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
    Private Sub frmParast_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_CALC_CAT' table. You can move, or remove it, as needed.
        Me.Vw_CALC_CATTableAdapter.Fill(Me.Priamos_NETDataSet.vw_CALC_CAT)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_EXC' table. You can move, or remove it, as needed.
        'Me.Vw_EXCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_EXC)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)
        Select Case Mode
            Case FormMode.NewRecord

                txtCode.Text = DBQ.GetNextId("INH")

            Case FormMode.EditRecord
                LoadForms.LoadFormGRP(LayoutControlGroup1, "Select * from vw_INH where id ='" + sID + "'")
                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
        End Select
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        My.Settings.frmINH = Me.Location
        My.Settings.Save()
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\INHDET_def.xml") Then GridView5.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\INHDET_def.xml", OptionsLayoutBase.FullLayout)
        cmdSaveINH.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub frmINH_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub chkEXP_ItemChecking(sender As Object, e As ItemCheckingEventArgs) Handles chkCALC_CAT.ItemChecking

    End Sub

    Private Sub cmdSaveINH_Click(sender As Object, e As EventArgs) Handles cmdSaveINH.Click
        Dim sResult As Boolean
        Dim sGuid As String
        Try
            If Valid.ValidateFormGRP(LayoutControlGroup1) Then
                'Dim myLayoutControls As New List(Of Control)
                'myLayoutControls.Add(LayoutControl1BDG) : myLayoutControls.Add(LayoutControl3Heating)
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.GroupLayoutControl, "INH",,, LayoutControlGroup1, sGuid, True)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.GroupLayoutControl, "INH",,, LayoutControlGroup1, sID, True)
                End Select
                If sResult Then
                    If Mode = FormMode.NewRecord Then sID = sGuid
                    txtCode.Text = DBQ.GetNextId("INH")
                    Dim form As New frmScroller
                    form.LoadRecords("vw_INH")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdSaveInd_Click(sender As Object, e As EventArgs) Handles cmdSaveInd.Click
        Dim sResult As Boolean
        Dim sCalcCatID As String

        If Valid.ValidateFormGRP(LayoutControlGroup2) Then

            sCalcCatID = chkCALC_CAT.SelectedValue.ToString
            sResult = DBQ.InsertNewData(DBQueries.InsertMode.GroupLayoutControl, "IND",,, LayoutControlGroup2,,, "inhID,calcCatID ", toSQLValueS(sID) & "," & toSQLValueS(sCalcCatID))
            If sResult Then
                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cls.ClearGroupCtrls(LayoutControlGroup2)
                Valid.SChanged = False
            End If
        End If
    End Sub

    Private Sub GridView5_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView5.RowUpdated

    End Sub

    Private Sub GridView5_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView5.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteRecord()
        End Select


    End Sub
    Private Sub DeleteRecord()
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM IND WHERE ID = '" & GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString & "'"
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView5_FocusedRowLoaded(sender As Object, e As RowEventArgs) Handles GridView5.FocusedRowLoaded

    End Sub

    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView5.CellValueChanged
        Try
            Dim sSQL As String
            sSQL = "UPDATE [IND] SET calcCatID  = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "calcCatID").ToString) &
                    ",repName = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "repName").ToString) &
                    ",amt = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "amt"), True) &
                    ",owner_tenant = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "owner_tenant")) &
            " WHERE ID = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString)
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Private Sub cmdINDDel_Click(sender As Object, e As EventArgs) Handles cmdINDDel.Click
        DeleteRecord()
    End Sub

    Private Sub cmdINDRefresh_Click(sender As Object, e As EventArgs) Handles cmdINDRefresh.Click
        Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
    End Sub
End Class