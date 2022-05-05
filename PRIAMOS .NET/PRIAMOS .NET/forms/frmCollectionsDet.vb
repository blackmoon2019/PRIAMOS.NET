Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmCollectionsDet
    Private sID As String, sbdgID As String, saptID As String, sinhID As String
    Private sTenant As Boolean, sCheckForTenant As Boolean = False
    Private LoadForms As New FormLoader
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
    Private Sub frmCollectionsDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If sinhID <> "" And sCheckForTenant = True Then
            Me.Vw_COL_DTableAdapter.FillByInhIDAndTenant(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sinhID), sTenant, System.Guid.Parse(saptID))
        ElseIf sinhID <> "" Then
            Me.Vw_COL_DTableAdapter.FillByInhID(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sinhID), System.Guid.Parse(saptID))
        Else
            Me.Vw_COL_DTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sbdgID), System.Guid.Parse(saptID))
        End If
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COL_D_def.xml") = False Then
            GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COL_D_def.xml", OptionsLayoutBase.FullLayout)
        End If

        GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COL_D_def.xml", OptionsLayoutBase.FullLayout)

        cmdCol_D_Del.Enabled = UserProps.AllowDelete
    End Sub

    Private Sub cmdCol_D_Del_Click(sender As Object, e As EventArgs) Handles cmdCol_D_Del.Click
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
        Dim I As Integer
        Dim sSQL As String
        Dim AptBal As Decimal, Credit As Decimal
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφούν οι επιλεγμένες εγγραφές?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbNo Then Exit Sub
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)

                If GridView1.GetRowCellValue(selectedRowHandle, "ID") = Nothing Then Exit Sub
                sSQL = "DELETE FROM COL_D WHERE ID = " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString)
                Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using
                AptBal = AptBal + GridView1.GetRowCellValue(selectedRowHandle, "debit")
                If GridView1.GetRowCellValue(selectedRowHandle, "inhID").ToString <> "" Then Credit = GridView1.GetRowCellValue(selectedRowHandle, "Credit") Else Credit = 0
                ' Από την στιγμή που διαγράφω κινήσεις είσπραξης θα πρέπει να γίνει Ενημέρωση της είσπραξης
                sSQL = "UPDATE COL SET completed=0,debit = debit +  " & toSQLValueS(Credit.ToString, True) &
                      ",bal=bal + " & toSQLValueS(Credit.ToString, True) & " where id = " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "colID").ToString)
                Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using

            Next
            ' Από την στιγμή που διαγράφω κινήσεις είσπραξης θα πρέπει να γίνει Ενημέρωση υπολοίπου διαμερίσματος
            sSQL = "UPDATE APT SET BAL=BAL + " & toSQLValueS(AptBal, True) & " where id = " & toSQLValueS(saptID)
            Using oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery() : End Using
            frmCollections.LoaderData(sbdgID)
            If sinhID <> "" And sCheckForTenant = True Then
                Me.Vw_COL_DTableAdapter.FillByInhIDAndTenant(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sinhID), sTenant, System.Guid.Parse(saptID))
            ElseIf sinhID <> "" Then
                Me.Vw_COL_DTableAdapter.FillByInhID(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sinhID), System.Guid.Parse(saptID))
            Else
                Me.Vw_COL_DTableAdapter.Fill(Me.Priamos_NETDataSet2.vw_COL_D, System.Guid.Parse(sbdgID), System.Guid.Parse(saptID))
            End If
            XtraMessageBox.Show("Η εγγραφές διαγράφηκαν με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdCol_D_Del_KeyDown(sender As Object, e As KeyEventArgs) Handles cmdCol_D_Del.KeyDown


    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete : If UserProps.AllowDelete = True Then cmdCol_D_Del.PerformClick()
        End Select
    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView1, "COL_D_def.xml")
    End Sub
End Class