﻿Imports System.IO
'Imports iTextSharp.text 'Core PDF Text Functionalities
'Imports iTextSharp.text.pdf 'PDF Content
'Imports iTextSharp.text.pdf.parser
Imports System.Data.SqlClient
Imports DevExpress.Utils.Menu
Imports DevExpress.Utils
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Calendar
Imports DevExpress.XtraEditors.Controls
Imports System.ComponentModel
Imports DevExpress.XtraPrinting
Imports DevExpress.Export
Imports System.Drawing.Printing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.DataProcessing

Public Class frmBDG
    '------Private Variables Declaration------
    Private sID As String = ""

    Private sManageID As String

    Private Iam As String
    Private Aam As String
    Public Mode As Byte
    Private bdgName As String
    Private Bmlc As New Dictionary(Of String, String)
    Private ApmilFieldsToBeUpdate As New List(Of String)
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Private CtrlCombo As DevExpress.XtraEditors.LookUpEdit
    Private CtrlComboCheckedComboBoxEdit As DevExpress.XtraEditors.CheckedComboBoxEdit
    Private CalledFromCtrl As Boolean
    Private ModeBCCT As Byte
    Private ModePROFACTD As Byte
    Private ActiveGrid As GridView
    Private CommentsChanged As Boolean = False

    '------C L A S S E S------
    Private ManageCbo As New CombosManager
    Private UserPermissions As New CheckPermissions
    Private Valid As New ValidateControls
    
    Private FillCbo As New FillCombos
    Private Apmil As New Apmil
    Private InvOils As New InvOilGas
    Private InvGas As New InvOilGas
    Private BdgManage As New BManage
    Private DBQ As New DBQueries
    Private LoadForms As New FormLoader
    Private EnDisControls As New EnableControls
    Private Cls As New ClearControls
    Friend Class MenuColumnInfo
        Public Sub New(ByVal column As GridColumn)
            Me.Column = column
        End Sub
        Public Column As GridColumn
    End Class
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property bManageID As String
        Set(value As String)
            sManageID = value
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
    Public WriteOnly Property CallerControl As DevExpress.XtraEditors.LookUpEdit
        Set(value As DevExpress.XtraEditors.LookUpEdit)
            CtrlCombo = value
        End Set
    End Property
    Public WriteOnly Property CallerControlCheckedComboBoxEdit As DevExpress.XtraEditors.CheckedComboBoxEdit
        Set(value As DevExpress.XtraEditors.CheckedComboBoxEdit)
            CtrlComboCheckedComboBoxEdit = value
        End Set
    End Property
    Public WriteOnly Property CalledFromControl As Boolean
        Set(value As Boolean)
            CalledFromCtrl = value
        End Set
    End Property


    Private Sub frmBDG_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_BDG.vw_FOLDER_CAT' table. You can move, or remove it, as needed.
        Me.Vw_FOLDER_CATTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_FOLDER_CAT)

        'TODO: This line of code loads data into the 'Priamos_NETDataSet.ANN_GRPS' table. You can move, or remove it, as needed.
        Me.ANN_GRPSTableAdapter.Fill(Me.Priamos_NETDataSet.ANN_GRPS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet2.Collectors' table. You can move, or remove it, as needed.
        Me.CollectorsTableAdapter.Fill(Me.Priamos_NETDataSet.Collectors)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_FOLDER_CAT' table. You can move, or remove it, as needed.
        Me.Vw_FOLDER_CATTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_FOLDER_CAT)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_DOY' table. You can move, or remove it, as needed.
        Me.Vw_DOYTableAdapter.Fill(Me.Priamos_NETDataSet.vw_DOY)
        Me.Vw_PRFTableAdapter.Fill(Me.Priamos_NETDataSet.vw_PRF)
        Me.Vw_CCTTableAdapter.FillByAll(Me.Priamos_NETDataSet.vw_CCT)
        AddHandler grdBDG_M.EmbeddedNavigator.ButtonClick, AddressOf Grid_EmbeddedNavigator_ButtonClick
        If sID.Length = 0 Then
            Me.BDGKeysManagerTableAdapter.Fill(Me.Priamos_NETDataSet.BDGKeysManager, System.Guid.Empty)
        Else
            Me.BDGKeysManagerTableAdapter.Fill(Me.Priamos_NETDataSet.BDGKeysManager, System.Guid.Parse(sID))
        End If
        DevExpress.XtraGrid.Localization.GridLocalizer.Active = New GridGreekLocalizer()
        Dim sSQL As New System.Text.StringBuilder
        'txtAam.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        'txtIam.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        'txtAam.Properties.Mask.EditMask = "c" & ProgProps.Decimals
        'txtIam.Properties.Mask.EditMask = "c" & ProgProps.Decimals
        'Νομοί
        FillCbo.COU(cboCOU)

        Select Case Mode
            Case FormMode.NewRecord
                FillCbo.FillCheckedListMLC(chkMLC, FormMode.NewRecord)
                dtDTS.EditValue = DateTime.Now
                txtCode.Text = DBQ.GetNextId("BDG")
                cmdAPTAdd.Enabled = False
                cmdAptDel.Enabled = False
                cmdAPTEdit.Enabled = False
                cmdAptRefresh.Enabled = False
                NavManage.Enabled = False
                NavHeating.Enabled = False
                NavMaintenance.Enabled = False
                NavFixedCosts.Enabled = False
                NavProfActD.Enabled = False
                NavHeatingInvoices.Enabled = False
                NavDecontamination.Enabled = False
                NavConsumption.Enabled = False
                NavDeposit.Enabled = False
                NavAPM.Enabled = False
                NavINH.Enabled = False
                chkPRD.Checked = True
                grdBDG_M.Enabled = False
            Case FormMode.EditRecord
                FillCbo.FillCheckedListMLC(chkMLC, FormMode.EditRecord, sID, Bmlc)
                If cboCOU.EditValue <> Nothing Then sSQL.AppendLine(" where couid = " & toSQLValueS(cboCOU.EditValue.ToString))
                FillCbo.AREAS(cboAREAS, sSQL)
                Dim myLayoutControls As New List(Of System.Windows.Forms.Control)
                myLayoutControls.Add(LayoutControl1BDG) : myLayoutControls.Add(LayoutControl2BDG_1)
                myLayoutControls.Add(LayoutControl2BDG_2) : myLayoutControls.Add(LayoutControl2BDG_3) : myLayoutControls.Add(LayoutControl2BDG_4)
                LoadForms.LoadFormNew(myLayoutControls, "Select * from vw_BDG where id ='" + sID + "'", False)
                'LoadForms.LoadForm(LayoutControl1BDG, "Select * from vw_BDG where id ='" + sID + "'", True)
                Iam = txtIam.EditValue
                Aam = txtAam.EditValue
                LoadForms.LoadDataToGrid(grdAPT, GridView1, "SELECT * FROM VW_APT where bdgid ='" + sID + "' ORDER BY ORD")
                Me.Text = "Πολυκατοικία: " & txtNam.Text
                Me.Vw_BDG_MTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_BDG_M, System.Guid.Parse(sID))
                Me.Vw_CCTTableAdapter.FillByAll(Me.Priamos_NETDataSet.vw_CCT)
        End Select
        NavDeposit.Enabled = chkKeepDeposit.Checked
        Maintab.ShowTabHeader = Maintab.ShowTabHeader.False
        ' Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        'Me.CenterToScreen()
        'Me.Size = New Size(2244, 1444)

        'My.Settings.frmBDG = Me.Location
        '  My.Settings.Save()
        bdgName = txtNam.Text
        LoadForms.RestoreLayoutFromXml(GridView1, "APT_def.xml")
        LoadForms.RestoreLayoutFromXml(GridView12, "BDGManagers_def.xml")
        GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub frmBDG_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub
    Private Sub txtTK_LostFocus(sender As Object, e As EventArgs) Handles txtTK.LostFocus
        FillCbo.ADR(cboADR, ADRsSQL)
    End Sub
    Private Sub cboCOU_EditValueChanged(sender As Object, e As EventArgs) Handles cboCOU.EditValueChanged
        Dim sSQL As New System.Text.StringBuilder
        If cboCOU.EditValue <> Nothing Then sSQL.AppendLine(" where couid = " & toSQLValueS(cboCOU.EditValue.ToString))
        FillCbo.AREAS(cboAREAS, sSQL)
        FillCbo.ADR(cboADR, ADRsSQL)
    End Sub
    Private Sub cboAREAS_EditValueChanged(sender As Object, e As EventArgs) Handles cboAREAS.EditValueChanged
        FillCbo.ADR(cboADR, ADRsSQL)
    End Sub


    Private Function ADRsSQL() As System.Text.StringBuilder
        Dim sSQL As New System.Text.StringBuilder
        Dim CouID As String = ""
        Dim AreaID As String = ""
        If cboCOU.EditValue <> Nothing Then CouID = cboCOU.EditValue.ToString
        If cboAREAS.EditValue <> Nothing Then AreaID = cboAREAS.EditValue.ToString
        sSQL.AppendLine("Select id,Name,tk from vw_ADR ")
        If CouID.Length > 0 Or AreaID.Length > 0 Or txtTK.Text.Length > 0 Then sSQL.AppendLine(" where ")
        If CouID.Length > 0 Then sSQL.AppendLine(" couid = " & toSQLValueS(CouID))
        If AreaID.Length > 0 Then
            If CouID.Length > 0 Then sSQL.AppendLine(" AND ")
            sSQL.AppendLine(" AreaID = " & toSQLValueS(AreaID))
        End If
        If txtTK.Text.Length > 0 Then
            If CouID.Length > 0 Or AreaID.Length > 0 Then sSQL.AppendLine(" AND ")
            sSQL.AppendLine(" TK = " & toSQLValue(txtTK))
        End If
        sSQL.AppendLine(" order by name ")
        Return sSQL
    End Function
    Private Sub txtAR_Validated(sender As Object, e As EventArgs) Handles txtAR.Validated
        txtNam.Text = cboADR.Text + " " + txtAR.Text
    End Sub

    Private Sub cboADR_EditValueChanged(sender As Object, e As EventArgs) Handles cboADR.EditValueChanged
        If sender.editvalue <> Nothing And txtNam.Text.Length = 0 Then txtNam.Text = cboADR.Text + " " + txtAR.Text : bdgName = txtNam.Text 'Else txtNam.Text = ""
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Dim sGuid As String
        Try
            If Valid.ValidateForm(LayoutControl1BDG) Then
                'Dim myLayoutControls As New List(Of Control)
                'myLayoutControls.Add(LayoutControl1BDG) : myLayoutControls.Add(LayoutControl3Heating)
                Dim myLayoutControls As New List(Of System.Windows.Forms.Control)
                myLayoutControls.Add(LayoutControl1BDG) : myLayoutControls.Add(LayoutControl2BDG_1)
                myLayoutControls.Add(LayoutControl2BDG_2) : myLayoutControls.Add(LayoutControl2BDG_3) : myLayoutControls.Add(LayoutControl2BDG_4)
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        'sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "BDG", LayoutControl1BDG,,, sGuid, True)
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.MultipleLayoutControls, "BDG", , myLayoutControls,, sGuid)
                    Case FormMode.EditRecord
                        'sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "BDG", LayoutControl1BDG,,, sID, True)
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.MultipleLayoutControls, "BDG",, myLayoutControls,, sID)
                End Select
                If sResult Then
                    'Ενεργοποίηση Μπάρας
                    NavManage.Enabled = True
                    NavHeating.Enabled = True
                    NavMaintenance.Enabled = True
                    NavFixedCosts.Enabled = True
                    NavProfActD.Enabled = True
                    NavHeatingInvoices.Enabled = True
                    NavDecontamination.Enabled = True
                    NavConsumption.Enabled = True
                    NavDeposit.Enabled = True
                    NavAPM.Enabled = True
                    NavINH.Enabled = True
                    grdBDG_M.Enabled = True
                    If Mode = FormMode.NewRecord Then sID = sGuid
                    ' Εαν έχει γίνει αλλαγή στην αμοιβή διαχείρισης
                    If Aam <> txtAam.EditValue Then
                        Dim sSQL As String
                        sSQL = "INSERT INTO AAM_H(aam,bdgid,modifiedBy,createdOn) values (" &
                                toSQLValue(txtIam, True) & "," & toSQLValueS(sID) & "," & toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                        Aam = txtAam.EditValue
                    End If

                    ' Εαν έχει γίνει αλλαγή στην αμοιβή έκδοσης
                    If Iam <> txtIam.EditValue Then
                        Dim sSQL As String
                        sSQL = "INSERT INTO IAM_H(iam,bdgid,modifiedBy,createdOn) values (" &
                                   toSQLValue(txtIam, True) & "," & toSQLValueS(sID) & "," & toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                        Iam = txtIam.EditValue
                    End If
                    ' Έαν είναι νέα εγγραφή καταχωρώ πάντα μια εγγραφή στον πίνακα BMANAGE(Διαχείρηση)
                    If Mode = FormMode.NewRecord Then
                        Dim sSQL As String
                        sManageID = System.Guid.NewGuid.ToString
                        sSQL = "INSERT INTO BMANAGE(ID,bdgID,createdOn) values (" & toSQLValueS(sManageID) & "," & toSQLValueS(sGuid) & ", getdate() )"
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                        Mode = FormMode.EditRecord : sID = sGuid
                    End If

                    'Όταν είναι σε EditMode διαγραφουμε όλες τις κατηγορίες και τις ξανακαταχωρούμε
                    Dim sSQL2 As String
                    If Mode = FormMode.EditRecord Then
                        sSQL2 = "DELETE FROM BMLC where BDGID = '" & sID & "'"
                        Using oCmd As New SqlCommand(sSQL2, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                    End If

                    ' Καταχώρηση Χιλιοστών πολυκατοικίας
                    For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In chkMLC.CheckedItems
                        sSQL2 = "INSERT INTO BMLC ([BDGID],[mlcID],[modifiedBy],[createdOn])  
                                        values (" & toSQLValueS(sID) & "," & toSQLValueS(item.Tag.ToString()) & "," &
                                                        toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                        Using oCmd As New SqlCommand(sSQL2, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                    Next
                    Bmlc.Clear()
                    FillCbo.FillCheckedListMLC(chkMLC, FormMode.EditRecord, sID, Bmlc)

                    If Mode = FormMode.NewRecord Then
                        dtDTS.EditValue = DateTime.Now
                        txtCode.EditValue = DBQ.GetNextId("BDG")
                    End If

                    'Dim form As New frmScroller
                    'form.LoadRecords("vw_BDG", sID)
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CommentsChanged = False
                    Valid.SChanged = False
                    cmdAPTAdd.Enabled = True
                    cmdAptRefresh.Enabled = True
                    cmdAPTEdit.Enabled = True
                    cmdAptDel.Enabled = True
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCode_GotFocus(sender As Object, e As EventArgs) Handles txtCode.GotFocus
        frmMain.bbFields.Caption = "DB Field: BDG.code"
    End Sub

    Private Sub cmdAam_Click(sender As Object, e As EventArgs) Handles cmdAam.Click
        FillAAM_H()
        'FlyoutPanel1.OwnerControl = cmdAam
        'FlyoutPanel1.OptionsBeakPanel.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade
        'FlyoutPanel1.Options.CloseOnOuterClick = True
        'FlyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Manual
        'FlyoutPanel1.ShowPopup()
    End Sub
    Private Sub FillIAM_H()
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT convert(varchar,createdon ,105)+ '  ' + '(' + cast(iam as nvarchar(10)) + ')'  as name
                                                     FROM VW_IAM_H WHERE BDGId = '" & sID & "' order by 1 ", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If sdr.HasRows Then
                lstData.Items.Clear()
                lstData.DisplayMember = "name"
                lstData.ValueMember = "name"
                While sdr.Read()
                    lstData.Items.Add(sdr.Item(0).ToString)
                End While
            End If
            sdr.Close()
            sdr = Nothing
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillAAM_H()
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT convert(varchar,createdon ,105)+ '  ' + '(' + cast(aam as nvarchar(10)) + ')'  as name
                                                     FROM VW_AAM_H WHERE BDGId = '" & sID & "' order by 1 ", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If sdr.HasRows Then
                lstData.Items.Clear()
                lstData.DisplayMember = "name"
                lstData.ValueMember = "name"
                While sdr.Read()
                    lstData.Items.Add(sdr.Item(0).ToString)
                End While
            End If
            sdr.Close()
            sdr = Nothing
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdIam_Click(sender As Object, e As EventArgs) Handles cmdIam.Click
        FillIAM_H()
        'FlyoutPanel1.OwnerControl = cmdIam
        'FlyoutPanel1.OptionsBeakPanel.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade
        'FlyoutPanel1.Options.CloseOnOuterClick = True
        'FlyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Manual
        'FlyoutPanel1.ShowPopup()
    End Sub

    Private Sub cmdAPTAdd_Click(sender As Object, e As EventArgs) Handles cmdAPTAdd.Click
        NewApt()
    End Sub

    Private Sub cmdAptRefresh_Click(sender As Object, e As EventArgs) Handles cmdAptRefresh.Click
        AptRefresh()
    End Sub
    Public Sub AptRefresh()
        LoadForms.LoadDataToGrid(grdAPT, GridView1, "SELECT * FROM VW_APT where bdgid ='" + sID + "' ORDER BY ORD")
        LoadForms.RestoreLayoutFromXml(GridView1, "APT_def.xml")
    End Sub
    Private Sub DeleteApt()
        Dim sSQL As String
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") = Nothing Then Exit Sub

            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM APT WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                AptRefresh()
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NewApt()
        Dim form1 As frmAPT = New frmAPT()
        form1.Text = "Διαμερίσματα"
        'form1.MdiParent = frmMain
        form1.Mode = FormMode.NewRecord
        form1.FormScroller = Me
        form1.BDGID = sID
        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
    End Sub
    Private Sub EditApt()
        Dim form1 As frmAPT = New frmAPT()
        form1.Text = "Διαμερίσματα"
        form1.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
        'form1.MdiParent = frmMain
        form1.Mode = FormMode.EditRecord
        form1.FormScroller = Me
        form1.BDGID = sID
        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
    End Sub
    Private Sub grdAPT_KeyDown(sender As Object, e As KeyEventArgs) Handles grdAPT.KeyDown
        Select Case e.KeyCode
            Case Keys.F2 : If UserProps.AllowInsert = True Then NewApt()
            Case Keys.F3 : If UserProps.AllowEdit = True Then EditApt()
            Case Keys.F5 : AptRefresh()
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteApt()
        End Select
    End Sub

    Private Sub cmdAptDel_Click(sender As Object, e As EventArgs) Handles cmdAptDel.Click
        DeleteApt()
    End Sub

    Private Sub cmdAPTEdit_Click(sender As Object, e As EventArgs) Handles cmdAPTEdit.Click
        EditApt()
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView1, "APT_def.xml", "vw_APT")
        Else
            ActiveGrid = GridView1
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub OnCanGRIDEdit(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        GridView1.OptionsBehavior.Editable = item.Checked
        GridView1.OptionsBehavior.ReadOnly = Not item.Checked
    End Sub

    Private Function CreateEditGRID(ByVal caption As String, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView, ByVal image As System.Drawing.Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (GRD.OptionsBehavior.Editable), image, New EventHandler(AddressOf OnCanGRIDEdit))
        Return item
    End Function

    ' Copy Cell
    Private Sub BarCopyCell_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyCell.ItemClick
        If ActiveGrid.GetRowCellValue(ActiveGrid.FocusedRowHandle, ActiveGrid.FocusedColumn) IsNot Nothing AndAlso ActiveGrid.GetRowCellValue(ActiveGrid.FocusedRowHandle, ActiveGrid.FocusedColumn).ToString() <> [String].Empty Then
            Clipboard.SetText(ActiveGrid.GetRowCellValue(ActiveGrid.FocusedRowHandle, ActiveGrid.FocusedColumn).ToString())
        End If
    End Sub
    'Copy All
    Private Sub BarCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyAll.ItemClick
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        GridView1.OptionsSelection.MultiSelect = False
    End Sub
    'Copy Row
    Private Sub BarCopyRow_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyRow.ItemClick
        Dim view As GridView = CType(GridView1, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            GridView1.OptionsSelection.MultiSelect = True
            GridView1.SelectRow(view.FocusedRowHandle)
            GridView1.CopyToClipboard()
            GridView1.OptionsSelection.MultiSelect = False
        End If
    End Sub

    Private Sub NavHeating_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavHeating.ElementClick
        HeatingSelected()
    End Sub
    Public Sub HeatingSelected()
        Dim sSQL As New System.Text.StringBuilder
        Maintab.SelectedTabPage = tabHeating
        'Τύποι Υπολογισμού
        FillCbo.CALC_TYPES(cboHtypes)
        'Τύποι Υπολογισμού
        FillCbo.CALC_TYPES(cboBtypes)
        'Τύποι Καυσίμων
        FillCbo.FTYPES(cboFtypes)
        sSQL.AppendLine("where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & " ORDER BY mdt desc")
        'Προηγούμενες μετρήσεις
        FillCbo.BEF_MES(cboBefMes, sSQL)
        If Mode = FormMode.NewRecord Then
            'cboHtypes.EditValue = System.Guid.Parse("C331F98B-8504-44CE-9C75-2546B76BAD4E") 'Χωρίς Θέρμανση
        Else
            LoadForms.LoadForm(LayoutControl3Heating, "Select * from BDG where id ='" + sID + "'", True)
        End If

    End Sub

    Private Sub NavHeatingInvoices_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavHeatingInvoices.ElementClick
        HeatingInvoicesSelected()
    End Sub
    Public Sub HeatingInvoicesSelected()
        Maintab.SelectedTabPage = tabHeatingInvoices
        'Προμηθευτές για πετρέλαιο
        FillCbo.SUP(cboOInvSup)
        'Προμηθευτές για φυσικό αέριο
        FillCbo.SUP(cboGInvSup)
        'Πάροχοι
        'FillCbo.PUBLIC_S(cbofService2, "where servicetypeID='F0EE8CF4-2778-4EF8-BCF3-225541551CE6' and id = ( select top 1 fPublicServiceID from BMANAGE where bdgID = " & toSQLValueS(sID) & ")", True)
        Me.Vw_PUBLIC_STableAdapter.FillByFysikoBdgID(Me.Priamos_NET_DataSet_BDG.vw_PUBLIC_S, System.Guid.Parse(sID))
        Me.Vw_MEASURERSTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_MEASURERS)
        Me.Vw_INHNotCalculatedBYBDGTableAdapter.FillByBDG(Me.Priamos_NET_DataSet_INH.vw_INHNotCalculatedBYBdg, System.Guid.Parse(sID))

        Dim table As DataTable = Me.Vw_PUBLIC_STableAdapter.GetDataByFysikoBdgID(System.Guid.Parse(sID))
        If table.Rows.Count > 0 Then cbofService2.EditValue = table.Rows(0).Item(0)
        table.Dispose()

        InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")
        GridView3.OptionsBehavior.Editable = True
        GridView4.OptionsBehavior.Editable = True
        'Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable
        Dim ExcludeControls As New List(Of String)
        ExcludeControls.Add(cmdOInvAdd.Name)
        ExcludeControls.Add(cmdOInvDelete.Name)
        ExcludeControls.Add(cmdOInvRefresh.Name)
        ExcludeControls.Add(cmdOInvAdd.Name)
        EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup5, ExcludeControls)
        InvGas.LoadGasRecords(grdGas, GridView4, "SELECT * FROM  vw_INV_GAS where bdgid ='" + sID + "' ORDER by createdon desc")
        cmdOInvAdd.Checked = False
        'Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable
        ExcludeControls.Clear()
        ExcludeControls.Add(cmdGInvAdd.Name)
        ExcludeControls.Add(cmdGInvDelete.Name)
        ExcludeControls.Add(cmdGInvRefresh.Name)
        EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup6, ExcludeControls)
        cmdGInvAdd.Checked = False
        'Valid.AddControlsForCheckIfSomethingChanged(LayoutControl4InvHeatGas)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl2BManage)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl3Heating)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl5FixedCosts)

    End Sub
    Private Sub NavManage_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavManage.ElementClick
        Dim sSQL As String
        Maintab.SelectedTabPage = tabManage
        FillCbo.PUBLIC_S(cboeService, "where servicetypeID='E073DA5D-C428-4F03-88C3-9ACCC51EF812'")
        FillCbo.PUBLIC_S(cbofService, "where servicetypeID='F0EE8CF4-2778-4EF8-BCF3-225541551CE6'")
        FillCbo.PUBLIC_S(cbowService, "where servicetypeID='61407200-4E84-4FC7-9B99-A60FC5F9821B'")

        If sManageID IsNot Nothing Then
            If sManageID.Length > 0 Then
                sSQL = "SELECT * FROM vw_BMANAGE WHERE ID = '" & sManageID & "'"
                BdgManage.LoadBManageRecords(LayoutControl2BManage, sSQL)
            End If
            'TODO: This line of code loads data into the 'Priamos_NET_DataSet_BDG.vw_PUBLIC_S' table. You can move, or remove it, as needed.
            ' Me.Vw_PUBLIC_STableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_PUBLIC_S)
        End If
        'Valid.AddControlsForCheckIfSomethingChanged(LayoutControl2BManage)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl3Heating)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl4InvHeatGas)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl5FixedCosts)
    End Sub

    Private Sub NavGeneral_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavGeneral.ElementClick
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                Exit Sub
            End If
        End If
        Maintab.SelectedTabPage = tabBDG
        'Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl2BManage)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl3Heating)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl4InvHeatGas)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl5FixedCosts)
    End Sub



    Private Sub dtMes_DrawItem(sender As Object, e As CustomDrawDayNumberCellEventArgs) Handles dtMes.DrawItem
        ''If (dtMes.EditValue = Nothing) Then
        ''    If (e.Selected = True) Then
        ''If (e.Date = DateTime.Today) Then
        'e.Graphics.DrawRectangle(Pens.Red, e.Bounds)

        ''End If
        'e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brushes.Black, e.Bounds, e.Style.GetStringFormat())
        '        e.Handled = True
        ''    End If
        ''End If
    End Sub



    Private Sub OilFilesSelection(Optional ByVal ValueToGrid As Boolean = False)
        XtraOpenFileDialog1.FilterIndex = 1
        XtraOpenFileDialog1.InitialDirectory = "C:\"
        XtraOpenFileDialog1.Title = "Open File"
        XtraOpenFileDialog1.CheckFileExists = False
        XtraOpenFileDialog1.Multiselect = False
        Dim result As DialogResult = XtraOpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            If ValueToGrid Then
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "filename", XtraOpenFileDialog1.SafeFileName)
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "comefrom", System.IO.Path.GetDirectoryName(XtraOpenFileDialog1.FileName))
            Else
                txtOInvFileNames.EditValue = ""
                txtOInvFileNames.EditValue = XtraOpenFileDialog1.SafeFileName
            End If
        End If
    End Sub
    Private Sub GasFilesSelection(Optional ByVal ValueToGrid As Boolean = False)
        XtraOpenFileDialog1.FilterIndex = 1
        XtraOpenFileDialog1.InitialDirectory = "C:\"
        XtraOpenFileDialog1.Title = "Open File"
        XtraOpenFileDialog1.CheckFileExists = False
        XtraOpenFileDialog1.Multiselect = False
        Dim result As DialogResult = XtraOpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            If ValueToGrid Then
                GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "filename", XtraOpenFileDialog1.SafeFileName)
                GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "comefrom", System.IO.Path.GetDirectoryName(XtraOpenFileDialog1.FileName))
            Else
                txtGInvFileNames.EditValue = ""
                txtGInvFileNames.EditValue = XtraOpenFileDialog1.SafeFileName
            End If
        End If
    End Sub


    Private Sub CheckButton2_CheckedChanged(sender As Object, e As EventArgs)
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            GridView4.OptionsBehavior.Editable = True
        Else
            GridView4.OptionsBehavior.Editable = False
        End If
    End Sub

    Private Sub cboOInvSup_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboOInvSup.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageSUP(cboOInvSup, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageSUP(cboOInvSup, FormMode.EditRecord)
            Case 3 : cboOInvSup.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboGInvSup_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboGInvSup.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageSUP(cboGInvSup, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageSUP(cboGInvSup, FormMode.EditRecord)
            Case 3 : cboGInvSup.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboCOU_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboCOU.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageCOU(cboCOU, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageCOU(cboCOU, FormMode.EditRecord)
            Case 3 : cboCOU.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboAREAS_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboAREAS.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageAREAS(cboAREAS, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageAREAS(cboAREAS, FormMode.EditRecord)
            Case 3 : cboAREAS.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboADR_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboADR.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageADR(cboADR, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageADR(cboADR, FormMode.EditRecord)
            Case 3 : cboADR.EditValue = Nothing
        End Select
    End Sub
    Private Sub LoadMefMes(ByVal sDate As String)
        Dim sSQL As String
        If cboBefMes.EditValue <> Nothing Then
            sSQL = "Select CUR.ahpbHID,CUR.ID
	                ,CUR.code
	                ,CUR.aptID
	                ,case when CUR.mes<>0 then cur.mdt else  (select MAX(mdt) FROM AHPB	WHERE bdgid = '" + sID + "' AND boiler =  " + RGTypeHeating.SelectedIndex.ToString + "	AND mdt < " + toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) + "	and AHPB.aptID = CUR.aptID) end AS mdt	
	                ,CUR.mes
	                ,isnull((select TOP 1 SUM(mes) FROM AHPB	WHERE bdgid = '" + sID + "' AND boiler = " + RGTypeHeating.SelectedIndex.ToString + "	AND mdt < " + toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) + " and AHPB.aptID = CUR.aptID GROUP BY MDT ORDER BY MDT DESC ),0) AS mesB
	                ,CUR.mesDif
	                ,CUR.boiler
	                ,CUR.RealName
	                ,CUR.nam
	                ,CUR.ttl
	                ,CUR.ord
	                ,CUR.Floor
	                ,CUR.flrID
	                ,CUR.cmt
	                ,CUR.bdgID
	                ,CUR.bdgNam
	                ,CUR.mdt
	                ,CUR.finalized
                From vw_AHPB CUR
                Where bdgid ='" + sID + "' and boiler = " + RGTypeHeating.SelectedIndex.ToString + " and mdt = " + toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) + " ORDER BY CUR.ORD"

            LoadForms.LoadDataToGrid(grdAPTAHPB, GridView2, sSQL)
            LoadForms.RestoreLayoutFromXml(GridView2, "AHPB_def.xml")
            GridView2.OptionsMenu.ShowConditionalFormattingItem = True
            GridView2.Columns("boiler").OptionsColumn.ReadOnly = True
            GridView2.Columns("mesB").OptionsColumn.ReadOnly = True : GridView2.Columns("mesB").OptionsColumn.AllowEdit = False
            GridView2.Columns("mes").OptionsColumn.ReadOnly = False : GridView2.Columns("mes").OptionsColumn.AllowEdit = True
            GridView2.Columns("mesDif").OptionsColumn.ReadOnly = False : GridView2.Columns("mesDif").OptionsColumn.AllowEdit = True
            GridView2.Columns("nam").OptionsColumn.AllowEdit = False : GridView2.Columns("ord").OptionsColumn.AllowEdit = False
            GridView2.Columns("finalized").OptionsColumn.AllowEdit = False
            GridView2.Columns("mdt").OptionsColumn.ReadOnly = False : GridView2.Columns("mdt").OptionsColumn.AllowEdit = True
            cmdDelAHPB.Enabled = True
        Else
            cmdDelAHPB.Enabled = False
        End If

    End Sub
    Private Sub cmdSaveManage_Click(sender As Object, e As EventArgs) Handles cmdSaveManage.Click
        Dim sResult As Boolean
        Try
            'Η Νέα εγγραφή γίνεται πάντα όταν καταχωρείται η πολυκατοικία
            If Mode = FormMode.EditRecord Then
                ' sResult = BdgManage.UpdateBManageData(LayoutControl2BManage, sManageID)
                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "BMANAGE", LayoutControl2BManage,,, sManageID, True)
            End If
            If sResult Then
                'Dim form As New frmScroller
                'form.LoadRecords("vw_BDG")
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Valid.SChanged = False
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub NavAPM_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavAPM.ElementClick
        Try
            Maintab.SelectedTabPage = tabAPM
            ApmLoad()
            'GridView5.OptionsMenu.EnableFooterMenu = True
            'GridView5.Columns(6).AllowSummaryMenu = True
            'Dim siTotal As New GridColumnSummaryItem()
            'siTotal.SummaryType = DevExpress.Data.SummaryItemType.Sum
            'siTotal.DisplayFormat = "{0} records"
            'GridView5.Columns(6).Summary.Add(siTotal)

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdSaveHB_Click(sender As Object, e As EventArgs) Handles cmdSaveHB.Click
        Dim sResult As Boolean
        Try
            'Η Νέα εγγραφή γίνεται πάντα όταν καταχωρείται η πολυκατοικία
            If Mode = FormMode.EditRecord Then
                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "BDG", LayoutControl3Heating,,, sID)

            End If
            If sResult Then
                'Dim form As New frmScroller
                'form.LoadRecords("vw_BDG")
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Valid.SChanged = False
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub RGTypeHeating_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RGTypeHeating.SelectedIndexChanged
        Dim sSQL As New System.Text.StringBuilder
        sSQL.AppendLine("where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & " ORDER BY mdt desc")
        'Προηγούμενες μετρήσεις
        FillCbo.BEF_MES(cboBefMes, sSQL)
        cboBefMes.EditValue = Nothing
        Cls.ClearGrid(grdAPTAHPB)
    End Sub

    Private Sub GridView5_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView5.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView5, "APMIL_def.xml")
        Else
            ActiveGrid = GridView5
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub cmdAddAHPB_Click(sender As Object, e As EventArgs) Handles cmdAddAHPB.Click
        Try
            If dtMes.EditValue = Nothing Then
                XtraMessageBox.Show("Παρακαλώ επιλέξτε πρώτα ημερομηνία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Cls.ClearGrid(grdAPTAHPB)
                Using oCmd As New SqlCommand("CreateAHPB", CNDB)
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.Parameters.AddWithValue("@bdgid", sID)
                    oCmd.Parameters.AddWithValue("@ahpbDT", dtMes.EditValue)
                    oCmd.Parameters.AddWithValue("@boiler", RGTypeHeating.SelectedIndex)
                    oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID.ToString)
                    oCmd.ExecuteNonQuery()
                End Using
                LoadForms.LoadDataToGrid(grdAPTAHPB, GridView2, "SELECT * FROM vw_AHPB where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & "and mdt = " + toSQLValueS(CDate(dtMes.Text).ToString("yyyyMMdd")) & " ORDER BY ORD")
                LoadForms.RestoreLayoutFromXml(GridView2, "AHPB_def.xml")
                If GridView2.RowCount = 0 Then
                    XtraMessageBox.Show("Πρέπει πρώτα να καταχωρήσετε διαμερίσματα", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    cmdDelAHPB.Enabled = True
                    cmdRefreshAHPB.Enabled = True
                End If
                Dim sSQL As New System.Text.StringBuilder
                sSQL.AppendLine("where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & " ORDER BY mdt desc")
                'Προηγούμενες μετρήσεις
                FillCbo.BEF_MES(cboBefMes, sSQL)
                cboBefMes.EditValue = Nothing
                GridView2.Columns("boiler").OptionsColumn.ReadOnly = True
                GridView2.Columns("nam").OptionsColumn.AllowEdit = False
                cboBefMes.EditValue = dtMes.EditValue
                cmdRefreshAHPB.PerformClick()
            End If

        Catch ex As Exception
            If Err.Number = 5 Then
                XtraMessageBox.Show("Υπάρχει ήδη καταχωρημένη μέτρηση στην συγκεκριμένη ημερομηνία.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End Try
    End Sub

    Private Sub cmdDelAHPB_Click(sender As Object, e As EventArgs) Handles cmdDelAHPB.Click
        Dim sSQL As String
        Dim sBoiler As String
        Try
            If RGTypeHeating.SelectedIndex = 0 Then sBoiler = "Θέρμανσης" Else sBoiler = "Boiler"
            If GridView2.SelectedRowsCount = 0 Then XtraMessageBox.Show("Δεν έχετε επιλέξει εγγραφές προς διαγραφή", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφούν οι ώρες " & sBoiler & " για την ημερομηνία " & cboBefMes.Text & " ?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                'sSQL = "DELETE FROM AHPB WHERE bdgID = '" & sID & "' " &
                '        " and  mdt = " + toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd")) &
                '        " and boiler = " & RGTypeHeating.SelectedIndex
                If DeleteSelectedRows() = False Then Exit Sub
                LoadMefMes(cboBefMes.Text)
                If GridView2.RowCount > 0 Then
                    cmdDelAHPB.Enabled = True
                Else
                    cmdDelAHPB.Enabled = False
                    cboBefMes.EditValue = Nothing
                End If
                cmdRefreshAHPB.Enabled = True
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function DeleteSelectedRows() As Boolean
        Dim sSQL As String
        Dim I As Integer
        Try
            For I = 0 To GridView2.SelectedRowsCount - 1
                If CheckIfAHPBisFinalized(GridView2.GetRowCellValue(GridView2.GetSelectedRows(I), "ahpbHID").ToString) = True Then
                    XtraMessageBox.Show("Δεν μπορείτε να διαγράψετε ώρες που συμμετέχουν σε παραστατικό!", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
                sSQL = "DELETE FROM AHPB WHERE ID = " & toSQLValueS(GridView2.GetRowCellValue(GridView2.GetSelectedRows(I), "ID").ToString)

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next
            If cboBefMes.Text <> "" Then
                sSQL = "SELECT * FROM vw_AHPB where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & " and mdt = " + toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd")) & " ORDER BY ORD"
                LoadForms.LoadDataToGrid(grdAPTAHPB, GridView2, sSQL)
                LoadForms.RestoreLayoutFromXml(GridView2, "AHPB_def.xml")
            End If

            If GridView2.RowCount <= 0 Then
                sSQL = "DELETE FROM AHPB_H WHERE boiler = " & RGTypeHeating.SelectedIndex & " and bdgID = " & toSQLValueS(sID) & " and mdt = " & toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd"))
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Dim sSQL2 As New System.Text.StringBuilder
                sSQL2.AppendLine("where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & " ORDER BY mdt desc")
                'Προηγούμενες μετρήσεις
                FillCbo.BEF_MES(cboBefMes, sSQL2)
            End If
            cboBefMes.EditValue = Nothing
            Cls.ClearGrid(grdAPTAHPB)
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Private Function CheckIfAHPBisFinalized(ByVal sahpbHID As String) As Boolean
        Dim sID As String
        Dim sSQL As String = "select top 1 ID from AHPB_H where finalized=1 and ID =  " & toSQLValueS(sahpbHID)
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        cmd = New SqlCommand(sSQL, CNDB)
        sdr = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            sID = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
            sdr.Close()
            Return True
        Else
            sdr.Close()
            Return False
        End If

    End Function
    Private Sub cboBefMes_ButtonClick(sender As Object, e As ButtonPressedEventArgs)
        If e.Button.Index = 1 Then cboBefMes.EditValue = Nothing
    End Sub

    Private Sub cboFtypes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboFtypes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageFtypes(cboFtypes, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageFtypes(cboFtypes, FormMode.EditRecord)
            Case 3 : cboFtypes.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboHtypes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboHtypes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageCalcTypes(cboHtypes, FormMode.NewRecord, GridView1)
            Case 2 : ManageCbo.ManageCalcTypes(cboHtypes, FormMode.EditRecord, GridView1)
            Case 3 : cboHtypes.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboBtypes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBtypes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageCalcTypes(cboBtypes, FormMode.NewRecord, GridView1)
            Case 2 : ManageCbo.ManageCalcTypes(cboBtypes, FormMode.NewRecord, GridView1)
            Case 3 : cboBtypes.EditValue = Nothing
        End Select

    End Sub

    Private Sub HyperlinkLabelControl1_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles HyperlinkLabelControl1.HyperlinkClick
        'System.Diagnostics.Process.Start(e.Text)
        'WebBrowser1.Navigate("https://ebill.dei.gr/Login.aspx")
    End Sub

    Private Sub HyperlinkLabelControl111_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles HyperlinkLabelControl111.HyperlinkClick
        System.Diagnostics.Process.Start(e.Text)
    End Sub

    Private Sub HyperlinkLabelControl11_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles HyperlinkLabelControl11.HyperlinkClick
        System.Diagnostics.Process.Start(e.Text)
    End Sub

    Private Sub GridView2_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView2.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView2, "AHPB_def.xml",, "Select top 1 * from vw_AHPB")
        Else
            ActiveGrid = GridView2
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub cmdGInvAdd_CheckedChanged(sender As Object, e As EventArgs) Handles cmdGInvAdd.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            GridView4.OptionsBehavior.Editable = False
            'Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable - Clear
            Dim ExcludeControls As New List(Of String)
            ExcludeControls.Add(cbofService2.Name)
            InvGas.AddNewGasInv(LayoutControlGroup6, ExcludeControls)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Enabled, LayoutControlGroup6)
            txtGInvCode.Text = DBQ.GetNextId("INV_GAS")
            cmdGInvSave.Enabled = True
        Else
            'Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable - Clear
            Dim ExcludeControls As New List(Of String)
            ExcludeControls.Add(cbofService2.Name)
            Cls.ClearGroupCtrls(LayoutControlGroup6, ExcludeControls)
            ExcludeControls.Add(cmdGInvAdd.Name)
            ExcludeControls.Add(cmdGInvDelete.Name)
            ExcludeControls.Add(cmdGInvRefresh.Name)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup6, ExcludeControls)
            cmdGInvSave.Enabled = False
        End If
    End Sub
    Private Sub RepositoryItemButtonGas_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonGas.ButtonClick
        If GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "InhCalculated").ToString = "True" Or GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "completed").ToString = "True" Then
            XtraMessageBox.Show("Δεν μπορείτε να επισυνάψετε αρχείο όταν το τιμολόγιο έχει ολοκληρωθεί ή συμμετέχει σε παραστατικό", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        GasFilesSelection(True)
        If XtraOpenFileDialog1.FileName = "" Then Exit Sub
        Dim sGID As String = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ID").ToString
        ' Διαγραφή πρώτα παλιού αρχείου
        Using oCmd As New SqlCommand("delete from INV_GAS WHERE ID = " & toSQLValueS(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "F_ID").ToString), CNDB)
            oCmd.ExecuteNonQuery()
        End Using

        If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_GASF", sGID) = False Then
            XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RepositoryItemButtonOil_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonOil.ButtonClick
        If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "InhCalculated").ToString = "True" Or GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "completed").ToString = "True" Then
            XtraMessageBox.Show("Δεν μπορείτε να επισυνάψετε αρχείο όταν το τιμολόγιο έχει ολοκληρωθεί ή συμμετέχει σε παραστατικό", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        OilFilesSelection(True)
        If XtraOpenFileDialog1.FileName = "" Then Exit Sub
        Dim sOID As String = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString
        ' Διαγραφή πρώτα παλιού αρχείου
        Using oCmd As New SqlCommand("delete from INV_OILF WHERE ID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "F_ID").ToString), CNDB)
            oCmd.ExecuteNonQuery()
        End Using
        If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_OILF", sOID) = False Then
            XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub cmdOInvAdd_CheckedChanged(sender As Object, e As EventArgs) Handles cmdOInvAdd.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            'GridView3.OptionsBehavior.Editable = False
            InvOils.AddNewOilInv(LayoutControlGroup5)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Enabled, LayoutControlGroup5)
            txtOInvCode.Text = DBQ.GetNextId("INV_OIL")
            cmdOInvSave.Enabled = True
        Else
            Cls.ClearGroupCtrls(LayoutControlGroup5)
            Dim ExcludeControls As New List(Of String)
            ExcludeControls.Add(cmdOInvAdd.Name)
            ExcludeControls.Add(cmdOInvDelete.Name)
            ExcludeControls.Add(cmdOInvRefresh.Name)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup5, ExcludeControls)
            cmdOInvSave.Enabled = False
        End If
    End Sub

    Private Sub grdOil_DoubleClick(sender As Object, e As EventArgs) Handles grdOil.DoubleClick
        If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "filename") Is DBNull.Value Then Exit Sub
        Try
            Dim fs As System.IO.FileStream = New System.IO.FileStream(Application.StartupPath & "\" & GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "filename"), System.IO.FileMode.Create)

            Dim b() As Byte = LoadForms.GetFile(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "F_ID").ToString, "INV_OILF")
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute(Application.StartupPath & "\" & GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "filename"))
        Catch ex As IOException
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grdGas_DoubleClick(sender As Object, e As EventArgs) Handles grdGas.DoubleClick
        If GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "filename") Is DBNull.Value Then Exit Sub
        Try
            Dim fs As System.IO.FileStream = New System.IO.FileStream(Application.StartupPath & "\" & GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "filename"), System.IO.FileMode.Create)

            Dim b() As Byte = LoadForms.GetFile(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "F_ID").ToString, "INV_GASF")
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute(Application.StartupPath & "\" & GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "filename"))
        Catch ex As IOException
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtGInvFileNames_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtGInvFileNames.ButtonClick
        If e.Button.Index = 0 Then
            GasFilesSelection()
        Else
            txtGInvFileNames.EditValue = Nothing
        End If
    End Sub

    Private Sub txtOInvFileNames_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtOInvFileNames.ButtonClick
        If e.Button.Index = 0 Then
            OilFilesSelection()
        Else
            txtOInvFileNames.EditValue = Nothing
        End If
    End Sub

    Private Sub GridView4_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView4.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView4, "INV_GAS_def.xml", "vw_INV_GAS")
        Else
            ActiveGrid = GridView4
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub GridView4_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView4.RowUpdated
        Dim FieldsToBeUpdate As New List(Of String)
        Try
            FieldsToBeUpdate.Add("invNumber")
            FieldsToBeUpdate.Add("invDate")
            FieldsToBeUpdate.Add("price")
            FieldsToBeUpdate.Add("totalPrice")
            If InvGas.UpdateGasData(GridView4, GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ID").ToString, FieldsToBeUpdate) = True Then
                XtraOpenFileDialog1.FileName = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "comefrom").ToString & "\" & GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "filename").ToString
                If XtraOpenFileDialog1.SafeFileName <> "" Then
                    ' Διαγραφή πρώτα παλιού αρχείου
                    InvGas.DeleteRecordWithoutQuestion(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "F_ID").ToString, "INV_GASF")

                    If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_GASF", GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ID").ToString) = False Then
                        XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                XtraOpenFileDialog1.FileName = ""
                InvGas.LoadGasRecords(grdGas, GridView4, "SELECT * FROM  vw_INV_GAS where bdgid ='" + sID + "' ORDER by createdon desc")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grdGas_KeyDown(sender As Object, e As KeyEventArgs) Handles grdGas.KeyDown
        Select Case e.KeyCode
            Case Keys.F2 : If UserProps.AllowInsert = True Then cmdGInvAdd.PerformClick()
            Case Keys.F3
            Case Keys.F5 : cmdGInvRefresh.PerformClick()
            Case Keys.Delete : If UserProps.AllowDelete = True Then cmdGInvDelete.PerformClick()
        End Select
    End Sub

    Private Sub cmdGInvRefresh_Click(sender As Object, e As EventArgs) Handles cmdGInvRefresh.Click
        InvGas.LoadGasRecords(grdGas, GridView4, "SELECT * FROM  vw_INV_GAS where bdgid ='" + sID + "' ORDER by createdon desc")
    End Sub

    Private Sub cmdGInvDelete_Click(sender As Object, e As EventArgs) Handles cmdGInvDelete.Click
        If GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ID") = Nothing Then Exit Sub
        InvGas.DeleteRecordWithoutQuestion(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "F_ID").ToString, "INV_GASF")
        InvGas.DeleteRecord(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ID").ToString, "INV_GAS")
        InvGas.LoadGasRecords(grdGas, GridView4, "SELECT * FROM  vw_INV_GAS where bdgid ='" + sID + "' ORDER by createdon desc")

    End Sub

    Private Sub GridView3_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView3.RowUpdated
        Try
            Dim FieldsToBeUpdate As New List(Of String)
            FieldsToBeUpdate.Add("invNumber")
            FieldsToBeUpdate.Add("invDate")
            FieldsToBeUpdate.Add("liters")
            FieldsToBeUpdate.Add("price")
            FieldsToBeUpdate.Add("totalPrice")
            FieldsToBeUpdate.Add("mes")
            FieldsToBeUpdate.Add("mesB")
            FieldsToBeUpdate.Add("completed")
            If InvOils.UpdateOilData(GridView3, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString, FieldsToBeUpdate) = True Then
                XtraOpenFileDialog1.FileName = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "comefrom").ToString & "\" & GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "filename").ToString

                If XtraOpenFileDialog1.SafeFileName <> "" Then
                    ' Διαγραφή πρώτα παλιού αρχείου
                    InvOils.DeleteRecordWithoutQuestion(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "F_ID").ToString, "INV_OILF")

                    If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_OILF", GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString) = False Then
                        XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                XtraOpenFileDialog1.FileName = ""
                InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")

            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView3.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView3, "INV_OIL_def.xml", "vw_INV_OIL")
        Else
            ActiveGrid = GridView3
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub grdOil_KeyDown(sender As Object, e As KeyEventArgs) Handles grdOil.KeyDown
        Select Case e.KeyCode
            Case Keys.F2 : If UserProps.AllowInsert = True Then cmdOInvAdd.PerformClick()
            Case Keys.F3
            Case Keys.F5 : cmdOInvRefresh.PerformClick()
            Case Keys.Delete : If UserProps.AllowDelete = True Then cmdOInvDelete.PerformClick()
        End Select
    End Sub

    Private Sub cmdOInvDelete_Click(sender As Object, e As EventArgs) Handles cmdOInvDelete.Click
        InvOils.DeleteRecordWithoutQuestion(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "F_ID").ToString, "INV_OILF")
        InvOils.DeleteRecord(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString, "INV_OIL")
        InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")
        'Υπολογισμός Διαθέσιμου υπολοίπου
        CalculateDepositR()
        ' Σύνολο Λογιστικού και Διαθέσιμου Αποθεματικού 
        GettotDepositA_R()

    End Sub

    Private Sub cmdOInvRefresh_Click(sender As Object, e As EventArgs) Handles cmdOInvRefresh.Click
        InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")
    End Sub

    Private Sub cmdGInvSave_Click(sender As Object, e As EventArgs) Handles cmdGInvSave.Click
        Dim INH As New INH
        If Valid.ValidateFormGRP(LayoutControlGroup6) Then
            If chkGasFixed.Checked = True And cboINH.EditValue = Nothing Then
                XtraMessageBox.Show("Έχετε επιλέξει πάγιο παραστατικό χωρίς να επιλέξετε τιμολόγιο χρέωσης. ", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim sGID As String = System.Guid.NewGuid.ToString
            If InvGas.InsertGasData(LayoutControlGroup6, sGID, "bdgid", sID) Then
                InvGas.LoadGasRecords(grdGas, GridView4, "SELECT * FROM  vw_INV_GAS where bdgid ='" + sID + "' ORDER by createdon desc")
                If XtraOpenFileDialog1.SafeFileName <> "" Then
                    If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_GASF", sGID) = False Then
                        XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If


                ' Υπολογισμός Κατανάλωσης για την περίπτωση Φυσικού Αερίου
                Dim sHTypeID As String, sFTypeID As String, sBTypeID As String, sConsumptionID As String
                sConsumptionID = Guid.NewGuid.ToString
                sFTypeID = "" : sBTypeID = "" : sHTypeID = ""
                GetHeatingInf(sHTypeID, sFTypeID, sBTypeID)
                If sFTypeID.ToUpper = "3E3B5B65-6B09-4CAA-B467-24A1108C0F0C" Then ' Φυσικό Αέριο
                    If sHTypeID.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Or sHTypeID.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" _
                    Or sBTypeID.ToUpper = "9F7BD209-A5A0-47F4-BB0B-9CEA9483B6AE" Or sBTypeID.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Then
                        Dim sahpbHIDH As String, sahpbHIDB As String
                        If CheckForAhpbH(sahpbHIDH, False) = False And CheckForAhpbB(sahpbHIDB, False) = False Then
                            XtraMessageBox.Show("Δεν εκτελέστηκε ο υπολογισμός Κατανάλωσης φυσικού αερίου γιατί δεν έχετε καταχωρήσει ώρες κατανάλωσης θέρμανσης και Boiler. ", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            CalculateConsumption(toSQLValue(txtGInvTotalPrice, True), 0, sConsumptionID, sahpbHIDH, sahpbHIDB, sGID)
                        End If
                    End If
                End If

                If chkGasFixed.Checked = True Then
                    If INH.InsertINDFixedConsumption(cboINH.EditValue.ToString, sID, sGID, 0) = False Then Exit Sub
                End If

                'Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable
                Dim ExcludeControls As New List(Of String)
                    ExcludeControls.Add(cbofService2.Name)
                    Cls.ClearGroupCtrls(LayoutControlGroup6, ExcludeControls)
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                    XtraOpenFileDialog1.FileName = ""
                    GridView4.OptionsBehavior.Editable = False
                    txtGInvFileNames.EditValue = ""
                    'cmdOInvSave.Enabled = False
                End If
            End If
    End Sub
    'Υπολογισμός Κατανάλωσης
    Private Sub CalculateConsumption(ByVal totConsumption As String, ByVal totConsumptionLiter As String,
                                     ByVal sConsumptionID As String, ByVal sahpbHIDH As String, ByVal sahpbHIDB As String, ByVal invGasID As String)
        Try

            Using oCmd As New SqlCommand("consumption_Calculate", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@consumptionID", sConsumptionID)
                oCmd.Parameters.AddWithValue("@bdgID", sID)
                oCmd.Parameters.AddWithValue("@ahpbHID", sahpbHIDH)
                oCmd.Parameters.AddWithValue("@ahpbHIDB", sahpbHIDB)
                oCmd.Parameters.AddWithValue("@totConsumption", totConsumption)
                oCmd.Parameters.AddWithValue("@totConsumptionLiter", totConsumptionLiter)
                oCmd.Parameters.AddWithValue("@createdBy", UserProps.ID.ToString)
                oCmd.Parameters.AddWithValue("@MachineName", UserProps.MachineName)
                oCmd.Parameters.AddWithValue("@invGasID", invGasID)
                oCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function CheckForAhpbH(ByRef sahpbHIDH As String, ByVal FromGrid As Boolean) As Boolean
        Dim sSQL As String
        If FromGrid = False Then
            sSQL = "select top 1 ID from AHPB_H where   boiler=0 and bdgID = " & toSQLValueS(sID) &
                             " and mdt =  " & toSQLValueS(CDate(tDateConsumption.EditValue).ToString("yyyyMMdd"))
        Else
            sSQL = "select top 1 ID from AHPB_H where   boiler=0 and bdgID = " & toSQLValueS(sID) &
                             " and mdt =  " & toSQLValueS(CDate(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "dtMeasurement")).ToString("yyyyMMdd"))

        End If
        sahpbHIDH = Guid.Empty.ToString
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        cmd = New SqlCommand(sSQL, CNDB)
        sdr = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            sahpbHIDH = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
            sdr.Close()
            Return True
        Else
            sdr.Close()
            Return False
        End If
    End Function

    Private Function CheckForAhpbB(ByRef sahpbHIDB As String, ByVal FromGrid As Boolean) As Boolean
        Dim sSQL As String
        If FromGrid = False Then
            sSQL = "select top 1 ID from AHPB_H where boiler=1 and bdgID = " & toSQLValueS(sID) &
                             "and mdt =  " & toSQLValueS(CDate(tDateConsumption.EditValue).ToString("yyyyMMdd"))

        Else
            sSQL = "select top 1 ID from AHPB_H where boiler=1 and bdgID = " & toSQLValueS(sID) &
                             "and mdt =  " & toSQLValueS(CDate(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "dtMeasurement")).ToString("yyyyMMdd"))

        End If
        sahpbHIDB = Guid.Empty.ToString
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        cmd = New SqlCommand(sSQL, CNDB)
        sdr = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            sahpbHIDB = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
            sdr.Close()
            Return True
        Else
            sdr.Close()
            Return False
        End If
    End Function
    Private Sub cmdOInvSave_Click(sender As Object, e As EventArgs) Handles cmdOInvSave.Click
        Dim mes As Decimal, mesB As Decimal
        If Valid.ValidateFormGRP(LayoutControlGroup5) Then
            Dim sOID As String = System.Guid.NewGuid.ToString
            mesB = txtOInvBefMes.EditValue : mes = txtOInvMes.EditValue
            If mesB > mes Then
                XtraMessageBox.Show("Δεν μπορεί η προμέτρηση να είναι μεγαλύτερη από την επιμέτρηση", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If InvOils.InsertOilData(LayoutControlGroup5, sOID, "bdgid", sID) Then
                InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")
                If XtraOpenFileDialog1.SafeFileName <> "" Then
                    If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_OILF", sOID) = False Then
                        XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                ' Καταχώρηση της μέτρησης στον έλεγχο δεξαμενών
                If InsertTank(sOID) = False Then
                    XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην εισαγωγή εγγραφής για την ""Μέτρηση της Δεξαμενής"" ", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                'Υπολογισμός Διαθέσιμου υπολοίπου
                CalculateDepositR()
                ' Σύνολο Λογιστικού και Διαθέσιμου Αποθεματικού 
                GettotDepositA_R()

                Cls.ClearGroupCtrls(LayoutControlGroup5)
                ''Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable
                'Dim ExcludeControls As New List(Of String)
                'ExcludeControls.Add(cmdOInvAdd.Name)
                'ExcludeControls.Add(cmdOInvDelete.Name)
                'ExcludeControls.Add(cmdOInvRefresh.Name)
                'EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup5, ExcludeControls)

                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Valid.SChanged = False
                XtraOpenFileDialog1.FileName = ""
                txtOInvFileNames.EditValue = ""
                'GridView3.OptionsBehavior.Editable = False
                'cmdOInvSave.Enabled = False
            End If

        End If
    End Sub


    Private Function InsertTank(ByVal sOID As String) As Boolean
        Try
            Dim sSQL As String
            sSQL = "DELETE FROM TANK WHERE ID = " & toSQLValueS(sOID)
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

            sSQL = "insert into TANK (ID,[bdgID],[measurementcatID],[invOilID],[dtMeasurement], [mes], [mesB],liters, [usrID], 
                                     [modifiedBy], [modifiedOn], [createdOn], [createdBy], [MachineName]) " &
                         "SELECT NEWID(),bdgid,(SELECT TOP 1 ID FROM MEASUREMENT_CAT WHERE isInvoice = 1) as measurementcatID,ID," &
                         "invDate,mes,mesB,liters,usrID,[modifiedBy], [modifiedOn], [createdOn], [createdBy], [MachineName]" &
                         "FROM INV_OIL WHERE ID= " & toSQLValueS(sOID)
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub GridView5_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView5.RowUpdated
        Try
            Apmil.UpdateApMilData(GridView5, GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString, ApmilFieldsToBeUpdate)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdDelAPM_Click(sender As Object, e As EventArgs) Handles cmdDelAPM.Click
        Dim sSQL As String
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM APMIL WHERE ID = '" & GridView5.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                GridView5.DeleteRow(GridView1.FocusedRowHandle)
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdApmRefresh_Click(sender As Object, e As EventArgs) Handles cmdApmRefresh.Click
        Try
            ApmLoad()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ApmLoad()
        Try
            Dim sSQL As String
            Dim sSQL2 As String



            sSQL = "SELECT * from vw_APMIL where bdgid = '" & sID & "' order by ORD"
            sSQL2 = "SELECT * from vw_APMIL_D where bdgid = '" & sID & "' order by ORD"
            Dim AdapterMaster As New SqlDataAdapter(sSQL, CNDB)
            Dim AdapterDetail As New SqlDataAdapter(sSQL2, CNDB)
            Dim sdataSet As New DataSet()
            AdapterMaster.Fill(sdataSet, "vw_APMIL")
            AdapterDetail.Fill(sdataSet, "vw_APMIL_D")
            Dim keyColumn As DataColumn = sdataSet.Tables("vw_APMIL").Columns("ID")
            Dim foreignKeyColumn As DataColumn = sdataSet.Tables("vw_APMIL_D").Columns("ID")
            sdataSet.Relations.Add("ΧΙΛΙΟΣΤΑ ΜΕ ΜΕΙΩΣΕΙΣ", keyColumn, foreignKeyColumn)
            GridView5.Columns.Clear()
            GridView7.Columns.Clear()
            grdAPM.DataSource = sdataSet.Tables("vw_APMIL")
            grdAPM.ForceInitialize()

            'LoadForms.LoadDataToGrid(grdAPM, GridView5, "SELECT * from vw_APMIL where bdgid = '" & sID & "' order by ORD")
            'LoadForms.LoadDataToGrid(grdAPM, GridView7, "SELECT * from vw_APMIL_D where bdgid = '" & sID & "' order by ORD")
            'Φορτώνει όλες τις ονομασίες των στηλών από τον SQL. Από το πεδίο Description
            LoadForms.LoadColumnDescriptionNames(GridView5, , "vw_APMIL")
            LoadForms.LoadColumnDescriptionNames(GridView7, , "vw_APMIL_D")
            LoadForms.RestoreLayoutFromXml(GridView5, "APMIL_def.xml")
            LoadForms.RestoreLayoutFromXml(GridView7, "APMIL_D_def.xml")

            GridView5.OptionsCustomization.AllowSort = False

            ApmilFieldsToBeUpdate.Clear()
            For Each kvp As KeyValuePair(Of String, String) In Bmlc
                If kvp.Value = 0 Then
                    If GridView5.Columns(kvp.Key) IsNot Nothing Then
                        GridView5.Columns(kvp.Key).Visible = False
                        GridView5.Columns(kvp.Key).OptionsColumn.ReadOnly = True
                        GridView5.Columns(kvp.Key).OptionsColumn.AllowEdit = False
                        'Στήλη κλειστών
                        If GridView5.Columns("c_" & kvp.Key) IsNot Nothing Then
                            GridView5.Columns("c_" & kvp.Key).Visible = False
                            GridView5.Columns("c_" & kvp.Key).OptionsColumn.ReadOnly = True
                            GridView5.Columns("c_" & kvp.Key).OptionsColumn.AllowEdit = False
                        End If
                        'Στήλη Χιλιοστών με μειώσεις
                        If GridView7.Columns("d_" & kvp.Key) IsNot Nothing Then
                            GridView7.Columns("d_" & kvp.Key).Visible = False
                            GridView7.Columns("d_" & kvp.Key).OptionsColumn.ReadOnly = True
                            GridView7.Columns("d_" & kvp.Key).OptionsColumn.AllowEdit = False
                        End If

                    End If
                Else
                    If GridView5.Columns(kvp.Key) IsNot Nothing Then
                        GridView5.Columns(kvp.Key).Visible = True
                        GridView5.Columns(kvp.Key).OptionsColumn.ReadOnly = False
                        GridView5.Columns(kvp.Key).OptionsColumn.AllowEdit = True
                        ApmilFieldsToBeUpdate.Add(kvp.Key)
                        'Στήλη κλειστών
                        If GridView5.Columns("c_" & kvp.Key) IsNot Nothing Then
                            GridView5.Columns("c_" & kvp.Key).Visible = True
                            GridView5.Columns("c_" & kvp.Key).OptionsColumn.ReadOnly = False
                            GridView5.Columns("c_" & kvp.Key).OptionsColumn.AllowEdit = True
                            ApmilFieldsToBeUpdate.Add("c_" & kvp.Key)
                        End If
                        'Στήλη Χιλιοστών με μειώσεις
                        If GridView7.Columns("d_" & kvp.Key) IsNot Nothing Then
                            GridView7.Columns("d_" & kvp.Key).Visible = True
                            GridView7.Columns("d_" & kvp.Key).OptionsColumn.ReadOnly = True
                            GridView7.Columns("d_" & kvp.Key).OptionsColumn.AllowEdit = False
                        End If

                    End If
                End If
            Next
            'GridView5.Columns("AptNam").OptionsColumn.ReadOnly = True
            'GridView5.Columns("AptNam").OptionsColumn.AllowEdit = False
            'GridView5.Columns("ttl").Fixed = FixedStyle.Left
            'GridView5.Columns("ord").Fixed = FixedStyle.Left
            'GridView5.Columns("AptNam").Fixed = FixedStyle.Left
            ApmilFieldsToBeUpdate.Add("ΠΟΣΟΣΤΟ ΚΛΕΙΣΤΟΥ")
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdAddApmil_Click(sender As Object, e As EventArgs) Handles cmdAddApmil.Click
        Try
            ' Καταχώρηση μιας γραμμής για τα χιλιοστά
            Dim sSQL As String = "insert into APMIL ([aptID],[bdgID],[modifiedby],[createdon]) " &
                             "SELECT id,bdgid," & toSQLValueS(UserProps.ID.ToString) & ", getdate() " &
                             "FROM APT WHERE BDGID= " & toSQLValueS(sID) &
                             "And ID Not In(Select APTID FROM APMIL WHERE BDGID= " & toSQLValueS(sID) & ")"

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            ApmLoad()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView5_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles GridView5.CustomDrawFooterCell
        'Dim view As GridView = TryCast(sender, GridView)
        'Dim column1 As GridColumn = view.Columns("AptName")

        'Dim r As Rectangle = e.Bounds
        '    r.Inflate(-1, -1)
        '    e.Cache.FillRectangle(Brushes.Red, r)
        '    r.Inflate(-2, 0)
        '    e.Appearance.DrawString(e.Cache, e.Info.DisplayText, r)
        '    e.Handled = True

    End Sub

    Private Sub frmBDG_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtOInvPrice_EditValueChanged(sender As Object, e As EventArgs) Handles txtOInvPrice.EditValueChanged
        If txtOInvLiters.Text = "" Then Exit Sub
        txtOInvTotalPrice.EditValue = txtOInvLiters.Text.Replace("€", "") * txtOInvPrice.Text.Replace("€", "")
    End Sub

    Private Sub txtOInvLiters_EditValueChanged(sender As Object, e As EventArgs) Handles txtOInvLiters.EditValueChanged
        If txtOInvLiters.Text = "" Then Exit Sub
        txtOInvTotalPrice.EditValue = txtOInvLiters.Text.Replace("€", "") * txtOInvPrice.Text.Replace("€", "")
    End Sub


    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView5.CellValueChanged
        Dim sAptID As String
        Try
            sAptID = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "aptID").ToString()
            If e.Value < 100 Then
                ' Καταχώρηση μιας γραμμής για τα χιλιοστά
                Dim sSQL As String = "UPDATE APT SET CLOSED = 1 WHERE ID = " & toSQLValueS(sAptID)

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        ChangeValues(e.Column.FieldName, e.RowHandle)
    End Sub
    Private Sub ChangeValues(ByVal FieldName As String, ByVal RowHandle As Integer)
        Dim mes As Decimal, mesB As Decimal, Dif As Decimal, sDate As String, sSQL As String
        Dim row As DataRow
        Try

            row = GridView2.GetDataRow(RowHandle)
            mesB = row("mesB")
            mes = row("mes")
            Dif = row("mesDif")
            row.Table.Columns.Item("mdt").ReadOnly = False
            If dtMes.EditValue = Nothing Then sDate = CDate(cboBefMes.EditValue).ToString("yyyyMMdd") Else sDate = CDate(dtMes.EditValue).ToString("yyyyMMdd")
            If FieldName = "mes" Then
                Dif = mes - mesB
                row("mesDif") = Dif
                If dtMes.EditValue = Nothing Then row("mdt") = cboBefMes.EditValue Else row("mdt") = dtMes.EditValue
            ElseIf FieldName = "mesDif" Then
                mes = Dif + mesB
                row("mes") = mes
                If dtMes.EditValue = Nothing Then row("mdt") = cboBefMes.EditValue Else row("mdt") = dtMes.EditValue
            End If

            sSQL = "UPDATE  AHPB SET MES = " & toSQLValueS(mes, True) &
                        ",MESDIF = " & toSQLValueS(Dif, True) &
                        ",mdt = " & toSQLValueS(sDate) &
                        " WHERE ID = " & toSQLValueS(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ID").ToString)

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

            'Ενημέρωση συνόλου ωρών
            sSQL = "UPDATE  AHPB_H SET totalBdgMesDif = (select sum(mesdif) from AHPB where ahpbHID=ahpb_h.id) where id = " & toSQLValueS(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ahpbHID").ToString)

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim sAptID As String
        Try
            sAptID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString()
            ' Ενημέρωση στήλης
            Dim sSQL As String = "UPDATE APT SET " & e.Column.FieldName & " = " & toSQLValueS(e.Value.ToString) & "  WHERE ID = " & toSQLValueS(sAptID)
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            If Err.Number = 5 Then
                XtraMessageBox.Show("Η συγκεκριμένη στήλη δεν διατίθεται προς επεξεργασία απευθείας από την όψη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End Try
    End Sub

    Private Sub NavFixedCosts_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavFixedCosts.ElementClick
        Dim sSQL As String
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                Exit Sub
            End If
        End If
        Maintab.SelectedTabPage = tabFixedCosts
        LoadIEP()
        'Valid.AddControlsForCheckIfSomethingChanged(LayoutControl5FixedCosts)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl2BManage)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl3Heating)
        'Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl4InvHeatGas)
    End Sub
    Public Sub LoadIEP()
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_IEP' table. You can move, or remove it, as needed.
        Me.Vw_IEPTableAdapter.FillByBDG(Me.Priamos_NET_DataSet_BDG.vw_IEP, System.Guid.Parse(sID))

        'Dim sSQL As String
        'sSQL = "SELECT * FROM vw_IEP WHERE BDGID = '" & sID & "' ORDER BY code"
        'LoadForms.LoadDataToGrid(grdIEP, GridView6, sSQL)
        ''Φορτώνει όλες τις ονομασίες των στηλών από τον SQL. Από το πεδίο Description
        'LoadForms.LoadColumnDescriptionNames(GridView6,, "vw_IEP")
        LoadForms.RestoreLayoutFromXml(GridView6, "IEP_def.xml")
        GridView6.ExpandAllGroups()

    End Sub
    Private Sub GridView6_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView6.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView6, "IEP_def.xml", "VW_IEP")
        Else
            ActiveGrid = GridView6
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub cmdAddIEP_Click(sender As Object, e As EventArgs) Handles cmdAddIEP.Click
        NewIEP()
    End Sub

    Private Sub cmdEditIEP_Click(sender As Object, e As EventArgs) Handles cmdEditIEP.Click
        EditIEP()
    End Sub

    Private Sub grdIEP_DoubleClick(sender As Object, e As EventArgs) Handles grdIEP.DoubleClick
        Dim form1 As frmIEP = New frmIEP()
        form1.Text = "Έξοδα"
        'form1.MdiParent = frmMain
        form1.Mode = FormMode.EditRecord
        form1.FormScroller = Me
        form1.ID = GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "ID").ToString
        form1.BDGID = sID
        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        'form1.Show()
        form1.ShowDialog()
    End Sub


    Private Sub DeleteIEP()
        Dim sSQL As String
        Try
            If GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM IEP WHERE ID = '" & GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                LoadIEP()
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdIEPDelete_Click(sender As Object, e As EventArgs) Handles cmdIEPDelete.Click
        DeleteIEP()
    End Sub

    Private Sub grdIEP_KeyDown(sender As Object, e As KeyEventArgs) Handles grdIEP.KeyDown
        Select Case e.KeyCode
            Case Keys.F2 : If UserProps.AllowInsert = True Then NewIEP()
            Case Keys.F3 : If UserProps.AllowEdit = True Then EditIEP()
            Case Keys.F5 : LoadIEP()
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteIEP()
        End Select
    End Sub
    Private Sub NewIEP()
        Dim form1 As frmIEP = New frmIEP()
        form1.Text = "Έξοδα"
        'form1.MdiParent = frmMain
        form1.Mode = FormMode.NewRecord
        form1.FormScroller = Me
        form1.BDGID = sID
        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        'form1.Show()
        form1.ShowDialog()
    End Sub
    Private Sub EditIEP()
        Dim form1 As frmIEP = New frmIEP()
        form1.Text = "Έξοδα"
        'form1.MdiParent = frmMain
        form1.Mode = FormMode.EditRecord
        form1.FormScroller = Me
        form1.ID = GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "ID").ToString
        form1.BDGID = sID
        '    frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        'form1.Show()
        form1.ShowDialog()
    End Sub

    Private Sub cmdDeiLogin_Click(sender As Object, e As EventArgs)
        On Error Resume Next
        'WebBrowser1.Document.GetElementById("ctl00_ctl00_Site_Main_Main_ApartmentBuildingBills_txtCustomerCode").SetAttribute("value", txteCounter.Text)
        'WebBrowser1.Document.GetElementById("ctl00$ctl00$Site_Main$Main$ApartmentBuildingBills$btnFindApartmentBuildingBills").InvokeMember("click")

    End Sub

    Private Sub WebBrowser1_NewWindow(sender As Object, e As CancelEventArgs)
        e.Cancel = True

        'Dim url As String = WebBrowser1.StatusText

        'WebBrowser1.Navigate(url)

    End Sub
    Public Shared Function GetTextFromPDF(PdfFileName As String) As String
        Dim oReader As New iTextSharp.text.pdf.PdfReader(PdfFileName)

        Dim sOut = ""

        For i = 1 To oReader.NumberOfPages - 1
            Dim its As New iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy

            sOut &= iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
        Next
        Dim sAmount As String() = sOut.Split(vbLf)
        Dim value As String = Array.Find(sAmount, Function(x) (x.StartsWith("*")))
        value = value.Replace("*", "")
        Return value
    End Function

    Private Sub cmdOpenPDF_Click(sender As Object, e As EventArgs)
        FilesSelection()
    End Sub
    Private Sub FilesSelection()

        XtraOpenFileDialog1.Filter = "PDF files (*.pdf)|*.pdf"
        XtraOpenFileDialog1.FilterIndex = 1
        XtraOpenFileDialog1.InitialDirectory = "C:\"
        XtraOpenFileDialog1.Title = "Open File"
        XtraOpenFileDialog1.CheckFileExists = False
        XtraOpenFileDialog1.Multiselect = False
        Dim result As DialogResult = XtraOpenFileDialog1.ShowDialog()
        ' If result = DialogResult.OK Then txtPayDEI.EditValue = GetTextFromPDF(XtraOpenFileDialog1.SafeFileName)
    End Sub

    Private Sub cmdIEPRefresh_Click(sender As Object, e As EventArgs) Handles cmdIEPRefresh.Click
        LoadIEP()
    End Sub

    Private Sub cmdApmExport_Click(sender As Object, e As EventArgs) Handles cmdApmExport.Click
        Dim options = New XlsxExportOptionsEx()
        options.UnboundExpressionExportMode = UnboundExpressionExportMode.AsFormula
        options.ExportType = ExportType.WYSIWYG
        XtraSaveFileDialog1.Filter = "XLSX Files (*.xlsx*)|*.xlsx"
        XtraSaveFileDialog1.FileName = "Χιλιοστά_" & bdgName
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView5.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
            Process.Start(XtraSaveFileDialog1.FileName)
        End If

    End Sub

    Private Sub GridView7_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView7.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView7, "APMIL_D_def.xml")
        Else
            'PopupMenuRowsDetail.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub NavMaintenance_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavMaintenance.ElementClick
        Try
            Maintab.SelectedTabPage = tabMaintenance
            Me.Vw_PRFTableAdapter.Fill(Me.Priamos_NETDataSet.vw_PRF)
            Me.Vw_BCCTTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BCCT, System.Guid.Parse(sID))
            LayoutControlGroup15.Enabled = False
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdSaveBCCT_Click(sender As Object, e As EventArgs) Handles cmdSaveBCCT.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateFormGRP(LayoutControlGroup13) Then
                'Dim myLayoutControls As New List(Of Control)
                'myLayoutControls.Add(LayoutControl1BDG) : myLayoutControls.Add(LayoutControl3Heating)
                Select Case ModeBCCT
                    Case FormMode.NewRecord
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "BCCT", LayoutControl4Maintenance,,, , True, "bdgID", toSQLValueS(sID))
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "BCCT", LayoutControl4Maintenance,,, sID, True)
                End Select
                If sResult Then


                    'If Mode = FormMode.NewRecord Then dtDTS.EditValue = DateTime.Now
                    Cls.ClearGroupCtrls(LayoutControlGroup15)
                    txtCode.Text = DBQ.GetNextId("BCCT")
                    Me.Vw_BCCTTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BCCT, System.Guid.Parse(sID))
                    LayoutControlGroup15.Enabled = False
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdNewBCCT_Click(sender As Object, e As EventArgs) Handles cmdNewBCCT.Click
        LayoutControlGroup15.Enabled = True
        Cls.ClearGroupCtrls(LayoutControlGroup15)
        txtCodeBcct.Text = DBQ.GetNextId("BCCT")
        ModeBCCT = FormMode.NewRecord
    End Sub
    Private Sub cboPRF_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboPrf.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManagePRF(cboPrf, FormMode.NewRecord, False) ' Me.Vw_CCT_PFTableAdapter.FillByPRFid(Me.Priamos_NETDataSet1.vw_CCT_PF, cboPrf.EditValue)
            Case 2 : ManageCbo.ManagePRF(cboPrf, FormMode.EditRecord, False)
            Case 3 : cboPrf.EditValue = Nothing
        End Select
    End Sub


    Private Sub cboCCT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboCCT.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboCCT.EditValue = Nothing : ManageCbo.ManageCCT(False,, cboCCT)
                If cboPrf.EditValue = Nothing Then Exit Sub
                Me.Vw_CCT_PFTableAdapter.FillByPRFid(Me.Priamos_NETDataSet.vw_CCT_PF, System.Guid.Parse(cboPrf.EditValue.ToString))
            Case 2 : If cboCCT.EditValue <> Nothing Then ManageCbo.ManageCCT(False,, cboCCT) : 
                If cboPrf.EditValue = Nothing Then Exit Sub
                Me.Vw_CCT_PFTableAdapter.FillByPRFid(Me.Priamos_NETDataSet.vw_CCT_PF, System.Guid.Parse(cboPrf.EditValue.ToString))
            Case 3 : cboCCT.EditValue = Nothing
        End Select
    End Sub

    Private Sub RepositoryItemLookUpEditCCT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemLookUpEditCCT.ButtonClick
        Dim RecID As String
        Select Case e.Button.Index
            Case 1
                GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "cctID", Nothing)
                ManageCbo.ManageCCT(True, RecID, cboCCT, GridView8)
                GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "cctID", RecID)
            Case 2
                If GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "cctID").ToString <> Nothing Then
                    ManageCbo.ManageCCT(True, RecID, cboCCT, GridView8)
                End If
            Case 3 : GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "cctID", Nothing)
        End Select
    End Sub

    Private Sub RepositoryItemLookUpEditPRF_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemLookUpEditPRF.ButtonClick
        Dim RecID As String
        Select Case e.Button.Index
            Case 1
                GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "prfID", Nothing) : ManageCbo.ManagePRF(cboPrf, FormMode.NewRecord, True, RecID, GridView8)
                Me.Vw_PRFTableAdapter.Fill(Me.Priamos_NETDataSet.vw_PRF)
                GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "prfID", RecID)
            Case 2
                If GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "prfID").ToString <> Nothing Then ManageCbo.ManagePRF(cboPrf, FormMode.EditRecord, True, RecID, GridView8)
            Case 3 : GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "prfID", Nothing)
        End Select
    End Sub
    Private Sub DeleteRecordBCCT()
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM BCCT WHERE ID = '" & GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "ID").ToString & "'"
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Me.Vw_BCCTTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BCCT, System.Guid.Parse(sID))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmddelBCCT_Click(sender As Object, e As EventArgs) Handles cmddelBCCT.Click
        DeleteRecordBCCT()
    End Sub

    Private Sub cmdBCCTRefresh_Click(sender As Object, e As EventArgs) Handles cmdBCCTRefresh.Click
        Me.Vw_BCCTTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BCCT, System.Guid.Parse(sID))
    End Sub


    Private Sub GridView8_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView8.RowUpdated
        Try
            Dim sSQL As String

            sSQL = "UPDATE [BCCT] SET cctID  = " & toSQLValueS(GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "cctID").ToString) &
                ",prfID = " & toSQLValueS(GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "prfID").ToString) &
                ",cmt = " & toSQLValueS(GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "cmt").ToString) &
        " WHERE ID = " & toSQLValueS(GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "ID").ToString)
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Me.Vw_BCCTTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BCCT, System.Guid.Parse(sID))

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NavINH_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavINH.ElementClick
        Maintab.SelectedTabPage = tabINH
        Me.Vw_INHTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_INH, System.Guid.Parse(sID))
        LoadForms.RestoreLayoutFromXml(GridView_INH, "INH_BDG_def.xml")
        cmdDelINH.Enabled = UserProps.AllowDelete

    End Sub

    Private Sub GridView_INH_DoubleClick(sender As Object, e As EventArgs) Handles GridView_INH.DoubleClick
        If GridView_INH.IsGroupRow(GridView_INH.FocusedRowHandle) Then Exit Sub
        Dim fINH As frmINH = New frmINH()
        fINH.Text = "Παραστατικό"
        fINH.ID = GridView_INH.GetRowCellValue(GridView_INH.FocusedRowHandle, "ID").ToString
        fINH.MdiParent = frmMain
        fINH.Mode = FormMode.EditRecord
        fINH.Scroller = GridView_INH
        fINH.FormScroller = Me
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(fINH.Parent.ClientRectangle.Width / 2 - fINH.Width / 2), CInt(fINH.Parent.ClientRectangle.Height / 2 - fINH.Height / 2)))
        fINH.Show()
    End Sub

    Private Sub cmdNewINH_Click(sender As Object, e As EventArgs) Handles cmdNewINH.Click

        Dim fINH As frmINH = New frmINH()
        fINH.Text = "Κοινόχρηστα"
        'fINH.MdiParent = frmMain
        fINH.Mode = FormMode.NewRecord
        fINH.cboBDG.EditValue = System.Guid.Parse(sID)

        'fINH.Scroller = GridView10
        'fINH.FormScroller = Me
        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
        fINH.ShowDialog()
    End Sub

    Private Sub cmdEditINH_Click(sender As Object, e As EventArgs) Handles cmdEditINH.Click
        If GridView_INH.IsGroupRow(GridView_INH.FocusedRowHandle) Then Exit Sub
        Dim fINH As frmINH = New frmINH()
        fINH.Text = "Κοινόχρηστα"
        fINH.ID = GridView_INH.GetRowCellValue(GridView_INH.FocusedRowHandle, "ID").ToString
        'fINH.MdiParent = frmMain
        fINH.Mode = FormMode.EditRecord
        'fINH.Scroller = GridView10
        'fINH.FormScroller = Me
        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
        fINH.ShowDialog()
    End Sub

    Private Sub cmdRefINH_Click(sender As Object, e As EventArgs) Handles cmdRefINH.Click
        Me.Vw_INHTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_INH, System.Guid.Parse(sID))
    End Sub

    Private Sub cmdExportINH_Click(sender As Object, e As EventArgs) Handles cmdExportINH.Click
        Dim options = New XlsxExportOptionsEx()
        options.UnboundExpressionExportMode = UnboundExpressionExportMode.AsFormula
        options.ExportType = ExportType.WYSIWYG
        XtraSaveFileDialog1.Filter = "XLSX Files (*.xlsx*)|*.xlsx"
        XtraSaveFileDialog1.FileName = "Παραστατικά_" & bdgName
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView_INH.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
            Process.Start(XtraSaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub cmdDelINH_Click(sender As Object, e As EventArgs) Handles cmdDelINH.Click
        DelINH()
    End Sub
    Private Sub DelINH()
        Dim sSQL As String
        Try
            If GridView_INH.GetRowCellValue(GridView_INH.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            ' Διαφραφή επιτρέπεται μόνο όταν ειναι έναντι διαμέρισματος ή από μεταφορά ή ο χρήστης είμαι ΕΓΩ
            If GridView_INH.GetRowCellValue(GridView_INH.FocusedRowHandle, "reserveAPT").ToString = "True" Or
                GridView_INH.GetRowCellValue(GridView_INH.FocusedRowHandle, "FromTransfer").ToString = "True" Or
                UserProps.ID.ToString.ToUpper = "E9CEFD11-47C0-4796-A46B-BC41C4C3606B" Then
                If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή? Προσοχή θα επηρεάσει το υπόλοιπο του διαμερίσματος", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    ' Ενημέρωση υπολοίπου διαμερίσματος
                    sSQL = "UPDATE APT " &
                       "SET BAL_ADM = BAL_ADM - debit  " &
                       "FROM COL " &
                       "INNER JOIN APT ON APT.ID=COL.aptID " &
                       "WHERE  inhID =  " & toSQLValueS(GridView_INH.GetRowCellValue(GridView_INH.FocusedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If
                ' Ενημέρωση αποθεματικού
                CalculateDepositA()
                ' Διαγραφή παραστατικού
                sSQL = "DELETE FROM INH WHERE ID = '" & GridView_INH.GetRowCellValue(GridView_INH.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Vw_INHTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_INH, System.Guid.Parse(sID))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cboBefMes_EditValueChanged(sender As Object, e As EventArgs) Handles cboBefMes.EditValueChanged
        LoadMefMes(cboBefMes.EditValue)
        cmdRefreshAHPB.Enabled = True
    End Sub

    Private Sub grdAPT_DoubleClick(sender As Object, e As EventArgs) Handles grdAPT.DoubleClick
        EditApt()
    End Sub

    Private Sub cmdRefreshAHPB_Click(sender As Object, e As EventArgs) Handles cmdRefreshAHPB.Click
        If cboBefMes.Text = "" Then
            XtraMessageBox.Show("Δεν έχετε επιλέξει ημερομηνία προηγ. μέτρησης", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            LoadMefMes(cboBefMes.Text)
        End If


    End Sub

    Private Sub cboPrf_EditValueChanged(sender As Object, e As EventArgs) Handles cboPrf.EditValueChanged
        If cboPrf.EditValue Is Nothing Then Exit Sub
        If cboPrf.EditValue.ToString = "" Then Exit Sub
        Me.Vw_CCT_PFTableAdapter.FillByPRFid(Me.Priamos_NETDataSet.vw_CCT_PF, System.Guid.Parse(cboPrf.EditValue.ToString))

    End Sub

    Private Sub RepositoryItemLookUpEditPRF_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEditPRF.EditValueChanged
        'Dim view As GridView = TryCast(sender, GridView)
        'Dim prfID As String = GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "prfID").ToString()
        'If prfID.Length > 0 Then Me.Vw_CCT_PFTableAdapter.FillByPRFid(Me.Priamos_NETDataSet1.vw_CCT_PF, System.Guid.Parse(prfID))

    End Sub



    Private Sub GridView8_ShownEditor(sender As Object, e As EventArgs) Handles GridView8.ShownEditor
        Dim view As ColumnView = DirectCast(sender, ColumnView)
        If view.FocusedColumn.FieldName = "cctID" Then

            Dim editor As LookUpEdit = CType(view.ActiveEditor, LookUpEdit)
            Dim prfID As String = GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "prfID").ToString()
            editor.Properties.DataSource = Me.Vw_CCT_PFTableAdapter.GetDataByPRFid(System.Guid.Parse(prfID))


        End If
    End Sub

    Private Sub cboBefMes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBefMes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboBefMes.EditValue = Nothing
        End Select
    End Sub

    Private Sub NavBDGF_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavBDGF.ElementClick
        Try
            Maintab.SelectedTabPage = tabBDG_F
            Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_BDG_F, System.Guid.Parse(sID))
            LoadForms.RestoreLayoutFromXml(GridView_BDGF, "vw_BDG_F.xml")
            GridView_BDGF.OptionsBehavior.Editable = False
            txtBDGFCode.Text = DBQ.GetNextId("BDG_F")
            cmdSaveBDGFile.Enabled = True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboDOY_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboDOY.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageDOY(cboDOY, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageDOY(cboDOY, FormMode.EditRecord)
            Case 3 : cboDOY.EditValue = Nothing
        End Select
    End Sub


    Private Sub txtBDGFilename_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtBDGFilename.ButtonClick
        If e.Button.Index = 1 Then
            BDGFileSelection()
        Else
            txtBDGFilename.EditValue = Nothing
        End If
    End Sub
    Private Sub BDGFileSelection(Optional ByVal ValueToGrid As Boolean = False)
        XtraOpenFileDialog1.FilterIndex = 1
        XtraOpenFileDialog1.InitialDirectory = "C:\"
        XtraOpenFileDialog1.Title = "Open File"
        XtraOpenFileDialog1.CheckFileExists = False
        XtraOpenFileDialog1.Multiselect = True
        Dim result As DialogResult = XtraOpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            If ValueToGrid Then
                GridView_BDGF.SetRowCellValue(GridView_BDGF.FocusedRowHandle, "filename", XtraOpenFileDialog1.SafeFileName)
                GridView_BDGF.SetRowCellValue(GridView_BDGF.FocusedRowHandle, "comefrom", System.IO.Path.GetDirectoryName(XtraOpenFileDialog1.FileName))
            Else
                txtBDGFilename.EditValue = ""
                txtBDGFilename.EditValue = XtraOpenFileDialog1.SafeFileName
                If XtraOpenFileDialog1.SafeFileNames.Length > 1 Then txtBDGFilename.EditValue = "{Πολλαπλά Αρχεία}"
            End If
        End If

    End Sub

    Private Sub cmdSaveBDGFile_Click(sender As Object, e As EventArgs) Handles cmdSaveBDGFile.Click
        If Valid.ValidateFormGRP(LayoutControlGroup18) Then
            If XtraOpenFileDialog1.SafeFileName <> "" Then
                If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "BDG_F", sID, "folderCatID", toSQLValueS(cboFolderCat.EditValue.ToString), PB) = False Then
                    XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Cls.ClearGroupCtrls(LayoutControlGroup18)
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                    XtraOpenFileDialog1.FileName = ""
                    txtBDGFilename.EditValue = ""
                    txtBDGFCode.Text = DBQ.GetNextId("BDG_F")
                End If
            End If
            Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_BDG_F, System.Guid.Parse(sID))
            PB.Value = 0

        End If

    End Sub
    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Try
            Dim sFilename = GridView_BDGF.GetRowCellValue(GridView_BDGF.FocusedRowHandle, "filename")
            'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & sFilename)
            Dim fs As System.IO.FileStream = New System.IO.FileStream(Application.StartupPath & "\" & sFilename, System.IO.FileMode.Create)
            Dim b() As Byte = LoadForms.GetFile(GridView_BDGF.GetRowCellValue(GridView_BDGF.FocusedRowHandle, "ID").ToString, "BDG_F")
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute(Application.StartupPath & "\" & sFilename)
        Catch ex As IOException
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdBDGFDelete_Click(sender As Object, e As EventArgs) Handles cmdBDGFDelete.Click
        Dim sSQL As String
        Dim selectedRowHandles As Int32() = GridView_BDGF.GetSelectedRows()
        For I = 0 To selectedRowHandles.Length - 1
            Dim selectedRowHandle As Int32 = selectedRowHandles(I)
            If GridView_BDGF.GetRowCellValue(selectedRowHandle, "ID") = Nothing Then Exit Sub
            sSQL = "DELETE FROM BDG_F WHERE ID = " & toSQLValueS(GridView_BDGF.GetRowCellValue(selectedRowHandle, "ID").ToString)

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

        Next
        Try

            Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_BDG_F, System.Guid.Parse(sID))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdBDGFRefresh_Click(sender As Object, e As EventArgs) Handles cmdBDGFRefresh.Click
        Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_BDG_F, System.Guid.Parse(sID))
    End Sub

    Private Sub cboFolderCat_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboFolderCat.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageFolderCat(cboFolderCat, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageFolderCat(cboFolderCat, FormMode.EditRecord)
            Case 3 : cboFolderCat.EditValue = Nothing
        End Select
    End Sub

    Private Sub cmdBDGFDownload_Click(sender As Object, e As EventArgs) Handles cmdBDGFDownload.Click
        Dim selectedRowHandles As Int32() = GridView_BDGF.GetSelectedRows()
        Dim SelectedPath As String
        Dim result As DialogResult = XtraFolderBrowserDialog1.ShowDialog()
        Try


            If result = DialogResult.OK Then
                SelectedPath = XtraFolderBrowserDialog1.SelectedPath
            Else
                Exit Sub
            End If

            SplashScreenManager1.ShowWaitForm()
            SplashScreenManager1.SetWaitFormCaption("Παρακαλώ περιμένετε")

            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                Dim sFilename = GridView_BDGF.GetRowCellValue(selectedRowHandle, "filename")
                If File.Exists(Application.StartupPath & "\" & sFilename) Then File.Delete(Application.StartupPath & "\" & sFilename)
                Dim fs As System.IO.FileStream = New System.IO.FileStream(Application.StartupPath & "\" & sFilename, System.IO.FileMode.Create)
                Dim b() As Byte = LoadForms.GetFile(GridView_BDGF.GetRowCellValue(selectedRowHandle, "ID").ToString, "BDG_F")
                fs.Write(b, 0, b.Length)
                fs.Close()
                My.Computer.FileSystem.CopyFile(Application.StartupPath & "\" & sFilename, SelectedPath & "\" & sFilename, True)
            Next
            SplashScreenManager1.CloseWaitForm()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            SplashScreenManager1.CloseWaitForm()
        End Try

    End Sub
    Private Sub cmdBDGFEdit_Click(sender As Object, e As EventArgs) Handles cmdBDGFEdit.Click
        Dim sSQL As String
        Dim selectedRowHandles As Int32() = GridView_BDGF.GetSelectedRows()

        Dim lkup As New DevExpress.XtraEditors.LookUpEdit
        lkup.Properties.DataSource = VwFOLDERCATBindingSource
        lkup.Properties.ForceInitialize()
        lkup.Properties.PopulateColumns()
        lkup.Properties.DisplayMember = "name"
        lkup.Properties.ValueMember = "ID"
        lkup.Properties.Columns.Item(0).Visible = False
        lkup.Properties.Columns.Item(1).Caption = "Κατηγορία"
        lkup.Properties.NullText = ""
        Dim args = New XtraInputBoxArgs()
        args.Caption = "Επιλογή Κατηγορίας"
        args.Prompt = "Επιλέξτε Κατηγορία"
        args.DefaultButtonIndex = 0
        args.Editor = lkup
        Dim Result = XtraInputBox.Show(args)
        If Result Is Nothing Then
            lkup = Nothing
            Exit Sub
        Else
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                sSQL = "update BDG_F set folderCatID = " & toSQLValueS(lkup.EditValue.ToString) & " where ID = " & toSQLValueS(GridView_BDGF.GetRowCellValue(selectedRowHandle, "ID").ToString)
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next I
            Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_BDG_F, System.Guid.Parse(sID))
        End If
        lkup = Nothing
    End Sub
    Private Sub cmdBDGFPrint_Click(sender As Object, e As EventArgs) Handles cmdBDGFPrint.Click
        Dim sSQL As String
        Dim selectedRowHandles As Int32() = GridView_BDGF.GetSelectedRows()
        Dim cbo As New DevExpress.XtraEditors.ComboBoxEdit
        cbo.Properties.TextEditStyle = TextEditStyles.DisableTextEditor
        For Each printer As String In PrinterSettings.InstalledPrinters
            cbo.Properties.Items.Add(printer)
        Next printer
        Dim args = New XtraInputBoxArgs()
        args.Caption = "Επιλογή Εκτυπωτή"
        args.Prompt = "Επιλέξτε εκτυπωτή"
        args.DefaultButtonIndex = 0
        'args.DefaultResponse = "Test"
        args.Editor = cbo
        Dim Result = XtraInputBox.Show(args)
        If Result Is Nothing Then
            XtraMessageBox.Show("Πρέπει υποχρεωτικά να επιλέξετε εκτυπωτή για να προχωρήσετε.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        For I = 0 To selectedRowHandles.Length - 1
            Dim selectedRowHandle As Int32 = selectedRowHandles(I)
            Dim sFilename = GridView_BDGF.GetRowCellValue(selectedRowHandle, "filename")
            If File.Exists(Application.StartupPath & "\" & sFilename) Then File.Delete(Application.StartupPath & "\" & sFilename)
            Dim fs As System.IO.FileStream = New System.IO.FileStream(Application.StartupPath & "\" & sFilename, System.IO.FileMode.Create)
            Dim b() As Byte = LoadForms.GetFile(GridView_BDGF.GetRowCellValue(selectedRowHandle, "ID").ToString, "BDG_F")
            fs.Write(b, 0, b.Length)
            fs.Close()

            printme(Application.StartupPath & "\" & sFilename, Result)

        Next
        Try

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub printme(ByVal filename As String, ByVal PrinterName As String)
        Dim SelProcess As New Process

        Dim printDialog1 As New System.Windows.Forms.PrintDialog
        Dim psi As New ProcessStartInfo
        printDialog1.AllowSomePages = True
        printDialog1.UseEXDialog = True
        With printDialog1.PrinterSettings
            .PrintFileName = filename
            .Copies = 2
            .FromPage = 1
            .ToPage = 1
            .PrinterName = PrinterName
        End With

        psi.UseShellExecute = True
        psi.Verb = "print"
        psi.FileName = filename
        psi.Arguments = printDialog1.PrinterSettings.ToString
        psi.WindowStyle = ProcessWindowStyle.Hidden
        SelProcess.StartInfo = psi
        SelProcess.Start()
    End Sub



    Private Sub GridView8_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridView8.CustomDrawCell
        Dim GRD8 As GridView = sender
        If GRD8.GetRowCellValue(e.RowHandle, "Fullname") = Nothing Then Exit Sub
        If e.Column.FieldName = "cctID" Then e.DisplayText = GRD8.GetRowCellValue(e.RowHandle, "Fullname").ToString()

    End Sub

    Private Sub cmdAHPBExport_Click(sender As Object, e As EventArgs) Handles cmdAHPBExport.Click
        Dim options = New XlsxExportOptionsEx()
        options.UnboundExpressionExportMode = UnboundExpressionExportMode.AsFormula
        options.ExportType = ExportType.WYSIWYG
        XtraSaveFileDialog1.Filter = "XLSX Files (*.xlsx*)|*.xlsx"
        XtraSaveFileDialog1.FileName = "Ώρες Μέτρησης_" & bdgName
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView2.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
            Process.Start(XtraSaveFileDialog1.FileName)
        End If
    End Sub


    Private Sub GridView2_ShowingEditor(sender As Object, e As CancelEventArgs) Handles GridView2.ShowingEditor
        Dim View As GridView = sender
        Dim CellValue As String = View.GetRowCellValue(View.FocusedRowHandle, "finalized").ToString()
        If CellValue = "True" Then e.Cancel = True
    End Sub


    Private Sub cmdAptExport_Click(sender As Object, e As EventArgs) Handles cmdAptExport.Click
        Dim options = New XlsxExportOptionsEx()
        options.UnboundExpressionExportMode = UnboundExpressionExportMode.AsFormula
        options.ExportType = ExportType.WYSIWYG
        XtraSaveFileDialog1.Filter = "XLSX Files (*.xlsx*)|*.xlsx"
        XtraSaveFileDialog1.FileName = "Διαμερίσματα_" & bdgName
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView1.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
            Process.Start(XtraSaveFileDialog1.FileName)
        End If

    End Sub

    Private Sub cmdINHEmail_Click(sender As Object, e As EventArgs) Handles cmdINHEmail.Click
        Dim form As frmEmailAPT = New frmEmailAPT()
        Dim sInhIDS As New Dictionary(Of Integer, String)
        Dim selectedRowHandles As Integer() = GridView_INH.GetSelectedRows()
        If selectedRowHandles.Length = 0 Then XtraMessageBox.Show("Δεν έχετε επιλέξει παραστατικό", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        For I = 0 To GridView_INH.SelectedRowsCount - 1
            sInhIDS.Add(selectedRowHandles(I), GridView_INH.GetRowCellValue(selectedRowHandles(I), "ID").ToString)
        Next
        form.Mode = 0
        form.Text = "Αποστολή Email"
        form.IDS = sInhIDS
        form.bdgID = sID
        form.ShowDialog()
    End Sub

    Private Sub cboDebitUsr_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboDebitUsr.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageUSR(cboDebitUsr, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageUSR(cboDebitUsr, FormMode.EditRecord)
            Case 3 : cboDebitUsr.EditValue = Nothing
        End Select
    End Sub

    Private Sub cmdCol_Click(sender As Object, e As EventArgs) Handles cmdCol.Click
        Dim form As frmCollections = New frmCollections()
        form.Text = "Είσπραξεις Κοινοχρήστων"
        UserPermissions.GetUserPermissions(form.Text) : If UserProps.AllowView = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : form.Dispose() : Exit Sub
        form.BDGID = sID
        form.MdiParent = frmMain
        form.Show()

    End Sub

    Private Sub cboKeysManager_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboKeysManager.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.KeysManager(cboKeysManager, FormMode.NewRecord)
            Case 2 : ManageCbo.KeysManager(cboKeysManager, FormMode.EditRecord)
            Case 3 : cboKeysManager.EditValue = Nothing
        End Select

    End Sub

    Private Sub GridView_BDGF_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView_BDGF.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView_BDGF, "vw_BDG_F.xml", "vw_BDG_F")
        Else
            ActiveGrid = GridView_BDGF
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If

    End Sub
    Private Sub cmdSaveProfActD_Click(sender As Object, e As EventArgs) Handles cmdSaveProfActD.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateFormGRP(LayoutControlGroup24) Then
                Dim sGuid As String = System.Guid.NewGuid.ToString
                Select Case ModePROFACTD
                    Case FormMode.NewRecord
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "PROF_ACT_D", LayoutControl6Jobs,,, sGuid, True, "bdgID", toSQLValueS(sID))
                        'Case FormMode.EditRecord
                        '    sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "PROF_ACT_D", LayoutControl6Jobs,,, sID, True)
                End Select


                If sResult Then
                    txtCodeProfActD.Text = DBQ.GetNextId("PROF_ACT_D")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If ModePROFACTD = FormMode.NewRecord Then
                        'Δημιουργία εγγραφής είσπραξης 
                        If XtraMessageBox.Show("Θέλετε να δημιουργηθεί είσπραξη για την εργασία?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                            Dim sSQL As New System.Text.StringBuilder

                            sSQL.AppendLine("INSERT INTO COL_EXT(bdgid,profActDID,credit,debit,bal,ColMethodID,dtcredit,createdOn)")
                            sSQL.AppendLine("VALUES( " & toSQLValueS(sID) & "," & toSQLValueS(sGuid) & ",0," &
                                            toSQLValue(txtProfActDAmt, True) & "," & toSQLValue(txtProfActDAmt, True) & "," & toSQLValueS("75E3251D-077D-42B0-B79A-9F2886381A97") & "," &
                                            toSQLValueS(CDate(dtProfActD.Text).ToString("yyyyMMdd")) & ",getdate())")
                            'Εκτέλεση QUERY
                            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                                oCmd.ExecuteNonQuery()
                            End Using

                            'Ενημέρωση εγγραφής ότι δημιουργήθηκε είσπραξη πάνω της
                            Using oCmd As New SqlCommand("UPDATE PROF_ACT_D SET ColCreated = 1 where ID = " & toSQLValueS(sGuid), CNDB)
                                oCmd.ExecuteNonQuery()
                            End Using


                        End If
                        Cls.ClearGroupCtrls(LayoutControlGroup24)
                        Me.Vw_PROF_ACT_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet3.vw_PROF_ACT_D, System.Guid.Parse(sID))
                    End If

                End If
                Valid.SChanged = False
            End If


        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NavProfActD_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavProfActD.ElementClick
        Try
            Maintab.SelectedTabPage = tabProfActD
            ModePROFACTD = FormMode.NewRecord
            'TODO: This line of code loads data into the 'Priamos_NETDataSet4.vw_PARTNER_AND_WORKSHOP' table. You can move, or remove it, as needed.
            Me.Vw_PARTNER_AND_WORKSHOPTableAdapter.Fill(Me.Priamos_NETDataSet.vw_PARTNER_AND_WORKSHOP)
            'TODO: This line of code loads data into the 'Priamos_NETDataSet3.vw_PROF_ACT' table. You can move, or remove it, as needed.
            Me.Vw_PROF_ACTTableAdapter.Fill(Me.Priamos_NETDataSet3.vw_PROF_ACT)
            Me.Vw_PROF_ACT_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet3.vw_PROF_ACT_D, System.Guid.Parse(sID))
            LoadForms.RestoreLayoutFromXml(GridView10, "vw_PROF_ACT_D.xml")
            txtCodeProfActD.Text = DBQ.GetNextId("PROF_ACT_D")
            cmdSaveProfActD.Enabled = True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cboProfAct_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboProfAct.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManagePROFACT(cboProfAct, FormMode.NewRecord, Me)
            Case 2 : ManageCbo.ManagePROFACT(cboProfAct, FormMode.EditRecord, Me)
            Case 3 : cboProfAct.EditValue = Nothing : txtProfActDAmt.EditValue = Nothing : txtProfActDAmt.Text = "0"
        End Select
    End Sub

    Private Sub cboWorkshop_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboWorkshop.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageCUS(cboWorkshop, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageCUS(cboWorkshop, FormMode.EditRecord)
            Case 3 : cboWorkshop.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboProfAct_EditValueChanged(sender As Object, e As EventArgs) Handles cboProfAct.EditValueChanged
        If cboProfAct.EditValue Is Nothing Then Exit Sub
        txtProfActDAmt.EditValue = cboProfAct.GetColumnValue("amt")
    End Sub

    Private Sub GridView_INH_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView_INH.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView_INH, "INH_BDG_def.xml",, "Select top 1 * from vw_INH")
        Else
            ActiveGrid = GridView_INH
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub cmdNewProfActD_Click(sender As Object, e As EventArgs) Handles cmdNewProfActD.Click
        Cls.ClearGroupCtrls(LayoutControlGroup21)
        txtCodeProfActD.Text = DBQ.GetNextId("PROF_ACT_D")
        ModePROFACTD = FormMode.NewRecord

    End Sub

    Private Sub DeleteRecordPROFACTD()
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader

        Try
            sSQL = "select top 1 completed from COL_EXT where profActDID =  " & toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "ID").ToString)
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()

            If sdr.Read() = True Then
                XtraMessageBox.Show("Δεν μπορείτε να διαγράψετε εργασία όταν υπάρχει είσπραξη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sdr.Close()
                sdr = Nothing

                Exit Sub
            End If
            sdr.Close()
            sdr = Nothing


            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM PROF_ACT_D WHERE ID = '" & GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "ID").ToString & "'"
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Me.Vw_PROF_ACT_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet3.vw_PROF_ACT_D, System.Guid.Parse(sID))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdDeleteProfActD_Click(sender As Object, e As EventArgs) Handles cmdDeleteProfActD.Click
        DeleteRecordPROFACTD()
    End Sub

    Private Sub cmdRefreshProfActD_Click(sender As Object, e As EventArgs) Handles cmdRefreshProfActD.Click
        Me.Vw_PROF_ACT_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet3.vw_PROF_ACT_D, System.Guid.Parse(sID))
    End Sub

    Private Sub RepositoryItemWorkShop_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemWorkShop.ButtonClick
        Dim RecID As String
        Select Case e.Button.Index
            Case 1
                GridView10.SetRowCellValue(GridView10.FocusedRowHandle, "cctID", Nothing)
                ManageCbo.ManageCCT(True, RecID, cboWorkshop, GridView10)
                GridView10.SetRowCellValue(GridView10.FocusedRowHandle, "cctID", RecID)
            Case 2
                If GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "cctID").ToString <> Nothing Then
                    ManageCbo.ManageCCT(True, RecID, cboWorkshop, GridView10)
                End If
            Case 3 : GridView10.SetRowCellValue(GridView10.FocusedRowHandle, "cctID", Nothing)
        End Select
    End Sub
    Private Sub RepositoryItemProfAct_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemProfAct.ButtonClick
        Dim RecID As String
        Select Case e.Button.Index
            Case 1
                GridView10.SetRowCellValue(GridView10.FocusedRowHandle, "profActID", Nothing)
                ManageCbo.ManagePROFACT(cboProfAct, FormMode.NewRecord, Me, True, GridView10)
                GridView10.SetRowCellValue(GridView10.FocusedRowHandle, "profActID", RecID)
            Case 2
                If GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "profActID").ToString <> Nothing Then
                    ManageCbo.ManagePROFACT(cboProfAct, FormMode.EditRecord, Me, True, GridView10)
                End If
            Case 3 : GridView10.SetRowCellValue(GridView10.FocusedRowHandle, "profActID", Nothing)
        End Select
    End Sub
    Private Sub GridView10_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridView10.CustomDrawCell
        Dim GRD10 As GridView = sender
        If e.Column.FieldName = "cctID" Then e.DisplayText = GRD10.GetRowCellValue(e.RowHandle, "cctName").ToString()

    End Sub
    Private Sub GridView10_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView10.RowUpdated

    End Sub

    Private Sub GridView10_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView10.KeyDown
        If e.KeyCode = Keys.Delete Then DeleteRecordPROFACTD()
    End Sub

    Private Sub GridView10_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView10.CellValueChanged
        Try
            Dim sSQL As String

            sSQL = "UPDATE [PROF_ACT_D] SET cctID  = " & toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "cctID").ToString) &
                ",profActID = " & toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "profActID").ToString) &
                ",amt = " & toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "amt").ToString, True) &
                ",colCreated = " & toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "colCreated").ToString) &
                ",cmt = " & toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "cmt").ToString) &
        " WHERE ID = " & toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "ID").ToString)
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            If e.Column.FieldName = "colCreated" And e.Value = "1" Then
                'Δημιουργία εγγραφής είσπραξης 
                If XtraMessageBox.Show("Θέλετε να δημιουργηθεί είσπραξη για την εργασία?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    Dim sSQLs As New System.Text.StringBuilder

                    sSQLs.AppendLine("INSERT INTO COL_EXT(bdgid,profActDID,credit,debit,bal,ColMethodID,dtcredit,createdOn)")
                    sSQLs.AppendLine("VALUES( " & toSQLValueS(sID) & "," & toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "ID").ToString) & ",0," &
                                    toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "amt").ToString, True) & "," &
                                    toSQLValueS(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "amt").ToString, True) & "," &
                                    toSQLValueS("75E3251D-077D-42B0-B79A-9F2886381A97") & "," &
                                    toSQLValueS(CDate(GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "profDate").ToString).ToString("yyyyMMdd")) & ",getdate())")
                    'Εκτέλεση QUERY
                    Using oCmd As New SqlCommand(sSQLs.ToString, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using


                End If
            End If

            Me.Vw_PROF_ACT_DTableAdapter.FillByBDGID(Me.Priamos_NETDataSet3.vw_PROF_ACT_D, System.Guid.Parse(sID))

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NavConsumption_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavConsumption.ElementClick
        Maintab.SelectedTabPage = tabConsumptions
        Me.AHPB_H_HCONSUMPTIONTableAdapter.FillbyBDGID(Me.Priamos_NETDataSet3.AHPB_H_HCONSUMPTION, System.Guid.Parse(sID))
        Me.AHPB_H_BCONSUMPTIONTableAdapter.FillbyBDGID(Me.Priamos_NETDataSet3.AHPB_H_BCONSUMPTION, System.Guid.Parse(sID))
        Me.Vw_CONSUMPTIONSTableAdapter.FillByBdgID(Me.Priamos_NETDataSet3.vw_CONSUMPTIONS, System.Guid.Parse(sID))
        LoadForms.RestoreLayoutFromXml(GridView11, "vw_CONSUMPTIONS.xml")
    End Sub


    Private Sub cmdRefreshConsumption_Click(sender As Object, e As EventArgs) Handles cmdRefreshConsumption.Click
        RefreshConsumption()
    End Sub
    Private Sub RefreshConsumption()
        Me.AHPB_H_HCONSUMPTIONTableAdapter.FillbyBDGID(Me.Priamos_NETDataSet3.AHPB_H_HCONSUMPTION, System.Guid.Parse(sID))
        Me.AHPB_H_BCONSUMPTIONTableAdapter.FillbyBDGID(Me.Priamos_NETDataSet3.AHPB_H_BCONSUMPTION, System.Guid.Parse(sID))
        Me.Vw_CONSUMPTIONSTableAdapter.FillByBdgID(Me.Priamos_NETDataSet3.vw_CONSUMPTIONS, System.Guid.Parse(sID))
    End Sub

    Private Sub GridView11_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView11.KeyDown
        Select Case e.KeyCode
            Case Keys.F5 : RefreshConsumption()
        End Select

    End Sub

    Private Sub GridView10_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView10.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView10, "vw_PROF_ACT_D.xml", "vw_PROF_ACT_D")
        Else
            ActiveGrid = GridView10
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If

    End Sub

    Private Sub GridView_INH_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView_INH.KeyDown
        If e.KeyCode = Keys.Delete Then DelINH()
    End Sub

    Private Sub GridView11_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView11.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView11, "vw_CONSUMPTIONS.xml", "vw_CONSUMPTIONS")
        Else
            ActiveGrid = GridView11
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub GridView2_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView2.ValidatingEditor
        If e.Value = "" Then e.ErrorText = "Παρακαλώ εισάγετε αριθμό" : e.Valid = False
    End Sub

    Private Sub cbogrp_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cbogrp.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageANN_GRPS(cbogrp, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageANN_GRPS(cbogrp, FormMode.EditRecord)
            Case 3 : cbogrp.EditValue = Nothing
        End Select
    End Sub

    Private Sub cmdBDGFEmail_Click(sender As Object, e As EventArgs) Handles cmdBDGFEmail.Click
        Dim form As frmEmailAPT = New frmEmailAPT()
        Dim sIDS As New Dictionary(Of Integer, String)
        Dim selectedRowHandles As Integer() = GridView_BDGF.GetSelectedRows()
        If selectedRowHandles.Length = 0 Then XtraMessageBox.Show("Δεν έχετε επιλέξει αρχείο", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        For I = 0 To GridView_BDGF.SelectedRowsCount - 1
            sIDS.Add(selectedRowHandles(I), GridView_BDGF.GetRowCellValue(selectedRowHandles(I), "ID").ToString)
        Next
        form.IDS = sIDS
        form.Mode = 1
        form.Text = "Αποστολή Email"
        form.bdgID = sID
        form.ShowDialog()
    End Sub

    Private Sub Grid_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Select Case e.Button.ButtonType
            Case e.Button.ButtonType.Remove : If DeleteRecordBDG_M() = vbYes Then e.Handled = False Else e.Handled = True
            Case e.Button.ButtonType.Append
                'GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "isMain", 0) : GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "AllowsendEmail", 0)
                'GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "cctID", "")

        End Select
    End Sub
    Private Function DeleteRecordBDG_M() As MsgBoxResult
        If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "ID") = Nothing Then Return vbCancel
        If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim sSQL As String = "DELETE FROM BDG_M WHERE ID = '" & GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "ID").ToString & "'"
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Me.Vw_BDG_MTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_BDG_M, System.Guid.Parse(sID))
            Return vbYes

        Else
            Return vbNo
        End If
    End Function
    Private Sub GridView12_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView12.ValidateRow
        Dim sSQL As New System.Text.StringBuilder
        Try
            sSQL.Clear()
            If GridView12.RowCount = 0 Then Exit Sub
            If e.RowHandle = grdBDG_M.NewItemRowHandle Then
                If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "cctID").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε επαφή"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "isMain").ToString = "False" And GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AllowsendEmail").ToString = "True" Then
                    e.ErrorText = "Αποστολή Email Επιτρέπεται μόνο στον Κύριο Διαχειριστή"
                    e.Valid = False
                    Exit Sub
                End If
                Dim sGuid As String = Guid.NewGuid.ToString
                GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "ID", sGuid)
                GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "bdgID", sID)
                GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "createdBy", UserProps.ID.ToString)

                sSQL.AppendLine("INSERT INTO BDG_M (ID,bdgID,cctID,isMain,AllowsendEmail,createdBy,MachineName)")
                sSQL.AppendLine("Select " & toSQLValueS(sGuid) & ",")
                sSQL.AppendLine(toSQLValueS(sID) & ",")
                sSQL.AppendLine(toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "cctID").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "isMain").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AllowsendEmail").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString) & ",")
                sSQL.AppendLine(toSQLValueS(UserProps.MachineName))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Else
                If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "cctID").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε επαφή"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "isMain").ToString = "False" And GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AllowsendEmail").ToString = "True" Then
                    e.ErrorText = "Αποστολή Email Επιτρέπεται μόνο στον Κύριο Διαχειριστή"
                    e.Valid = False
                    Exit Sub
                End If
                sSQL.AppendLine("UPDATE BDG_M SET  ")
                sSQL.AppendLine("cctID = " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "cctID").ToString) & ",")
                sSQL.AppendLine("isMain = " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "isMain").ToString) & ",")
                sSQL.AppendLine("AllowsendEmail = " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AllowsendEmail").ToString) & ",")
                sSQL.AppendLine("modifiedBy = " & toSQLValueS(UserProps.ID.ToString) & ",")
                sSQL.AppendLine("MachineName = " & toSQLValueS(UserProps.MachineName))
                sSQL.Append("WHERE ID = " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "ID").ToString))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            End If
        Catch sqlEx As SqlException When sqlEx.Number = 2601
            XtraMessageBox.Show("Έχετε ορίσει παραπάνω από έναν Κύριους διαχειριστές ή προσπαθήσατε να καταχωρήσετε την ίδια επαφή.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Valid = False
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView12_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView12.KeyDown
        If e.KeyCode = Keys.Delete And UserProps.AllowDelete = True Then DeleteRecordBDG_M()
        If e.KeyCode = Keys.Down And UserProps.AllowInsert Then
            If sender.FocusedRowHandle < 0 Then Exit Sub
            Dim viewInfo As GridViewInfo = TryCast(sender.GetViewInfo(), GridViewInfo)
            If sender.FocusedRowHandle = viewInfo.RowsInfo.Last().RowHandle Then

            End If
        End If
    End Sub

    Private Sub RepCCT_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles RepCCT.ButtonPressed
        Dim RecID As String
        Select Case e.Button.Index
            Case 1
                If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "cctID").ToString <> Nothing Then
                    ManageCbo.ManageCCT(True, RecID, , GridView12)
                End If
        End Select
    End Sub

    Private Sub GridView12_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView12.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView12, "BDGManagers_def.xml", "vw_CCT")
        Else
            ActiveGrid = GridView12
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub txtBDGFilename_EditValueChanged(sender As Object, e As EventArgs) Handles txtBDGFilename.EditValueChanged

    End Sub

    Private Sub BarEIDOP_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarEIDOP.ItemClick
        Dim selectedRowHandles As Integer() = GridView_INH.GetSelectedRows()
        For I = 0 To GridView_INH.SelectedRowsCount - 1
            If GridView_INH.GetRowCellValue(selectedRowHandles(I), "Calculated") = True Then PrintReport(1, selectedRowHandles(I))
        Next
    End Sub

    Private Sub BarRECEIPT_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarRECEIPT.ItemClick
        Dim selectedRowHandles As Integer() = GridView_INH.GetSelectedRows()
        For I = 0 To GridView_INH.SelectedRowsCount - 1
            If GridView_INH.GetRowCellValue(selectedRowHandles(I), "Calculated") = True Then PrintReport(2, selectedRowHandles(I))
        Next
    End Sub

    Private Sub BarSYG_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarSYG.ItemClick
        Dim selectedRowHandles As Integer() = GridView_INH.GetSelectedRows()
        For I = 0 To GridView_INH.SelectedRowsCount - 1
            If GridView_INH.GetRowCellValue(selectedRowHandles(I), "Calculated") = True Then PrintReport(0, selectedRowHandles(I))
        Next
    End Sub
    Private Sub PrintReport(ByVal sWichReport As Integer, ByVal Row As Integer)
        Try
            Select Case sWichReport
                Case 0
                    Dim report As New Rep_Sygentrotiki()
                    ' Εαν έχει FI
                    If GridView_INH.GetRowCellValue(Row, "HTypeID") IsNot Nothing Then
                        If GridView_INH.GetRowCellValue(Row, "HTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Then report.HasFI = True Else report.HasFI = False
                    Else
                        report.HasFI = False
                    End If
                    ' Εαν έχει FI Boiler
                    If GridView_INH.GetRowCellValue(Row, "BTypeID") IsNot Nothing Then
                        If GridView_INH.GetRowCellValue(Row, "BTypeID").ToString.ToUpper = "11F7A89C-F64D-4596-A5AF-005290C5FA49" Then report.HasFIBoiler = True Else report.HasFIBoiler = False
                    Else
                        report.HasFIBoiler = False
                    End If
                    If GridView_INH.GetRowCellValue(Row, "ahpb_HID") IsNot Nothing Then
                        If GridView_INH.GetRowCellValue(Row, "ahpb_HID").ToString.Length > 0 Then report.HasHoursH = True Else report.HasHoursH = False
                    Else
                        report.HasHoursH = False
                    End If
                    If GridView_INH.GetRowCellValue(Row, "ahpb_HIDB") IsNot Nothing Then
                        If GridView_INH.GetRowCellValue(Row, "ahpb_HIDB").ToString.Length > 0 Then report.HasHoursBoiler = True Else report.HasHoursBoiler = False
                    Else
                        report.HasHoursBoiler = False
                    End If

                    report.Parameters.Item(0).Value = GridView_INH.GetRowCellValue(Row, "ID").ToString
                    report.Parameters.Item(1).Value = GridView_INH.GetRowCellValue(Row, "bdgID").ToString
                    report.CreateDocument()
                    report.PrintingSystem.Document.ScaleFactor = 0.99


                    Dim tool As New PrintToolBase(report.PrintingSystem)
                    tool.Print()
                Case 1
                    Dim report As New Eidop()
                    report.Parameters.Item(0).Value = GridView_INH.GetRowCellValue(Row, "ID").ToString
                    report.CreateDocument()
                    Dim tool As New PrintToolBase(report.PrintingSystem)
                    tool.Print()
                Case 2
                    Dim report As New Receipt
                    Dim sMargins As New System.Drawing.Printing.Margins
                    report.Parameters.Item(0).Value = GridView_INH.GetRowCellValue(Row, "ID").ToString
                    report.PrintingSystem.Document.ScaleFactor = 0.92
                    report.DefaultPrinterSettingsUsing.UsePaperKind = False
                    report.DefaultPrinterSettingsUsing.UseMargins = False
                    sMargins.Bottom = 50 : sMargins.Top = 90 : sMargins.Left = 100 : sMargins.Right = 50
                    report.Margins = sMargins
                    report.CreateDocument()
                    Dim tool As New PrintToolBase(report.PrintingSystem)
                    tool.Print()

            End Select
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NavDeposit_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavDeposit.ElementClick
        Try
            Maintab.SelectedTabPage = tabDeposit
            Me.DEPOSIT_ATableAdapter.FillbybdgID(Me.Priamos_NET_DataSet_BDG.vw_DEPOSIT_A, System.Guid.Parse(sID))
            LoadForms.RestoreLayoutFromXml(GridView_DepositA, "vw_DEPOSIT_A.xml")
            'Υπολογισμός Διαθέσιμου υπολοίπου
            CalculateDepositR()
            ' Σύνολο Λογιστικού και Διαθέσιμου Αποθεματικού 
            GettotDepositA_R()

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GettotDepositA_R()
        Try

            Dim sAmtA As Double, sAmtR As Double
            Dim sSQL As String = "select top 1 totDepositA,totDepositR from BDG where ID =  " & toSQLValueS(sID)
            Dim cmd As SqlCommand
            Dim sdr As SqlDataReader
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then
                If sdr.IsDBNull(sdr.GetOrdinal("totDepositA")) = False Then sAmtA = sdr.GetDecimal(sdr.GetOrdinal("totDepositA")).ToString
                If sdr.IsDBNull(sdr.GetOrdinal("totDepositR")) = False Then sAmtR = sdr.GetDecimal(sdr.GetOrdinal("totDepositR")).ToString
                sdr.Close()
            Else
                sdr.Close()
            End If
            txtTotalDepositAmt.EditValue = sAmtA
            txtTotalDepositAmtR.EditValue = sAmtR
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub cmdSaveAccountantDeposit_Click(sender As Object, e As EventArgs) Handles cmdSaveAccountantDeposit.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LDeposit) Then
                Dim sGuid As String = System.Guid.NewGuid.ToString
                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "DEPOSIT_A", LDeposit,,, sGuid, True, "bdgID", toSQLValueS(sID))
                If sResult Then
                    If XtraOpenFileDialog1.SafeFileName <> "" Then
                        If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "DEPOSIT_F", sGuid) = False Then
                            XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        XtraOpenFileDialog1.FileName = ""
                    End If
                    CalculateDepositA()
                    ClearDepositA()
                    RefreshDepositA()
                End If
            End If


        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RefreshDepositA()
        Me.DEPOSIT_ATableAdapter.FillbybdgID(Me.Priamos_NET_DataSet_BDG.vw_DEPOSIT_A, System.Guid.Parse(sID))
    End Sub

    Private Sub cmdRefreshDepositA_Click(sender As Object, e As EventArgs) Handles cmdRefreshDepositA.Click
        RefreshDepositA()
    End Sub
    Private Sub DeleteDepositA()
        Dim sSQL As String
        Try
            If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "ID") = Nothing Then Exit Sub

            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM DEPOSIT_A WHERE ID = '" & GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                CalculateDepositA()
                ClearDepositA()

                RefreshDepositA()
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdDeleteDepositA_Click(sender As Object, e As EventArgs) Handles cmdDeleteDepositA.Click
        DeleteDepositA()
    End Sub
    Private Sub GridView_DepositA_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView_DepositA.KeyDown
        Select Case e.KeyCode
            'Case Keys.F2 : If UserProps.AllowInsert = True Then Cls.ClearGroupCtrls(LayoutControlGroup25)
            Case Keys.F3
            Case Keys.F5 : RefreshDepositA()
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteDepositA()
        End Select

    End Sub

    Private Sub GridView_DepositA_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView_DepositA.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView_DepositA, "vw_DEPOSIT_A.xml", "vw_DEPOSIT_A")
        Else
            ActiveGrid = GridView_DepositA
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If

    End Sub

    Private Sub GridView_DepositA_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView_DepositA.ValidateRow
        Dim sSQL As New System.Text.StringBuilder
        Dim sDate As String, sMultiplier As Integer
        Try
            sSQL.Clear()

            If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "dtDeposit").ToString = "" Then
                e.ErrorText = "Παρακαλώ επιλεξτε Ημερομηνία"
                e.Valid = False
                Exit Sub
            End If
            If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "ord").ToString = "" Then
                e.ErrorText = "Παρακαλώ πληκτρολογείστε AA"
                e.Valid = False
                Exit Sub
            End If
            If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "multiplierDescr").ToString = "" Then
                e.ErrorText = "Παρακαλώ επιλεξτε Τύπο Κίνησης"
                e.Valid = False
                Exit Sub
            End If
            If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "ttl").ToString = "" Then
                e.ErrorText = "Παρακαλώ πληκτρολογείστε Λεκτικό"
                e.Valid = False
                Exit Sub
            End If
            If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "amt").ToString = "" Then
                e.ErrorText = "Παρακαλώ πληκτρολογείστε ποσό"
                e.Valid = False
                Exit Sub
            End If
            If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "multiplierDescr").ToString = "Αύξηση" Then
                sMultiplier = 0
            Else
                sMultiplier = 1
            End If
            If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "amt") > 0 And sMultiplier = 1 Then
                e.ErrorText = "Δεν μπορείτε να καταχωρήσετε αρνητικό αριθμό με τύπο κίνησης ""Αύξηση"""
                e.Valid = False
                Exit Sub
            End If
            If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "amt") < 0 And sMultiplier = 0 Then
                e.ErrorText = "Δεν μπορείτε να καταχωρήσετε θετικό αριθμό με τύπο κίνησης ""Μείωση"""
                e.Valid = False
                Exit Sub
            End If

            sSQL.AppendLine("UPDATE DEPOSIT_A	SET ")
            sSQL.AppendLine("ord = " & toSQLValueS(GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "ord").ToString, True) & ",")
            sSQL.AppendLine("multiplier = " & sMultiplier & ",")
            sSQL.AppendLine("ttl= " & toSQLValueS(GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "ttl").ToString) & ",")
            sSQL.AppendLine("amt = " & toSQLValueS(GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "amt").ToString, True) & ",")
            sSQL.AppendLine("isPrepayment = " & toSQLValueS(GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "isPrepayment").ToString) & ",")
            sDate = GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "dtDeposit").ToString
            If sDate <> "" Then sDate = toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) Else sDate = "NULL"
            sSQL.AppendLine("dtDeposit= " & sDate & ",")
            sSQL.AppendLine("modifiedBy = " & toSQLValueS(UserProps.ID.ToString))
            sSQL.Append("WHERE ID = " & toSQLValueS(GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "ID").ToString))
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            'Υπολογισμός Λογιστικού Αποθεματικού
            CalculateDepositA()
        Catch sqlEx As SqlException When sqlEx.Number = 2601
            XtraMessageBox.Show("Ύπάρχει ήδη εγγραφή καταχωρημένη με αυτά τα στοιχεία.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Valid = False
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CalculateDepositA()
        Try
            Using oCmd As New SqlCommand("CalculateAndReturnDepositA", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@bdgID", sID)
                oCmd.Parameters.Add("@Amt", SqlDbType.Decimal)
                oCmd.Parameters("@Amt").Direction = ParameterDirection.Output
                oCmd.ExecuteNonQuery()
                txtTotalDepositAmt.EditValue = oCmd.Parameters("@Amt").Value
                If txtTotalDepositAmt.Text = "" Then txtTotalDepositAmt.EditValue = "0.00"
            End Using
            'Υπολογισμός Διαθέσιμου υπολοίπου
            CalculateDepositR()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CalculateDepositR()
        Try
            Using oCmd As New SqlCommand("CalculateAndReturnDepositR", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@bdgID", sID)
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
                txtTotalDepositAmtR.EditValue = oCmd.Parameters("@totDepositR").Value : If txtTotalDepositAmtR.Text = "" Then txtTotalDepositAmtR.EditValue = "0.00"
                txtUnpaidInd.EditValue = oCmd.Parameters("@UnpaidInd").Value : If txtUnpaidInd.Text = "" Then txtUnpaidInd.EditValue = "0.00"
                txtPaidInd.EditValue = oCmd.Parameters("@PaidInd").Value : If txtPaidInd.Text = "" Then txtPaidInd.EditValue = "0.00"
                txtUnchargeOil.EditValue = oCmd.Parameters("@UnchargableOil").Value : If txtUnchargeOil.Text = "" Then txtUnchargeOil.EditValue = "0.00"
                txtAptBAdm.EditValue = oCmd.Parameters("@AptBalAdm").Value : If txtAptBAdm.Text = "" Then txtAptBAdm.EditValue = "0.00"
                txtPrepayments.EditValue = oCmd.Parameters("@totPrepayments").Value : If txtPrepayments.Text = "" Then txtPrepayments.EditValue = "0.00"
                txttotDepositRAndPrepayments.EditValue = oCmd.Parameters("@totDepositRAndPrepayments").Value : If txttotDepositRAndPrepayments.Text = "" Then txttotDepositRAndPrepayments.EditValue = "0.00"
                txtTotalDepositAmtR.ToolTip = "Διαθέσιμο Υπόλοιπο = (Λογιστικό Υπόλοιπο + Απλήρωτα έξοδα υπολογισμένων παραστατικών) " + Environment.NewLine +
                                              " - " + Environment.NewLine +
                                              "(Πληρωμένα έξοδα μη υπολογισμένων παραστατικών + Υπόλοιπα διαμερισμάτων(από διαχειρίσεις" + Environment.NewLine +
                                              " + " + Environment.NewLine +
                                              "Αχρέωτο πετρέλαιο Δεξαμενής)"
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearDepositA()
        Dim ExceptFields As New List(Of String)
        ExceptFields.Add("txtTotalDepositAmt")
        Cls.ClearCtrls(LDeposit, ExceptFields)
        txtDepositAmt.ForeColor = Color.Black
        txtDepositFilename.EditValue = ""
    End Sub
    Private Sub cboMultiplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMultiplier.SelectedIndexChanged
        If cboMultiplier.SelectedIndex = 0 Then
            txtDepositAmt.ForeColor = Color.Green
        Else
            txtDepositAmt.ForeColor = Color.Red
        End If
        If txtDepositAmt.EditValue IsNot Nothing Then
            If cboMultiplier.SelectedIndex = 1 Then txtDepositAmt.EditValue = txtDepositAmt.EditValue * -1
        End If

    End Sub


    Private Sub txtDepositAmt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDepositAmt.KeyDown
        If e.KeyCode = Keys.Subtract And cboMultiplier.SelectedIndex = 0 Then
            XtraMessageBox.Show("Δεν μπορείτε να καταχωρήσετε αρνητικό αριθμό με τύπο κίνησης ""Αύξηση""", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDepositAmt.EditValue = txtDepositAmt.EditValue.ToString.Replace("-", "")
        End If

    End Sub

    Private Sub cmdAddDepositA_Click(sender As Object, e As EventArgs) Handles cmdAddDepositA.Click
        ClearDepositA()
    End Sub

    Private Sub txtDepositAmt_Validated(sender As Object, e As EventArgs) Handles txtDepositAmt.Validated
        If cboMultiplier.SelectedIndex = 0 Then
            txtDepositAmt.ForeColor = Color.Green
        Else
            txtDepositAmt.ForeColor = Color.Red
        End If
        If txtDepositAmt.EditValue IsNot Nothing Then
            If cboMultiplier.SelectedIndex = 1 Then txtDepositAmt.EditValue = txtDepositAmt.EditValue * -1
        End If
    End Sub

    Private Sub GridView_DepositA_DoubleClick(sender As Object, e As EventArgs) Handles GridView_DepositA.DoubleClick
        If GridView_DepositA.IsGroupRow(GridView_DepositA.FocusedRowHandle) Then Exit Sub
        If GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "inhID") = Nothing Then Exit Sub
        Dim fINH As frmINH = New frmINH()
        fINH.Text = "Παραστατικό"
        fINH.ID = GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "inhID").ToString
        fINH.MdiParent = frmMain
        fINH.Mode = FormMode.EditRecord
        fINH.Scroller = GridView_DepositA
        fINH.FormScroller = Me
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(fINH.Parent.ClientRectangle.Width / 2 - fINH.Width / 2), CInt(fINH.Parent.ClientRectangle.Height / 2 - fINH.Height / 2)))
        fINH.Show()
    End Sub
    Private Sub txtDepositFilename_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtDepositFilename.ButtonClick
        If e.Button.Index = 1 Then
            DepositFileSelection()
        Else
            txtDepositFilename.EditValue = Nothing
        End If
    End Sub
    Private Sub DepositFileSelection(Optional ByVal ValueToGrid As Boolean = False)
        XtraOpenFileDialog1.FilterIndex = 1
        XtraOpenFileDialog1.InitialDirectory = "C:\"
        XtraOpenFileDialog1.Title = "Open File"
        XtraOpenFileDialog1.CheckFileExists = False
        XtraOpenFileDialog1.Multiselect = False
        Dim result As DialogResult = XtraOpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            If ValueToGrid Then
                Using oCmd As New SqlCommand("DELETE FROM DEPOSIT_F where depositAID = '" & GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "ID").ToString & "'", CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "DEPOSIT_F", GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "ID").ToString) = False Then
                    XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                GridView_DepositA.SetRowCellValue(GridView_DepositA.FocusedRowHandle, "filename", XtraOpenFileDialog1.SafeFileName)
                XtraOpenFileDialog1.FileName = ""
                RefreshDepositA()
            Else
                txtDepositFilename.EditValue = "" : txtDepositFilename.EditValue = XtraOpenFileDialog1.SafeFileName
            End If
        End If

    End Sub

    Private Sub RepDepositF_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepDepositF.ButtonClick
        Select Case e.Button.Index
            Case 0 : OpenFileSelection()
            Case 1 : DepositFileSelection(True)
        End Select
        If e.Button.Index = 1 Then cboBefMes.EditValue = Nothing
    End Sub
    Private Sub OpenFileSelection()
        Try
            Dim sFilename = GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "filename")
            If sFilename Is DBNull.Value Then Exit Sub

            Dim fs As System.IO.FileStream = New System.IO.FileStream(Application.StartupPath & "\" & sFilename, System.IO.FileMode.Create)
            Dim b() As Byte = LoadForms.GetFile(GridView_DepositA.GetRowCellValue(GridView_DepositA.FocusedRowHandle, "depositFID").ToString, "DEPOSIT_F")
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute(Application.StartupPath & "\" & sFilename)
        Catch ex As IOException
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboeService_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboeService.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManagePUBLIC_S(cboeService, FormMode.NewRecord)
            Case 2 : ManageCbo.ManagePUBLIC_S(cboeService, FormMode.EditRecord)
            Case 3 : cboeService.EditValue = Nothing
        End Select
    End Sub

    Private Sub cbofService_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cbofService.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManagePUBLIC_S(cbofService, FormMode.NewRecord)
            Case 2 : ManageCbo.ManagePUBLIC_S(cbofService, FormMode.EditRecord)
            Case 3 : cbofService.EditValue = Nothing
        End Select
    End Sub

    Private Sub cbowService_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cbowService.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManagePUBLIC_S(cbowService, FormMode.NewRecord)
            Case 2 : ManageCbo.ManagePUBLIC_S(cbowService, FormMode.EditRecord)
            Case 3 : cbowService.EditValue = Nothing
        End Select
    End Sub

    Private Sub chkKeepDeposit_CheckStateChanged(sender As Object, e As EventArgs) Handles chkKeepDeposit.CheckStateChanged
        NavDeposit.Enabled = chkKeepDeposit.Checked
    End Sub

    Private Sub chkManage_CheckStateChanged(sender As Object, e As EventArgs) Handles chkManage.CheckStateChanged
        chkKeepDeposit.Checked = chkManage.Checked
    End Sub

    Private Sub txtComments_EditValueChanged(sender As Object, e As EventArgs) Handles txtComments.EditValueChanged
        CommentsChanged = True
    End Sub

    Private Sub txtComments_LostFocus(sender As Object, e As EventArgs) Handles txtComments.LostFocus
        If CommentsChanged = True Then
            CommentsChanged = False
            XtraMessageBox.Show("Έχετε κάνει αλλαγές στα ""Σχόλια"". Παρακαλώ αποθηκευστε την πολυκατοικία.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BarEXP_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarEXP.ItemClick
        Dim selectedRowHandles As Integer() = GridView_INH.GetSelectedRows()
        Dim frmFilePreviwer As New frmFilePreviwer
        frmFilePreviwer.Text = "Προβολή Αρχείων"
        frmFilePreviwer.PrintAllExp = True
        For I = 0 To selectedRowHandles.Length - 1
            Dim selectedRowHandle As Int32 = selectedRowHandles(I)
            If GridView_INH.GetRowCellValue(selectedRowHandle, "ID") IsNot Nothing Then
                frmFilePreviwer.sIDs.Add(GridView_INH.GetRowCellValue(selectedRowHandle, "ID").ToString)
            End If
        Next
        frmFilePreviwer.ShowDialog()
    End Sub

    Private Sub cmdCheckTank_Click(sender As Object, e As EventArgs) Handles cmdCheckTank.Click
        Dim fTANK As frmTANK = New frmTANK()
        fTANK.Text = "Καταχώρηση Μετρήσεων Δεξαμενής"
        fTANK.BdgID = sID
        fTANK.Mode = FormMode.NewRecord
        fTANK.ShowDialog()

    End Sub

    Private Sub GetHeatingInf(ByRef sHTypeID As String, ByRef FTypeID As String, ByRef BTypeID As String)
        Try

            Dim sSQL As String = "select top 1 HTypeID,FTypeID,BTypeID from BDG where ID =  " & toSQLValueS(sID)
            Dim cmd As SqlCommand
            Dim sdr As SqlDataReader
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then
                If sdr.IsDBNull(sdr.GetOrdinal("HTypeID")) = False Then sHTypeID = sdr.GetGuid(sdr.GetOrdinal("HTypeID")).ToString
                If sdr.IsDBNull(sdr.GetOrdinal("FTypeID")) = False Then FTypeID = sdr.GetGuid(sdr.GetOrdinal("FTypeID")).ToString
                If sdr.IsDBNull(sdr.GetOrdinal("BTypeID")) = False Then BTypeID = sdr.GetGuid(sdr.GetOrdinal("BTypeID")).ToString
                sdr.Close()
            Else
                sdr.Close()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkGasFixed_CheckedChanged(sender As Object, e As EventArgs) Handles chkGasFixed.CheckedChanged
        If chkGasFixed.Checked = True Then
            cboINH.ReadOnly = False
        Else
            cboINH.ReadOnly = True : cboINH.EditValue = Nothing
        End If
    End Sub




    'Private Sub cmdSaveBDGFile_Click(sender As Object, e As EventArgs) Handles cmdSaveBDGFile.Click
    '    If Valid.ValidateFormGRP(LayoutControlGroup18) Then
    '        If XtraOpenFileDialog1.SafeFileName <> "" Then
    '            If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "BDG_F", sID, "folderCatID", toSQLValueS(cboFolderCat.EditValue.ToString), PB) = False Then
    '                XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Else
    '                Cls.ClearGroupCtrls(LayoutControlGroup18)
    '                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Valid.SChanged = False
    '                XtraOpenFileDialog1.FileName = ""
    '                txtBDGFilename.EditValue = ""
    '                txtBDGFCode.Text = DBQ.GetNextId("BDG_F")
    '            End If
    '        End If
    '        Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_BDG_F, System.Guid.Parse(sID))
    '        PB.Value = 0

    '    End If

    'End Sub
End Class