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
            sdr.Close()
            Return ProgProps.Decimals
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Public Function GetProgvat() As Integer
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select val FROM PRM where prm= 'VAT'"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then ProgProps.VAT = sdr.GetString(sdr.GetOrdinal("VAL"))
            Return ProgProps.VAT
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Sub SetProgDecimals(ByVal sValue As Integer)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            sSQL = "Update PRM set val = '" & sValue & "' where prm= 'DECIMAL_PLACES'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub SetProgVAT(ByVal sValue As Integer)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            sSQL = "Update PRM set val = '" & sValue & "' where prm= 'VAT'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub SetProgADM(ByVal sValue As String)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            sSQL = "Update PRM set val = '" & sValue & "' where prm= 'VAT'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub SetProgANNMENT(ByVal sValue As String)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            sSQL = "Update PRM set val = '" & sValue & "' where prm= 'ANN_MENT'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub GetProgInvoicesEmail()
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select prm,val FROM PRM where prm in('INVOICES_EMAIL','BODY_RECREATE','BODY_RESEND','BODY','BODY_SYG','UNPAID_INVOICES_TABLE','BODY_NOT_MANAGED','SUBJECT_NOT_MANAGED')"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            While sdr.Read()
                If sdr.IsDBNull(sdr.GetOrdinal("VAL")) = False Then
                    Select Case sdr.GetString(sdr.GetOrdinal("prm")).ToString
                        Case "INVOICES_EMAIL" : ProgProps.InvoicesEmailID = sdr.GetString(sdr.GetOrdinal("VAL"))
                        Case "BODY" : ProgProps.InvoicesBody = sdr.GetString(sdr.GetOrdinal("VAL"))
                        Case "BODY_SYG" : ProgProps.InvoicesBodySYG = sdr.GetString(sdr.GetOrdinal("VAL"))
                        Case "BODY_RECEIPT" : ProgProps.InvoicesBodyRECEIPT = sdr.GetString(sdr.GetOrdinal("VAL"))
                        Case "BODY_RESEND" : ProgProps.InvoicesBodyResend = sdr.GetString(sdr.GetOrdinal("VAL"))
                        Case "BODY_RECREATE" : ProgProps.InvoicesBodyRecreate = sdr.GetString(sdr.GetOrdinal("VAL"))
                        Case "UNPAID_INVOICES_TABLE" : ProgProps.InvoicesUnpaidTable = sdr.GetString(sdr.GetOrdinal("VAL"))
                        Case "BODY_NOT_MANAGED" : ProgProps.InvoicesBodyNotManaged = sdr.GetString(sdr.GetOrdinal("VAL"))
                        Case "SUBJECT_NOT_MANAGED" : ProgProps.InvoicesSubjectNotManaged = sdr.GetString(sdr.GetOrdinal("VAL"))
                    End Select

                End If
            End While
            sdr.Close()
            If ProgProps.InvoicesEmailID <> "" Then
                sSQL = "select server,un,pwd,port,ssl FROM MAILS where ID = " & toSQLValueS(ProgProps.InvoicesEmailID)
                cmd = New SqlCommand(sSQL, CNDB)
                sdr = cmd.ExecuteReader()
                If (sdr.Read() = True) Then
                    If sdr.IsDBNull(sdr.GetOrdinal("un")) = False Then ProgProps.InvoicesEmailUsername = sdr.GetString(sdr.GetOrdinal("un"))
                    If sdr.IsDBNull(sdr.GetOrdinal("server")) = False Then ProgProps.InvoicesEmailServer = sdr.GetString(sdr.GetOrdinal("server"))
                    If sdr.IsDBNull(sdr.GetOrdinal("pwd")) = False Then ProgProps.InvoicesEmailPassword = sdr.GetString(sdr.GetOrdinal("pwd"))
                    If sdr.IsDBNull(sdr.GetOrdinal("port")) = False Then ProgProps.InvoicesEmailPort = sdr.GetInt32(sdr.GetOrdinal("port"))
                    If sdr.IsDBNull(sdr.GetOrdinal("ssl")) = False Then ProgProps.InvoicesEmailSSL = sdr.GetBoolean(sdr.GetOrdinal("ssl"))
                End If
                sdr.Close()
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            If (sdr.Read() = True) Then
                If sdr.IsDBNull(sdr.GetOrdinal("VAL")) = False Then
                    ProgProps.SupportEmail = sdr.GetString(sdr.GetOrdinal("VAL"))
                End If
            End If
            sdr.Close()
            Return ProgProps.SupportEmail
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function GetProgADM() As String
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select val FROM PRM where prm= 'ADM'"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then ProgProps.ADM = sdr.GetString(sdr.GetOrdinal("VAL"))
            sdr.Close()
            Return ProgProps.ADM
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Public Function GetProgANNMENT() As String
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select val FROM PRM where prm= 'ANN_MENT'"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then ProgProps.ADM = sdr.GetString(sdr.GetOrdinal("VAL"))
            sdr.Close()
            Return ProgProps.ADM
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Function GetProgEXFolderPath() As String
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Try
            sSQL = "select val FROM PRM where prm= 'EX_FOLDER_PATH'"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            If (sdr.Read() = True) Then ProgProps.EXFolderPath = sdr.GetString(sdr.GetOrdinal("VAL"))
            sdr.Close()
            Return ProgProps.EXFolderPath
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Sub SetProgTechSupportEmail(ByVal sValue As String)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            sSQL = "Update PRM set val = '" & sValue & "' where prm= 'SUPPORT_EMAIL'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.SupportEmail = sValue
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub SetProgInvoicesEmail(ByVal sValue As String, ByVal sValue2 As String, ByVal sValue3 As String, ByVal sValue4 As String, ByVal sValue5 As String,
                                    ByVal sValue6 As String, ByVal sValue7 As String, ByVal sValue8 As String, ByVal sValue9 As String)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            sSQL = "Update PRM set val = '" & sValue & "' where prm= 'INVOICES_EMAIL'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.InvoicesEmailID = sValue
            sSQL = "Update PRM set val = '" & sValue2 & "' where prm= 'BODY'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.InvoicesBody = sValue2
            sSQL = "Update PRM set val = '" & sValue3 & "' where prm= 'BODY_RESEND'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.InvoicesBodyResend = sValue3
            sSQL = "Update PRM set val = '" & sValue4 & "' where prm= 'BODY_RECREATE'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.InvoicesBodyRecreate = sValue4
            sSQL = "Update PRM set val = '" & sValue5 & "' where prm= 'BODY_SYG'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.InvoicesBodySYG = sValue5
            sSQL = "Update PRM set val = '" & sValue6 & "' where prm= 'BODY_RECEIPT'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.InvoicesBodyRECEIPT = sValue6
            sSQL = "Update PRM set val = '" & sValue7 & "' where prm= 'UNPAID_INVOICES_TABLE'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.InvoicesUnpaidTable = sValue7
            sSQL = "Update PRM set val = '" & sValue8 & "' where prm= 'BODY_NOT_MANAGED'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.InvoicesBodyNotManaged = sValue8
            sSQL = "Update PRM set val = '" & sValue9 & "' where prm= 'SUBJECT_NOT_MANAGED'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            ProgProps.InvoicesBodyNotManaged = sValue9


        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub SetProgEXFolderPath(ByVal sValue As String)
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            sSQL = "Update PRM set val = '" & sValue & "' where prm= 'EX_FOLDER_PATH'"
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
