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

End Module
