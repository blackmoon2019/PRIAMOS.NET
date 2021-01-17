Imports Microsoft.SqlServer.Management.Sdk.Sfc
Imports Microsoft.SqlServer.Management.Smo
Imports System.Windows.Forms
Imports System.Data
Imports System

Public Class frmDBConnection

    Private Sub frmDBConnection_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dataTable As DataTable = SmoApplication.EnumAvailableSqlServers(False)
        cboSQLServer.Properties.DataSource = dataTable

    End Sub
    Private Sub LoadSQLServers(ByVal sqlCombo As DevExpress.XtraEditors.LookUpEdit)

    End Sub
End Class