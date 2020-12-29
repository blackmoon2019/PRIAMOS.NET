Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Public Class BManage
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Private LoadForms As New FormLoader
    Public Function UpdateBManageData(ByVal Control As DevExpress.XtraLayout.LayoutControl, ByVal sGuid As String)
        Return DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "BMANAGE", Control,,, sGuid, True)
    End Function
    Public Sub LoadBManageRecords(ByVal control As DevExpress.XtraLayout.LayoutControl, ByVal sSQL As String)
        LoadForms.LoadForm(control, sSQL)
    End Sub
End Class
