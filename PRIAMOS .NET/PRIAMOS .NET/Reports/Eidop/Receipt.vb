Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports DevExpress.XtraPrinting

Public Class Receipt
    Private Frm As frmINH
    Public WriteOnly Property INHForm As frmINH
        Set(value As frmINH)
            Frm = value
        End Set
    End Property

    Private Sub Receipt_PrintProgress(sender As Object, e As PrintProgressEventArgs) Handles Me.PrintProgress
        Dim sSQL As String
        sSQL = "UPDATE INH SET DateOfPrintEisp = GETDATE() WHERE DateOfPrintEisp IS NULL AND ID = " & toSQLValueS(inhID.Value.ToString)
        Using oCmd As New SqlCommand(sSQL, CNDB)
            oCmd.ExecuteNonQuery()
        End Using
        If Frm IsNot Nothing Then
            Frm.chkPrintReceipt.CheckState = CheckState.Checked
            Frm.chkPrintReceipt.Properties.ValueChecked = True
            Frm.chkPrintReceipt.Checked = True
            Frm.chkPrintReceipt.EditValue = True
            'Frm.chkPrintReceipt.Refresh()
            Frm.chkPrintReceipt.Select()
            Frm.Refresh()
        End If
    End Sub

    Private Sub Receipt_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint

    End Sub
End Class