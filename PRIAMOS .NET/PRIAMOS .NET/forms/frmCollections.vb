Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public Class frmCollections
    Private sID As String, sbdgID As String, sinhID As String
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
    Public WriteOnly Property BDGID As String
        Set(value As String)
            sbdgID = value
        End Set
    End Property
    Public WriteOnly Property INHID As String
        Set(value As String)
            sinhID = value
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
    Private Sub cmdExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmCollections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet1.vw_BDG' table. You can move, or remove it, as needed.
        Me.Vw_BDGTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BDG)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_USR' table. You can move, or remove it, as needed.
        Me.Vw_USRTableAdapter.Fill(Me.Priamos_NETDataSet.vw_USR)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BANKS' table. You can move, or remove it, as needed.
        Me.Vw_BANKSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BANKS)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COL_METHOD' table. You can move, or remove it, as needed.
        Me.Vw_COL_METHODTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COL_METHOD)
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COL' table. You can move, or remove it, as needed.
        Me.Vw_COLTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COL)
        If sbdgID <> Nothing Then
            cboBDG.EditValue = System.Guid.Parse(sbdgID)
            cboINH.EditValue = System.Guid.Parse(sinhID)
        End If
        Me.CenterToScreen()
        My.Settings.frmCollections = Me.Location
        My.Settings.Save()

        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\COLLECTIONS_def.xml") = False Then
            GridView5.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\COLLECTIONS_def.xml", OptionsLayoutBase.FullLayout)
        End If
        GridView5.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\COLLECTIONS_def.xml", OptionsLayoutBase.FullLayout)

    End Sub

    Private Sub frmCollections_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cboBDG_EditValueChanged(sender As Object, e As EventArgs) Handles cboBDG.EditValueChanged
        If cboBDG.EditValue <> Nothing Then
            Me.Vw_COLTableAdapter.FillByBDG(Me.Priamos_NETDataSet.vw_COL, System.Guid.Parse(cboBDG.EditValue.ToString))
            Me.Vw_INHTableAdapter.Fill(Me.Priamos_NETDataSet.vw_INH, System.Guid.Parse(cboBDG.EditValue.ToString))
        End If
    End Sub

    Private Sub cmdExit_Click_1(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView5.CellValueChanged
        Try
            Dim sSQL As String, dtcredit As String
            Dim credit As Decimal, debit As Decimal, bal As Decimal

            If GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "dtCredit") Is DBNull.Value Then
                dtcredit = "NULL"
            Else
                dtcredit = toSQLValueS(CDate(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "dtCredit")).ToString("yyyyMMdd"))
            End If
            If GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "debit") Is DBNull.Value Then
                debit = 0
            Else
                debit = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "debit")
            End If
            If GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "credit") Is DBNull.Value Then
                credit = 0
            Else
                credit = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "credit")
            End If
            If GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "bal") Is DBNull.Value Then
                bal = 0
            Else
                bal = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "bal")
            End If

            If e.Column.FieldName = "credit" Then
                bal = debit - credit
                GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "bal", bal)
            End If


            sSQL = "UPDATE [COL] SET ColMethodID  = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ColMethodID").ToString) &
                ",bankID  = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "bankID").ToString) &
                ",usrID  = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "usrID").ToString) &
                ",dtcredit  = " & dtcredit &
                ",credit = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "credit"), True) &
                ",bal = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "bal"), True) &
        " WHERE ID = " & toSQLValueS(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "ID").ToString)
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RepositoryCOL_METHOD_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryCOL_METHOD.ButtonPressed
        Select Case e.Button.Index
            Case 1 : GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "ColMethodID", "")
        End Select
    End Sub

    Private Sub RepositoryUSR_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryUSR.ButtonPressed
        Select Case e.Button.Index
            Case 1 : GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "usrID", "")
        End Select
    End Sub

    Private Sub RepositoryBANK_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryBANK.ButtonPressed
        Select Case e.Button.Index
            Case 1 : GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "bankID", "")
        End Select
    End Sub

    Private Sub cboINH_EditValueChanged(sender As Object, e As EventArgs) Handles cboINH.EditValueChanged
        Me.Vw_COLTableAdapter.FillByINH(Me.Priamos_NETDataSet.vw_COL, System.Guid.Parse(cboINH.EditValue.ToString))
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
End Class