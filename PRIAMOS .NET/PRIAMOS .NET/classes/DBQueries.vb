Imports System.Data.SqlClient
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors
Imports System.IO
Imports DevExpress.XtraRichEdit.Model.History

Public Class DBQueries
    Public Enum InsertMode
        OneLayoutControl = 1
        MultipleLayoutControls = 2
        GroupLayoutControl = 3
        GridControl = 4
    End Enum

    Public Function GetNextId(ByVal sTable As String) As Integer
        'Dim cmd As SqlCommand = New SqlCommand("SELECT IDENT_CURRENT('" & sTable & "')  AS ID", CNDB)
        Dim cmd As SqlCommand = New SqlCommand("SELECT Case when (select top 1 ID from " & sTable & ") Is Not null then  IDENT_CURRENT('" & sTable & "') + 1 else 1 end   AS ID", CNDB)
        Dim ID As Integer = cmd.ExecuteScalar()
        'If ID > 1 Then ID = ID + 1
        Return ID
    End Function
    Public Function InsertNewData(ByVal Mode As InsertMode, ByVal sTable As String, Optional ByVal control As DevExpress.XtraLayout.LayoutControl = Nothing,
                                  Optional ByVal controls As List(Of Control) = Nothing, Optional ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup = Nothing,
                                  Optional ByVal sGuid As String = "", Optional ByVal IgnoreVisibility As Boolean = False,
                                  Optional ByVal ExtraFields As String = "", Optional ByVal ExtraValues As String = "") As Boolean
        Select Case Mode
            Case 1
                Return InsertData(control, sTable, sGuid, IgnoreVisibility, ExtraFields, ExtraValues)
            Case 2
                Return InsertDataNew(controls, sTable, sGuid, IgnoreVisibility, ExtraFields, ExtraValues)
            Case 3
                Return InsertDataGRP(GRP, sTable, sGuid, IgnoreVisibility, ExtraFields, ExtraValues)

        End Select
    End Function


    Public Function InsertNewDataFiles(ByVal control As DevExpress.XtraEditors.XtraOpenFileDialog, ByVal sTable As String, ByVal ID As String,
                                       Optional ByVal ExtraFields As String = "", Optional ByVal ExtraValues As String = "", Optional ByVal PB As System.Windows.Forms.ProgressBar = Nothing) As Boolean
        Dim sSQL As New System.Text.StringBuilder
        Dim i As Integer
        Try
            If PB IsNot Nothing Then
                PB.Minimum = 0
                PB.Maximum = control.FileNames.Count - 1
                PB.Step = 1
                PB.Style = ProgressBarStyle.Continuous
                'PB.Properties.Minimum = 0
                'PB.Properties.Maximum = control.FileNames.Count - 1
                'PB.Properties.Step = 1
                'PB.Properties.PercentView = True
                'PB.Properties.ShowTitle = True
            End If
            For i = 0 To control.FileNames.Count - 1
                sSQL.Clear()
                Select Case sTable
                    Case "CCT_F"
                        sSQL.AppendLine("INSERT INTO CCT_F ( ") : sSQL.AppendLine(IIf(ExtraFields.Length > 0, ExtraFields & ",", "") & " cctID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                        'sSQL.AppendLine("INSERT INTO CCT_F (cctID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                    Case "INV_GASF"
                        'sSQL.AppendLine("INSERT INTO INV_GASF (invGASID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                        sSQL.AppendLine("INSERT INTO INV_GASF ( ") : sSQL.AppendLine(IIf(ExtraFields.Length > 0, ExtraFields & ",", "") & " invGASID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                    Case "INV_OILF"
                        'sSQL.AppendLine("INSERT INTO INV_OILF (invOilID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                        sSQL.AppendLine("INSERT INTO INV_OILF ( ") : sSQL.AppendLine(IIf(ExtraFields.Length > 0, ExtraFields & ",", "") & " invOilID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                    Case "BDG_F"
                        'sSQL.AppendLine("INSERT INTO BDG_F (bdgID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                        sSQL.AppendLine("INSERT INTO BDG_F ( ") : sSQL.AppendLine(IIf(ExtraFields.Length > 0, ExtraFields & ",", "") & " bdgID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                End Select
                Dim extension As String = Path.GetExtension(control.FileNames(i))
                Dim FilePath As String = Path.GetDirectoryName(control.FileNames(i))
                Dim FileName As String = Path.GetFileName(control.FileNames(i))
                My.Computer.FileSystem.CopyFile(control.FileNames(i), ProgProps.ServerPath & FileName, True)

                sSQL.AppendLine("Select ")
                If ExtraValues.Length > 0 Then sSQL.AppendLine(ExtraValues & ",")
                sSQL.AppendLine(toSQLValueS(ID) & ",")
                sSQL.AppendLine(toSQLValueS(control.SafeFileNames(i).ToString) & ",")
                sSQL.AppendLine(toSQLValueS(FilePath) & ",")
                sSQL.AppendLine(toSQLValueS(extension) & ",")

                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString) & "," & toSQLValueS(UserProps.ID.ToString) & ", getdate(), files.* ")
                sSQL.AppendLine("FROM OPENROWSET (BULK " & toSQLValueS(ProgProps.ServerPath & FileName) & ", SINGLE_BLOB) files")

                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                If PB IsNot Nothing Then PB.PerformStep()
            Next
            control.FileName = ""
            'ReadBlobFile()
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function
    Public Function InsertNewDataFilesFromListBox(ByVal control As DevExpress.XtraEditors.ImageListBoxControl, ByVal sTable As String, ByVal ID As String, ByVal sFilesPath As String) As Boolean
        Dim sSQL As New System.Text.StringBuilder
        Dim sFullFilenames As New System.Text.StringBuilder
        Try
            For Each item As DevExpress.XtraEditors.Controls.ImageListBoxItem In control.SelectedItems
                sSQL.Clear()
                Select Case sTable
                    Case "CCT_F" : sSQL.AppendLine("INSERT INTO CCT_F (cctID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                    Case "INV_GASF" : sSQL.AppendLine("INSERT INTO INV_GASF (invGASID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                    Case "INV_OILF" : sSQL.AppendLine("INSERT INTO INV_OILF (invOilID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                    Case "IND_F" : sSQL.AppendLine("INSERT INTO IND_F (indID,filename,comefrom,extension, [modifiedBy],[createdby],[createdOn],files)")
                End Select
                Dim extension As String = Path.GetExtension(item.Value)
                Dim FilePath As String = sFilesPath
                Dim FileName As String = item.Value
                My.Computer.FileSystem.CopyFile(sFilesPath & "\" & FileName, ProgProps.ServerPath & FileName, True)

                sSQL.AppendLine("Select " & toSQLValueS(ID) & ",")
                sSQL.AppendLine(toSQLValueS(sFilesPath & "\" & FileName) & ",")
                sSQL.AppendLine(toSQLValueS(sFilesPath) & ",")
                sSQL.AppendLine(toSQLValueS(extension) & ",")
                sSQL.AppendLine(toSQLValueS(UserProps.ID.ToString) & "," & toSQLValueS(UserProps.ID.ToString) & ", getdate(), files.* ")
                sSQL.AppendLine("FROM OPENROWSET (BULK " & toSQLValueS(ProgProps.ServerPath & FileName) & ", SINGLE_BLOB) files")
                sFullFilenames.AppendLine(sFilesPath & "\" & FileName & IIf(sFullFilenames.Length > 0, ";", ""))
                'Εκτέλεση QUERY
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next
            sSQL.Clear()
            If sTable = "IND_F" Then
                sSQL.AppendLine("UPDATE [IND] SET SelectedFiles = " & toSQLValueS(sFullFilenames.ToString) & " WHERE ID = " & toSQLValueS(ID))
                Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            End If
            'ReadBlobFile()
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    'Η InsertData χρησιμοποιείται για να αποθηκεύσει Data για ένα LayoutContol
    Private Function InsertData(ByVal control As DevExpress.XtraLayout.LayoutControl, ByVal sTable As String, Optional ByVal sGuid As String = "",
                                Optional ByVal IgnoreVisibility As Boolean = False,
                                Optional ByVal ExtraFields As String = "", Optional ByVal ExtraValues As String = "") As Boolean
        Dim sSQLF As New System.Text.StringBuilder ' Το 1ο StringField αφορά τα πεδία
        Dim sSQLV As New System.Text.StringBuilder ' Το 2ο StringField αφορά τις τιμές
        Dim IsFirstField As Boolean = True
        Dim TagValue As String()
        Dim FormHasPic(5) As Boolean
        Dim pic(5) As DevExpress.XtraEditors.PictureEdit
        'Tag Value = 0 For Load
        'Tag Value = 1 For Insert
        'Tag Value = 2 For Update
        Try
            'Εαν η function καλεστεί με sGuid σημαίνει ότι θα πρε΄πει να καταχωρίσουμε εμείς το ID
            If sGuid.Length > 0 Then IsFirstField = False
            'FIELDS
            sSQLF.AppendLine("INSERT INTO " & sTable & "(" & IIf(sGuid.Length > 0, "ID", ""))
            If ExtraFields.Length > 0 Then
                sSQLF.AppendLine(IIf(IsFirstField = True, "", ",") & ExtraFields)
            End If
            'VALUES
            sSQLV.AppendLine("VALUES(" & IIf(sGuid.Length > 0, toSQLValueS(sGuid), ""))
            If ExtraValues.Length > 0 Then sSQLV.AppendLine(IIf(IsFirstField = True, "", ",") & ExtraValues) : IsFirstField = False
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
                                TagValue = RDG.Properties.Items(i).Tag.Split(",")
                                'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                                Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                                If value <> Nothing Then
                                    ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                    sSQLF.Append(IIf(IsFirstField = True, "", ",") & TagValue(0))
                                    If RDG.SelectedIndex = i Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS("True"))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS("False"))
                                    End If
                                End If
                            Next i
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
                            If value <> Nothing Then
                                ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                sSQLF.Append(IIf(IsFirstField = True, "", ",") & TagValue(0))
                                ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                                ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                                Dim Ctrl As Control = LItem.Control
                                If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                    Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(cbo.EditValue.ToString))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.PictureEdit Then
                                    For I As Integer = 0 To UBound(FormHasPic)
                                        If FormHasPic(I) = False Then
                                            FormHasPic(I) = True
                                            pic(I) = Ctrl
                                            If pic(I).Text <> "" Then
                                                sSQLV.Append(IIf(IsFirstField = True, "", ",") & "@Photo" & I)
                                            Else
                                                sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                            End If
                                            Exit For
                                        End If
                                    Next
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                    Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                    cbo = Ctrl
                                    Debug.Print(cbo.Name)
                                    If cbo.EditValue <> Nothing Then
                                        If cbo.EditValue = "False" Or cbo.EditValue = "True" Or cbo.Properties.Tag = "0" Then
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & cbo.SelectedIndex)
                                        Else
                                            If cbo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                                sSQLV.Append(IIf(IsFirstField = True, "", ",") & cbo.SelectedIndex)
                                            Else
                                                sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(cbo.EditValue.ToString))
                                            End If
                                        End If
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                    Dim dt As DevExpress.XtraEditors.DateEdit
                                    dt = Ctrl
                                    If dt.Text <> "" Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(CDate(dt.Text).ToString("yyyyMMdd")))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraScheduler.DateNavigator Then
                                    Dim dt As DevExpress.XtraScheduler.DateNavigator
                                    dt = Ctrl
                                    If dt.EditValue.ToString <> "" Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(CDate(dt.EditValue.ToString).ToString("yyyyMMdd")))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                                    Dim spn As DevExpress.XtraEditors.SpinEdit
                                    spn = Ctrl
                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(spn.Text))
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
                                    Dim txt As DevExpress.XtraEditors.MemoEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ColorPickEdit Then
                                    Dim cpk As DevExpress.XtraEditors.ColorPickEdit
                                    cpk = Ctrl
                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & cpk.Text)
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                    Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & cbo.SelectedIndex)
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                    Dim txt As DevExpress.XtraEditors.TextEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                    End If
                                    '*******DevExpress.XtraEditors.ButtonEdit******
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ButtonEdit Then
                                    Dim txt As DevExpress.XtraEditors.ButtonEdit
                                    txt = Ctrl
                                    If txt.Properties.Tag = True Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                    Dim chk As DevExpress.XtraEditors.CheckEdit
                                    chk = Ctrl
                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & chk.EditValue)
                                End If
                                IsFirstField = False
                            End If
                            'End If
