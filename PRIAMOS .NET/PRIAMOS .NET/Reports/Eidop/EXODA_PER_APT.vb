Imports System.Drawing.Printing

Public Class EXODA_PER_APT

    Private Sub EXODA_PER_APT_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.BeforePrint
        If GetCurrentColumnValue("aptID") = Nothing Then Exit Sub
        ' EXODA_PER_APT.ParameterBindings.Item(1).Parameter.Value = "ASd"

    End Sub

    Private Sub GroupHeader1_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GroupHeader1.BeforePrint
        If Detail.Report.RowCount = 0 Then e.Cancel = True
    End Sub
End Class