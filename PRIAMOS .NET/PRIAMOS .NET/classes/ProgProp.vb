Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Public Class ProgProp
    Public Function GetProgDecimals() As Integer
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select val FROM PRM where prm= 'DECIMAL_PLACES'"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then ProgProps.Decimals = sdr.GetString(sdr.GetOrdinal("VAL"))
            Return ProgProps.Decimals
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Public Sub SetProgDecimals(ByVal sValue As Integer)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            sSQL = "Update PRM set val = '" & sValue & "'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function GetProgTechSupportEmail() As String
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select val FROM PRM where prm= 'SUPPORT_EMAIL'"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then ProgProps.SupportEmail = sdr.GetString(sdr.GetOrdinal("VAL"))
            Return ProgProps.SupportEmail
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Public Sub SetProgTechSupportEmail(ByVal sValue As Integer)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            sSQL = "Update PRM set val = '" & sValue & "'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
