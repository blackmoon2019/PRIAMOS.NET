Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmGridPreviewer
    Private LoadForms As New FormLoader
    Private sID As String
    Private sMode As Integer
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property Mode As Integer
        Set(value As Integer)
            sMode = value
        End Set
    End Property

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmGridPreviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case sMode
            Case 0
                Me.Vw_INV_OILDTableAdapter.FillByTankID(Me.Priamos_NET_DataSet_BDG.vw_INV_OILD, System.Guid.Parse(sID))
                LoadForms.RestoreLayoutFromXml(GridView1, "vw_INV_OILD.xml")
            Case 1
                Me.Vw_INV_OILDTableAdapter.FillByinvOILID(Me.Priamos_NET_DataSet_BDG.vw_INV_OILD, System.Guid.Parse(sID))
                LoadForms.RestoreLayoutFromXml(GridView1, "vw_INV_OILD2.xml")

        End Select
        Me.CenterToScreen()
    End Sub
    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        Select Case sMode
            Case 0 : If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView1, "vw_INV_OILD.xml", "vw_INV_OILD")
            Case 1 : If e.MenuType = GridMenuType.Column Then LoadForms.PopupMenuShow(e, GridView1, "vw_INV_OILD2.xml", "vw_INV_OILD")
        End Select


    End Sub
End Class