Imports DevExpress.XtraEditors

Public Class frmApol
    Private sID As String
    Private sWorkshopID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private FScrollerExist As Boolean = False
    Private Valid As New ValidateControls
    Private Log As New Transactions
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Private LoadForms As New FormLoader
    Private Cls As New ClearControls
    Private Calendar As New InitializeCalendar
    Private sColor As Integer
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property WorkshopID As String
        Set(value As String)
            sWorkshopID = value
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
    Public WriteOnly Property FormScrollerExist As Boolean
        Set(value As Boolean)
            FScrollerExist = value
        End Set
    End Property
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
    Private Sub frmApol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_APOL_TYPES' table. You can move, or remove it, as needed.
        Me.Vw_APOL_TYPESTableAdapter.Fill(Me.Priamos_NETDataSet.vw_APOL_TYPES)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_WORKSHOPS' table. You can move, or remove it, as needed.
        Me.Vw_WORKSHOPSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_WORKSHOPS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("APOL")
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_APOL where id ='" + sID + "'")
        End Select
        Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        My.Settings.Save()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then

                Select Case Mode
                    Case FormMode.NewRecord
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "APOL", LayoutControl1)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "APOL", LayoutControl1,,, sID)
                End Select
                If sResult Then XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmApol_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub
End Class