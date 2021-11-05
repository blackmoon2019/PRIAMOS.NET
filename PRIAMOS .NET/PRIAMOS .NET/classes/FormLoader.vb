Imports System.Data.SqlClient
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository

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
                                    If IgnoreVisibility = True Then
                                        If LItem.Control.Visible = False Then GoTo NextItem
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
                                If IgnoreVisibility = True Then
                                    If LItem.Control.Visible = False Then GoTo NextItem
                                End If

                                ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                                'If LItem.Control.Visible = True Then
                                If value <> Nothing Then
                                    TagV = TagValue(0).Replace("[", "").Replace("]", "")
                                    Console.WriteLine(TagV)
                                    'Function που ελέγχει αν υπάρχει ενα πεδίο μέσα στον SQLDataReader
                                    If ColumnExistToDataReader(sdr, TagV) = False Then GoTo NextItem
                                    sdr.GetDataTypeName(sdr.GetOrdinal(TagV))
                                    Dim index = sdr.GetOrdinal(TagV)
                                    Console.WriteLine(sdr.GetDataTypeName(index))
                                    'If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetBoolean(sdr.GetOrdinal(TagV)))
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
                                        Case "date"
                                            If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetDateTime(sdr.GetOrdinal(TagV)))
                                        Case "varbinary"
                                            If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then
                                                Dim pic As DevExpress.XtraEditors.PictureEdit
                                                Dim bytes As Byte()
                                                pic = LItem.Control
                                                bytes = DirectCast(sdr(TagV), Byte())
                                                pic.EditValue = bytes
                                            End If
                                    End Select
                                End If
