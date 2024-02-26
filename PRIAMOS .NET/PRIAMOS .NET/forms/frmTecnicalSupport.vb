Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Reflection
Imports DevExpress.Utils.DirectXPaint
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmTecnicalSupport
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Private CtrlCombo As DevExpress.XtraEditors.LookUpEdit
    Private CalledFromCtrl As Boolean
    Private ManageCbo As New CombosManager
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
    Public WriteOnly Property CallerControl As DevExpress.XtraEditors.LookUpEdit
        Set(value As DevExpress.XtraEditors.LookUpEdit)
            CtrlCombo = value
        End Set
    End Property
    Public WriteOnly Property CalledFromControl As Boolean
        Set(value As Boolean)
            CalledFromCtrl = value
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
                'cmdEmail.Enabled = False
                cmdEmailAnswer.Enabled = False
                txtAnswer.Enabled = True : txtAnswer.ReadOnly = True
            Case FormMode.EditRecord
                'LoadForms.LoadForm(LayoutControl1, "Select * from vw_TECH_SUP where id ='" + sID + "'")
                LoadForms.LoadForm(LayoutControl1, "Select IMAGE,imageAns,IMAGE1,IMAGE2,IMAGE3, vw_TECH_SUP.*  from vw_TECH_SUP INNER JOIN TECH_SUP ON vw_TECH_SUP.ID = TECH_SUP.ID where vw_TECH_SUP.ID ='" + sID + "'")
                LoadForms.LoadDataToGrid(GridControl1, GridView1, "select ID,techSUPID,files,filename,comefrom,createdon,realname From vw_TECH_SUP_F where techSupID = '" & sID & "'")

                If UserProps.ID = System.Guid.Parse("E9CEFD11-47C0-4796-A46B-BC41C4C3606B") Then
                    chkFixed.Enabled = True : txtAnswer.Enabled = True : PictureEdit11.Enabled = True : chkRejected.Enabled = True : txtAnswer.ReadOnly = False
                    chkMoreInfo.Enabled = True : chkBuilded.Enabled = True : txtBuildVersion.Enabled = True
                    cmdEmailAnswer.Enabled = True : SimpleButton1.Enabled = True : chkIsBilled.Enabled = True : ChkAdded.Enabled = True
                End If
        End Select
        If txtBuildVersion.Text = "" Then txtBuildVersion.EditValue = Assembly.GetExecutingAssembly().GetName().Version.ToString()
        LoadForms.RestoreLayoutFromXml(GridView1, "TECH_SUP_F_def.xml")
        Me.CenterToScreen()
    End Sub

    Private Sub frmTecnicalSupport_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs)

    End Sub
    Private Function SaveTech(ByVal FromProgrammer As Boolean) As Boolean
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "TECH_SUP", LayoutControl1,,, sGuid,, IIf(FromProgrammer = False, "fromUserID", ""), IIf(FromProgrammer = False, toSQLValueS(UserProps.ID.ToString), ""))
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "TECH_SUP", LayoutControl1,,, sID,,,,, IIf(FromProgrammer = False, "fromUserID =  " & toSQLValueS(UserProps.ID.ToString), ""))
                End Select
                If sResult Then
                    SaveTech = True
                    'Εκτέλεση QUERY
                    If txtFileNames.Text <> "" Then
                        sResult = DBQ.InsertNewDataFiles(XtraOpenFileDialog1, "TECH_SUP_F", IIf(Mode = FormMode.NewRecord, sGuid, sID))
                        LoadForms.LoadDataToGrid(GridControl1, GridView1, "select ID,techSupID,files,filename,comefrom,createdon,realname From vw_TECH_SUP_F where techSupID = " & toSQLValueS(IIf(Mode = FormMode.NewRecord, sGuid, sID)))
                        LoadForms.RestoreLayoutFromXml(GridView1, "TECH_SUP_F_def.xml")
                    End If

                    Dim form As New frmScroller
                    form.LoadRecords("vw_TECH_SUP")
                Else
                    SaveTech = False

                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            SaveTech = False
        End Try
    End Function

    Private Sub cmdEmail_Click(sender As Object, e As EventArgs) Handles cmdEmail.Click
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            If SaveTech(False) = True Then
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
                e_mail.Body = "Από: [" & UserProps.RealName & "]" & vbNewLine & vbNewLine & txtCode.Text & " - " & txtBody.Text
                Dim myMailHTMLBody = "<html><head></head><body>" & e_mail.Body & " <img src=cid:ThePictureID></body></html>"
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
                If PictureEdit12.EditValue IsNot Nothing Then

                    Dim myImageData() As Byte = PictureEdit12.EditValue
                    'CREATE LINKED RESOURCE FOR ALT VIEW
                    Dim myStream As New MemoryStream(myImageData)
                    Dim myLinkedResouce = New LinkedResource(myStream, "image/jpeg")
                    'SET CONTENTID SO HTML CAN REFERENCE CORRECTLY
                    myLinkedResouce.ContentId = "ThePictureID" 'this must match in the HTML of the message body

                    'ADD LINKED RESOURCE TO ALT VIEW, AND ADD ALT VIEW TO MESSAGE
                    myAltView.LinkedResources.Add(myLinkedResouce)
                    e_mail.AlternateViews.Add(myAltView)
                End If
                If PictureEdit13.EditValue IsNot Nothing Then

                    Dim myImageData() As Byte = PictureEdit13.EditValue
                    'CREATE LINKED RESOURCE FOR ALT VIEW
                    Dim myStream As New MemoryStream(myImageData)
                    Dim myLinkedResouce = New LinkedResource(myStream, "image/jpeg")
                    'SET CONTENTID SO HTML CAN REFERENCE CORRECTLY
                    myLinkedResouce.ContentId = "ThePictureID" 'this must match in the HTML of the message body

                    'ADD LINKED RESOURCE TO ALT VIEW, AND ADD ALT VIEW TO MESSAGE
                    myAltView.LinkedResources.Add(myLinkedResouce)
                    e_mail.AlternateViews.Add(myAltView)
                End If
                If PictureEdit14.EditValue IsNot Nothing Then

                    Dim myImageData() As Byte = PictureEdit14.EditValue
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
                XtraMessageBox.Show("Το email στάλθηκε με επιτυχία!!", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                sSQL = "UPDATE TECH_SUP SET EmailSent = 1 where ID = " & toSQLValueS(IIf(Mode = FormMode.NewRecord, sGuid, sID))
                cmd = New SqlCommand(sSQL, CNDB) : cmd.ExecuteNonQuery()
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdEmailAnswer_Click(sender As Object, e As EventArgs) Handles cmdEmailAnswer.Click
        Dim sSQL As String
        Dim cmd As SqlCommand
        Try
            If SaveTech(True) = True Then
                Dim Smtp_Server As New SmtpClient
                Dim e_mail As New MailMessage()
                Smtp_Server.UseDefaultCredentials = False
                Smtp_Server.Credentials = New System.Net.NetworkCredential(UserProps.Email, UserProps.EmailPassword)
                Smtp_Server.DeliveryMethod = SmtpDeliveryMethod.Network
                Smtp_Server.Port = UserProps.EmailPort
                Smtp_Server.EnableSsl = UserProps.EmailSSL
                Smtp_Server.Host = UserProps.EmailServer

                e_mail = New MailMessage()
                e_mail.From = New MailAddress(txtEmailTo.Text)
                If txtEmailTo.Text <> "" Then e_mail.To.Add(txtFrom.Text)
                If txtCC.Text <> "" Then e_mail.CC.Add(txtCC.Text)
                e_mail.Subject = "ΑΠ:" + txtSubject.Text.Replace(vbCr, "").Replace(vbLf, "")
                e_mail.IsBodyHtml = True
                If chkFixed.Checked Then
                    e_mail.Body = chkFixed.Text & vbCrLf & txtCode.Text & " - " & txtAnswer.Text
                End If
                If chkRejected.Checked Then
                    e_mail.Body = chkRejected.Text & vbCrLf & txtCode.Text & " - " & txtAnswer.Text
                End If
                If chkMoreInfo.Checked Then
                    e_mail.Body = chkMoreInfo.Text & vbCrLf & txtCode.Text & " - " & txtAnswer.Text
                End If

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
                XtraMessageBox.Show("Το email στάλθηκε με επιτυχία!!", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub cboCategory_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboCategory.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageTechCatCategory(cboCategory, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageTechCatCategory(cboCategory, FormMode.EditRecord)
            Case 3 : cboCategory.EditValue = Nothing
        End Select

    End Sub

    Private Sub PictureEdit1_DoubleClick(sender As Object, e As EventArgs) Handles PictureEdit1.DoubleClick
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Pictures") = False Then My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Pictures")
        PictureEdit1.Image.Save(Application.StartupPath & "\Pictures\Image1.jpg", Imaging.ImageFormat.Jpeg)
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Pictures\Image1.jpg") Then ShellExecute(Application.StartupPath & "\Pictures\Image1.jpg")
    End Sub
    Private Sub ShellExecute(ByVal File As String)
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = File
        myProcess.StartInfo.UseShellExecute = True
        myProcess.StartInfo.RedirectStandardOutput = False
        myProcess.Start()
        myProcess.Dispose()
    End Sub

    Private Sub PictureEdit11_DoubleClick(sender As Object, e As EventArgs) Handles PictureEdit11.DoubleClick
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Pictures") = False Then My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Pictures")
        PictureEdit11.Image.Save(Application.StartupPath & "\Pictures\Image5.jpg", Imaging.ImageFormat.Jpeg)
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Pictures\Image5.jpg") Then ShellExecute(Application.StartupPath & "\Pictures\Image5.jpg")
    End Sub

    Private Sub PictureEdit12_DoubleClick(sender As Object, e As EventArgs) Handles PictureEdit12.DoubleClick
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Pictures") = False Then My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Pictures")
        PictureEdit12.Image.Save(Application.StartupPath & "\Pictures\Image2.jpg", Imaging.ImageFormat.Jpeg)
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Pictures\Image2.jpg") Then ShellExecute(Application.StartupPath & "\Pictures\Image2.jpg")
    End Sub

    Private Sub PictureEdit13_DoubleClick(sender As Object, e As EventArgs) Handles PictureEdit13.DoubleClick
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Pictures") = False Then My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Pictures")
        PictureEdit13.Image.Save(Application.StartupPath & "\Pictures\Image3.jpg", Imaging.ImageFormat.Jpeg)
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Pictures\Image3.jpg") Then ShellExecute(Application.StartupPath & "\Pictures\Image3.jpg")
    End Sub

    Private Sub PictureEdit14_DoubleClick(sender As Object, e As EventArgs) Handles PictureEdit14.DoubleClick
        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Pictures") = False Then My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Pictures")
        PictureEdit14.Image.Save(Application.StartupPath & "\Pictures\Image4.jpg", Imaging.ImageFormat.Jpeg)
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Pictures\Image4.jpg") Then ShellExecute(Application.StartupPath & "\Pictures\Image4.jpg")

    End Sub

    Private Sub cmdSave_Click_1(sender As Object, e As EventArgs) Handles cmdSave.Click
        If SaveTech(False) Then XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SaveTech(True) Then XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub txtFileNames_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtFileNames.ButtonClick
        If e.Button.Index = 0 Then
            FilesSelection()
        Else
            txtFileNames.EditValue = Nothing
        End If
    End Sub

    Private Sub FilesSelection()

        'XtraOpenFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        XtraOpenFileDialog1.FilterIndex = 1
        If XtraOpenFileDialog1.FileName.ToString = "" Then
            XtraOpenFileDialog1.InitialDirectory = "C:\"
        Else
            XtraOpenFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(XtraOpenFileDialog1.FileName)
        End If
        XtraOpenFileDialog1.Title = "Open File"
        XtraOpenFileDialog1.CheckFileExists = False
        XtraOpenFileDialog1.Multiselect = True
        Dim result As DialogResult = XtraOpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            txtFileNames.EditValue = ""
            For I = 0 To XtraOpenFileDialog1.FileNames.Count - 1
                txtFileNames.EditValue = txtFileNames.EditValue & IIf(txtFileNames.EditValue <> "", ";", "") & XtraOpenFileDialog1.SafeFileNames(I)
            Next I


        End If
    End Sub
    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        Select Case e.KeyCode
            'Case Keys.F2 : If UserProps.AllowInsert = True Then NewRecord()
            'Case Keys.F3 : If UserProps.AllowEdit = True Then EditRecord()
            'Case Keys.F5 : LoadRecords()
            Case Keys.Delete : DeleteRecord() 'If UserProps.AllowDelete = True Then DeleteRecord()
        End Select

    End Sub


    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "filename") Is DBNull.Value Then Exit Sub
        Dim fs As IO.FileStream = New IO.FileStream("D:\" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "filename"), IO.FileMode.Create)
        Dim b() As Byte = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "files")
        Try
            fs.Write(b, 0, b.Length)
            fs.Close()
            ShellExecute("D:\" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "filename"))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()
        Dim sSQL As String
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM TECH_SUP_F WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadForms.LoadDataToGrid(GridControl1, GridView1, "select ID,techsupID,filename,comefrom,createdon,realname From vw_TECH_SUP_F where techsupID = '" & sID & "'")
                LoadForms.RestoreLayoutFromXml(GridView1, "TECH_SUP_F_def.xml")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView1_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView1, "TECH_SUP_F_def.xml", "TECH_SUP_F")
    End Sub

    Private Sub txtFileNames_EditValueChanged(sender As Object, e As EventArgs) Handles txtFileNames.EditValueChanged

    End Sub

    Private Sub cboCategory_EditValueChanged(sender As Object, e As EventArgs) Handles cboCategory.EditValueChanged

    End Sub

    Private Sub cboCategory_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles cboCategory.EditValueChanging
        If cboCategory.EditValue Is Nothing Then Exit Sub
        Dim OldRowIndex As Integer = cboCategory.Properties.GetDataSourceRowIndex("id", e.OldValue)
        Dim OldBillingValue As Object = cboCategory.Properties.GetDataSourceValue("billing", OldRowIndex)
        Dim NewRowIndex As Integer = cboCategory.Properties.GetDataSourceRowIndex("id", e.NewValue)
        Dim NewBillingValue As Object = cboCategory.Properties.GetDataSourceValue("billing", NewRowIndex)
        If Mode = FormMode.EditRecord And OldBillingValue = True And NewBillingValue = False And UserProps.ID.ToString.ToUpper <> "E9CEFD11-47C0-4796-A46B-BC41C4C3606B" Then
            XtraMessageBox.Show(String.Format("Προσπαθείτε να αλλάξετε κατηγορία από Χρεώσιμη σε ΜΗ. Παρακαλώ επικοινωνείστε."), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
            cboCategory.EditValue = e.OldValue
        End If


    End Sub

    Private Sub cboCategory_Validated(sender As Object, e As EventArgs) Handles cboCategory.Validated
    End Sub

    Private Sub cboCategory_CloseUp(sender As Object, e As CloseUpEventArgs) Handles cboCategory.CloseUp

    End Sub
End Class