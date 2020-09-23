﻿Imports System.Net.Mail
Imports System.Data.SqlClient
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmMailSettings
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
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
                    Dim cmd As SqlCommand = New SqlCommand("Select * from vw_MAILS where id ='" + sID + "'", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        If sdr.IsDBNull(sdr.GetOrdinal("un")) = False Then txtUN.Text = sdr.GetString(sdr.GetOrdinal("un"))
                        If sdr.IsDBNull(sdr.GetOrdinal("pwd")) = False Then txtPWD.Text = sdr.GetString(sdr.GetOrdinal("pwd"))
                        If sdr.IsDBNull(sdr.GetOrdinal("server")) = False Then txtServer.Text = sdr.GetString(sdr.GetOrdinal("server"))
                        If sdr.IsDBNull(sdr.GetOrdinal("port")) = False Then txtPort.Text = sdr.GetInt32(sdr.GetOrdinal("port"))
                        If sdr.IsDBNull(sdr.GetOrdinal("ssl")) = False Then chkSSL.Checked = sdr.GetBoolean(sdr.GetOrdinal("ssl"))
                        sdr.Close()
                    End If
                    cmdSave.Enabled = UserProps.AllowEdit
                Case FormMode.NewRecord
                    cmdSave.Enabled = UserProps.AllowInsert
            End Select

            Me.CenterToScreen()
            My.Settings.frmUsers = Me.Location
            My.Settings.Save()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Dim sSQL As String
        Try
            'For Each rowHandle As Integer In GridLookUpEdit1View.GetSelectedRows()
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sSQL = "INSERT INTO MAILS ([server],[un],[pwd],[port],[ssl],[modifiedBy],[createdOn]) " &
                                "values (" & toSQLValue(txtServer) & "," &
                                             toSQLValue(txtUN) & "," &
                                             toSQLValue(txtPWD) & "," &
                                             toSQLValue(txtPort, True) & "," &
                                             chkSSL.EditValue & "," &
                                             toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                    Case FormMode.EditRecord

                        sSQL = "UPDATE MAILS set UN =  " & toSQLValue(txtUN) & "," &
                               "PWD = " & toSQLValue(txtPWD) & "," &
                               "server = " & toSQLValue(txtServer) & "," &
                               "port = " & toSQLValue(txtPort, True) & "," &
                               "modifiedBy = " & toSQLValueS(UserProps.ID.ToString) & "," &
                               "ssl = " & chkSSL.EditValue &
                               " where id = '" & sID & "'"

                End Select
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                    Dim form As frmScroller = Frm
                    form.LoadRecords("vw_MAILS")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End If
            '    values.Add(GridLookUpEdit1View.GetRowCellValue(rowHandle, "Realname"))


            'Next rowHandle
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdCheckMail_Click(sender As Object, e As EventArgs) Handles cmdCheckMail.Click
        Dim result = XtraInputBox.Show("Πληκτρολογήστε το Email που θα πάει το ΤΕΣΤ Email", "PRIAMOS .NET", "Default")
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

    Private Sub frmMailSettings_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub
End Class