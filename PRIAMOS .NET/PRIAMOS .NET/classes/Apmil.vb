Public Class Apmil
    Private DBQ As New DBQueries
    Private LoadForms As New FormLoader
    Public Function UpdateApMilData(ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sGuid As String, ByVal FieldsToBeUpdate As List(Of String))
        Return DBQ.UpdateNewData(DBQueries.InsertMode.GridControl, "APMIL",,,, sGuid, True, GRD, FieldsToBeUpdate)
    End Function
    Public Sub LoadApMilRecords(ByVal control As DevExpress.XtraLayout.LayoutControl, ByVal sSQL As String)
        LoadForms.LoadForm(control, sSQL)
    End Sub
End Class
