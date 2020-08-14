Imports System.Data.SqlClient

Module Main
    Public CNDB As New SqlConnection()
    Enum FormMode
        NewRecord = 1
        EditRecord = 2
        DeleteRecord = 3
        ViewRecord = 4
    End Enum
    Public Structure USER_PROPS
        Public ID As Guid
        Public Code As String
        Public RealName As String
        Public UN As String
        Public PWD As String
        Public DataTable As String
        Public CurrentView As String
    End Structure
    Public UserProps As USER_PROPS
    Public Function toSQLValue(t As DevExpress.XtraEditors.TextEdit, Optional ByVal isnum As Boolean = False) As String
        If t.Text.Length = 0 Then
            Return "NULL" 'this will pass through any SQL statement without notice  
        Else 'Lets suppose our textbox is checked to contain only numbers, so we count on it  
            If Not isnum Then Return "'" + t.Text + "'" Else Return t.Text
        End If
    End Function
End Module
