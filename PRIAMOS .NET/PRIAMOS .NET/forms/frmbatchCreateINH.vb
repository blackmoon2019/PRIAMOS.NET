Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmbatchCreateINH
    Private Sub dtFDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtFDate.EditValueChanged
        lbldate.Text = TranslateDates(dtFDate, dtTDate)
    End Sub

    Private Sub dtTDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtTDate.EditValueChanged
        lbldate.Text = TranslateDates(dtFDate, dtTDate)
    End Sub

    Private Sub cmdSaveINH_Click(sender As Object, e As EventArgs) Handles cmdSaveINH.Click
        Try
            Dim date1 As Date = Date.Parse(dtFDate.EditValue.ToString)
            Dim date2 As Date = Date.Parse(dtTDate.EditValue.ToString)
            Dim Months As Long = DateDiff(DateInterval.Month, date1, date2) + 1
            dtTDate.EditValue = date2.AddMonths(1).AddDays(-1)
            date2 = Date.Parse(dtTDate.EditValue.ToString)
            Dim sCompleteDate As String = TranslateDates(dtFDate, dtTDate)
            If XtraMessageBox.Show("Θέλετε να προχωρήσω στην δημιουργία παραστατικών των πολυκατοικιών που είναι διαχειρίσης για διάστημα " & sCompleteDate & " ?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Using oCmd As New SqlCommand("batch_create_inv", CNDB)
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.Parameters.AddWithValue("@fdate", date1)
                    oCmd.Parameters.AddWithValue("@tdate", date2)
                    oCmd.Parameters.AddWithValue("@completeDate", sCompleteDate)
                    oCmd.Parameters.AddWithValue("@Months", Months)
                    oCmd.Parameters.AddWithValue("@modifiedby", UserProps.ID.ToString)
                    oCmd.ExecuteNonQuery()
                End Using
                XtraMessageBox.Show("Τα παραστατικά δημιουργήθηκαν με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmbatchCreateINH_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub frmbatchCreateINH_Load(sender As Object, e As EventArgs) Handles Me.Load
        lbldate.Text = ""
        dtFDate.Properties.Mask.EditMask = "Y"
        dtFDate.Properties.Mask.UseMaskAsDisplayFormat = True
        dtFDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
        dtTDate.Properties.Mask.EditMask = "Y"
        dtTDate.Properties.Mask.UseMaskAsDisplayFormat = True
        dtTDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView

        Me.CenterToScreen()
    End Sub
End Class