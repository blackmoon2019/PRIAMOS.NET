Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmColEnanti
    Private ManageCbo As New CombosManager
    Private sBdgID As String
    Private sBdgNam As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Dim sGuid As String

    Public WriteOnly Property BdgID As String
        Set(value As String)
            sBdgID = value
        End Set
    End Property
    Public WriteOnly Property BdgNam As String
        Set(value As String)
            sBdgNam = value
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

    Private Sub frmColEnanti_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COL_METHOD' table. You can move, or remove it, as needed.
        Me.Vw_COL_METHODTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COL_METHOD)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.FillByIsManaged(Me.Priamos_NETDataSet.vw_BDG)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_USR' table. You can move, or remove it, as needed.
        Me.Vw_USRTableAdapter.Fill(Me.Priamos_NETDataSet.vw_USR)
        If sBdgID IsNot Nothing Then
            Me.Vw_APTTableAdapter.FillByBDGAndBalAdm(Me.Priamos_NETDataSet.vw_APT, System.Guid.Parse(sBdgID))
            cboBDG.EditValue = System.Guid.Parse(sBdgID)
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sSQL As New System.Text.StringBuilder
        Dim sINHID As String
        Dim sCOLID As String
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                sINHID = System.Guid.NewGuid.ToString
                sCOLID = System.Guid.NewGuid.ToString
                'Καταχώρηση Παραστατικού
                sSQL.AppendLine("INSERT INTO INH (id,bdgID,CMT,FDATE,TDATE,TotalInh,extraordinary,createdOn,modifiedBY,completeDate,reserveAPT)")
                sSQL.AppendLine("select " & toSQLValueS(sINHID) & ",")
                sSQL.AppendLine(toSQLValueS(sBdgID) & ",")
                sSQL.AppendLine(toSQLValue(txtComments) & ",")
                sSQL.AppendLine("GETDATE(),GETDATE(),")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine("0,GETDATE(),")
                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString) & ",")
                sSQL.AppendLine("dbo.ConvertMonthToGR(GETDATE()) + ' ' + cast( year(getdate()) as nvarchar(4)),1")
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                'Καταχώρηση Είσπραξης
                sSQL.Clear()
                sSQL.AppendLine("INSERT INTO COL (ID,bdgID,aptID,INHID,debitusrID,debit,CREDIT,BAL,dtdebit,cmt,ColMethodID,createdOn,completed,tenant,reserveAPT,modifiedBY)")
                sSQL.AppendLine("select " & toSQLValueS(sCOLID) & ",")
                sSQL.AppendLine(toSQLValueS(sBdgID) & ",")
                sSQL.AppendLine(toSQLValueS(cboApt.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValueS(sINHID) & ",")
                sSQL.AppendLine(toSQLValueS(cboDebitUsr.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine("0,")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine("GETDATE(),")
                sSQL.AppendLine(toSQLValue(txtComments) & ",")
                sSQL.AppendLine(toSQLValueS(cboColMethodID.EditValue.ToString) & ",")
                sSQL.AppendLine("GETDATE(),0,")
                sSQL.AppendLine(toSQLValueS(cboOwnerTenant.SelectedIndex) & ",1,")
                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                'Καταχώρηση Προοδευτικής Χρέωσης
                sSQL.Clear()
                sSQL.AppendLine("INSERT INTO COL_P (BDGID,APTID,INHID,debit,tenant)")
                sSQL.AppendLine("select ")
                sSQL.AppendLine(toSQLValueS(sBdgID) & ",")
                sSQL.AppendLine(toSQLValueS(cboApt.EditValue.ToString) & ",")
                sSQL.AppendLine(toSQLValueS(sINHID) & ",")
                sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                sSQL.AppendLine("1")
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                ''Καταχώρηση Επιμέρους είσπραξης
                'sSQL.Clear()
                'sSQL.AppendLine("INSERT INTO COL_D (colID,bdgID,aptID,INHID,debitusrID,debit,CREDIT,BAL,agreed,tenant,createdOn,reserveAPT,ComeFrom,modifiedBY)")
                'sSQL.AppendLine("select " & toSQLValueS(sCOLID) & ",")
                'sSQL.AppendLine(toSQLValueS(sBdgID) & ",")
                'sSQL.AppendLine(toSQLValueS(cboApt.EditValue.ToString) & ",")
                'sSQL.AppendLine(toSQLValueS(sINHID) & ",")
                'sSQL.AppendLine(toSQLValueS(cboDebitUsr.EditValue.ToString) & ",")
                'sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                'sSQL.AppendLine("0,")
                'sSQL.AppendLine(toSQLValue(txtDebit, True) & "*(-1),")
                'sSQL.AppendLine("0,")
                'sSQL.AppendLine(toSQLValueS(cboOwnerTenant.SelectedIndex) & ",")
                'sSQL.AppendLine("GETDATE(),1,4,")
                'sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString))
                ''Εκτέλεση QUERY
                'Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                '    oCmd.ExecuteNonQuery()
                'End Using
                'Ενημέρωση Υπολοίπου διαμερίσματος
                sSQL.Clear()
                sSQL.AppendLine("UPDATE APT set bal_adm = bal_adm + " & toSQLValue(txtDebit, True) & "*(-1) WHERE ID = " & toSQLValueS(cboApt.EditValue.ToString))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using

                'Καθαρισμός Controls
                Cls.ClearCtrls(LayoutControl1)
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Valid.SChanged = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cboBDG_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageBDG(cboBDG, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageBDG(cboBDG, FormMode.EditRecord)
            Case 3 : cboBDG.EditValue = Nothing
        End Select
    End Sub
    Private Sub cboApt_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboApt.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageAPT(cboApt, FormMode.NewRecord, cboBDG.EditValue.ToString)
            Case 2 : ManageCbo.ManageAPT(cboApt, FormMode.EditRecord, cboBDG.EditValue.ToString)
            Case 3 : cboApt.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboApt_EditValueChanged(sender As Object, e As EventArgs) Handles cboApt.EditValueChanged
        txtComments.EditValue = "ΕΝΑΝΤΙ ΔΙΑΜΕΡΙΣΜΑΤΟΣ " & cboApt.Text
    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue = Nothing Then Exit Sub
        sBdgID = cboBDG.EditValue.ToString
        Me.Vw_APTTableAdapter.FillByBDGAndBalAdm(Me.Priamos_NETDataSet.vw_APT, System.Guid.Parse(cboBDG.EditValue.ToString))
    End Sub

    Private Sub cboColMethodID_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboColMethodID.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageColMethod(cboColMethodID, FormMode.NewRecord, Me)
            Case 2 : ManageCbo.ManageColMethod(cboColMethodID, FormMode.EditRecord, Me)
            Case 3 : cboColMethodID.EditValue = Nothing
        End Select
    End Sub
End Class