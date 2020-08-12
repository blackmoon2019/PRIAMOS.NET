Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmUsers
    Private sID As String
    Public Mode As Byte
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click


    End Sub

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim cmd As SqlCommand = New SqlCommand("Select * from vw_USR where id ='" + sID + "'", CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            If (sdr.Read() = True) Then
                txtUN.Text = sdr.GetString(sdr.GetOrdinal("un"))
                txtPWD.Text = sdr.GetString(sdr.GetOrdinal("pwd"))
                txtRealName.Text = sdr.GetString(sdr.GetOrdinal("realname"))
                sdr.Close()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class