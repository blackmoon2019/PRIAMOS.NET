Imports System.Configuration
Imports System.Data.SqlClient

Public Class CN




    Dim s As String = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
    Private connStr As String = ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString

    Public Function OpenConnection() As Boolean
        Dim DBConnection As New SqlConnection()
        Try
            DBConnection.ConnectionString = connStr
            DBConnection.Open()
            If DBConnection.State = ConnectionState.Open Then
                CNDB = DBConnection
                Return True
            Else
                DBConnection.Close()
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
            Return False
        End Try
    End Function

End Class
