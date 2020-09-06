Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class CheckPermissions
    Public Sub GetUserPermissions()
        'ByVal frm As DevExpress.XtraEditors.XtraForm
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select [DELETE],[INSERT],[EDIT] from RIGHTS  where UID= '" & UserProps.ID.ToString & "'"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then

                UserProps.AllowDelete = sdr.GetBoolean(sdr.GetOrdinal("DELETE"))
                UserProps.AllowEdit = sdr.GetBoolean(sdr.GetOrdinal("EDIT"))
                UserProps.AllowInsert = sdr.GetBoolean(sdr.GetOrdinal("INSERT"))

            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
