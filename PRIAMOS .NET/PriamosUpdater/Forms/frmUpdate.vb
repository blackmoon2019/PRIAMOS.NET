Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Partial Public Class frmUpdate

    Public Sub New()
        InitializeComponent()
    End Sub
    Private strArg() As String
    Private Sub frmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '------Arguments--------
        '1 Current Version
        '2 Server Update Path
        '3 Server Application Path
        '4 Version To be Updated
        'Dim proc = Process.GetProcessesByName("PRIAMOS.NET")
        'For i As Integer = 0 To proc.Count - 1
        '    proc(i).CloseMainWindow()
        'Next i

        If Debugger.IsAttached Then
            strArg = {"1.1.0.4", "\\192.168.1.51\priamos.net\Updates\1.1.0.5", "C:\Users\USER\source\repos\PRIAMOS .NET\PRIAMOS .NET\PRIAMOS .NET\bin\Debug\", "1.1.0.5"}
        Else
            ' Assume we aren't running from the IDE
            strArg = Command().Split(",")
            'XtraMessageBox.Show(strArg(0))
            'XtraMessageBox.Show(strArg(1))
            'XtraMessageBox.Show(strArg(2))
            'XtraMessageBox.Show(strArg(3))


        End If

    End Sub

    Private Sub frmUpdate_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim ExeVer As String, FilesToBeUpdated() As String
        Dim CN As New CN
        If CN.OpenConnection = False Then XtraMessageBox.Show("Παρουσιάστηκε πρόβλημα κατά την σύνδεση στο PRIAMOS .NET", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Try
            'Παίρνω όλες τις εκδόσεις από την τρέχουσα και μετά ώστε να πάω να τραβήξω όλα τα μοναδικά αρχεία τα οποία θα αναβαθμιστούν
            'Αναφέρω την λέξη μοναδικά γιατί δεν θέλω το EXE για παράδειγμα να το τραβήξω πολλές φορές αν υπάρχει σε όλες τις εκδόσεις 
            'αλλά μόνο την τελευταία
            KillProcess()
            sSQL = "select *,(select count(*) FROM VER_HIST where ExeVer > '" & strArg(0) & "') as Rows FROM VER_HIST where ExeVer > '" & strArg(0) & "' order by ExeVer asc"
            cmd = New SqlCommand(sSQL, CNDB)
            sdr = cmd.ExecuteReader()
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.PercentView = True
            ProgressBarControl1.Properties.Minimum = 0

            ProgressBarControl2.Properties.Step = 1
            ProgressBarControl2.Properties.PercentView = True
            ProgressBarControl2.Properties.Minimum = 0
            lblTotal.Text = "Αναβάθμιση από έκδοση " & strArg(0) & " σε έκδοση " & strArg(3)
            While sdr.Read()
                ProgressBarControl2.Properties.Maximum = sdr.GetInt32(sdr.GetOrdinal("Rows"))
                ExeVer = sdr.GetString(sdr.GetOrdinal("ExeVer"))
                FilesToBeUpdated = sdr.GetString(sdr.GetOrdinal("FilesToBeUpdated")).Split(",")

                ProgressBarControl1.Properties.Maximum = FilesToBeUpdated.Length
                Application.DoEvents()
                ProgressBarControl1.EditValue = 0
                ProgressBarControl1.Reset()
                For i = 0 To FilesToBeUpdated.Length() - 1
                    lblFileCounter.Text = "Αντιγραφή αρχείου " & strArg(1) & "\" & FilesToBeUpdated(i)
                    Application.DoEvents()
                    ProgressBarControl1.PerformStep()
                    ProgressBarControl1.Update()
                    'XtraMessageBox.Show(strArg(1) & FilesToBeUpdated(i))
                    'XtraMessageBox.Show(strArg(2) & FilesToBeUpdated(i))
                    FileCopy(strArg(1) & "\" & FilesToBeUpdated(i), strArg(2) & "\" & FilesToBeUpdated(i))
                Next
                Application.DoEvents()
                ProgressBarControl2.PerformStep()
                ProgressBarControl2.Update()

            End While
            If (XtraMessageBox.Show("Η ενημέρωση ολοκληρώθηκε με επιτυχία.Θέλετε να ανοίξω το PRIAMOS .NET?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Information)) = DialogResult.Yes Then
                Shell(strArg(2) & "\PRIAMOS.NET.exe")
                End
            End If
            sdr.Close()


        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub KillProcess()
        Dim myProcesses() As Process
        Dim myProcess As Process

        myProcesses = Process.GetProcessesByName("PRIAMOS.NET")

        Try

            If myProcesses.Length > 0 Then
                For Each myProcess In myProcesses
                    If myProcess IsNot Nothing Then
                        myProcess.Kill()
                    End If

                Next
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        End
    End Sub
End Class
