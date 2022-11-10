Imports DevExpress.XtraEditors

Public Class frmIEP
    Private sID As String
    Private sBDGID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private Log As New Transactions
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Dim sGuid As String
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
    Public WriteOnly Property BDGID As String
        Set(value As String)
            sBDGID = value
        End Set
    End Property
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmIEP_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sSQL As New System.Text.StringBuilder
        'Τυύποι υπολογισμών
        FillCbo.CALC_CAT(cboCaclCat)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("IEP")
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_IEP where id ='" + sID + "'")
        End Select
        ' Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        My.Settings.frmEXP = Me.Location
        My.Settings.Save()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "IEP", LayoutControl1,,,,, "bdgid", toSQLValueS(sBDGID))
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "IEP", LayoutControl1,,, sID)
                End Select
                If sResult Then
                    If Mode = FormMode.NewRecord Then
                        Cls.ClearCtrls(LayoutControl1)
                        txtCode.Text = DBQ.GetNextId("IEP")
                    End If


                    Dim form As frmBDG = Frm
                    form.LoadIEP()
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Valid.SChanged = False
                    txtrepname.Select()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class