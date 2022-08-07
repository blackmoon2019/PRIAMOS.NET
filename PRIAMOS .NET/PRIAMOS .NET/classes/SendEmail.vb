Imports System.Net.Mail
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class SendEmail
    Public Function SendInvoiceEmail(ByVal Subject As String, ByVal Body As String, ByVal sType As Integer, ByVal sToEmail As String, ByVal sFile As String) As Boolean
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
            e_mail.To.Add(sToEmail)
            'If txtCC.Text <> "" Then e_mail.CC.Add(txtCC.Text)
            e_mail.Subject = Subject
            e_mail.IsBodyHtml = True
            Body.Replace("\n", "<br />")
            e_mail.Body = Body
            e_mail.Headers.Add("Disposition-Notification-To", "admin@priamoservice.gr")

            e_mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
            Dim myMailHTMLBody = "<html><head></head><body>" & Body & " </body></html>"
            If System.IO.File.Exists(sFile) Then
                Dim data As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(sFile)
                e_mail.Attachments.Add(data)
                Smtp_Server.Send(e_mail)
            Else
                XtraMessageBox.Show("Δεν βρέθηκε το αρχείο " & sFile, ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
            e_mail.Dispose()
            Smtp_Server.Dispose()
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
