Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports DevExpress.CodeParser
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraExport.Xls
Public Class frmGen
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private CtrlCombo As DevExpress.XtraEditors.LookUpEdit
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private CalledFromCtrl As Boolean
    Private Valid As New ValidateControls
    Private Log As New Transactions
    Private DBQ As New DBQueries
    Private FillCbo As New FillCombos
    Private sDataTable As String
    Private S As New System.Text.StringBuilder
    Private Cls As New ClearControls
    Private LoadForms As New FormLoader

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
    Public WriteOnly Property CalledFromControl As Boolean
        Set(value As Boolean)
            CalledFromCtrl = value
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
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        My.Settings.frmGen = Me.Location
        My.Settings.Save()
    End Sub

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Mode = FormMode.NewRecord
        Cls.ClearCtrls(LayoutControl1)
        LoadGen()
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
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "COU", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.COU(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_COU")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("COU")
                            Case "AREAS"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "AREAS", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.AREAS(CtrlCombo, S)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_AREAS")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("AREAS")
                            Case "ADR"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "ADR", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.ADR(CtrlCombo, S)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_ADR")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("ADR")
                            Case "DOY"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "DOY", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.DOY(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_DOY")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("DOY")
                            Case "PRF"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "PRF", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.PRF(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_PRF")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("PRF")
                            Case "HTYPES"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "HTYPES", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.HTYPES(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_HTYPES")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("HTYPES")
                            Case "BTYPES"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "BTYPES", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.HTYPES(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_BTYPES")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("BTYPES")
                            Case "FTYPES"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "FTYPES", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.FTYPES(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_FTYPES")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("FTYPES")
                            Case "CALC_TYPES"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "CALC_TYPES", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.CALC_TYPES(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_CALC_TYPES")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("CALC_TYPES")
                            Case "MLC"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "MLC", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.MLC(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_MLC")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("MLC")
                            Case "TECH_CAT"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "TECH_CAT", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.TECH_CAT(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_TECH_CAT")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("TECH_CAT")
                            Case "CALC_CAT"
                                sGuid = System.Guid.NewGuid.ToString
                                sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "CALC_CAT", LayoutControl1,,, sGuid, True)
                                If CalledFromCtrl Then
                                    FillCbo.CALC_CAT(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sGuid)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_CALC_CAT")
                                End If
                                'Καθαρισμός Controls
                                Cls.ClearCtrls(LayoutControl1)
                                txtCode.Text = DBQ.GetNextId("CALC_CAT")
                        End Select
                    Case FormMode.EditRecord
                        Select Case sDataTable
                            Case "COU"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "COU", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.COU(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_COU")
                                End If
                            Case "AREAS"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "AREAS", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.AREAS(CtrlCombo, S)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_AREAS")
                                End If
                            Case "ADR"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "ADR", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.ADR(CtrlCombo, S)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_ADR")
                                End If
                            Case "DOY"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "DOY", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.DOY(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_DOY")
                                End If
                            Case "PRF"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "PRF", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.PRF(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_PRF")
                                End If
                            Case "HTYPES"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "HTYPES", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.HTYPES(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_HTYPES")
                                End If
                            Case "BTYPES"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "BTYPES", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.HTYPES(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_BTYPES")
                                End If
                            Case "FTYPES"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "FTYPES", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.FTYPES(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_FTYPES")
                                End If
                            Case "CALC_TYPES"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "CALC_TYPES", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.CALC_TYPES(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_CALC_TYPES")
                                End If
                            Case "MLC"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "MLC", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.MLC(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_MLC")
                                End If
                            Case "TECH_CAT"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "TECH_CAT", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.TECH_CAT(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_TECH_CAT")
                                End If
                            Case "CALC_CAT"
                                sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "CALC_CAT", LayoutControl1,,, sID, True)
                                If CalledFromCtrl Then
                                    FillCbo.CALC_CAT(CtrlCombo)
                                    CtrlCombo.EditValue = System.Guid.Parse(sID)
                                Else
                                    Dim form As New frmScroller
                                    form = Frm
                                    form.LoadRecords("vw_CALC_CAT")
                                End If
                        End Select
                End Select
                If sResult Then
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If

            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadGen()
        Try
            Select Case sDataTable
                Case "COU"
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("COU")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_COU where id ='" + sID + "'", True)
                    End If
                Case "AREAS"
                    FillCbo.COU(cbo1)
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("AREAS")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_AREAS where id ='" + sID + "'", True)
                    End If
                Case "ADR"
                    FillCbo.COU(cbo1)
                    Dim sSQL As New System.Text.StringBuilder
                    FillCbo.AREAS(cbo2, sSQL)
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("ADR")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_ADR where id ='" + sID + "'", True)
                    End If
                Case "DOY"
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("DOY")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_DOY where id ='" + sID + "'", True)
                    End If
                Case "PRF"
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("PRF")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_PRF where id ='" + sID + "'", True)
                    End If
                Case "HTYPES"
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("HTYPES")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_HTYPES where id ='" + sID + "'", True)
                    End If
                Case "BTYPES"
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("BTYPES")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_BTYPES where id ='" + sID + "'", True)
                    End If
                Case "FTYPES"
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("FTYPES")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_FTYPES where id ='" + sID + "'", True)
                    End If
                Case "CALC_TYPES"
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("CALC_TYPES")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_CALC_TYPES where id ='" + sID + "'", True)
                    End If
                Case "MLC"
                    ' FillCbo.CALC_TYPES(cbo1)
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("MLC")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_MLC where id ='" + sID + "'", True)
                    End If
                Case "TECH_CAT"
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("TECH_CAT")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_TECH_CAT where id ='" + sID + "'", True)
                    End If
                Case "CALC_CAT"
                    FillCbo.CALC_TYPES(cbo1)
                    If Mode = FormMode.NewRecord Then
                        txtCode.Text = DBQ.GetNextId("CALC_CAT")
                    Else
                        LoadForms.LoadForm(LayoutControl1, "Select * from vw_CALC_CAT where id ='" + sID + "'", True)
                    End If
            End Select
            cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
            cmdDelete.Enabled = IIf(Mode = FormMode.NewRecord, False, UserProps.AllowDelete)
            txtName.Select()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                    Case "COU"
                        If CalledFromCtrl Then
                            FillCbo.COU(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_COU")
                        End If
                    Case "AREAS"
                        If CalledFromCtrl Then
                            FillCbo.AREAS(CtrlCombo, S)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_AREAS")
                        End If
                    Case "ADR"
                        If CalledFromCtrl Then
                            FillCbo.ADR(CtrlCombo, S)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_ADR")
                        End If
                    Case "DOY"
                        If CalledFromCtrl Then
                            FillCbo.DOY(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_DOY")
                        End If
                    Case "PRF"
                        If CalledFromCtrl Then
                            FillCbo.PRF(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_PRF")
                        End If
                    Case "HTYPES"
                        If CalledFromCtrl Then
                            FillCbo.HTYPES(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_HTYPES")
                        End If
                    Case "BTYPES"
                        If CalledFromCtrl Then
                            FillCbo.BTYPES(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_BTYPES")
                        End If
                    Case "FTYPES"
                        If CalledFromCtrl Then
                            FillCbo.FTYPES(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_FTYPES")
                        End If
                    Case "CALC_TYPES"
                        If CalledFromCtrl Then
                            FillCbo.CALC_TYPES(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_CALC_TYPES")
                        End If
                    Case "MLC"
                        If CalledFromCtrl Then
                            FillCbo.MLC(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_MLC")
                        End If
                    Case "TECH_CAT"
                        If CalledFromCtrl Then
                            FillCbo.TECH_CAT(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_TECH_CAT")
                        End If
                    Case "CALC_CAT"
                        If CalledFromCtrl Then
                            FillCbo.CALC_CAT(CtrlCombo)
                        Else
                            Dim form As New frmScroller
                            form.LoadRecords("vw_CALC_CAT")
                        End If
                End Select
                Cls.ClearCtrls(LayoutControl1)
                txtCode.Text = DBQ.GetNextId(sDataTable)
                If CalledFromCtrl Then CtrlCombo.EditValue = Nothing

                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbo1_GotFocus(sender As Object, e As EventArgs) Handles cbo1.GotFocus
        frmMain.bbFields.Caption = "DB Field: " & sDataTable & ".couid"
    End Sub

    Private Sub cbo2_GotFocus(sender As Object, e As EventArgs) Handles cbo2.GotFocus
        frmMain.bbFields.Caption = "DB Field: " & sDataTable & ".areaid"
    End Sub

    Private Sub txtCode_GotFocus(sender As Object, e As EventArgs) Handles txtCode.GotFocus
        frmMain.bbFields.Caption = "DB Field: " & sDataTable & ".code"
    End Sub

    Private Sub txtName_GotFocus(sender As Object, e As EventArgs) Handles txtName.GotFocus
        frmMain.bbFields.Caption = "DB Field: " & sDataTable & ".name"
    End Sub

    Private Sub frmGen_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub frmGen_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub


    Private Sub cbo1_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cbo1.ButtonPressed
        cbo1.EditValue = Nothing
    End Sub
End Class