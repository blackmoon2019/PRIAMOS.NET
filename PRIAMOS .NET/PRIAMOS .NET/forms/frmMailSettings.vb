﻿Imports System.Net.Mail
Imports System.Data.SqlClient
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.ComponentModel

Public Class frmMailSettings
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private DBQ As New DBQueries
    Private LoadForms As New FormLoader
    Private Cls As New ClearControls
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
    Private Sub frmMailSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'FillComboMulti(cboUsers)
            Select Case Mode
                Case FormMode.EditRecord
                    LoadForms.LoadForm(LayoutControl1, "Select * from vw_MAILS where id ='" + sID + "'")
                    cmdSave.Enabled = UserProps.AllowEdit
                Case FormMode.NewRecord
                    cmdSave.Enabled = UserProps.AllowInsert
            End Select
            '   Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
            Me.CenterToScreen()
            My.Settings.frmUsers = Me.Location
            My.Settings.Save()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    'Private Sub FillComboMulti(ByVal cbo As DevExpress.XtraEditors.GridLookUpEdit)
    '    Dim ds As DataSet = New DataSet
    '    Dim cmd As SqlCommand = New SqlCommand("Select id,Realname from vw_USR ", CNDB)
    '    Dim sdr As SqlDataReader = cmd.ExecuteReader()

    '    cbo.Properties.DataSource = sdr
    '    cbo.Properties.DisplayMember = "Realname"
    '    cbo.Properties.ValueMember = "id"

    '    'GridLookUpEdit1View.OptionsSelection.CheckBoxSelectorField = "IsSelected"
    '    cbo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit

    '    'cbo.Properties.PopupView.Columns("id").Visible = False


    'End Sub
    Private Sub frmMailSettings_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    'Private Sub GridLookUpEdit1View_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
    '    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    '    Dim values As New List(Of Object)()
    '    Dim sVal As String
    '    For Each rowHandle As Integer In view.GetSelectedRows()
    '        values.Add(view.GetRowCellValue(rowHandle, "id"))
    '        sVal = IIf(Not sVal Is Nothing, sVal + " - ", "") + view.GetRowCellValue(rowHandle, "Realname").ToString
    '    Next rowHandle
    '    ToolTipController1.ToolTipStyle = DevExpress.Utils.ToolTipStyle.Windows7
    '    ToolTipController1.SetToolTip(cboUsers, sVal)
    'End Sub

    Private Sub cboUsers_CustomDisplayText(sender As Object, e As CustomDisplayTextEventArgs)
        'Dim values As New List(Of Object)()
        'e.DisplayText = ""
        'If Not cboUsers.EditValue Is Nothing Then
        '    For Each rowHandle As Integer In GridLookUpEdit1View.GetSelectedRows()
        '        '    values.Add(GridLookUpEdit1View.GetRowCellValue(rowHandle, "Realname"))
        '        e.DisplayText = Convert.ToString(e.DisplayText + " - " + GridLookUpEdit1View.GetRowCellValue(rowHandle, "Realname"))

        '    Next rowHandle
        'End If
        'e.DisplayText = ToolTipController1.ToString
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            'For Each rowHandle As Integer In GridLookUpEdit1View.GetSelectedRows()
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "MAILS", LayoutControl1)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "MAILS", LayoutControl1,,, sID)
                End Select
                'Dim form As New frmScroller
                'form.LoadRecords("vw_MAILS")
                If sResult Then
                    'Καθαρισμός Controls
                    Cls.ClearCtrls(LayoutControl1)
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If
            End If
            '    values.Add(GridLookUpEdit1View.GetRowCellValue(rowHandle, "Realname"))
            'Next rowHandle
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdCheckMail_Click(sender As Object, e As EventArgs) Handles cmdCheckMail.Click
        Dim result = XtraInputBox.Show("Πληκτρολογήστε το Email που θα πάει το ΤΕΣΤ Email", ProgProps.ProgTitle, "Default")
        CheckEmail(result)
    End Sub
    Private Sub CheckEmail(ByVal sTO As String)
        Try

            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New System.Net.NetworkCredential(txtUN.Text, txtPWD.Text)
            SmtpServer.Port = txtPort.Text
            SmtpServer.Host = txtServer.Text
            SmtpServer.EnableSsl = chkSSL.Checked
            mail = New MailMessage()
            mail.From = New MailAddress(txtUN.Text)
            mail.To.Add(sTO)
            mail.Subject = "Test Mail"
            mail.Body = "This is for testing mail "
            SmtpServer.Send(mail)
            MsgBox("mail send")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub chkSSL_GotFocus(sender As Object, e As EventArgs) Handles chkSSL.GotFocus
        frmMain.bbFields.Caption = "DB Field: MAILS.ssl"
    End Sub

    Private Sub txtPort_GotFocus(sender As Object, e As EventArgs) Handles txtPort.GotFocus
        frmMain.bbFields.Caption = "DB Field: MAILS.port"
    End Sub

    Private Sub txtPWD_GotFocus(sender As Object, e As EventArgs) Handles txtPWD.GotFocus
        frmMain.bbFields.Caption = "DB Field: MAILS.pwd"
    End Sub

    Private Sub txtServer_GotFocus(sender As Object, e As EventArgs) Handles txtServer.GotFocus
        frmMain.bbFields.Caption = "DB Field: MAILS.server"
    End Sub

    Private Sub txtUN_GotFocus(sender As Object, e As EventArgs) Handles txtUN.GotFocus
        frmMain.bbFields.Caption = "DB Field: MAILS.un"
    End Sub

    Private Sub frmMailSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class