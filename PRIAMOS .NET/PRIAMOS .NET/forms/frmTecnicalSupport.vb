Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports DevExpress.XtraEditors

Public Class frmTecnicalSupport
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private Log As New Transactions
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Dim sGuid As String

    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property Scroller As DevExpress.XtraGrid.Views.Grid.GridView
        Set(value As DevExpress.XtraGrid.Views.Grid.GridView)
            Ctrl = value
        End Set
    End Property
    Public WriteOnly Property FormScroller As DevExpress.XtraEditors.XtraForm
        Set(value As DevExpress.XtraEditors.XtraForm)
            Frm = value
        End Set
    End Property
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmTecnicalSupport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sSQL As New System.Text.StringBuilder
        'Κατηγορίες τεχνικής υποστήριξης
        FillCbo.TECH_CAT(cboCategory)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("TECH_SUP")
                txtFrom.Text = UserProps.Email
                txtEmailTo.Text = ProgProps.SupportEmail
                cmdEmail.Enabled = False
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_TECH_SUP where id ='" + sID + "'")
                If UserProps.ID = System.Guid.Parse("E9CEFD11-47C0-4796-A46B-BC41C4C3606B") Then
                    chkFixed.Enabled = True : txtAnswer.Enabled = True : PictureEdit11.Enabled = True
                End If
        End Select
        Me.CenterToScreen()
        My.Settings.frmTecnicalSupport = Me.Location
        My.Settings.Save()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub frmTecnicalSupport_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "TECH_SUP", LayoutControl1,,, sGuid)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "TECH_SUP", LayoutControl1,,, sID)
                End Select
                If sResult Then
                    'Καθαρισμός Controls
                    'If Mode = FormMode.NewRecord Then Cls.ClearCtrls(LayoutControl1)
                    'txtCode.Text = DBQ.GetNextId("TECH_SUP")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmdEmail.Enabled = True
                    Dim form As New frmScroller
                    form.LoadRecords("vw_TECH_SUP")


                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub cmdEmail_Click(sender As Object, e As EventArgs) Handles cmdEmail.Click
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New System.Net.NetworkCredential(UserProps.Email, UserProps.EmailPassword)

            Smtp_Server.Port = UserProps.EmailPort
            Smtp_Server.EnableSsl = UserProps.EmailSSL
            Smtp_Server.Host = UserProps.EmailServer

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(txtFrom.Text)
            If txtEmailTo.Text <> "" Then e_mail.To.Add(txtEmailTo.Text)
            If txtCC.Text <> "" Then e_mail.CC.Add(txtCC.Text)
            e_mail.Subject = txtSubject.Text
            e_mail.IsBodyHtml = True
            e_mail.Body = txtBody.Text
            Dim myMailHTMLBody = "<html><head></head><body>" & txtBody.Text & " <img src=cid:ThePictureID></body></html>"
            Dim myAltView As AlternateView = AlternateView.CreateAlternateViewFromString(myMailHTMLBody, New System.Net.Mime.ContentType("text/html"))
            Dim myImageData() As Byte = PictureEdit1.EditValue
            'CREATE LINKED RESOURCE FOR ALT VIEW
            Dim myStream As New MemoryStream(myImageData)
            Dim myLinkedResouce = New LinkedResource(myStream, "image/jpeg")
            'SET CONTENTID SO HTML CAN REFERENCE CORRECTLY
            myLinkedResouce.ContentId = "ThePictureID" 'this must match in the HTML of the message body
            'ADD LINKED RESOURCE TO ALT VIEW, AND ADD ALT VIEW TO MESSAGE
            myAltView.LinkedResources.Add(myLinkedResouce)
            e_mail.AlternateViews.Add(myAltView)
            Smtp_Server.Send(e_mail)
            XtraMessageBox.Show("Το email στάλθηκε με επιτυχία!!", "PRIAMOS NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sSQL = "UPDATE TECH_SUP SET EmailSent = 1 where ID = " & toSQLValueS(IIf(Mode = FormMode.NewRecord, sGuid, sID))
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class