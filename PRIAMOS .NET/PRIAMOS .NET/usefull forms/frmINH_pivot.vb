Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPivotGrid

Public Class frmINH_pivot
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

        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_EXC' table. You can move, or remove it, as needed.
        'Me.Vw_EXCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_EXC)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)
        Select Case Mode
            Case FormMode.NewRecord

                txtCode.Text = DBQ.GetNextId("INH")
                LayoutControlGroup2.Enabled = False
                cmdSaveInd.Enabled = False
            Case FormMode.EditRecord
                LoadForms.LoadFormGRP(LayoutControlGroup1, "Select * from vw_INH where id ='" + sID + "'")
                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
                Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
                Me.Vw_CALC_CATTableAdapter.Fill(Me.Priamos_NETDataSet.vw_CALC_CAT, cboBDG.EditValue)
                PivotColumns()
        End Select
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        ' My.Settings.frmINH_pivot = Me.Location
        My.Settings.Save()
        dtFDate.Properties.Mask.EditMask = "Y"
        dtFDate.Properties.Mask.UseMaskAsDisplayFormat = True
        dtFDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
        dtTDate.Properties.Mask.EditMask = "Y"
        dtTDate.Properties.Mask.UseMaskAsDisplayFormat = True
        dtTDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
        lbldate.Text = TranslateDates(dtFDate, dtTDate)
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\INHDET_def.xml") Then GridView5.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\INHDET_def.xml", OptionsLayoutBase.FullLayout)
        cmdSaveINH.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub
    Private Sub PivotColumns()
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select distinct calcCatID from vw_INC where inhID = " & toSQLValueS(sID)
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            While sdr.Read()
                If sdr.IsDBNull(sdr.GetOrdinal("calcCatID")) = False Then
                    Select Case sdr.GetGuid(sdr.GetOrdinal("calcCatID")).ToString
                        Case "c8adcd0b-d8bc-4f68-b6bb-d5cbcb88b4b9" : PivotGridControl1.Fields("shared").Visible = True
                        Case "7fa0d7ba-2713-405c-8748-61dd8537a9cc" : PivotGridControl1.Fields("elevator").Visible = True
                        Case "8d47e8ab-3692-48f1-8cba-1e3f41afc13d" : PivotGridControl1.Fields("heating").Visible = True
                        Case "bbfda968-8c0c-431b-a804-ac8b8ca4b3d3" : PivotGridControl1.Fields("special_costs").Visible = True
                        Case "8d417a79-9757-4b18-8695-ae1bdf9416dd" : PivotGridControl1.Fields("owners").Visible = True
                        Case "9c3f4423-6fb6-44fd-a3c0-64e5d609c2cb" : PivotGridControl1.Fields("billing").Visible = True
                        Case "8d417a79-9757-4b18-8695-ae1bdf9416dd" : PivotGridControl1.Fields("garage").Visible = True
                        Case "3fe81416-ef7c-4d3b-b1ea-e4cc40350fde" : PivotGridControl1.Fields("monomers1").Visible = True
                        Case "ebd46c24-fbb0-47ad-a325-143c953a4ab4" : PivotGridControl1.Fields("monomers2").Visible = True
                        Case "2ae90ba0-dd3d-424d-9f6e-da7a9a518620" : PivotGridControl1.Fields("monomers3").Visible = True
                    End Select
                End If
            End While

            '    If PivotGridControl1.Cells.RowCount > 0 Then
            '    For i As Integer = 0 To PivotGridControl1.Cells.ColumnCount - 1
            '        Dim CellInfo As PivotCellEventArgs = PivotGridControl1.Cells.GetCellInfo(i, 0)
            '        For Each field As PivotGridField In PivotGridControl1.GetFieldsByArea(PivotArea.ColumnArea)
            '            Dim val As Object = CellInfo.GetFieldValue(field)
            '            Dim scalcCatID As String = Convert.ToString(val)
            '            Select Case scalcCatID
            '                Case "c8adcd0b-d8bc-4f68-b6bb-d5cbcb88b4b9" : PivotGridControl1.Fields("shared").Visible = True
            '                Case "7fa0d7ba-2713-405c-8748-61dd8537a9cc" : PivotGridControl1.Fields("elevator").Visible = True
            '                Case "8d47e8ab-3692-48f1-8cba-1e3f41afc13d" : PivotGridControl1.Fields("heating").Visible = True
            '                Case "bbfda968-8c0c-431b-a804-ac8b8ca4b3d3" : PivotGridControl1.Fields("special_costs").Visible = True
            '                Case "8d417a79-9757-4b18-8695-ae1bdf9416dd" : PivotGridControl1.Fields("owners").Visible = True
            '                Case "9c3f4423-6fb6-44fd-a3c0-64e5d609c2cb" : PivotGridControl1.Fields("billing").Visible = True
            '                Case "8d417a79-9757-4b18-8695-ae1bdf9416dd" : PivotGridControl1.Fields("garage").Visible = True
            '                Case "3fe81416-ef7c-4d3b-b1ea-e4cc40350fde" : PivotGridControl1.Fields("monomers1").Visible = True
            '                Case "ebd46c24-fbb0-47ad-a325-143c953a4ab4" : PivotGridControl1.Fields("monomers2").Visible = True
            '                Case "2ae90ba0-dd3d-424d-9f6e-da7a9a518620" : PivotGridControl1.Fields("monomers3").Visible = True
            '            End Select
            '        Next
            '    Next
            'End If
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'PivotGridControl1.Fields("repName").Visible = True
        'PivotGridControl1.Fields("calcCatID").Visible = False
        'If PivotGridControl1.Cells.RowCount > 0 Then
        '    For i As Integer = 0 To PivotGridControl1.Cells.ColumnCount - 1
        '        'Dim CellInfo As PivotCellEventArgs = PivotGridControl1.Cells.GetCellInfo(i, 0)
        '        Dim DS As PivotDrillDownDataSource
        '        DS = PivotGridControl1.CreateDrillDownDataSource(i, 0)
        '        Dim DSR As PivotDrillDownDataRow = DS(0)
        '        If Not DSR Is Nothing Then
        '            Dim scalcCatID As String = DSR.Item("calcCatID").ToString
        '            Select Case scalcCatID.ToUpper
        '                Case "c8adcd0b-d8bc-4f68-b6bb-d5cbcb88b4b9" : PivotGridControl1.Fields("shared").Visible = True
        '                Case "7fa0d7ba-2713-405c-8748-61dd8537a9cc" : PivotGridControl1.Fields("elevator").Visible = True
        '                Case "8d47e8ab-3692-48f1-8cba-1e3f41afc13d" : PivotGridControl1.Fields("heating").Visible = True
        '                Case "bbfda968-8c0c-431b-a804-ac8b8ca4b3d3" : PivotGridControl1.Fields("special_costs").Visible = True
        '                Case "8d417a79-9757-4b18-8695-ae1bdf9416dd" : PivotGridControl1.Fields("owners").Visible = True
        '                Case "9c3f4423-6fb6-44fd-a3c0-64e5d609c2cb" : PivotGridControl1.Fields("billing").Visible = True
        '                Case "8d417a79-9757-4b18-8695-ae1bdf9416dd" : PivotGridControl1.Fields("garage").Visible = True
        '                Case "3fe81416-ef7c-4d3b-b1ea-e4cc40350fde" : PivotGridControl1.Fields("monomers1").Visible = True
        '                Case "ebd46c24-fbb0-47ad-a325-143c953a4ab4" : PivotGridControl1.Fields("monomers2").Visible = True
        '                Case "2ae90ba0-dd3d-424d-9f6e-da7a9a518620" : PivotGridControl1.Fields("monomers3").Visible = True
        '            End Select
        '        End If
        '    Next i
        'End If
    End Sub
    Private Sub frmINH_pivot_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub chkEXP_ItemChecking(sender As Object, e As ItemCheckingEventArgs) Handles chkCALC_CAT.ItemChecking

    End Sub

    Private Sub cmdSaveINH_Click(sender As Object, e As EventArgs) Handles cmdSaveINH.Click
        Dim sResult As Boolean
        Dim sGuid As String
        Dim sSQL As String
        Try
            If Valid.ValidateFormGRP(LayoutControlGroup1) Then
                'Dim myLayoutControls As New List(Of Control)
                'myLayoutControls.Add(LayoutControl1BDG) : myLayoutControls.Add(LayoutControl3Heating)
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        Dim sCompleteDate As String = TranslateDates(dtFDate, dtTDate)
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.GroupLayoutControl, "INH",,, LayoutControlGroup1, sGuid, True, "completeDate", toSQLValueS(sCompleteDate))
                        If sResult Then
                            sSQL = "INSERT INTO IND (inhID, calcCatID, repName, amt, owner_tenant) " &
                                   "Select " & toSQLValueS(sGuid) & ",calcCatID,repName,amt,owner_tenant from iep where bdgID = " & toSQLValueS(cboBDG.EditValue.ToString)
                            Using oCmd As New SqlCommand(sSQL, CNDB)
                                oCmd.ExecuteNonQuery()
                            End Using
                            Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sGuid))
                        End If
                    Case FormMode.EditRecord
                        Dim sCompleteDate As String = TranslateDates(dtFDate, dtTDate)
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.GroupLayoutControl, "INH",,, LayoutControlGroup1, sID, True,,, "completeDate = " & toSQLValueS(sCompleteDate))
                End Select
                If sResult Then
                    If Mode = FormMode.NewRecord Then sID = sGuid
                    txtCode.Text = DBQ.GetNextId("INH")
                    Dim form As New frmScroller
                    form.LoadRecords("vw_INH")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                    LayoutControlGroup2.Enabled = True
                    cmdSaveInd.Enabled = True

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

    Private Sub GridView5_RowUpdated(sender As Object, e As RowObjectEventArgs)

    End Sub

    Private Sub GridView5_KeyDown(sender As Object, e As KeyEventArgs)
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdINDDel_Click(sender As Object, e As EventArgs) Handles cmdINDDel.Click
        DeleteRecord()
    End Sub

    Private Sub cmdINDRefresh_Click(sender As Object, e As EventArgs) Handles cmdINDRefresh.Click
        Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
    End Sub

    Private Sub GridView5_CustomDrawGroupRow(sender As Object, e As RowObjectCustomDrawEventArgs)
        Dim info As GridGroupRowInfo = TryCast(e.Info, GridGroupRowInfo)
        If info.GroupValueText = "Checked" Then
            info.GroupText = "Ένοικος"
        Else
            info.GroupText = "Ιδιοκτήτης"
        End If
    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue = Nothing Then Exit Sub
        If cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Then
            txtHeatingType.EditValue = cboBDG.GetColumnValue("HTYPE_Name")
        Else
            txtHeatingType.EditValue = Nothing
        End If
        If cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Then
            txtBoilerType.EditValue = cboBDG.GetColumnValue("BTYPE_Name")
        Else
            txtBoilerType.EditValue = Nothing
        End If
    End Sub

    Private Sub cboBDG_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboBDG.EditValue = Nothing : ManageBDG(cboBDG)
            Case 2 : If cboBDG.EditValue <> Nothing Then ManageBDG(cboBDG)
            Case 3 : cboBDG.EditValue = Nothing
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

    Private Sub cmdCalculate_Click(sender As Object, e As EventArgs) Handles cmdCalculate.Click
        Try
            Using oCmd As New SqlCommand("inv_Calculate", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@inhid", sID)
                oCmd.Parameters.AddWithValue("@bdgid", cboBDG.EditValue.ToString)
                oCmd.ExecuteNonQuery()
            End Using
            XtraMessageBox.Show("Ο υπολογισμός ολοκληρώθηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtFDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtFDate.EditValueChanged
        lbldate.Text = TranslateDates(dtFDate, dtTDate)
    End Sub

    Private Sub dtTDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtTDate.EditValueChanged
        lbldate.Text = TranslateDates(dtFDate, dtTDate)
    End Sub
End Class