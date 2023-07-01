Imports System.Drawing.Printing

Public Class EXODA
    Private Sub GroupHeader1_BeforePrint(sender As Object, e As PrintEventArgs) Handles GroupHeader1.BeforePrint
        If Detail.Report.RowCount = 0 Then e.Cancel = True
    End Sub
End Class