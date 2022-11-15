Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmContacts
    Private ManageCbo As New CombosManager
    Private sID As String
    Public Mode As Byte
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Private Valid As New ValidateControls
    Private DBQ As New DBQueries
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

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cboBDG_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageBDG(cboBDG, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageBDG(cboBDG, FormMode.EditRecord)
            Case 3 : cboBDG.EditValue = Nothing
        End Select
    End Sub

    Private Sub frmContacts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_USR' table. You can move, or remove it, as needed.
        Me.Vw_USRTableAdapter.Fill(Me.Priamos_NETDataSet.vw_USR)
        Select Case Mode
            Case FormMode.NewRecord
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from CONTACTS where id ='" + sID + "'", True)
        End Select
        Me.CenterToScreen()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)

    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        Me.Vw_APTTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_APT, System.Guid.Parse(cboBDG.EditValue.ToString))
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Dim sGuid As String
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "CONTACTS", LayoutControl1,,, sGuid, True)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "CONTACTS", LayoutControl1,,, sID, True)
                End Select
                If sResult Then
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboAPT_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboAPT.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageAPT(cboAPT, FormMode.NewRecord, cboBDG.EditValue.ToString)
            Case 2 : ManageCbo.ManageAPT(cboAPT, FormMode.EditRecord, cboBDG.EditValue.ToString)
            Case 3 : cboBDG.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboUSR_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboUSR.ButtonClick
        Select Case e.Button.Index
            Case 1 : ManageCbo.ManageUSR(cboUSR, FormMode.NewRecord)
            Case 2 : ManageCbo.ManageUSR(cboUSR, FormMode.EditRecord)
            Case 3 : cboBDG.EditValue = Nothing
        End Select
    End Sub

    Private Sub frmContacts_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub
End Class