NextItem:
                        End If
                    End If
                End If
            Next
            sSQLF.Append(", [modifiedBy],[createdOn] ")
            sSQLF.Append(", [MachineName],[createdBy]) ")
            sSQLV.Append("," & toSQLValueS(UserProps.ID.ToString) & ", getdate() ")
            sSQLV.Append("," & toSQLValueS(UserProps.MachineName) & "," & toSQLValueS(UserProps.ID.ToString) & ")")
            sSQLF.AppendLine(sSQLV.ToString)
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQLF.ToString, CNDB)
                For I As Integer = 0 To UBound(FormHasPic)
                    If FormHasPic(I) = True Then
                        If pic(I).Text = "" Then
                            oCmd.Parameters.AddWithValue("@Photo" & I, "NULL")
                        Else
                            oCmd.Parameters.AddWithValue("@Photo" & I, pic(I).EditValue)
                        End If
                    End If
                Next
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    'Η InsertDataNew χρησιμοποιείται για να αποθηκεύση Data από περισσότερα τους ενός LayoutContol
    'Του στέλνεις Πολλά LayoutContols και κάνει Loop τα LayoutItems
    Private Function InsertDataNew(ByVal controls As List(Of Control), ByVal sTable As String, Optional ByVal sGuid As String = "",
                                   Optional ByVal IgnoreVisibility As Boolean = False,
                                   Optional ByVal ExtraFields As String = "", Optional ByVal ExtraValues As String = "") As Boolean
        Dim sSQLF As New System.Text.StringBuilder ' Το 1ο StringField αφορά τα πεδία
        Dim sSQLV As New System.Text.StringBuilder ' Το 2ο StringField αφορά τις τιμές
        Dim IsFirstField As Boolean = True
        Dim TagValue As String()
        Dim FormHasPic(5) As Boolean
        Dim pic(5) As DevExpress.XtraEditors.PictureEdit
        'Tag Value = 0 For Load
        'Tag Value = 1 For Insert
        'Tag Value = 2 For Update
        Try
            'Εαν η function καλεστεί με sGuid σημαίνει ότι θα πρε΄πει να καταχωρίσουμε εμείς το ID
            If sGuid.Length > 0 Then IsFirstField = False
            'FIELDS
            sSQLF.AppendLine("INSERT INTO " & sTable & "(" & IIf(sGuid.Length > 0, "ID", ""))
            If ExtraFields.Length > 0 Then
                sSQLF.AppendLine(IIf(IsFirstField = True, "", ",") & ExtraFields)
                IsFirstField = False
            End If
            'VALUES
            sSQLV.AppendLine("VALUES(" & IIf(sGuid.Length > 0, toSQLValueS(sGuid), ""))
            If ExtraValues.Length > 0 Then sSQLV.AppendLine(IIf(IsFirstField = True, "", ",") & ExtraValues)
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
                                    If RDG.Properties.Items(i).Tag <> Nothing Then
                                        'Βάζω τις τιμές του TAG σε array
                                        TagValue = RDG.Properties.Items(i).Tag.Split(",")
                                        'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                                        Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                                        If value <> Nothing Then
                                            ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                            sSQLF.Append(IIf(IsFirstField = True, "", ",") & TagValue(0))
                                            If RDG.SelectedIndex = i Then
                                                sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS("True"))
                                            Else
                                                sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS("False"))
                                            End If
                                        End If
                                    End If
                                Next i
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
                                If value <> Nothing Then
                                    ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                    sSQLF.Append(IIf(IsFirstField = True, "", ",") & TagValue(0))
                                    ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                                    ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                                    Dim Ctrl As Control = LItem.Control
                                    If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                        Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                        cbo = Ctrl
                                        If cbo.EditValue <> Nothing Then
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(cbo.EditValue.ToString))
                                        Else
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.PictureEdit Then
                                        For I As Integer = 0 To UBound(FormHasPic)
                                            If FormHasPic(I) = False Then
                                                FormHasPic(I) = True
                                                pic(I) = Ctrl
                                                If pic(I).Text <> "" Then
                                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & "@Photo" & I)
                                                Else
                                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                                End If
                                                Exit For
                                            End If
                                        Next
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                        Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                        cbo = Ctrl
                                        Debug.Print(cbo.Name)
                                        If cbo.EditValue <> Nothing Then
                                            If cbo.EditValue = "False" Or cbo.EditValue = "True" Or cbo.Properties.Tag = "0" Then
                                                sSQLV.Append(IIf(IsFirstField = True, "", ",") & cbo.SelectedIndex)
                                            Else
                                                If cbo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & cbo.SelectedIndex)
                                                Else
                                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(cbo.EditValue.ToString))
                                                End If
                                            End If
                                        Else
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                        Dim dt As DevExpress.XtraEditors.DateEdit
                                        dt = Ctrl
                                        If dt.Text <> "" Then
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(CDate(dt.Text).ToString("yyyyMMdd")))
                                        Else
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                                        Dim spn As DevExpress.XtraEditors.SpinEdit
                                        spn = Ctrl
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(spn.Text))
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
                                        Dim txt As DevExpress.XtraEditors.MemoEdit
                                        txt = Ctrl
                                        If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.EditValue, True))
                                        Else
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ColorPickEdit Then
                                        Dim cpk As DevExpress.XtraEditors.ColorPickEdit
                                        cpk = Ctrl
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & cpk.Text)
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                        Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                        cbo = Ctrl
                                        If cbo.EditValue <> Nothing Then
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & cbo.SelectedIndex)
                                        Else
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                        Dim txt As DevExpress.XtraEditors.TextEdit
                                        txt = Ctrl
                                        If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.EditValue, True))
                                        Else
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                        End If
                                        '*******DevExpress.XtraEditors.ButtonEdit******
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ButtonEdit Then
                                        Dim txt As DevExpress.XtraEditors.ButtonEdit
                                        txt = Ctrl
                                        If txt.Properties.Tag = True Then
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.EditValue, True))
                                        Else
                                            sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                        Dim chk As DevExpress.XtraEditors.CheckEdit
                                        chk = Ctrl
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & chk.EditValue)
                                    End If
                                    IsFirstField = False
                                End If
                                'End If
