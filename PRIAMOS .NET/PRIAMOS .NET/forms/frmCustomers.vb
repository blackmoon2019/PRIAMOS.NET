Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmCustomers
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private LoadForms As New FormLoader
    Private Cls As New ClearControls
    Private CtrlCombo As DevExpress.XtraEditors.LookUpEdit
    Private CalledFromCtrl As Boolean
    Private UserPermissions As New CheckPermissions
    Private ManageCbo As New CombosManager

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

    Private Sub frmCustomers_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BANKS' table. You can move, or remove it, as needed.
        Me.Vw_BANKSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BANKS)
        Dim sSQL As New System.Text.StringBuilder
        'Νομοί
        FillCbo.COU(cboCOU)
        'FillCbo.ADR(cboADR, sSQL)
        'FillCbo.AREAS(cboAREAS, sSQL)
        FillCbo.DOY(cboDOY)
        AddHandler grdCCT_BANKS.EmbeddedNavigator.ButtonClick, AddressOf Grid_EmbeddedNavigator_ButtonClick

        Select Case Mode
            Case FormMode.NewRecord
                'dtDTS.EditValue = DateTime.Now
                txtCode.Text = DBQ.GetNextId("CCT")
                FillCbo.FillCheckedListPRF(chkPRF, FormMode.NewRecord)
            Case FormMode.EditRecord
                Me.Vw_CCT_BANKSTableAdapter.FillBycctID(Me.Priamos_NET_DataSet_BDG.vw_CCT_BANKS, System.Guid.Parse(sID))
                FillCbo.FillCheckedListPRF(chkPRF, FormMode.EditRecord, sID)
                If cboCOU.EditValue <> Nothing Then sSQL.AppendLine(" where couid = " & toSQLValueS(cboCOU.EditValue.ToString))
                FillCbo.AREAS(cboAREAS, sSQL)
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_CCT where id ='" + sID + "'")
                LoadForms.LoadDataToGrid(GridControl1, GridView1, "select ID,cctID,files,filename,comefrom,createdon,realname From vw_CCT_F where cctID = '" & sID & "'")
                Dim C As New GridColumn
                C.Name = "ICO"
                C.Caption = ""
                C.Visible = True
                Dim textEdit As New RepositoryItemTextEdit()
                textEdit.ContextImageOptions.Image = My.Resources.AddFile_16x16
                C.ColumnEdit = textEdit
                GridControl1.RepositoryItems.Add(textEdit)
                C.VisibleIndex = 0
                GridView1.Columns.Add(C)

        End Select
        LoadForms.RestoreLayoutFromXml(GridView1, "vw_CCT_F_def.xml")
        LoadForms.RestoreLayoutFromXml(GridView12, "CCT_BANKS.xml")
        Me.CenterToScreen()
        UserPermissions.GetUserPermissions(Me.Text)
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)

    End Sub
    Private Sub DeleteRecord()
        Dim sSQL As String
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM CCT_F WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadForms.LoadDataToGrid(GridControl1, GridView1, "select ID,cctID,filename,comefrom,createdon,realname From vw_CCT_F where cctID = '" & sID & "'")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub frmCustomers_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Dim sGuid As String
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "CCT", LayoutControl1,,, sGuid)
                        sID = sGuid
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "CCT", LayoutControl1,,, sID)
                        sGuid = sID
                End Select
                'Καθαρισμός Controls
                'If Mode = FormMode.EditRecord Then Cls.ClearCtrls(LayoutControl1)
                'dtDTS.EditValue = DateTime.Now
                If txtFileNames.Text <> "" Then
                    sResult = DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "CCT_F", sGuid)
                    LoadForms.LoadDataToGrid(GridControl1, GridView1, "select ID,cctID,files,filename,comefrom,createdon,realname From vw_CCT_F where cctID = '" & sGuid & "'")
                End If
                If Mode = FormMode.NewRecord Then txtCode.Text = DBQ.GetNextId("CCT")
                If CalledFromCtrl Then
                    FillCbo.CCT(CtrlCombo)
                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                Else
                    'Dim form As New frmScroller
                    'form.LoadRecords("vw_CCT")
                End If
                'Cls.ClearCtrls(LayoutControl1)
                'Όταν είναι σε EditMode διαγραφουμε όλες τις κατηγορίες και τις ξανακαταχωρούμε
                Dim sSQL2 As String
                If Mode = FormMode.EditRecord Then
                    sSQL2 = "DELETE FROM CCT_PF where CCTID = '" & sGuid & "'"
                    Using oCmd As New SqlCommand(sSQL2, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If

                ' Καταχώρηση Χιλιοστών πολυκατοικίας
                For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In chkPRF.CheckedItems
                    sSQL2 = "INSERT INTO CCT_PF ([CCTID],[prfID],[modifiedBy],[createdOn])  
                                        values (" & toSQLValueS(sGuid) & "," & toSQLValueS(item.Tag.ToString()) & "," &
                                                        toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                    Using oCmd As New SqlCommand(sSQL2, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                Next
                FillCbo.FillCheckedListPRF(chkPRF, FormMode.EditRecord, sGuid)
                If sResult = True Then
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                    Mode = FormMode.EditRecord
                    txtFileNames.Text = ""
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FilesSelection()

        'XtraOpenFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        XtraOpenFileDialog1.FilterIndex = 1
        XtraOpenFileDialog1.InitialDirectory = "C:\"
        XtraOpenFileDialog1.Title = "Open File"
        XtraOpenFileDialog1.CheckFileExists = False
        XtraOpenFileDialog1.Multiselect = True
        Dim result As DialogResult = XtraOpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            txtFileNames.EditValue = ""
            For I = 0 To XtraOpenFileDialog1.FileNames.Count - 1
                txtFileNames.EditValue = txtFileNames.EditValue & IIf(txtFileNames.EditValue <> "", ";", "") & XtraOpenFileDialog1.SafeFileNames(I)
            Next I


        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        Select Case e.KeyCode
            'Case Keys.F2 : If UserProps.AllowInsert = True Then NewRecord()
            'Case Keys.F3 : If UserProps.AllowEdit = True Then EditRecord()
            'Case Keys.F5 : LoadRecords()
            Case Keys.Delete : DeleteRecord() 'If UserProps.AllowDelete = True Then DeleteRecord()
        End Select

    End Sub


    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "filename") Is DBNull.Value Then Exit Sub
        Dim fs As IO.FileStream = New IO.FileStream("D:\" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "filename"), IO.FileMode.Create)
        Dim b() As Byte = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "files")
        Try
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute("D:\" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "filename"))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ShellExecute(ByVal File As String)
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = File
        myProcess.StartInfo.UseShellExecute = True
        myProcess.StartInfo.RedirectStandardOutput = False
        myProcess.Start()
        myProcess.Dispose()
    End Sub


    Private Sub cboDOY_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboDOY.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboDOY.EditValue = Nothing : ManageCbo.ManageDOY(cboDOY, FormMode.NewRecord)
            Case 2 : If cboDOY.EditValue <> Nothing Then ManageCbo.ManageDOY(cboDOY, FormMode.EditRecord)
            Case 3 : cboDOY.EditValue = Nothing
        End Select
    End Sub
    Private Sub cboCOU_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboCOU.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboCOU.EditValue = Nothing : ManageCbo.ManageCOU(cboCOU, FormMode.NewRecord)
            Case 2 : If cboCOU.EditValue <> Nothing Then ManageCbo.ManageCOU(cboCOU, FormMode.EditRecord)
            Case 3 : cboCOU.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboAREAS_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboAREAS.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboAREAS.EditValue = Nothing : ManageCbo.ManageAREAS(cboAREAS, FormMode.NewRecord)
            Case 2 : If cboAREAS.EditValue <> Nothing Then ManageCbo.ManageAREAS(cboAREAS, FormMode.EditRecord)
            Case 3 : cboAREAS.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboADR_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboADR.ButtonClick
        Select Case e.Button.Index
            Case 1 : cboADR.EditValue = Nothing : ManageCbo.ManageADR(cboADR, FormMode.NewRecord)
            Case 2 : If cboADR.EditValue <> Nothing Then ManageCbo.ManageADR(cboADR, FormMode.EditRecord)
            Case 3 : cboADR.EditValue = Nothing
        End Select
    End Sub


    Private Sub txtFileNames_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtFileNames.ButtonClick
        If e.Button.Index = 0 Then
            FilesSelection()
        Else
            txtFileNames.EditValue = Nothing
        End If
    End Sub

    Private Sub frmCustomers_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub GridView1_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView1, "vw_CCT_F_def.xml", "vw_CCT_F")
    End Sub
    Private Sub Grid_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Select Case e.Button.ButtonType
            Case e.Button.ButtonType.Remove
                If DeleteRecordCCT_BANKS() = vbYes Then e.Handled = False Else e.Handled = True
            Case e.Button.ButtonType.Append
                If sID = Nothing Then XtraMessageBox.Show("Πρέπει πρώτα να καταχωρηθεί πελάτης", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : e.Handled = True
        End Select
    End Sub
    Private Function DeleteRecordCCT_BANKS() As MsgBoxResult
        If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "ID") = Nothing Then Return vbCancel
        If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim sSQL As String = "DELETE FROM CCT_BANKS WHERE ID = '" & GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "ID").ToString & "'"
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Me.Vw_CCT_BANKSTableAdapter.FillBycctID(Me.Priamos_NET_DataSet_BDG.vw_CCT_BANKS, System.Guid.Parse(sID))
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
            If e.RowHandle = grdCCT_BANKS.NewItemRowHandle Then
                If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "bankID").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε τράπεζα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "Iban").ToString = "" And GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AccountNumber").ToString = "" Then
                    e.ErrorText = "Δεν έχετε συμπληρώσει λογαριασμό"
                    e.Valid = False
                    Exit Sub
                End If
                Dim sGuid As String = Guid.NewGuid.ToString
                GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "ID", sGuid)
                GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "cctID", sID)
                GridView12.SetRowCellValue(GridView12.FocusedRowHandle, "createdBy", UserProps.ID.ToString)

                sSQL.AppendLine("INSERT INTO CCT_BANKS (ID,cctID,bankID,Iban,AccountNumber,AccountHolder,BicNumber,createdBy,MachineName)")
                sSQL.AppendLine("Select " & toSQLValueS(sGuid) & ",")
                sSQL.AppendLine(toSQLValueS(sID) & ",")
                sSQL.AppendLine(toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "bankID").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "Iban").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AccountNumber").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AccountHolder").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "BicNumber").ToString) & ",")
                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString) & ",")
                sSQL.AppendLine(toSQLValueS(UserProps.MachineName))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Else
                If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "bankID").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε τράπεζα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "Iban").ToString = "" And GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AccountNumber").ToString = "" Then
                    e.ErrorText = "Δεν έχετε συμπληρώσει λογαριασμό"
                    e.Valid = False
                    Exit Sub
                End If
                sSQL.AppendLine("UPDATE CCT_BANKS SET  ")
                sSQL.AppendLine("bankID = " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "bankID").ToString) & ",")
                sSQL.AppendLine("Iban = " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "Iban").ToString) & ",")
                sSQL.AppendLine("AccountNumber = " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AccountNumber").ToString) & ",")
                sSQL.AppendLine("AccountHolder= " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "AccountHolder").ToString) & ",")
                sSQL.AppendLine("BicNumber = " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "BicNumber").ToString) & ",")
                sSQL.AppendLine("modifiedBy = " & toSQLValueS(UserProps.ID.ToString) & ",")
                sSQL.AppendLine("MachineName = " & toSQLValueS(UserProps.MachineName))
                sSQL.Append("WHERE ID = " & toSQLValueS(GridView12.GetRowCellValue(GridView12.FocusedRowHandle, "ID").ToString))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            End If
        Catch sqlEx As SqlException When sqlEx.Number = 2601

            e.Valid = False
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView12_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView12.KeyDown
        If e.KeyCode = Keys.Delete And UserProps.AllowDelete = True Then DeleteRecordCCT_BANKS()
        If e.KeyCode = Keys.Down And UserProps.AllowInsert Then
            If sender.FocusedRowHandle < 0 Then Exit Sub
            Dim viewInfo As GridViewInfo = TryCast(sender.GetViewInfo(), GridViewInfo)
            If sender.FocusedRowHandle = viewInfo.RowsInfo.Last().RowHandle Then

            End If
        End If
    End Sub
    Private Sub GridView12_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView12.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView12, "CCT_BANKS.xml", "vw_CCT_BANKS")
    End Sub

End Class