NextItem:
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
    Public Function LoadFormGRP(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup, ByVal sSQL As String) As Boolean

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
                For Each item As BaseLayoutItem In GRP.Items
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
                                If LItem.Control.Visible = True Then
                                    If value <> Nothing Then
                                        TagV = TagValue(0).Replace("[", "").Replace("]", "")
                                        Console.WriteLine(TagV)
                                        If sdr.GetSchemaTable().Select("ColumnName='" & TagV & "'").Length > 0 Then
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
                                                Case "date"
                                                    If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then SetValueToControl(LItem, sdr.GetDateTime(sdr.GetOrdinal(TagV)))
                                                Case "varbinary"
                                                    If sdr.IsDBNull(sdr.GetOrdinal(TagV)) = False Then
                                                        Dim pic As DevExpress.XtraEditors.PictureEdit
                                                        Dim bytes As Byte()
                                                        pic = LItem.Control
                                                        bytes = DirectCast(sdr(TagV), Byte())
                                                        pic.EditValue = bytes
                                                    End If
                                            End Select
                                        End If
                                    End If
                                End If
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
    Private Function ColumnExistToDataReader(ByVal sdr As SqlDataReader, ByVal sColName As String) As Boolean
        sdr.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" + sColName + "'"
        Return (sdr.GetSchemaTable().DefaultView.Count > 0)
    End Function
    Private Sub SetValueToControl(ByVal LItem As LayoutControlItem, ByVal sValue As String)
        Dim Ctrl As Control = LItem.Control
        If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
            Dim cbo As DevExpress.XtraEditors.LookUpEdit
            Dim stestGuid As Guid
            Dim isint As Integer
            Dim isValid As Boolean = Guid.TryParse(sValue, stestGuid)
            cbo = Ctrl
            If isValid = True Then
                cbo.EditValue = System.Guid.Parse(sValue)
            Else
                If Integer.TryParse(sValue, isint) Then
                    cbo.EditValue = Convert.ToInt32(sValue)
                Else
                    cbo.EditValue = sValue
                End If
            End If
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.DateEdit Then
            Dim dt As DevExpress.XtraEditors.DateEdit
            dt = Ctrl
            dt.EditValue = CDate(sValue)
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TimeEdit Then
            Dim tm As DevExpress.XtraEditors.TimeEdit
            tm = Ctrl

            tm.EditValue = CDate(sValue).ToString("HH:mm")
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.MemoEdit Then
            Dim txt As DevExpress.XtraEditors.MemoEdit
            txt = Ctrl
            If txt.Properties.Mask.EditMask = "c" & ProgProps.Decimals Then
                txt.Text = Math.Round(CDec(sValue), ProgProps.Decimals)
            Else
                txt.Text = sValue
            End If
        ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.ComboBoxEdit Then
            Dim cbo As DevExpress.XtraEditors.ComboBoxEdit
            cbo = Ctrl
            If sValue = False Then cbo.SelectedIndex = 0 Else cbo.SelectedIndex = 1
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
    Public Sub LoadDataToGrid(ByRef GRDControl As DevExpress.XtraGrid.GridControl, ByRef GRDView As DevExpress.XtraGrid.Views.Grid.GridView,
                              ByVal sSQL As String, Optional ByVal AddColumnButton As Boolean = False)
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        Dim dt As New DataTable("sTable")
        Dim sTable As DataTable
        Try
            myCmd = CNDB.CreateCommand
            myCmd.CommandText = sSQL
            GRDView.Columns.Clear()
            myReader = myCmd.ExecuteReader()
            dt.Load(myReader)
            GRDControl.DataSource = dt
            GRDControl.ForceInitialize()
            GRDControl.DefaultView.PopulateColumns()
            'Προσθήκη Στήλης BUTTON(Θα πρέπει στον Designer να έχω προσθέσει ενα repositoryitem τύπου Button)
            If AddColumnButton Then
                Dim C2 As New GridColumn
                Dim Btn As New RepositoryItemButtonEdit()
                Btn = GRDControl.RepositoryItems.Item(0)
                Btn.ContextImageOptions.Image = My.Resources.icons8_upload_link_document_16
                C2.ColumnEdit = Btn
                C2.VisibleIndex = 0
                GRDView.Columns.Add(C2)
            End If
            If dt.Rows.Count = 0 And GRDView.Columns.Count = 0 Then
                For Each myField As DataColumn In dt.Columns
                    Dim columnNameValue As String = myField.ColumnName
                    Dim C As New GridColumn
                    C.Name = columnNameValue
                    C.Caption = columnNameValue
                    C.Visible = True
                    GRDView.Columns.Add(C)
                Next
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub LoadColumnDescriptionNames(ByRef GRDControl As DevExpress.XtraGrid.GridControl, ByRef GRDView As DevExpress.XtraGrid.Views.Grid.GridView,
                                          Optional ByVal sTable As String = "", Optional ByVal sView As String = "")
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        Dim sSQL As String
        Dim dt As New DataTable("sTable")
        Try
            If sView.Length > 0 Then
                sSQL = "Select  VIEW_COLUMN_NAME = c.name,VIEW_CATALOG,VIEW_SCHEMA,VIEW_NAME,TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,ISNULL(c.name,COLUMN_NAME) AS COLUMN_NAME, ISNULL(ep.value,ISNULL(c.name,COLUMN_NAME)) As 'COLUMN_DESCRIPTION'
                        From sys.columns c
                        INNER Join sys.views vw on c.OBJECT_ID = vw.OBJECT_ID
                        INNER Join sys.schemas s ON s.schema_id = vw.schema_id
                        Left Join INFORMATION_SCHEMA.VIEW_COLUMN_USAGE vcu on vw.name = vcu.VIEW_NAME And s.name = vcu.VIEW_SCHEMA And c.name = vcu.COLUMN_NAME
                        Left Join(
                            SELECT distinct SCM_Name=SCM.Name, TBL_Name = TBL.name, COLName = COL.name, COL_Object_id = COL.object_id, COL_column_id = COL.column_id
                            FROM
                            SYS.COLUMNS COL
                            INNER Join SYS.TABLES TBL on COL.object_id = TBL.object_id
                            INNER Join SYS.SCHEMAS SCM ON TBL.schema_id = SCM.schema_id) tempTBL on tempTBL.TBL_Name=vcu.TABLE_NAME And tempTBL.SCM_Name=TABLE_SCHEMA And tempTBL.COLName = vcu.COLUMN_NAME
                        Left Join sys.extended_properties ep on tempTBL.COL_Object_id = ep.major_id And tempTBL.COL_column_id = ep.minor_id
                        where vw.NAME = '" & sView & "'"
            ElseIf sTable.Length > 0 Then
                sSQL = "Select   objname, [value] FROM fn_listextendedproperty(NULL, 'SCHEMA', 'dbo', 'TABLE', '" & sTable & "','COLUMN', NULL)"
            Else
                Exit Sub
            End If

            myCmd = CNDB.CreateCommand
            myCmd.CommandText = sSQL
            myReader = myCmd.ExecuteReader()
            dt.Load(myReader)
            For Each row As DataRow In dt.Rows
                Dim columnName As String = row.Item("COLUMN_NAME").ToString
                Dim columnNameValue As String = row.Item("COLUMN_DESCRIPTION").ToString

                If columnName.Length > 0 And columnNameValue.Length > 0 Then
                    Dim C As New GridColumn
                    C = GRDView.Columns.ColumnByName("col" & columnName)
                    If C IsNot Nothing Then
                        If C.Caption = "" Then C.Caption = columnNameValue
                        C = Nothing
                    End If
                End If
                'If columnName.Length > 0 And GRDView.Columns.Item(columnName) IsNot Nothing Then GRDView.Columns.Item(columnName).Caption = columnNameValue
            Next
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "Dreamy Kitchen CRM", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Φορτώνει ενα query σε στήλες στο Grid
    Public Sub LoadColumnsandRowsToGridFromSQL(ByRef GRDControl As DevExpress.XtraGrid.GridControl, ByRef GRDView As DevExpress.XtraGrid.Views.Grid.GridView,
                                       ByVal sSQLColumns As String, ByVal sSQLRows As String, ByVal FieldToColumn As String, Optional ByVal AddColumnButton As Boolean = False)
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        Dim dt As New DataTable("sTable")
        Try
            myCmd = CNDB.CreateCommand
            myCmd.CommandText = sSQLColumns
            GRDView.Columns.Clear()
            myReader = myCmd.ExecuteReader()
            dt.Load(myReader)

            For Each row As DataRow In dt.Rows
                Dim C As New GridColumn
                dt.Columns.Add(row.Item(FieldToColumn).ToString, GetType(Double))
                C.Caption = row.Item(FieldToColumn).ToString
                C.FieldName = row.Item(FieldToColumn).ToString
                C.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                C.Visible = True
                GRDView.Columns.Add(C)
            Next row

            myCmd = Nothing
            myCmd = CNDB.CreateCommand
            myCmd.CommandText = sSQLRows
            myReader = myCmd.ExecuteReader()
            dt = Nothing
            dt = New DataTable("sTable")
            dt.Load(myReader)
            For Each row As DataRow In dt.Rows

                GRDView.AddNewRow()
                'set a new row cell value. The static GridControl.NewItemRowHandle field allows you to retrieve the added row
                GRDView.SetRowCellValue(GRDControl.NewItemRowHandle, GRDView.Columns(0), "1.44")
            Next row

            'GRDControl.DataSource = dt
            'GRDControl.ForceInitialize()
            'GRDControl.DefaultView.PopulateColumns()

            'Προσθήκη Στήλης BUTTON(Θα πρέπει στον Designer να έχω προσθέσει ενα repositoryitem τύπου Button)
            If AddColumnButton Then
                Dim C2 As New GridColumn
                Dim Btn As New RepositoryItemButtonEdit()
                Btn = GRDControl.RepositoryItems.Item(0)
                Btn.ContextImageOptions.Image = My.Resources.icons8_upload_link_document_16
                C2.ColumnEdit = Btn
                C2.VisibleIndex = 0
                GRDView.Columns.Add(C2)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

