Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Columns

Module Main
    Public CNDB As New SqlConnection()
    Public CNDB2 As New SqlConnection()
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
        Public UNSave As String
        Public MachineName As String
        Public DataTable As String
        Public CurrentView As String
        Public AllowView As Boolean
        Public AllowInsert As Boolean
        Public AllowEdit As Boolean
        Public AllowDelete As Boolean
        Public Email As String
        Public EmailServer As String
        Public EmailPassword As String
        Public EmailPort As Integer
        Public EmailSSL As Boolean
    End Structure
    Public UserProps As USER_PROPS
    Public Structure PROG_PROPS
        Public VAT As Integer
        Public Decimals As Integer
        Public SupportEmail As String
        Public InvoicesEmailID As String
        Public InvoicesBody As String
        Public InvoicesBodySYG As String
        Public InvoicesBodyRECEIPT As String
        Public InvoicesBodyResend As String
        Public InvoicesBodyRecreate As String
        Public InvoicesEmailServer As String
        Public InvoicesEmailUsername As String
        Public InvoicesEmailPassword As String
        Public InvoicesEmailPort As Integer
        Public InvoicesEmailSSL As Boolean
        Public EXFolderPath As String
        Public ADM As String
        Public ANNMENT As String
        Public ProgTitle As String
        Public ServerViewsPath As String
        Public ServerPath As String
        Public Records As Integer
    End Structure
    Public ProgProps As PROG_PROPS

    Public Function toSQLValue(t As DevExpress.XtraEditors.TextEdit, Optional ByVal isnum As Boolean = False) As String
        If t.Text.Length = 0 Then
            Return "NULL" 'this will pass through any SQL statement without notice  
        Else 'Lets suppose our textbox is checked to contain only numbers, so we count on it  
            Dim sValue As String = t.Text
            If Not isnum Then
                Return "'" + sValue + "'"
            Else
                sValue = sValue.Replace(",", ".")
                sValue = sValue.Replace(" €", "")
                sValue = sValue.Replace("%", "")
                Return sValue
            End If
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
        Try
            If t <> Nothing Then
                If t.Length = 0 Then
                    Return "NULL" 'this will pass through any SQL statement without notice  
                Else 'Lets suppose our textbox is checked to contain only numbers, so we count on it  
                    If Not isnum Then
                        Return "'" + t + "'"
                    Else
                        t = t.Replace(",", ".")
                        t = t.Replace(" €", "")
                        Return t
                    End If
                End If
            Else
                Return "NULL" 'this will pass through any SQL statement without notice  
            End If
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function TranslateDates(ByVal fDate As DevExpress.XtraEditors.DateEdit, ByVal tDate As DevExpress.XtraEditors.DateEdit) As String
        If fDate.DateTime.Year = tDate.DateTime.Year Then
            TranslateDates = fDate.Text.Replace(fDate.DateTime.Year, "") & "-" & tDate.Text
            ' Εαν ο μήνας είναι ο ίδιος τότε αποθηκέυουμε μόνο Μηνας - Ετος
            If fDate.Text.Replace(fDate.DateTime.Year, "") = tDate.Text.Replace(tDate.DateTime.Year, "") Then
                TranslateDates = fDate.Text.Replace(fDate.DateTime.Year, "") & " " & fDate.DateTime.Year
            End If
        Else
            TranslateDates = fDate.Text & "-" & tDate.Text
            ' Εαν ο μήνας είναι ο ίδιος τότε αποθηκέυουμε μόνο Μηνας - Ετος
            If fDate.Text.Replace(fDate.DateTime.Year, "") <> tDate.Text.Replace(tDate.DateTime.Year, "") Then
                TranslateDates = fDate.Text.Replace(fDate.DateTime.Year, "") & " " & fDate.DateTime.Year & "-" & tDate.Text
            End If
        End If
        TranslateDates = TranslateDates.Replace("Ιανουάριος", "Ιαν.")
        TranslateDates = TranslateDates.Replace("Φεβρουάριος", "Φεβ.")
        TranslateDates = TranslateDates.Replace("Μάρτιος ", "Μαρ.")
        TranslateDates = TranslateDates.Replace("Απρίλιος", "Απρ.")
        TranslateDates = TranslateDates.Replace("Μάϊος", "Μάι.")
        TranslateDates = TranslateDates.Replace("Ιούνιος ", "Ιούν.")
        TranslateDates = TranslateDates.Replace("Ιούλιος", "Ιούλ.")
        TranslateDates = TranslateDates.Replace("Αύγουστος", "Αυγ.")
        TranslateDates = TranslateDates.Replace("Σεπτέμβριος", "Σεπ.")
        TranslateDates = TranslateDates.Replace("Οκτώβριος", "Οκτ.")
        TranslateDates = TranslateDates.Replace("Νοέμβριος", "Νοέ.")
        TranslateDates = TranslateDates.Replace("Δεκέμβριος", "Δεκ.")
        Return TranslateDates
    End Function

    'Public Function FindItemByValChkListBox(ByVal sValue As String, ByVal chkList As DevExpress.XtraEditors.CheckedListBoxControl) As DevExpress.XtraEditors.Controls.CheckedListBoxItem
    '    For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In chkList

    '    Next
    'End Function

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
