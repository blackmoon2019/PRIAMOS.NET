Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmVersions
    Private Valid As New ValidateControls
    Private LoadForms As New FormLoader
    Private DBQ As New DBQueries
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Private Cls As New ClearControls
    Public Mode As Byte
    Private sID As String


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

    Private Sub frmVersions_Load(sender As Object, e As EventArgs) Handles Me.Load
        If UserProps.ID.ToString.ToUpper <> "E9CEFD11-47C0-4796-A46B-BC41C4C3606B" Then LayoutControl1.Enabled = False


        Select Case Mode
            Case FormMode.NewRecord
                txtCode.Text = DBQ.GetNextId("PRIAMOS_VER")
                dtFDate.EditValue = Date.Now
                'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_TECH_SUP' table. You can move, or remove it, as needed.
                Me.Vw_TECH_SUPTableAdapter.FillWithNew(Me.Priamos_NETDataSet.vw_TECH_SUP)
            Case FormMode.EditRecord
                'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_TECH_SUP' table. You can move, or remove it, as needed.
                Me.Vw_TECH_SUPTableAdapter.FillBy(Me.Priamos_NETDataSet.vw_TECH_SUP)
                LoadForms.LoadForm(LayoutControl1, "Select * from vw_PRIAMOSVER where id = " & toSQLValueS(sID))
        End Select
        Me.CenterToScreen()
        cmdSave.Enabled = IIf(Mode = FormMode.NewRecord, UserProps.AllowInsert, UserProps.AllowEdit)
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        sResult = DBQ.InsertNewData(DBQueries.InsertMode.OneLayoutControl, "PRIAMOS_VER", LayoutControl1)
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateNewData(DBQueries.InsertMode.OneLayoutControl, "PRIAMOS_VER", LayoutControl1,,, sID)
                End Select
                If sResult Then
                    'Καθαρισμός Controls
                    If Mode = FormMode.NewRecord Then Cls.ClearCtrls(LayoutControl1)
                    txtCode.Text = DBQ.GetNextId("PRIAMOS_VER")
                    XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dtFDate.EditValue = Date.Now
                    Valid.SChanged = False
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sSQL As String
        Dim myValue As String = InputBox("Πληκτρολογήστε την Έκδοση", "Έκδοση", "")
        Try
            If myValue = "" Then Exit Sub
            sSQL = "Update ver set ExeVer = " & toSQLValueS(myValue) & ",DbVer = " & toSQLValueS(myValue) & ", UpdatePath='\\192.168.1.52\priamos.net\Updates\" & myValue & "\'"
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            sSQL = "insert into [dbo].[VER_HIST] (ID, ExeVer, DbVer, FilesToBeUpdated, DateUpdated) " &
                "Select  newid()," & toSQLValueS(myValue) & "," & toSQLValueS(myValue) & ",'PRIAMOS.NET.exe',getdate()"
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            sSQL = "update TECH_SUP set Builded = 1 where BuildVersion = " & toSQLValueS(myValue)
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

            If My.Computer.FileSystem.DirectoryExists("\\192.168.1.52\priamos.net\Updates\" & myValue) = False Then
                My.Computer.FileSystem.CreateDirectory("\\192.168.1.52\priamos.net\Updates\" & myValue)
                Dim exePath As String = Application.ExecutablePath()
                My.Computer.FileSystem.CopyFile(Application.ExecutablePath().Replace("Debug", "Release"), "\\192.168.1.52\priamos.net\Updates\" & myValue & "\PRIAMOS.NET.exe")
            End If
            XtraMessageBox.Show("Η έκδοση δημιουργήθηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbotechnical_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cbotechnical.ButtonClick
        Select Case e.Button.Index
            Case 1 : cbotechnical.EditValue = Nothing : ManageTechnical()
            Case 2 : If cbotechnical.EditValue <> Nothing Then ManageTechnical()
            Case 3 : cbotechnical.EditValue = Nothing
        End Select
    End Sub
    Private Sub ManageTechnical()
        Dim form1 As frmTecnicalSupport = New frmTecnicalSupport()
        form1.Text = "Τεχνική Υποστήριξη"
        'form1.MdiParent = frmMain
        form1.CallerControl = cbotechnical
        form1.CalledFromControl = True
        If cbotechnical.EditValue <> Nothing Then
            form1.ID = cbotechnical.EditValue.ToString
            form1.Mode = FormMode.EditRecord
        Else
            form1.Mode = FormMode.NewRecord
        End If

        'frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.ShowDialog()
    End Sub

End Class