Imports System.Drawing.Printing

Public Class EXODA_PER_APT

    Private Sub EXODA_PER_APT_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        If GetCurrentColumnValue("aptID") = Nothing Then Exit Sub
        ' EXODA_PER_APT.ParameterBindings.Item(1).Parameter.Value = "ASd"

    End Sub
End Class