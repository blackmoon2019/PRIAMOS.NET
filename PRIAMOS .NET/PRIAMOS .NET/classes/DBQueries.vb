Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports DevExpress.XtraEditors
Public Class DBQueries
    Public Function GetNextId(ByVal sTable As String) As Integer
        Dim sSQL As String
        Dim cmd As SqlCommand = New SqlCommand("SELECT IDENT_CURRENT('" & sTable & "') + 1 AS ID", CNDB)
        Dim ID As Integer = cmd.ExecuteScalar()
        Return ID
    End Function
End Class
