﻿Imports System.Drawing.Printing

Public Class EXODA_PER_APT_OWNERS
    Private Sub GroupHeader1_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GroupHeader1.BeforePrint
        If Detail.Report.RowCount = 0 Then e.Cancel = True
    End Sub
End Class