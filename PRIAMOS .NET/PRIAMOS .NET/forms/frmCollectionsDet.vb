Imports System.Collections.Specialized
Imports System.Data.SqlClient
Imports System.Text
Imports DevExpress.CodeParser
Imports DevExpress.Data
Imports DevExpress.DataAccess
Imports DevExpress.Utils
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmCollectionsDet
    Private sID As String, sbdgID As String, saptID As String, sinhID As String, sColBanksID As String
    Private sTenant As Boolean, sCheckForTenant As Boolean = False
    Private sCalledFromCollBanks As Boolean = False
    Private sCalledForNegatives As Boolean = False
    Private sGetCompletedCols As Boolean = False
    Private sDeposit As Decimal = 0
    Dim TotBal As Decimal
    Dim TotCredit As Decimal
    Private sInhIDS2 As New Dictionary(Of String, String)
    Private sInhIDSSelected As New Dictionary(Of String, String)
    Private LoadForms As New FormLoader
    Private UserPermissions As New CheckPermissions
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property

    Public WriteOnly Property BDGID As String
        Set(value As String)
            sbdgID = value
        End Set
    End Property
    Public WriteOnly Property APTID As String
        Set(value As String)
            saptID = value
        End Set
    End Property

    Public WriteOnly Property INHID As String
        Set(value As String)
            sinhID = value
        End Set
    End Property
    Public WriteOnly Property ColBanksID As String
        Set(value As String)
            sColBanksID = value
        End Set
    End Property
    Public WriteOnly Property TENANT As Boolean
        Set(value As Boolean)
            sTenant = value
        End Set
    End Property

    Public WriteOnly Property CheckForTenant As Boolean
        Set(value As Boolean)
            sCheckForTenant = value
        End Set
    End Property
    Public WriteOnly Property GetCompletedCols As Boolean
        Set(value As Boolean)
            sGetCompletedCols = value
        End Set
    End Property
    Public WriteOnly Property CalledForNegatives As Boolean
        Set(value As Boolean)
            sCalledForNegatives = value
        End Set
    End Property
    Public WriteOnly Property CalledFromCollBanks As Boolean
        Set(value As Boolean)
            sCalledFromCollBanks = value
        End Set
    End Property

    Public WriteOnly Property Deposit As Decimal
        Set(value As Decimal)
            sDeposit = value
        End Set
    End Property

    Public ReadOnly Property inhIDS2() As Dictionary(Of String, String)
        Get
            Return sInhIDS2
        End Get
    End Property

    Private Sub cmdSaveSelected_Click(sender As Object, e As EventArgs) Handles cmdSaveSelected.Click

        'Dim TotDebit As Decimal
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length - 1 = -1 Then XtraMessageBox.Show("Δεν έχετε επιλέξει κάποια εγγραφή", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        sInhIDS2.Clear()
        For I = 0 To selectedRowHandles.Length - 1
            Dim selectedRowHandle As Int32 = selectedRowHandles(I)
            If GridView1.GetRowCellValue(selectedRowHandle, "inhID").ToString <> "" Then
                sInhIDS2.Add(Guid.NewGuid.ToString, GridView1.GetRowCellValue(selectedRowHandle, "tenant").ToString & "," & GridView1.GetRowCellValue(selectedRowHandle, "inhID").ToString & "," & GridView1.GetRowCellValue(selectedRowHandle, "credit").ToString.Replace(",", "."))
                '    TotDebit = TotDebit + GridView1.GetRowCellValue(selectedRowHandle, "debit")
            End If
        Next
        If sDeposit > TotCredit Then
            XtraMessageBox.Show("Το σύνολο των επιλεγμένων παραστατικών πρέπει να είναι είναι μεγαλύτερο ή ίσο της κατάθεσης", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub


    Private Sub frmCollectionsDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If sCalledForNegatives = True Then
            COL_PER_BDG_APTTableAdapter.FillForNegatives(Me.Priamos_NETDataSet3.COL_PER_BDG_APT, System.Guid.Parse(sbdgID), System.Guid.Parse(saptID))
            GridControl1.DataSource = COLPERBDGAPTBindingSource
            GridControl1.ForceInitialize()
            GridControl1.DefaultView.PopulateColumns()
            LoadForms.RestoreLayoutFromXml(GridView1, "COL_FOR_NEGATIVES_def.xml")
            lblDeposit.Text = "Ποσό Κατάθεσης : " & sDeposit
            LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Exit Sub
        End If
        If sCalledFromCollBanks = True Then
            If sGetCompletedCols = False Then
                COL_PER_BDG_APTTableAdapter.FillDifferentBal(Me.Priamos_NETDataSet3.COL_PER_BDG_APT, System.Guid.Parse(sbdgID), System.Guid.Parse(saptID))
                GridControl1.DataSource = COLPERBDGAPTBindingSource
                GridControl1.ForceInitialize()
                GridControl1.DefaultView.PopulateColumns()
                LoadForms.RestoreLayoutFromXml(GridView1, "COL_BANKS_DET_def.xml")
                'GridView1.Columns.Item("bal").SummaryItem.SummaryType = SummaryItemType.Custom
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                TotBal = 0 : TotCredit = 0
                GridView1.UpdateTotalSummary()
            Else
                COLBanksCompletedTableAdapter.Fill(Me.Priamos_NETDataSet3.COLBanksCompleted, System.Guid.Parse(sColBanksID))
                GridControl1.DataSource = COLBanksCompletedBindingSource
                GridControl1.ForceInitialize()
                GridControl1.DefaultView.PopulateColumns()
                LoadForms.RestoreLayoutFromXml(GridView1, "COL_BANKS_DET_COMPLETED_def.xml")
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
            GridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.False
            LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            lblDeposit.Text = "Ποσό Κατάθεσης : " & sDeposit
            Exit Sub
        End If
        'Default Άνοιγμα
        UserPermissions.GetUserPermissions(Me.Text) : If UserProps.AllowDelete = False Then cmdCol_D_Del.Enabled = False
        If sinhID <> "" And sCheckForTenant = True Then
            Me.Vw_COL_DTableAdapter.FillByInhIDAndTenant(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sinhID), sTenant, System.Guid.Parse(saptID))
        ElseIf sinhID <> "" Then
            Me.Vw_COL_DTableAdapter.FillByInhID(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sinhID), System.Guid.Parse(saptID))
        Else
            Me.Vw_COL_DTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sbdgID), System.Guid.Parse(saptID))
        End If
        GridControl1.DataSource = VwCOLDBindingSource
        GridControl1.ForceInitialize()
        GridControl1.DefaultView.PopulateColumns()
        LoadForms.RestoreLayoutFromXml(GridView1, "COL_D_def.xml")
        cmdCol_D_Del.Enabled = UserProps.AllowDelete
        LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

    End Sub

    Private Sub cmdCol_D_Del_Click(sender As Object, e As EventArgs) Handles cmdCol_D_Del.Click
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
        Dim I As Integer
        Dim sSQL As String
        Dim AptBal As Decimal, Credit As Decimal
        Try
            If selectedRowHandles.Length - 1 = -1 Then XtraMessageBox.Show("Δεν έχετε επιλέξει κάποια εγγραφή για διαγραφή", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφούν οι επιλεγμένες εγγραφές?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)

                If GridView1.GetRowCellValue(selectedRowHandle, "ID") = Nothing Then Exit Sub
                If GridView1.GetRowCellValue(selectedRowHandle, "agreed") = 0 Then
                    sSQL = "DELETE FROM COL_D WHERE ID = " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using
                    'AptBal = AptBal + GridView1.GetRowCellValue(selectedRowHandle, "debit")
                    If GridView1.GetRowCellValue(selectedRowHandle, "inhID").ToString <> "" Then Credit = GridView1.GetRowCellValue(selectedRowHandle, "Credit") Else Credit = 0
                    ' Από την στιγμή που διαγράφω κινήσεις είσπραξης θα πρέπει να γίνει Ενημέρωση της είσπραξης
                    sSQL = "UPDATE COL SET completed=0,bal=bal + " & toSQLValueS(Credit.ToString, True) &
                            " where id = " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "colID").ToString)

                    Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using

                    sSQL = "UPDATE COL_P SET debit=isnull(debit,0) + " & toSQLValueS(Credit.ToString, True) &
                           " where bdgid = " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "bdgID").ToString) &
                           "and aptID= " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "aptID").ToString) &
                           "and inhID= " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "inhID").ToString) &
                           "and tenant= " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "tenant").ToString)
                    Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using

                Else
                    XtraMessageBox.Show("Δεν μπορείτε να διαγράψετε πίστωση που έχει συμφωνηθεί." & vbCrLf &
                    "Για να κάνετε διαγραφή θα πρέπει πρώτα να την ενημερώσετε ως 'ΜΗ ΣΥΜΦΩΝΙΑ ΠΙΣΤΩΣΗΣ'", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Next
            ' Από την στιγμή που διαγράφω κινήσεις είσπραξης θα πρέπει να γίνει Ενημέρωση υπολοίπου διαμερίσματος
            ' Ενημέρωση υπολοίπου διαμερίσματος
            'sSQL = "Update apt set apt.bal_adm = (select isnull(sum(col.bal),0) from col where completed=0 And aptID = " & toSQLValueS(saptID) & ") where id = " & toSQLValueS(saptID)
            'Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using

            ' Από την στιγμή που διαγράφω κινήσεις είσπραξης θα πρέπει να γίνει Ενημέρωση υπολοίπου διαμερίσματος
            'sSQL = "UPDATE APT SET BAL=BAL + " & toSQLValueS(AptBal, True) & " where id = " & toSQLValueS(saptID)
            'Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using
            frmCollections.LoaderData(sbdgID)
            If sinhID <> "" And sCheckForTenant = True Then
                Me.Vw_COL_DTableAdapter.FillByInhIDAndTenant(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sinhID), sTenant, System.Guid.Parse(saptID))
            ElseIf sinhID <> "" Then
                Me.Vw_COL_DTableAdapter.FillByInhID(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sinhID), System.Guid.Parse(saptID))
            Else
                Me.Vw_COL_DTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sbdgID), System.Guid.Parse(saptID))
            End If
            XtraMessageBox.Show("Η εγγραφές διαγράφηκαν με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                UserPermissions.GetUserPermissions(Me.Text) : If UserProps.AllowDelete = True Then cmdCol_D_Del.PerformClick()
        End Select
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            If sCalledFromCollBanks = True Then
                If sGetCompletedCols = False Then
                    LoadForms.PopupMenuShow(e, GridView1, "COL_BANKS_DET_def.xml")
                Else
                    LoadForms.PopupMenuShow(e, GridView1, "COL_BANKS_DET_COMPLETED_def.xml")
                End If
                Exit Sub
            End If
            If sCalledForNegatives = True Then
                LoadForms.PopupMenuShow(e, GridView1, "COL_FOR_NEGATIVES_def.xml")
                Exit Sub
            End If
            'Default
            LoadForms.PopupMenuShow(e, GridView1, "COL_D_def.xml")
        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        sInhIDS2.Clear() : Me.Close()
    End Sub

    Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        If e.Item.fieldname = "bal" Then
            e.TotalValue = TotBal
        ElseIf e.Item.fieldname = "credit" Then
            e.TotalValue = TotCredit
        End If
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanging

    End Sub

    Private Sub GridView1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        If Me.IsActive = False Then Exit Sub
        If e.Action = System.ComponentModel.CollectionChangeAction.Add Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "credit") = 0 Then
                XtraMessageBox.Show("Δεν μπορείτε να επιλέξετε παραστατικό με μηδέν ποσό είσπραξης", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If sInhIDSSelected.ContainsKey(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "inhID").ToString) = False Then
                sInhIDSSelected.Add(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "inhID").ToString, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bal"))
                TotBal = TotBal + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bal")
            End If
            TotCredit = TotCredit + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "credit")
        Else
            If sInhIDSSelected.ContainsKey(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "inhID").ToString) = True Then
                sInhIDSSelected.Remove(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "inhID").ToString)
                TotBal = TotBal - GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bal")
            End If
            TotCredit = TotCredit - GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "credit")
        End If
        GridView1.UpdateTotalSummary()
    End Sub

    Private Sub frmCollectionsDet_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        sInhIDSSelected.Clear()
    End Sub

    Private Sub Rep_Credit_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles Rep_Credit.ButtonPressed
        Select Case e.Button.Index
            Case 0
                UserPermissions.GetUserPermissions(Me.Text)
                If UserProps.AllowEdit = False Then
                    XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "credit", 0)
                    Exit Sub
                End If
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "credit", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bal")) : GridView1.ValidateEditor()
            Case 1 : GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "credit", 0)

        End Select
    End Sub

    Private Sub GridView1_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Try
            '**********************************************************************************
            ' Ο παρακάτω κώδικας ισχύει για τις περιπτώσεις που υπάρχουν αρνητικά παραστατικά *
            '**********************************************************************************
            Dim credit As Decimal, debit As Decimal, bal As Decimal

            If sCalledFromCollBanks = True Then
                If sender.FocusedColumn.FieldName = "credit" Then
                    If e.Value < 0 Then
                        e.ErrorText = "Δεν επιτρέπονται αρνητικοί αριθμοί. "
                        e.Valid = False
                        Exit Sub
                    End If
                    If sender.GetRowCellValue(sender.FocusedRowHandle, "debit") Is DBNull.Value Then
                        debit = 0
                    Else
                        debit = sender.GetRowCellValue(sender.FocusedRowHandle, "debit")
                    End If

                    credit = e.Value
                    If credit > debit Then
                        e.ErrorText = "Δεν μπορεί η πίστωση να είναι μεγαλύτερη από την χρέωση σε ενα παραστατικό. Το μέγιστο επιτρεπόμενο ποσό είναι : " & bal & "€"
                        e.Valid = False
                        Exit Sub
                    End If
                    If credit = 0 Then
                        e.Valid = False
                        e.ErrorText = "Δεν μπορεί η είσπραξη να είναι μηδενική."
                        Exit Sub
                    End If
                    If sender.GetRowCellValue(sender.FocusedRowHandle, "bal") Is DBNull.Value Then
                        bal = 0
                    Else
                        bal = sender.GetRowCellValue(sender.FocusedRowHandle, "bal")
                    End If
                    If credit > bal Then
                        e.ErrorText = "Η πίστωση δεν μπορεί να ξεπερνάει το ποσό των: " & bal & "€"
                        e.Valid = False
                        Exit Sub
                    End If
                End If
                Exit Sub
            End If

            If sCalledForNegatives = True Then

                UserPermissions.GetUserPermissions(Me.Text) : If UserProps.AllowEdit = False Then XtraMessageBox.Show("Δεν έχουν οριστεί τα απαραίτητα δικαιώματα στον χρήστη", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                Dim sSQL As String, dtcredit As String
                Dim debitusrID As String
                If sender.FocusedColumn.FieldName = "debit" Then Exit Sub
                If sender.GetRowCellValue(sender.FocusedRowHandle, "debitusrID").ToString().ToUpper = "26521B58-5590-4880-A31E-4E91A6CF964D" Then
                    e.ErrorText = "Ο System User δεν έχει δικαίωμα είσπραξης. "
                    sender.SetRowCellValue(sender.FocusedRowHandle, "credit", 0)
                    e.Valid = False
                    Exit Sub
                End If

                If sender.FocusedColumn.FieldName = "credit" And IsDebitUserUnique(sender, debitusrID) = False Then
                    'XtraMessageBox.Show("Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.ErrorText = "Υπάρχουν διαφορετικοί Χρήστες Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                    e.Valid = False
                    Exit Sub
                ElseIf sender.FocusedColumn.FieldName = "credit" And IsDebitUserEmpty(sender) = True Then
                    'XtraMessageBox.Show("Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. ", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.ErrorText = "Δεν υπάρχει κανένας Χρήστης Χρέωσης στα παραστατικά. Δεν μπορείτε να αλλάξετε την πίστωση στο διαμέρισμα. "
                    sender.SetRowCellValue(sender.FocusedRowHandle, "credit", 0)
                    e.Valid = False
                    Exit Sub
                ElseIf sender.FocusedColumn.FieldName = "credit" Then
                    If e.Value < 0 Then
                        e.ErrorText = "Δεν επιτρέπονται αρνητικοί αριθμοί. "
                        e.Valid = False
                        Exit Sub
                    End If
                    If sender.GetRowCellValue(sender.FocusedRowHandle, "debit") Is DBNull.Value Then
                        debit = 0
                    Else
                        debit = sender.GetRowCellValue(sender.FocusedRowHandle, "debit")
                    End If

                    credit = e.Value
                    If credit > debit Then
                        e.ErrorText = "Δεν μπορεί η πίστωση να είναι μεγαλύτερη από την χρέωση σε ενα παραστατικό."
                        e.Valid = False
                        Exit Sub
                    End If
                    If credit = 0 Then
                        e.Valid = False
                        e.ErrorText = "Δεν μπορεί η είσπραξη να είναι μηδενική."
                        Exit Sub
                    End If
                    If sender.GetRowCellValue(sender.FocusedRowHandle, "bal") Is DBNull.Value Then
                        bal = 0
                    Else
                        bal = sender.GetRowCellValue(sender.FocusedRowHandle, "bal")
                    End If
                    If credit > sDeposit * (-1) Then
                        e.ErrorText = "Η πίστωση δεν μπορεί να ξεπερνάει το ποσό των: " & sDeposit * -1 & "€"
                        e.Valid = False
                        Exit Sub
                    End If
                    If credit > bal Then
                        e.ErrorText = "Η πίστωση δεν μπορεί να ξεπερνάει το ποσό των: " & bal & "€"
                        e.Valid = False
                        Exit Sub
                    End If
                End If


                If debit = 0 And credit = 0 Then Exit Sub

                If sender.FocusedColumn.FieldName = "credit" Then 'Or sender.FocusedColumn.FieldName = "ColMethodID" Or sender.FocusedColumn.FieldName = "bankID" 
                    If sender.GetRowCellValue(sender.FocusedRowHandle, "debit") Is DBNull.Value Then
                        debit = 0
                    Else
                        debit = sender.GetRowCellValue(sender.FocusedRowHandle, "debit")
                    End If
                    If sender.FocusedColumn.FieldName = "credit" Then
                        credit = e.Value
                    Else
                        If sender.GetRowCellValue(sender.FocusedRowHandle, "credit") Is DBNull.Value Then
                            credit = 0
                        Else
                            credit = sender.GetRowCellValue(sender.FocusedRowHandle, "credit")
                        End If

                    End If
                    If sender.GetRowCellValue(sender.FocusedRowHandle, "bal") Is DBNull.Value Then
                        bal = 0
                    Else
                        bal = sender.GetRowCellValue(sender.FocusedRowHandle, "bal")
                    End If
                    bal = Math.Abs(bal) - credit
                    dtcredit = toSQLValueS(Date.Now.ToString("yyyyMMdd"))

                    Dim sNegInhID As String, sNegBdgID As String, sNegAptID As String, sdebitusrID As String, sNegTenant As Boolean
                    sNegBdgID = sender.GetRowCellValue(sender.FocusedRowHandle, "bdgID").ToString.ToUpper
                    sNegInhID = sender.GetRowCellValue(sender.FocusedRowHandle, "inhID").ToString.ToUpper
                    sNegAptID = sender.GetRowCellValue(sender.FocusedRowHandle, "aptID").ToString.ToUpper
                    sdebitusrID = sender.GetRowCellValue(sender.FocusedRowHandle, "debitusrID").ToString.ToUpper
                    sNegTenant = IIf(sender.GetRowCellValue(sender.FocusedRowHandle, "tenant") = False, 0, 1)
                    sender.SetRowCellValue(sender.FocusedRowHandle, "bal", bal)
                    ' Υπολογισμός Είσπραξης
                    If ColCalculate(credit, sNegInhID, sNegBdgID, sNegAptID, sdebitusrID, sNegTenant, 0) Then
                        ColCalculate(credit * -1, sinhID, sbdgID, saptID, sdebitusrID, sTenant, 3)
                        ' Ενημέρωση αρνητικού Παραστατικου 
                        COL_PER_BDG_APTTableAdapter.FillForNegatives(Me.Priamos_NETDataSet3.COL_PER_BDG_APT, System.Guid.Parse(sbdgID), System.Guid.Parse(saptID))
                        sDeposit = sDeposit + credit : lblDeposit.Text = "Ποσό Κατάθεσης : " & sDeposit
                    End If
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function ColCalculate(ByVal credit As Decimal,
                                  ByVal sNegInhID As String, ByVal sNegBdgID As String, ByVal sNegAptID As String,
                                  ByVal debitusrID As String, ByVal tenant As Boolean, ByVal ComeFrom As Integer) As Boolean
        Try


            Using oCmd As New SqlCommand("col_Calculate", CNDB)
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.AddWithValue("@debitusrID", debitusrID)
                oCmd.Parameters.AddWithValue("@bdgID", sNegBdgID)
                oCmd.Parameters.AddWithValue("@aptID", sNegAptID)
                oCmd.Parameters.AddWithValue("@inhID", sNegInhID)
                oCmd.Parameters.AddWithValue("@Givencredit", credit)
                oCmd.Parameters.AddWithValue("@modifiedBy", UserProps.ID.ToString.ToUpper)
                oCmd.Parameters.AddWithValue("@ComeFrom", ComeFrom)
                oCmd.Parameters.AddWithValue("@ColMethodID", "75E3251D-077D-42B0-B79A-9F2886381A97") ' ΜΕΤΡΗΤΑ
                oCmd.Parameters.AddWithValue("@TenantOwner", tenant)
                oCmd.Parameters.AddWithValue("@Agreed", 0)
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function UpdateNegativeInvoice(ByVal credit As Decimal, ByVal sInhID As String, ByVal sAptID As String) As Boolean
        Try
            Dim sSQL As String
            sSQL = "UPDATE COL SET credit= " & toSQLValueS(credit, True) & " ,bal=bal + " & toSQLValueS(credit.ToString, True) & " where inhid = " & toSQLValueS(sInhID) & " and aptID = " & toSQLValueS(sAptID)
            sDeposit = sDeposit + credit
            lblDeposit.Text = "Ποσό Κατάθεσης : " & sDeposit
            Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using
            sSQL = "UPDATE COL SET credit= " & toSQLValueS(credit, True) & " ,bal=bal + " & toSQLValueS(credit.ToString, True) & " where inhid = " & toSQLValueS(sInhID) & " and aptID = " & toSQLValueS(sAptID)
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    'Function που ελέγχει αν ο χρήστης χρέωσης στα παραστατικά είναι μοναδικός
    Private Function IsDebitUserUnique(ByVal GrdView As GridView, Optional ByRef dbusrID As String = "") As Boolean
        Dim i As Integer
        Dim Row As DataRow
        Dim debitusrID As String, tmpdebitusrID As String
        Try
            For i = 0 To GrdView.DataRowCount - 1
                Row = GrdView.GetDataRow(i)
                tmpdebitusrID = Row.Item("debitusrID").ToString
                If tmpdebitusrID = "" Then Return False
                If tmpdebitusrID <> debitusrID Then
                    If debitusrID <> "" Then Return False Else debitusrID = tmpdebitusrID
                End If
            Next
            dbusrID = debitusrID
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    'Function που ελέγχει αν δεν υπάρχει κανένας χρήστης χρέωσης στα παραστατικά
    Private Function IsDebitUserEmpty(ByVal GrdView As GridView) As Boolean
        Dim i As Integer
        Dim Row As DataRow
        Dim debitusrID As String
        Try
            For i = 0 To GrdView.DataRowCount - 1
                Row = GrdView.GetDataRow(i)
                debitusrID = Row.Item("debitusrID").ToString
                If debitusrID <> "" Then Return False
            Next
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

End Class