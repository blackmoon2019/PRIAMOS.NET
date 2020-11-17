Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors

Public Class ClearControls
    Public Sub ClearCtrls(ByVal control As DevExpress.XtraLayout.LayoutControl)
        For Each item As BaseLayoutItem In control.Items
            If TypeOf item Is LayoutControlItem Then
                Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                If LItem.ControlName <> Nothing Then
                    If LItem.Control.Tag <> "" Then
                        If LItem.Control.Visible = True Then
                            Dim Ctrl As Control = LItem.Control
                            If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                cbo = Ctrl
                                cbo.EditValue = Nothing : cbo.Text = "" : cbo.EditValue = ""

                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                Dim dt As DevExpress.XtraEditors.DateEdit
                                dt = Ctrl
                                dt.Text = "" : dt.EditValue = ""
                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                Dim txt As DevExpress.XtraEditors.TextEdit
                                txt = Ctrl
                                txt.Text = ""
                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                Dim chk As DevExpress.XtraEditors.CheckEdit
                                chk = Ctrl
                                chk.Checked = False
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub
    Public Sub ClearGrid(ByVal GRD As DevExpress.XtraGrid.GridControl)
        GRD.BeginUpdate()
        Try
            GRD.DataSource = Nothing
        Finally
            GRD.EndUpdate()
        End Try
    End Sub
End Class
