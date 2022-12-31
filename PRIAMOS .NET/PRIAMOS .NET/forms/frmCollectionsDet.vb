﻿Imports System.Collections.Specialized
Imports System.Data.SqlClient
Imports System.Text
Imports DevExpress.CodeParser
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmCollectionsDet
    Private sID As String, sbdgID As String, saptID As String, sinhID As String, sColBanksID As String
    Private sTenant As Boolean, sCheckForTenant As Boolean = False
    Private sCalledFromCollBanks As Boolean = False
    Private sGetCompletedCols As Boolean = False
    Private sDeposit As Decimal = 0
    Private sInhIDS2 As New Dictionary(Of String, String)
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

        Dim TotDebit As Decimal
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length - 1 = -1 Then XtraMessageBox.Show("Δεν έχετε επιλέξει κάποια εγγραφή", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
        sInhIDS2.Clear()
        For I = 0 To selectedRowHandles.Length - 1
            Dim selectedRowHandle As Int32 = selectedRowHandles(I)
            If GridView1.GetRowCellValue(selectedRowHandle, "inhID").ToString <> "" Then
                sInhIDS2.Add(Guid.NewGuid.ToString, GridView1.GetRowCellValue(selectedRowHandle, "tenant").ToString & "," & GridView1.GetRowCellValue(selectedRowHandle, "inhID").ToString)
                TotDebit = TotDebit + GridView1.GetRowCellValue(selectedRowHandle, "debit")
            End If
        Next
        'If sDeposit > TotDebit Then
        '    XtraMessageBox.Show("Το σύνολο των επιλεγμένων παραστατικών πρέπει να είναι είναι μεγαλύτερο ή ίσο της κατάθεσης", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'Else
        Me.Close()
        'End If
    End Sub


    Private Sub frmCollectionsDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If sCalledFromCollBanks = False Then
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
        Else
            If sGetCompletedCols = False Then
                COL_PER_BDG_APTTableAdapter.Fill(Me.Priamos_NETDataSet3.COL_PER_BDG_APT, System.Guid.Parse(sbdgID), System.Guid.Parse(saptID))
                GridControl1.DataSource = COLPERBDGAPTBindingSource
                GridControl1.ForceInitialize()
                GridControl1.DefaultView.PopulateColumns()
                LoadForms.RestoreLayoutFromXml(GridView1, "COL_BANKS_DET_def.xml")
                'Dim i As Integer
                'Dim sFilter As String = ""
                'For i = 0 To sInhIDS.Count - 1
                '    sFilter = sFilter & "{" & sInhIDS.Item(i) & "}" & IIf(i <> sInhIDS.Count - 1, ",", "")
                'Next
                'If sFilter.Length > 0 Then
                '    GridView1.ActiveFilterString = "[inhID] In (" & sFilter & ")"
                '    GridView1.SelectAll()
                'End If
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                COLBanksCompletedTableAdapter.Fill(Me.Priamos_NETDataSet3.COLBanksCompleted, System.Guid.Parse(sColBanksID))
                GridControl1.DataSource = COLBanksCompletedBindingSource
                GridControl1.ForceInitialize()
                GridControl1.DefaultView.PopulateColumns()
                LoadForms.RestoreLayoutFromXml(GridView1, "COL_BANKS_DET_COMPLETED_def.xml")
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If

            LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            lblDeposit.Text = "Ποσό Κατάθεσης : " & sDeposit
        End If
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
            If sCalledFromCollBanks = False Then
                LoadForms.PopupMenuShow(e, GridView1, "COL_D_def.xml")
            Else
                If sGetCompletedCols = False Then
                    LoadForms.PopupMenuShow(e, GridView1, "COL_BANKS_DET_def.xml")
                Else
                    LoadForms.PopupMenuShow(e, GridView1, "COL_BANKS_DET_COMPLETED_def.xml")
                End If
            End If
            End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        sInhIDS2.Clear() : Me.Close()
    End Sub
End Class