Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Localization


Public Class GreekGridLocalizer
        Inherits GridLocalizer
        Public Overrides ReadOnly Property Language() As String
            Get
            Return "Greek"
        End Get
        End Property
        Public Overrides Function GetLocalizedString(id As GridStringId) As String
        Dim ret As String = ""
        Console.WriteLine(id)
        Select Case id
            ' ... 
            Case GridStringId.FindControlFindButton
                Return "Εύρεση"
            Case GridStringId.FindControlClearButton
                Return "Καθαρισμός"
            Case GridStringId.FilterBuilderCaption
                Return "Επεξεργασία Φίλτρων"
            Case GridStringId.FilterBuilderCancelButton
                Return "Ακύρωση"
            Case GridStringId.FilterBuilderApplyButton
                Return "Εφαρμογή"
            Case GridStringId.GridGroupPanelText
                Return "Σύρε μια στήλη εδώ για να ομαδοποιήσεις τις εγγραφές με αυτήν την στήλη"
            Case GridStringId.MenuColumnClearSorting
                    Return "Sortierung entfernen"
                Case GridStringId.MenuGroupPanelHide
                Return "Απόκρυψη γραμμής ομαδοποίησης"
            Case GridStringId.MenuColumnRemoveColumn
                Return "Απόκρυψη Στήλης"
            Case GridStringId.MenuColumnFilterEditor
                Return "Επεξεργασία Φίλτρων"
            Case GridStringId.MenuColumnFindFilterShow
                Return "Εμφάνιση πίνακα εύρεσης"
            Case GridStringId.MenuColumnAutoFilterRowShow
                Return "Εμφάνιση γραμμής φίλτρων"
            Case GridStringId.MenuColumnSortAscending
                Return "Αύξουσα Ταξινόμηση"
            Case GridStringId.MenuColumnSortDescending
                Return "Φθίνουσα Ταξινόμηση"
            Case GridStringId.MenuColumnGroup
                Return "Ομαδοποίησης επιλεγμένης στήλης"
            Case GridStringId.MenuColumnUnGroup
                    Return "Gruppierung aufheben"
                Case GridStringId.MenuColumnColumnCustomization
                Return "Επιλογή Στηλών"
            Case GridStringId.MenuColumnBestFit
                Return "Αυτόματο πλάτος στήλης"
            Case GridStringId.MenuColumnFilter
                    Return "Kann gruppieren"
                Case GridStringId.MenuColumnClearFilter
                Return "Επεξεργασία Φίλτρων"
            Case GridStringId.MenuColumnBestFitAllColumns
                Return "Αυτόματο πλάτος (όλων των στηλών)"

            Case Else
                Console.WriteLine(id)
                ' ... 
                ret = MyBase.GetLocalizedString(id)
                    Exit Select
            End Select
            Return ret
        End Function
    End Class

    Public Class GermanEditorsLocalizer
        Inherits Localizer
        Public Overrides ReadOnly Property Language() As String
            Get
                Return "Deutsch"
            End Get
        End Property

        Public Overrides Function GetLocalizedString(ByVal id As StringId) As String
            Select Case id
         ' ...
            Case StringId.NavigatorTextStringFormat : Return "Εγγραφές {0} από {1}"
            Case StringId.PictureEditMenuCut : Return "Ausschneiden"
                Case StringId.PictureEditMenuCopy : Return "Kopieren"
                Case StringId.PictureEditMenuPaste : Return "Einfugen"
                Case StringId.PictureEditMenuDelete : Return "Loschen"
                Case StringId.PictureEditMenuLoad : Return "Laden"
                Case StringId.PictureEditMenuSave : Return "Speichern"
                    ' ...
            End Select
            Return ""
        End Function
    End Class

