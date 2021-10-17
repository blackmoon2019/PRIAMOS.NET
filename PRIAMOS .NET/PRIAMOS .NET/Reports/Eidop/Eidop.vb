Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class Eidop
    Private Sub Eidop_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint

    End Sub

    Private Sub Detail_BeforePrint(sender As Object, e As PrintEventArgs) Handles Detail.BeforePrint
        Dim sAptID As String
        sAptID = GetCurrentColumnValue("ID").ToString

        'EXODA_PER_APT.ParameterBindings.Item(1).Parameter.Value = sAptID
    End Sub

End Class