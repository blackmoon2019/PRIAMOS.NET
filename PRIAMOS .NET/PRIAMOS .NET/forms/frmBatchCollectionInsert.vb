Imports System.Data.SqlClient
Imports DevExpress.Utils.VisualEffects
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Localization
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmBatchCollectionInsert
    Sub New()

        GridLocalizer.Active = New GridGreekLocalizer()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmBatchCollectionInsert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_BDG)
        AddHandler grdCollections.EmbeddedNavigator.ButtonClick, AddressOf Grid_EmbeddedNavigator_ButtonClick
        DevExpress.XtraGrid.Localization.GridLocalizer.Active = New GridGreekLocalizer()
    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue <> Nothing Then
            Me.Vw_APTTableAdapter.FillByBDG(Me.Priamos_NET_DataSet_BDG.vw_APT, System.Guid.Parse(cboBDG.EditValue.ToString))
            Me.TmpBatchCollectionsTableAdapter.FillByBDG(Me.Priamos_NETDataSet2.tmpBatchCollections, System.Guid.Parse(cboBDG.EditValue.ToString))
        End If
    End Sub
    Private Sub GridView1_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles GridView1.InvalidRowException
        ' e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub
    Private Sub Grid_EmbeddedNavigator_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Select Case e.Button.ButtonType
            Case e.Button.ButtonType.Remove : If DeleteRecord() = vbYes Then e.Handled = False Else e.Handled = True
            Case e.Button.ButtonType.Append
                If cboBDG.EditValue = Nothing Then
                    XtraMessageBox.Show("Δεν έχετε επιλέξει πολυκατοικία.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Handled = True
                End If
            Case e.Button.ButtonType.EndEdit : cboBDG.Enabled = True
        End Select
    End Sub
    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Delete And UserProps.AllowDelete = True Then DeleteRecord()
        If e.KeyCode = Keys.Down And UserProps.AllowInsert Then
            If sender.FocusedRowHandle < 0 Then Exit Sub
            Dim viewInfo As GridViewInfo = TryCast(sender.GetViewInfo(), GridViewInfo)
            If sender.FocusedRowHandle = viewInfo.RowsInfo.Last().RowHandle Then
                If cboBDG.EditValue = Nothing Then
                    XtraMessageBox.Show("Δεν έχετε επιλέξει πολυκατοικία.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                GridView1.PostEditor() : GridView1.AddNewRow()
            End If
        End If
    End Sub
    Private Function DeleteRecord() As MsgBoxResult
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "aptID") = Nothing Then Return vbCancel
        If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim sSQL As String = "DELETE FROM tmpBatchCollections WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Return vbYes
        Else
            Return vbNo
        End If
    End Function
    Private Sub GridView1_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        Dim sSQL As New System.Text.StringBuilder
        Dim sDate As String
        Try
            sSQL.Clear()
            If e.RowHandle = grdCollections.NewItemRowHandle Then
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "aptID").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε διαμέρισμα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε Από Μήνα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString = "" Then
                    e.ErrorText = "Παρακαλώ επιλεξτε Έως Μήνα"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ownerAmt").ToString = "" Then
                    e.ErrorText = "Παρακαλώ πληκτρολογείστε ποσό"
                    e.Valid = False
                    Exit Sub
                End If
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tenantAmt").ToString = "" Then
                    e.ErrorText = "Παρακαλώ πληκτρολογείστε ποσό"
                    e.Valid = False
                    Exit Sub
                End If
                If CheckIfDateIsValid() = False Then
                    e.ErrorText = "Δεν μπορεί η ""ΑΠΟ"" ημερομηνία να είναι μεγαλύτερη από την ""ΕΩΣ"""
                    e.Valid = False
                    Exit Sub
                End If
                Dim sGuid As String = Guid.NewGuid.ToString
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "ID", sGuid)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "bdgID", cboBDG.EditValue.ToString)

                sSQL.AppendLine("INSERT INTO tmpBatchCollections (ID,bdgID,aptID,fDate,tDate,ownerAmt,tenantAmt)")
                sSQL.AppendLine("Select " & toSQLValueS(sGuid) & ",")
                sSQL.AppendLine(toSQLValueS(cboBDG.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "aptID").ToString) & ",")
                sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString
                If sDate <> "" Then sDate = toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) Else sDate = "NULL"
                sSQL.AppendLine(sDate & ",")
                sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString
                If sDate <> "" Then sDate = toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) Else sDate = "NULL"
                sSQL.AppendLine(sDate & ",")
                sSQL.AppendLine(toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ownerAmt").ToString, True) & ",")
                sSQL.AppendLine(toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tenantAmt").ToString, True))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Else
                If CheckIfDateIsValid() = False Then
                    e.ErrorText = "Δεν μπορεί η ""ΑΠΟ"" ημερομηνία να είναι μεγαλύτερη από την ""ΕΩΣ"""
                    e.Valid = False
                    Exit Sub
                End If

                sSQL.AppendLine("UPDATE tmpBatchCollections	SET bdgID= " & toSQLValueS(cboBDG.EditValue.ToString) & ",")
                sSQL.AppendLine("aptID = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "aptID").ToString) & ",")
                sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString
                If sDate <> "" Then sDate = toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) Else sDate = "NULL"
                sSQL.AppendLine("fDate = " & sDate & ",")
                sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString
                If sDate <> "" Then sDate = toSQLValueS(CDate(sDate).ToString("yyyyMMdd")) Else sDate = "NULL"
                sSQL.AppendLine("tDate = " & sDate & ",")
                sSQL.AppendLine("ownerAmt = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ownerAmt").ToString, True) & ",")
                sSQL.AppendLine("tenantAmt = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tenantAmt").ToString, True))
                sSQL.Append("WHERE ID = " & toSQLValueS(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function CheckIfDateIsValid() As Boolean
        Dim sDate As String
        sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "fDate").ToString
        Dim date1 As Date = Date.Parse(sDate)
        sDate = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "tDate").ToString
        Dim date2 As Date = Date.Parse(sDate)
        Dim LastDayInMonthDate As Date = New Date(date2.Year, date2.Month, Date.DaysInMonth(date2.Year, date2.Month))

        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "tDate", LastDayInMonthDate)
        If DateDiff(DateInterval.Month, date1, date2) < 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    Private Sub CreateColInh()
        Dim sSQL As New System.Text.StringBuilder
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
        Dim I As Integer
        Dim sINHID As String
        Dim sINDID As String
        Dim sCOLID As String
        Try
            If selectedRowHandles.Length = 0 Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να καταχωρηθούν οι τρέχουσες εγγραφές?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
            LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            ProgressBarControl1.EditValue = 0
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Maximum = selectedRowHandles.Length - 1
            ProgressBarControl1.Properties.Minimum = 0


            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                sINHID = System.Guid.NewGuid.ToString
                sCOLID = System.Guid.NewGuid.ToString
                sINDID = System.Guid.NewGuid.ToString

                'Καταχώρηση Παραστατικού
                sSQL.AppendLine("INSERT INTO INH (id,bdgID,CMT,FDATE,TDATE,TotalInh,extraordinary,createdOn,modifiedBY,completeDate,reserveAPT)")
                sSQL.AppendLine("select " & toSQLValueS(sINHID) & ",")
                sSQL.AppendLine(toSQLValueS(cboBDG.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValueS("Παραστατικό εκ μεταφοράς από πρώην διαχειριστη") & ",")
                sSQL.AppendLine("GETDATE(),GETDATE(),")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine("0,GETDATE(),")
                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString) & ",")
                sSQL.AppendLine("dbo.ConvertMonthToGR(GETDATE()) + ' ' + cast( year(getdate()) as nvarchar(4)) + ' -  Έναντι',1")
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                'Καταχώρηση Πάγιου εξόδου
                sSQL.Clear()
                sSQL.AppendLine("INSERT INTO IND (id,inhID, calcCatID, repName, amt, owner_tenant)")
                sSQL.AppendLine("select " & toSQLValueS(sINDID) & "," & toSQLValueS(sINHID) & ",'3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE',")
                sSQL.AppendLine(toSQLValue(txtComments) & ",")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine(toSQLValueS(cboOwnerTenant.SelectedIndex))
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                'Καταχώρηση Υπολογισμένης εγγραφής
                sSQL.Clear()
                sSQL.AppendLine("INSERT INTO INC (ID,inhID,indID,bdgID,aptID, monomers1,tot_monomers1,createdby)")
                sSQL.AppendLine("select newid()," & toSQLValueS(sINHID) & "," & toSQLValueS(sINDID) & "," & toSQLValueS(sBdgID) & ",")
                sSQL.AppendLine(toSQLValueS(cboApt.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString))
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using

                'Καταχώρηση Είσπραξης
                sSQL.Clear()
                sSQL.AppendLine("INSERT INTO COL (ID,bdgID,aptID,INHID,debitusrID,debit,CREDIT,BAL,dtdebit,cmt,ColMethodID,createdOn,completed,tenant,reserveAPT,modifiedBY)")
                sSQL.AppendLine("select " & toSQLValueS(sCOLID) & ",")
                sSQL.AppendLine(toSQLValueS(sBdgID) & ",")
                sSQL.AppendLine(toSQLValueS(cboApt.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValueS(sINHID) & ",")
                sSQL.AppendLine(toSQLValueS(cboDebitUsr.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine("0,")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine("GETDATE(),")
                sSQL.AppendLine(toSQLValue(txtComments) & ",")
                sSQL.AppendLine(toSQLValueS(cboColMethodID.EditValue.ToString) & ",")
                sSQL.AppendLine("GETDATE(),0,")
                sSQL.AppendLine(toSQLValueS(cboOwnerTenant.SelectedIndex) & ",1,")
                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                'Καταχώρηση Προοδευτικής Χρέωσης
                sSQL.Clear()
                sSQL.AppendLine("INSERT INTO COL_P (BDGID,APTID,INHID,debit,tenant)")
                sSQL.AppendLine("select ")
                sSQL.AppendLine(toSQLValueS(sBdgID) & ",")
                sSQL.AppendLine(toSQLValueS(cboApt.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValueS(sINHID) & ",")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine("1")
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using

                'Ενημέρωση Υπολοίπου διαμερίσματος
                sSQL.Clear()
                sSQL.AppendLine("UPDATE APT set bal_adm = bal_adm + " & toSQLValue(txtDebit, True) & "*(-1) WHERE ID = " & toSQLValueS(cboApt.EditValue.ToString))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using


            Next I

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Try
    End Sub

End Class