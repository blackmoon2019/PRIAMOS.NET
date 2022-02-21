Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

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
                cmdEmailAnswer.Enabled = False
            Case FormMode.EditRecord
                'LoadForms.LoadForm(LayoutControl1, "Select * from vw_TECH_SUP where id ='" + sID + "'")
                LoadForms.LoadForm(LayoutControl1, "Select IMAGE,imageAns,vw_TECH_SUP.*  from vw_TECH_SUP INNER JOIN TECH_SUP ON vw_TECH_SUP.ID = TECH_SUP.ID where vw_TECH_SUP.ID ='" + sID + "'")

                If UserProps.ID = System.Guid.Parse("E9CEFD11-47C0-4796-A46B-BC41C4C3606B") Then
                    chkFixed.Enabled = True : txtAnswer.Enabled = True : PictureEdit11.Enabled = True
                    cmdEmailAnswer.Enabled = True
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
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cmdEmail.Enabled = True
                    Dim form As New frmScroller
                    form.LoadRecords("vw_TECH_SUP")


                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            If PictureEdit1.EditValue IsNot Nothing Then

                Dim myImageData() As Byte = PictureEdit1.EditValue
                'CREATE LINKED RESOURCE FOR ALT VIEW
                Dim myStream As New MemoryStream(myImageData)
                Dim myLinkedResouce = New LinkedResource(myStream, "image/jpeg")
                'SET CONTENTID SO HTML CAN REFERENCE CORRECTLY
                myLinkedResouce.ContentId = "ThePictureID" 'this must match in the HTML of the message body

                'ADD LINKED RESOURCE TO ALT VIEW, AND ADD ALT VIEW TO MESSAGE
                myAltView.LinkedResources.Add(myLinkedResouce)
                e_mail.AlternateViews.Add(myAltView)
            End If

            Smtp_Server.Send(e_mail)
            XtraMessageBox.Show("Το email στάλθηκε με επιτυχία!!", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            sSQL = "UPDATE TECH_SUP SET EmailSent = 1 where ID = " & toSQLValueS(IIf(Mode = FormMode.NewRecord, sGuid, sID))
            cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdEmailAnswer_Click(sender As Object, e As EventArgs) Handles cmdEmailAnswer.Click
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
            e_mail.From = New MailAddress(txtEmailTo.Text)
            If txtEmailTo.Text <> "" Then e_mail.To.Add(txtFrom.Text)
            If txtCC.Text <> "" Then e_mail.CC.Add(txtCC.Text)
            e_mail.Subject = "ΑΠ:" + txtSubject.Text
            e_mail.IsBodyHtml = True
            e_mail.Body = txtAnswer.Text
            Dim myMailHTMLBody = "<html><head></head><body>" & txtAnswer.Text & " <img src=cid:ThePictureID></body></html>"
            Dim myAltView As AlternateView = AlternateView.CreateAlternateViewFromString(myMailHTMLBody, New System.Net.Mime.ContentType("text/html"))
            If PictureEdit11.EditValue IsNot Nothing Then

                Dim myImageData() As Byte = PictureEdit11.EditValue
                'CREATE LINKED RESOURCE FOR ALT VIEW
                Dim myStream As New MemoryStream(myImageData)
                Dim myLinkedResouce = New LinkedResource(myStream, "image/jpeg")
                'SET CONTENTID SO HTML CAN REFERENCE CORRECTLY
                myLinkedResouce.ContentId = "ThePictureID" 'this must match in the HTML of the message body

                'ADD LINKED RESOURCE TO ALT VIEW, AND ADD ALT VIEW TO MESSAGE
                myAltView.LinkedResources.Add(myLinkedResouce)
                e_mail.AlternateViews.Add(myAltView)
            End If

            Smtp_Server.Send(e_mail)
            XtraMessageBox.Show("Το email στάλθηκε με επιτυχία!!", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ManageCategory()
        Dim form1 As frmGen = New frmGen()
        form1.Text = "Κατηγορίες Τεχνικής ποστήριξης"
        form1.L1.Text = "Κωδικός"
        form1.L2.Text = "Κατηγορία"
        form1.DataTable = "TECH_CAT"
        form1.CalledFromControl = True
        form1.CallerControl = cboCategory
        form1.CallerForm = Me
        form1.MdiParent = frmMain
        If cboCategory.EditValue <> Nothing Then
            form1.Mode = FormMode.EditRecord
            form1.ID = cboCategory.EditValue.ToString
        Else
            form1.Mode = FormMode.NewRecord
        End If

        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub cboCategory_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboCategory.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboCategory.EditValue = Nothing : ManageCategory()
            Case 2 : If cboCategory.EditValue <> Nothing Then ManageCategory()
            Case 3 : cboCategory.EditValue = Nothing
        End Select
    End Sub
End Class