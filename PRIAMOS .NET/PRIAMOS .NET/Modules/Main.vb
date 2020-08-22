Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns

Module Main
    Public CNDB As New SqlConnection()
    Enum FormMode
        NewRecord = 1
        EditRecord = 2
        DeleteRecord = 3
        ViewRecord = 4
    End Enum
    Public Structure USER_PROPS
        Public ID As Guid
        Public Code As String
        Public RealName As String
        Public UN As String
        Public PWD As String
        Public DataTable As String
        Public CurrentView As String
    End Structure
    Public UserProps As USER_PROPS
    Public Function toSQLValue(t As DevExpress.XtraEditors.TextEdit, Optional ByVal isnum As Boolean = False) As String
        If t.Text.Length = 0 Then
            Return "NULL" 'this will pass through any SQL statement without notice  
        Else 'Lets suppose our textbox is checked to contain only numbers, so we count on it  
            If Not isnum Then Return "'" + t.Text + "'" Else Return t.Text
        End If
    End Function
    Public Sub HideColumns(GridView1 As DevExpress.XtraGrid.Views.Grid.GridView, sExclude As String)
        Dim col As GridColumn
        For Each col In GridView1.Columns
            ' Look at FieldName, not Name (name of Column)  
            If col.FieldName.Contains(sExclude) Then col.Visible = False
        Next
    End Sub

    Public Function toSQLValueS(t As String, Optional ByVal isnum As Boolean = False) As String
        If t.Length = 0 Then
            Return "NULL" 'this will pass through any SQL statement without notice  
        Else 'Lets suppose our textbox is checked to contain only numbers, so we count on it  
            If Not isnum Then Return "'" + t + "'" Else Return t
        End If
    End Function


End Module
'Private Sub SetUserSettings()
'    Dim cf As New XML_Serialization.User_Settings
'    cf.user = New XML_Serialization.User() With {.ID = sUserCode}
'    cf.user.Settings = New XML_Serialization.Settings With {.DataTable = sDataTable, .CurrentView = BarViews.EditValue}
'    Dim s As New Xml.Serialization.XmlSerializer(GetType(XML_Serialization.User_Settings))
'    Using fs As New System.IO.FileStream(Application.StartupPath & "\file.xml", System.IO.FileMode.OpenOrCreate)
'        s.Serialize(fs, cf)
'    End Using
'End Sub
'Private Sub GetUserSettings()
'    Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(XML_Serialization.User_Settings))
'    Dim file As New System.IO.StreamReader(Application.StartupPath & "\file.xml")
'    Dim overview As XML_Serialization.User_Settings
'    overview = CType(reader.Deserialize(file), XML_Serialization.User_Settings)
'    Console.WriteLine(overview.user.Settings.DataTable)

'End Sub

'Dim Col As GridColumn
'Col = GridView1.Columns.ColumnByFieldName("id")
'        MsgBox(GridView1.GetRowCellValue(sender.FocusedRowHandle, "id").ToString)
