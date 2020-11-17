Imports System.Data.SqlClient
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns

Public Class FormLoader
    Public Function LoadFormNew(ByVal controls As List(Of Control), ByVal sSQL As String, Optional ByVal IgnoreVisibility As Boolean = False) As Boolean

        Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        Dim sTable As DataTable
        Dim TagValue As String()
        '        Dim control As DevExpress.XtraLayout.LayoutControl
        'Tag Value = 0 For Load
        'Tag Value = 1 For Insert
        'Tag Value = 2 For Update
        Dim TagV As String
        Try


            sTable = sdr.GetSchemaTable()
            If (sdr.Read() = True) Then
                For Each control As DevExpress.XtraLayout.LayoutControl In controls
                    For Each item As BaseLayoutItem In control.Items
                        If TypeOf item Is LayoutControlItem Then
                            Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                            If LItem.ControlName <> Nothing Then

                                'Γίνεται διαχείριση όταν υπάρχει RadioGroup με optionButtons
                                If TypeOf LItem.Control Is DevExpress.XtraEditors.RadioGroup Then
                                    Dim RDG As DevExpress.XtraEditors.RadioGroup
                                    RDG = LItem.Control
                                    For i As Integer = 0 To RDG.Properties.Items.Count - 1
                                        'Βάζω τις τιμές του TAG σε array
                                        If RDG.Properties.Items(i).Tag <> Nothing Then
                                            TagValue = RDG.Properties.Items(i).Tag.Split(",")
                                            'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                                            Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                                            If value <> Nothing Then
                                                TagV = TagValue(0).Replace("[", "").Replace("]", "")
                                                Console.WriteLine(TagV)
                                                sdr.GetDataTypeName(sdr.GetOrdinal(TagV))
                                                Dim index = sdr.GetOrdinal(TagV)
                                                Console.WriteLine(sdr.GetDataTypeName(index))
                                                If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then
                                                    If sdr.GetBoolean(sdr.GetOrdinal(TagV)) = True Then RDG.SelectedIndex = i
                                                End If
                                            End If
                                        End If
                                    Next i
                                End If

                                ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                                If LItem.Control.Tag <> "" Then
                                    'Βάζω τις τιμές του TAG σε array
                                    TagValue = LItem.Control.Tag.ToString.Split(",")
                                    'Ψάχνω αν το πεδίο έχει δικάιωμα Προβολής
                                    Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("0")))
                                    ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                                    If IgnoreVisibility = False Then
                                        If LItem.Control.Visible = True Then GoTo NextItem
                                    End If

                                    ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                                    'If LItem.Control.Visible = True Then
                                    If value <> Nothing Then
                                        TagV = TagValue(0).Replace("[", "").Replace("]", "")
                                        Console.WriteLine(TagV)
                                        sdr.GetDataTypeName(sdr.GetOrdinal(TagV))
                                        Dim index = sdr.GetOrdinal(TagV)
                                        Console.WriteLine(sdr.GetDataTypeName(index))
                                        Select Case sdr.GetDataTypeName(index)
                                            Case "nvarchar"
                                                If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetString(sdr.GetOrdinal(TagV)))
                                            Case "int"
                                                If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetInt32(sdr.GetOrdinal(TagV)))
                                            Case "uniqueidentifier"
                                                If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetGuid(sdr.GetOrdinal(TagV)).ToString)
                                            Case "bit"
                                                If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetBoolean(sdr.GetOrdinal(TagV)))
                                            Case "decimal"
                                                If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetDecimal(sdr.GetOrdinal(TagV)))
                                            Case "datetime"
                                                If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetDateTime(sdr.GetOrdinal(TagV)))
                                        End Select
                                    End If