NextItem:
                            End If
                        End If
                    End If
                Next
            Next
            sSQLF.Append(", [modifiedBy],[createdOn] ")
            sSQLF.Append(", [MachineName],[createdBy]) ")
            sSQLV.Append("," & toSQLValueS(UserProps.ID.ToString) & ", getdate() ")
            sSQLV.Append("," & toSQLValueS(UserProps.MachineName) & "," & toSQLValueS(UserProps.ID.ToString) & ")")
            sSQLF.AppendLine(sSQLV.ToString)
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQLF.ToString, CNDB)
                For I As Integer = 0 To UBound(FormHasPic)
                    If FormHasPic(I) = True Then
                        If pic(I).Text = "" Then
                            oCmd.Parameters.AddWithValue("@Photo" & I, "NULL")
                        Else
                            oCmd.Parameters.AddWithValue("@Photo" & I, pic(I).EditValue)
                        End If
                    End If
                Next
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    'Η InsertDataGRP χρησιμοποιείται για να αποθηκεύσει Data τους ενός LayoutGroupContol
    'Του στέλνεις 1 LayoutGroupContol και κάνει Loop τα LayoutItems
    Private Function InsertDataGRP(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup, ByVal sTable As String, Optional ByVal sGuid As String = "",
                                   Optional ByVal IgnoreVisibility As Boolean = False,
                                   Optional ByVal ExtraFields As String = "", Optional ByVal ExtraValues As String = "") As Boolean
        Dim sSQLF As New System.Text.StringBuilder ' Το 1ο StringField αφορά τα πεδία
        Dim sSQLV As New System.Text.StringBuilder ' Το 2ο StringField αφορά τις τιμές
        Dim IsFirstField As Boolean = True
        Dim TagValue As String()
        'Tag Value = 0 For Load
        'Tag Value = 1 For Insert
        'Tag Value = 2 For Update
        Try
            'Εαν η function καλεστεί με sGuid σημαίνει ότι θα πρε΄πει να καταχωρίσουμε εμείς το ID
            If sGuid.Length > 0 Then IsFirstField = False
            'FIELDS
            sSQLF.AppendLine("INSERT INTO " & sTable & "(" & IIf(sGuid.Length > 0, "ID", ""))
            If ExtraFields.Length > 0 Then sSQLF.AppendLine(IIf(IsFirstField = True, "", ",") & ExtraFields)
            'VALUES
            sSQLV.AppendLine("VALUES(" & IIf(sGuid.Length > 0, toSQLValueS(sGuid), ""))
            If ExtraValues.Length > 0 Then
                sSQLV.AppendLine(IIf(IsFirstField = True, "", ",") & ExtraValues)
                IsFirstField = False
            End If

            For Each item As BaseLayoutItem In GRP.Items
                If TypeOf item Is LayoutControlItem Then
                    Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                    If LItem.ControlName <> Nothing Then
                        'Γίνεται διαχείριση όταν υπάρχει RadioGroup με optionButtons
                        If TypeOf LItem.Control Is DevExpress.XtraEditors.RadioGroup Then
                            Dim RDG As DevExpress.XtraEditors.RadioGroup
                            RDG = LItem.Control
                            For i As Integer = 0 To RDG.Properties.Items.Count - 1
                                'Βάζω τις τιμές του TAG σε array
                                TagValue = RDG.Properties.Items(i).Tag.Split(",")
                                'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                                Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                                If value <> Nothing Then
                                    ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                    sSQLF.Append(IIf(IsFirstField = True, "", ",") & TagValue(0))
                                    If RDG.SelectedIndex = i Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS("True"))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS("False"))
                                    End If
                                End If
                            Next i
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
                            If value <> Nothing Then
                                ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                sSQLF.Append(IIf(IsFirstField = True, "", ",") & TagValue(0))
                                ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                                ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                                Dim Ctrl As Control = LItem.Control
                                If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                    Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(cbo.EditValue.ToString))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                    Dim dt As DevExpress.XtraEditors.DateEdit
                                    dt = Ctrl
                                    If dt.Text <> "" Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(CDate(dt.EditValue).ToString("yyyyMMdd")))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                                    Dim spn As DevExpress.XtraEditors.SpinEdit
                                    spn = Ctrl
                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(spn.Text))
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
                                    Dim txt As DevExpress.XtraEditors.MemoEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                    Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & cbo.SelectedIndex)
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                    End If

                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                    Dim txt As DevExpress.XtraEditors.TextEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Or
                                        txt.Properties.MaskSettings.MaskExpression = "c" Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                    End If
                                    '*******DevExpress.XtraEditors.ButtonEdit******
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ButtonEdit Then
                                    Dim txt As DevExpress.XtraEditors.ButtonEdit
                                    txt = Ctrl
                                    If txt.Properties.Tag = True Then
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                    Dim chk As DevExpress.XtraEditors.CheckEdit
                                    chk = Ctrl
                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & chk.EditValue)
                                End If
                                IsFirstField = False
                            End If
                            'End If
