Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraLayout

Public Class frmAPT
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

    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property BDGID As String
        Set(value As String)
            sBDGID = value
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

    Private Sub frmAPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sSQL As New System.Text.StringBuilder
        'Ένοικοι
        FillCbo.CCT(cboTenant)
        'Ιδιοκτήτες
        FillCbo.CCT(cboOwner)
        'Ορόφοι
        FillCbo.FLR(cboFloor)
        'Πολυκατοικίες  
        sSQL.AppendLine(" where ID = " & toSQLValueS(sBDGID))
        FillCbo.BDG(cboBDG, sSQL)
        cboBDG.EditValue = System.Guid.Parse(sBDGID)
        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("APT")
            Case FormMode.EditRecord
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_APT where id ='" + sID + "'")
        End Select
        Me.CenterToScreen()
        My.Settings.frmAPT = Me.Location
        My.Settings.Save()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub frmAPT_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Dim sAptID As String
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sAptID = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "APT", LayoutControl1,,, sAptID)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "APT", LayoutControl1,,, sID)
                End Select
                If sResult Then
                    If Mode = FormMode.NewRecord Then
                        ' Καταχώρηση μιας γραμμής για τα χιλιοστά
                        Dim sSQL As String = "INSERT INTO APMIL ([BDGID],[APTID],[modifiedBy],[createdOn])  
                                        values (" & toSQLValueS(sBDGID) & "," & toSQLValueS(sAptID) & "," &
                                                        toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using
                    End If
                    'Καθαρισμός Controls
                    If Mode = FormMode.NewRecord Then Cls.ClearCtrls(LayoutControl1)
                        txtCode.Text = DBQ.GetNextId("APT")
                        Dim form As frmBDG = Frm
                        form.AptRefresh()
                        XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ManageTenant()
        Dim form1 As frmCustomers = New frmCustomers()
        form1.Text = "Επαφές"
        form1.CallerControl = cboTenant
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        If cboTenant.EditValue <> Nothing Then
            form1.ID = cboTenant.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub ManageOwner()
        Dim form1 As frmCustomers = New frmCustomers()
        form1.Text = "Επαφές"
        form1.CallerControl = cboOwner
        form1.CalledFromControl = True
        form1.MdiParent = frmMain
        If cboOwner.EditValue <> Nothing Then
            form1.ID = cboOwner.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub cboTenant_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboTenant.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageTenant()
            Case 2 : cboTenant.EditValue = Nothing
        End Select
    End Sub

    Private Sub cboOwner_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles cboOwner.ButtonPressed
        Select Case e.Button.Index
            Case 1 : ManageOwner()
            Case 2 : cboOwner.EditValue = Nothing
        End Select
    End Sub
    'Private Sub LoadAPT()
    '    Dim sSQL As String
    '    Dim myConn As SqlConnection
    '    Dim myCmd As SqlCommand
    '    Dim myReader As SqlDataReader

    '    myCmd = CNDB.CreateCommand
    '    myCmd.CommandText = sSQL
    '    GridView1.Columns.Clear()
    '    myReader = myCmd.ExecuteReader()
    '    grdMain.DataSource = myReader
    '    grdMain.DefaultView.PopulateColumns()

    '    'Εαν δεν έχει data το Dataset αναγκαστικά προσθέτω μόνος μου τις στήλες
    '    If myReader.HasRows = False Then
    '        For i As Integer = 0 To myReader.FieldCount - 1
    '            Dim C As New GridColumn
    '            C.Name = myReader.GetName(i).ToString
    '            C.Caption = myReader.GetName(i).ToString
    '            C.Visible = True
    '            GridView1.Columns.Add(C)
    '        Next i
    '    End If
    '    LoadViews()

    '    'If grdMain.DefaultView.DataRowCount <> 0 Then myReader.Close() 'myReader.Close()
    'End Sub
End Class