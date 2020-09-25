Imports System.Data.SqlClient
Imports System.IO
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

        Select Case sDataTable
            Case "COU"
                If Mode = FormMode.NewRecord Then
                    txtID.Text = DBQ.GetNextId("COU")
                    cmdSave.Enabled = UserProps.AllowInsert
                Else
                    Dim cmd As SqlCommand = New SqlCommand("Select * from vw_COU where id ='" + sID + "'", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        If sdr.IsDBNull(sdr.GetOrdinal("code")) = False Then txtID.Text = sdr.GetInt32(sdr.GetOrdinal("code"))
                        If sdr.IsDBNull(sdr.GetOrdinal("name")) = False Then txtName.Text = sdr.GetString(sdr.GetOrdinal("name"))
                        sdr.Close()
                    End If
                    cmdSave.Enabled = UserProps.AllowEdit
                End If

            Case "AREAS"
                If Mode = FormMode.NewRecord Then
                    txtID.Text = DBQ.GetNextId("AREAS")
                    FillCbo.COU(cbo1)
                    cmdSave.Enabled = UserProps.AllowInsert
                Else
                    Dim cmd As SqlCommand = New SqlCommand("Select * from vw_AREAS where id ='" + sID + "'", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        If sdr.IsDBNull(sdr.GetOrdinal("code")) = False Then txtID.Text = sdr.GetInt32(sdr.GetOrdinal("code"))
                        If sdr.IsDBNull(sdr.GetOrdinal("name")) = False Then txtName.Text = sdr.GetString(sdr.GetOrdinal("name"))
                        If sdr.IsDBNull(sdr.GetOrdinal("COUID")) = False Then cbo1.EditValue = sdr.GetGuid(sdr.GetOrdinal("COUID"))
                        sdr.Close()
                    End If
                    cmdSave.Enabled = UserProps.AllowEdit
                End If
            Case "ADR"
                If Mode = FormMode.NewRecord Then
                    txtID.Text = DBQ.GetNextId("ADR")
                    FillCbo.COU(cbo1)
                    FillCbo.AREAS(cbo2)
                    cmdSave.Enabled = UserProps.AllowInsert
                Else
                    Dim cmd As SqlCommand = New SqlCommand("Select * from vw_ADR where id ='" + sID + "'", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        If sdr.IsDBNull(sdr.GetOrdinal("code")) = False Then txtID.Text = sdr.GetInt32(sdr.GetOrdinal("code"))
                        If sdr.IsDBNull(sdr.GetOrdinal("name")) = False Then txtName.Text = sdr.GetString(sdr.GetOrdinal("name"))
                        If sdr.IsDBNull(sdr.GetOrdinal("COUID")) = False Then cbo1.EditValue = sdr.GetGuid(sdr.GetOrdinal("COUID"))
                        If sdr.IsDBNull(sdr.GetOrdinal("AREAID")) = False Then cbo2.EditValue = sdr.GetGuid(sdr.GetOrdinal("AREAID"))
                        sdr.Close()
                    End If
                    cmdSave.Enabled = UserProps.AllowEdit
                End If
        End Select

    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Mode = FormMode.NewRecord
        Select Case sDataTable
            Case "COU" : txtID.Text = DBQ.GetNextId("COU")
            Case "AREAS" : txtID.Text = DBQ.GetNextId("AREAS")
            Case "ADR" : txtID.Text = DBQ.GetNextId("ADR")
        End Select
        txtName.Text = ""
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sSQL As String
        Dim sGuid As String
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        Select Case sDataTable
                            Case "COU"
                                sGuid = System.Guid.NewGuid.ToString
                                sSQL = "INSERT INTO COU ([ID],[NAME],[modifiedBy],[createdOn]) " &
                                        "values (" & toSQLValueS(sGuid) & "," &
                                                 toSQLValue(txtName) & "," &
                                                 toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                                Using oCmd As New SqlCommand(sSQL, CNDB)
                                    oCmd.ExecuteNonQuery()
                                End Using
                                FillCbo.COU(CtrlCombo)
                                CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                txtName.Text = ""
                                txtID.Text = DBQ.GetNextId("COU")
                            Case "AREAS"
                                sGuid = System.Guid.NewGuid.ToString
                                sSQL = "INSERT INTO AREAS ([ID],[NAME],[COUID], [modifiedBy],[createdOn]) " &
                                        "values (" & toSQLValueS(sGuid) & "," &
                                                 toSQLValue(txtName) & "," &
                                                 toSQLValueS(cbo1.EditValue.ToString) & "," &
                                                 toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                                Using oCmd As New SqlCommand(sSQL, CNDB)
                                    oCmd.ExecuteNonQuery()
                                End Using
                                FillCbo.AREAS(CtrlCombo)
                                CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                txtName.Text = ""
                                cbo1.EditValue = Nothing
                                txtID.Text = DBQ.GetNextId("AREAS")
                            Case "ADR"
                                sGuid = System.Guid.NewGuid.ToString
                                sSQL = "INSERT INTO ADR ([ID],[NAME],[COUID],[AREAID], [modifiedBy],[createdOn]) " &
                                        "values (" & toSQLValueS(sGuid) & "," &
                                                 toSQLValue(txtName) & "," &
                                                 toSQLValueS(cbo1.EditValue.ToString) & "," &
                                                 toSQLValueS(cbo2.EditValue.ToString) & "," &
                                                 toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                                Using oCmd As New SqlCommand(sSQL, CNDB)
                                    oCmd.ExecuteNonQuery()
                                End Using
                                Dim S As New System.Text.StringBuilder
                                FillCbo.ADR(CtrlCombo, S)
                                CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                txtName.Text = ""
                                cbo1.EditValue = Nothing
                                cbo2.EditValue = Nothing
                                txtID.Text = DBQ.GetNextId("ADR")

                        End Select


                    Case FormMode.EditRecord
                        Select Case sDataTable
                            Case "COU"
                                sSQL = "UPDATE COU set [NAME] =  " & toSQLValue(txtName) & "," &
                                       "modifiedBy = " & toSQLValueS(UserProps.ID.ToString) &
                                       " where id = '" & sID & "'"
                                Using oCmd As New SqlCommand(sSQL, CNDB)
                                    oCmd.ExecuteNonQuery()
                                End Using
                                FillCbo.COU(CtrlCombo)
                                CtrlCombo.EditValue = System.Guid.Parse(sID)
                            Case "AREAS"
                                sSQL = "UPDATE AREAS set [NAME] =  " & toSQLValue(txtName) & "," &
                                       "COUID = " & toSQLValueS(cbo1.EditValue.ToString) & "," &
                                       "modifiedBy = " & toSQLValueS(UserProps.ID.ToString) & "," &
                                       " where id = '" & sID & "'"
                                Using oCmd As New SqlCommand(sSQL, CNDB)
                                    oCmd.ExecuteNonQuery()
                                End Using
                                FillCbo.AREAS(CtrlCombo)
                                CtrlCombo.EditValue = System.Guid.Parse(sID)

                            Case "ADR"
                                sSQL = "UPDATE ADR set [NAME] =  " & toSQLValue(txtName) & "," &
                                       "COUID = " & toSQLValueS(cbo1.EditValue.ToString) & "," &
                                       "AREAID = " & toSQLValueS(cbo2.EditValue.ToString) & "," &
                                       "modifiedBy = " & toSQLValueS(UserProps.ID.ToString) & "," &
                                       " where id = '" & sID & "'"
                                Using oCmd As New SqlCommand(sSQL, CNDB)
                                    oCmd.ExecuteNonQuery()
                                End Using
                                Dim S As New System.Text.StringBuilder
                                FillCbo.ADR(CtrlCombo, S)
                                CtrlCombo.EditValue = System.Guid.Parse(sID)
                        End Select

                End Select

                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class