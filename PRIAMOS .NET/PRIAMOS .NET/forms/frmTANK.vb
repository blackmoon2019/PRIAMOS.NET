Imports System.Data.SqlClient
Imports System.Reflection
Imports DevExpress.Pdf.Drawing.DirectX
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmTANK
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private sBdgID As String
    Private lpcH As Double
    Private CtrlCombo As DevExpress.XtraEditors.LookUpEdit
    Private CalledFromCtrl As Boolean
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Dim sGuid As String

    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property BdgID As String
        Set(value As String)
            sBdgID = value
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


    Private Sub frmTANK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_BDG.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_BDG)
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_BDG.vw_MEASUREMENT_CAT' table. You can move, or remove it, as needed.
        Me.Vw_MEASUREMENT_CATTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_MEASUREMENT_CAT)
        'TODO: This line of code loads data into the 'Priamos_NET_DataSet_BDG.vw_MEASURERS' table. You can move, or remove it, as needed.
        Me.Vw_MEASURERSTableAdapter.Fill(Me.Priamos_NET_DataSet_BDG.vw_MEASURERS)
        Dim sSQL As New System.Text.StringBuilder
        'Πολυκατοικίες
        'FillCbo.BDG(cboBDG)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("TANK")
            Case FormMode.EditRecord
                Me.Vw_TANKTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_TANK, System.Guid.Parse(sBdgID))
        End Select
        Me.Vw_TANKTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_TANK, System.Guid.Parse(sBdgID))
        cboBDG.EditValue = sBdgID
        lpcH = cboBDG.GetColumnValue("lpcH")
        dtMeasurement.EditValue = Date.Now
        LoadForms.RestoreLayoutFromXml(GridView3, "TANK_def.xml")
        Me.CenterToScreen()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Dim sTankID As String
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                If cboMeasurementcat.GetColumnValue("isInvoice") = "1" Then XtraMessageBox.Show("Δεν μπορείτε να καταχωρήσετε εγγραφή αγοράς. " & vbCrLf &
                    "Μόνο μέσα από τα Τιμολόγια Καυσίμων ", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                sTankID = System.Guid.NewGuid.ToString

                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "TANK", LayoutControl1,,, sTankID,, "litersB,liters", txtmesB.EditValue.ToString & "*" & lpcH & "," & txtmes.EditValue.ToString & "*" & lpcH)
                If sResult Then
                    'Καθαρισμός Controls
                    Cls.ClearCtrls(LayoutControl1)
                    Me.Vw_TANKTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_TANK, System.Guid.Parse(sBdgID))
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCode.Text = DBQ.GetNextId("TANK")
                    cboBDG.EditValue = System.Guid.Parse(sBdgID)
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdRefreshMeasurement_Click(sender As Object, e As EventArgs) Handles cmdRefreshMeasurement.Click
        Me.Vw_TANKTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_TANK, System.Guid.Parse(sBdgID))
    End Sub

    Private Sub cmdDeleteMeasurement_Click(sender As Object, e As EventArgs) Handles cmdDeleteMeasurement.Click
        DeleteRecord()
    End Sub

    Private Sub cmdAddMeasurement_Click(sender As Object, e As EventArgs) Handles cmdAddMeasurement.Click
        Cls.ClearCtrls(LayoutControl1)
        cboBDG.EditValue = System.Guid.Parse(sBdgID)
        dtMeasurement.EditValue = Date.Now
    End Sub


    Private Sub GridView3_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView3.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView3, "TANK_def.xml", "vw_TANK")
    End Sub

    Private Sub GridView3_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles GridView3.ValidatingEditor
        Try
            If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "invOilID").ToString.Length > 0 Then
                e.ErrorText = "Δεν μπορείς να τροποποιήσεις εγγραφή που αφορά παραστατικό Αγοράς πετρελάιου"
                e.Valid = False
            End If

            If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            Dim sSQL As String
            Dim mes As Double, mesB As Double, liters As Double, litersB As Double
            If sender.GetRowCellValue(sender.FocusedRowHandle, "mes") Is DBNull.Value Then
                mes = 0
            Else
                mes = sender.GetRowCellValue(sender.FocusedRowHandle, "mes")
            End If
            If sender.GetRowCellValue(sender.FocusedRowHandle, "mesB") Is DBNull.Value Then
                mesB = 0
            Else
                mesB = sender.GetRowCellValue(sender.FocusedRowHandle, "mesB")
            End If
            liters = mes * lpcH : litersB = mesB * lpcH

            sender.SetRowCellValue(sender.FocusedRowHandle, "liters", liters)
            sender.SetRowCellValue(sender.FocusedRowHandle, "litersB", litersB)
            sSQL = "UPDATE  TANK SET " &
                        " measurementcatID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "measurementcatID").ToString) &
                        " ,usrID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "usrID").ToString) &
                        ",mes = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "mes").ToString, True) &
                        ",mesB = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "mesB").ToString, True) &
                        ",liters = " & toSQLValueS(liters.ToString, True) &
                        ",litersB = " & toSQLValueS(litersB.ToString, True) &
                        ",dtMeasurement = " & toSQLValueS(CDate(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "dtMeasurement")).ToString("yyyyMMdd")) &
                        " WHERE ID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString)

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView3.KeyDown
        If e.KeyCode = Keys.Delete And UserProps.AllowDelete = True Then DeleteRecord()
    End Sub
    Private Function DeleteRecord() As Boolean
        Dim sSQL As String
        Try
            If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID") = Nothing Then Return False
            If GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "invOilID").ToString.Length > 0 Then
                XtraMessageBox.Show("Δεν μπορείς να διαγράψεις εγγραφή που αφορά παραστατικό Αγοράς πετρελάιου", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
            If XtraMessageBox.Show("Θέλετε να διαγραφή η εγγραφή ?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM TANK  WHERE ID = " & toSQLValueS(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "ID").ToString)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Me.Vw_TANKTableAdapter.FillByBdgID(Me.Priamos_NET_DataSet_BDG.vw_TANK, System.Guid.Parse(sBdgID))
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try




    End Function
End Class