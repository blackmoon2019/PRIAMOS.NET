Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmFilePreviwer
    Private sID As String
    Private Splash As DevExpress.XtraSplashScreen.SplashScreenManager
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property Spl As DevExpress.XtraSplashScreen.SplashScreenManager
        Set(value As DevExpress.XtraSplashScreen.SplashScreenManager)
            Splash = value
        End Set
    End Property

    Private Sub frmFilePreviwer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_IND_F' table. You can move, or remove it, as needed.
        Me.Vw_IND_FTableAdapter.Fill(Me.Priamos_NETDataSet.vw_IND_F, System.Guid.Parse(sID))
        Splash.CloseWaitForm()
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
        If GridView1.IsGroupRow(GridView1.FocusedRowHandle) Then Exit Sub
        Dim sFilename = System.IO.Path.GetTempFileName().ToString().Replace(".tmp", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "extension"))
        Dim fs As IO.FileStream = New IO.FileStream(sFilename, IO.FileMode.Create)
        Dim b() As Byte = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "files")
        fs.Write(b, 0, b.Length)
        PdfViewer1.LoadDocument(fs)
        fs.Close()
    End Sub
End Class