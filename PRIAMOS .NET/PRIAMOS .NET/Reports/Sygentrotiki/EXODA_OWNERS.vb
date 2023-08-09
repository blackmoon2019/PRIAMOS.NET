Imports System.Drawing.Printing

Public Class EXODA_OWNERS


    Private Sub GroupFooter1_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GroupFooter1.BeforePrint
        If Detail.Report.RowCount = 0 Then e.Cancel = True
    End Sub
End Class