Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports DevExpress.XtraPrinting

Public Class Receipt
    Private Sub Receipt_PrintProgress(sender As Object, e As PrintProgressEventArgs) Handles Me.PrintProgress
        Dim sSQL As String
        sSQL = "UPDATE INH SET DateOfPrintEisp = GETDATE() WHERE DateOfPrintEisp IS NULL AND ID = " & toSQLValueS(inhID.Value.ToString)
        Using oCmd As New SqlCommand(sSQL, CNDB)
            oCmd.ExecuteNonQuery()
        End Using
    End Sub
End Class