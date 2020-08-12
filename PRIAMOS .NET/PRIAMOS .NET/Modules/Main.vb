Imports System.Data.SqlClient

Module Main
    Public CNDB As New SqlConnection()
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
