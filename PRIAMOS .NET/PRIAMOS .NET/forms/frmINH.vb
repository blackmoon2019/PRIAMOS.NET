Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPivotGrid

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
                LayoutControlGroup2.Enabled = False
                cmdSaveInd.Enabled = False
            Case FormMode.EditRecord
                LoadForms.LoadFormGRP(LayoutControlGroup1, "Select * from vw_INH where id ='" + sID + "'")
                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
                Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
                EditRecord()
        End Select
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        My.Settings.frmINH = Me.Location
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
    Private Sub EditRecord()
        'Δημιουργία BANDS
        CreateBands()
        Dim myCmd As New SqlCommand
        myCmd.CommandText = "inv_Results"
        myCmd.Parameters.AddWithValue("@inhid", sID)
        myCmd.CommandType = CommandType.StoredProcedure
        myCmd.Connection = CNDB
        Dim myReader As SqlDataReader = myCmd.ExecuteReader()
        Dim dt As New DataTable("sTable")
        GridINH.Columns.Clear()
        dt.Load(myReader)
        GridControl2.DataSource = dt
        GridControl2.ForceInitialize()
        GridControl2.DefaultView.PopulateColumns()
        myReader.Close()
        TransposeColumns()
        GridINH.BestFitColumns()
    End Sub
    Private Sub CreateBands()
        'Dim sSQL As String
        'Dim cmd As SqlCommand
        'Dim sdr As SqlDataReader
        Try
            For i As Integer = 0 To GridView5.DataRowCount - 1

                Dim B As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                B.Caption = GridView5.GetRowCellDisplayText(i, "calcCatID")
                B.Name = GridView5.GetRowCellDisplayText(i, "calcCatID")
                B.AppearanceHeader.Options.UseTextOptions = True
                B.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                If CheckIfBandExists(B.Caption) = False Then GridINH.Bands.Add(B)
            Next              'cmd = New SqlCommand(sSQL, CNDB)
            ''sdr = cmd.ExecuteReader()
            ''GridINH.Bands.AddBand("ΔΙΑΜΕΡΙΣΜΑΤΑ")
            ''Dim Col As DevExpress.XtraGrid.Columns.GridColumn
            ''Col = GridINH.Columns("colaptNam")
            ''GridINH.Columns.Add(Col)

            'While sdr.Read()
            '    If sdr.IsDBNull(sdr.GetOrdinal("name")) = False Then GridINH.Bands.AddBand(sdr.GetString(sdr.GetOrdinal("name")))
            'End While
            'sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function CheckIfBandExists(ByVal Band As String) As Boolean
        For Each B As DevExpress.XtraGrid.Views.BandedGrid.GridBand In GridINH.Bands
            If B.Caption = Band Then Return True
        Next
        Return False

    End Function
    Private Sub TransposeColumns()
        Dim B As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GridINH.Bands.Item("apt")

        If B.Columns.Count = 0 Then Exit Sub
        For Each column As BandedGridColumn In B.Columns
            If column.ColIndex > 0 Then
                column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                column.SummaryItem.DisplayFormat = "Σύνολο {0:n2}€"
            End If
        Next column
        For i As Integer = 0 To GridView5.DataRowCount - 1
            B.Columns.Item("col" & GridView5.GetRowCellDisplayText(i, "repName").Replace(" ", "")).OwnerBand = GridINH.Bands.Item(GridView5.GetRowCellDisplayText(i, "calcCatID"))
        Next


    End Sub
    Private Sub frmINH_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
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
            EditRecord()
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

    Private Sub GridView5_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView5.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteRecord()
        End Select
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

    Private Sub GridView5_CustomDrawGroupRow(sender As Object, e As RowObjectCustomDrawEventArgs) Handles GridView5.CustomDrawGroupRow
        Dim info As GridGroupRowInfo = TryCast(e.Info, GridGroupRowInfo)
        If info.GroupValueText = "Checked" Then
            info.GroupText = "Ένοικος"
        Else
            info.GroupText = "Ιδιοκτήτης"
        End If
    End Sub



    Private Sub TabPane1_SelectedPageChanged(sender As Object, e As SelectedPageChangedEventArgs) Handles TabPane1.SelectedPageChanged
        If TabPane1.SelectedPageIndex = 0 Then cmdINDDel.Enabled = True Else cmdINDDel.Enabled = False

    End Sub
End Class