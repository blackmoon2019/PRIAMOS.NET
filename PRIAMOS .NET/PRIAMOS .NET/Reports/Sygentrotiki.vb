Imports System.Data.SqlClient
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI

Public Class Rep_Sygentrotiki
    Private Sub Rep_Sygentrotiki_AfterPrint(sender As Object, e As EventArgs) Handles Me.AfterPrint


    End Sub
    'Ενημέρωση ημερομηνίας εκτύπωσης
    Private Sub Rep_Sygentrotiki_PrintProgress(sender As Object, e As PrintProgressEventArgs) Handles Me.PrintProgress
        Dim sSQL As String
        sSQL = "UPDATE INH SET DATEOFPRINT = GETDATE() WHERE DATEOFPRINT IS NULL AND ID = " & toSQLValueS(inhID.Value.ToString)
        Using oCmd As New SqlCommand(sSQL, CNDB)
            oCmd.ExecuteNonQuery()
        End Using
    End Sub


End Class