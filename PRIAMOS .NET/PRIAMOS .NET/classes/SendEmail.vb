Imports System.Net.Mail
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports System.Net

Public Class SendEmail
    Public Function SendInvoiceEmail(ByVal Subject As String, ByVal Body As String, ByVal sType As Integer, ByVal sToEmail As String, ByVal sFile As String, ByRef statusMsg As String) As Boolean
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New System.Net.NetworkCredential(ProgProps.InvoicesEmailUsername, ProgProps.InvoicesEmailPassword)

            Smtp_Server.Port = ProgProps.InvoicesEmailPort
            Smtp_Server.EnableSsl = ProgProps.InvoicesEmailSSL
            Smtp_Server.Host = ProgProps.InvoicesEmailServer

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(ProgProps.InvoicesEmailUsername)
            Dim parts As String() = sToEmail.Split(";")

            ' Loop through result strings with For Each.
            ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
            If CNDB.Database <> "Priamos_NET" Or Debugger.IsAttached = True Then
                e_mail.To.Add("johnmavroselinos@gmail.com")
            Else
                For Each part As String In parts
                    If part.Length > 0 Then e_mail.To.Add(part)
                Next
            End If

            'If txtCC.Text <> "" Then e_mail.CC.Add(txtCC.Text)
            e_mail.Subject = Subject
            e_mail.IsBodyHtml = True
            Body.Replace("\n", "<br />")
            e_mail.Body = Body
            If CNDB.Database <> "Priamos_NET" Or Debugger.IsAttached = True Then
                e_mail.Headers.Add("Disposition-Notification-To", "johnmavroselinos@gmail.com")
            Else
                e_mail.Headers.Add("Disposition-Notification-To", "admin@priamoservice.gr")
            End If


            e_mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
            Dim myMailHTMLBody = "<html><head></head><body>" & Body & " </body></html>"
            If System.IO.File.Exists(sFile) Then
                Dim data As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(sFile)
                e_mail.Attachments.Add(data)
                Smtp_Server.Send(e_mail)
            Else
                statusMsg = "Δεν βρέθηκε το αρχείο " & sFile
                'XtraMessageBox.Show("Δεν βρέθηκε το αρχείο " & sFile, ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
            e_mail.Dispose()
            Smtp_Server.Dispose()
            statusMsg = "Email Sent Successfully"
            Return True
        Catch ex As Exception
            statusMsg = String.Format("Error: {0}", ex.Message)
            'XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function SendFilesEmail(ByVal Subject As String, ByVal Body As String, ByVal sType As Integer, ByVal sToEmail As String, ByVal sFiles As String(), ByRef statusMsg As String) As Boolean
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New System.Net.NetworkCredential(ProgProps.InvoicesEmailUsername, ProgProps.InvoicesEmailPassword)

            Smtp_Server.Port = ProgProps.InvoicesEmailPort
            Smtp_Server.EnableSsl = ProgProps.InvoicesEmailSSL
            Smtp_Server.Host = ProgProps.InvoicesEmailServer

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(ProgProps.InvoicesEmailUsername)
            Dim parts As String() = sToEmail.Split(";")

            ' Loop through result strings with For Each.
            ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
            If CNDB.Database <> "Priamos_NET" Or Debugger.IsAttached = True Then
                e_mail.To.Add("johnmavroselinos@gmail.com")
            Else
                For Each part As String In parts
                    If part.Length > 0 Then e_mail.To.Add(part)
                Next
            End If

            statusMsg = ""
            'If txtCC.Text <> "" Then e_mail.CC.Add(txtCC.Text)
            e_mail.Subject = Subject
            e_mail.IsBodyHtml = True
            Body.Replace("\n", "<br />")
            e_mail.Body = Body
            If CNDB.Database <> "Priamos_NET" Or Debugger.IsAttached = True Then
                e_mail.Headers.Add("Disposition-Notification-To", "johnmavroselinos@gmail.com")
            Else
                e_mail.Headers.Add("Disposition-Notification-To", "admin@priamoservice.gr")
            End If


            e_mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
            Dim myMailHTMLBody = "<html><head></head><body>" & Body & " </body></html>"
            For Each sFile As String In sFiles
                If sFile.Length > 0 Then
                    If System.IO.File.Exists(sFile) Then
                        Dim data As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(sFile)
                        e_mail.Attachments.Add(data)
                    Else
                        statusMsg = statusMsg & "Δεν βρέθηκε το αρχείο " & sFile & vbCrLf
                        Exit For
                    End If
                End If
            Next

            'Smtp_Server.Timeout = 12000
            Try
                Smtp_Server.Send(e_mail)
            Catch ex As Exception
                statusMsg = String.Format("Error: {0}", ex.Message)
                e_mail.Dispose()
                Smtp_Server.Dispose()
            End Try
            If statusMsg.Length > 0 Then
                e_mail.Dispose()
                Smtp_Server.Dispose()
                Return False
            End If
            e_mail.Dispose()
            Smtp_Server.Dispose()
            statusMsg = "Email Sent Successfully"
            Return True
        Catch ex As Exception
            statusMsg = String.Format("Error: {0}", ex.Message)
            'XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Class
