Imports DevExpress.XtraEditors
Imports DevExpress.XtraLayout

Public Class ValidateControls
    Public Function ValidateForm(ByVal control As DevExpress.XtraLayout.LayoutControl) As Boolean
        For Each item As BaseLayoutItem In control.Items
            If TypeOf item Is LayoutControlItem Then
                Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                If LItem.Tag = "1" Then
                    If LItem.Control.Visible = True Then
                        If LItem.Control.Text = "" Then
                            XtraMessageBox.Show("Υπάρχουν υποχρεωτικά πεδία που δεν έχετε συμπληρώσει.", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If
                    End If
                End If
            End If
        Next
        Return True
    End Function
End Class