NextItem:
                        End If
                    End If
                End If
            Next
            sSQLF.Append(", [modifiedBy],[createdOn] ")
            sSQLF.Append(", [MachineName],[createdBy]) ")
            sSQLV.Append("," & toSQLValueS(UserProps.ID.ToString) & ", getdate() ")
            sSQLV.Append("," & toSQLValueS(UserProps.MachineName) & "," & toSQLValueS(UserProps.ID.ToString) & ")")

            sSQLF.AppendLine(sSQLV.ToString)
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQLF.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception

            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function UpdateNewData(ByVal Mode As InsertMode, ByVal sTable As String, Optional ByVal control As DevExpress.XtraLayout.LayoutControl = Nothing,
                                  Optional ByVal controls As List(Of Control) = Nothing, Optional ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup = Nothing,
                                  Optional ByVal sGuid As String = "", Optional ByVal IgnoreVisibility As Boolean = False,
                                  Optional GRD As DevExpress.XtraGrid.Views.Grid.GridView = Nothing,
                                  Optional ByVal FieldsToBeUpdate As List(Of String) = Nothing,
                                  Optional ExceptFields As List(Of String) = Nothing,
                                  Optional ByVal ExtraFieldsAndValues As String = "") As Boolean
        Select Case Mode
            Case 1
                Return UpdateData2(control, sTable, sGuid, IgnoreVisibility, ExtraFieldsAndValues)
            Case 2
                Return UpdateDataNew(controls, sTable, sGuid, IgnoreVisibility)
            Case 3
                Return UpdateDataGRP(GRP, sTable, sGuid, IgnoreVisibility, ExceptFields, ExtraFieldsAndValues)
            Case 4
                Return UpdateDataGRD(GRD, sTable, sGuid, FieldsToBeUpdate, IgnoreVisibility)
        End Select
    End Function
    Private Function UpdateData(ByVal control As DevExpress.XtraLayout.LayoutControl, ByVal sTable As String, ByVal sID As String, Optional ByVal IgnoreVisibility As Boolean = False) As Boolean
        Dim sSQL As New System.Text.StringBuilder ' Το 1ο StringField αφορά τα πεδία
        Dim IsFirstField As Boolean = True
        Dim TagValue As String()
        Dim FormHasPic(5) As Boolean
        Dim pic(5) As DevExpress.XtraEditors.PictureEdit
        'Tag Value = 0 For Load
        'Tag Value = 1 For Insert
        'Tag Value = 2 For Update
        Try
            'Εαν η function καλεστεί με sGuid σημαίνει ότι θα πρε΄πει να καταχωρίσουμε εμείς το ID
            'FIELDS
            sSQL.AppendLine("UPDATE " & sTable & " SET ")
            For Each item As BaseLayoutItem In control.Items
                If TypeOf item Is LayoutControlItem Then
                    Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                    If LItem.ControlName <> Nothing Then
                        'Γίνεται διαχείριση όταν υπάρχει RadioGroup με optionButtons
                        If TypeOf LItem.Control Is DevExpress.XtraEditors.RadioGroup Then
                            Dim RDG As DevExpress.XtraEditors.RadioGroup
                            RDG = LItem.Control
                            For i As Integer = 0 To RDG.Properties.Items.Count - 1
                                If RDG.Properties.Items(i).Tag <> "" Then
                                    'Βάζω τις τιμές του TAG σε array
                                    TagValue = RDG.Properties.Items(i).Tag.Split(",")
                                    'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                                    Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                                    If value <> Nothing Then
                                        ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                        sSQL.Append(IIf(IsFirstField = True, "", ",") & TagValue(0) & " = ")
                                        If RDG.SelectedIndex = i Then
                                            sSQL.Append(toSQLValueS("True"))
                                        Else
                                            sSQL.Append(toSQLValueS("False"))
                                        End If
                                    End If
                                End If
                            Next i
                        End If
                        ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                        If LItem.Control.Tag <> "" Then
                            'Βάζω τις τιμές του TAG σε array
                            TagValue = LItem.Control.Tag.ToString.Split(",")
                            'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                            Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                            ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                            If IgnoreVisibility = True Then
                                If LItem.Control.Visible = False Then GoTo NextItem
                            End If
                            'If LItem.Control.Visible = True 
                            If value <> Nothing Then
                                ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                sSQL.Append(IIf(IsFirstField = True, "", ",") & TagValue(0) & " = ")
                                ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                                ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                                Dim Ctrl As Control = LItem.Control
                                If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                    Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQL.Append(toSQLValueS(cbo.EditValue.ToString))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                    Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQL.Append(cbo.SelectedIndex)
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.GridLookUpEdit Then
                                    Dim cbo As DevExpress.XtraEditors.GridLookUpEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQL.Append(toSQLValueS(cbo.EditValue.ToString))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.PictureEdit Then
                                    For I As Integer = 0 To UBound(FormHasPic)
                                        If FormHasPic(I) = False Then
                                            FormHasPic(I) = True
                                            pic(I) = Ctrl
                                            If pic(I).Text <> "" Then
                                                sSQL.Append("@Photo" & I)
                                            Else
                                                sSQL.Append("NULL")
                                            End If
                                            Exit For
                                        End If
                                    Next
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ColorPickEdit Then
                                    Dim cpk As DevExpress.XtraEditors.ColorPickEdit
                                    cpk = Ctrl
                                    If cpk.Text = "0" Then
                                        sSQL.Append("NULL")
                                    Else
                                        sSQL.Append(cpk.Text)
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                    Dim dt As DevExpress.XtraEditors.DateEdit
                                    dt = Ctrl
                                    If dt.Text <> "" Then
                                        sSQL.Append(toSQLValueS(CDate(dt.Text).ToString("yyyyMMdd")))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraScheduler.DateNavigator Then
                                    Dim dt As DevExpress.XtraScheduler.DateNavigator
                                    dt = Ctrl
                                    If dt.EditValue.ToString <> "" Then
                                        sSQL.Append(toSQLValueS(CDate(dt.EditValue.ToString).ToString("yyyyMMdd")))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                                    Dim spn As DevExpress.XtraEditors.SpinEdit
                                    spn = Ctrl
                                    sSQL.Append(toSQLValueS(spn.Text))
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
                                    Dim txt As DevExpress.XtraEditors.MemoEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                        sSQL.Append(toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQL.Append(toSQLValueS(txt.Text))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                    Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQL.Append(cbo.SelectedIndex)
                                    Else
                                        sSQL.Append(IIf(IsFirstField = True, "", ",") & "NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                    Dim txt As DevExpress.XtraEditors.TextEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                        sSQL.Append(toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQL.Append(toSQLValueS(txt.Text.Replace("%", "")))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                    Dim chk As DevExpress.XtraEditors.CheckEdit
                                    chk = Ctrl
                                    sSQL.Append(chk.EditValue)
                                End If
                                IsFirstField = False
                            End If
                            'End If
NextItem:
                        End If
                    End If
                End If
            Next
            sSQL.Append(", [modifiedBy] = " & toSQLValueS(UserProps.ID.ToString))
            sSQL.Append(", [MachineName]= " & toSQLValueS(UserProps.MachineName))

            sSQL.Append("WHERE ID = " & toSQLValueS(sID))
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                For I As Integer = 0 To UBound(FormHasPic)
                    If FormHasPic(I) = True Then
                        If pic(I).Text = "" Then
                            oCmd.Parameters.AddWithValue("@Photo" & I, "NULL")
                        Else
                            oCmd.Parameters.AddWithValue("@Photo" & I, pic(I).EditValue)
                        End If
                    End If
                Next
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function UpdateData2(ByVal control As DevExpress.XtraLayout.LayoutControl, ByVal sTable As String, ByVal sID As String, Optional ByVal IgnoreVisibility As Boolean = False, Optional ByVal ExtraFieldsAndValues As String = "") As Boolean
        Dim sSQL As New System.Text.StringBuilder ' Το 1ο StringField αφορά τα πεδία
        Dim IsFirstField As Boolean = True
        Dim TagValue As String()
        Dim FormHasPic(5) As Boolean
        Dim pic(5) As DevExpress.XtraEditors.PictureEdit
        'Tag Value = 0 For Load
        'Tag Value = 1 For Insert
        'Tag Value = 2 For Update
        Try
            'Εαν η function καλεστεί με sGuid σημαίνει ότι θα πρε΄πει να καταχωρίσουμε εμείς το ID
            'FIELDS
            sSQL.AppendLine("UPDATE " & sTable & " SET ")
            If ExtraFieldsAndValues.Length > 0 Then sSQL.AppendLine(ExtraFieldsAndValues) : IsFirstField = False
            For Each item As BaseLayoutItem In control.Items
                If TypeOf item Is LayoutControlItem Then
                    Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                    If LItem.ControlName <> Nothing Then
                        'Γίνεται διαχείριση όταν υπάρχει RadioGroup με optionButtons
                        If TypeOf LItem.Control Is DevExpress.XtraEditors.RadioGroup Then
                            Dim RDG As DevExpress.XtraEditors.RadioGroup
                            RDG = LItem.Control
                            For i As Integer = 0 To RDG.Properties.Items.Count - 1
                                If RDG.Properties.Items(i).Tag <> "" Then
                                    'Βάζω τις τιμές του TAG σε array
                                    TagValue = RDG.Properties.Items(i).Tag.Split(",")
                                    'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                                    Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                                    If value <> Nothing Then
                                        ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                        sSQL.Append(IIf(IsFirstField = True, "", ",") & TagValue(0) & " = ")
                                        If RDG.SelectedIndex = i Then
                                            sSQL.Append(toSQLValueS("True"))
                                        Else
                                            sSQL.Append(toSQLValueS("False"))
                                        End If
                                    End If
                                End If
                            Next i
                        End If
                        ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                        If LItem.Control.Tag <> "" Then
                            'Βάζω τις τιμές του TAG σε array
                            TagValue = LItem.Control.Tag.ToString.Split(",")
                            'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                            Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                            ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                            If IgnoreVisibility = True Then
                                If LItem.Control.Visible = False Then GoTo NextItem
                            End If
                            'If LItem.Control.Visible = True 
                            If value <> Nothing Then
                                ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                sSQL.Append(IIf(IsFirstField = True, "", ",") & TagValue(0) & " = ")
                                ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                                ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                                Dim Ctrl As Control = LItem.Control
                                If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                    Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQL.Append(toSQLValueS(cbo.EditValue.ToString))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.PictureEdit Then
                                    For I As Integer = 0 To UBound(FormHasPic)
                                        If FormHasPic(I) = False Then
                                            FormHasPic(I) = True
                                            pic(I) = Ctrl
                                            If pic(I).Text <> "" Then
                                                sSQL.Append("@Photo" & I)
                                            Else
                                                sSQL.Append("NULL")
                                            End If
                                            Exit For
                                        End If
                                    Next
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                    Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        If cbo.EditValue = "False" Or cbo.EditValue = "True" Then
                                            sSQL.Append(cbo.SelectedIndex)
                                        Else
                                            If cbo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                                sSQL.Append(cbo.SelectedIndex)
                                            Else
                                                sSQL.Append(toSQLValueS(cbo.EditValue.ToString))
                                            End If
                                        End If
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                    Dim dt As DevExpress.XtraEditors.DateEdit
                                    dt = Ctrl
                                    If dt.Text <> "" Then
                                        sSQL.Append(toSQLValueS(CDate(dt.Text).ToString("yyyyMMdd")))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraScheduler.DateNavigator Then
                                    Dim dt As DevExpress.XtraScheduler.DateNavigator
                                    dt = Ctrl
                                    If dt.EditValue.ToString <> "" Then
                                        sSQL.Append(toSQLValueS(CDate(dt.EditValue.ToString).ToString("yyyyMMdd")))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                                    Dim spn As DevExpress.XtraEditors.SpinEdit
                                    spn = Ctrl
                                    sSQL.Append(toSQLValueS(spn.Text))
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ColorPickEdit Then
                                    Dim cpk As DevExpress.XtraEditors.ColorPickEdit
                                    cpk = Ctrl
                                    If cpk.Text = "0" Then
                                        sSQL.Append("NULL")
                                    Else
                                        sSQL.Append(cpk.Text)
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
                                    Dim txt As DevExpress.XtraEditors.MemoEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                        sSQL.Append(toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQL.Append(toSQLValueS(txt.Text))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                    Dim txt As DevExpress.XtraEditors.TextEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                        sSQL.Append(toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQL.Append(toSQLValueS(txt.Text.Replace("%", "")))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                    Dim chk As DevExpress.XtraEditors.CheckEdit
                                    chk = Ctrl
                                    sSQL.Append(chk.EditValue)
                                End If
                                IsFirstField = False
                            End If
                            'End If
NextItem:
                        End If
                    End If
                End If
            Next
            sSQL.Append(", [modifiedBy] = " & toSQLValueS(UserProps.ID.ToString))
            sSQL.Append(", [MachineName]= " & toSQLValueS(UserProps.MachineName))
            sSQL.Append("WHERE ID = " & toSQLValueS(sID))
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)

                For I As Integer = 0 To UBound(FormHasPic)
                    If FormHasPic(I) = True Then
                        If pic(I).Text = "" Then
                            oCmd.Parameters.AddWithValue("@Photo" & I, "NULL")
                        Else
                            oCmd.Parameters.AddWithValue("@Photo" & I, pic(I).EditValue)
                        End If
                    End If
                Next
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function UpdateDataNew(ByVal controls As List(Of Control), ByVal sTable As String, ByVal sID As String,
                                   Optional ByVal IgnoreVisibility As Boolean = False, Optional ByVal ExtraFieldsAndValues As String = "") As Boolean
        Dim sSQL As New System.Text.StringBuilder ' Το 1ο StringField αφορά τα πεδία
        Dim IsFirstField As Boolean = True
        Dim TagValue As String()
        Dim FormHasPic(5) As Boolean
        Dim pic(5) As DevExpress.XtraEditors.PictureEdit
        'Tag Value = 0 For Load
        'Tag Value = 1 For Insert
        'Tag Value = 2 For Update
        Try
            'Εαν η function καλεστεί με sGuid σημαίνει ότι θα πρε΄πει να καταχωρίσουμε εμείς το ID
            'FIELDS
            sSQL.AppendLine("UPDATE " & sTable & " SET ")
            If ExtraFieldsAndValues.Length > 0 Then sSQL.AppendLine(ExtraFieldsAndValues) : IsFirstField = False
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
                                    If RDG.Properties.Items(i).Tag <> Nothing Then
                                        'Βάζω τις τιμές του TAG σε array
                                        TagValue = RDG.Properties.Items(i).Tag.Split(",")
                                        'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                                        Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                                        If value <> Nothing Then
                                            ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                            sSQL.Append(IIf(IsFirstField = True, "", ",") & TagValue(0) & " = ")
                                            If RDG.SelectedIndex = i Then
                                                sSQL.Append(toSQLValueS("True"))
                                            Else
                                                sSQL.Append(toSQLValueS("False"))
                                            End If
                                        End If
                                    End If
                                Next i
                            End If
                            ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                            If LItem.Control.Tag <> "" Then
                                'Βάζω τις τιμές του TAG σε array
                                TagValue = LItem.Control.Tag.ToString.Split(",")
                                'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                                Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                                ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                                If IgnoreVisibility = True Then
                                    If LItem.Control.Visible = False Then GoTo NextItem
                                End If
                                'If LItem.Control.Visible = True 
                                If value <> Nothing Then
                                    ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                    sSQL.Append(IIf(IsFirstField = True, "", ",") & TagValue(0) & " = ")
                                    ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                                    ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                                    Dim Ctrl As Control = LItem.Control
                                    If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                        Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                        cbo = Ctrl
                                        If cbo.EditValue <> Nothing Then
                                            sSQL.Append(toSQLValueS(cbo.EditValue.ToString))
                                        Else
                                            sSQL.Append("NULL")
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.PictureEdit Then
                                        For I As Integer = 0 To UBound(FormHasPic)
                                            If FormHasPic(I) = False Then
                                                FormHasPic(I) = True
                                                pic(I) = Ctrl
                                                If pic(I).Text <> "" Then
                                                    sSQL.Append("@Photo" & I)
                                                Else
                                                    sSQL.Append("NULL")
                                                End If
                                                Exit For
                                            End If
                                        Next
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                        Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                        cbo = Ctrl
                                        If cbo.EditValue <> Nothing Then
                                            If cbo.EditValue = "False" Or cbo.EditValue = "True" Then
                                                sSQL.Append(cbo.SelectedIndex)
                                            Else
                                                If cbo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                                    sSQL.Append(cbo.SelectedIndex)
                                                Else
                                                    sSQL.Append(toSQLValueS(cbo.EditValue.ToString))
                                                End If
                                            End If
                                        Else
                                            sSQL.Append("NULL")
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                        Dim dt As DevExpress.XtraEditors.DateEdit
                                        dt = Ctrl
                                        If dt.Text <> "" Then
                                            sSQL.Append(toSQLValueS(CDate(dt.Text).ToString("yyyyMMdd")))
                                        Else
                                            sSQL.Append("NULL")
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                                        Dim spn As DevExpress.XtraEditors.SpinEdit
                                        spn = Ctrl
                                        sSQL.Append(toSQLValueS(spn.Text))
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ColorPickEdit Then
                                        Dim cpk As DevExpress.XtraEditors.ColorPickEdit
                                        cpk = Ctrl
                                        If cpk.Text = "0" Then
                                            sSQL.Append("NULL")
                                        Else
                                            sSQL.Append(cpk.Text)
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
                                        Dim txt As DevExpress.XtraEditors.MemoEdit
                                        txt = Ctrl
                                        If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                            sSQL.Append(toSQLValueS(txt.EditValue, True))
                                        Else
                                            sSQL.Append(toSQLValueS(txt.Text))
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                        Dim txt As DevExpress.XtraEditors.TextEdit
                                        txt = Ctrl
                                        If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                            sSQL.Append(toSQLValueS(txt.EditValue, True))
                                        Else
                                            sSQL.Append(toSQLValueS(txt.Text.Replace("%", "")))
                                        End If
                                    ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                        Dim chk As DevExpress.XtraEditors.CheckEdit
                                        chk = Ctrl
                                        sSQL.Append(chk.EditValue)
                                    End If
                                    IsFirstField = False
                                End If
                                'End If
NextItem:
                            End If

                        End If
                    End If
                Next
            Next
            sSQL.Append(", [modifiedBy] = " & toSQLValueS(UserProps.ID.ToString))
            sSQL.Append(", [MachineName]= " & toSQLValueS(UserProps.MachineName))
            sSQL.Append("WHERE ID = " & toSQLValueS(sID))
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)

                For I As Integer = 0 To UBound(FormHasPic)
                    If FormHasPic(I) = True Then
                        If pic(I).Text = "" Then
                            oCmd.Parameters.AddWithValue("@Photo" & I, "NULL")
                        Else
                            oCmd.Parameters.AddWithValue("@Photo" & I, pic(I).EditValue)
                        End If
                    End If
                Next
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function UpdateDataGRP(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup, ByVal sTable As String, ByVal sID As String,
                                   Optional ByVal IgnoreVisibility As Boolean = False, Optional ExceptFields As List(Of String) = Nothing,
                                   Optional ByVal ExtraFieldsAndValues As String = "") As Boolean
        Dim sSQL As New System.Text.StringBuilder ' Το 1ο StringField αφορά τα πεδία
        Dim IsFirstField As Boolean = True
        Dim TagValue As String()
        Dim FormHasPic As Boolean = False
        Dim pic As DevExpress.XtraEditors.PictureEdit

        'Tag Value = 0 For Load
        'Tag Value = 1 For Insert
        'Tag Value = 2 For Update
        Try
            'Εαν η function καλεστεί με sGuid σημαίνει ότι θα πρε΄πει να καταχωρίσουμε εμείς το ID
            'FIELDS
            sSQL.AppendLine("UPDATE " & sTable & " SET ")
            If ExtraFieldsAndValues.Length > 0 Then sSQL.AppendLine(ExtraFieldsAndValues) : IsFirstField = False
            For Each item As BaseLayoutItem In GRP.Items
                If TypeOf item Is LayoutControlItem Then
                    Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                    If LItem.ControlName <> Nothing Then
                        'Γίνεται διαχείριση όταν υπάρχει RadioGroup με optionButtons
                        If TypeOf LItem.Control Is DevExpress.XtraEditors.RadioGroup Then
                            Dim RDG As DevExpress.XtraEditors.RadioGroup
                            RDG = LItem.Control
                            For i As Integer = 0 To RDG.Properties.Items.Count - 1
                                'Βάζω τις τιμές του TAG σε array
                                TagValue = RDG.Properties.Items(i).Tag.Split(",")
                                'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                                Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                                If value <> Nothing Then
                                    ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                    sSQL.Append(IIf(IsFirstField = True, "", ",") & TagValue(0) & " = ")
                                    If RDG.SelectedIndex = i Then
                                        sSQL.Append(toSQLValueS("True"))
                                    Else
                                        sSQL.Append(toSQLValueS("False"))
                                    End If
                                End If
                            Next i
                        End If
                        ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                        If LItem.Control.Tag <> "" Then
                            'Βάζω τις τιμές του TAG σε array
                            TagValue = LItem.Control.Tag.ToString.Split(",")
                            'Ψάχνω αν το πεδίο έχει δικάιωμα μεταβολής
                            Dim value As String = Array.Find(TagValue, Function(x) (x.StartsWith("2")))
                            ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                            If IgnoreVisibility = True Then
                                If LItem.Control.Visible = False Then GoTo NextItem
                            End If
                            'If LItem.Control.Visible = True 
                            If value <> Nothing Then
                                If ExceptFields IsNot Nothing Then
                                    If IsExceptedField(LItem, ExceptFields) Then GoTo NextItem
                                End If
                                ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                sSQL.Append(IIf(IsFirstField = True, "", ",") & TagValue(0) & " = ")
                                ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                                ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                                Dim Ctrl As Control = LItem.Control
                                If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                    Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                    cbo = Ctrl
                                    If cbo.EditValue IsNot Nothing Then
                                        sSQL.Append(toSQLValueS(cbo.EditValue.ToString))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
                                    Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQL.Append(cbo.SelectedIndex)
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.GridLookUpEdit Then
                                    Dim cbo As DevExpress.XtraEditors.GridLookUpEdit
                                    cbo = Ctrl
                                    If cbo.EditValue <> Nothing Then
                                        sSQL.Append(toSQLValueS(cbo.EditValue.ToString))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.PictureEdit Then
                                    pic = Ctrl
                                    FormHasPic = True
                                    If pic.Text <> "" Then
                                        sSQL.Append("@Photo")
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
                                    Dim dt As DevExpress.XtraEditors.DateEdit
                                    dt = Ctrl
                                    If dt.Text <> "" Then
                                        sSQL.Append(toSQLValueS(CDate(dt.Text).ToString("yyyyMMdd")))
                                    Else
                                        sSQL.Append("NULL")
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.SpinEdit Then
                                    Dim spn As DevExpress.XtraEditors.SpinEdit
                                    spn = Ctrl
                                    sSQL.Append(toSQLValueS(spn.Text))
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
                                    Dim txt As DevExpress.XtraEditors.MemoEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                        sSQL.Append(toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQL.Append(toSQLValueS(txt.Text))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                    Dim txt As DevExpress.XtraEditors.TextEdit
                                    txt = Ctrl
                                    If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Or txt.Properties.Mask.MaskType = Mask.MaskType.Numeric Or txt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric Then
                                        sSQL.Append(toSQLValueS(txt.EditValue, True))
                                    Else
                                        sSQL.Append(toSQLValueS(txt.Text))
                                    End If
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                    Dim chk As DevExpress.XtraEditors.CheckEdit
                                    chk = Ctrl
                                    sSQL.Append(chk.EditValue)
                                End If
                                IsFirstField = False
                            End If
                            'End If
NextItem:
                        End If
                    End If
                End If
            Next
            sSQL.Append(", [modifiedBy] = " & toSQLValueS(UserProps.ID.ToString))
            sSQL.Append(", [MachineName]= " & toSQLValueS(UserProps.MachineName))
            sSQL.Append("WHERE ID = " & toSQLValueS(sID))
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                If FormHasPic Then
                    If pic.Text = "" Then
                        oCmd.Parameters.AddWithValue("@Photo", "NULL")
                    Else
                        oCmd.Parameters.AddWithValue("@Photo", pic.EditValue)
                    End If
                End If
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
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

    'Διαβάζει τις στήλες ενός GRID δυναμικά και τα πεδία ενός LayoutControlGroup δυναμικά και κάνει Update
    Public Function UpdateDataGRD(ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sTable As String, ByVal sID As String, ByVal FieldsToBeUpdate As List(Of String), Optional ByVal IgnoreVisibility As Boolean = False)
        Dim sSQL As New System.Text.StringBuilder
        Dim sDate As DateTime
        Try
            sSQL.AppendLine("UPDATE " & sTable & " SET ")
            For Each column As DevExpress.XtraGrid.Columns.GridColumn In GRD.Columns
                If column.Visible = True Then
                    If FieldsToBeUpdate.Contains(column.FieldName) Then
                        If GRD.GetRowCellValue(GRD.FocusedRowHandle, column.FieldName) IsNot DBNull.Value Then
                            Select Case column.ColumnType.Name
                                Case "Guid" : sSQL.AppendLine("[" & column.FieldName & "]" & "=" & toSQLValueS(GRD.GetRowCellValue(GRD.FocusedRowHandle, column.FieldName).ToString))
                                Case "Int32" : sSQL.AppendLine("[" & column.FieldName & "]" & "=" & toSQLValueS(GRD.GetRowCellValue(GRD.FocusedRowHandle, column.FieldName).ToString, True))
                                Case "DateTime"
                                    sDate = GRD.GetRowCellValue(GRD.FocusedRowHandle, column.FieldName)

                                    sSQL.AppendLine("[" & column.FieldName & "]" & "=" & toSQLValueS(sDate.ToString("yyyyMMdd")))

                                Case "Decimal" : sSQL.AppendLine("[" & column.FieldName & "]" & "=" & toSQLValueS(GRD.GetRowCellValue(GRD.FocusedRowHandle, column.FieldName).ToString, True))
                                Case "String" : sSQL.AppendLine("[" & column.FieldName & "]" & "=" & toSQLValueS(GRD.GetRowCellValue(GRD.FocusedRowHandle, column.FieldName).ToString))
                            End Select
                            sSQL.AppendLine(",")
                        End If
                    End If
                End If
            Next
            sSQL.Append(" [modifiedBy] = " & toSQLValueS(UserProps.ID.ToString))
            sSQL.Append(", [MachineName]= " & toSQLValueS(UserProps.MachineName))
            sSQL.Append("WHERE ID = " & toSQLValueS(sID))
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using

            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
End Class
