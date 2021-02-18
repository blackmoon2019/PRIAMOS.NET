Imports System.Configuration
Imports System.Data.SqlClient

Public Class CN

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

    Public Function OpenConnectionWithParam(ByVal Servername As String, ByVal authentication As String,
                                            ByVal Login As String, ByVal Pwd As String, Optional ByVal Database As String = "") As Boolean
        Dim DBConnection As New SqlConnection()
        Dim cnSTR As New System.Text.StringBuilder

        If authentication = "True" Then cnSTR.Append("Password = " & Pwd & ";")
        cnSTR.Append("Persist Security Info=" & authentication & ";")
        If authentication = "True" Then cnSTR.Append("User ID= " & Login & ";")
        If Database <> "" Then cnSTR.Append("Initial Catalog=" & Database & ";")
        cnSTR.Append("Data Source=" & Servername & ";")
        cnSTR.Append("MultipleActiveResultSets = True")

        Try
            DBConnection.ConnectionString = cnSTR.ToString
            DBConnection.Open()

            If DBConnection.State = ConnectionState.Open Then
                CNDB2 = DBConnection
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