NextItem:
                                    'End If
                                End If
                            End If
                        End If
                    Next
                Next
            End If

            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function LoadForm(ByVal control As DevExpress.XtraLayout.LayoutControl, ByVal sSQL As String, Optional ByVal IgnoreVisibility As Boolean = False) As Boolean

        Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        Dim sTable As DataTable
        Dim TagValue As String()
        'Tag Value = 0 For Load
        'Tag Value = 1 For Insert
        'Tag Value = 2 For Update
        Dim TagV As String
        Try
            sTable = sdr.GetSchemaTable()
            If (sdr.Read() = True) Then

                For Each item As BaseLayoutItem In control.Items
                    If TypeOf item Is LayoutControlItem Then
                        Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                        If LItem.ControlName <> Nothing Then
                            ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                            If LItem.Control.Tag <> "" Then
                                'Βάζω τις τιμές του TAG σε array
                                TagValue = LItem.Control.Tag.ToString.Split(",")
                                'Ψάχνω αν το πεδίο έχει δικάιωμα Προβολής
                                Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("0")))
                                ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                                If IgnoreVisibility = False Then
                                    If LItem.Control.Visible = True Then GoTo NextItem
                                End If

                                ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                                'If LItem.Control.Visible = True Then
                                If value <> Nothing Then
                                    TagV = TagValue(0).Replace("[", "").Replace("]", "")
                                    Console.WriteLine(TagV)
                                    sdr.GetDataTypeName(sdr.GetOrdinal(TagV))
                                    Dim index = sdr.GetOrdinal(TagV)
                                    Console.WriteLine(sdr.GetDataTypeName(index))
                                    If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetBoolean(sdr.GetOrdinal(TagV)))
                                    Select Case sdr.GetDataTypeName(index)
                                        Case "nvarchar"
                                            If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetString(sdr.GetOrdinal(TagV)))
                                        Case "int"
                                            If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetInt32(sdr.GetOrdinal(TagV)))
                                        Case "uniqueidentifier"
                                            If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetGuid(sdr.GetOrdinal(TagV)).ToString)
                                        Case "bit"
                                            If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetBoolean(sdr.GetOrdinal(TagV)))
                                        Case "decimal"
                                            If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetDecimal(sdr.GetOrdinal(TagV)))
                                        Case "datetime"
                                            If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetDateTime(sdr.GetOrdinal(TagV)))
                                    End Select
                                End If
NextItem:
                                'End If
                            End If
                        End If
                    End If
                Next
            End If
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub SetValueToControl(ByVal LItem As LayoutControlItem, ByVal sValue As String)
        Dim Ctrl As Control = LItem.Control
        If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
            Dim cbo As DevExpress.XtraEditors.LookUpEdit
            cbo = Ctrl : cbo.EditValue = System.Guid.Parse(sValue)
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
            Dim dt As DevExpress.XtraEditors.DateEdit
            dt = Ctrl
            dt.EditValue = CDate(sValue)
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
            Dim txt As DevExpress.XtraEditors.MemoEdit
            txt = Ctrl
            If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Then
                txt.Text = Math.Round(CDec(sValue), ProgProps.Decimals)
            Else
                txt.Text = sValue
            End If
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
            Dim txt As DevExpress.XtraEditors.TextEdit
            txt = Ctrl
            If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Then
                txt.Text = Math.Round(CDec(sValue), ProgProps.Decimals)
            ElseIf txt.Properties.Mask.EditMask = "d" Then ' Αφορά το DateEditControl
                txt.Text = sValue
            Else
                txt.Text = sValue
            End If
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
            Dim chk As DevExpress.XtraEditors.CheckEdit
            chk = Ctrl
            chk.EditValue = sValue
            chk.Checked = sValue
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then

        End If
    End Sub
    Public Sub LoadDataToGrid(ByRef GRDControl As DevExpress.XtraGrid.GridControl, ByRef GRDView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sSQL As String)
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader

        myCmd = CNDB.CreateCommand
        myCmd.CommandText = sSQL
        GRDView.Columns.Clear()
        myReader = myCmd.ExecuteReader()
        GRDControl.DataSource = myReader
        GRDControl.ForceInitialize()
        GRDControl.DefaultView.PopulateColumns()
        If myReader.HasRows = False Then
            For i As Integer = 0 To myReader.FieldCount - 1
                Dim C As New GridColumn
                C.Name = myReader.GetName(i).ToString
                C.Caption = myReader.GetName(i).ToString
                C.Visible = True
                GRDView.Columns.Add(C)
            Next i

        End If
    End Sub
    Public Sub LoadDataToGridForEdit(ByRef GRDControl As DevExpress.XtraGrid.GridControl, ByRef GRDView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sSQL As String)
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        Dim dt As New DataTable("sTable")
        Try
            myCmd = CNDB.CreateCommand
            myCmd.CommandText = sSQL
            GRDView.Columns.Clear()
            myReader = myCmd.ExecuteReader()
            dt.Load(myReader)
            GRDControl.DataSource = dt
            GRDControl.ForceInitialize()
            GRDControl.DefaultView.PopulateColumns()
            If dt.Rows.Count = 0 Then
                For i As Integer = 0 To myReader.FieldCount - 1
                    Dim C As New GridColumn
                    C.Name = myReader.GetName(i).ToString
                    C.Caption = myReader.GetName(i).ToString
                    C.Visible = True
                    GRDView.Columns.Add(C)
                Next i
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

