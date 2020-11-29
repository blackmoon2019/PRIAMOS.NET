Imports DevExpress.XtraLayout
Public Class EnableControls
    Public Enum EnableMode
        Enabled = True
        Disabled = False
    End Enum
    Public Sub EnableControls(ByVal Mode As EnableMode, ByVal control As DevExpress.XtraLayout.LayoutControl, Optional ByVal ExcludeControls As List(Of String) = Nothing)
        For Each item As BaseLayoutItem In control.Items
            If TypeOf item Is LayoutControlItem Then
                Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                If LItem.ControlName <> Nothing Then
                    If LItem.Control.Visible = True Then
                        If Not IsNothing(ExcludeControls) Then
                            If ExcludeControls.Contains(LItem.ControlName) Then
                                GoTo NextItem
                            End If
                        End If
                        Dim Ctrl As Control = LItem.Control
                        If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                            Dim cbo As DevExpress.XtraEditors.LookUpEdit
                            cbo = Ctrl
                            cbo.Enabled = Mode
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                            Dim dt As DevExpress.XtraEditors.DateEdit
                            dt = Ctrl
                            dt.Enabled = Mode
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                            Dim txt As DevExpress.XtraEditors.TextEdit
                            txt = Ctrl
                            txt.Enabled = Mode
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                            Dim chk As DevExpress.XtraEditors.CheckEdit
                            chk = Ctrl
                            chk.Enabled = Mode
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SimpleButton Then
                            Dim btn As DevExpress.XtraEditors.SimpleButton
                            btn = Ctrl
                            btn.Enabled = Mode
                        End If
                    End If
                End If
            End If
NextItem:
        Next
    End Sub
    Public Sub EnableControlsGRP(ByVal Mode As EnableMode, ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup, Optional ByVal ExcludeControls As List(Of String) = Nothing)
        For Each item As BaseLayoutItem In GRP.Items
            If TypeOf item Is LayoutControlItem Then
                Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                If LItem.ControlName <> Nothing Then
                    If LItem.Control.Visible = True Then
                        If Not IsNothing(ExcludeControls) Then
                            If ExcludeControls.Contains(LItem.ControlName) Then
                                GoTo NextItem
                            End If
                        End If

                        Dim Ctrl As Control = LItem.Control
                        If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                            Dim cbo As DevExpress.XtraEditors.LookUpEdit
                            cbo = Ctrl
                            cbo.Enabled = Mode
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                            Dim dt As DevExpress.XtraEditors.DateEdit
                            dt = Ctrl
                            dt.Enabled = Mode
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                            Dim txt As DevExpress.XtraEditors.TextEdit
                            txt = Ctrl
                            txt.Enabled = Mode
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                            Dim chk As DevExpress.XtraEditors.CheckEdit
                            chk = Ctrl
                            chk.Enabled = Mode
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SimpleButton Then
                            Dim btn As DevExpress.XtraEditors.SimpleButton
                            btn = Ctrl
                            btn.Enabled = Mode
                        End If
                    End If
                End If
            End If
NextItem:
        Next
    End Sub
End Class
