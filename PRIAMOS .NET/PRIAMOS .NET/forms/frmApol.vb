Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

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
        Me.Vw_BDGTableAdapter.FillByIsNotManaged(Me.Priamos_NETDataSet.vw_BDG)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("APOL")
                cboWorkshop.EditValue = System.Guid.Parse(ProgProps.ADM)
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_APOL where id ='" + sID + "'")
        End Select
        ' Valid.AddControlsForCheckIfSomethingChanged(LayoutControl1)
        Me.CenterToScreen()
        My.Settings.Save()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Dim sSQL As New System.Text.StringBuilder
        Try
            If Valid.ValidateForm(LayoutControl1) Then

                Select Case Mode
                    Case FormMode.NewRecord
                        Dim sGuid As String = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "APOL", LayoutControl1,,, sGuid)
                        sSQL.AppendLine("INSERT INTO COL_EXT(bdgid,apolID,credit,debit,bal,ColMethodID,dtdebit)")
                        sSQL.AppendLine("VALUES( " & toSQLValueS(cboBDG.EditValue.ToString) & "," & toSQLValueS(sGuid) & ",0," &
                                        toSQLValue(txtAmt, True) & "," & toSQLValue(txtAmt, True) & "," & toSQLValueS("75E3251D-077D-42B0-B79A-9F2886381A97") & ",getdate())")
                        'Εκτέλεση QUERY
                        Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using

                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "APOL", LayoutControl1,,, sID)
                End Select
                If sResult Then XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub frmApol_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cboBDG_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboBDG.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboBDG.EditValue = Nothing : ManageBDG(cboBDG)
            Case 2 : If cboBDG.EditValue <> Nothing Then ManageBDG(cboBDG)
            Case 3 : cboBDG.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageBDG(ByVal cbo As DevExpress.XtraEditors.LookUpEdit)
        Dim form1 As frmBDG = New frmBDG()
        form1.Text = "Πολυκατοικία"
        form1.CallerControl = cbo
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        If cbo.EditValue <> Nothing Then
            form1.ID = cbo.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub cboWorkshop_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboWorkshop.ButtonPressed
        Select Case e.Button.Index
            Case 1 : cboWorkshop.EditValue = Nothing : ManageWokshop(False)
            Case 2 : If cboWorkshop.EditValue <> Nothing Then ManageWokshop(False)
            Case 3 : cboWorkshop.EditValue = Nothing
        End Select

    End Sub
    Private Sub ManageWokshop(ByVal isFromGrid As Boolean, Optional ByRef RecID As String = "")
        Dim form1 As frmCustomers = New frmCustomers()
        form1.Text = "Συνεργεία"
        If isFromGrid = False Then
            form1.CallerControl = cboWorkshop
            form1.CalledFromControl = True
            If cboWorkshop.EditValue <> Nothing Then
                form1.ID = cboWorkshop.EditValue.ToString
                form1.Mode = FormMode.EditRecord
            Else
                form1.Mode = FormMode.NewRecord
                form1.chkWorkshop.Checked = True
                form1.chkPrivate.Checked = False
            End If
        End If
        form1.ShowDialog()
    End Sub

End Class