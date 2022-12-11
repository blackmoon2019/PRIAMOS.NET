Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmColExt
    Private sID As String
    Private sApolID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Private UserPermissions As New CheckPermissions
    Private ManageCbo As New CombosManager
    Dim sGuid As String
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property ApolID As String
        Set(value As String)
            sApolID = value
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

    Private Sub frmColExt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet31.vw_COL_EXT_TYPES' table. You can move, or remove it, as needed.
        Me.Vw_COL_EXT_TYPESTableAdapter.Fill(Me.Priamos_NETDataSet31.vw_COL_EXT_TYPES)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet3.vw_PROF_ACT' table. You can move, or remove it, as needed.
        Me.Vw_PROF_ACTTableAdapter.Fill(Me.Priamos_NETDataSet3.vw_PROF_ACT)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BANKS' table. You can move, or remove it, as needed.
        Me.Vw_BANKSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BANKS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COL_METHOD' table. You can move, or remove it, as needed.
        Me.Vw_COL_METHODTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COL_METHOD)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.FillByIsNotManaged(Me.Priamos_NETDataSet.vw_BDG)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.Collectors' table. You can move, or remove it, as needed.
        Me.CollectorsTableAdapter.Fill(Me.Priamos_NETDataSet.Collectors)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("COL_EXT")
                dtCredit.EditValue = Date.Now
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_COL_EXT where id = " & toSQLValueS(sID))
                If sApolID.Length <> 0 Then
                    cboBDG.ReadOnly = True
                    cboApt.ReadOnly = True
                End If
        End Select
        ' Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        UserPermissions.GetUserPermissions(Me.Text)

        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue = Nothing Then Exit Sub
        Me.Vw_APTTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_APT, System.Guid.Parse(cboBDG.EditValue.ToString))
    End Sub

    Private Sub frmColExt_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "COL_EXT", LayoutControl1,,, sGuid,, "credit,bal,creditusrID,dtDebit",
                                    toSQLValue(txtDebit, True) & "," & toSQLValue(txtDebit, True) & "," & toSQLValueS(UserProps.ID.ToString) & ",getdate()")
                    Case FormMode.EditRecord
                        If sApolID = Nothing Then
                            sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "COL_EXT", LayoutControl1,,, sID,,,,,
                                "credit=" & toSQLValue(txtDebit, True) & ",bal=" & toSQLValue(txtDebit, True) & ",creditusrID=" & toSQLValueS(UserProps.ID.ToString) & ",dtDebit=getdate()")
                        Else
                            sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "COL_EXT", LayoutControl1,,, sID,,,,,
                                "bal=bal - " & toSQLValue(txtDebit, True) & ",creditusrID=" & toSQLValueS(UserProps.ID.ToString) & ",dtDebit=getdate()")
                        End If
                End Select
                If sResult Then
                    'Καθαρισμός Controls
                    If Mode = FormMode.NewRecord Then Cls.ClearCtrls(LayoutControl1)
                    txtCode.Text = DBQ.GetNextId("COL_EXT")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmColExt_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Valid.SChanged Then
            If XtraMessageBox.Show("Έχουν γίνει αλλάγές στην φόρμα που δεν έχετε σώσει.Αν προχωρήσετε οι αλλαγές σας θα χαθούν", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Valid.SChanged = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub cboProfAct_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboProfAct.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManagePROFACT(cboProfAct, FormMode.NewRecord, Me)
            Case 2 : ManageCbo.ManagePROFACT(cboProfAct, FormMode.EditRecord, Me)
            Case 3 : cboProfAct.EditValue = Nothing
        End Select
    End Sub
    Private Sub cboBDG_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageBDG(cboBDG, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageBDG(cboBDG, FormMode.EditRecord)
            Case 3 : cboBDG.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboCollector_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboCollector.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageUSR(cboCollector, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageUSR(cboCollector, FormMode.EditRecord)
            Case 3 : cboCollector.EditValue = Nothing
        End Select

    End Sub
    Private Sub cboColMethod_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboColMethod.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageColMethod(cboColMethod, FormMode.NewRecord, Me)
            Case 2 : ManageCbo.ManageColMethod(cboColMethod, FormMode.EditRecord, Me)
            Case 3 : cboColMethod.EditValue = Nothing
        End Select
    End Sub


    Private Sub cboAPT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboApt.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageAPT(cboApt, FormMode.NewRecord, cboBDG.EditValue.ToString)
            Case 2 : ManageCbo.ManageAPT(cboApt, FormMode.EditRecord, cboBDG.EditValue.ToString)
            Case 3 : cboApt.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboBank_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboBank.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageBANK(cboBank, FormMode.NewRecord, Me)
            Case 2 : ManageCbo.ManageBANK(cboBank, FormMode.EditRecord, Me)
            Case 3 : cboBank.EditValue = Nothing
        End Select
    End Sub


    Private Sub cboColMethod_EditValueChanged(sender As Object, e As EventArgs) Handles cboColMethod.EditValueChanged
        If cboColMethod.EditValue Is Nothing Then Exit Sub
        If cboColMethod.EditValue.ToString.ToUpper = "F34B402C-ADD8-48E7-85A9-FFDF7DAED582" Then cboBank.ReadOnly = False Else cboBank.ReadOnly = True : cboBank.EditValue = Nothing
    End Sub


    Private Sub cboColExtType_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboColExtType.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageColExtTypes(cboColExtType, FormMode.NewRecord, Me)
            Case 2 : ManageCbo.ManageColExtTypes(cboColExtType, FormMode.EditRecord, Me)
            Case 3 : cboColExtType.EditValue = Nothing
        End Select
    End Sub
End Class