Imports DevExpress.XtraEditors
Imports DevExpress.XtraLayout

Public Class ValidateControls
    Public SChanged As Boolean
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
    Public Function ValidateFormGRP(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup) As Boolean
        For Each item As BaseLayoutItem In GRP.Items
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
    Public Sub AddControlsForCheckIfSomethingChanged(ByVal control As DevExpress.XtraLayout.LayoutControl, Optional ByVal IgnoreVisibility As Boolean = False)
        Dim TagValue As String()
        Dim IsFirstField As Boolean = True
        For Each item As DevExpress.XtraLayout.BaseLayoutItem In control.Items
            If TypeOf item Is DevExpress.XtraLayout.LayoutControlItem Then
                Dim LItem As DevExpress.XtraLayout.LayoutControlItem = CType(item, DevExpress.XtraLayout.LayoutControlItem)
                If LItem.ControlName <> Nothing Then
                    'Γίνεται διαχείριση όταν υπάρχει RadioGroup με optionButtons
                    If TypeOf LItem.Control Is DevExpress.XtraEditors.RadioGroup Then
                        Dim RDG As DevExpress.XtraEditors.RadioGroup
                        RDG = LItem.Control
                    End If
                    ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                    If LItem.Control.Tag <> "" Then
                        'Βάζω τις τιμές του TAG σε array
                        TagValue = LItem.Control.Tag.ToString.Split(",")
                        'Ψάχνω αν το πεδίο έχει δικάιωμα καταχώρησης
                        Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("1")))
                        ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                        If IgnoreVisibility = True Then
                            If LItem.Control.Visible = False Then GoTo NextItem
                        End If

                        ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                        'If LItem.Control.Visible = True Then
                        ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                        ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                        Dim Ctrl As Control = LItem.Control
                        If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                            Dim cbo As DevExpress.XtraEditors.LookUpEdit
                            cbo = Ctrl
                            AddHandler CType(cbo, DevExpress.XtraEditors.LookUpEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                            Dim dt As DevExpress.XtraEditors.DateEdit
                            dt = Ctrl
                            AddHandler CType(dt, DevExpress.XtraEditors.DateEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                            Dim spn As DevExpress.XtraEditors.SpinEdit
                            spn = Ctrl
                            AddHandler CType(spn, DevExpress.XtraEditors.SpinEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
                            Dim txt As DevExpress.XtraEditors.MemoEdit
                            txt = Ctrl
                            AddHandler CType(txt, DevExpress.XtraEditors.MemoEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                            Dim txt As DevExpress.XtraEditors.TextEdit
                            txt = Ctrl
                            AddHandler CType(txt, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf SomethingChanged
                            '*******DevExpress.XtraEditors.ButtonEdit******
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ButtonEdit Then
                            Dim txt As DevExpress.XtraEditors.ButtonEdit
                            txt = Ctrl
                            AddHandler CType(txt, DevExpress.XtraEditors.ButtonEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                            Dim chk As DevExpress.XtraEditors.CheckEdit
                            chk = Ctrl
                            AddHandler CType(chk, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf SomethingChanged
                        End If
                        IsFirstField = False
NextItem:
                    End If
                End If
            End If
        Next
    End Sub
    Public Sub RemoveControlsForCheckIfSomethingChanged(ByVal control As DevExpress.XtraLayout.LayoutControl, Optional ByVal IgnoreVisibility As Boolean = False)
        Dim TagValue As String()
        Dim IsFirstField As Boolean = True
        For Each item As DevExpress.XtraLayout.BaseLayoutItem In control.Items
            If TypeOf item Is DevExpress.XtraLayout.LayoutControlItem Then
                Dim LItem As DevExpress.XtraLayout.LayoutControlItem = CType(item, DevExpress.XtraLayout.LayoutControlItem)
                If LItem.ControlName <> Nothing Then
                    'Γίνεται διαχείριση όταν υπάρχει RadioGroup με optionButtons
                    If TypeOf LItem.Control Is DevExpress.XtraEditors.RadioGroup Then
                        Dim RDG As DevExpress.XtraEditors.RadioGroup
                        RDG = LItem.Control
                    End If
                    ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                    If LItem.Control.Tag <> "" Then
                        'Βάζω τις τιμές του TAG σε array
                        TagValue = LItem.Control.Tag.ToString.Split(",")
                        'Ψάχνω αν το πεδίο έχει δικάιωμα καταχώρησης
                        Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("1")))
                        ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                        If IgnoreVisibility = True Then
                            If LItem.Control.Visible = False Then GoTo NextItem
                        End If

                        ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                        'If LItem.Control.Visible = True Then
                        ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                        ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                        Dim Ctrl As Control = LItem.Control
                        If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                            Dim cbo As DevExpress.XtraEditors.LookUpEdit
                            cbo = Ctrl
                            AddHandler CType(cbo, DevExpress.XtraEditors.LookUpEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                            Dim dt As DevExpress.XtraEditors.DateEdit
                            dt = Ctrl
                            RemoveHandler CType(dt, DevExpress.XtraEditors.DateEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                            Dim spn As DevExpress.XtraEditors.SpinEdit
                            spn = Ctrl
                            RemoveHandler CType(spn, DevExpress.XtraEditors.SpinEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
                            Dim txt As DevExpress.XtraEditors.MemoEdit
                            txt = Ctrl
                            RemoveHandler CType(txt, DevExpress.XtraEditors.MemoEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                            Dim txt As DevExpress.XtraEditors.TextEdit
                            txt = Ctrl
                            RemoveHandler CType(txt, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf SomethingChanged
                            '*******DevExpress.XtraEditors.ButtonEdit******
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ButtonEdit Then
                            Dim txt As DevExpress.XtraEditors.ButtonEdit
                            txt = Ctrl
                            RemoveHandler CType(txt, DevExpress.XtraEditors.ButtonEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                            Dim chk As DevExpress.XtraEditors.CheckEdit
                            chk = Ctrl
                            RemoveHandler CType(chk, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf SomethingChanged
                        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckedListBoxControl Then
                            Dim chk As DevExpress.XtraEditors.CheckedListBoxControl
                            chk = Ctrl
                            RemoveHandler CType(chk, DevExpress.XtraEditors.CheckedListBoxControl).SelectedIndexChanged, AddressOf SomethingChanged
                        End If
                        IsFirstField = False
NextItem:
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub SomethingChanged(sender As Object, e As EventArgs)
        SChanged = True
    End Sub

End Class
