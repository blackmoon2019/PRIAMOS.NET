﻿Imports System.Drawing.Printing

Public Class EXODA

    Private Sub GroupFooter1_BeforePrint(sender As Object, e As PrintEventArgs) Handles GroupFooter1.BeforePrint
        If Detail.Report.RowCount = 0 Then e.Cancel = True
    End Sub
End Class