Imports System.Drawing.Printing

Public Class ClosedAPT
    Private Sub Detail_BeforePrint(sender As Object, e As PrintEventArgs) Handles Detail.BeforePrint

    End Sub

    Private Sub XrLabel1_BeforePrint(sender As Object, e As PrintEventArgs)
        'XrLabel1.WidthF = 300
    End Sub
End Class