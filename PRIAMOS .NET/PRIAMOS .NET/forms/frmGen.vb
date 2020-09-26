Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports DevExpress.CodeParser
Imports DevExpress.XtraEditors
Imports DevExpress.XtraExport.Xls
Public Class frmGen
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private CtrlCombo As DevExpress.XtraEditors.LookUpEdit
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private Log As New Transactions
    Private DBQ As New DBQueries
    Private FillCbo As New FillCombos
    Private sDataTable As String
    Private S As New System.Text.StringBuilder

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
    Public WriteOnly Property DataTable As String
        Set(value As String)
            sDataTable = value
        End Set
    End Property

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmGen_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadGen()
        Me.CenterToScreen()
        My.Settings.frmGen = Me.Location
        My.Settings.Save()
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Mode = FormMode.NewRecord
        LoadGen()
        txtName.Text = ""
        cbo1.EditValue = Nothing
        cbo2.EditValue = Nothing
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sGuid As String
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        Select Case sDataTable
                            Case "COU"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertData(LayoutControl1, "COU", sGuid)
                                FillCbo.COU(CtrlCombo)
                                CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                txtName.Text = ""
                                txtCode.Text = DBQ.GetNextId("COU")
                            Case "AREAS"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertData(LayoutControl1, "AREAS", sGuid)
                                FillCbo.AREAS(CtrlCombo, S)
                                CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                txtName.Text = ""
                                cbo1.EditValue = Nothing
                                txtCode.Text = DBQ.GetNextId("AREAS")
                            Case "ADR"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertData(LayoutControl1, "ADR", sGuid)
                                FillCbo.ADR(CtrlCombo, S)
                                CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                txtName.Text = ""
                                cbo1.EditValue = Nothing
                                cbo2.EditValue = Nothing
                                txtCode.Text = DBQ.GetNextId("ADR")
                        End Select
                    Case FormMode.EditRecord
                        Select Case sDataTable
                            Case "COU"
                                sResult = DBQ.UpdateData(LayoutControl1, "COU", sID)
                                FillCbo.COU(CtrlCombo)
                                CtrlCombo.EditValue = System.Guid.Parse(sID)
                            Case "AREAS"
                                sResult = DBQ.UpdateData(LayoutControl1, "AREAS", sID)
                                FillCbo.AREAS(CtrlCombo, S)
                                CtrlCombo.EditValue = System.Guid.Parse(sID)
                            Case "ADR"
                                sResult = DBQ.UpdateData(LayoutControl1, "ADR", sID)
                                FillCbo.ADR(CtrlCombo, S)
                                CtrlCombo.EditValue = System.Guid.Parse(sID)
                        End Select
                End Select
                If sResult Then XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadGen()
        Select Case sDataTable
            Case "COU"
                If Mode = FormMode.NewRecord Then
                    txtCode.Text = DBQ.GetNextId("COU")
                Else
                    Dim cmd As SqlCommand = New SqlCommand("Select * from vw_COU where id ='" + sID + "'", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        If sdr.IsDBNull(sdr.GetOrdinal("code")) = False Then txtCode.Text = sdr.GetInt32(sdr.GetOrdinal("code"))
                        If sdr.IsDBNull(sdr.GetOrdinal("name")) = False Then txtName.Text = sdr.GetString(sdr.GetOrdinal("name"))
                        sdr.Close()
                    End If
                End If

            Case "AREAS"
                FillCbo.COU(cbo1)
                If Mode = FormMode.NewRecord Then
                    txtCode.Text = DBQ.GetNextId("AREAS")
                Else
                    Dim cmd As SqlCommand = New SqlCommand("Select * from vw_AREAS where id ='" + sID + "'", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        If sdr.IsDBNull(sdr.GetOrdinal("code")) = False Then txtCode.Text = sdr.GetInt32(sdr.GetOrdinal("code"))
                        If sdr.IsDBNull(sdr.GetOrdinal("name")) = False Then txtName.Text = sdr.GetString(sdr.GetOrdinal("name"))
                        If sdr.IsDBNull(sdr.GetOrdinal("COUID")) = False Then cbo1.EditValue = sdr.GetGuid(sdr.GetOrdinal("COUID"))
                        sdr.Close()
                    End If
                End If
            Case "ADR"
                FillCbo.COU(cbo1)
                Dim sSQL As New System.Text.StringBuilder
                FillCbo.AREAS(cbo2, sSQL)
                If Mode = FormMode.NewRecord Then
                    txtCode.Text = DBQ.GetNextId("ADR")
                Else
                    Dim cmd As SqlCommand = New SqlCommand("Select * from vw_ADR where id ='" + sID + "'", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        If sdr.IsDBNull(sdr.GetOrdinal("code")) = False Then txtCode.Text = sdr.GetInt32(sdr.GetOrdinal("code"))
                        If sdr.IsDBNull(sdr.GetOrdinal("name")) = False Then txtName.Text = sdr.GetString(sdr.GetOrdinal("name"))
                        If sdr.IsDBNull(sdr.GetOrdinal("COUID")) = False Then cbo1.EditValue = sdr.GetGuid(sdr.GetOrdinal("COUID"))
                        If sdr.IsDBNull(sdr.GetOrdinal("AREAID")) = False Then cbo2.EditValue = sdr.GetGuid(sdr.GetOrdinal("AREAID"))
                        sdr.Close()
                    End If
                End If
        End Select
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
        cmdDelete.Enabled = IIf(Mode = FormMode.NewRecord, False, UserProps.AllowDelete)

    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        DeleteRecord()
    End Sub
    'Διαγραφη Εγγραφής
    Private Sub DeleteRecord()
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                sSQL = "DELETE FROM " & sDataTable & " WHERE ID = " & toSQLValueS(sID)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                Select Case sDataTable
                    Case "COU" : FillCbo.COU(CtrlCombo)
                        txtCode.Text = DBQ.GetNextId("COU")
                    Case "AREAS" : FillCbo.AREAS(CtrlCombo, S)
                        txtCode.Text = DBQ.GetNextId("AREAS")
                    Case "ADR" : FillCbo.ADR(CtrlCombo, S)
                        txtCode.Text = DBQ.GetNextId("ADR")
                End Select
                txtName.Text = ""
                cbo1.EditValue = Nothing
                cbo2.EditValue = Nothing
                CtrlCombo.EditValue = Nothing

                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class