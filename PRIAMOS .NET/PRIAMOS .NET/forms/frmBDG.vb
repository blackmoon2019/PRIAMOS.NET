Imports System.IO
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

Public Class frmBDG
    '------Private Variables Declaration------
    Private sID As String
    Private sManageID As String
    Private sAHPBID As String
    Private Iam As String
    Private Aam As String
    Public Mode As Byte
    Private bdgName As String
    Private Bmlc As New Dictionary(Of String, String)
    Private ApmilFieldsToBeUpdate As New List(Of String)
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Private CtrlCombo As DevExpress.XtraEditors.LookUpEdit
    Private CalledFromCtrl As Boolean
    Private ModeBCCT As Byte

    '------C L A S S E S------
    Private Valid As New ValidateControls
    Private Log As New Transactions
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
    Public WriteOnly Property CalledFromControl As Boolean
        Set(value As Boolean)
            CalledFromCtrl = value
        End Set
    End Property
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmBDG_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_FOLDER_CAT' table. You can move, or remove it, as needed.
        Me.Vw_FOLDER_CATTableAdapter.Fill(Me.Priamos_NETDataSet.vw_FOLDER_CAT)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_DOY' table. You can move, or remove it, as needed.
        Me.Vw_DOYTableAdapter.Fill(Me.Priamos_NETDataSet.vw_DOY)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet1.vw_CCT_PF' table. You can move, or remove it, as needed.
        'Me.Vw_CCT_PFTableAdapter.Fill(Me.Priamos_NETDataSet1.vw_CCT_PF)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_PRF' table. You can move, or remove it, as needed.
        Me.Vw_PRFTableAdapter.Fill(Me.Priamos_NETDataSet.vw_PRF)
        Dim sSQL As New System.Text.StringBuilder
        'txtAam.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        'txtIam.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        'txtAam.Properties.Mask.EditMask = "c" & ProgProps.Decimals
        'txtIam.Properties.Mask.EditMask = "c" & ProgProps.Decimals
        'Νομοί
        FillCbo.COU(cboCOU)
        'Επαφές
        Dim sSQLcct As New System.Text.StringBuilder
        sSQLcct.AppendLine(" where isprivate =1")
        FillCbo.CCT(cboManager, sSQLcct)

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
                NavTasks.Enabled = False
                NavHeatingInvoices.Enabled = False
                NavDecontamination.Enabled = False
                NavConsumption.Enabled = False
                NavBoiler.Enabled = False
                NavAPM.Enabled = False
                NavINH.Enabled = False
            Case FormMode.EditRecord
                FillCbo.FillCheckedListMLC(chkMLC, FormMode.EditRecord, sID, Bmlc)
                If cboCOU.EditValue <> Nothing Then sSQL.AppendLine(" where couid = " & toSQLValueS(cboCOU.EditValue.ToString))
                FillCbo.AREAS(cboAREAS, sSQL)
                'Dim myLayoutControls As New List(Of Control)
                'myLayoutControls.Add(LayoutControl1BDG) : myLayoutControls.Add(LayoutControl2BManage)
                'LoadForms.LoadFormNew(myLayoutControls, "Select * from vw_BDG where id ='" + sID + "'", True)
                LoadForms.LoadForm(LayoutControl1BDG, "Select * from vw_BDG where id ='" + sID + "'", True)
                Iam = txtIam.EditValue
                Aam = txtAam.EditValue
                LoadForms.LoadDataToGrid(grdAPT, GridView1, "SELECT * FROM VW_APT where bdgid ='" + sID + "' ORDER BY ORD")
        End Select
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        Me.CenterToScreen()
        My.Settings.frmBDG = Me.Location
        My.Settings.Save()
        bdgName = txtNam.Text
        LoadForms.RestoreLayoutFromXml(GridView1, "APT_def.xml")

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

    Private Sub ManageCOU()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Νομοί"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Νομός"
        form1.DataTable = "COU"
        form1.CalledFromControl = True
        form1.CallerControl = cboCOU
        form1.MdiParent = frmMain
        If cboCOU.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboCOU.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub ManageAREAS()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Περιοχές"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Περιοχή"
        form1.L3.Text = "Νομός"
        form1.DataTable = "AREAS"
        form1.CalledFromControl = True
        form1.CallerControl = cboAREAS
        form1.MdiParent = frmMain
        form1.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        If cboAREAS.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboAREAS.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
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

    Private Sub ManageADR()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Διευθύνσεις"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Διεύθυνση"
        form1.L3.Text = "Νομός"
        form1.L4.Text = "Περιοχές"
        form1.L7.Text = "ΤΚ"
        form1.L7.Control.Tag = "tk,0,1,2"
        form1.DataTable = "ADR"
        form1.CalledFromControl = True
        form1.CallerControl = cboADR
        form1.MdiParent = frmMain
        form1.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        form1.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        form1.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        If cboADR.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboADR.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

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
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "BDG", LayoutControl1BDG,,, sGuid, True)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "BDG", LayoutControl1BDG,,, sID, True)
                End Select
                If sResult Then
                    'Ενεργοποίηση Μπάρας
                    NavManage.Enabled = True
                    NavHeating.Enabled = True
                    NavMaintenance.Enabled = True
                    NavFixedCosts.Enabled = True
                    NavTasks.Enabled = True
                    NavHeatingInvoices.Enabled = True
                    NavDecontamination.Enabled = True
                    NavConsumption.Enabled = True
                    NavBoiler.Enabled = True
                    NavAPM.Enabled = True
                    NavINH.Enabled = True

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
                        sSQL = "INSERT INTO BMANAGE(ID,bdgID,createdOn) values (" & toSQLValueS(sManageID) & "," & toSQLValueS(sID) & ", getdate() )"
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

                    If Mode = FormMode.NewRecord Then dtDTS.EditValue = DateTime.Now
                    txtCode.Text = DBQ.GetNextId("BDG")
                    'Dim form As New frmScroller
                    'form.LoadRecords("vw_BDG", sID)
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                    cmdAPTAdd.Enabled = True
                    cmdAptRefresh.Enabled = True
                    cmdAPTEdit.Enabled = True
                    cmdAptDel.Enabled = True
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCode_GotFocus(sender As Object, e As EventArgs) Handles txtCode.GotFocus
        frmMain.bbFields.Caption = "DB Field: BDG.code"
    End Sub

    Private Sub cmdAam_Click(sender As Object, e As EventArgs) Handles cmdAam.Click
        FillAAM_H()
        FlyoutPanel1.OwnerControl = cmdAam
        FlyoutPanel1.OptionsBeakPanel.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade
        FlyoutPanel1.Options.CloseOnOuterClick = True
        FlyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Manual
        FlyoutPanel1.ShowPopup()
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdIam_Click(sender As Object, e As EventArgs) Handles cmdIam.Click
        FillIAM_H()
        FlyoutPanel1.OwnerControl = cmdIam
        FlyoutPanel1.OptionsBeakPanel.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade
        FlyoutPanel1.Options.CloseOnOuterClick = True
        FlyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Manual
        FlyoutPanel1.ShowPopup()
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
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM APT WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                AptRefresh()
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            LoadForms.PopupMenuShow(e, GridView1, "APT_def.xml")
        Else
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
        Dim view As GridView = CType(GridView1, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
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
        Dim sSQL As New System.Text.StringBuilder
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                Exit Sub
            End If
        End If
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
            LoadForms.LoadForm(LayoutControl3Heating, "Select * from vw_BDG where id ='" + sID + "'", True)
        End If
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl3Heating)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl2BManage)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl4InvHeatGas)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl5FixedCosts)

        'cboFtypes.Enabled = False
        'cmdCboManageFtypes.Enabled = False
        'cmdCboManageBtypes.Enabled = False
        'cboBtypes.Enabled = False
        'txtHpc.Enabled = False
        'txtHpb.Enabled = False
        'txtCalH.Enabled = False
        'txtTacH.Enabled = False
        'txtTacB.Enabled = False
        'txtLpcH.Enabled = False
        'txtLpcB.Enabled = False
        'RGBolier.Enabled = False
        'txtCalB.Enabled = False
        'End If
    End Sub
    Private Sub NavHeatingInvoices_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavHeatingInvoices.ElementClick
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                Exit Sub
            End If
        End If
        Maintab.SelectedTabPage = tabHeatingInvoices
        'Προμηθευτές για πετρέλαιο
        FillCbo.SUP(cboOInvSup)
        'Προμηθευτές για φυσικό αέριο
        FillCbo.SUP(cboGInvSup)
        InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")
        GridView3.OptionsBehavior.Editable = False
        'Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable
        Dim ExcludeControls As New List(Of String)
        ExcludeControls.Add(cmdOInvAdd.Name)
        ExcludeControls.Add(cmdOInvDelete.Name)
        ExcludeControls.Add(cmdOInvEdit.Name)
        ExcludeControls.Add(cmdOInvRefresh.Name)
        ExcludeControls.Add(cmdOInvAdd.Name)
        EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup5, ExcludeControls)
        InvGas.LoadGasRecords(grdGas, GridView4, "SELECT * FROM  vw_INV_GAS where bdgid ='" + sID + "' ORDER by createdon desc")
        cmdOInvAdd.Checked = False : cmdOInvEdit.Checked = False
        GridView4.OptionsBehavior.Editable = False
        'Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable
        ExcludeControls.Clear()
        ExcludeControls.Add(cmdGInvAdd.Name)
        ExcludeControls.Add(cmdGInvDelete.Name)
        ExcludeControls.Add(cmdGInvEdit.Name)
        ExcludeControls.Add(cmdGInvRefresh.Name)
        EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup6, ExcludeControls)
        cmdGInvAdd.Checked = False : cmdGInvEdit.Checked = False
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl4InvHeatGas)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl2BManage)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl3Heating)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl5FixedCosts)
    End Sub
    Private Sub NavManage_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavManage.ElementClick
        Dim sSQL As String
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                Exit Sub
            End If
        End If
        Maintab.SelectedTabPage = tabManage
        If sManageID IsNot Nothing Then
            sSQL = "SELECT * FROM vw_BMANAGE WHERE ID = '" & sManageID & "'"
            BdgManage.LoadBManageRecords(LayoutControl2BManage, sSQL)
        End If
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl2BManage)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl3Heating)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl4InvHeatGas)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl5FixedCosts)
    End Sub

    Private Sub NavGeneral_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavGeneral.ElementClick
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                Exit Sub
            End If
        End If
        Maintab.SelectedTabPage = tabBDG
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl2BManage)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl3Heating)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl4InvHeatGas)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl5FixedCosts)
    End Sub

    Private Sub ManageBtypes()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Τύποι Boiler"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τύπος"
        form1.DataTable = "BTYPES"
        form1.CalledFromControl = True
        form1.CallerControl = cboBtypes
        form1.MdiParent = frmMain
        If cboBtypes.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboBtypes.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Private Sub ManageCalcTypes(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim fGen As frmGen = New frmGen()
        fGen.Text = "Τύποι Υπολογισμού"
        fGen.MdiParent = frmMain
        fGen.Mode = FormMode.NewRecord
        fGen.Scroller = GridView1
        fGen.DataTable = "CALC_TYPES"
        fGen.L1.Text = "Κωδικός"
        fGen.L2.Text = "Όνομα"
        fGen.chk1.Text = "Ενεργό"
        fGen.L7.Text = "Τύπος"
        fGen.txtL7.Tag = "type,0,1,2"
        fGen.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        fGen.CalledFromControl = True
        fGen.CallerControl = cbo
        If cbo.EditValue <> Nothing Then
            fGen.Mode = FormMode.EditRecord
            fGen.ID = cbo.EditValue.ToString
        Else
            fGen.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(fGen.Parent.ClientRectangle.Width / 2 - fGen.Width / 2), CInt(fGen.Parent.ClientRectangle.Height / 2 - fGen.Height / 2)))
        fGen.Show()

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

    Private Sub ManageHtypes()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Τύποι Θέρμανσης"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τύπος"
        form1.DataTable = "HTYPES"
        form1.CalledFromControl = True
        form1.CallerControl = cboHtypes
        form1.MdiParent = frmMain
        If cboHtypes.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboHtypes.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub ManageFtypes()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Τύποι Καυσίμων"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Τύπος"
        form1.DataTable = "FTYPES"
        form1.CalledFromControl = True
        form1.CallerControl = cboFtypes
        form1.MdiParent = frmMain
        If cboFtypes.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboFtypes.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
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

    Private Sub ShellExecute(ByVal File As String)
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = File
        myProcess.StartInfo.UseShellExecute = True
        myProcess.StartInfo.RedirectStandardOutput = False
        myProcess.Start()
        myProcess.Dispose()
    End Sub
    Private Sub CheckButton2_CheckedChanged(sender As Object, e As EventArgs)
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            GridView4.OptionsBehavior.Editable = True
        Else
            GridView4.OptionsBehavior.Editable = False
        End If
    End Sub
    Private Sub ManageCUS(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim form1 As frmCustomers = New frmCustomers()
        form1.Text = "Πελάτες"
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
    Private Sub cboOInvSup_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboOInvSup.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboOInvSup.EditValue = Nothing : ManageCUS(cboOInvSup)
            Case 2 : If cboOInvSup.EditValue <> Nothing Then ManageCUS(cboOInvSup)
            Case 3 : cboOInvSup.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboGInvSup_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboGInvSup.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboGInvSup.EditValue = Nothing : ManageCUS(cboGInvSup)
            Case 2 : If cboGInvSup.EditValue <> Nothing Then ManageCUS(cboGInvSup)
            Case 3 : cboGInvSup.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboCOU_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboCOU.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboCOU.EditValue = Nothing : ManageCOU()
            Case 2 : If cboCOU.EditValue <> Nothing Then ManageCOU()
            Case 3 : cboCOU.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboAREAS_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboAREAS.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboAREAS.EditValue = Nothing : ManageAREAS()
            Case 2 : If cboAREAS.EditValue <> Nothing Then ManageAREAS()
            Case 3 : cboAREAS.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboADR_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboADR.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboADR.EditValue = Nothing : ManageADR()
            Case 2 : If cboADR.EditValue <> Nothing Then ManageADR()
            Case 3 : cboADR.EditValue = Nothing
        End Select
    End Sub
    Private Sub LoadMefMes()
        Dim sSQL As String
        If cboBefMes.EditValue <> Nothing Then
            'sSQL = "Select CUR.ID, CUR.code, CUR.aptID, CUR.mes,   
            '  CUR.mesDif, CUR.boiler, CUR.RealName, CUR.nam, CUR.ttl, CUR.ord, CUR.Floor, 
            '  CUR.flrID, CUR.cmt, CUR.bdgID, CUR.bdgNam,CUR.mdt,   " &
            '        "(select BEF.mes as mesB from AHPB BEF where boiler=" + RGTypeHeating.SelectedIndex.ToString + " and bef.bdgID= CUR.bdgID And BEF.aptID =CUR.aptID And BEF.mdt = (select max(mdt) from vw_AHPB where  boiler=" + RGTypeHeating.SelectedIndex.ToString + " and mdt < " + toSQLValueS(CDate(cboBefMes.EditValue).ToString("yyyyMMdd")) + " and aptID=BEF.aptID and bdgID=BEF.bdgID ) ) as mesB " &
            '        "from ( " +
            '        "Select * From vw_AHPB " +
            '        "Where bdgid =" + toSQLValueS(sID) + "  and boiler = " + RGTypeHeating.SelectedIndex.ToString + " and mdt = " + toSQLValueS(CDate(cboBefMes.EditValue).ToString("yyyyMMdd")) + " ) as CUR " +
            '        "   ORDER BY CUR.ORD   "
            'sSQL = "SELECT * FROM vw_AHPB where bdgid ='" + sID + "' and boiler = " + RGTypeHeating.SelectedIndex.ToString + " and mdt = " + toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd")) + "  ORDER BY ORD"
            sSQL = "SELECT CUR.ID, CUR.code, CUR.aptID,     BEF.mdt,CUR.mes, cur.mesB, " +
                    "CUR.mesDif, CUR.boiler, CUR.RealName, CUR.nam, CUR.ttl, CUR.ord, CUR.Floor,  " +
                    "CUR.flrID, CUR.cmt, CUR.bdgID, CUR.bdgNam,CUR.mdt   " +
                    "from vw_AHPB CUR " +
                    "inner join ( " +
                    "Select    [bdgID], [aptID], max([mdt]) as mdt " +
                    "From vw_AHPB " +
                    "Where bdgid =" + toSQLValueS(sID) + "  And boiler = " + RGTypeHeating.SelectedIndex.ToString + " And mdt <= " + toSQLValueS(CDate(cboBefMes.EditValue).ToString("yyyyMMdd")) +
                    "group by [bdgID], [aptID]) as BEF on BEF.aptID=CUR.aptID and BEF.mdt =cur.mdt and boiler=1 ORDER BY CUR.ORD   "

            'sSQL = "Select CUR.ID, CUR.code, CUR.aptID, CUR.mes, BEF.mes as mesB,  
            '  CUR.mesDif, CUR.boiler, CUR.RealName, CUR.nam, CUR.ttl, CUR.ord, CUR.Floor, 
            '  CUR.flrID, CUR.cmt, CUR.bdgID, CUR.bdgNam,CUR.mdt   from ( " +
            '        "Select * From vw_AHPB " +
            '        "Where bdgid =" + toSQLValueS(sID) + "  and boiler = " + RGTypeHeating.SelectedIndex.ToString + " and mdt = " + toSQLValueS(CDate(cboBefMes.EditValue).ToString("yyyyMMdd")) + " ) as CUR " +
            '        "Left Join vw_AHPB BEF on bef.bdgID= CUR.bdgID And BEF.aptID =CUR.aptID And 
            '        BEF.mdt = (select max(mdt) from vw_AHPB where mdt < " + toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd")) + " and aptID=BEF.aptID and bdgID=BEF.bdgID ) ORDER BY CUR.ORD   "
            'LoadForms.LoadDataToGrid(grdAPTAHPB, GridView2, "SELECT * FROM vw_AHPB where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & "and mdt = " + toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd")) & " ORDER BY ORD")
            LoadForms.LoadDataToGrid(grdAPTAHPB, GridView2, sSQL)
            LoadForms.RestoreLayoutFromXml(GridView2, "AHPB_def.xml")
            GridView2.Columns("boiler").OptionsColumn.ReadOnly = True
            GridView2.Columns("mesB").OptionsColumn.ReadOnly = True : GridView2.Columns("mesB").OptionsColumn.AllowEdit = False
            GridView2.Columns("mes").OptionsColumn.ReadOnly = False : GridView2.Columns("mes").OptionsColumn.AllowEdit = True
            GridView2.Columns("mesDif").OptionsColumn.ReadOnly = False : GridView2.Columns("mesDif").OptionsColumn.AllowEdit = True
            GridView2.Columns("nam").OptionsColumn.AllowEdit = False
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
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Valid.SChanged = False
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Valid.SChanged = False
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub cmdAddAHPB_Click(sender As Object, e As EventArgs) Handles cmdAddAHPB.Click
        Try
            If dtMes.EditValue = Nothing Then
                XtraMessageBox.Show("Παρακαλώ επιλέξτε πρώτα ημερομηνία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                    XtraMessageBox.Show("Πρέπει πρώτα να καταχωρήσετε διαμερίσματα", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdDelAHPB_Click(sender As Object, e As EventArgs) Handles cmdDelAHPB.Click
        Dim sSQL As String
        Dim sBoiler As String
        Try
            If RGTypeHeating.SelectedIndex = 0 Then sBoiler = "Θέρμανσης" Else sBoiler = "Boiler"
            If XtraMessageBox.Show("Θέλετε να διαγραφούν οι ώρες " & sBoiler & " για την ημερομηνία " & cboBefMes.Text & " ?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                'sSQL = "DELETE FROM AHPB WHERE bdgID = '" & sID & "' " &
                '        " and  mdt = " + toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd")) &
                '        " and boiler = " & RGTypeHeating.SelectedIndex
                DeleteSelectedRows()
                LoadMefMes()
                If GridView2.RowCount > 0 Then
                    cmdDelAHPB.Enabled = True
                Else
                    cmdDelAHPB.Enabled = False
                    cboBefMes.EditValue = Nothing
                End If
                cmdRefreshAHPB.Enabled = True
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DeleteSelectedRows()
        Dim sSQL As String
        Dim I As Integer
        Try
            For I = 0 To GridView2.SelectedRowsCount - 1
                sSQL = "DELETE FROM AHPB WHERE ID = " & toSQLValueS(GridView2.GetRowCellValue(GridView2.GetSelectedRows(I), "ID").ToString)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next
            LoadForms.LoadDataToGrid(grdAPTAHPB, GridView2, "SELECT * FROM vw_AHPB where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & "and mdt = " + toSQLValueS(CDate(dtMes.Text).ToString("yyyyMMdd")) & " ORDER BY ORD")
            LoadForms.RestoreLayoutFromXml(GridView2, "AHPB_def.xml")
            If GridView2.RowCount <= 0 Then
                If cboBefMes.EditValue = Nothing Then
                    sSQL = "DELETE FROM AHPB_H WHERE bdgID = " & toSQLValueS(sID) & " and mdt = " & toSQLValueS(CDate(dtMes.Text).ToString("yyyyMMdd"))
                Else
                    sSQL = "DELETE FROM AHPB_H WHERE bdgID = " & toSQLValueS(sID) & " and mdt = " & toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd"))
                End If
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Dim sSQL2 As New System.Text.StringBuilder
                sSQL2.AppendLine("where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & " ORDER BY mdt desc")
                'Προηγούμενες μετρήσεις
                FillCbo.BEF_MES(cboBefMes, sSQL2)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub cboBefMes_ButtonClick(sender As Object, e As ButtonPressedEventArgs)
        If e.Button.Index = 1 Then cboBefMes.EditValue = Nothing
    End Sub

    Private Sub cboFtypes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboFtypes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboFtypes.EditValue = Nothing : ManageFtypes()
            Case 2 : If cboFtypes.EditValue <> Nothing Then ManageFtypes()
            Case 3 : cboFtypes.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboHtypes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboHtypes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboHtypes.EditValue = Nothing : ManageCalcTypes(cboHtypes)
            Case 2 : If cboHtypes.EditValue <> Nothing Then ManageCalcTypes(cboHtypes)
            Case 3 : cboHtypes.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboBtypes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBtypes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboBtypes.EditValue = Nothing : ManageCalcTypes(cboBtypes)
            Case 2 : If cboBtypes.EditValue <> Nothing Then ManageCalcTypes(cboBtypes)
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
            LoadForms.PopupMenuShow(e, GridView2, "AHPB_def.xml")
        Else
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub cmdGInvAdd_CheckedChanged(sender As Object, e As EventArgs) Handles cmdGInvAdd.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            GridView4.OptionsBehavior.Editable = False
            InvGas.AddNewGasInv(LayoutControlGroup6)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Enabled, LayoutControlGroup6)
            txtGInvCode.Text = DBQ.GetNextId("INV_GAS")
            cmdGInvSave.Enabled = True
            cmdGInvEdit.Enabled = False
        Else
            Cls.ClearGroupCtrls(LayoutControlGroup6)
            'Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable
            Dim ExcludeControls As New List(Of String)
            ExcludeControls.Add(cmdGInvAdd.Name)
            ExcludeControls.Add(cmdGInvDelete.Name)
            ExcludeControls.Add(cmdGInvEdit.Name)
            ExcludeControls.Add(cmdGInvRefresh.Name)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup6, ExcludeControls)
            cmdGInvSave.Enabled = False
            cmdGInvEdit.Enabled = True
        End If
    End Sub

    Private Sub cmdOInvEdit_CheckedChanged(sender As Object, e As EventArgs) Handles cmdOInvEdit.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            cmdOInvAdd.Enabled = False
            GridView3.OptionsBehavior.Editable = True
        Else
            GridView3.OptionsBehavior.Editable = False
            cmdOInvAdd.Enabled = True
        End If
    End Sub

    Private Sub RepositoryItemButtonGas_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonGas.ButtonClick
        GasFilesSelection(True)
        'If XtraOpenFileDialog1.FileName = "" Then Exit Sub
        'Dim sGID As String = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ID").ToString
        '' Διαγραφή πρώτα παλιού αρχείου
        'Using oCmd As New SqlCommand("delete from INV_GAS WHERE ID = " & toSQLValueS(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "F_ID").ToString), CNDB)
        '    oCmd.ExecuteNonQuery()
        'End Using

        'If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_GASF", sGID) = False Then
        '    XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub

    Private Sub RepositoryItemButtonOil_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonOil.ButtonClick
        OilFilesSelection(True)
        'If XtraOpenFileDialog1.FileName = "" Then Exit Sub
        'Dim sOID As String = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString
        '' Διαγραφή πρώτα παλιού αρχείου
        'Using oCmd As New SqlCommand("delete from INV_OILF WHERE ID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "F_ID").ToString), CNDB)
        '    oCmd.ExecuteNonQuery()
        'End Using
        'If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_OILF", sOID) = False Then
        '    XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If

    End Sub

    Private Sub cmdOInvAdd_CheckedChanged(sender As Object, e As EventArgs) Handles cmdOInvAdd.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            GridView3.OptionsBehavior.Editable = False
            InvOils.AddNewOilInv(LayoutControlGroup5)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Enabled, LayoutControlGroup5)
            txtOInvCode.Text = DBQ.GetNextId("INV_OIL")
            cmdOInvSave.Enabled = True
            cmdOInvEdit.Enabled = False
        Else
            Cls.ClearGroupCtrls(LayoutControlGroup5)
            Dim ExcludeControls As New List(Of String)
            ExcludeControls.Add(cmdOInvAdd.Name)
            ExcludeControls.Add(cmdOInvDelete.Name)
            ExcludeControls.Add(cmdOInvEdit.Name)
            ExcludeControls.Add(cmdOInvRefresh.Name)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup5, ExcludeControls)
            cmdOInvSave.Enabled = False
            cmdOInvEdit.Enabled = True
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            LoadForms.PopupMenuShow(e, GridView4, "INV_GAS_def.xml")
        Else
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
                        XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                XtraOpenFileDialog1.FileName = ""
                InvGas.LoadGasRecords(grdGas, GridView4, "SELECT * FROM  vw_INV_GAS where bdgid ='" + sID + "' ORDER by createdon desc")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grdGas_KeyDown(sender As Object, e As KeyEventArgs) Handles grdGas.KeyDown
        Select Case e.KeyCode
            Case Keys.F2 : If UserProps.AllowInsert = True Then cmdGInvAdd.PerformClick()
            Case Keys.F3 : If UserProps.AllowEdit = True Then cmdGInvEdit.PerformClick()
            Case Keys.F5 : cmdGInvRefresh.PerformClick()
            Case Keys.Delete : If UserProps.AllowDelete = True Then cmdGInvDelete.PerformClick()
        End Select
    End Sub

    Private Sub cmdGInvRefresh_Click(sender As Object, e As EventArgs) Handles cmdGInvRefresh.Click
        InvGas.LoadGasRecords(grdGas, GridView4, "SELECT * FROM  vw_INV_GAS where bdgid ='" + sID + "' ORDER by createdon desc")
    End Sub

    Private Sub cmdGInvDelete_Click(sender As Object, e As EventArgs) Handles cmdGInvDelete.Click
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
            If InvOils.UpdateOilData(GridView3, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString, FieldsToBeUpdate) = True Then
                XtraOpenFileDialog1.FileName = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "comefrom").ToString & "\" & GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "filename").ToString

                If XtraOpenFileDialog1.SafeFileName <> "" Then
                    ' Διαγραφή πρώτα παλιού αρχείου
                    InvOils.DeleteRecordWithoutQuestion(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "F_ID").ToString, "INV_OILF")

                    If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_OILF", GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString) = False Then
                        XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                XtraOpenFileDialog1.FileName = ""
                InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView3.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView3, "INV_OIL_def.xml")
        Else
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub grdOil_KeyDown(sender As Object, e As KeyEventArgs) Handles grdOil.KeyDown
        Select Case e.KeyCode
            Case Keys.F2 : If UserProps.AllowInsert = True Then cmdOInvAdd.PerformClick()
            Case Keys.F3 : If UserProps.AllowEdit = True Then cmdOInvEdit.PerformClick()
            Case Keys.F5 : cmdOInvRefresh.PerformClick()
            Case Keys.Delete : If UserProps.AllowDelete = True Then cmdOInvDelete.PerformClick()
        End Select
    End Sub

    Private Sub cmdOInvDelete_Click(sender As Object, e As EventArgs) Handles cmdOInvDelete.Click
        InvOils.DeleteRecordWithoutQuestion(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "F_ID").ToString, "INV_OILF")
        InvOils.DeleteRecord(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString, "INV_OIL")
        InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")
    End Sub

    Private Sub cmdOInvRefresh_Click(sender As Object, e As EventArgs) Handles cmdOInvRefresh.Click
        InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")
    End Sub

    Private Sub cmdGInvSave_Click(sender As Object, e As EventArgs) Handles cmdGInvSave.Click
        If Valid.ValidateFormGRP(LayoutControlGroup6) Then
            Dim sGID As String = System.Guid.NewGuid.ToString
            If InvGas.InsertGasData(LayoutControlGroup6, sGID, "bdgid", sID) Then
                InvGas.LoadGasRecords(grdGas, GridView4, "SELECT * FROM  vw_INV_GAS where bdgid ='" + sID + "' ORDER by createdon desc")
                If XtraOpenFileDialog1.SafeFileName <> "" Then
                    If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_GASF", sGID) = False Then
                        XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                Cls.ClearGroupCtrls(LayoutControlGroup6)
                'Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable
                'Dim ExcludeControls As New List(Of String)
                'ExcludeControls.Add(cmdGInvAdd.Name)
                'ExcludeControls.Add(cmdGInvDelete.Name)
                'ExcludeControls.Add(cmdGInvEdit.Name)
                'ExcludeControls.Add(cmdGInvRefresh.Name)
                'EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup6, ExcludeControls)
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Valid.SChanged = False
                XtraOpenFileDialog1.FileName = ""
                GridView4.OptionsBehavior.Editable = False
                txtGInvFileNames.EditValue = ""
                'cmdOInvSave.Enabled = False
            End If
        End If
    End Sub

    Private Sub cmdOInvSave_Click(sender As Object, e As EventArgs) Handles cmdOInvSave.Click
        If Valid.ValidateFormGRP(LayoutControlGroup5) Then
            Dim sOID As String = System.Guid.NewGuid.ToString
            If InvOils.InsertOilData(LayoutControlGroup5, sOID, "bdgid", sID) Then
                InvOils.LoadOilRecords(grdOil, GridView3, "SELECT * FROM  vw_INV_OIL where bdgid ='" + sID + "' ORDER by createdon desc")
                If XtraOpenFileDialog1.SafeFileName <> "" Then
                    If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_OILF", sOID) = False Then
                        XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                Cls.ClearGroupCtrls(LayoutControlGroup5)
                ''Κάνει exclude λίστα από controls που δεν θέλω να συμπεριλαμβάνονται στο enable/disable
                'Dim ExcludeControls As New List(Of String)
                'ExcludeControls.Add(cmdOInvAdd.Name)
                'ExcludeControls.Add(cmdOInvDelete.Name)
                'ExcludeControls.Add(cmdOInvEdit.Name)
                'ExcludeControls.Add(cmdOInvRefresh.Name)
                'EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup5, ExcludeControls)
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Valid.SChanged = False
                XtraOpenFileDialog1.FileName = ""
                txtOInvFileNames.EditValue = ""
                GridView3.OptionsBehavior.Editable = False
                'cmdOInvSave.Enabled = False
            End If

        End If
    End Sub

    Private Sub GridView5_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView5.RowUpdated
        Try
            Apmil.UpdateApMilData(GridView5, GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString, ApmilFieldsToBeUpdate)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdDelAPM_Click(sender As Object, e As EventArgs) Handles cmdDelAPM.Click
        Dim sSQL As String
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM APMIL WHERE ID = '" & GridView5.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                GridView5.DeleteRow(GridView1.FocusedRowHandle)
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdApmRefresh_Click(sender As Object, e As EventArgs) Handles cmdApmRefresh.Click
        Try
            ApmLoad()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            LoadForms.LoadColumnDescriptionNames(grdAPM, GridView5, , "vw_APMIL")
            LoadForms.LoadColumnDescriptionNames(grdAPM, GridView7, , "vw_APMIL_D")
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
            ApmilFieldsToBeUpdate.Add("ΠΟΣΟΣΤΟ ΚΛΕΙΣΤΟΥ")
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
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

    Private Sub cmdGInvEdit_CheckedChanged(sender As Object, e As EventArgs) Handles cmdGInvEdit.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            cmdGInvAdd.Enabled = False
            GridView4.OptionsBehavior.Editable = True
        Else
            GridView4.OptionsBehavior.Editable = False
            cmdGInvAdd.Enabled = True
        End If
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim mes As Decimal, mesB As Decimal, Dif As Decimal
        Try
            If e.Column.FieldName <> "mes" Or e.Column.FieldName = "mesDif" Then Exit Sub
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "mes") Is DBNull.Value Then
                mes = 0
            Else
                mes = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "mes")
            End If
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "mesB") Is DBNull.Value Then
                mesB = 0
            Else
                mesB = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "mesB")
            End If
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "mesDif") Is DBNull.Value Then
                Dif = 0
            Else
                Dif = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "mesDif")
            End If

            If e.Column.FieldName = "mes" Then
                Dif = mes - mesB
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "mesDif", Dif)
            ElseIf e.Column.FieldName = "mesDif" Then
                mes = Dif + mesB
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "mes", mes)
            End If

            Dim sSQL As String

            sSQL = "UPDATE  AHPB SET MES = " & toSQLValueS(mes, True) &
                        ",MESDIF = " & toSQLValueS(Dif, True) &
                        " WHERE ID = '" & GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ID").ToString & "'"

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                XtraMessageBox.Show("Η συγκεκριμένη στήλη δεν διατίθεται προς επεξεργασία απευθείας από την όψη", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End Try
    End Sub

    Private Sub NavFixedCosts_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavFixedCosts.ElementClick
        Dim sSQL As String
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                Exit Sub
            End If
        End If
        Maintab.SelectedTabPage = tabFixedCosts
        LoadIEP()
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl5FixedCosts)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl1BDG)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl2BManage)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl3Heating)
        Valid.RemoveControlsForCheckIfSomethingChanged(LayoutControl4InvHeatGas)
    End Sub
    Public Sub LoadIEP()
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_IEP' table. You can move, or remove it, as needed.
        Me.Vw_IEPTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_IEP, System.Guid.Parse(sID))

        'Dim sSQL As String
        'sSQL = "SELECT * FROM vw_IEP WHERE BDGID = '" & sID & "' ORDER BY code"
        'LoadForms.LoadDataToGrid(grdIEP, GridView6, sSQL)
        ''Φορτώνει όλες τις ονομασίες των στηλών από τον SQL. Από το πεδίο Description
        'LoadForms.LoadColumnDescriptionNames(grdIEP, GridView6,, "vw_IEP")
        LoadForms.RestoreLayoutFromXml(GridView6, "IEP_def.xml")
        GridView6.ExpandAllGroups()

    End Sub
    Private Sub GridView6_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView6.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView6, "IEP_def.xml")
        Else
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
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM IEP WHERE ID = '" & GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                LoadIEP()
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub cmdDeiLogin_Click(sender As Object, e As EventArgs) Handles cmdDeiLogin.Click
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

    Private Sub cmdOpenPDF_Click(sender As Object, e As EventArgs) Handles cmdOpenPDF.Click
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
        If result = DialogResult.OK Then txtPayDEI.EditValue = GetTextFromPDF(XtraOpenFileDialog1.SafeFileName)
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Case 1 : cboPrf.EditValue = Nothing : ManagePRF(False) ' Me.Vw_CCT_PFTableAdapter.FillByPRFid(Me.Priamos_NETDataSet1.vw_CCT_PF, cboPrf.EditValue)
            Case 2 : If cboPrf.EditValue <> Nothing Then ManagePRF(False)
            Case 3 : cboPrf.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManagePRF(ByVal isFromGrid As Boolean, Optional ByRef RecID As String = "")
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Επαγγέλματα"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Επάγγελμα"
        form1.DataTable = "PRF"
        If isFromGrid = False Then
            form1.CallerControl = cboPrf
            form1.CalledFromControl = True
            If cboPrf.EditValue <> Nothing Then
                form1.ID = cboPrf.EditValue.ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
            End If
        Else
            If GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "prfID").ToString <> Nothing Then
                form1.ID = GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "prfID").ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
            End If
        End If

        'form1.MdiParent = frmMain

        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
        RecID = form1.RecID
    End Sub

    Private Sub ManageCCT(ByVal isFromGrid As Boolean, Optional ByRef RecID As String = "")
        Dim form1 As frmCustomers = New frmCustomers()
        form1.Text = "Πελάτες"
        'form1.MdiParent = frmMain
        If isFromGrid = False Then
            form1.CallerControl = cboCCT
            form1.CalledFromControl = False
            If cboCCT.EditValue <> Nothing Then
                form1.ID = cboCCT.EditValue.ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
                form1.chkWorkshop.Checked = True
                form1.chkPrivate.Checked = False
            End If
        Else
            If GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "cctID").ToString <> Nothing Then
                form1.ID = GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "cctID").ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
                form1.chkWorkshop.Checked = True
                form1.chkPrivate.Checked = False
            End If
        End If

        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
    End Sub
    Private Sub ManageManager()
        Dim form1 As frmCustomers = New frmCustomers()
        form1.Text = "Διαχειριστής"
        'form1.MdiParent = frmMain
        form1.CallerControl = cboManager
        form1.CalledFromControl = True
        If cboManager.EditValue <> Nothing Then
            form1.ID = cboManager.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
            form1.chkWorkshop.Checked = False
            form1.chkPrivate.Checked = True
        End If

        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
    End Sub
    Private Sub cboCCT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboCCT.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboCCT.EditValue = Nothing : ManageCCT(False) : Me.Vw_CCT_PFTableAdapter.FillByPRFid(Me.Priamos_NETDataSet1.vw_CCT_PF, System.Guid.Parse(cboPrf.EditValue.ToString))
            Case 2 : If cboCCT.EditValue <> Nothing Then ManageCCT(False) : Me.Vw_CCT_PFTableAdapter.FillByPRFid(Me.Priamos_NETDataSet1.vw_CCT_PF, System.Guid.Parse(cboPrf.EditValue.ToString))
            Case 3 : cboCCT.EditValue = Nothing
        End Select
    End Sub

    Private Sub RepositoryItemLookUpEditCCT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemLookUpEditCCT.ButtonClick
        Dim RecID As String
        Select Case e.Button.Index
            Case 1
                GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "cctID", Nothing)
                ManageCCT(True, RecID)
                GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "cctID", RecID)
            Case 2
                If GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "cctID").ToString <> Nothing Then
                    ManageCCT(True, RecID)
                End If
            Case 3 : GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "cctID", Nothing)
        End Select
    End Sub

    Private Sub RepositoryItemLookUpEditPRF_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemLookUpEditPRF.ButtonClick
        Dim RecID As String
        Select Case e.Button.Index
            Case 1
                GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "prfID", Nothing) : ManagePRF(True, RecID)
                Me.Vw_PRFTableAdapter.Fill(Me.Priamos_NETDataSet.vw_PRF)
                GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "prfID", RecID)
            Case 2
                If GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "prfID").ToString <> Nothing Then ManagePRF(True, RecID)
            Case 3 : GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "prfID", Nothing)
        End Select
    End Sub
    Private Sub DeleteRecordBCCT()
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM BCCT WHERE ID = '" & GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "ID").ToString & "'"
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Me.Vw_BCCTTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BCCT, System.Guid.Parse(sID))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboManager_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboManager.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboManager.EditValue = Nothing : ManageManager()
            Case 2 : If cboManager.EditValue <> Nothing Then ManageManager()
            Case 3 : cboManager.EditValue = Nothing
        End Select

    End Sub


    Private Sub NavINH_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavINH.ElementClick
        Maintab.SelectedTabPage = tabINH
        Me.Vw_INHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INH, System.Guid.Parse(sID))
        LoadForms.RestoreLayoutFromXml(GridView10, "INH_BDG_def.xml")


    End Sub

    Private Sub GridView10_DoubleClick(sender As Object, e As EventArgs) Handles GridView10.DoubleClick
        If GridView10.IsGroupRow(GridView10.FocusedRowHandle) Then Exit Sub
        Dim fINH As frmINH = New frmINH()
        fINH.Text = "Κοινόχρηστα"
        fINH.ID = GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "ID").ToString
        fINH.MdiParent = frmMain
        fINH.Mode = FormMode.EditRecord
        fINH.Scroller = GridView10
        fINH.FormScroller = Me
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(fINH.Parent.ClientRectangle.Width / 2 - fINH.Width / 2), CInt(fINH.Parent.ClientRectangle.Height / 2 - fINH.Height / 2)))
        fINH.Show()
    End Sub

    Private Sub cmdNewINH_Click(sender As Object, e As EventArgs) Handles cmdNewINH.Click

        Dim fINH As frmINH = New frmINH()
        fINH.Text = "Κοινόχρηστα"
        'fINH.MdiParent = frmMain
        fINH.Mode = FormMode.NewRecord
        'fINH.Scroller = GridView10
        'fINH.FormScroller = Me
        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
        fINH.ShowDialog()
    End Sub

    Private Sub cmdEditINH_Click(sender As Object, e As EventArgs) Handles cmdEditINH.Click
        If GridView10.IsGroupRow(GridView10.FocusedRowHandle) Then Exit Sub
        Dim fINH As frmINH = New frmINH()
        fINH.Text = "Κοινόχρηστα"
        fINH.ID = GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "ID").ToString
        'fINH.MdiParent = frmMain
        fINH.Mode = FormMode.EditRecord
        'fINH.Scroller = GridView10
        'fINH.FormScroller = Me
        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
        fINH.ShowDialog()
    End Sub

    Private Sub cmdRefINH_Click(sender As Object, e As EventArgs) Handles cmdRefINH.Click
        Me.Vw_INHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INH, System.Guid.Parse(sID))
    End Sub

    Private Sub cmdExportINH_Click(sender As Object, e As EventArgs) Handles cmdExportINH.Click
        Dim options = New XlsxExportOptionsEx()
        options.UnboundExpressionExportMode = UnboundExpressionExportMode.AsFormula
        options.ExportType = ExportType.WYSIWYG
        XtraSaveFileDialog1.Filter = "XLSX Files (*.xlsx*)|*.xlsx"
        XtraSaveFileDialog1.FileName = "Παραστατικά_" & bdgName
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView10.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
            Process.Start(XtraSaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub cmdDelINH_Click(sender As Object, e As EventArgs) Handles cmdDelINH.Click
        Dim sSQL As String
        Try
            If GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                sSQL = "DELETE FROM INH WHERE ID = '" & GridView10.GetRowCellValue(GridView10.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Vw_INHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INH, System.Guid.Parse(sID))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView10_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView10.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            LoadForms.PopupMenuShow(e, GridView10, "INH_BDG_def.xml")
        Else
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub

    Private Sub cboBefMes_EditValueChanged(sender As Object, e As EventArgs) Handles cboBefMes.EditValueChanged
        LoadMefMes()
        cmdRefreshAHPB.Enabled = True
    End Sub

    Private Sub grdAPT_DoubleClick(sender As Object, e As EventArgs) Handles grdAPT.DoubleClick
        EditApt()
    End Sub

    Private Sub cmdRefreshAHPB_Click(sender As Object, e As EventArgs) Handles cmdRefreshAHPB.Click
        If cboBefMes.Text = "" Then
            XtraMessageBox.Show("Δεν έχετε επιλέξει ημερομηνία προηγ. μέτρησης", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim sSQL As String
        sSQL = "SELECT CUR.ID, CUR.code, CUR.aptID,     BEF.mdt,CUR.mes, cur.mesB, " +
                    "CUR.mesDif, CUR.boiler, CUR.RealName, CUR.nam, CUR.ttl, CUR.ord, CUR.Floor,  " +
                    "CUR.flrID, CUR.cmt, CUR.bdgID, CUR.bdgNam,CUR.mdt   " +
                    "from vw_AHPB CUR " +
                    "inner join ( " +
                    "Select    [bdgID], [aptID], max([mdt]) as mdt " +
                    "From vw_AHPB " +
                    "Where bdgid =" + toSQLValueS(sID) + "  And boiler = " + RGTypeHeating.SelectedIndex.ToString + " And mdt <= " + toSQLValueS(CDate(cboBefMes.EditValue).ToString("yyyyMMdd")) +
                    "group by [bdgID], [aptID]) as BEF on BEF.aptID=CUR.aptID and BEF.mdt =cur.mdt and boiler=1 ORDER BY CUR.ORD   "

        LoadForms.LoadDataToGrid(grdAPTAHPB, GridView2, sSQL)
        LoadForms.RestoreLayoutFromXml(GridView2, "AHPB_def.xml")

    End Sub

    Private Sub cboPrf_EditValueChanged(sender As Object, e As EventArgs) Handles cboPrf.EditValueChanged
        Me.Vw_CCT_PFTableAdapter.FillByPRFid(Me.Priamos_NETDataSet1.vw_CCT_PF, System.Guid.Parse(cboPrf.EditValue.ToString))

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
            Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NETDataSet.vw_BDG_F, System.Guid.Parse(sID))
            GridView12.OptionsBehavior.Editable = False
            txtBDGFCode.Text = DBQ.GetNextId("BDG_F")
            cmdSaveBDGFile.Enabled = True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.TargetSite), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboDOY_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboDOY.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboDOY.EditValue = Nothing : ManageDOY()
            Case 2 : If cboDOY.EditValue <> Nothing Then ManageDOY()
            Case 3 : cboDOY.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageDOY()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "ΔΟΥ"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "ΔΟΥ"
        form1.DataTable = "DOY"
        form1.CallerControl = cboDOY
        form1.CalledFromControl = True
        If cboDOY.EditValue <> Nothing Then form1.ID = cboDOY.EditValue.ToString
        form1.MdiParent = frmMain
        If cboDOY.EditValue <> Nothing Then form1.Mode = FormMode.EditRecord Else form1.Mode = FormMode.NewRecord
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub txtInvoiceFilename_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtBDGFilename.ButtonClick
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
                GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "filename", XtraOpenFileDialog1.SafeFileName)
                GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "comefrom", System.IO.Path.GetDirectoryName(XtraOpenFileDialog1.FileName))
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
                    XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Cls.ClearGroupCtrls(LayoutControlGroup18)
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                    XtraOpenFileDialog1.FileName = ""
                    txtBDGFilename.EditValue = ""
                    txtBDGFCode.Text = DBQ.GetNextId("BDG_F")
                End If
            End If
            Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NETDataSet.vw_BDG_F, System.Guid.Parse(sID))
            PB.Value = 0

        End If

    End Sub
    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Try
            Dim sFilename = GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "filename")
            'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\" & sFilename)
            Dim fs As System.IO.FileStream = New System.IO.FileStream(Application.StartupPath & "\" & sFilename, System.IO.FileMode.Create)
            Dim b() As Byte = LoadForms.GetFile(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "ID").ToString, "BDG_F")
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute(Application.StartupPath & "\" & sFilename)
        Catch ex As IOException
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdBDGFDelete_Click(sender As Object, e As EventArgs) Handles cmdBDGFDelete.Click
        Dim sSQL As String
        Dim selectedRowHandles As Int32() = GridView12.GetSelectedRows()
        For I = 0 To selectedRowHandles.Length - 1
            Dim selectedRowHandle As Int32 = selectedRowHandles(I)
            If GridView12.GetRowCellValue(selectedRowHandle, "ID") = Nothing Then Exit Sub
            sSQL = "DELETE FROM BDG_F WHERE ID = " & toSQLValueS(GridView12.GetRowCellValue(selectedRowHandle, "ID").ToString)

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

        Next
        Try

            Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NETDataSet.vw_BDG_F, System.Guid.Parse(sID))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdBDGFRefresh_Click(sender As Object, e As EventArgs) Handles cmdBDGFRefresh.Click
        Me.Vw_BDG_FTableAdapter.FillByBdgID(Me.Priamos_NETDataSet.vw_BDG_F, System.Guid.Parse(sID))
    End Sub

    Private Sub cboFolderCat_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboFolderCat.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboFolderCat.EditValue = Nothing : ManageFolderCat()
            Case 2 : If cboFolderCat.EditValue <> Nothing Then ManageFolderCat()
            Case 3 : cboFolderCat.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageFolderCat()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Κατηγορίες Φακέλων"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Κατηγορία"
        form1.DataTable = "FOLDER_CAT"
        form1.CalledFromControl = True
        form1.CallerControl = cboFolderCat
        form1.MdiParent = frmMain
        If cboFolderCat.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboFolderCat.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub cmdBDGFPrint_Click(sender As Object, e As EventArgs) Handles cmdBDGFPrint.Click
        Dim sSQL As String
        Dim selectedRowHandles As Int32() = GridView12.GetSelectedRows()
        Dim cbo As New DevExpress.XtraEditors.ComboBoxEdit
        cbo.Properties.TextEditStyle=TextEditStyles.DisableTextEditor 
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
            XtraMessageBox.Show("Πρέπει υποχρεωτικά να επιλέξετε εκτυπωτή για να προχωρήσετε.", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        For I = 0 To selectedRowHandles.Length - 1
            Dim sFilename = GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "filename")
            Dim fs As System.IO.FileStream = New System.IO.FileStream(Application.StartupPath & "\" & sFilename, System.IO.FileMode.Create)
            Dim b() As Byte = LoadForms.GetFile(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "ID").ToString, "BDG_F")
            fs.Write(b, 0, b.Length)
            fs.Close()

            printme(Application.StartupPath & "\" & sFilename, Result)

        Next
        Try

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        If e.Column.FieldName = "cctID" Then e.DisplayText = GRD8.GetRowCellValue(e.RowHandle, "Fullname").ToString()

    End Sub












    'ΘΕΡΜΑΝΣΗ
    '    Private Sub cboHtypes_EditValueChanged(sender As Object, e As EventArgs) Handles cboHtypes.EditValueChanged

    '        Select Case cboHtypes.EditValue
    '            'Αυτονομία με σταθερό πάγιο
    '            Case System.Guid.Parse("1879D79E-6071-4C1B-A9A4-0AEC70EB8025")
    '                cboBtypes.Enabled = True
    '                cmdCboManageBtypes.Enabled = True
    '                cboFtypes.Enabled = True
    '                txtHpc.Enabled = True
    '                RGBolier.Enabled = True
    '            'Αυτονομία με χρήση Fi
    '            Case System.Guid.Parse("64FE370B-9499-4263-861E-E1820E0ED9CD")
    '                cboBtypes.Enabled = True
    '                cmdCboManageBtypes.Enabled = True
    '                cboFtypes.Enabled = True
    '                txtHpc.Enabled = False
    '                RGBolier.Enabled = False
    '            'Κεντρική Θέρμανση
    '            Case System.Guid.Parse("D29BAB0F-F94C-428F-A699-102EE9EF0BC2")
    '                cboFtypes.Enabled = True
    '                txtHpc.Enabled = False
    '                RGBolier.Enabled = False
    '            Case Else
    '                cboBtypes.Enabled = False
    '                cboBtypes.EditValue = Nothing
    '                cboBtypes.EditValue = ""
    '                cboBtypes.Text = ""
    '                cmdCboManageBtypes.Enabled = False
    '                cboFtypes.Enabled = False
    '                txtHpc.Enabled = False
    '                RGBolier.Enabled = False
    '        End Select
    '    End Sub
    '    'BOILER
    '    Private Sub cboBtypes_EditValueChanged(sender As Object, e As EventArgs) Handles cboBtypes.EditValueChanged
    '        Select Case cboBtypes.EditValue
    '            'Με Σταθερό Πάγιο
    '            Case System.Guid.Parse("9E155093-4E5E-42AB-AFEB-57239B8E25F0")
    '                txtHpb.Enabled = True
    '                RGBolier.Enabled = True
    '            'Με Χρήση Fi
    '            Case System.Guid.Parse("19E83D91-E350-47DA-9BE0-80AEF55AC70A")
    '                RGBolier.Enabled = True
    '            Case Else
    '                txtHpb.Enabled = False
    '                RGBolier.Enabled = False
    '        End Select
    '    End Sub
    '    'ΤΥΠΟΣ ΚΑΥΣΙΜΟΥ
    '    Private Sub cboFtypes_EditValueChanged(sender As Object, e As EventArgs) Handles cboFtypes.EditValueChanged
    '        Select Case cboFtypes.EditValue
    '            'Πετρέλαιο
    '            Case System.Guid.Parse("AA662AEB-2B3B-4189-8253-A904669E7BCB")
    '                If cboHtypes.EditValue = System.Guid.Parse("D29BAB0F-F94C-428F-A699-102EE9EF0BC2") Or
    '                   cboHtypes.EditValue = System.Guid.Parse("1879D79E-6071-4C1B-A9A4-0AEC70EB8025") Or
    '                   cboHtypes.EditValue = System.Guid.Parse("64FE370B-9499-4263-861E-E1820E0ED9CD") Then
    '                    txtTacH.Enabled = True
    '                    txtLpcH.Enabled = True
    '                Else
    '                    txtTacH.Enabled = False
    '                    txtLpcH.Enabled = False
    '                End If
    '            Case Else
    '                txtTacH.Enabled = False
    '        End Select
    '    End Sub

    '    Private Sub RGBolier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RGBolier.SelectedIndexChanged
    '        'Ξεχωριστός
    '        If RGBolier.SelectedIndex = 1 Then
    '            If cboFtypes.EditValue = System.Guid.Parse("AA662AEB-2B3B-4189-8253-A904669E7BCB") Then
    '                If cboBtypes.EditValue = System.Guid.Parse("9E155093-4E5E-42AB-AFEB-57239B8E25F0") Or cboBtypes.EditValue = System.Guid.Parse("19E83D91-E350-47DA-9BE0-80AEF55AC70A") Then
    '                    txtLpcH.Enabled = True
    '                Else
    '                    txtLpcH.Enabled = False
    '                End If
    '            End If
    '            'Boiler
    '            Select Case cboBtypes.EditValue
    '            'Με Σταθερό Πάγιο - 'Με Χρήση Fi
    '                    Case System.Guid.Parse("9E155093-4E5E-42AB-AFEB-57239B8E25F0"), System.Guid.Parse("19E83D91-E350-47DA-9BE0-80AEF55AC70A")
    '                        If cboFtypes.EditValue = System.Guid.Parse("AA662AEB-2B3B-4189-8253-A904669E7BCB") Then
    '                            txtTacB.Enabled = True
    '                        End If
    '                    Case Else
    '                        txtHpb.Enabled = False
    '                        RGBolier.Enabled = False
    '                        txtTacB.Enabled = False
    '                End Select
    '            Else
    '                txtTacB.Enabled = False
    '        End If
    '    End Sub

End Class