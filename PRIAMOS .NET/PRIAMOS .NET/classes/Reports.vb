Imports DevExpress.DataAccess
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraScheduler.Native
Imports DevExpress.XtraSpreadsheet.DocumentFormats
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab

Public Class Reports
    Public Function SYGReport(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Try
            Dim isManaged As Boolean = GRD.GetRowCellValue(Row, "isManaged").ToString
            If isManaged = True Then
                Return SygReportManaged(Row, sIDS, GRD)
            Else
                Return SygReportUnManaged(Row, sIDS, GRD)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function SygReportManaged(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Dim Emails As New SendEmail
        Dim sEmailID As String
        Dim statusMsg As String
        Dim sSQL As String
        Try


            Dim sInhID As String = GRD.GetRowCellValue(Row, "ID").ToString
            Dim sBdgID As String = GRD.GetRowCellValue(Row, "bdgID").ToString
            sSQL =
                        "select APT.ID as AptID,
                                    CONCAT(
									case when sendEmailOwner=1 then  CCT_OWNER.email + ';' else '' end,
									case when sendEmailOwner=1 then  CCT_OWNER.email2 +';' else '' end,
									case when sendEmailOwner=1 then  CCT_OWNER.email3 +';' else '' end, 
									case when sendEmailTenant=1 then  CCT_TENANT.email  +';' else '' end, 
									case when sendEmailTenant=1 then  CCT_TENANT.email2  +';' else '' end, 
									case when sendEmailTenant=1 then  CCT_TENANT.email3  +';' else '' end, 
									case when sendEmailRepresentative=1 then  CCT_REP.email   +';' else '' end, 
									case when sendEmailRepresentative=1 then  CCT_REP.email2   +';' else '' end,
									case when sendEmailRepresentative=1 then  CCT_REP.email3   +';' else '' end) AS EMAIL,
                                    INH.completeDate,BDG.id as BdgID,BDG.nam as BDGNAM,BDG.old_code as BDGCode,APT.ttl as APTNAM,APT.bal_adm,
                                    (select isnull(sum(vw_INC.AmtPerCalc),0) as AMOUNT  from dbo.vw_INC vw_INC
                                    where vw_INC.inhID=INH.ID
                                    and vw_INC.aptID=APT.ID) as AMOUNT 
                                from INH 
                                INNER JOIN BDG ON BDG.ID =INH.bdgID 
                                INNER JOIN APT ON APT.bdgID =INH.bdgID
                                LEFT JOIN CCT CCT_OWNER ON CCT_OWNER.ID =APT.OwnerID 
								LEFT JOIN CCT CCT_TENANT ON CCT_TENANT.ID =APT.TenantID
                                LEFT JOIN CCT CCT_REP ON CCT_REP.ID =APT.RepresentativeID
                                WHERE INH.ID= " & toSQLValueS(sInhID) &
                        " AND 
								((COALESCE(CCT_OWNER.email,CCT_OWNER.EMAIL2,CCT_OWNER.EMAIL3) IS NOT NULL and sendEmailOwner =1)    OR
								(COALESCE(CCT_TENANT.email,CCT_TENANT.EMAIL2,CCT_TENANT.EMAIL3) IS NOT NULL and sendEmailTenant =1) OR 
                                (COALESCE(CCT_REP.email,CCT_REP.EMAIL2,CCT_REP.EMAIL3) IS NOT NULL and sendEmailRepresentative =1)  )  "

            Cmd = New SqlCommand(sSQL, CNDB)
            sdr = Cmd.ExecuteReader()
            Dim sEmailTo As String
            While sdr.Read()
                Dim sAptID As String
                Dim sFName As String
                Dim sBody As String
                Dim Subject As String = ""
                Dim report As New Rep_Sygentrotiki()
                report.Parameters.Item(0).Value = sInhID
                report.Parameters.Item(1).Value = sBdgID
                If sdr.IsDBNull(sdr.GetOrdinal("AptID")) = False Then
                    sAptID = sdr.GetGuid(sdr.GetOrdinal("AptID").ToString).ToString
                    sEmailTo = sdr.GetString(sdr.GetOrdinal("EMAIL").ToString).ToString

                    If sEmailTo.Last = ";" Then sEmailTo = sEmailTo.Substring(0, sEmailTo.Length - 1)
                    sFName = "SYG_" + sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString
                    sBody = ProgProps.InvoicesBodySYG
                    If sBody = Nothing Then sBody = ""
                    sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                    sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)
                    sBody = sBody.Replace("{BDGCOD}", sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString)
                    sBody = sBody.Replace("{APTNAM}", sdr.GetString(sdr.GetOrdinal("APTNAM").ToString).ToString)
                    sBody = sBody.Replace("{AMOUNT}", sdr.GetDecimal(sdr.GetOrdinal("AMOUNT").ToString).ToString)
                    sBody = sBody.Replace("{BAL_ADM}", sdr.GetDecimal(sdr.GetOrdinal("BAL_ADM").ToString).ToString)
                    Subject = sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("APTNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString & " - " & "Συγκεντρωτική"

                    ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
                    If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
                    report.CreateDocument()
                    report.ExportToPdf(Path.GetTempPath & sFName & ".pdf")
                    report.Dispose()
                    report = Nothing
                    sEmailID = System.Guid.NewGuid.ToString
                    ' Αποστολή Email
                    Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Path.GetTempPath & sFName & ".pdf", statusMsg)
                    ' Ενημέρωση ΠΑραστατικού ότι στάλθηκε Email
                    sSQL = "Update INH SET EmailSyg = 1,DateOfEmailSyg=getdate() WHERE ID = " & toSQLValueS(sInhID)
                    Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                    ' Καταχώρηση στον πίνακα LOG EMAIL
                    sSQL = "insert into EMAIL_LOG(syg,EmailSend,ID,inhID,aptID,usrID,sendDate,resendDate,recreateDate,statusMsg,toEmail)
                                SELECT 1,1," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & "," & toSQLValueS(sEmailTo)
                    oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                    If sIDS.Length > 0 Then sIDS.Append(",")
                    sIDS.Append(toSQLValueS(sEmailID))
                End If
            End While
            sdr.Close()
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function SygReportUnManaged(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Dim Emails As New SendEmail
        Dim sEmailID As String
        Dim statusMsg As String
        Dim sSQL As String
        Try

            Dim sInhID As String = GRD.GetRowCellValue(Row, "ID").ToString
            Dim sBdgID As String = GRD.GetRowCellValue(Row, "bdgID").ToString
            sSQL =
                        "select 
                                    CONCAT(
									case when AllowsendEmail=1 then  CCT_MANAGER.email   +';' else '' end,
                                    case when AllowsendEmail=1 then  CCT_MANAGER.email2   +';' else '' end,
                                    case when AllowsendEmail=1 then  CCT_MANAGER.email3   +';' else '' end) AS EMAIL,
                                    INH.completeDate,BDG.id as BdgID,BDG.nam as BDGNAM,BDG.old_code as BDGCode
                                from INH 
                                INNER JOIN BDG ON BDG.ID =INH.bdgID 
                                LEFT JOIN VW_BDG_M CCT_MANAGER ON CCT_MANAGER.ID =BDG.managerID and isMain =1
                                WHERE INH.ID= " & toSQLValueS(sInhID) &
                        " AND (COALESCE(CCT_MANAGER.email,CCT_MANAGER.EMAIL2,CCT_MANAGER.EMAIL3) IS NOT NULL and AllowsendEmail =1)   "

            Cmd = New SqlCommand(sSQL, CNDB)
            sdr = Cmd.ExecuteReader()
            Dim sEmailTo As String
            While sdr.Read()
                Dim sFName As String
                Dim sBody As String
                Dim Subject As String = ""
                Dim report As New Rep_Sygentrotiki()
                report.Parameters.Item(0).Value = sInhID
                report.Parameters.Item(1).Value = sBdgID
                sEmailTo = sdr.GetString(sdr.GetOrdinal("EMAIL").ToString).ToString

                If sEmailTo.Last = ";" Then sEmailTo = sEmailTo.Substring(0, sEmailTo.Length - 1)
                sFName = "SYG_" + sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString
                sBody = ProgProps.InvoicesBodyNotManaged
                If sBody = Nothing Then sBody = ""
                sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)

                Subject = sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString & " - " & "Συγκεντρωτική"

                ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
                If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
                report.CreateDocument()
                report.ExportToPdf(Path.GetTempPath & sFName & ".pdf")
                report.Dispose()
                report = Nothing
                sEmailID = System.Guid.NewGuid.ToString
                ' Αποστολή Email
                Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Path.GetTempPath & sFName & ".pdf", statusMsg)
                ' Ενημέρωση ΠΑραστατικού ότι στάλθηκε Email
                sSQL = "Update INH SET EmailSyg = 1,DateOfEmailSyg=getdate() WHERE ID = " & toSQLValueS(sInhID)
                Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                ' Καταχώρηση στον πίνακα LOG EMAIL
                sSQL = "insert into EMAIL_LOG(syg,EmailSend,ID,inhID,usrID,sendDate,resendDate,recreateDate,statusMsg,toEmail)
                        SELECT 1,1," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & "," & toSQLValueS(sEmailTo)
                oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()

                If sIDS.Length > 0 Then sIDS.Append(",")
                sIDS.Append(toSQLValueS(sEmailID))
            End While
            sdr.Close()
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function EidopReport(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Try
            Dim isManaged As Boolean = GRD.GetRowCellValue(Row, "isManaged").ToString
            If isManaged = True Then
                Return EidopReportManaged(Row, sIDS, GRD)
            Else
                Return EidopReportUnManaged(Row, sIDS, GRD)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function EidopReportManaged(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Dim Emails As New SendEmail
        Dim sEmailID As String
        Dim statusMsg As String
        Try

            Dim sInhID As String = GRD.GetRowCellValue(Row, "ID").ToString
            Dim sSQL As String =
                            "select APT.ID as AptID,
                                    CONCAT(
									case when sendEmailOwner=1 then  CCT_OWNER.email + ';' else '' end,
									case when sendEmailOwner=1 then  CCT_OWNER.email2 +';' else '' end,
									case when sendEmailOwner=1 then  CCT_OWNER.email3 +';' else '' end, 
									case when sendEmailTenant=1 then  CCT_TENANT.email  +';' else '' end, 
									case when sendEmailTenant=1 then  CCT_TENANT.email2  +';' else '' end, 
									case when sendEmailTenant=1 then  CCT_TENANT.email3  +';' else '' end, 
									case when sendEmailRepresentative=1 then  CCT_REP.email   +';' else '' end, 
									case when sendEmailRepresentative=1 then  CCT_REP.email2   +';' else '' end,
									case when sendEmailRepresentative=1 then  CCT_REP.email3   +';' else '' end) AS EMAIL,
                                    INH.completeDate,BDG.id as BdgID,BDG.nam as BDGNAM,BDG.old_code as BDGCode,APT.ttl as APTNAM,APT.bal_adm,
                                    (select isnull(sum(vw_INC.AmtPerCalc),0) as AMOUNT  from dbo.vw_INC vw_INC
                                    where vw_INC.inhID=INH.ID
                                    and vw_INC.aptID=APT.ID) as AMOUNT 
                                from INH 
                                INNER JOIN BDG ON BDG.ID =INH.bdgID 
                                INNER JOIN APT ON APT.bdgID =INH.bdgID 
                                LEFT JOIN CCT CCT_OWNER ON CCT_OWNER.ID =APT.OwnerID 
								LEFT JOIN CCT CCT_TENANT ON CCT_TENANT.ID =APT.TenantID
                                LEFT JOIN CCT CCT_REP ON CCT_REP.ID =APT.RepresentativeID
                                WHERE INH.ID= " & toSQLValueS(sInhID) &
                            " AND 
								((COALESCE(CCT_OWNER.email,CCT_OWNER.EMAIL2,CCT_OWNER.EMAIL3) IS NOT NULL and sendEmailOwner =1)    OR
								(COALESCE(CCT_TENANT.email,CCT_TENANT.EMAIL2,CCT_TENANT.EMAIL3) IS NOT NULL and sendEmailTenant =1) OR 
                                (COALESCE(CCT_REP.email,CCT_REP.EMAIL2,CCT_REP.EMAIL3) IS NOT NULL and sendEmailRepresentative =1)  )  "
            Cmd = New SqlCommand(sSQL, CNDB)
            sdr = Cmd.ExecuteReader()
            Dim sEmailTo As String
            While sdr.Read()
                Dim sAptID As String
                Dim sBdgID As String
                Dim sFName As String
                Dim sBody As String
                Dim Subject As String = ""
                Dim report As New Eidop()
                report.Parameters.Item(0).Value = sInhID
                If sdr.IsDBNull(sdr.GetOrdinal("AptID")) = False Then
                    sAptID = sdr.GetGuid(sdr.GetOrdinal("AptID").ToString).ToString
                    sBdgID = sdr.GetGuid(sdr.GetOrdinal("BdgID").ToString).ToString
                    sEmailTo = sdr.GetString(sdr.GetOrdinal("EMAIL").ToString).ToString
                    If sEmailTo.Last = ";" Then sEmailTo = sEmailTo.Substring(0, sEmailTo.Length - 1)
                    report.FilterString = "[ID] = {" & sAptID & "}"
                    sFName = sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString +
                    sdr.GetString(sdr.GetOrdinal("APTNAM").ToString).ToString
                    If GRD.GetRowCellValue(Row, "email") = True Then
                        sBody = ProgProps.InvoicesBodyRecreate
                    Else
                        sBody = ProgProps.InvoicesBody
                    End If
                    If sBody = Nothing Then sBody = ""

                    sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                    sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)
                    sBody = sBody.Replace("{BDGCOD}", sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString)
                    sBody = sBody.Replace("{APTNAM}", sdr.GetString(sdr.GetOrdinal("APTNAM").ToString).ToString)
                    sBody = sBody.Replace("{AMOUNT}", sdr.GetDecimal(sdr.GetOrdinal("AMOUNT").ToString).ToString)
                    sBody = sBody.Replace("{BAL_ADM}", sdr.GetDecimal(sdr.GetOrdinal("BAL_ADM").ToString).ToString)
                    Dim UnpaidInvoiceTable As String = ""
                    UnpaidInvoiceTable = ProgProps.InvoicesUnpaidTable.Replace("-----ΓΡΑΜΜΕΣ ΠΙΝΑΚΑ------", CreateHtmlTableRows(sBdgID, sAptID))
                    sBody = sBody.Replace("{UNPAID_INVOICES_TABLE}", UnpaidInvoiceTable)
                    Subject = sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("APTNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString

                    ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
                    If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
                    report.CreateDocument()
                    report.ExportToPdf(Path.GetTempPath & sFName & ".pdf")
                    report.Dispose()
                    report = Nothing
                    sEmailID = System.Guid.NewGuid.ToString
                    ' Αποστολή Email
                    Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Path.GetTempPath & sFName & ".pdf", statusMsg)
                    ' Ενημέρωση ΠΑραστατικού ότι στάλθηκε Email
                    sSQL = "Update INH SET EMAIL = 1,DateOfEmail=getdate() WHERE ID = " & toSQLValueS(sInhID)
                    Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                    sSQL = "insert into EMAIL_LOG(eidop,EmailSend,ID,inhID,aptID,usrID,sendDate,resendDate,recreateDate,statusMsg,toEmail)
                                        SELECT 1,1," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & "," & toSQLValueS(sEmailTo)
                    oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()

                    If sIDS.Length > 0 Then sIDS.Append(",")
                    sIDS.Append(toSQLValueS(sEmailID))
                End If
            End While
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function EidopReportUnManaged(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Dim Emails As New SendEmail
        Dim sEmailID As String, statusMsg As String, sBDGCode As String
        Dim sBody As String, Subject As String, sSQL As String, sEmailTo As String, sBdgID As String
        Try

            Dim sInhID As String = GRD.GetRowCellValue(Row, "ID").ToString
            sEmailID = System.Guid.NewGuid.ToString
            sSQL = "select INH.completeDate,BDG.id as BdgID,BDG.nam as BDGNAM,INH.completeDate,BDG.old_code as BDGCode, 
					CONCAT(case when AllowsendEmail=1 then  CCT_MANAGER.email   +';' else '' end,
                    case when AllowsendEmail=1 then  CCT_MANAGER.email2   +';' else '' end,
                    case when AllowsendEmail=1 then  CCT_MANAGER.email3   +';' else '' end) AS EMAIL 
                from INH 
                INNER JOIN BDG ON BDG.ID =INH.bdgID 
                LEFT JOIN VW_BDG_M CCT_MANAGER ON CCT_MANAGER.ID =BDG.managerID and isMain =1
                WHERE INH.ID= " & toSQLValueS(sInhID) &
            " AND (COALESCE(CCT_MANAGER.email,CCT_MANAGER.EMAIL2,CCT_MANAGER.EMAIL3) IS NOT NULL and AllowsendEmail =1)  "
            Cmd = New SqlCommand(sSQL, CNDB)
            sdr = Cmd.ExecuteReader()
            If sdr.Read() Then
                sEmailTo = sdr.GetString(sdr.GetOrdinal("EMAIL").ToString).ToString
                sBody = ProgProps.InvoicesBodyNotManaged
                If sBody = Nothing Then sBody = ""
                sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)

                Subject = sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString
                sBdgID = sdr.GetGuid(sdr.GetOrdinal("BdgID").ToString).ToString
                sBDGCode = sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString
                sdr.Close()
            Else
                sdr.Close()
                ' Δεν υπάρχει εμαιλ στον διαχειριστή ή δεν έχουν ορίσει να αποστέλλεται εμαιλ
                Dim oCmd As New SqlCommand(sSQL, CNDB)
                sSQL = "insert into EMAIL_LOG(eidop,EmailSend,ID,inhID,usrID,statusMsg)
                        SELECT 1,0," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(UserProps.ID.ToString) & "," & toSQLValueS("Δεν υπάρχει Email ή δεν έχετε επιλέξε να αποστέλλονται Email στον διαχειριστή.")
                oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                sIDS.Append(toSQLValueS(sEmailID))
                Return False
            End If
            Dim report As New Eidop()
            report.Parameters.Item(0).Value = sInhID
            Dim sFName As String
            sFName = sBDGCode + " - " + "Ειδοποιήσεις"
            If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"

            report.ExportToPdf(Path.GetTempPath & sFName & ".pdf")

            If Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Path.GetTempPath & sFName & ".pdf", statusMsg) Then
                ' Ενημέρωση ΠΑραστατικού ότι στάλθηκε Email
                sSQL = "Update INH SET email = 1,DateOfEmail=getdate() WHERE ID = " & toSQLValueS(sInhID)
                Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                sSQL = "insert into EMAIL_LOG(eidop,EmailSend,ID,inhID,usrID,sendDate,resendDate,recreateDate,statusMsg,toEmail)
                                SELECT 1,1," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & "," & toSQLValueS(sEmailTo)
                oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
            End If
            If sIDS.Length > 0 Then sIDS.Append(",")
            sIDS.Append(toSQLValueS(sEmailID))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function ReceiptReport(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Try
            Dim isManaged As Boolean = GRD.GetRowCellValue(Row, "isManaged").ToString
            If isManaged = True Then
                Return ReceiptReportManaged(Row, sIDS, GRD)
            Else
                Return ReceiptReportUnManaged(Row, sIDS, GRD)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function ReceiptReportManaged(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Dim Emails As New SendEmail
        Dim sEmailID As String
        Dim statusMsg As String
        Try

            Dim sInhID As String = GRD.GetRowCellValue(Row, "ID").ToString
            Dim sSQL As String =
                            "select APT.ID as AptID,
                                    CONCAT(
									case when sendEmailOwner=1 then  CCT_OWNER.email + ';' else '' end,
									case when sendEmailOwner=1 then  CCT_OWNER.email2 +';' else '' end,
									case when sendEmailOwner=1 then  CCT_OWNER.email3 +';' else '' end, 
									case when sendEmailTenant=1 then  CCT_TENANT.email  +';' else '' end, 
									case when sendEmailTenant=1 then  CCT_TENANT.email2  +';' else '' end, 
									case when sendEmailTenant=1 then  CCT_TENANT.email3  +';' else '' end, 
									case when sendEmailRepresentative=1 then  CCT_REP.email   +';' else '' end, 
									case when sendEmailRepresentative=1 then  CCT_REP.email2   +';' else '' end,
									case when sendEmailRepresentative=1 then  CCT_REP.email3   +';' else '' end) AS EMAIL,
                                    INH.completeDate,BDG.id as BdgID,BDG.nam as BDGNAM,BDG.old_code as BDGCode,APT.ttl as APTNAM,APT.bal_adm,
                                    (select isnull(sum(vw_INC.AmtPerCalc),0) as AMOUNT  from dbo.vw_INC vw_INC
                                    where vw_INC.inhID=INH.ID
                                    and vw_INC.aptID=APT.ID) as AMOUNT 
                                from INH 
                                INNER JOIN BDG ON BDG.ID =INH.bdgID 
                                INNER JOIN APT ON APT.bdgID =INH.bdgID 
                                LEFT JOIN CCT CCT_OWNER ON CCT_OWNER.ID =APT.OwnerID 
								LEFT JOIN CCT CCT_TENANT ON CCT_TENANT.ID =APT.TenantID
                                LEFT JOIN CCT CCT_REP ON CCT_REP.ID =APT.RepresentativeID
                                WHERE INH.ID= " & toSQLValueS(sInhID) &
                            " AND 
								((COALESCE(CCT_OWNER.email,CCT_OWNER.EMAIL2,CCT_OWNER.EMAIL3) IS NOT NULL and sendEmailOwner =1)    OR
								(COALESCE(CCT_TENANT.email,CCT_TENANT.EMAIL2,CCT_TENANT.EMAIL3) IS NOT NULL and sendEmailTenant =1) OR 
                                (COALESCE(CCT_REP.email,CCT_REP.EMAIL2,CCT_REP.EMAIL3) IS NOT NULL and sendEmailRepresentative =1)  )  "
            Cmd = New SqlCommand(sSQL, CNDB)
            sdr = Cmd.ExecuteReader()
            Dim sEmailTo As String
            While sdr.Read()
                Dim sAptID As String
                Dim sBdgID As String
                Dim sFName As String
                Dim sBody As String
                Dim Subject As String = ""
                Dim report As New Receipt()
                report.Parameters.Item(0).Value = sInhID
                If sdr.IsDBNull(sdr.GetOrdinal("AptID")) = False Then
                    sAptID = sdr.GetGuid(sdr.GetOrdinal("AptID").ToString).ToString
                    sBdgID = sdr.GetGuid(sdr.GetOrdinal("BdgID").ToString).ToString
                    sEmailTo = sdr.GetString(sdr.GetOrdinal("EMAIL").ToString).ToString
                    If sEmailTo.Last = ";" Then sEmailTo = sEmailTo.Substring(0, sEmailTo.Length - 1)
                    report.FilterString = "[ID] = {" & sAptID & "}"
                    sFName = sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString +
                    sdr.GetString(sdr.GetOrdinal("APTNAM").ToString).ToString
                    If GRD.GetRowCellValue(Row, "email") = True Then
                        sBody = ProgProps.InvoicesBodyRecreate
                    Else
                        sBody = ProgProps.InvoicesBody
                    End If
                    If sBody = Nothing Then sBody = ""
                    sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                    sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)
                    sBody = sBody.Replace("{BDGCOD}", sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString)
                    sBody = sBody.Replace("{APTNAM}", sdr.GetString(sdr.GetOrdinal("APTNAM").ToString).ToString)
                    sBody = sBody.Replace("{AMOUNT}", sdr.GetDecimal(sdr.GetOrdinal("AMOUNT").ToString).ToString)
                    sBody = sBody.Replace("{BAL_ADM}", sdr.GetDecimal(sdr.GetOrdinal("BAL_ADM").ToString).ToString)
                    Dim UnpaidInvoiceTable As String = ""
                    UnpaidInvoiceTable = ProgProps.InvoicesUnpaidTable.Replace("-----ΓΡΑΜΜΕΣ ΠΙΝΑΚΑ------", CreateHtmlTableRows(sBdgID, sAptID))
                    sBody = sBody.Replace("{UNPAID_INVOICES_TABLE}", UnpaidInvoiceTable)
                    Subject = sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("APTNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString

                    ' Όταν ήμαστε στο ΤΕΣΤ Περιβάλλον
                    If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
                    report.CreateDocument()
                    report.ExportToPdf(Path.GetTempPath & sFName & ".pdf")
                    report.Dispose()
                    report = Nothing
                    sEmailID = System.Guid.NewGuid.ToString
                    ' Αποστολή Email
                    Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Path.GetTempPath & sFName & ".pdf", statusMsg)
                    ' Ενημέρωση ΠΑραστατικού ότι στάλθηκε Email
                    sSQL = "Update INH SET emailReceipt = 1,DateOfEmailReceipt=getdate() WHERE ID = " & toSQLValueS(sInhID)
                    Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                    sSQL = "insert into EMAIL_LOG(receipt,EmailSend,ID,inhID,aptID,usrID,sendDate,resendDate,recreateDate,statusMsg,toEmail)
                                        SELECT 1,1," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & "," & toSQLValueS(sEmailTo)
                    oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()

                    If sIDS.Length > 0 Then sIDS.Append(",")
                    sIDS.Append(toSQLValueS(sEmailID))
                End If
            End While
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function ReceiptReportUnManaged(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Dim Emails As New SendEmail
        Dim sEmailID As String, statusMsg As String, sBDGCode As String
        Dim sFileNames As String()
        Dim sFNames As String, sBody As String, Subject As String, sSQL As String, sEmailTo As String, sBdgID As String
        Try

            Dim sInhID As String = GRD.GetRowCellValue(Row, "ID").ToString
            sEmailID = System.Guid.NewGuid.ToString
            sSQL = "select INH.completeDate,BDG.id as BdgID,BDG.nam as BDGNAM,INH.completeDate,BDG.old_code as BDGCode, 
					CONCAT(case when AllowsendEmail=1 then  CCT_MANAGER.email   +';' else '' end,
                    case when AllowsendEmail=1 then  CCT_MANAGER.email2   +';' else '' end,
                    case when AllowsendEmail=1 then  CCT_MANAGER.email3   +';' else '' end) AS EMAIL 
                from INH 
                INNER JOIN BDG ON BDG.ID =INH.bdgID 
                LEFT JOIN VW_BDG_M CCT_MANAGER ON CCT_MANAGER.ID =BDG.managerID and isMain =1
                WHERE INH.ID= " & toSQLValueS(sInhID) &
            " AND (COALESCE(CCT_MANAGER.email,CCT_MANAGER.EMAIL2,CCT_MANAGER.EMAIL3) IS NOT NULL and AllowsendEmail =1) "
            Cmd = New SqlCommand(sSQL, CNDB)
            sdr = Cmd.ExecuteReader()
            If sdr.Read() Then
                sEmailTo = sdr.GetString(sdr.GetOrdinal("EMAIL").ToString).ToString
                sBody = ProgProps.InvoicesBodyNotManaged
                If sBody = Nothing Then sBody = ""
                sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)

                Subject = sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString
                sBdgID = sdr.GetGuid(sdr.GetOrdinal("BdgID").ToString).ToString
                sBDGCode = sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString
                sdr.Close()
            Else
                sdr.Close()
                ' Δεν υπάρχει εμαιλ στον διαχειριστή ή δεν έχουν ορίσει να αποστέλλεται εμαιλ
                Dim oCmd As New SqlCommand(sSQL, CNDB)
                sSQL = "insert into EMAIL_LOG(receipt,EmailSend,ID,inhID,usrID,statusMsg)
                        SELECT 1,1," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(UserProps.ID.ToString) & "," & toSQLValueS("Δεν υπάρχει Email ή δεν έχετε επιλέξε να αποστέλλονται Email στον διαχειριστή.")
                oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                sIDS.Append(toSQLValueS(sEmailID))
                Return False
            End If
            Dim report As New Receipt()
            report.Parameters.Item(0).Value = sInhID
            Dim sFName As String
            sFName = sBDGCode + " - " + "Αποδείξεις"
            If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
            report.ExportToPdf(Path.GetTempPath & sFName & ".pdf")

            If Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Path.GetTempPath & sFName & ".pdf", statusMsg) Then
                ' Ενημέρωση ΠΑραστατικού ότι στάλθηκε Email
                sSQL = "Update INH SET emailReceipt = 1,DateOfEmailReceipt=getdate() WHERE ID = " & toSQLValueS(sInhID)
                Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                sSQL = "insert into EMAIL_LOG(receipt,EmailSend,ID,inhID,usrID,sendDate,resendDate,recreateDate,statusMsg,toEmail)
                                SELECT 1,1," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & "," & toSQLValueS(sEmailTo)
                oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
            End If
            If sIDS.Length > 0 Then sIDS.Append(",")
            sIDS.Append(toSQLValueS(sEmailID))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Public Function AllReports(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        ' Παίζει μόνο για τις ΜΗ Διαχειρίσεις
        Try
            Dim isManaged As Boolean = GRD.GetRowCellValue(Row, "isManaged").ToString
            Dim sInhID As String = GRD.GetRowCellValue(Row, "ID").ToString
            If isManaged = False Then
                Return AllReporstUnManaged(Row, sIDS, GRD)
            Else
                Dim sSQL As String = "insert into EMAIL_LOG(syg,eidop,receipt,EmailSend,ID,inhID,usrID,sendDate,resendDate,recreateDate,statusMsg)
                                SELECT 1,1,1,1," & toSQLValueS(System.Guid.NewGuid.ToString) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS("Η Αποστολή όλων των Reports υποστηρίζεται μόνο σε ΜΗ διαχειρίσης")
                Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()

            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function AllReporstUnManaged(ByVal Row As Integer, ByRef sIDS As StringBuilder, ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Dim Emails As New SendEmail
        Dim sEmailID As String, statusMsg As String, sBDGCode As String
        Dim sFileNames As String()
        Dim sFNames As String, sBody As String, Subject As String, sSQL As String, sEmailTo As String, sBdgID As String
        Try

            Dim sInhID As String = GRD.GetRowCellValue(Row, "ID").ToString
            sEmailID = System.Guid.NewGuid.ToString
            sSQL = "select INH.completeDate,BDG.id as BdgID,BDG.nam as BDGNAM,INH.completeDate,BDG.old_code as BDGCode, 
					CONCAT(case when AllowsendEmail=1 then  CCT_MANAGER.email   +';' else '' end,
                    case when AllowsendEmail=1 then  CCT_MANAGER.email2   +';' else '' end,
                    case when AllowsendEmail=1 then  CCT_MANAGER.email3   +';' else '' end) AS EMAIL 
                from INH 
                INNER JOIN BDG ON BDG.ID =INH.bdgID 
                LEFT JOIN VW_BDG_M CCT_MANAGER ON CCT_MANAGER.ID =BDG.managerID and isMain =1
                WHERE INH.ID= " & toSQLValueS(sInhID) &
            " AND (COALESCE(CCT_MANAGER.email,CCT_MANAGER.EMAIL2,CCT_MANAGER.EMAIL3) IS NOT NULL and AllowsendEmail =1)  "
            Cmd = New SqlCommand(sSQL, CNDB)
            sdr = Cmd.ExecuteReader()
            If sdr.Read() Then
                sEmailTo = sdr.GetString(sdr.GetOrdinal("EMAIL").ToString).ToString
                sBody = ProgProps.InvoicesBodyNotManaged
                If sBody = Nothing Then sBody = ""
                sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)
                Subject = sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString
                sBdgID = sdr.GetGuid(sdr.GetOrdinal("BdgID").ToString).ToString
                sBDGCode = sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString
                sdr.Close()
            Else
                sdr.Close()
                ' Δεν υπάρχει εμαιλ στον διαχειριστή ή δεν έχουν ορίσει να αποστέλλεται εμαιλ
                Dim oCmd As New SqlCommand(sSQL, CNDB)
                sSQL = "insert into EMAIL_LOG(syg,receipt,eidop,EmailSend,ID,inhID,usrID,statusMsg)
                        SELECT 1,1,1,0," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(UserProps.ID.ToString) & "," & toSQLValueS("Δεν υπάρχει Email ή δεν έχετε επιλέξε να αποστέλλονται Email στον διαχειριστή.")
                oCmd = New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                sIDS.Append(toSQLValueS(sEmailID))
                Return False
            End If

            Dim sFNameSYG As String, sFNameEIDOP As String, sFNameRECEIPT As String

            ' ΣΥΓΚΕΝΤΡΩΤΙΚΗ
            Dim repSYG As New Rep_Sygentrotiki()
            repSYG.Parameters.Item(0).Value = sInhID
            repSYG.Parameters.Item(1).Value = sBdgID
            sFNameSYG = Path.GetTempPath & sBDGCode + " - " + "Συγκεντρωτικη.pdf"
            repSYG.ExportToPdf(sFNameSYG)
            repSYG.Dispose() : repSYG = Nothing

            ' ΕΙΔΟΠΟΙΗΣΕΙΣ
            Dim repEIDOP As New Eidop()
            repEIDOP.Parameters.Item(0).Value = sInhID
            sFNameEIDOP = Path.GetTempPath & sBDGCode + " - " + "Ειδοποιήσεις.pdf"
            repEIDOP.ExportToPdf(sFNameEIDOP)
            repEIDOP.Dispose() : repEIDOP = Nothing


            ' ΑΠΟΔΕΙΞΕΙΣ
            Dim repRECEIPT As New Receipt()
            repRECEIPT.Parameters.Item(0).Value = sInhID
            sFNameRECEIPT = Path.GetTempPath & sBDGCode + " - " + "Αποδείξεις.pdf"
            repRECEIPT.ExportToPdf(sFNameRECEIPT)
            repRECEIPT.Dispose() : repRECEIPT = Nothing


            sFNames = sFNameSYG & ";" & sFNameEIDOP & ";" & sFNameRECEIPT
            sFileNames = sFNames.Split(";")

            If CNDB.Database <> "Priamos_NET" Then sEmailTo = "johnmavroselinos@gmail.com;thv@priamoservice.gr"
            If Emails.SendFilesEmail(Subject, sBody, 0, sEmailTo, sFileNames, statusMsg) = True Then
                ' Ενημέρωση ΠΑραστατικού ότι στάλθηκε Email
                sSQL = "Update INH SET emailReceipt = 1,DateOfEmailReceipt=getdate() , email = 1,DateOfEmail=getdate(),emailSyg = 1,DateOfEmailSyg=getdate()  WHERE ID = " & toSQLValueS(sInhID)
                Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
            End If
            sSQL = "insert into EMAIL_LOG(syg,eidop,receipt,EmailSend,ID,inhID,usrID,sendDate,resendDate,recreateDate,statusMsg,toEmail)
                                SELECT 1,1,1,1," & toSQLValueS(sEmailID) & "," & toSQLValueS(sInhID) & "," & toSQLValueS(UserProps.ID.ToString) & ",GETDATE(),NULL,NULL," & toSQLValueS(statusMsg) & "," & toSQLValueS(sEmailTo)
            Dim oCmd2 As New SqlCommand(sSQL, CNDB) : oCmd2.ExecuteNonQuery()

            If sIDS.Length > 0 Then sIDS.Append(",")
            sIDS.Append(toSQLValueS(sEmailID))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class
