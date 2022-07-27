Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports DevExpress.XtraPrinting

Public Class Eidop
    Private Sub Eidop_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint

    End Sub

    Private Sub Detail_BeforePrint(sender As Object, e As PrintEventArgs) Handles Detail.BeforePrint
        'Dim sAptID As String
        'sAptID = GetCurrentColumnValue("ID").ToString

        'EXODA_PER_APT.ParameterBindings.Item(1).Parameter.Value = sAptID
    End Sub

    Private Sub Eidop_PrintProgress(sender As Object, e As PrintProgressEventArgs) Handles Me.PrintProgress
        Dim sSQL As String
        sSQL = "UPDATE INH SET DateOfPrintEidop = GETDATE() WHERE DateOfPrintEidop IS NULL AND ID = " & toSQLValueS(inhID.Value.ToString)
        Using oCmd As New SqlCommand(sSQL, CNDB)
            oCmd.ExecuteNonQuery()
        End Using
    End Sub

End Class