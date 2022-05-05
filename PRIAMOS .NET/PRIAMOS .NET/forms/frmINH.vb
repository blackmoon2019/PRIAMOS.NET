﻿
Imports System.Data.SqlClient
Imports DevExpress.Export
Imports DevExpress.Utils
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UI.CrossTab

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
    Private Sfilenames As String = ""

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
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_ANN_MENTS' table. You can move, or remove it, as needed.
        Me.Vw_ANN_MENTSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_ANN_MENTS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_TTL' table. You can move, or remove it, as needed.
        Me.Vw_TTLTableAdapter.Fill(Me.Priamos_NETDataSet.vw_TTL)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_EXC' table. You can move, or remove it, as needed.
        'Me.Vw_EXCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_EXC)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)


        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("INH")
                LayoutControlGroup2.Enabled = False
                cmdSaveInd.Enabled = False
                cmdCalculate.Enabled = False
                cmdDel.Enabled = False
                cmdRefresh.Enabled = False
            Case FormMode.EditRecord
                LoadForms.LoadFormGRP(LayoutControlGroup1, "Select * from vw_INH where id ='" + sID + "'")
                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
                Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
                Me.AHPB_HTableAdapter.Fill(Me.Priamos_NETDataSet.AHPB_H, cboBDG.EditValue)
                Me.AHPB_H1TableAdapter.Fill(Me.Priamos_NETDataSet.AHPB_H1, cboBDG.EditValue)
                Me.Vw_CALC_CATTableAdapter.Fill(Me.Priamos_NETDataSet.vw_CALC_CAT, cboBDG.EditValue)
                Me.Vw_INHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INH, cboBDG.EditValue)
                If cboAhpbH.EditValue IsNot Nothing Then cboAhpb.EditValue = cboAhpbH.EditValue
                EditRecord()
                'Χιλιοστά Διαμερισμάτων
                ApmLoad()
                lbldate.Text = TranslateDates(dtFDate, dtTDate)
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

        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\INHDET_def.xml") = False Then
            GridView5.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\INHDET_def.xml", OptionsLayoutBase.FullLayout)
        End If
        GridView5.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\INHDET_def.xml", OptionsLayoutBase.FullLayout)

        LoadConditionalFormatting()
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
                            GridControl1.DataSource = VwINDBindingSource
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
                    cmdDel.Enabled = True
                    cmdCalculate.Enabled = True
                    cmdRefresh.Enabled = True
                    TabNavigationPage3.Enabled = True
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadConditionalFormatting()
        Dim formatConditionRuleExpression As New StyleFormatCondition()
        formatConditionRuleExpression.Appearance.ForeColor = Color.Orange
        formatConditionRuleExpression.Appearance.Options.UseBackColor = True
        formatConditionRuleExpression.ApplyToRow = True
        formatConditionRuleExpression.Name = "Format0"
        formatConditionRuleExpression.Column = GridView5.Columns("SelectedFiles")
        formatConditionRuleExpression.Condition = FormatConditionEnum.Expression
        formatConditionRuleExpression.Expression = "Not IsNullOrEmpty([SelectedFiles])"
        GridView5.FormatConditions.Add(formatConditionRuleExpression)
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
    Private Sub DeleteIND_F(Optional ByVal Question As Boolean = True)
        Dim sSQL As String
        Try
            If Question Then
                If XtraMessageBox.Show("Θέλετε να διαγραφεί τα αρχεία άπό το επιλεγμένο έξοδο?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
                    Exit Sub
                End If
            End If

            sSQL = "DELETE FROM IND_F WHERE indID = '" & GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString & "'"
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Dim Column As GridColumn
            Column = GridView5.Columns.ColumnByName("colSelectedFiles")
            GridView5.SetRowCellValue(GridView5.FocusedRowHandle, Column, "")

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DeleteIND()
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM IND WHERE ID = '" & GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString & "'"
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                'Διαγραφή αρχείων αν υπάρχουν
                DeleteIND_F(False)
                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteINC()
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφεί o υπολογισμός?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM INC WHERE INHID = " & toSQLValueS(sID)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                sSQL = "UPDATE INH SET AHPB_HID=NULL,CALCULATED=0 WHERE ID = " & toSQLValueS(sID)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                If cboAhpbH.EditValue IsNot Nothing Then
                    sSQL = "UPDATE AHPB_H SET FINALIZED=0 WHERE ID = " & toSQLValueS(cboAhpbH.EditValue.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If
                EditRecord() : Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
                Me.AHPB_HTableAdapter.Fill(Me.Priamos_NETDataSet.AHPB_H, System.Guid.Parse(cboBDG.EditValue.ToString))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub cmdINDDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        Select Case TabPane1.SelectedPageIndex
            Case 0 : DeleteIND()
            Case 1 : DeleteINC()
            Case 2
            Case Else
        End Select

    End Sub

    Private Sub cmdINDRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Select Case TabPane1.SelectedPageIndex
            Case 0 : Me.Vw_INDTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND, System.Guid.Parse(sID))
            Case 1 : EditRecord() : Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
            Case 2 : ApmLoad()
            Case Else
        End Select

    End Sub
    Private Sub cboBDG_Validated(sender As Object, e As EventArgs) Handles cboBDG.Validated
        If cboBDG.EditValue = Nothing Then Exit Sub
        If cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Then
            txtHeatingType.EditValue = cboBDG.GetColumnValue("HTYPE_Name")
            txtHpc.EditValue = cboBDG.GetColumnValue("hpc")

            If Priamos_NETDataSet.AHPB_H.Rows.Count > 0 Then
                cboAhpb.ItemIndex = 0
                cboAhpb.Properties.ReadOnly = False

            ElseIf cboAhpb.Properties.DataSource.Count = 0 Then
                XtraMessageBox.Show("Δεν υπάρχουν καταχωρημένες ώρες", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'cmdOK.Enabled = False
            End If
        Else
            txtHeatingType.EditValue = Nothing
        End If
        If cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Then
            txtBoilerType.EditValue = cboBDG.GetColumnValue("BTYPE_Name")
        Else
            txtBoilerType.EditValue = Nothing
        End If
    End Sub
    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue = Nothing Then Exit Sub
        chkCALC_CAT.DataSource = VwCALCCATBindingSource
        'Me.AHPB_H1TableAdapter.Fill(Me.Priamos_NETDataSet.AHPB_H1, cboBDG.EditValue)
        Me.AHPB_HTableAdapter.Fill(Me.Priamos_NETDataSet.AHPB_H, cboBDG.EditValue)
        Me.Vw_CALC_CATTableAdapter.Fill(Me.Priamos_NETDataSet.vw_CALC_CAT, cboBDG.EditValue)
        If cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Then
            txtHeatingType.EditValue = cboBDG.GetColumnValue("HTYPE_Name")
            txtHpc.EditValue = cboBDG.GetColumnValue("hpc")
        Else
            txtHeatingType.EditValue = Nothing
            txtHpc.EditValue = Nothing
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
            Case 3 : cboBDG.EditValue = Nothing : chkCALC_CAT.DataSource = Nothing : chkCALC_CAT.Items.Clear()
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
            If (cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
                cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE") And cboAhpbH.EditValue Is Nothing Then
                LayoutControl1.Enabled = False
                FlyoutPanel1.OwnerControl = TabPane1
                FlyoutPanel1.OptionsBeakPanel.AnimationType = Win.PopupToolWindowAnimation.Fade
                'FlyoutPanel1.Options.CloseOnOuterClick = True
                FlyoutPanel1.Options.AnchorType = Win.PopupToolWindowAnchor.Center
                FlyoutPanel1.ShowPopup()
            Else
                Calculate()
                TabNavigationPage2.Enabled = True

            End If
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
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteIND()
        End Select
    End Sub

    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView5.CellValueChanged
        Try
            Dim sSQL As String
            sSQL = "UPDATE [IND] SET calcCatID  = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "calcCatID").ToString) &
                ",repName = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "repName").ToString) &
                ",amt = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "amt"), True) &
                ",owner_tenant = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "owner_tenant")) &
                ",SelectedFiles = " & toSQLValueS(IIf(IsDBNull(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "SelectedFiles")) = True, "", GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "SelectedFiles"))) &
                ",paid = " & IIf(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "paid") = True, 1, 0) &
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
        Select Case TabPane1.SelectedPageIndex
            Case 0 : cmdDel.Enabled = True
            Case 1 : cmdDel.Enabled = True
            Case 2 : ApmLoad()        'Χιλιοστά Διαμερισμάτων

            Case Else : cmdDel.Enabled = False
        End Select
    End Sub

    Private Sub ApmLoad()
        Try
            Dim sSQL As String
            Dim sSQL2 As String



            sSQL = "SELECT * from vw_APMIL where bdgid = " & toSQLValueS(cboBDG.EditValue.ToString) & " order by ORD"
            sSQL2 = "SELECT * from vw_APMIL_D where bdgid = " & toSQLValueS(cboBDG.EditValue.ToString) & " order by ORD"
            Dim AdapterMaster As New SqlDataAdapter(sSQL, CNDB)
            Dim AdapterDetail As New SqlDataAdapter(sSQL2, CNDB)
            Dim sdataSet As New DataSet()
            AdapterMaster.Fill(sdataSet, "vw_APMIL")
            AdapterDetail.Fill(sdataSet, "vw_APMIL_D")
            Dim keyColumn As DataColumn = sdataSet.Tables("vw_APMIL").Columns("ID")
            Dim foreignKeyColumn As DataColumn = sdataSet.Tables("vw_APMIL_D").Columns("ID")
            sdataSet.Relations.Add("ΧΙΛΙΟΣΤΑ ΜΕ ΜΕΙΩΣΕΙΣ", keyColumn, foreignKeyColumn)
            GridView1.Columns.Clear()
            GridView7.Columns.Clear()
            grdAPM.DataSource = sdataSet.Tables("vw_APMIL")
            grdAPM.ForceInitialize()

            'LoadForms.LoadDataToGrid(grdAPM, GridView5, "SELECT * from vw_APMIL where bdgid = '" & sID & "' order by ORD")
            'LoadForms.LoadDataToGrid(grdAPM, GridView7, "SELECT * from vw_APMIL_D where bdgid = '" & sID & "' order by ORD")
            'Φορτώνει όλες τις ονομασίες των στηλών από τον SQL. Από το πεδίο Description
            LoadForms.LoadColumnDescriptionNames(grdAPM, GridView1, , "vw_APMIL")
            LoadForms.LoadColumnDescriptionNames(grdAPM, GridView7, , "vw_APMIL_D")
            LoadForms.RestoreLayoutFromXml(GridView1, "APMIL_def.xml")
            LoadForms.RestoreLayoutFromXml(GridView7, "APMIL_D_def.xml")
            GridView1.OptionsCustomization.AllowSort = False

            'GridView1.Columns("AptNam").OptionsColumn.ReadOnly = True
            'GridView1.Columns("AptNam").OptionsColumn.AllowEdit = False
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboRepname_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboRepname.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboRepname.EditValue = Nothing : ManageTTL()
            Case 2 : If cboRepname.EditValue <> Nothing Then ManageTTL()
            Case 3 : cboRepname.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageTTL()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Λεκτικά Εκτυπώσεων"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Λεκτικό"
        form1.DataTable = "TTL"
        form1.CalledFromControl = True
        form1.CallerControl = cboRepname
        form1.CallerForm = Me
        form1.MdiParent = frmMain
        If cboRepname.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboRepname.GetColumnValue("ID").ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub Calculate()
        Try
            Dim sAhpbID As String
            Using oCmd As New SqlCommand("inv_Calculate", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@inhid", sID.ToUpper)
                oCmd.Parameters.AddWithValue("@bdgid", cboBDG.EditValue.ToString.ToUpper)
                ' Εαν είναι νέα εγγραφή τότε παίρνω την τιμή της ώρας από το Combo στο FlyoutPanel
                If (cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
                    cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE") And cboAhpbH.EditValue Is Nothing Then
                    If cboAhpb.EditValue Is Nothing Then sAhpbID = "00000000-0000-0000-0000-000000000000" Else sAhpbID = cboAhpb.EditValue.ToString.ToUpper
                Else
                    ' Παίρνω την τιμή της ώρας από το Combo των ωρών που έχει φορτωθεί με το παραστατικό
                    If cboAhpbH.EditValue Is Nothing Then sAhpbID = "00000000-0000-0000-0000-000000000000" Else sAhpbID = cboAhpbH.EditValue.ToString.ToUpper
                End If
                oCmd.Parameters.AddWithValue("@ahpbHID", System.Guid.Parse(sAhpbID))
                oCmd.ExecuteNonQuery()
            End Using
            XtraMessageBox.Show("Ο υπολογισμός ολοκληρώθηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EditRecord()
            Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        FlyoutPanel1.HidePopup()
        LayoutControl1.Enabled = True
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        FlyoutPanel1.HidePopup()
        Calculate()
        Me.AHPB_H1TableAdapter.Fill(Me.Priamos_NETDataSet.AHPB_H1, cboBDG.EditValue)
        cboAhpbH.EditValue = cboAhpb.EditValue
        LayoutControl1.Enabled = True
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Select Case TabPane1.SelectedPageIndex
            Case 0 : ExportGrid(0, "Έξοδα")
            Case 1 : ExportGrid(1, "Υπολογισμένα")
            Case 2 : ExportGrid(2, "Χιλιοστά")
            Case Else
        End Select

    End Sub
    Private Sub ExportGrid(ByVal grdMode As Integer, ByVal fName As String)
        Dim options = New XlsxExportOptionsEx()
        options.UnboundExpressionExportMode = UnboundExpressionExportMode.AsFormula
        options.ExportType = ExportType.WYSIWYG
        XtraSaveFileDialog1.Filter = "XLSX Files (*.xlsx*)|*.xlsx"
        XtraSaveFileDialog1.FileName = fName
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Select Case grdMode
                Case 0 : GridView5.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
                Case 1 : GridINH.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
                Case 2 : GridView7.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
            End Select

            Process.Start(XtraSaveFileDialog1.FileName)
        End If
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

    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If e.SelectedControl Is cboAnnouncements Then
            If cboAnnouncements.CalcBestSize().Width > cboAnnouncements.Width Then
                e.Info = New ToolTipControlInfo(cboAnnouncements, cboAnnouncements.EditValue)
            End If
        End If
    End Sub


    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim report As New Rep_Sygentrotiki()
        report.Parameters.Item(0).Value = sID
        report.Parameters.Item(1).Value = cboBDG.EditValue
        SplashScreenManager1.ShowWaitForm()
        SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")
        report.CreateDocument()

        Dim printTool As New ReportPrintTool(report)
        printTool.ShowRibbonPreview()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim report As New Eidop()
        report.Parameters.Item(0).Value = sID
        ' report.Parameters.Item(1).Value = cboBDG.EditValue
        SplashScreenManager1.ShowWaitForm()
        SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")
        report.CreateDocument()

        Dim printTool As New ReportPrintTool(report)
        printTool.ShowRibbonPreview()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RepositoryItemLookUpEdit3_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemLookUpEdit3.ButtonClick
        Select Case e.Button.Index
            Case 1 : FilesSelection()
            Case 2
                SplashScreenManager1.ShowWaitForm()
                SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")
                OpenPreviwer()
            Case 3 : If UserProps.AllowDelete = True Then DeleteIND_F()
        End Select
    End Sub
    Private Sub OpenPreviwer()
        Dim frmFilePreviwer As New frmFilePreviwer
        frmFilePreviwer.Text = "Προβολή Αρχείων"
        frmFilePreviwer.ID = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString
        frmFilePreviwer.Spl = SplashScreenManager1
        frmFilePreviwer.ShowDialog()
    End Sub
    Private Sub FilesSelection()

        XtraOpenFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf"
        XtraOpenFileDialog1.FilterIndex = 1
        XtraOpenFileDialog1.InitialDirectory = ProgProps.EXFolderPath
        XtraOpenFileDialog1.Title = "Open File"
        XtraOpenFileDialog1.CheckFileExists = False
        XtraOpenFileDialog1.Multiselect = True
        Dim result As DialogResult = XtraOpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Dim Column As GridColumn
            Column = GridView5.Columns.ColumnByName("colSelectedFiles")
            Column.OptionsColumn.AllowEdit = False
            Sfilenames = ""
            For I = 0 To XtraOpenFileDialog1.FileNames.Count - 1
                Sfilenames = Sfilenames & IIf(Sfilenames <> "", ";", "") & XtraOpenFileDialog1.FileNames(I)
                GridView5.SetRowCellValue(GridView5.FocusedRowHandle, Column, Sfilenames)
            Next I
            ' Αποθήκευση Αρχείων
            DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "IND_F", GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString)

        End If
    End Sub

    Private Sub GridView5_PopupMenuShowing(sender As Object, e As Views.Grid.PopupMenuShowingEventArgs) Handles GridView5.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()

            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChanged, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex

                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItem("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChanged, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveView, Nothing, Nothing, Nothing, Nothing))

            End If
        End If

    End Sub

    'Μετονομασία Στήλης Master
    Private Sub OnEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView5.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Function CreateCheckItem(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView5.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Κλείδωμα Στήλης Master
    Private Sub OnCanMoveItemClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    'Αποθήκευση όψης 
    Private Sub OnSaveView(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView5.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\INHDET_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Friend Class MenuColumnInfo
        Public Sub New(ByVal column As GridColumn)
            Me.Column = column
        End Sub
        Public Column As GridColumn
    End Class

    Private Sub cmdNewInh_Click(sender As Object, e As EventArgs) Handles cmdNewInh.Click
        Mode = FormMode.NewRecord
        Cls.ClearGroupCtrls(LayoutControlGroup1) : Cls.ClearGroupCtrls(LayoutControlGroup2)
        txtCode.Text = DBQ.GetNextId("INH")
        LayoutControlGroup2.Enabled = False
        cmdSaveInd.Enabled = False
        cmdCalculate.Enabled = False
        cmdDel.Enabled = False
        chkCALC_CAT.DataSource = Nothing
        chkCALC_CAT.Items.Clear()
        TabNavigationPage2.Enabled = False
        TabNavigationPage3.Enabled = False
        GridControl1.DataSource = Nothing
    End Sub

    Private Sub RepositoryItemLookUpEdit2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemLookUpEdit2.ButtonClick
        Select Case e.Button.Index
            Case 1 : FilesSelection()
            Case 2
                SplashScreenManager1.ShowWaitForm()
                SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")
                OpenPreviwer()
            Case 3 : If UserProps.AllowDelete = True Then DeleteIND_F()
        End Select
    End Sub

    Private Sub TabPane1_SelectedPageChanging(sender As Object, e As SelectedPageChangingEventArgs) Handles TabPane1.SelectedPageChanging
        If e.Page.Enabled = False Then e.Cancel = True
    End Sub



    'Μετονομασία Στήλης Master
    Private Sub OnEditValueChanged2(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView1.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Function CreateCheckItem2(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChanged2(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView1.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Κλείδωμα Στήλης Master
    Private Sub OnCanMoveItemClick2(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    'Αποθήκευση όψης 
    Private Sub OnSaveView2(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\APMIL_def.xml", OptionsLayoutBase.FullLayout)
        GridView7.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\APMIL_D_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If UserProps.ID.ToString.ToUpper = "E9CEFD11-47C0-4796-A46B-BC41C4C3606B" Or
           UserProps.ID.ToString.ToUpper = "526EAA73-3B21-4BEE-A575-F19BD2BC5FCF" Or
           UserProps.ID.ToString.ToUpper = "97E2CB01-93EA-4F97-B000-FDA359EC943C" Then
            If XtraMessageBox.Show("Θέλετε να γίνει κοινοποίηση της όψης? Εαν επιλέξετε 'Yes' όλοι οι χρήστες θα έχουν την ίδια όψη", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If My.Computer.FileSystem.FileExists(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_def.xml") = False Then GridView1.OptionsLayout.LayoutVersion = "v1"
                If My.Computer.FileSystem.FileExists(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml") = False Then GridView7.OptionsLayout.LayoutVersion = "v1"
                GridView1.SaveLayoutToXml(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_def.xml", OptionsLayoutBase.FullLayout)
                GridView7.SaveLayoutToXml(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml", OptionsLayoutBase.FullLayout)
            End If
        End If
    End Sub
    'Συγχρονισμός όψης από Server
    Private Sub OnSyncView2(ByVal sender As System.Object, ByVal e As EventArgs)
        If XtraMessageBox.Show("Θέλετε να γίνει μεταφορά της όψης από τον server?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            ' Έλεγχος αν υπάρχει όψη με μεταγενέστερη ημερομηνία στον Server
            If System.IO.File.Exists(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_def.xml") = True Then
                My.Computer.FileSystem.CopyFile(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_def.xml", Application.StartupPath & "\DSGNS\DEF\APMIL_def.xml", True)
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\APMIL_def.xml", OptionsLayoutBase.FullLayout)
            End If
            If System.IO.File.Exists(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml") = True Then
                My.Computer.FileSystem.CopyFile(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml", Application.StartupPath & "\DSGNS\DEF\APMIL_D_def.xml", True)
                GridView7.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\APMIL_D_def.xml", OptionsLayoutBase.FullLayout)
            End If

        End If
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()

            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChanged2, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex

                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItem2("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChanged2, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveView2, Nothing, Nothing, Nothing, Nothing))
                '5nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Συγχρονισμός όψης από Server", AddressOf OnSyncView2, Nothing, Nothing, Nothing, Nothing))


            End If
        End If
    End Sub

    Private Sub cboBDG_RightToLeftChanged(sender As Object, e As EventArgs) Handles cboBDG.RightToLeftChanged

    End Sub
End Class