Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class CheckPermissions
    Public Sub GetUserPermissions(ByVal FormName As String)
        'ByVal frm As DevExpress.XtraEditors.XtraForm
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select [VIEW],[DELETE],[INSERT],[EDIT] 
                    from FORMS F
					inner join FORM_RIGHTS FR on FR.Fid = F.ID where FR.UID= '" & UserProps.ID.ToString & "' and F.name = " & toSQLValueS(FormName)
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then

                UserProps.AllowView = sdr.GetBoolean(sdr.GetOrdinal("VIEW"))
                UserProps.AllowDelete = sdr.GetBoolean(sdr.GetOrdinal("DELETE"))
                UserProps.AllowEdit = sdr.GetBoolean(sdr.GetOrdinal("EDIT"))
                UserProps.AllowInsert = sdr.GetBoolean(sdr.GetOrdinal("INSERT"))

            Else
                UserProps.AllowView = False
                UserProps.AllowDelete = False
                UserProps.AllowEdit = False
                UserProps.AllowInsert = False
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
