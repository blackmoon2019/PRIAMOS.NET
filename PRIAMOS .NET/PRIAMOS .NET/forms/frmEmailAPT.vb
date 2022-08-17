Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public Class frmEmailAPT
    Private sbdgID As String
    Private sInhIDS As New Dictionary(Of Integer, String)
    Private LoadForms As New FormLoader
    Public WriteOnly Property InhIDS As Dictionary(Of Integer, String)
        Set(value As Dictionary(Of Integer, String))
            sInhIDS = value
        End Set
    End Property
    Public WriteOnly Property bdgID As String
        Set(value As String)
            sbdgID = value
        End Set
    End Property
    Private Sub frmEmailAPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet3.APT' table. You can move, or remove it, as needed.
        Me.APTTableAdapter.Fill(Me.Priamos_NETDataSet3.APT, System.Guid.Parse(sbdgID))
        Me.CenterToScreen()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged

    End Sub

    Private Sub RepSendEmail_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepSendEmail.ButtonClick
        Try
            Dim sSQL As String
            Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
            Dim sAptID As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
            Dim sAptTTL As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ttl").ToString
            Dim OwnerID As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OwnerID").ToString
            Dim TenantID As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "TenantID").ToString
            Dim RepresentativeID As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RepresentativeID").ToString
            Dim sendEmailOwner As Integer = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sendEmailOwner") = True, 1, 0)
            Dim sendEmailTenant As Integer = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sendEmailTenant") = True, 1, 0)
            Dim sendEmailRepresentative As Integer = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sendEmailRepresentative") = True, 1, 0)
            Dim EmailRepresentative As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "cctRepresentativeEmail")
            Dim EmailOwner As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "cctOwnerEmail")
            Dim EmailTenant As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "cctTenantEmail")
            Dim receipt As Integer = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "receipt") = True, 1, 0)
            Dim syg As Integer = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "syg") = True, 1, 0)
            Dim Eidop As Integer = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "eidop") = True, 1, 0)
            Dim BalAdm As Double = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bal_adm")

            If receipt = 0 And Eidop = 0 And syg = 0 Then
                XtraMessageBox.Show("Δεν έχετε επιλέξει εκτύπωση", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If

            If XtraMessageBox.Show("Θέλετε να αποσταλεί email?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                For Each kvp As KeyValuePair(Of Integer, String) In sInhIDS
                    If ExportReport(1, sAptID, kvp.Value, sAptTTL, BalAdm, IIf(sendEmailRepresentative, EmailRepresentative, ""), IIf(sendEmailOwner, EmailOwner, ""), IIf(sendEmailTenant, EmailTenant, "")) = True Then
                        sSQL = "insert into EMAIL_LOG(inhID,aptID,usrID,sendDate,resendDate,recreateDate,owner,tenant,Representative,OwnerID,TenantID,RepresentativeID,syg,eidop,receipt)
                        SELECT " & toSQLValueS(kvp.Value) & "," & toSQLValueS(sAptID) & "," & toSQLValueS(UserProps.ID.ToString) & ",NULL,GETDATE(),NULL," &
                            sendEmailOwner & "," & sendEmailTenant & "," & sendEmailRepresentative & "," & toSQLValueS(OwnerID) & "," & toSQLValueS(TenantID) & "," & toSQLValueS(RepresentativeID) & "," &
                            syg & "," & Eidop & "," & receipt
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                    End If
                Next
                XtraMessageBox.Show("Η αποστολή ολοκληρώθηκε επιτυχώς!", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function ExportReport(ByVal sWichReport As Integer, ByVal sAptID As String, ByVal sInhId As String, ByVal sAtptTTL As String, ByVal BalADM As Double,
                             ByVal EmailRepresentative As String, ByVal EmailOwner As String, ByVal EmailTenant As String) As Boolean
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Dim Emails As New SendEmail
        Try

            Select Case sWichReport
                Case 0 ' Συγκεντρωτική
                Case 1 ' Ειδοποιήσεις
                    SSM.ShowWaitForm()
                    SSM.SetWaitFormCaption("Παρακαλώ περιμένετε")

                    Dim sSQL As String = "select INH.completeDate,BDG.nam as BDGNAM,BDG.old_code as BDGCode,
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
                        sBody = ProgProps.InvoicesBody
                        sBody = sBody.Replace("{PRD}", sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString)
                        sBody = sBody.Replace("{BDGNAM}", sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString)
                        sBody = sBody.Replace("{BDGCOD}", sdr.GetInt32(sdr.GetOrdinal("BDGCode").ToString).ToString)
                        sBody = sBody.Replace("{APTNAM}", sAtptTTL)
                        sBody = sBody.Replace("{AMOUNT}", sdr.GetDecimal(sdr.GetOrdinal("AMOUNT").ToString).ToString)
                        sBody = sBody.Replace("{BAL_ADM}", BalADM)
                        Subject = sdr.GetString(sdr.GetOrdinal("BDGNAM").ToString).ToString & " - " & sAtptTTL & " - " & sdr.GetString(sdr.GetOrdinal("completeDate").ToString).ToString
                        'sEmailTo = "johnmavroselinos@gmail.com"
                        report.CreateDocument()
                        report.ExportToPdf(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads\" & sFName & ".pdf")
                        report.Dispose()
                        report = Nothing
                        If Emails.SendInvoiceEmail(Subject, sBody, 0, sEmailTo, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads\" & sFName & ".pdf") = True Then
                            sSQL = "Update INH SET EMAIL = 1,DateOfEmail=getdate() WHERE ID = " & toSQLValueS(sInhId)
                            Dim oCmd As New SqlCommand(sSQL, CNDB) : oCmd.ExecuteNonQuery()
                        Else
                            Return False
                        End If
                    End While
                    sdr.Close()
                    SSM.CloseWaitForm()
                    Return True
                Case 2 ' Εισπράξεις

            End Select
        Catch ex As Exception
            SSM.CloseWaitForm()
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
End Class