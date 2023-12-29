
Imports System.Data.SqlClient
Imports DevExpress.Export
Imports DevExpress.LookAndFeel
Imports DevExpress.Spreadsheet
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
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI

Public Class frmINH
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private ManageCbo As New CombosManager
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Private INH As New INH
    Private InhFieldAndValues As Dictionary(Of String, String)
    Dim sGuid As String
    Private Sfilenames As String = ""
    Private fdate As Date
    Private Tdate As Date

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
        Try
            'TODO: This line of code loads data into the 'Priamos_NET_DataSet_INH.vw_ANN_MENTS' table. You can move, or remove it, as needed.
            Me.Vw_ANN_MENTSTableAdapter1.Fill(Me.Priamos_NET_DataSet_INH.vw_ANN_MENTS)
            'TODO: This line of code loads data into the 'Priamos_NET_DataSet_INH.vw_TTL' table. You can move, or remove it, as needed.
            Me.Vw_TTLTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_TTL)
            'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_ANN_MENTS' table. You can move, or remove it, as needed.
            Me.Vw_ANN_MENTSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_ANN_MENTS)
            'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_TTL' table. You can move, or remove it, as needed.
            Me.Vw_TTLTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_TTL)
            'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_EXC' table. You can move, or remove it, as needed.
            'Me.Vw_EXCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_EXC)
            'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
            Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)


            Select Case Mode
                Case FormMode.NewRecord
                    txtCode.Text = DBQ.GetNextId("INH")
                    TextEdit1.Enabled = False
                    LayoutControlGroup2.Enabled = False
                    cmdSaveInd.Enabled = False
                    LcmdCalculate.Enabled = False
                    cmdDel.Enabled = False
                    cmdRefresh.Enabled = False
                    LcmdCancelInvoice.Enabled = False
                    lCanceled.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    lbldate.Text = ""
                    cmdPrintAll.Enabled = False
                    cmdSaveINH.Enabled = UserProps.AllowInsert
                    cboBDG.Select()
                    SetBdgFieldsValues()
                Case FormMode.EditRecord
                    InhFieldAndValues = New Dictionary(Of String, String)
                    LoadForms.LoadForm(LayoutControl1, "Select * from vw_INH where id = " & toSQLValueS(sID), False, InhFieldAndValues)
                    Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
                    Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))

                    ' Στην περίπτωση που έχει πάγιο τιμολόγιο κατανάλωσης φυσικού αερίου τότε καθαρίζουμε τις ώρες
                    If CheckIfHasGasFixedInvoices(0) = False Then cboAhpbH.DataBindings.Clear()
                    If CheckIfHasGasFixedInvoices(1) = False Then cboAhpbHB.DataBindings.Clear()

                    If InhFieldAndValues.Item("mdt") <> "" And chkCalculated.Checked = True Then
                        lblInf.Text = "Το παραστατικό υπολογίσθηκε με ώρες θέρμανσης: " & CDate(InhFieldAndValues.Item("mdt")).ToString("dd/MM/yyyy")
                        cboAhpbH.EditValue = System.Guid.Parse(InhFieldAndValues.Item("ahpb_HID"))
                        If cboAhpbH.Text = "" Then cboAhpbH.EditValue = Nothing
                    End If
                    If InhFieldAndValues.Item("mdtBoiler") <> "" And chkCalculated.Checked = True Then
                        lblInf2.Text = "Το παραστατικό υπολογίσθηκε με ώρες Boiler: " & CDate(InhFieldAndValues.Item("mdtBoiler")).ToString("dd/MM/yyyy")
                        cboAhpbHB.EditValue = System.Guid.Parse(InhFieldAndValues.Item("ahpb_HIDB"))
                        If cboAhpbHB.Text = "" Then cboAhpbHB.EditValue = Nothing
                    End If
                    If InhFieldAndValues.Item("OilInvDate") <> "" And chkCalculated.Checked = True Then
                        lblInf3.Text = "Το παραστατικό υπολογίσθηκε με το/τα τιμολόγιο/α Πετρελάιου: " & InhFieldAndValues.Item("OilInvDate").ToString()
                        If cboInvOil.Text = "" Then cboInvOil.EditValue = Nothing
                    End If
                    If InhFieldAndValues.Item("GasInvDate") <> "" And chkCalculated.Checked = True Then
                        lblInf4.Text = "Το παραστατικό υπολογίσθηκε με το/τα τιμολόγιο/α Φυσικού Αερίου: " & InhFieldAndValues.Item("GasInvDate").ToString()
                        If cboInvGas.Text = "" Then cboInvGas.EditValue = Nothing
                    End If

                    If cboInvOil.Properties.GetItems.Count <> 0 Or cboInvGas.Properties.GetItems.Count <> 0 Then
                        If cboInvOil.Properties.GetItems.Count <> 0 Then cboInvOil.BackColor = Color.Coral
                        If cboInvGas.Properties.GetItems.Count <> 0 Then cboInvGas.BackColor = Color.Coral

                        Dim cmd As SqlCommand = New SqlCommand("Select 1 as sKey,invOilID as invOilGasID from IND 
                                                                inner join INH   ON INH.id = IND.inhID where calculated= 0 and 
                                                                invOilID is not null and inhID = " & toSQLValueS(sID) &
                                                    "UNION      Select 2 as sKey,invGasID as invOilGasID 
                                                                from IND inner join INH   ON INH.id = IND.inhID where calculated= 0 and 
                                                                invGasID is not null and inhID = " & toSQLValueS(sID), CNDB)
                        Dim sdr As SqlDataReader = cmd.ExecuteReader()
                        If sdr.HasRows Then
                            While sdr.Read()
                                Select Case sdr("sKey")
                                    Case "1" : If sdr("invOilGasID").ToString <> "" Then cboInvOil.Properties.GetItems.Item(System.Guid.Parse(sdr("invOilGasID").ToString)).CheckState = CheckState.Checked
                                    Case "2" : If sdr("invOilGasID").ToString <> "" Then cboInvGas.Properties.GetItems.Item(System.Guid.Parse(sdr("invOilGasID").ToString)).CheckState = CheckState.Checked
                                End Select
                            End While
                        End If
                        sdr.Close()
                    Else
                        cboInvOil.BackColor = Color.White : cboInvGas.BackColor = Color.White

                    End If



                    'lbldate.Text = TranslateDates(dtFDate, dtTDate)
                    Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NET_DataSet_INH.vw_INH, System.Guid.Parse(cboBDG.EditValue.ToString))
                    DataNavigator1.Position = SetNavigatorPosition()
                    If lblCancel.Text = "True" Then
                        lblCancel.Text = "ΑΚΥΡΩΜΕΝΟ"
                        lCanceled.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                        LcmdSaveINH.Enabled = False : LcmdCancelInvoice.Enabled = False : LcmdCalculate.Enabled = False : LcmdSaveInd.Enabled = False : GridView5.OptionsBehavior.Editable = False
                    Else
                        lCanceled.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        LcmdSaveINH.Enabled = True : LcmdCalculate.Enabled = True : LcmdSaveInd.Enabled = True : GridView5.OptionsBehavior.Editable = True
                        'cmdCancelInvoice.Enabled = True
                    End If
                    Me.Text = "Παραστατικό - " & cboBDG.Text
                    If chkCalculated.CheckState = CheckState.Checked Then cmdSaveInd.Enabled = False : cmdDel.Enabled = False : cmdSaveINH.Enabled = False
                    fdate = Date.Parse(dtFDate.EditValue.ToString) : Tdate = Date.Parse(dtTDate.EditValue.ToString)

            End Select
            '  Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
            Me.CenterToScreen()
            dtFDate.Properties.Mask.EditMask = "Y"
            dtFDate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtFDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
            dtTDate.Properties.Mask.EditMask = "Y"
            dtTDate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtTDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView

            LoadForms.RestoreLayoutFromXml(GridView5, "INHDET_def.xml")
            If chkCalculated.Checked = True Then
                LcmdCancelCalculate.Enabled = True : LcmdCalculate.Enabled = False : GridView5.OptionsBehavior.Editable = False
            Else
                LcmdCancelCalculate.Enabled = False : LcmdCalculate.Enabled = IIf(Mode = FormMode.NewRecord, False, True) : GridView5.OptionsBehavior.Editable = True
            End If
            If cboBDG.EditValue <> Nothing Then
                If cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "94CECEE9-739E-4E31-9B43-796D318FB9C5" Then cboInvOil.Enabled = True Else cboInvOil.Enabled = False
            End If
            LoadConditionalFormatting()
            cboOwnerTenant.SelectedIndex = 1  'If Mode = FormMode.EditRecord Then chkCALC_CAT.SetItemChecked(0, True)
            If chkreserveAPT.Checked = True Then
                LayoutControlGroup1.Enabled = False
                LayoutControlGroup2.Enabled = False
                LcmdNewInh.Enabled = False
                LcmdCalculate.Enabled = False
                LcmdCancelCalculate.Enabled = False
                LcmdCancelInvoice.Enabled = False
                LayoutControlItem17.Enabled = False
                LcmdSaveINH.Enabled = False
                BarSygentrotiki.Enabled = False
                BarEidop.Enabled = False
                LayoutControlItem25.Enabled = True
            End If
            If chkFromTransfer.Checked = True Then
                LcmdCalculate.Enabled = False : LcmdCancelCalculate.Enabled = False : LayoutControlItem12.Enabled = False
                GridView5.OptionsBehavior.Editable = False
            End If
            cboBDG.Select()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
            Dim i As Integer
            For i = 0 To GridView5.DataRowCount - 1

                Dim B As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                B.Caption = GridView5.GetRowCellDisplayText(i, "calcCatID")
                B.Name = GridView5.GetRowCellDisplayText(i, "calcCatID")
                B.AppearanceHeader.Options.UseTextOptions = True
                B.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                If CheckIfBandExists(B.Caption) = False Then GridINH.Bands.Add(B)
            Next
            'Dim B2 As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            'B2.Caption = "Πάγιο ή Επιβ."
            'B2.Name = "Πάγιο ή Επιβ."
            'B2.AppearanceHeader.Options.UseTextOptions = True
            'B2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            'If CheckIfBandExists(B2.Caption) = False Then GridINH.Bands.Add(B2)
            'cmd = New SqlCommand(sSQL, CNDB)
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function CheckIfBandExists(ByVal Band As String) As Boolean
        For Each B As DevExpress.XtraGrid.Views.BandedGrid.GridBand In GridINH.Bands
            If B.Caption = Band Then Return True
        Next
        Return False

    End Function
    Private Function CheckIfOwnerBandExists(ByVal Band As String) As Boolean
        Try
            Dim B As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GridINH.Bands.Item("apt")
            If B.Columns.Item("col" & Band.Replace(" ", "")) Is Nothing Then
                Return False
            Else
                Return True
            End If


        Catch ex As Exception
            Return False
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub TransposeColumns()
        Try
            Dim B As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GridINH.Bands.Item("apt")

            If B.Columns.Count = 0 Then Exit Sub
            For Each column As BandedGridColumn In B.Columns
                If column.ColIndex > 0 Then
                    column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    column.SummaryItem.DisplayFormat = "Σύνολο {0:n2}€"
                End If
            Next column
            For i As Integer = 0 To GridView5.DataRowCount - 1
                If CheckRepNameIfExists(GridView5.GetRowCellDisplayText(i, "repName"), True) = True Then
                    XtraMessageBox.Show("Υπάρχει διπλή καταχώρηση στα έξοδα. Το έξοδο '" & GridView5.GetRowCellDisplayText(i, "repName").ToString & "' υπάρχει 2 φορές. ", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit For
                Else
                    If CheckIfOwnerBandExists(GridView5.GetRowCellDisplayText(i, "repName").ToString) = False Then
                        XtraMessageBox.Show("Το έξοδο '" & GridView5.GetRowCellDisplayText(i, "repName").ToString & "' έχει καταχωρηθεί χωρίς να υπολογιστεί το παραστατικό. " + Environment.NewLine &
                                                "Στα Υπολογισμένα δεν θα το δείτε ως Στήλη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        B.Columns.Item("col" & GridView5.GetRowCellDisplayText(i, "repName").Replace(" ", "")).OwnerBand = GridINH.Bands.Item(GridView5.GetRowCellDisplayText(i, "calcCatID"))
                        B.Columns.Item("col" & GridView5.GetRowCellDisplayText(i, "repName").Replace(" ", "") & "ΕΠΙΒ.").OwnerBand = GridINH.Bands.Item(GridView5.GetRowCellDisplayText(i, "calcCatID"))
                        B.Columns.Item("col" & GridView5.GetRowCellDisplayText(i, "repName").Replace(" ", "") & "ΣΥΝΟΛΟ").OwnerBand = GridINH.Bands.Item(GridView5.GetRowCellDisplayText(i, "calcCatID"))
                    End If
                End If
            Next
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmINH_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub


    Private Sub cmdSaveINH_Click(sender As Object, e As EventArgs) Handles cmdSaveINH.Click
        Dim sResult As Boolean
        Dim sGuid As String
        Dim Months As Long
        Try
            If Valid.ValidateFormGRP(LayoutControlGroup1) Then
                'Ελεγχος αν είναι valid το διάστημα
                If CheckIfDateIsValid(Months) = False Then Exit Sub

                Select Case Mode
                    Case FormMode.NewRecord
                        'Ελεγχος αν υπάρχει παραστατικό στο δίάστημα
                        If CheckIfINHMonthExists() Then Exit Sub
                        sGuid = System.Guid.NewGuid.ToString
                        Dim sCompleteDate As String = TranslateDates(dtFDate, dtTDate)
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.GroupLayoutControl, "INH",,, LayoutControlGroup1, sGuid, True, "completeDate", toSQLValueS(sCompleteDate))
                        If sResult Then
                            ' Αν είναι θερμιδομέτρηση δεν καταχωρούντε πάγια έξοδα
                            If chkCalorimetric.CheckState = CheckState.Unchecked Then
                                ' Όταν είναι έκδοση δεν μπορεί να πολαπλασιαστεί ανάλογα τους μηνες που έχουν επιλεχθεί
                                ' Όταν έχει οριστεί διαμέρισμα στα πάγια έξοδα τότε αυτόματα παίρνει τα υπολογισμένα του τελευταίου παραστατικού γιαυτό το διαμέρισμα και τα μεταφέρει στο επόμενο
                                If INH.InsertIND(sGuid, toSQLValueS(CDate(dtFDate.EditValue).ToString("yyyyMMdd")), toSQLValueS(cboBDG.EditValue.ToString), Months) = False Then
                                    Exit Sub
                                End If
                            End If

                            ' Όταν είναι κεντρική θέρμανση = Καταμερισμός με Χιλιοστά
                            If INH.InsertINDCentralHeating(sGuid, cboBDG.EditValue.ToString, cboInvOil, cboInvGas) = False Then Exit Sub

                            ' Όταν είναι αυτονομία και υπάρχει πάγιο φυσικού αερίου
                            If INH.InsertINDFixedConsumption(sGuid, cboBDG.EditValue.ToString, "", 1, cboInvGas) = False Then Exit Sub


                            If (cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
                                        cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Or
                                        cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
                                        cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE") Then
                                If cboAhpbH.EditValue IsNot Nothing Or cboAhpbHB.EditValue IsNot Nothing Then
                                    If cboAhpbH.EditValue IsNot Nothing Then
                                        ' Όταν είναι Κοινός λέβητας και έχει θερμίδες σε Boiler και σε Θέρμανση τότε καταχωρούμε αυτόματα Κατανάλωση Θέρμανσης και Boiler
                                        If INH.InsertINDConsumption(sGuid, toSQLValueS(cboBDG.EditValue.ToString), toSQLValueS(cboAhpbH.EditValue.ToString)) Then
                                        End If
                                    End If
                                    If cboAhpbHB.EditValue IsNot Nothing Then
                                        ' Όταν είναι Κοινός λέβητας και έχει θερμίδες σε Boiler και σε Θέρμανση τότε καταχωρούμε αυτόματα Κατανάλωση Θέρμανσης και Boiler
                                        If INH.InsertINDConsumption(sGuid, toSQLValueS(cboBDG.EditValue.ToString),, toSQLValueS(cboAhpbHB.EditValue.ToString)) Then
                                        End If
                                    End If

                                    Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sGuid))
                                    grdIND.DataSource = VwINDBindingSource
                                End If
                            End If
                        End If
                    Case FormMode.EditRecord
                        If chkCalorimetric.CheckState = CheckState.Checked Then
                            If XtraMessageBox.Show("Έχετε επιλέξει θερμιδομέτρηση. Αν έχετε καταχωρήσει έξοδα θα διαγραφούν.Να προχωρήσει η διαδικασία?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                Dim sCompleteDate As String = TranslateDates(dtFDate, dtTDate)
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.GroupLayoutControl, "INH",,, LayoutControlGroup1, sID, True,,,, "completeDate = " & toSQLValueS(sCompleteDate))
                                ' Αν είναι θερμιδομέτρηση δεν καταχωρούντε πάγια έξοδα
                                If INH.DeleteIND(sID) Then

                                End If
                                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
                                grdIND.DataSource = VwINDBindingSource
                            End If
                        Else
                            Dim sCompleteDate As String = TranslateDates(dtFDate, dtTDate)
                            sResult = DBQ.UpdateNewData(DBQueries.InsertMode.GroupLayoutControl, "INH",,, LayoutControlGroup1, sID, True,,,, "completeDate = " & toSQLValueS(sCompleteDate))
                            If sResult Then
                                ' Εαν Θέρμανση= καταμερισμός με χιλιοστά
                                If cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "94CECEE9-739E-4E31-9B43-796D318FB9C5" Then
                                    ' Όταν είναι κεντρική θέρμανση = Καταμερισμός με Χιλιοστά
                                    If INH.UpdateINDCentralHeating(sID, cboBDG.EditValue.ToString, cboInvOil, cboInvGas) = False Then Exit Sub
                                    ' Εαν Θέρμανση= Αυτονομία με χρήση FI /  Boiler= Αυτονομία με χρήση FI ή Αυτονομία με σταθερό πάγιο 
                                ElseIf (cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
                                        cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Or
                                        cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
                                        cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE") Then
                                    If cboAhpbH.EditValue IsNot Nothing Or cboAhpbHB.EditValue IsNot Nothing Then
                                        If cboAhpbH.EditValue IsNot Nothing Then
                                            ' Όταν είναι Κοινός λέβητας και έχει θερμίδες σε Boiler και σε Θέρμανση τότε καταχωρούμε αυτόματα Κατανάλωση Θέρμανσης και Boiler
                                            If INH.UpdateINDConsumption(sID, toSQLValueS(cboBDG.EditValue.ToString), toSQLValueS(cboAhpbH.EditValue.ToString)) = False Then Exit Sub
                                        End If
                                        If cboAhpbHB.EditValue IsNot Nothing Then
                                            ' Όταν είναι Κοινός λέβητας και έχει θερμίδες σε Boiler και σε Θέρμανση τότε καταχωρούμε αυτόματα Κατανάλωση Θέρμανσης και Boiler
                                            If INH.UpdateINDConsumption(sID, toSQLValueS(cboBDG.EditValue.ToString), , toSQLValueS(cboAhpbHB.EditValue.ToString)) = False Then Exit Sub
                                        End If
                                    Else
                                        'Στην περίπτωση κατανάλωσης αν δεν έχουν επιλεχθεί ώρες διαγράφει το έξοδο
                                        DeleteConsumptionS()
                                    End If
                                    ' Όταν είναι αυτονομία και υπάρχει πάγιο φυσικού αερίου
                                    If INH.InsertINDFixedConsumption(sID, cboBDG.EditValue.ToString, "", 1, cboInvGas) = False Then
                                        XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την καταχώρηση εξόδου παγίου φυσικού αερίου.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If

                                End If
                                ' Ενημέρωση των ποσών όλων των εξόδων ανάλογα με το διάστημα που έχει επιλεχθεί, πλην της έκδοσης
                                If INH.UpdateIND(sID, Months) = False Then XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την καταχώρηση του παραστατικού", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
                                grdIND.DataSource = VwINDBindingSource
                            End If
                        End If
                End Select
                If sResult Then
                    If Mode = FormMode.NewRecord Then sID = sGuid : Mode = FormMode.EditRecord
                    txtCode.Text = DBQ.GetNextId("INH")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False : LayoutControlGroup2.Enabled = True : LcmdSaveInd.Enabled = True
                    cmdDel.Enabled = True : LcmdCalculate.Enabled = True : cmdRefresh.Enabled = True
                    TabNavigationPage3.Enabled = True   'chkCALC_CAT.SetItemChecked(0, True)
                    BarSygentrotiki.Enabled = True : BarReceipt.Enabled = True : BarEidop.Enabled = True
                    LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Success
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Έλεγχος αν υπάρχει Τιμολόγιο Φυσικού αερίου που είναι πάγιο. Αυτό το θέλαμε για την περίπτβση που ενα τιμολόγιο είναι πάγιο
    ' π.χ καλοκαιρινό μήνα που δεν υπάρχει κατανάλωση να προσπερνάει τον έλεγχο των ωρών
    Private Function CheckIfHasGasFixedInvoices(ByVal mode As Int16) As Boolean
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim CountINH As Integer

        'ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ
        If mode = 0 Then
            sSQL = "select  count(IND.ID) as CountINH  
                    from IND 
                    inner join INV_GAS on INV_GAS.ID = IND.invGasID  
                    where fixed = 1 and calcCatID ='B139CE26-1ABA-4680-A1EE-623EC97C475B' And  IND.inhID = " & toSQLValueS(sID)

            'ΚΑΤ/ΣΗ BOILER
        Else
            sSQL = "select  count(IND.ID) as CountINH  
                    from IND 
                    inner join INV_GAS on INV_GAS.ID = IND.invGasID  
                    where fixed = 1 and calcCatID ='2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72' And  IND.inhID = " & toSQLValueS(sID)
        End If
        cmd = New SqlCommand(sSQL, CNDB)
        sdr = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            If sdr.IsDBNull(sdr.GetOrdinal("CountINH")) = True Then
                CountINH = 0
            Else
                CountINH = sdr.GetInt32(sdr.GetOrdinal("CountINH"))
            End If
            sdr.Close()
            If CountINH > 0 Then
                Return True
            End If
        End If
        Return False

    End Function
    Private Function CheckIfDateIsValid(ByRef Months As Long) As Boolean
        Dim date1 As Date = Date.Parse(dtFDate.EditValue.ToString)
        Dim date2 As Date = Date.Parse(dtTDate.EditValue.ToString)
        Dim LastDayInMonthDate As Date = New Date(date2.Year, date2.Month, Date.DaysInMonth(date2.Year, date2.Month))
        Months = DateDiff(DateInterval.Month, date1, date2) + 1

        dtTDate.EditValue = LastDayInMonthDate
        If DateDiff(DateInterval.Month, date1, date2) < 0 Then
            XtraMessageBox.Show("Δεν μπορεί η ""ΑΠΟ"" ημερομηνία να είναι μεγαλύτερη από την ""ΕΩΣ""", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If

    End Function

    Private Function CheckIfINHMonthExists() As Boolean

        Dim sSQL As String
        Dim DateChanged As Boolean = False
        If fdate <> dtFDate.EditValue Or Tdate <> dtTDate.EditValue Then DateChanged = True

        If chkExtraordinary.Checked = True Then
            sSQL = "select count(id) as CountINH from inh where extraordinary = 1 and bdgID = " & toSQLValueS(cboBDG.EditValue.ToString) & " and " & toSQLValueS(CDate(dtFDate.Text).ToString("yyyyMMdd")) & " between fDate and TDate"
        End If
        If chkCalorimetric.Checked = True Then
            sSQL = "select count(id) as CountINH from inh where Calorimetric = 1 and  bdgID = " & toSQLValueS(cboBDG.EditValue.ToString) & " and " & toSQLValueS(CDate(dtFDate.Text).ToString("yyyyMMdd")) & " between fDate and TDate"
        End If
        If chkExtraordinary.Checked = False And chkCalorimetric.Checked = False Then
            sSQL = "select count(id) as CountINH from inh where extraordinary = 0 and Calorimetric = 0   and  bdgID = " & toSQLValueS(cboBDG.EditValue.ToString) & " and " & toSQLValueS(CDate(dtFDate.Text).ToString("yyyyMMdd")) & " between fDate and TDate"
        End If

        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim CountINH As Integer
        cmd = New SqlCommand(sSQL, CNDB)
        sdr = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            If sdr.IsDBNull(sdr.GetOrdinal("CountINH")) = True Then
                CountINH = 0
            Else
                CountINH = sdr.GetInt32(sdr.GetOrdinal("CountINH"))
            End If
            sdr.Close()
            If CountINH > 0 Then
                XtraMessageBox.Show("Υπάρχει ήδη καταχωρημένο παραστατικό στο δίαστημα.Θέλετε να συνεχίσετε στην καταχώρηση?", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True
            End If
        End If
        Return False

    End Function
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
        'Dim sCalcCatID As String

        If Valid.ValidateFormGRP(LayoutControlGroup2) Then
            Dim repName As String
            repName = cboRepname.EditValue.ToString
            'If chkCALC_CAT.CheckedItemsCount = 0 Then
            If cboCALC_CAT.EditValue = Nothing Then
                XtraMessageBox.Show("Δεν έχετε επιλέξει έξοδο προς καταχώρηση.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If CheckRepNameIfExists(repName) = False Then
                'sCalcCatID = chkCALC_CAT.SelectedValue.ToString
                'sCalcCatID = cboCALC_CAT.EditValue.ToString
                sResult = DBQ.InsertNewData(DBQueries.InsertMode.GroupLayoutControl, "IND",,, LayoutControlGroup2,,, "inhID", toSQLValueS(sID))
                If sResult Then
                    Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
                    'XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Cls.ClearGroupCtrls(LayoutControlGroup2)
                    Valid.SChanged = False
                End If
                cboOwnerTenant.SelectedIndex = 1 : cboRepname.Select() 'chkCALC_CAT.SetItemChecked(0, True) : cboRepname.Select()
                'chkCALC_CAT.UnCheckAll()
            Else
                XtraMessageBox.Show("Υπάρχει ίδιο λεκτικό εκτύπωσης σε άλλο έξοδο.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Protected Overrides Function ProcessMnemonic(charCode As Char) As Boolean
        If ModifierKeys <> Keys.Alt Then
            Return False
        Else
            If charCode.ToString = "s" Or charCode.ToString = "S" Or charCode.ToString = "σ" Or charCode.ToString = "Σ" Then
                cmdSaveInd.PerformClick()
            End If
        End If
        Return MyBase.ProcessMnemonic(charCode)
    End Function
    Private Sub DeleteIND_F(Optional ByVal Question As Boolean = True)
        Dim sSQL As String
        Try
            If Question Then
                If XtraMessageBox.Show("Θέλετε να διαγραφεί τα αρχεία άπό το επιλεγμένο έξοδο?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DeleteIND()
        Dim sSQL As String
        Try
            If chkCalculated.CheckState = CheckState.Checked Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM IND WHERE ID = '" & GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString & "'"
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Me.INV_GASTableAdapter.FillByBDG(Me.Priamos_NET_DataSet_INH.INV_GAS, cboBDG.EditValue)
                'Διαγραφή αρχείων αν υπάρχουν
                DeleteIND_F(False)
                Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteINC()
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφεί o υπολογισμός?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM INC WHERE INHID = " & toSQLValueS(sID)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                sSQL = "UPDATE INH SET AHPB_HID=NULL,CALCULATED=0 WHERE ID = " & toSQLValueS(sID)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                If cboAhpbH.EditValue IsNot Nothing Then
                    sSQL = "UPDATE AHPB_H SET FINALIZED=0 WHERE BOILER=0 AND ID = " & toSQLValueS(cboAhpbH.EditValue.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If
                If cboAhpbHB.EditValue IsNot Nothing Then
                    sSQL = "UPDATE AHPB_H SET FINALIZED=0 WHERE BOILER=1 AND ID = " & toSQLValueS(cboAhpbHB.EditValue.ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If
                EditRecord() : Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
                Me.AHPB_HTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.AHPB_H, System.Guid.Parse(cboBDG.EditValue.ToString))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Case 0 : Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
            Case 1 : EditRecord() : Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
            Case 2 : ApmLoad()
            Case Else
        End Select

    End Sub
    Private Sub cboBDG_Validated(sender As Object, e As EventArgs) Handles cboBDG.Validated
        If cboBDG.EditValue = Nothing Then Exit Sub
        If cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
           cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Then

            txtHeatingType.EditValue = cboBDG.GetColumnValue("HTYPE_Name")
            txtHpc.EditValue = cboBDG.GetColumnValue("hpc")

            'If Priamos_NETDataSet.AHPB_H.Rows.Count > 0 Then
            '    cboAhpbH.Properties.ReadOnly = False
            'ElseIf cboAhpbH.Properties.DataSource.Count = 0 Then
            '    XtraMessageBox.Show("Δεν υπάρχουν καταχωρημένες ώρες Θέρμανσης", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Else
            txtHeatingType.EditValue = Nothing
        End If
        If cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
           cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Then
            txtBoilerType.EditValue = cboBDG.GetColumnValue("BTYPE_Name")
            txtHpb.EditValue = cboBDG.GetColumnValue("hpb")
            'If Priamos_NETDataSet.AHPB_Β.Rows.Count > 0 Then
            '    cboAhpbHB.Properties.ReadOnly = False
            'ElseIf cboAhpbHB.Properties.DataSource.Count = 0 Then
            '    XtraMessageBox.Show("Δεν υπάρχουν καταχωρημένες ώρες Boiler", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Else
            txtBoilerType.EditValue = Nothing
        End If
    End Sub
    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        Try
            If cboBDG.EditValue = Nothing Then Exit Sub
            SetBdgFieldsValues()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error:  {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetBdgFieldsValues()
        'chkCALC_CAT.DataSource = VwCALCCATBindingSource
        If cboBDG.EditValue <> Nothing Then
            Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NET_DataSet_INH.vw_INH, System.Guid.Parse(cboBDG.EditValue.ToString))
            Me.AHPB_HTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.AHPB_H, cboBDG.EditValue)
            Me.AHPB_ΒTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.AHPB_Β, cboBDG.EditValue)
            Me.INV_OILTableAdapter.FillbyBDG(Me.Priamos_NET_DataSet_INH.INV_OIL, cboBDG.EditValue)
            Me.INV_GASTableAdapter.FillByBDG(Me.Priamos_NET_DataSet_INH.INV_GAS, cboBDG.EditValue)
            Me.Vw_CALC_CATTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_CALC_CAT, cboBDG.EditValue)
            If cboInvOil.Properties.GetItems.Count <> 0 Then cboInvOil.BackColor = Color.Coral Else cboInvOil.BackColor = Color.White
            If cboInvGas.Properties.GetItems.Count <> 0 Then cboInvGas.BackColor = Color.Coral Else cboInvGas.BackColor = Color.White
            Me.Text = "Παραστατικό - " & cboBDG.Text
        End If

        ' Κεντρική Θέρμανση
        If cboBDG.GetColumnValue("FTYPE_Name") Is Nothing Then txtFtypes.EditValue = Nothing Else txtFtypes.EditValue = cboBDG.GetColumnValue("FTYPE_Name")

        If cboBDG.GetColumnValue("HTypeID") Is Nothing Then
            txtHeatingType.EditValue = Nothing
            txtHpc.EditValue = Nothing
        Else
            ' If cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Then
            txtHeatingType.EditValue = cboBDG.GetColumnValue("HTYPE_Name")
                txtHpc.EditValue = cboBDG.GetColumnValue("hpc")
            'Else
            '    txtHeatingType.EditValue = Nothing
            '    txtHpc.EditValue = Nothing
            'End If
        End If

        If cboBDG.GetColumnValue("BTypeID") Is Nothing Then
            txtBoilerType.EditValue = Nothing
            txtHpb.EditValue = Nothing
        Else
            'If cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Then
            txtBoilerType.EditValue = cboBDG.GetColumnValue("BTYPE_Name")
                txtHpb.EditValue = cboBDG.GetColumnValue("hpb")
            'Else
            '    txtBoilerType.EditValue = Nothing
            '    txtHpb.EditValue = Nothing
            'End If
        End If
        If cboBDG.GetColumnValue("cmt") Is Nothing Then Exit Sub
        txtBdgCmt.Text = cboBDG.GetColumnValue("cmt").ToString
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger

    End Sub
    Private Sub cboBDG_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboBDG.EditValue = Nothing : ManageCbo.ManageBDG(cboBDG, FormMode.NewRecord)
            Case 2 : If cboBDG.EditValue <> Nothing Then ManageCbo.ManageBDG(cboBDG, FormMode.EditRecord)
            Case 3 : cboBDG.EditValue = Nothing : cboCALC_CAT.Properties.DataSource = Nothing : Me.Text = "Παραστατικό" 'chkCALC_CAT.DataSource = Nothing : chkCALC_CAT.Items.Clear()
        End Select
    End Sub

    Private Sub cmdCalculate_Click(sender As Object, e As EventArgs) Handles cmdCalculate.Click
        Try
            Calculate() : TabNavigationPage2.Enabled = True : cmdPrintAll.Enabled = True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error:  {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dtFDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtFDate.EditValueChanged
        lbldate.Text = TranslateDates(dtFDate, dtTDate)
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger
    End Sub

    Private Sub dtTDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtTDate.EditValueChanged
        lbldate.Text = TranslateDates(dtFDate, dtTDate)
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger
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
                ",isPrepayment  = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "isPrepayment")) &
                ",owner_tenant = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "owner_tenant")) &
                ",regardingdeposit = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "regardingdeposit")) &
                ",SelectedFiles = " & toSQLValueS(IIf(IsDBNull(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "SelectedFiles")) = True, "", GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "SelectedFiles"))) &
                ",paid = " & IIf(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "paid") = True, 1, 0) &
        " WHERE ID = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString)
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Case 0 : If chkCalculated.CheckState = CheckState.Checked Then cmdDel.Enabled = False Else cmdDel.Enabled = True
            Case 1 : If chkCalculated.CheckState = CheckState.Checked Then cmdDel.Enabled = False Else cmdDel.Enabled = True : 
                EditRecord()
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
            LoadForms.LoadColumnDescriptionNames(GridView1, , "vw_APMIL")
            LoadForms.LoadColumnDescriptionNames(GridView7, , "vw_APMIL_D")
            LoadForms.RestoreLayoutFromXml(GridView1, "APMIL_def.xml")
            LoadForms.RestoreLayoutFromXml(GridView7, "APMIL_D_def.xml")
            GridView1.OptionsCustomization.AllowSort = False

            'GridView1.Columns("AptNam").OptionsColumn.ReadOnly = True
            'GridView1.Columns("AptNam").OptionsColumn.AllowEdit = False
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboRepname_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboRepname.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboRepname.EditValue = Nothing : ManageCbo.ManageTTL(cboRepname, FormMode.NewRecord, Me)
            Case 2 : If cboRepname.EditValue <> Nothing Then ManageCbo.ManageTTL(cboRepname, FormMode.EditRecord, Me)
            Case 3 : cboRepname.EditValue = Nothing
        End Select
    End Sub


    Private Sub Calculate()
        Try
            Dim sAhpbID As String = "00000000-0000-0000-0000-000000000000", sAhpbText As String = ""
            Dim sAhpbBID As String = "00000000-0000-0000-0000-000000000000", sAhpbBtext As String = ""
            ' Έλεγχος στην περίπτωση που υπάρχουν καταναλώσεις κι όχι ώρες και το αντίθετο
            If CheckForSelectedHours(sAhpbID, sAhpbBID, sAhpbText, sAhpbBtext) = False Then Exit Sub
            Using oCmd As New SqlCommand("inv_Calculate", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@inhid", sID.ToUpper)
                oCmd.Parameters.AddWithValue("@bdgid", cboBDG.EditValue.ToString.ToUpper)
                oCmd.Parameters.AddWithValue("@ahpbHID", System.Guid.Parse(sAhpbID))
                oCmd.Parameters.AddWithValue("@ahpbHIDB", System.Guid.Parse(sAhpbBID))
                oCmd.ExecuteNonQuery()
            End Using
            ' Ενημέρωση αποθεματικού
            CalculateDepositA(cboBDG.EditValue.ToString)
            'XtraMessageBox.Show("Ο υπολογισμός ολοκληρώθηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim args As New XtraMessageBoxArgs()
            args.AutoCloseOptions.Delay = 2000
            args.AutoCloseOptions.ShowTimerOnDefaultButton = True
            args.DefaultButtonIndex = 0
            args.Caption = ProgProps.ProgTitle
            args.Text = "Ο υπολογισμός ολοκληρώθηκε με επιτυχία"
            args.Buttons = New DialogResult() {DialogResult.OK}
            args.Icon = System.Drawing.SystemIcons.Information
            XtraMessageBox.Show(args).ToString()


            If sAhpbText <> "" Then lblInf.Text = "Το παραστατικό υπολογίσθηκε με ώρες θέρμανσης: " & sAhpbText : Me.AHPB_HTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.AHPB_H, cboBDG.EditValue)
            If sAhpbBtext <> "" Then lblInf2.Text = "Το παραστατικό υπολογίσθηκε με ώρες Boiler: " & sAhpbBtext : Me.AHPB_ΒTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.AHPB_Β, cboBDG.EditValue)

            Dim InhFieldAndValues = New Dictionary(Of String, String)
            InhFieldAndValues = LoadForms.DatasetToDictionary("Select * from vw_INH where id = " & toSQLValueS(sID))
            If InhFieldAndValues.Item("OilInvDate").ToString <> "" Then lblInf3.Text = "Το παραστατικό υπολογίσθηκε με το/τα τιμολόγιο/α Πετρελάιου: " & InhFieldAndValues.Item("OilInvDate").ToString() : Me.INV_OILTableAdapter.FillbyBDG(Me.Priamos_NET_DataSet_INH.INV_OIL, cboBDG.EditValue)
            If InhFieldAndValues.Item("GasInvDate").ToString <> "" Then lblInf4.Text = "Το παραστατικό υπολογίσθηκε με το/τα τιμολόγιο/α Φυσικού Αερίου: " & InhFieldAndValues.Item("GasInvDate").ToString : Me.INV_GASTableAdapter.FillByBDG(Me.Priamos_NET_DataSet_INH.INV_GAS, cboBDG.EditValue)


            chkCalculated.CheckState = CheckState.Checked
            chkCalculated.Checked = True
            LcmdCancelCalculate.Enabled = True
            LcmdCalculate.Enabled = False : LcmdCalculate.Enabled = False : GridView5.OptionsBehavior.Editable = False : cmdSaveInd.Enabled = False : cmdSaveINH.Enabled = False
            EditRecord()
            Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
            Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))

        Catch SQLex As SqlException
            XtraMessageBox.Show(String.Format("Error: {0}", SQLex.Errors.Item(0).ToString), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CalculateDepositR(ByVal sbdgID As String)
        Try
            Using oCmd As New SqlCommand("CalculateAndReturnDepositR", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@bdgID", sbdgID)
                oCmd.Parameters.Add("@totDepositR", SqlDbType.Decimal)
                oCmd.Parameters.Add("@UnchargableOil", SqlDbType.Decimal)
                oCmd.Parameters.Add("@UnpaidInd", SqlDbType.Decimal)
                oCmd.Parameters.Add("@PaidInd", SqlDbType.Decimal)
                oCmd.Parameters.Add("@AptBalAdm", SqlDbType.Decimal)
                oCmd.Parameters.Add("@totPrepayments", SqlDbType.Decimal)
                oCmd.Parameters.Add("@totDepositRAndPrepayments", SqlDbType.Decimal)
                oCmd.Parameters("@totDepositR").Direction = ParameterDirection.Output : oCmd.Parameters("@totDepositR").Precision = 18 : oCmd.Parameters("@totDepositR").Scale = 2
                oCmd.Parameters("@UnchargableOil").Direction = ParameterDirection.Output : oCmd.Parameters("@UnchargableOil").Precision = 18 : oCmd.Parameters("@UnchargableOil").Scale = 2
                oCmd.Parameters("@UnpaidInd").Direction = ParameterDirection.Output : oCmd.Parameters("@UnpaidInd").Precision = 18 : oCmd.Parameters("@UnpaidInd").Scale = 2
                oCmd.Parameters("@PaidInd").Direction = ParameterDirection.Output : oCmd.Parameters("@PaidInd").Precision = 18 : oCmd.Parameters("@PaidInd").Scale = 2
                oCmd.Parameters("@AptBalAdm").Direction = ParameterDirection.Output : oCmd.Parameters("@AptBalAdm").Precision = 18 : oCmd.Parameters("@AptBalAdm").Scale = 2
                oCmd.Parameters("@totPrepayments").Direction = ParameterDirection.Output : oCmd.Parameters("@totPrepayments").Precision = 18 : oCmd.Parameters("@totPrepayments").Scale = 2
                oCmd.Parameters("@totDepositRAndPrepayments").Direction = ParameterDirection.Output : oCmd.Parameters("@totDepositRAndPrepayments").Precision = 18 : oCmd.Parameters("@totDepositRAndPrepayments").Scale = 2
                oCmd.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CalculateDepositA(ByVal sbdgID As String)
        Try
            Using oCmd As New SqlCommand("CalculateAndReturnDepositA", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@bdgID", sbdgID)
                oCmd.Parameters.Add("@Amt", SqlDbType.Decimal)
                oCmd.Parameters("@Amt").Direction = ParameterDirection.Output
                oCmd.ExecuteNonQuery()
            End Using
            'Υπολογισμός Διαθέσιμου υπολοίπου
            CalculateDepositR(sbdgID)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function CheckForSelectedHours(ByRef sAhpbID As String, ByRef sAhpbBID As String, ByRef sAhpbText As String, ByRef sAhpbBtext As String) As Boolean
        'Έλεγχος αν έχει επιλεχθεί στα έξοδα Κατανάλωση Θέρμανσης ή Κατανάλωση boiler
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim sindHID As String = "", sindBID As String = ""
        Try

            If CheckIfHasGasFixedInvoices(0) = False Then
                ' Εαν έχει καταχωρήσει κατανάλωση θέρμανσης
                sSQL = "select top 1 ID from IND where inhID = " & toSQLValueS(sID) & " and calcCatID ='B139CE26-1ABA-4680-A1EE-623EC97C475B'"
                cmd = New SqlCommand(sSQL, CNDB)
                sdr = cmd.ExecuteReader()
                If (sdr.Read() = True) Then sindHID = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
                sdr.Close()
            End If
            If CheckIfHasGasFixedInvoices(1) = False Then
                ' Εαν έχει καταχωρήσει κατανάλωση Boiler
                sSQL = "select top 1 ID from IND where inhID = " & toSQLValueS(sID) & " and calcCatID ='2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'"
                cmd = New SqlCommand(sSQL, CNDB)
                sdr = cmd.ExecuteReader()
                If (sdr.Read() = True) Then sindBID = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
                sdr.Close()
            End If


            ' Εαν Θέρμανση= Αυτονομία με χρήση FI ή Αυτονομία με σταθερό πάγιο 
            If (cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
                cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE") Then
                If sindHID.Length = 0 And cboAhpbH.EditValue IsNot Nothing Then
                    XtraMessageBox.Show("Έχετε επιλέξει ώρες χωρίς να καταχωρήσετε κατανάλωση θέρμανσης.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                ElseIf sindHID.Length > 0 And cboAhpbH.EditValue Is Nothing Then
                    XtraMessageBox.Show("Έχετε καταχωρήσει κατανάλωση θέρμανσης χωρίς να επιλέξετε ώρες.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Else
                    If cboAhpbH.EditValue IsNot Nothing Then sAhpbID = cboAhpbH.EditValue.ToString.ToUpper : sAhpbText = cboAhpbH.Text
                End If
            Else
                If cboAhpbH.EditValue IsNot Nothing Then sAhpbID = cboAhpbH.EditValue.ToString.ToUpper : sAhpbText = cboAhpbH.Text
            End If


            ' Εαν Boiler= Αυτονομία με χρήση FI ή Αυτονομία με σταθερό πάγιο
            If (cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
               cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE") Then
                If sindBID.Length = 0 And cboAhpbHB.EditValue IsNot Nothing Then
                    XtraMessageBox.Show("Έχετε επιλέξει ώρες χωρίς να καταχωρήσετε κατανάλωση Boiler.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                ElseIf sindBID.Length > 0 And cboAhpbHB.EditValue Is Nothing Then
                    XtraMessageBox.Show("Έχετε καταχωρήσει κατανάλωση Boiler χωρίς να επιλέξετε  ώρες.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Else
                    If cboAhpbHB.EditValue IsNot Nothing Then sAhpbBID = cboAhpbHB.EditValue.ToString.ToUpper : sAhpbBtext = cboAhpbHB.Text
                End If
            Else
                If cboAhpbHB.EditValue IsNot Nothing Then sAhpbBID = cboAhpbHB.EditValue.ToString.ToUpper : sAhpbBtext = cboAhpbHB.Text
            End If

            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub DeleteConsumptionS()
        'Έλεγχος αν έχει επιλεχθεί στα έξοδα Κατανάλωση Θέρμανης ή Κατανάλωση boiler και δεν αφορά τιμολόγιο Φυσικού αερίου που είναι πάγιο
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim sindHID As String = "", sindBID As String = ""
        Try
            ' Εαν έχει καταχωρήσει κατανάλωση θέρμανσης
            sSQL = "select top 1 IND.ID from IND left join inv_Gas on inv_Gas.ID = IND.invGasID where IND.inhID  = " & toSQLValueS(sID) & " and calcCatID ='B139CE26-1ABA-4680-A1EE-623EC97C475B' and isnull(fixed,0) = 0"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then sindHID = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
            sdr.Close()
            ' Εαν έχει καταχωρήσει κατανάλωση Boiler
            sSQL = "select top 1 IND.ID from IND left join inv_Gas on inv_Gas.ID = IND.invGasID where IND.inhID  = " & toSQLValueS(sID) & " and calcCatID ='2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72' and isnull(fixed,0) = 0"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then sindBID = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
            sdr.Close()


            ' Εαν Θέρμανση= Αυτονομία με χρήση FI ή Αυτονομία με σταθερό πάγιο 
            If (cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
            cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE") Then
                If sindHID.Length > 0 And cboAhpbH.EditValue Is Nothing Then
                    sSQL = "DELETE IND 
                            FROM IND
                            inner join INH on INH.id = IND.inhID
                            inner join BDG on INH.bdgid = BDG.ID
                            where isManaged = 1 and IND.ID = " & toSQLValueS(sindHID)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                    Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
                    grdIND.DataSource = VwINDBindingSource
                End If
            End If

            ' Εαν Boiler= Αυτονομία με χρήση FI ή Αυτονομία με σταθερό πάγιο
            If (cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Or
           cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE") Then
                If sindBID.Length > 0 And cboAhpbHB.EditValue Is Nothing Then
                    sSQL = "DELETE IND 
                            FROM IND 
                            inner join INH on INH.id = IND.inhID
                            inner join BDG on INH.bdgid = BDG.ID
                            where isManaged = 1 and IND.ID = " & toSQLValueS(sindBID)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                    Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
                    grdIND.DataSource = VwINDBindingSource
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
            Case 1 : ManageCbo.ManageAnnouncements(cboAnnouncements, FormMode.NewRecord, Me)
            Case 2 : ManageCbo.ManageAnnouncements(cboAnnouncements, FormMode.EditRecord, Me)
            Case 3 : cboAnnouncements.EditValue = Nothing
        End Select
    End Sub



    Private Sub ToolTipController1_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        Try
            If e.SelectedControl Is cboAnnouncements Then
                If cboAnnouncements.CalcBestSize().Width > cboAnnouncements.Width Then
                    e.Info = New ToolTipControlInfo(cboAnnouncements, cboAnnouncements.EditValue)
                End If
            ElseIf e.SelectedControl Is chkCalculated Then

            ElseIf e.SelectedControl Is chkPrintEidop Then
                If chkPrintReceipt.Checked = True Then
                    e.Info = New ToolTipControlInfo(chkPrintEidop, "Εκτύπωση Ειδοποίησης στις " & vbCrLf & InhFieldAndValues.Item("DateOfPrintEidop"))
                    e.Info.ToolTipType = ToolTipType.Flyout
                    e.Info.IconType = ToolTipIconType.Information
                End If
            ElseIf e.SelectedControl Is chkPrintReceipt Then
                If chkPrintReceipt.Checked = True Then
                    e.Info = New ToolTipControlInfo(chkPrintReceipt, "Εκτύπωση Απόδειξης στις " & vbCrLf & InhFieldAndValues.Item("DateOfPrintEisp"))
                    e.Info.ToolTipType = ToolTipType.Flyout
                    e.Info.IconType = ToolTipIconType.Information
                End If

            ElseIf e.SelectedControl Is chkPrintSyg Then
                If chkPrintSyg.Checked = True Then
                    e.Info = New ToolTipControlInfo(chkPrintSyg, "Εκτύπωση Συγεντρωτικής στις " & vbCrLf & InhFieldAndValues.Item("DateOfPrint"))
                    e.Info.ToolTipType = ToolTipType.Flyout
                    e.Info.IconType = ToolTipIconType.Information
                End If
            ElseIf e.SelectedControl Is grdIND Then
                If chkEmail.Checked = True Then
                    e.Info = New ToolTipControlInfo(chkEmail, "Email Ειδοποίησης στις " & vbCrLf & InhFieldAndValues.Item("DateOfEmail"))
                    e.Info.ToolTipType = ToolTipType.Flyout
                    e.Info.IconType = ToolTipIconType.Information
                End If

            ElseIf e.SelectedControl Is txtBdgCmt Then
                e.Info = New ToolTipControlInfo(txtBdgCmt, txtBdgCmt.Text)
                e.Info.ToolTipType = ToolTipType.Flyout
                e.Info.IconType = ToolTipIconType.Application
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            LoadForms.PopupMenuShow(e, GridView5, "INHDET_def.xml", "VW_IND")
        Else
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If

    End Sub

    Private Function CreateCheckItem(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function

    'Κλείδωμα Στήλης Master
    Private Sub OnCanMoveItemClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub

    Friend Class MenuColumnInfo
        Public Sub New(ByVal column As GridColumn)
            Me.Column = column
        End Sub
        Public Column As GridColumn
    End Class

    Private Sub cmdNewInh_Click(sender As Object, e As EventArgs) Handles cmdNewInh.Click
        Mode = FormMode.NewRecord
        ClearForm()
        Me.Vw_INHTableAdapter.FillBybdgID(Me.Priamos_NET_DataSet_INH.vw_INH, System.Guid.NewGuid)
    End Sub
    Private Sub ClearForm()
        Cls.ClearGroupCtrls(LayoutControlGroup1) : Cls.ClearGroupCtrls(LayoutControlGroup2)
        txtCode.Text = DBQ.GetNextId("INH")
        LayoutControlGroup2.Enabled = False
        LcmdSaveInd.Enabled = False
        LcmdCalculate.Enabled = False
        cmdDel.Enabled = False
        LcmdCancelInvoice.Enabled = False
        cboCALC_CAT.Properties.DataSource = Nothing
        TabNavigationPage2.Enabled = False
        TabNavigationPage3.Enabled = False
        txtComments.EditValue = Nothing
        txtBdgCmt.EditValue = Nothing
        grdIND.DataSource = Nothing
        cboInvOil.SetEditValue(-1) : cboInvGas.SetEditValue(-1)
        lbldate.Text = " " : lblInf2.Text = "" : lblInf.Text = "" : lblInf3.Text = "" : lblInf4.Text = ""
        chkCalorimetric.Checked = False : chkExtraordinary.Checked = False : chkFromTransfer.Checked = False : chkreserveAPT.Checked = False
        chkCalculated.Checked = False : chkEmail.Checked = False : chkPrintEidop.Checked = False : chkPrintReceipt.Checked = False : chkPrintSyg.Checked = False
        cmdCalculate.Enabled = False : cmdCancelCalculate.Enabled = False
        BarSygentrotiki.Enabled = False : BarReceipt.Enabled = False : BarEidop.Enabled = False
        LcmdSaveINH.Enabled = True
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
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        If UserProps.ID.ToString.ToUpper = "E9CEFD11-47C0-4796-A46B-BC41C4C3606B" Or
           UserProps.ID.ToString.ToUpper = "E2BF15AC-19E3-498F-9459-1821B3898C76" Or
           UserProps.ID.ToString.ToUpper = "97E2CB01-93EA-4F97-B000-FDA359EC943C" Then
            If XtraMessageBox.Show("Θέλετε να γίνει κοινοποίηση της όψης? Εαν επιλέξετε 'Yes' όλοι οι χρήστες θα έχουν την ίδια όψη", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If My.Computer.FileSystem.FileExists(ProgProps.ServerViewsPath & "DSGNS\DEF\APMIL_def.xml") = False Then GridView1.OptionsLayout.LayoutVersion = "v1"
                If My.Computer.FileSystem.FileExists(ProgProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml") = False Then GridView7.OptionsLayout.LayoutVersion = "v1"
                GridView1.SaveLayoutToXml(ProgProps.ServerViewsPath & "DSGNS\DEF\APMIL_def.xml", OptionsLayoutBase.FullLayout)
                GridView7.SaveLayoutToXml(ProgProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml", OptionsLayoutBase.FullLayout)
            End If
        End If
    End Sub
    'Συγχρονισμός όψης από Server
    Private Sub OnSyncView2(ByVal sender As System.Object, ByVal e As EventArgs)
        If XtraMessageBox.Show("Θέλετε να γίνει μεταφορά της όψης από τον server?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            ' Έλεγχος αν υπάρχει όψη με μεταγενέστερη ημερομηνία στον Server
            If System.IO.File.Exists(ProgProps.ServerViewsPath & "DSGNS\DEF\APMIL_def.xml") = True Then
                My.Computer.FileSystem.CopyFile(ProgProps.ServerViewsPath & "DSGNS\DEF\APMIL_def.xml", Application.StartupPath & "\DSGNS\DEF\APMIL_def.xml", True)
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\APMIL_def.xml", OptionsLayoutBase.FullLayout)
            End If
            If System.IO.File.Exists(ProgProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml") = True Then
                My.Computer.FileSystem.CopyFile(ProgProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml", Application.StartupPath & "\DSGNS\DEF\APMIL_D_def.xml", True)
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

    Private Sub DataNavigator1_ButtonClick(sender As Object, e As NavigatorButtonClickEventArgs) Handles DataNavigator1.ButtonClick
        Select Case e.Button.ButtonType
            Case e.Button.ButtonType.Next : LoadINH(e.Button.ButtonType.Next)
            Case e.Button.ButtonType.Prev : LoadINH(e.Button.ButtonType.Prev)
            Case e.Button.ButtonType.First : LoadINH(e.Button.ButtonType.First)
            Case e.Button.ButtonType.Last : LoadINH(e.Button.ButtonType.Last)
        End Select
    End Sub
    Private Sub LoadINH(ByVal ButtonType As Integer)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            'If DataNavigator1.Tag = Nothing Then DataNavigator1.Tag = sID
            Select Case ButtonType
                Case 4 : sSQL = "select top 1 ID from INH where bdgID= " & toSQLValueS(cboBDG.EditValue.ToString) & " and code > " & toSQLValue(txtCode, True) & " order by code"
                Case 3 : sSQL = "select top 1 ID from INH where bdgID= " & toSQLValueS(cboBDG.EditValue.ToString) & " and code < " & toSQLValue(txtCode, True) & " order by code desc"
                Case 1 : sSQL = "select top 1 ID from INH where bdgID= " & toSQLValueS(cboBDG.EditValue.ToString) & " order by code asc "
                Case 6 : sSQL = "select top 1 ID from INH where bdgID= " & toSQLValueS(cboBDG.EditValue.ToString) & " order by code desc"
            End Select
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then sID = sdr.GetGuid(sdr.GetOrdinal("ID").ToString).ToString
            sdr.Close()
            txtColAnnouncement.EditValue = Nothing
            cboInvOil.SetEditValue(-1) : cboInvGas.SetEditValue(-1)
            cboInvOil.EditValue = Nothing : cboInvGas.EditValue = Nothing
            cboAnnouncements.EditValue = Nothing
            lblInf.Text = "" : lblInf2.Text = "" : lblInf3.Text = "" : lblInf4.Text = ""
            InhFieldAndValues = New Dictionary(Of String, String)
            LoadForms.LoadForm(LayoutControl1, "Select * from vw_INH where id = " & toSQLValueS(sID), False, InhFieldAndValues)
            If InhFieldAndValues.Item("mdt") <> "" Then lblInf.Text = "Το παραστατικό υπολογίσθηκε με ώρες θέρμανσης: " & CDate(InhFieldAndValues.Item("mdt")).ToString("dd/MM/yyyy") : cboAhpbH.EditValue = System.Guid.Parse(InhFieldAndValues.Item("ahpb_HID")) Else lblInf.Text = "" : cboAhpbH.EditValue = Nothing
            If InhFieldAndValues.Item("mdtBoiler") <> "" Then lblInf2.Text = "Το παραστατικό υπολογίσθηκε με ώρες Boiler: " & CDate(InhFieldAndValues.Item("mdtBoiler")).ToString("dd/MM/yyyy") : cboAhpbHB.EditValue = System.Guid.Parse(InhFieldAndValues.Item("ahpb_HIDB")) Else lblInf2.Text = "" : cboAhpbHB.EditValue = Nothing
            If InhFieldAndValues.Item("OilInvDate") <> "" And chkCalculated.Checked = True Then
                lblInf3.Text = "Το παραστατικό υπολογίσθηκε με το/τα τιμολόγιο/α Πετρελάιου: " & InhFieldAndValues.Item("OilInvDate").ToString()
                If cboInvOil.Text = "" Then cboInvOil.EditValue = Nothing
            End If
            If InhFieldAndValues.Item("GasInvDate") <> "" And chkCalculated.Checked = True Then
                lblInf4.Text = "Το παραστατικό υπολογίσθηκε με το/τα τιμολόγιο/α Φυσικού Αερίου: " & InhFieldAndValues.Item("GasInvDate").ToString()
                If cboInvGas.Text = "" Then cboInvGas.EditValue = Nothing
            End If

            If cboInvOil.Properties.GetItems.Count <> 0 Or cboInvGas.Properties.GetItems.Count <> 0 Then
                'cmd = New SqlCommand("Select 1 as sKey,invOilID as invOilGasID from IND where invOilID is not null and inhID = " & toSQLValueS(sID) &
                '                                    "UNION Select 2 as sKey,invGasID as invOilGasID from IND where invGasID is not null and inhID = " & toSQLValueS(sID), CNDB)
                cmd = New SqlCommand("Select 1 as sKey,invOilID as invOilGasID from IND 
                                                                inner join INH   ON INH.id = IND.inhID where calculated= 0 and 
                                                                invOilID is not null and inhID = " & toSQLValueS(sID) &
                                                    "UNION      Select 2 as sKey,invGasID as invOilGasID 
                                                                from IND inner join INH   ON INH.id = IND.inhID where calculated= 0 and 
                                                                invGasID is not null and inhID = " & toSQLValueS(sID), CNDB)


                sdr = cmd.ExecuteReader()
                If sdr.HasRows Then
                    While sdr.Read()
                        Select Case sdr("sKey")
                            Case "1" : If sdr("invOilGasID").ToString <> "" Then cboInvOil.Properties.GetItems.Item(System.Guid.Parse(sdr("invOilGasID").ToString)).CheckState = CheckState.Checked
                            Case "2" : If sdr("invOilGasID").ToString <> "" Then cboInvGas.Properties.GetItems.Item(System.Guid.Parse(sdr("invOilGasID").ToString)).CheckState = CheckState.Checked
                        End Select
                    End While
                End If
                sdr.Close()
            End If



            Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
            Me.Vw_INCTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INC, System.Guid.Parse(sID))
            If lblCancel.Text = "True" Then
                lblCancel.Text = "ΑΚΥΡΩΜΕΝΟ"
                lCanceled.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LcmdSaveINH.Enabled = False : LcmdCancelInvoice.Enabled = False : LcmdCalculate.Enabled = False : LcmdSaveInd.Enabled = False : GridView5.OptionsBehavior.Editable = False
            Else
                lCanceled.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LcmdSaveINH.Enabled = True : LcmdCalculate.Enabled = True : LcmdSaveInd.Enabled = True : GridView5.OptionsBehavior.Editable = True
                'cmdCancelInvoice.Enabled = True 
            End If
            If chkCalculated.Checked = True Then
                LcmdCancelCalculate.Enabled = True : LcmdCalculate.Enabled = False : GridView5.OptionsBehavior.Editable = False : cmdSaveInd.Enabled = False
                LcmdSaveINH.Enabled = False
            Else
                LcmdCancelCalculate.Enabled = False : LcmdCalculate.Enabled = True : GridView5.OptionsBehavior.Editable = True : cmdSaveInd.Enabled = True
                LcmdSaveINH.Enabled = True
            End If
            If chkExtraordinary.CheckState = CheckState.Checked Then LcmdSaveINH.Enabled = False
            If TabPane1.SelectedPageIndex = 1 Then EditRecord()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function SetNavigatorPosition() As Integer
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim Code As Integer
        Try
            sSQL = "select count(id) + 1  as Position  from inh where bdgID= " & toSQLValueS(cboBDG.EditValue.ToString) & " and   cast(tdate as date) <" & toSQLValueS(CDate(dtTDate.EditValue).ToString("yyyyMMdd"))
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then Code = sdr.GetInt32(sdr.GetOrdinal("Position")) - 1 Else Code = 0
            sdr.Close()
            Return Code
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub cmdCancelInvoice_Click(sender As Object, e As EventArgs) Handles cmdCancelInvoice.Click
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim Credit As Decimal
        If XtraMessageBox.Show("Θέλετε να ακυρώσετε το παραστατικό?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            sSQL = "Select   sum(isnull(credit,0)) As credit  from col_d where inhID = " & toSQLValueS(sID)
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then If sdr.IsDBNull(sdr.GetOrdinal("credit")) = False Then Credit = sdr.GetDecimal(sdr.GetOrdinal("credit")) Else Credit = 0
            sdr.Close()
            If Credit > 0 Then XtraMessageBox.Show("Έχετε εισπράξει από αυτό το παραστατικό " & Credit & "€. Θα πρέπει να ξαναπεράσετε τις εισπράξεις αυτές στο νέο παραστατικό", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Using oCmd As New SqlCommand("inv_cancel", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@inhid", sID.ToUpper)
                oCmd.Parameters.AddWithValue("@canceledBY", UserProps.ID.ToString.ToUpper)
                oCmd.ExecuteNonQuery()
            End Using
            lblCancel.Visible = True
            lCanceled.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            lblCancel.Text = "ΑΚΥΡΩΜΕΝΟ"
            LcmdSaveINH.Enabled = False : LcmdCancelInvoice.Enabled = False : LcmdCalculate.Enabled = False : LcmdSaveInd.Enabled = False : GridView5.OptionsBehavior.Editable = False
        End If


    End Sub

    Private Sub GridView5_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView5.ValidatingEditor
        Dim grdView As GridView = sender
        If grdView.FocusedColumn.FieldName <> "repName" Then Exit Sub
        If CheckRepNameIfExists(e.Value) = True Then
            e.ErrorText = "Υπάρχει ίδιο λεκτικό εκτύπωσης σε άλλο έξοδο."
            e.Valid = False
        End If
    End Sub
    Private Function CheckRepNameIfExists(ByVal repName As String, Optional ByVal CheckForUpTo1 As Boolean = False) As Boolean
        ' Παίρνει το μεγαλύτερο Α/Α και το αυξάνει κατα 1
        Dim cmd As SqlCommand = New SqlCommand("Select  count(repName) As CountRep FROM IND WHERE INHID= " & toSQLValueS(sID) & " AND repName =  " & toSQLValueS(repName.Replace("'", "''")), CNDB)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            If CheckForUpTo1 = True Then
                If sdr.GetInt32(sdr.GetOrdinal("CountRep")) > 1 Then
                    sdr.Close()
                    Return True
                End If
            Else
                If sdr.GetInt32(sdr.GetOrdinal("CountRep")) = 1 Then
                    sdr.Close()
                    Return True
                End If
            End If
        End If
        Return False
    End Function
    Private Sub cboAhpbH_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboAhpbH.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageAHPB(cboAhpbH, FormMode.EditRecord, cboAhpbH.Text, False, cboBDG.EditValue.ToString)
            Case 2 : If cboAhpbH.EditValue = Nothing Then Exit Sub
                ManageCbo.ManageAHPB(cboAhpbH, FormMode.EditRecord, cboAhpbH.Text, False, cboBDG.EditValue.ToString)
            Case 3 : Me.AHPB_HTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.AHPB_H, cboBDG.EditValue)
            Case 4 : cboAhpbH.EditValue = Nothing : lblInf.Text = ""
        End Select
    End Sub

    Private Sub cboAhpbHB_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboAhpbHB.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageAHPB(cboAhpbHB, FormMode.EditRecord, cboAhpbHB.Text, True, cboBDG.EditValue.ToString)
            Case 2 : If cboAhpbHB.EditValue = Nothing Then Exit Sub
                ManageCbo.ManageAHPB(cboAhpbHB, FormMode.EditRecord, cboAhpbHB.Text, True, cboBDG.EditValue.ToString)
            Case 3 : Me.AHPB_ΒTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.AHPB_Β, cboBDG.EditValue)
            Case 4 : cboAhpbHB.EditValue = Nothing : lblInf2.Text = ""
        End Select
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs)
        LayoutControl1.Enabled = True
    End Sub
    Private Sub BarSygentrotiki_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarSygentrotiki.ItemClick
        Try
            Dim report As New Rep_Sygentrotiki()
            ' Εαν έχει FI
            If cboBDG.GetColumnValue("HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Then report.HasFI = True Else report.HasFI = False
            ' Εαν έχει FI Boiler
            If cboBDG.GetColumnValue("BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Then report.HasFIBoiler = True Else report.HasFIBoiler = False


            'If cboAhpbH.EditValue IsNot Nothing Then report.HasHoursH = True Else report.HasHoursH = False
            'If cboAhpbB.EditValue IsNot Nothing Then report.HasHoursBoiler = True Else report.HasHoursBoiler = False
            If lblInf.Text.Length > 0 Then report.HasHoursH = True Else report.HasHoursH = False
            If lblInf2.Text.Length > 0 Then report.HasHoursBoiler = True Else report.HasHoursBoiler = False
            report.Parameters.Item(0).Value = sID
            report.Parameters.Item(1).Value = cboBDG.EditValue.ToString
            report.INHForm = Me
            SplashScreenManager1.ShowWaitForm()
            SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")
            report.CreateDocument()
            report.PrintingSystem.Document.ScaleFactor = 0.99
            Dim printTool As New ReportPrintTool(report)
            If chkCalculated.Checked = False Then
                Dim printingSystem As PrintingSystemBase = printTool.PrintingSystem
                printingSystem.SetCommandVisibility(New PrintingSystemCommand() {
                PrintingSystemCommand.ExportCsv, PrintingSystemCommand.ExportTxt, PrintingSystemCommand.ExportDocx,
                PrintingSystemCommand.ExportHtm, PrintingSystemCommand.ExportMht, PrintingSystemCommand.ExportPdf,
                PrintingSystemCommand.ExportRtf, PrintingSystemCommand.ExportXls, PrintingSystemCommand.ExportXlsx,
                PrintingSystemCommand.ExportGraphic, PrintingSystemCommand.Print, PrintingSystemCommand.PrintDirect,
                PrintingSystemCommand.PrintSelection}, CommandVisibility.None)
            End If
            printTool.ShowRibbonPreview()
            SplashScreenManager1.CloseWaitForm()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BarEidop_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarEidop.ItemClick
        Dim report As New Eidop()
        report.Parameters.Item(0).Value = sID
        ' report.Parameters.Item(1).Value = cboBDG.EditValue
        SplashScreenManager1.ShowWaitForm()
        SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")
        report.INHForm = Me
        report.CreateDocument()
        Dim printTool As New ReportPrintTool(report)
        If chkPrintSyg.Checked = False Then
            Dim printingSystem As PrintingSystemBase = printTool.PrintingSystem
            printingSystem.SetCommandVisibility(New PrintingSystemCommand() {
            PrintingSystemCommand.ExportCsv, PrintingSystemCommand.ExportTxt, PrintingSystemCommand.ExportDocx,
            PrintingSystemCommand.ExportHtm, PrintingSystemCommand.ExportMht, PrintingSystemCommand.ExportPdf,
            PrintingSystemCommand.ExportRtf, PrintingSystemCommand.ExportXls, PrintingSystemCommand.ExportXlsx,
            PrintingSystemCommand.ExportGraphic, PrintingSystemCommand.Print, PrintingSystemCommand.PrintDirect,
            PrintingSystemCommand.PrintSelection}, CommandVisibility.None)
        End If
        printTool.ShowRibbonPreview()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BarReceipt_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarReceipt.ItemClick
        'Dim report As New Eidop()
        Dim report As New Receipt
        Dim sMargins As New System.Drawing.Printing.Margins
        report.Parameters.Item(0).Value = sID
        ' report.Parameters.Item(1).Value = cboBDG.EditValue
        SplashScreenManager1.ShowWaitForm()
        SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")
        report.PrintingSystem.Document.ScaleFactor = 0.92
        report.DefaultPrinterSettingsUsing.UsePaperKind = False
        report.DefaultPrinterSettingsUsing.UseMargins = False
        sMargins.Bottom = 50 : sMargins.Top = 90 : sMargins.Left = 100 : sMargins.Right = 50
        report.INHForm = Me
        report.Margins = sMargins
        report.CreateDocument()
        Dim printTool As New ReportPrintTool(report)
        ' Αν δεν έχει εκτυπωθεί ειδοποίηση μόνο τότε μπορεί να εκτυπωθεί απόδειξη
        If chkPrintEidop.Checked = False And chkreserveAPT.Checked = False Then
            Dim printingSystem As PrintingSystemBase = printTool.PrintingSystem
            printingSystem.SetCommandVisibility(New PrintingSystemCommand() {
            PrintingSystemCommand.ExportCsv, PrintingSystemCommand.ExportTxt, PrintingSystemCommand.ExportDocx,
            PrintingSystemCommand.ExportHtm, PrintingSystemCommand.ExportMht, PrintingSystemCommand.ExportPdf,
            PrintingSystemCommand.ExportRtf, PrintingSystemCommand.ExportXls, PrintingSystemCommand.ExportXlsx,
            PrintingSystemCommand.ExportGraphic, PrintingSystemCommand.Print, PrintingSystemCommand.PrintDirect,
            PrintingSystemCommand.PrintSelection}, CommandVisibility.None)
        End If
        printTool.ShowRibbonPreview()
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub cmdExit_Click_1(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdCancelCalculate_Click(sender As Object, e As EventArgs) Handles cmdCancelCalculate.Click
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim Credit As Decimal

        If CheckIfisLastINH() = False Then
            XtraMessageBox.Show("Δεν μπορείτε να ακυρώσετε το παραστατικό όταν υπάρχουν μεταγενέστερα.Ακύρωση επιτρέπεται μόνο στο τελευταίο παραστατικό.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If XtraMessageBox.Show("Θέλετε να ακυρώσετε τον υπολογισμό του παραστατικού?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            sSQL = "Select   sum(isnull(credit,0)) As credit  from col_d where inhID = " & toSQLValueS(sID)
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then If sdr.IsDBNull(sdr.GetOrdinal("credit")) = False Then Credit = sdr.GetDecimal(sdr.GetOrdinal("credit")) Else Credit = 0
            sdr.Close()
            If Credit > 0 Then
                XtraMessageBox.Show("Έχετε εισπράξει από αυτό το παραστατικό " & Credit & "€. Δεν μπορείτε να προχωρήσετε σε ακύρωση αν δεν επαναφέρετε τις εισπράξεις.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Using oCmd As New SqlCommand("inv_cancelCalculate", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@inhid", sID.ToUpper)
                oCmd.ExecuteNonQuery()
            End Using
            ' Ενημέρωση αποθεματικού
            CalculateDepositA(cboBDG.EditValue.ToString)
            LcmdCalculate.Enabled = True : GridView5.OptionsBehavior.Editable = True : cmdCancelCalculate.Enabled = False
            chkCalculated.Checked = False : chkPrintEidop.Checked = False : chkPrintReceipt.Checked = False : chkPrintSyg.Checked = False
            cmdSaveInd.Enabled = True : cmdDel.Enabled = True : cmdSaveINH.Enabled = True : cmdPrintAll.Enabled = False
            Me.AHPB_HTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.AHPB_H, cboBDG.EditValue)
            Me.AHPB_ΒTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.AHPB_Β, cboBDG.EditValue)
            Me.Vw_INDTableAdapter.Fill(Me.Priamos_NET_DataSet_INH.vw_IND, System.Guid.Parse(sID))
            Me.INV_OILTableAdapter.FillbyBDG(Me.Priamos_NET_DataSet_INH.INV_OIL, cboBDG.EditValue)
            Me.INV_GASTableAdapter.FillByBDG(Me.Priamos_NET_DataSet_INH.INV_GAS, cboBDG.EditValue)

            lblInf2.Text = "" : lblInf.Text = "" : lblInf3.Text = "" : lblInf4.Text = ""
            cboAhpbH.EditValue = Nothing
            cboAhpbHB.EditValue = Nothing
        End If
    End Sub
    Private Function CheckIfisLastINH() As Boolean
        Dim sinhID As String
        Dim sSQL As New System.Text.StringBuilder
        sSQL.AppendLine("select ID from inh (nolock)  where bdgid= " & toSQLValueS(cboBDG.EditValue.ToString))
        sSQL.AppendLine("and calorimetric = " & toSQLValueS(chkCalorimetric.EditValue.ToString))
        sSQL.AppendLine("and reserveAPT = " & toSQLValueS(chkreserveAPT.EditValue.ToString))
        sSQL.AppendLine("and extraordinary = " & toSQLValueS(chkExtraordinary.EditValue.ToString))
        sSQL.AppendLine("and fromtransfer = " & toSQLValueS(chkFromTransfer.EditValue.ToString))
        sSQL.AppendLine("and calculated = 1 ")
        sSQL.AppendLine("and tdate=(select max(tdate) from inh (nolock) where bdgid= " & toSQLValueS(cboBDG.EditValue.ToString))
        sSQL.AppendLine("and calorimetric = " & toSQLValueS(chkCalorimetric.EditValue.ToString))
        sSQL.AppendLine("and reserveAPT = " & toSQLValueS(chkreserveAPT.EditValue.ToString))
        sSQL.AppendLine("and extraordinary = " & toSQLValueS(chkExtraordinary.EditValue.ToString))
        sSQL.AppendLine("and fromtransfer = " & toSQLValueS(chkFromTransfer.EditValue.ToString) & " and calculated = 1 )")

        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        cmd = New SqlCommand(sSQL.ToString, CNDB)
        sdr = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            sinhID = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
            If sinhID.ToUpper = sID.ToUpper Then
                sdr.Close()
                Return True
            Else
                sdr.Close()
                Return False
            End If
        Else
            sdr.Close()
            Return False
        End If


    End Function


    Private Sub chkCalorimetric_CheckStateChanged(sender As Object, e As EventArgs) Handles chkCalorimetric.CheckStateChanged
        If chkCalorimetric.Checked = True Then
            LayoutControlGroup2.Enabled = False
        Else
            LayoutControlGroup2.Enabled = True
        End If

    End Sub

    ' Copy Cell
    Private Sub BarCopyCell_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyCell.ItemClick
        Dim view As GridView = CType(GridView5, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
        End If
    End Sub
    'Copy All
    Private Sub BarCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyAll.ItemClick
        GridView5.OptionsSelection.MultiSelect = True
        GridView5.SelectAll()
        GridView5.CopyToClipboard()
        GridView5.OptionsSelection.MultiSelect = False
    End Sub
    'Copy Row
    Private Sub BarCopyRow_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyRow.ItemClick
        Dim view As GridView = CType(GridView5, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            GridView5.OptionsSelection.MultiSelect = True
            GridView5.SelectRow(view.FocusedRowHandle)
            GridView5.CopyToClipboard()
            GridView5.OptionsSelection.MultiSelect = False
        End If
    End Sub

    Private Sub cboAhpbH_EditValueChanged(sender As Object, e As EventArgs) Handles cboAhpbH.EditValueChanged
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger
    End Sub

    Private Sub cboAhpbHB_EditValueChanged(sender As Object, e As EventArgs) Handles cboAhpbHB.EditValueChanged
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger
    End Sub

    Private Sub cboAnnouncements_EditValueChanged(sender As Object, e As EventArgs) Handles cboAnnouncements.EditValueChanged
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger
    End Sub

    Private Sub txtComments_EditValueChanged(sender As Object, e As EventArgs) Handles txtComments.EditValueChanged
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger
    End Sub

    Private Sub txtBdgCmt_EditValueChanged(sender As Object, e As EventArgs) Handles txtBdgCmt.EditValueChanged
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger
    End Sub

    Private Sub chkExtraordinary_EditValueChanged(sender As Object, e As EventArgs) Handles chkExtraordinary.EditValueChanged
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger
    End Sub

    Private Sub chkCalorimetric_EditValueChanged(sender As Object, e As EventArgs) Handles chkCalorimetric.EditValueChanged
        If Me.IsActive Then LayoutControlGroup1.AppearanceGroup.BorderColor = DXSkinColors.FillColors.Danger
    End Sub

    Private Sub txtColAnnouncement_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtColAnnouncement.ButtonClick
        txtColAnnouncement.Text = "" : txtColAnnouncement.EditValue = Nothing

    End Sub

    Private Sub GridView5_DoubleClick(sender As Object, e As EventArgs) Handles GridView5.DoubleClick
        If GridView5.IsGroupRow(GridView5.FocusedRowHandle) = False Then
            SplashScreenManager1.ShowWaitForm()
            SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")
            OpenPreviwer()
        End If
    End Sub

    Private Sub cboInvOil_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboInvOil.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboInvOil.EditValue = Nothing : ManageCbo.ManageHeatingInvoicesCheckBox(cboInvOil, FormMode.EditRecord, cboBDG.EditValue.ToString)
            Case 2 : If cboInvOil.EditValue <> Nothing Then ManageCbo.ManageHeatingInvoicesCheckBox(cboInvOil, FormMode.EditRecord, cboBDG.EditValue.ToString)
            Case 3 : cboInvOil.EditValue = Nothing : cboInvOil.SetEditValue(-1)
        End Select

    End Sub

    Private Sub cboInvGas_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboInvGas.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboInvGas.EditValue = Nothing : ManageCbo.ManageHeatingInvoicesCheckBox(cboInvGas, FormMode.EditRecord, cboBDG.EditValue.ToString)
            Case 2 : If cboInvGas.EditValue <> Nothing Then ManageCbo.ManageHeatingInvoicesCheckBox(cboInvGas, FormMode.EditRecord, cboBDG.EditValue.ToString)
            Case 3 : cboInvGas.EditValue = Nothing : cboInvGas.SetEditValue(-1)
        End Select
    End Sub
    Private Sub cmdBatchFileEX_Click(sender As Object, e As EventArgs) Handles cmdBatchFileEX.Click
        Dim form As frmBatchInsertAttachmentsEX = New frmBatchInsertAttachmentsEX()
        form.Text = "Επισύναψη αρχείων εξόδων"
        If cboBDG.EditValue IsNot Nothing Then form.BDGID = cboBDG.EditValue.ToString
        form.StartPosition = FormStartPosition.CenterScreen
        form.Show()
    End Sub

    Private Sub cboCALC_CAT_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboCALC_CAT.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboCALC_CAT.EditValue = Nothing : ManageCbo.ManageCalcCat(cboCALC_CAT, FormMode.NewRecord)
            Case 2 : If cboCALC_CAT.EditValue <> Nothing Then ManageCbo.ManageCalcCat(cboCALC_CAT, FormMode.EditRecord)
            Case 3 : cboCALC_CAT.EditValue = Nothing
        End Select

    End Sub
End Class