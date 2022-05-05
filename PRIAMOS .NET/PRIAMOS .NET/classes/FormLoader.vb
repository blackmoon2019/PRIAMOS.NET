Imports System.Data.SqlClient
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Menu
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils

Public Class FormLoader
    Private GRDview As GridView
    Private XMLName As String
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
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Public Function GetFile(ByVal sRowID As String, ByVal sTable As String) As Byte()
        Dim sSQL As String
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim bytes As Byte()

        sSQL = "Select  files From " & sTable & " WHERE ID = " & toSQLValueS(sRowID)
        cmd = New SqlCommand(sSQL, CNDB) : sdr = cmd.ExecuteReader()
        If sdr.Read() = True Then
            bytes = DirectCast(sdr("files"), Byte())
            sdr.Close()
            Return bytes
        End If
        sdr.Close()

    End Function

    Public Sub RestoreLayoutFromXml(ByVal GridView As GridView, ByVal sXMLName As String)
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\" & sXMLName) Then GridView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sXMLName, OptionsLayoutBase.FullLayout)
    End Sub
    Public Sub PopupMenuShow(ByVal e As Views.Grid.PopupMenuShowingEventArgs, ByVal GridView As GridView, ByVal sXMLName As String)
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()
            GRDview = GridView : XMLName = sXMLName
            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnEditValueChanged, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex

                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItem("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnColumnsColorChanged, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex
                '4nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Εκτύπωση όψης", AddressOf OnPrintView, Nothing, Nothing, Nothing, Nothing))
                '5nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Αποθήκευση όψης", AddressOf OnSaveView, Nothing, Nothing, Nothing, Nothing))
                '6nd Custom Menu Item
                menu.Items.Add(New DXMenuItem("Συγχρονισμός όψης από Server", AddressOf OnSyncView, Nothing, Nothing, Nothing, Nothing))


            End If
        End If

    End Sub
    'Μετονομασία Στήλης Master
    Private Sub OnEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GRDview.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    Private Function CreateCheckItem(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GRDview.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Κλείδωμα Στήλης Master
    Private Sub OnCanMoveItemClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    'Αποθήκευση όψης 
    Private Sub OnSaveView(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim grdVer As Decimal
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        grdVer = IIf(GRDview.OptionsLayout.LayoutVersion = "", 0.5, GRDview.OptionsLayout.LayoutVersion)
        grdVer = grdVer + 0.5 : GRDview.OptionsLayout.LayoutVersion = grdVer
        GRDview.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\" & XMLName, OptionsLayoutBase.FullLayout)
        '  GridView7.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\APMIL_D_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκεύτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If UserProps.ID.ToString.ToUpper = "E9CEFD11-47C0-4796-A46B-BC41C4C3606B" Or
           UserProps.ID.ToString.ToUpper = "526EAA73-3B21-4BEE-A575-F19BD2BC5FCF" Or
           UserProps.ID.ToString.ToUpper = "97E2CB01-93EA-4F97-B000-FDA359EC943C" Then
            If XtraMessageBox.Show("Θέλετε να γίνει κοινοποίηση της όψης? Εαν επιλέξετε 'Yes' όλοι οι χρήστες θα έχουν την ίδια όψη", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If My.Computer.FileSystem.FileExists(UserProps.ServerViewsPath & "DSGNS\DEF\" & XMLName) = False Then GRDview.OptionsLayout.LayoutVersion = "v1"
                '    If My.Computer.FileSystem.FileExists(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml") = False Then GridView7.OptionsLayout.LayoutVersion = "v1"
                GRDview.SaveLayoutToXml(UserProps.ServerViewsPath & "DSGNS\DEF\" & XMLName, OptionsLayoutBase.FullLayout)
                '        GridView7.SaveLayoutToXml(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml", OptionsLayoutBase.FullLayout)
            End If
        End If
    End Sub

    'Εκτύπωση Όψης
    Private Sub OnPrintView(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXMenuItem = TryCast(sender, DXMenuItem)
        GRDview.GridControl.ShowRibbonPrintPreview()
    End Sub
    'Συγχρονισμός όψης από Server
    Private Sub OnSyncView(ByVal sender As System.Object, ByVal e As EventArgs)
        If XtraMessageBox.Show("Θέλετε να γίνει μεταφορά της όψης από τον server?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            ' Έλεγχος αν υπάρχει όψη με μεταγενέστερη ημερομηνία στον Server
            If System.IO.File.Exists(UserProps.ServerViewsPath & "DSGNS\DEF\" & XMLName) = True Then
                My.Computer.FileSystem.CopyFile(UserProps.ServerViewsPath & "DSGNS\DEF\" & XMLName, Application.StartupPath & "\DSGNS\DEF\" & XMLName, True)
                GRDview.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & XMLName, OptionsLayoutBase.FullLayout)
            End If
            'If System.IO.File.Exists(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml") = True Then
            '    My.Computer.FileSystem.CopyFile(UserProps.ServerViewsPath & "DSGNS\DEF\APMIL_D_def.xml", Application.StartupPath & "\DSGNS\DEF\APMIL_D_def.xml", True)
            '    '        GridView7.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\APMIL_D_def.xml", OptionsLayoutBase.FullLayout)
            'End If

        End If
    End Sub
    Friend Class MenuColumnInfo
        Public Sub New(ByVal column As GridColumn)
            Me.Column = column
        End Sub
        Public Column As GridColumn
    End Class

End Class

