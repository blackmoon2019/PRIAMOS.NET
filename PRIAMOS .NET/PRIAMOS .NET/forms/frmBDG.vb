Imports System.Data.SqlClient
Imports DevExpress.Utils.Menu
Imports DevExpress.Utils
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Calendar
Imports DevExpress.XtraEditors.Controls

Public Class frmBDG
    '------Private Variables Declaration------
    Private sID As String
    Private sManageID As String
    Private sAHPBID As String
    Private Iam As String
    Private Aam As String
    Public Mode As Byte
    Private Bmlc As New Dictionary(Of String, String)
    Private ApmilFieldsToBeUpdate As New List(Of String)
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
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
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmBDG_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sSQL As New System.Text.StringBuilder
        txtAam.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        txtIam.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        txtAam.Properties.Mask.EditMask = "c" & ProgProps.Decimals
        txtIam.Properties.Mask.EditMask = "c" & ProgProps.Decimals
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
                NavTasks.Enabled = False
                NavHeatingInvoices.Enabled = False
                NavDecontamination.Enabled = False
                NavConsumption.Enabled = False
                NavBoiler.Enabled = False
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
        Me.CenterToScreen()
        My.Settings.frmBDG = Me.Location
        My.Settings.Save()
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\APT_def.xml") Then GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\APT_def.xml", OptionsLayoutBase.FullLayout)
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
        form1.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
        form1.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
        sSQL.AppendLine("Select id,Name from vw_ADR ")
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
        form1.DataTable = "ADR"
        form1.CalledFromControl = True
        form1.CallerControl = cboADR
        form1.MdiParent = frmMain
        form1.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
        If sender.editvalue <> Nothing Then txtNam.Text = cboADR.Text + " " + txtAR.Text Else txtNam.Text = ""
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

                    dtDTS.EditValue = DateTime.Now
                    txtCode.Text = DBQ.GetNextId("BDG")
                    Dim form As New frmScroller
                    form.LoadRecords("vw_BDG")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\APT_def.xml") Then GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\APT_def.xml", OptionsLayoutBase.FullLayout)
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
        form1.MdiParent = frmMain
        form1.Mode = FormMode.NewRecord
        form1.FormScroller = Me
        form1.BDGID = sID
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub
    Private Sub EditApt()
        Dim form1 As frmAPT = New frmAPT()
        form1.Text = "Διαμερίσματα"
        form1.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
        form1.MdiParent = frmMain
        form1.Mode = FormMode.EditRecord
        form1.FormScroller = Me
        form1.BDGID = sID
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
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

    Private Sub grdAPT_DoubleClick(sender As Object, e As EventArgs) Handles grdAPT.DoubleClick
        EditApt()
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()
            Dim itemSaveView As New DXEditMenuItem()

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
        Else
            PopupMenuRows.ShowPopup(Control.MousePosition)
        End If
    End Sub
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView1.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChangedAHPB(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView2.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChangedINV_OIL(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView3.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    Private Sub OnColumnsColorChangedINV_GAS(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView4.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    Private Sub OnColumnsColorChangedAPMIL(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView5.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub

    'Αποθήκευση όψης Διαμερισμάτων
    Private Sub OnSaveView(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\APT_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    'Αποθήκευση όψης Μετρήσεων ωρών
    Private Sub OnSaveViewAHPB(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\AHPB_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub OnSaveViewINV_OIL(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView3.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\INV_OIL_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub OnSaveViewINV_GAS(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView4.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\INV_GAS_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub OnSaveViewAPMIL(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GridView5.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\APMIL_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub OnEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView1.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Sub OnEditValueChangedAHPB(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView2.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Sub OnEditValueChangedINV_OIL(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView3.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Sub OnEditValueChangedINV_GAS(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView4.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Sub OnEditValueChangedAPMIL(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView5.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub

    Private Sub OnCanMoveItemClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    Private Function CreateCheckItem(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClick))
        item.Tag = New MenuColumnInfo(column)
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
        tabBDG.SelectedTabPage = XtraTabPage3
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
        tabBDG.SelectedTabPage = XtraTabPage7
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
    End Sub
    Private Sub NavManage_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavManage.ElementClick
        Dim sSQL As String
        tabBDG.SelectedTabPage = XtraTabPage2
        If sManageID.Length > 0 Then
            sSQL = "SELECT * FROM vw_BMANAGE WHERE ID = '" & sManageID & "'"
            BdgManage.LoadBManageRecords(LayoutControl2BManage, sSQL)
        End If
    End Sub

    Private Sub NavGeneral_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavGeneral.ElementClick
        tabBDG.SelectedTabPage = XtraTabPage1
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
        form1.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
        fGen.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        fGen.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        fGen.L6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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

    Private Sub dtMes_DrawItem(sender As Object, e As CustomDrawDayNumberCellEventArgs)
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
        form1.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
        form1.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        form1.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
    Private Sub cboOInvSup_ButtonPressed(sender As Object, e As ButtonPressedEventArgs)
        Select Case e.Button.Index
            Case 1 : ManageCUS(cboOInvSup)
            Case 2 : cboOInvSup.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboGInvSup_ButtonPressed(sender As Object, e As ButtonPressedEventArgs)
        Select Case e.Button.Index
            Case 1 : ManageCUS(cboGInvSup)
            Case 2 : cboGInvSup.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboCOU_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboCOU.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCOU()
            Case 2 : cboCOU.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboAREAS_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboAREAS.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageAREAS()
            Case 2 : cboAREAS.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboADR_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboADR.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageADR()
            Case 2 : cboADR.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboBefMes_EditValueChanged(sender As Object, e As EventArgs) Handles cboBefMes.EditValueChanged
        Dim sSQL As String
        If cboBefMes.EditValue <> Nothing Then
            sSQL = "SELECT * FROM vw_AHPB where bdgid ='" + sID + "' and boiler = " + RGTypeHeating.SelectedIndex.ToString + " and mdt = " + toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd")) + "  ORDER BY ORD"
            LoadForms.LoadDataToGrid(grdAPTAHPB, GridView2, sSQL)
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\AHPB_def.xml") Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\AHPB_def.xml", OptionsLayoutBase.FullLayout)
            GridView2.Columns("boiler").OptionsColumn.ReadOnly = True
            GridView2.Columns("nam").OptionsColumn.AllowEdit = False
            cmdDelAHPB.Enabled = True
        Else
            cmdDelAHPB.Enabled = False
        End If
    End Sub

    Private Sub cmdSaveBills_Click(sender As Object, e As EventArgs) Handles cmdSaveBills.Click
        Dim sResult As Boolean
        Try
            'Η Νέα εγγραφή γίνεται πάντα όταν καταχωρείται η πολυκατοικία
            If Mode = FormMode.EditRecord Then
                sResult = BdgManage.UpdateBManageData(LayoutControl2BManage, sManageID)
                DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "BMANAGE", LayoutControl2BManage,,, sManageID, True)
            End If
            If sResult Then
                Dim form As New frmScroller
                form.LoadRecords("vw_BDG")
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub NavAPM_ElementClick(sender As Object, e As NavElementEventArgs) Handles NavAPM.ElementClick
        Try
            tabBDG.SelectedTabPage = XtraTabPage11
            ApmLoad()
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
                    Dim form As New frmScroller
                    form.LoadRecords("vw_BDG")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()
            Dim itemSaveView As New DXEditMenuItem()

            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChangedAPMIL, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex
                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItem("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChangedAPMIL, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveViewAPMIL, Nothing, Nothing, Nothing, Nothing))
            End If
        Else
            PopupMenuRows.ShowPopup(Control.MousePosition)
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
                    oCmd.Parameters.AddWithValue("@bolier", RGTypeHeating.SelectedIndex)
                    oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID.ToString)
                    oCmd.ExecuteNonQuery()
                End Using
                LoadForms.LoadDataToGrid(grdAPTAHPB, GridView2, "SELECT * FROM vw_AHPB where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & "and mdt = " + toSQLValueS(CDate(dtMes.Text).ToString("yyyyMMdd")) & " ORDER BY ORD")
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\AHPB_def.xml") Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\AHPB_def.xml", OptionsLayoutBase.FullLayout)
                Dim sSQL As New System.Text.StringBuilder
                sSQL.AppendLine("where bdgid ='" + sID + "' and boiler = " & RGTypeHeating.SelectedIndex & " ORDER BY mdt desc")
                'Προηγούμενες μετρήσεις
                FillCbo.BEF_MES(cboBefMes, sSQL)
                cboBefMes.EditValue = Nothing
                GridView2.Columns("boiler").OptionsColumn.ReadOnly = True
                GridView2.Columns("nam").OptionsColumn.AllowEdit = False

            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdDelAHPB_Click(sender As Object, e As EventArgs) Handles cmdDelAHPB.Click
        Dim sSQL As String
        Dim sBoiler As String
        Try
            If RGTypeHeating.SelectedIndex = 0 Then sBoiler = "Boiler" Else sBoiler = "Θέρμανσης"
            If XtraMessageBox.Show("Θέλετε να διαγραφούν οι ώρες " & sBoiler & " για την ημερομηνία " & cboBefMes.Text & " ?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM AHPB WHERE bdgID = '" & sID & "' " &
                        " and  mdt = " + toSQLValueS(CDate(cboBefMes.Text).ToString("yyyyMMdd")) &
                        " and boiler = " & RGTypeHeating.SelectedIndex

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Cls.ClearGrid(grdAPTAHPB)
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cboBefMes_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboBefMes.ButtonClick
        If e.Button.Index = 1 Then cboBefMes.EditValue = Nothing
    End Sub

    Private Sub cboFtypes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboFtypes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageFtypes()
            Case 2 : cboFtypes.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboHtypes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboHtypes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCalcTypes(cboHtypes)
            Case 2 : cboHtypes.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboBtypes_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBtypes.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCalcTypes(cboBtypes)
            Case 2 : cboBtypes.EditValue = Nothing
        End Select

    End Sub

    Private Sub HyperlinkLabelControl1_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles HyperlinkLabelControl1.HyperlinkClick
        System.Diagnostics.Process.Start(e.Text)
    End Sub

    Private Sub HyperlinkLabelControl111_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles HyperlinkLabelControl111.HyperlinkClick
        System.Diagnostics.Process.Start(e.Text)
    End Sub

    Private Sub HyperlinkLabelControl11_HyperlinkClick(sender As Object, e As HyperlinkClickEventArgs) Handles HyperlinkLabelControl11.HyperlinkClick
        System.Diagnostics.Process.Start(e.Text)
    End Sub

    Private Sub GridView2_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView2.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()
            Dim itemSaveView As New DXEditMenuItem()

            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChangedAHPB, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex
                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItem("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChangedAHPB, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveViewAHPB, Nothing, Nothing, Nothing, Nothing))
            End If
        Else
            PopupMenuRows.ShowPopup(Control.MousePosition)
        End If
    End Sub

    Private Sub GridView2_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView2.RowUpdated
        Dim sSQL As String
        Dim mes As Decimal
        Dim mesB As Decimal
        Dim Dif As Decimal
        Try
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
            Dif = mes - mesB
            GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "mesDif", Dif)
            sSQL = "UPDATE  AHPB SET MES = " & toSQLValueS(mes, True) &
                    ",MESB = " & toSQLValueS(mesB, True) &
                    ",MESDIF = " & toSQLValueS(Dif, True) &
                    " WHERE ID = '" & GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ID").ToString & "'"

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdGInvAdd_CheckedChanged(sender As Object, e As EventArgs) Handles cmdGInvAdd.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            GridView4.OptionsBehavior.Editable = False
            InvGas.AddNewGasInv(LayoutControlGroup6)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Enabled, LayoutControlGroup6)
            txtGInvCode.Text = DBQ.GetNextId("INV_GAS")
            cmdGInvSave.Enabled = True
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
        End If
    End Sub

    Private Sub cmdOInvEdit_CheckedChanged(sender As Object, e As EventArgs) Handles cmdOInvEdit.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            GridView3.OptionsBehavior.Editable = True
        Else
            GridView3.OptionsBehavior.Editable = False
        End If
    End Sub

    Private Sub RepositoryItemButtonGas_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonGas.ButtonClick
        GasFilesSelection(True)
        Dim sGID As String = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ID").ToString
        If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_GASF", sGID) = False Then
            XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RepositoryItemButtonOil_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonOil.ButtonClick
        OilFilesSelection(True)
        Dim sOID As String = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString
        If DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "INV_OILF", sOID) = False Then
            XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα στην αποθήκευση του επισυναπτόμενου αρχείου", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub cmdOInvAdd_CheckedChanged(sender As Object, e As EventArgs) Handles cmdOInvAdd.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked = True Then
            GridView3.OptionsBehavior.Editable = False
            InvOils.AddNewOilInv(LayoutControlGroup5)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Enabled, LayoutControlGroup5)
            txtOInvCode.Text = DBQ.GetNextId("INV_OIL")
            cmdOInvSave.Enabled = True
        Else
            Cls.ClearGroupCtrls(LayoutControlGroup5)
            Dim ExcludeControls As New List(Of String)
            ExcludeControls.Add(cmdOInvAdd.Name)
            ExcludeControls.Add(cmdOInvDelete.Name)
            ExcludeControls.Add(cmdOInvEdit.Name)
            ExcludeControls.Add(cmdOInvRefresh.Name)
            EnDisControls.EnableControlsGRP(EnableControls.EnableMode.Disabled, LayoutControlGroup5, ExcludeControls)
            cmdOInvSave.Enabled = False
        End If
    End Sub

    Private Sub grdOil_DoubleClick(sender As Object, e As EventArgs) Handles grdOil.DoubleClick
        If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "filename") Is DBNull.Value Then Exit Sub
        Dim fs As IO.FileStream = New IO.FileStream("D:\" & GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "filename"), IO.FileMode.Create)
        Dim b() As Byte = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "files")
        Try
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute("D:\" & GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "filename"))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub grdGas_DoubleClick(sender As Object, e As EventArgs) Handles grdGas.DoubleClick
        If GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "filename") Is DBNull.Value Then Exit Sub
        Dim fs As IO.FileStream = New IO.FileStream("D:\" & GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "filename"), IO.FileMode.Create)
        Dim b() As Byte = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "files")
        Try
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute("D:\" & GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "filename"))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()
            Dim itemSaveView As New DXEditMenuItem()

            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChangedINV_GAS, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex
                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItem("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChangedINV_GAS, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveViewINV_GAS, Nothing, Nothing, Nothing, Nothing))
            End If
        Else
            PopupMenuRows.ShowPopup(Control.MousePosition)
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
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView3.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()
            Dim itemSaveView As New DXEditMenuItem()

            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChangedINV_OIL, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex
                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItem("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChangedINV_OIL, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex

                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveViewINV_OIL, Nothing, Nothing, Nothing, Nothing))
            End If
        Else
            PopupMenuRows.ShowPopup(Control.MousePosition)
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
        LoadForms.LoadDataToGrid(grdAPM, GridView5, "SELECT * from vw_APMIL where bdgid = '" & sID & "' order by code")
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\APMIL_def.xml") Then GridView5.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\APMIL_def.xml", OptionsLayoutBase.FullLayout)
        ApmilFieldsToBeUpdate.Clear()
        For Each kvp As KeyValuePair(Of String, String) In Bmlc
            If kvp.Value = 0 Then
                GridView5.Columns(kvp.Key).Visible = False
                GridView5.Columns(kvp.Key).OptionsColumn.ReadOnly = True
                GridView5.Columns(kvp.Key).OptionsColumn.AllowEdit = False
            Else
                GridView5.Columns(kvp.Key).Visible = True
                GridView5.Columns(kvp.Key).OptionsColumn.ReadOnly = False
                GridView5.Columns(kvp.Key).OptionsColumn.AllowEdit = True
                ApmilFieldsToBeUpdate.Add(kvp.Key)
            End If
        Next
        GridView5.Columns("AptNam").OptionsColumn.ReadOnly = True
        GridView5.Columns("AptNam").OptionsColumn.AllowEdit = False
        ApmilFieldsToBeUpdate.Add("ΠΟΣΟΣΤΟ ΚΛΕΙΣΤΟΥ")
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