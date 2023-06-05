Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports DevExpress.DataAccess
Imports DevExpress.Xpo.DB
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmEmailAPT
    Private sbdgID As String
    Private sMode As Integer
    Private sIDS As New Dictionary(Of Integer, String)
    Private LoadForms As New FormLoader
    Public WriteOnly Property IDS As Dictionary(Of Integer, String)
        Set(value As Dictionary(Of Integer, String))
            sIDS = value
        End Set
    End Property
    Public WriteOnly Property bdgID As String
        Set(value As String)
            sbdgID = value
        End Set
    End Property
    Public WriteOnly Property Mode As Integer
        Set(value As Integer)
            sMode = value
        End Set
    End Property

    Private Sub frmEmailAPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet3.APT' table. You can move, or remove it, as needed.
        Me.APTTableAdapter.Fill(Me.Priamos_NETDataSet3.APT, System.Guid.Parse(sbdgID))
        GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown
        Select Case sMode
            Case 0 ' EMAIL Reports
                LBody.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LSubject.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case 1 ' Email Files
                colnam.Visible = False : colsyg.Visible = False : colreceipt.Visible = False : coleidop1.Visible = False
        End Select
        Me.CenterToScreen()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged

    End Sub

    Private Sub RepSendEmail_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepSendEmail.ButtonClick
        Dim sRow As Integer = GridView1.FocusedRowHandle
        Dim ErrorInProc As String = ""
        If XtraMessageBox.Show("Θέλετε να αποσταλεί email?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Select Case sMode
                Case 0 ' EMAIL Reports
                    SendEmailReport(sRow, ErrorInProc)
                Case 1 ' Email Files
                    If txtSubject.EditValue = Nothing Or txtBody.EditValue = Nothing Then ErrorInProc = "Δεν έχουν συμπληρωθεί υποχρεωτικά πεδία" Else SendEmailFiles(sRow, ErrorInProc)
            End Select

        End If
        If ErrorInProc.Length = 0 Then
            XtraMessageBox.Show("Η αποστολή ολοκληρώθηκε επιτυχώς!", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            XtraMessageBox.Show("Παρουσιάστηκαν προβλήματα στα διαμερίσματα " & ErrorInProc, ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub SendEmailReport(ByVal sRow As Integer, ByRef ErrorInProc As String)
        Dim sAptTTL As String = GridView1.GetRowCellValue(sRow, "ttl").ToString
        Try
            Dim sSQL As String
            Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
            Dim sAptID As String = GridView1.GetRowCellValue(sRow, "ID").ToString
            Dim OwnerID As String = GridView1.GetRowCellValue(sRow, "OwnerID").ToString
            Dim TenantID As String = GridView1.GetRowCellValue(sRow, "TenantID").ToString
            Dim RepresentativeID As String = GridView1.GetRowCellValue(sRow, "RepresentativeID").ToString
            Dim sendEmailOwner As Integer = IIf(GridView1.GetRowCellValue(sRow, "sendEmailOwner") = True, 1, 0)
            Dim sendEmailTenant As Integer = IIf(GridView1.GetRowCellValue(sRow, "sendEmailTenant") = True, 1, 0)
            Dim sendEmailRepresentative As Integer = IIf(GridView1.GetRowCellValue(sRow, "sendEmailRepresentative") = True, 1, 0)
            Dim EmailRepresentative As String = GridView1.GetRowCellValue(sRow, "cctRepresentativeEmail").ToString
            Dim EmailOwner As String = GridView1.GetRowCellValue(sRow, "cctOwnerEmail").ToString
            Dim EmailTenant As String = GridView1.GetRowCellValue(sRow, "cctTenantEmail").ToString
            Dim receipt As Integer = IIf(GridView1.GetRowCellValue(sRow, "receipt") = True, 1, 0)
            Dim syg As Integer = IIf(GridView1.GetRowCellValue(sRow, "syg") = True, 1, 0)
            Dim Eidop As Integer = IIf(GridView1.GetRowCellValue(sRow, "eidop") = True, 1, 0)
            Dim BalAdm As Double = GridView1.GetRowCellValue(sRow, "bal_adm")
            If receipt = 0 And Eidop = 0 And syg = 0 Then
                'XtraMessageBox.Show("Δεν έχετε επιλέξει εκτύπωση για το διαμέρισμα " & sAptTTL, ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorInProc = ErrorInProc + IIf(ErrorInProc.Length = 0, "", ", ") + "Δεν έχετε επιλέξει εκτύπωση για το διαμέρισμα " & sAptTTL
                Exit Sub
            End If
            If EmailRepresentative = "" And EmailTenant = "" And EmailOwner = "" Then
                'XtraMessageBox.Show("Δεν υπάρχει κανένα καταχωρημένο Email στο διαμέρισμα " & sAptTTL, ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorInProc = ErrorInProc + IIf(ErrorInProc.Length = 0, "", ", ") + "Δεν υπάρχει κανένα καταχωρημένο Email στο διαμέρισμα " & sAptTTL
                Exit Sub
            End If

            For Each kvp As KeyValuePair(Of Integer, String) In sIDS
                If Eidop = 1 Then
                    If EmailOwner <> "" Or EmailTenant <> "" Or EmailRepresentative <> "" Then
                        If ExportReport(1, sAptID, kvp.Value, sAptTTL, BalAdm, IIf(sendEmailRepresentative, EmailRepresentative, ""), IIf(sendEmailOwner, EmailOwner, ""), IIf(sendEmailTenant, EmailTenant, "")) = True Then
                            sSQL = "insert into EMAIL_LOG(inhID,aptID,usrID,sendDate,resendDate,recreateDate,owner,tenant,Representative,OwnerID,TenantID,RepresentativeID,syg,eidop,receipt)
                        SELECT " & toSQLValueS(kvp.Value) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",NULL,GETDATE(),NULL," &
                                sendEmailOwner & "," & sendEmailTenant & "," & sendEmailRepresentative & "," & toSQLValueS(OwnerID) & "," & toSQLValueS(TenantID) & "," & toSQLValueS(RepresentativeID) & "," &
                                syg & "," & Eidop & "," & receipt
                            Using oCmd As New SqlCommand(sSQL, CNDB)
                                oCmd.ExecuteNonQuery()
                            End Using
                        Else
                            ErrorInProc = ErrorInProc + IIf(ErrorInProc.Length = 0, "", ", ") + sAptTTL
                        End If
                    End If
                End If
                If syg = 1 Then
                    If EmailOwner <> "" Or EmailTenant <> "" Or EmailRepresentative <> "" Then
                        If ExportReport(0, sAptID, kvp.Value, sAptTTL, BalAdm, IIf(sendEmailRepresentative, EmailRepresentative, ""), IIf(sendEmailOwner, EmailOwner, ""), IIf(sendEmailTenant, EmailTenant, "")) = True Then
                            sSQL = "insert into EMAIL_LOG(inhID,aptID,usrID,sendDate,resendDate,recreateDate,owner,tenant,Representative,OwnerID,TenantID,RepresentativeID,syg,eidop,receipt)
                        SELECT " & toSQLValueS(kvp.Value) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",NULL,GETDATE(),NULL," &
                                sendEmailOwner & "," & sendEmailTenant & "," & sendEmailRepresentative & "," & toSQLValueS(OwnerID) & "," & toSQLValueS(TenantID) & "," & toSQLValueS(RepresentativeID) & "," &
                                syg & "," & Eidop & "," & receipt
                            Using oCmd As New SqlCommand(sSQL, CNDB)
                                oCmd.ExecuteNonQuery()
                            End Using
                        Else
                            ErrorInProc = ErrorInProc + IIf(ErrorInProc.Length = 0, "", ", ") + sAptTTL
                        End If
                    End If
                End If
                If receipt = 1 Then
                    If EmailOwner <> "" Or EmailTenant <> "" Or EmailRepresentative <> "" Then
                        If ExportReport(2, sAptID, kvp.Value, sAptTTL, BalAdm, IIf(sendEmailRepresentative, EmailRepresentative, ""), IIf(sendEmailOwner, EmailOwner, ""), IIf(sendEmailTenant, EmailTenant, "")) = True Then
                            sSQL = "insert into EMAIL_LOG(inhID,aptID,usrID,sendDate,resendDate,recreateDate,owner,tenant,Representative,OwnerID,TenantID,RepresentativeID,syg,eidop,receipt)
                        SELECT " & toSQLValueS(kvp.Value) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",NULL,GETDATE(),NULL," &
                                sendEmailOwner & "," & sendEmailTenant & "," & sendEmailRepresentative & "," & toSQLValueS(OwnerID) & "," & toSQLValueS(TenantID) & "," & toSQLValueS(RepresentativeID) & "," &
                                syg & "," & Eidop & "," & receipt
                            Using oCmd As New SqlCommand(sSQL, CNDB)
                                oCmd.ExecuteNonQuery()
                            End Using
                        Else
                            ErrorInProc = ErrorInProc + IIf(ErrorInProc.Length = 0, "", ", ") + sAptTTL
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorInProc = ErrorInProc + IIf(ErrorInProc.Length = 0, "", ", ") + sAptTTL
        End Try
    End Sub
    Private Sub SendEmailFiles(ByVal sRow As Integer, ByRef ErrorInProc As String)
        Dim sAptTTL As String = GridView1.GetRowCellValue(sRow, "ttl").ToString
        Dim sfIds As String
        Try
            Dim sSQL As String
            Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
            Dim sAptID As String = GridView1.GetRowCellValue(sRow, "ID").ToString
            Dim OwnerID As String = GridView1.GetRowCellValue(sRow, "OwnerID").ToString
            Dim TenantID As String = GridView1.GetRowCellValue(sRow, "TenantID").ToString
            Dim RepresentativeID As String = GridView1.GetRowCellValue(sRow, "RepresentativeID").ToString
            Dim sendEmailOwner As Integer = IIf(GridView1.GetRowCellValue(sRow, "sendEmailOwner") = True, 1, 0)
            Dim sendEmailTenant As Integer = IIf(GridView1.GetRowCellValue(sRow, "sendEmailTenant") = True, 1, 0)
            Dim sendEmailRepresentative As Integer = IIf(GridView1.GetRowCellValue(sRow, "sendEmailRepresentative") = True, 1, 0)
            Dim EmailRepresentative As String = GridView1.GetRowCellValue(sRow, "cctRepresentativeEmail").ToString
            Dim EmailOwner As String = GridView1.GetRowCellValue(sRow, "cctOwnerEmail").ToString
            Dim EmailTenant As String = GridView1.GetRowCellValue(sRow, "cctTenantEmail").ToString
            If EmailRepresentative = "" And EmailTenant = "" And EmailOwner = "" Then
                ErrorInProc = ErrorInProc + IIf(ErrorInProc.Length = 0, "", ", ") + "Δεν υπάρχει κανένα καταχωρημένο Email στο διαμέρισμα " & sAptTTL
                Exit Sub
            End If
            ' Μαζεύω τα κλειδιά των εγγραφών των αρχείων
            For Each kvp As KeyValuePair(Of Integer, String) In sIDS
                If EmailOwner <> "" Or EmailTenant <> "" Or EmailRepresentative <> "" Then sfIds = sfIds & kvp.Value & ";"
            Next
            ' Για να μπορεί να στείλει πολλά Attachment σε ενα email
            If DownloadFile(sAptID, sfIds, IIf(sendEmailRepresentative, EmailRepresentative, ""), IIf(sendEmailOwner, EmailOwner, ""), IIf(sendEmailTenant, EmailTenant, "")) = False Then
                ErrorInProc = ErrorInProc + IIf(ErrorInProc.Length = 0, "", ", ") + sAptTTL
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorInProc = ErrorInProc + IIf(ErrorInProc.Length = 0, "", ", ") + sAptTTL
        End Try
    End Sub
    Private Function ExportReport(ByVal sWichReport As Integer, ByVal sAptID As String, ByVal sInhId As String, ByVal sAtptTTL As String, ByVal BalADM As Double,
                             ByVal EmailRepresentative As String, ByVal EmailOwner As String, ByVal EmailTenant As String) As Boolean
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Dim Emails As New SendEmail
        Dim statusMsg As String
        Try

            Select Case sWichReport
                Case 0 ' Συγκεντρωτική
                    SSM.ShowWaitForm()
                    SSM.SetWaitFormCaption("Παρακαλώ περιμένετε")
                    Dim sSQL As String = "select INH.email,INH.completeDate,BDG.nam as BDGNAM,BDG.old_code as BDGCode
                                        from INH 
                                        INNER JOIN BDG ON BDG.ID =INH.bdgID 
                                        WHERE INH.ID= " & toSQLValueS(sInhId)

                    Cmd = New SqlCommand(sSQL, CNDB)
                    sdr = Cmd.ExecuteReader()
                    While sdr.Read()
                        Dim sEmailTo As String
                        Dim sFName As String
                        Dim sBody As String
                        Dim Subject As String = ""
                        Dim report As New Rep_Sygentrotiki()
                        report.Parameters.Item(0).Value = sInhId
                        report.Parameters.Item(1).Value = sbdgID
                        sEmailTo = String.Concat(EmailTenant, IIf(EmailTenant.Length > 0 And EmailOwner.Length > 0, ";", "") & EmailOwner, IIf((EmailOwner.Length > 0 Or EmailTenant.Length > 0) And EmailRepresentative.Length > 0, ";", "") & EmailRepresentative)

                        sFName = "SYG_" & sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString
                        sBody = ProgProps.InvoicesBodySYG
                        sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                        sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)
                        sBody = sBody.Replace("{BDGCOD}", sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString)
                        Subject = "Συγκεντρωτική - " & sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString
                        ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
                        If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
                        report.CreateDocument()
                        report.ExportToPdf(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads\" & sFName & ".pdf")
                        report.Dispose()
                        report = Nothing

                        If Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads\" & sFName & ".pdf", statusMsg) = True Then
                            sSQL = "Update INH SET EMAIL = 1,DateOfEmail=getdate() WHERE ID = " & toSQLValueS(sInhId)
                            Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                            sSQL = "insert into EMAIL_LOG(inhID,usrID,sendDate,statusMsg,syg)
                                        SELECT " & toSQLValueS(sInhId) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE()," & toSQLValueS(statusMsg) & ",1"
                            oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                        Else
                            sSQL = "insert into EMAIL_LOG(inhID,usrID,sendDate,statusMsg,syg)
                                        SELECT " & toSQLValueS(sInhId) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE()," & toSQLValueS(statusMsg) & ",1"
                            Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                            SSM.CloseWaitForm()
                            sdr.Close()
                            Return False
                        End If
                    End While
                    sdr.Close()
                    SSM.CloseWaitForm()
                    Return True

                Case 1 ' Ειδοποιήσεις
                    SSM.ShowWaitForm()
                    SSM.SetWaitFormCaption("Παρακαλώ περιμένετε")

                    Dim sSQL As String = "select INH.email,INH.completeDate,BDG.id as BdgID,BDG.nam as BDGNAM,BDG.old_code as BDGCode,
                                            (select isnull(sum(vw_INC.AmtPerCalc),0) as AMOUNT  from dbo.vw_INC vw_INC
                                            where vw_INC.inhID=INH.ID
                                            and vw_INC.aptID=APT.ID) as AMOUNT 
                                        from INH 
                                        INNER JOIN BDG ON BDG.ID =INH.bdgID 
                                        INNER JOIN APT ON APT.bdgID =INH.bdgID 
                                        WHERE APT.id = " & toSQLValueS(sAptID) & " and INH.ID= " & toSQLValueS(sInhId)

                    Cmd = New SqlCommand(sSQL, CNDB)
                    sdr = Cmd.ExecuteReader()
                    While sdr.Read()
                        Dim sEmailTo As String
                        Dim sFName As String
                        Dim sBody As String
                        Dim Subject As String = ""
                        Dim report As New Eidop()
                        report.Parameters.Item(0).Value = sInhId
                        sEmailTo = String.Concat(EmailTenant, IIf(EmailTenant.Length > 0 And EmailOwner.Length > 0, ";", "") & EmailOwner, IIf((EmailOwner.Length > 0 Or EmailTenant.Length > 0) And EmailRepresentative.Length > 0, ";", "") & EmailRepresentative)

                        report.FilterString = "[ID] = {" & sAptID & "}"
                        sFName = sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString + sAtptTTL
                        If sdr.GetBoolean(sdr.GetOrdinal("email")) = True Then
                            sBody = ProgProps.InvoicesBodyResend
                        Else
                            sBody = ProgProps.InvoicesBody
                        End If

                        sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                        sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)
                        sBody = sBody.Replace("{BDGCOD}", sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString)
                        sBody = sBody.Replace("{APTNAM}", sAtptTTL)
                        sBody = sBody.Replace("{AMOUNT}", sdr.GetDecimal(sdr.GetOrdinal("AMOUNT").ToString).ToString)
                        sBody = sBody.Replace("{BAL_ADM}", BalADM)
                        Dim UnpaidInvoiceTable As String = ""
                        UnpaidInvoiceTable = ProgProps.InvoicesUnpaidTable.Replace("-----ΓΡΑΜΜΕΣ ΠΙΝΑΚΑ------", CreateHtmlTableRows(sbdgID, sAptID))
                        sBody = sBody.Replace("{UNPAID_INVOICES_TABLE}", UnpaidInvoiceTable)
                        Subject = sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sAtptTTL & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString
                        ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
                        If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
                        report.CreateDocument()
                        report.ExportToPdf(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads\" & sFName & ".pdf")
                        report.Dispose()
                        report = Nothing

                        If Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads\" & sFName & ".pdf", statusMsg) = True Then
                            sSQL = "Update INH SET EMAIL = 1,DateOfEmail=getdate() WHERE ID = " & toSQLValueS(sInhId)
                            Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                            sSQL = "insert into EMAIL_LOG(inhID,aptID,usrID,sendDate,resendDate,recreateDate,statusMsg,eidop)
                                        SELECT " & toSQLValueS(sInhId) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & ",1"
                            oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()

                        Else
                            sSQL = "insert into EMAIL_LOG(inhID,aptID,usrID,sendDate,resendDate,recreateDate,statusMsg,eidop)
                                        SELECT " & toSQLValueS(sInhId) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & ",1"
                            Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                            SSM.CloseWaitForm()
                            sdr.Close()
                            Return False
                        End If
                    End While
                    sdr.Close()
                    SSM.CloseWaitForm()
                    Return True
                Case 2 ' Αποδείξεις
                    SSM.ShowWaitForm()
                    SSM.SetWaitFormCaption("Παρακαλώ περιμένετε")

                    Dim sSQL As String = "select INH.email,INH.completeDate,BDG.nam as BDGNAM,BDG.old_code as BDGCode,
                                            (select isnull(sum(vw_INC.AmtPerCalc),0) as AMOUNT  from dbo.vw_INC vw_INC
                                            where vw_INC.inhID=INH.ID
                                            and vw_INC.aptID=APT.ID) as AMOUNT 
                                        from INH 
                                        INNER JOIN BDG ON BDG.ID =INH.bdgID 
                                        INNER JOIN APT ON APT.bdgID =INH.bdgID 
                                        WHERE APT.id = " & toSQLValueS(sAptID) & " and INH.ID= " & toSQLValueS(sInhId)

                    Cmd = New SqlCommand(sSQL, CNDB)
                    sdr = Cmd.ExecuteReader()
                    While sdr.Read()
                        Dim sEmailTo As String
                        Dim sFName As String
                        Dim sBody As String
                        Dim Subject As String = ""
                        Dim report As New Receipt()
                        report.Parameters.Item(0).Value = sInhId
                        sEmailTo = String.Concat(EmailTenant, IIf(EmailTenant.Length > 0 And EmailOwner.Length > 0, ";", "") & EmailOwner, IIf((EmailOwner.Length > 0 Or EmailTenant.Length > 0) And EmailRepresentative.Length > 0, ";", "") & EmailRepresentative)

                        report.FilterString = "[ID] = {" & sAptID & "}"
                        sFName = "RECEIPT_" & sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString + sAtptTTL
                        sBody = ProgProps.InvoicesBodyRECEIPT

                        sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                        sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)
                        sBody = sBody.Replace("{BDGCOD}", sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString)
                        sBody = sBody.Replace("{APTNAM}", sAtptTTL)
                        sBody = sBody.Replace("{AMOUNT}", sdr.GetDecimal(sdr.GetOrdinal("AMOUNT").ToString).ToString)
                        sBody = sBody.Replace("{BAL_ADM}", BalADM)
                        Subject = "Απόδειξη - " & sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sAtptTTL & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString
                        ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
                        If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
                        report.CreateDocument()
                        report.ExportToPdf(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads\" & sFName & ".pdf")
                        report.Dispose()
                        report = Nothing

                        If Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads\" & sFName & ".pdf", statusMsg) = True Then
                            sSQL = "Update INH SET EMAIL = 1,DateOfEmail=getdate() WHERE ID = " & toSQLValueS(sInhId)
                            Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                            sSQL = "insert into EMAIL_LOG(inhID,aptID,usrID,sendDate,resendDate,recreateDate,statusMsg,receipt)
                                        SELECT " & toSQLValueS(sInhId) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & ",1"
                            oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()

                        Else
                            sSQL = "insert into EMAIL_LOG(inhID,aptID,usrID,sendDate,resendDate,recreateDate,statusMsg,receipt)
                                        SELECT " & toSQLValueS(sInhId) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & ",1"
                            Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                            sdr.Close()
                            SSM.CloseWaitForm()
                            Return False
                        End If
                    End While
                    sdr.Close()
                    SSM.CloseWaitForm()
                    Return True
            End Select
        Catch ex As Exception
            SSM.CloseWaitForm()
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Private Function DownloadFile(ByVal sAptID As String, ByVal sfID As String, ByVal EmailRepresentative As String, ByVal EmailOwner As String, ByVal EmailTenant As String) As Boolean
        Dim Emails As New SendEmail
        Dim statusMsg As String
        Dim sSQL As String
        Dim sFileIDs As String()
        Dim sFileNames As String()
        Dim sFNames As String
        Try


            Dim sEmailTo As String
            Dim sFName As String
            Dim sBody As String = txtBody.EditValue
            Dim Subject As String = txtSubject.EditValue
            sEmailTo = String.Concat(EmailTenant, IIf(EmailTenant.Length > 0 And EmailOwner.Length > 0, ";", "") & EmailOwner, IIf((EmailOwner.Length > 0 Or EmailTenant.Length > 0) And EmailRepresentative.Length > 0, ";", "") & EmailRepresentative)

            ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
            If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
            sFileIDs = sfID.Split(";")
            If sFileIDs.Length > 0 Then
                SSM.ShowWaitForm()
                SSM.SetWaitFormCaption("Παρακαλώ περιμένετε")
                For Each sFileID As String In sFileIDs
                    If sFileID = "" Then Exit For
                    Dim b() As Byte = LoadForms.GetFile(sFileID, "BDG_F", sFName)
                    If File.Exists(Path.GetTempPath & sFName) Then File.Delete(Path.GetTempPath & sFName)
                    Dim fs As System.IO.FileStream = New System.IO.FileStream(Path.GetTempPath & sFName, System.IO.FileMode.Create)
                    fs.Write(b, 0, b.Length)
                    fs.Close()
                    sFNames = sFNames & Path.GetTempPath & sFName & ";"
                Next
                sFileNames = sFNames.Split(";")
                If Emails.SendFilesEmail(Subject, sBody, 0, sEmailTo, sFileNames, statusMsg) = True Then
                    sSQL = "insert into EMAIL_LOG(aptID,bdgFID,usrID,sendDate,statusMsg,files,subject,body)
                                    SELECT " & toSQLValueS(sfID) & "," & toSQLValueS(sfID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE()," & toSQLValueS(statusMsg) & ",1, " &
                                    toSQLValueS(Subject) & "," & toSQLValueS(sBody)
                    Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()

                Else
                    sSQL = "insert into EMAIL_LOG(aptID,bdgFID,usrID,sendDate,statusMsg,files,subject,body)
                                    SELECT " & toSQLValueS(sfID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE()," & toSQLValueS(statusMsg) & ",1, " &
                                    toSQLValueS(Subject) & "," & toSQLValueS(sBody)
                    Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                    SSM.CloseWaitForm()
                    Return False
                End If

            End If
            SSM.CloseWaitForm()
            Return True
        Catch ex As Exception
            SSM.CloseWaitForm()
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Function CreateHtmlTableRows(ByVal bdgID As String, ByVal AptID As String) As String
        Dim sHTMLTableRow As String, sHTMLTable As String
        Dim sHTMLTableRows As New StringBuilder
        Dim sHtmlConstRow =
            "<tr><td class=""tg-pht1"" style=""border-color: inherit;border-style: solid;border-width: 1px;font-family: &quot;Times New Roman&quot;, Times, serif !important;font-size: 12px;overflow: hidden;padding: 10px 5px;word-break: normal;text-align: center;vertical-align: top;"">ΠΑΡΑΣΤΑΤΙΚΟ (ΜΗΝΑΣ)</td>
             <td class=""tg-pht1"" style=""border-color: inherit;border-style: solid;border-width: 1px;font-family: &quot;Times New Roman&quot;, Times, serif !important;font-size: 12px;overflow: hidden;padding: 10px 5px;word-break: normal;text-align: center;vertical-align: top;"">ΠΑΡΑΣΤΑΤΙΚΟ (ΠΟΣΟ €)</td></tr>"
        Try
            Dim Cmd As SqlCommand, sdr As SqlDataReader
            sHTMLTable = ProgProps.InvoicesUnpaidTable
            Dim sSQL As String =
            "SELECT S.completeDate, S.bal  
                    FROM COL
                    INNER JOIN
                    (
                    Select   aptID, c.bdgID, inhID, completeDate, 
		                    SUM(debit) As debit, SUM(credit) As credit, SUM(c.bal) As bal, debitusrID, dtDebit, 
		                    max(dtCredit) As dtCredit,YEAR(FDATE) AS Etos,MONTH(fDate) as  FromMonth,MONTH(tDate) as  ToMonth,fDate,tDate,I.Calorimetric,I.reserveAPT 
                    From COL C 
	                    INNER Join INH I ON I.ID=C.inhID 
	                    INNER Join APT A ON C.aptID = A.ID where completed=0     And C.bdgID =" & toSQLValueS(bdgID) & " and c.aptID= " & toSQLValueS(AptID) &
                   "group By aptID, c.BDGID, INHID, completeDate, debitusrID, dtDebit,YEAR(FDATE),MONTH(fDate),MONTH(tDate),fDate,tDate,Calorimetric,I.reserveAPT  )
	                    AS S ON S.bdgID =COL.bdgID AND S.aptID =COL.aptID and S.inhID = COL.inhID 
                    GROUP BY S.aptID, S.BDGID, S.INHID, S.completeDate, S.debitusrID, S.dtDebit,S.Etos,S.FromMonth ,S.ToMonth ,S.credit,S.bal,S.dtCredit,s.fDate,s.tDate,s.Calorimetric,s.reserveAPT    
                    order by S.aptID, S.BDGID, S.INHID, S.completeDate, S.debitusrID, S.dtDebit,S.Etos,S.FromMonth ,S.ToMonth ,S.credit,S.bal,S.dtCredit,s.fDate,s.tDate,s.Calorimetric,s.reserveAPT "
            Cmd = New SqlCommand(sSQL, CNDB)
            sdr = Cmd.ExecuteReader()
            Dim i As Integer = 1
            While sdr.Read()
                sHTMLTableRow = sHtmlConstRow
                sHTMLTableRow = sHTMLTableRow.Replace("tg-pht1", "tg-pht" & i)
                sHTMLTableRow = sHTMLTableRow.Replace("ΠΑΡΑΣΤΑΤΙΚΟ (ΜΗΝΑΣ)", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                sHTMLTableRow = sHTMLTableRow.Replace("ΠΑΡΑΣΤΑΤΙΚΟ (ΠΟΣΟ €)", sdr.GetDecimal(sdr.GetOrdinal("bal").ToString).ToString)
                sHTMLTableRows.AppendLine(sHTMLTableRow)
                i = i + 1
            End While
            sdr.Close()
            CreateHtmlTableRows = sHTMLTableRows.ToString
            If CreateHtmlTableRows.EndsWith(vbCrLf) Then
                Dim oTrim() As Char = {vbCr, vbLf}
                CreateHtmlTableRows = CreateHtmlTableRows.TrimEnd(oTrim)
            End If
            Return CreateHtmlTableRows
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub cmdBatchSend_Click(sender As Object, e As EventArgs) Handles cmdBatchSend.Click
        Dim ErrorInProc As String = ""
        If XtraMessageBox.Show("Θέλετε να αποσταλουν email στα επιλεγμένα διαμερίσματα?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)
                Select Case sMode
                    Case 0 : SendEmailReport(selectedRowHandle, ErrorInProc)
                    Case 1
                        If txtSubject.EditValue = Nothing Or txtBody.EditValue = Nothing Then ErrorInProc = "Δεν έχουν συμπληρωθεί υποχρεωτικά πεδία" Else SendEmailFiles(selectedRowHandle, ErrorInProc)
                End Select
            Next
        Else
            Exit Sub
        End If
        If ErrorInProc.Length = 0 Then
            XtraMessageBox.Show("Η αποστολή ολοκληρώθηκε επιτυχώς!", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            XtraMessageBox.Show("Παρουσιάστηκαν προβλήματα στα διαμερίσματα " & ErrorInProc, ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing

    End Sub
End Class