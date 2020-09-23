Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports DevExpress.XtraEditors
Public Class Transactions
    Public Sub Modified(ByVal FormName As String, ByVal TableName As String, ByVal RecId As Guid)
        Dim sSQL As String
        Dim cmd As SqlCommand

        Try
            sSQL = "INSERT INTO TRANS ([Uid],[FormName],[TableName],[Recid],[LastEdit]) " &
                                "values (" & toSQLValueS(UserProps.ID.ToString) & "," &
                                             toSQLValueS(FormName) & "," &
                                             toSQLValueS(TableName) & "," &
                                             toSQLValueS(RecId.ToString) & "," &
                                             Now.Date & ")"

            cmd = New SqlCommand(sSQL, CNDB)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))

        End Try
    End Sub
    Public Sub InsertOn(ByVal FormName As String, ByVal TableName As String, ByVal RecId As Guid)
        Dim sSQL As String
        Dim cmd As SqlCommand

        Try
            sSQL = "INSERT INTO TRANS ([Uid],[FormName],[TableName],[Recid],[LastInsert]) " &
                                "values (" & toSQLValueS(UserProps.ID.ToString) & "," &
                                             toSQLValueS(FormName) & "," &
                                             toSQLValueS(TableName) & "," &
                                             toSQLValueS(RecId.ToString) & "," &
                                             Now.Date & ")"

            cmd = New SqlCommand(sSQL, CNDB)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))

        End Try
    End Sub
    Public Sub DeleteOn(ByVal FormName As String, ByVal TableName As String, ByVal RecId As Guid)
        Dim sSQL As String
        Dim cmd As SqlCommand

        Try
            sSQL = "INSERT INTO TRANS ([Uid],[FormName],[TableName],[Recid],[LastDelete]) " &
                                "values (" & toSQLValueS(UserProps.ID.ToString) & "," &
                                             toSQLValueS(FormName) & "," &
                                             toSQLValueS(TableName) & "," &
                                             toSQLValueS(RecId.ToString) & "," &
                                             Now.Date & ")"

            cmd = New SqlCommand(sSQL, CNDB)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))

        End Try
    End Sub

End Class
