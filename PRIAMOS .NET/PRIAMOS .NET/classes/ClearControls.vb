Imports DevExpress.XtraLayout

Public Class ClearControls
    Public Sub ClearCtrls(ByVal control As DevExpress.XtraLayout.LayoutControl, Optional ExceptFields As List(Of String) = Nothing)
        For Each item As BaseLayoutItem In control.Items
            If TypeOf item Is LayoutControlItem Then
                Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                If ExceptFields IsNot Nothing Then
                    If IsExceptedField(LItem, ExceptFields) Then GoTo NextItem
                End If
                If LItem.ControlName <> Nothing Then
                    If LItem.Control.Tag <> "" Then
                        If LItem.Control.Visible = True Then
                            Dim Ctrl As Control = LItem.Control
                            If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                cbo = Ctrl : cbo.Text = "" : cbo.EditValue = ""
                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                Dim dt As DevExpress.XtraEditors.DateEdit
                                dt = Ctrl
                                dt.Text = "" : dt.EditValue = ""
                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                Dim txt As DevExpress.XtraEditors.TextEdit
                                txt = Ctrl
                                If txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric Then
                                    Select Case txt.Properties.Mask.EditMask
                                        Case "n2", "c" : txt.Text = "0,00"
                                        Case "n0" : txt.Text = "0"
                                        Case Else : txt.Text = "0"
                                    End Select
                                ElseIf txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                    txt.EditValue = "0"
                                Else
                                    txt.EditValue = ""
                                End If


                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                Dim chk As DevExpress.XtraEditors.CheckEdit
                                chk = Ctrl
                                chk.Checked = False
                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                                Dim spn As DevExpress.XtraEditors.SpinEdit
                                spn = Ctrl
                                spn.EditValue = 0
                            End If
                        End If
                    End If
                End If
            End If
NextItem:
        Next
    End Sub
    Private Function IsExceptedField(ByVal Litem As LayoutControlItem, ExceptFields As List(Of String)) As Boolean
        Dim Ctrl As Control = Litem.Control
        If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
            Dim cbo As DevExpress.XtraEditors.LookUpEdit
            cbo = Ctrl
            If ExceptFields.Contains(cbo.Properties.Tag) Then Return True
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
            Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
            cbo = Ctrl
            If ExceptFields.Contains(cbo.Properties.Tag) Then Return True
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.GridLookUpEdit Then
            Dim cbo As DevExpress.XtraEditors.GridLookUpEdit
            cbo = Ctrl
            If ExceptFields.Contains(cbo.Properties.Tag) Then Return True
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.PictureEdit Then
            Dim pic As DevExpress.XtraEditors.PictureEdit
            pic = Ctrl
            If ExceptFields.Contains(pic.Properties.Tag) Then Return True

        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
            Dim dt As DevExpress.XtraEditors.DateEdit
            dt = Ctrl

        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
            Dim spn As DevExpress.XtraEditors.SpinEdit
            spn = Ctrl

        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
            Dim txt As DevExpress.XtraEditors.MemoEdit
            txt = Ctrl

        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
            Dim txt As DevExpress.XtraEditors.TextEdit
            txt = Ctrl
            If ExceptFields.Contains(txt.Properties.Tag) Then Return True
            '*******DevExpress.XtraEditors.ButtonEdit******
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ButtonEdit Then
            Dim txt As DevExpress.XtraEditors.ButtonEdit
            txt = Ctrl

        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
            Dim chk As DevExpress.XtraEditors.CheckEdit
            chk = Ctrl
            If ExceptFields.Contains(chk.Properties.Tag) Then Return True
        End If
        Return False
    End Function
    Public Sub ClearGroupCtrls(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup)
        For Each grpitem As BaseLayoutItem In GRP.Items
            If TypeOf grpitem Is LayoutControlItem Then
                Dim LItem As LayoutControlItem = CType(grpitem, LayoutControlItem)
                If LItem.ControlName <> Nothing Then
                    If LItem.Control.Tag <> "" Then
                        If LItem.Control.Visible = True Then
                            Dim Ctrl As Control = LItem.Control
                            If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                cbo = Ctrl : cbo.EditValue = Nothing : cbo.Text = "" : cbo.EditValue = ""
                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                Dim dt As DevExpress.XtraEditors.DateEdit
                                dt = Ctrl
                                dt.Text = "" : dt.EditValue = ""
                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ButtonEdit Then
                                Dim bte As DevExpress.XtraEditors.ButtonEdit
                                bte = Ctrl
                                bte.Text = "" : bte.EditValue = ""

                            ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                Dim txt As DevExpress.XtraEditors.TextEdit
                                txt = Ctrl
                                If txt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric Then
                                    Select Case txt.Properties.Mask.EditMask
                                        Case "n2", "c" : txt.Text = "0,00"
                                        Case "n0" : txt.Text = "0"
                                    End Select
                                ElseIf txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                    txt.EditValue = "0"
                                Else
                                    txt.EditValue = ""
                                End If

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
