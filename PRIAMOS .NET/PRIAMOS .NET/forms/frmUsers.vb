Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmUsers
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
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
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sSQL As String
        Try
            Select Case Mode
                Case FormMode.NewRecord
                    sSQL = "INSERT INTO USR ([UN],[PWD],[REALNAME]) " &
                            "values (" & toSQLValue(txtUN) & "," &
                                         toSQLValue(txtPWD) & "," &
                                         toSQLValue(txtRealName) & ")"
                Case FormMode.EditRecord
                    If Valid.ValidateForm(LayoutControl1) Then
                        sSQL = "UPDATE USR set UN =  " & toSQLValue(txtUN) & "," &
                               "PWD = " & toSQLValue(txtPWD) & "," &
                               "RealName = " & toSQLValue(txtRealName) &
                               " where id = '" & sID & "'"
                    End If
            End Select
            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
                Dim form As frmScroller = Frm
                form.LoadRecords("vw_USR")
                XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Mode = FormMode.EditRecord Then
                Dim cmd As SqlCommand = New SqlCommand("Select * from vw_USR where id ='" + sID + "'", CNDB)
                Dim sdr As SqlDataReader = cmd.ExecuteReader()
                If (sdr.Read() = True) Then
                    txtUN.Text = sdr.GetString(sdr.GetOrdinal("un"))
                    txtPWD.Text = sdr.GetString(sdr.GetOrdinal("pwd"))
                    txtRealName.Text = sdr.GetString(sdr.GetOrdinal("realname"))
                    sdr.Close()
                End If
            End If
            Me.CenterToScreen()
            My.Settings.frmUsers = Me.Location
            My.Settings.Save()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmUsers_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class