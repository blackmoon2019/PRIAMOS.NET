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
        'Console.WriteLine(id)
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
                Return "Απαλοιφή Ταξινόμησης"
            Case GridStringId.MenuGroupPanelHide
                Return "Απόκρυψη γραμμής ομαδοποίησης"
            Case GridStringId.MenuGroupPanelFullExpand
                Return "Ανάπτυξη όλων"
            Case GridStringId.MenuGroupPanelFullCollapse
                Return "Σύμπτυξη όλων"
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
                Return "Απαλοιφή ομαδοποίησης"
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
            Case GridStringId.MenuFooterHide
                Return "Απόκρυψη υποσέλιδου"
            Case GridStringId.MenuFooterShow
                Return "Εμφάνιση υποσέλιδου"
            Case GridStringId.MenuGroupRowCollapse
                Return "Σύμπτυξη"
            Case GridStringId.MenuGroupRowExpand
                Return "Ανάπτυξη"
            Case GridStringId.MenuColumnConditionalFormatting
                Return "Κανόνες Μορφοποίησης"
            Case GridStringId.MenuGroupPanelClearGrouping
                Return "Απαλοιφή ομαδοποίησης"
            Case GridStringId.MenuFooterSum
                Return "Γενικό Σύνολο"
            Case GridStringId.MenuFooterMin
                Return "Ελάχιστο ποσό"
            Case GridStringId.MenuFooterMax
                Return "Μέγιστο ποσό"
            Case GridStringId.MenuFooterCount
                Return "Πλήθος"
            Case GridStringId.MenuFooterAverage
                Return "Μέσος όρος"
            Case GridStringId.MenuFooterNone
                Return "Απόκρυψη"
            Case GridStringId.CustomizationCaption
                Return "Προσαρμογή στηλών"
            Case GridStringId.MenuColumnGroupSummaryEditor
                Return "Επεξεργασία συνόλων ομαδοποίησης"
            Case GridStringId.GroupSummaryEditorSummaryMin
                Return "Ελάχιστο ποσό"
            Case GridStringId.GroupSummaryEditorSummaryMax
                Return "Μέγιστο ποσό"
            Case GridStringId.GroupSummaryEditorSummaryAverage
                Return "Μέσος όρος"
            Case GridStringId.GroupSummaryEditorSummarySum
                Return "Σύνολο"
            Case GridStringId.GroupSummaryEditorSummaryCount
                Return "Πλήθος"
            Case GridStringId.GroupSummaryEditorFormItemsTabCaption
                Return "Πεδία"
            Case GridStringId.GroupSummaryEditorFormOrderTabCaption
                Return "Ταξινόμηση"
            Case GridStringId.GroupSummaryEditorFormCaption
                Return "Επεξεργασία συνόλων ομαδοποίησης"
            Case GridStringId.MenuFooterAddSummaryItem
                Return "Προσθήκη νέου κανόνα συνόλου"
            'Case GridStringId.MenuColumnGroupSummarySortFormat
                ' Return "Ταξινόμηση πεδίων με σύνολα"
            Case GridStringId.MenuColumnSortGroupBySummaryMenu
                Return "Ταξινόμηση πεδίων με σύνολα"
            Case GridStringId.MenuFooterSumFormat
                Return "Σύνολο " + "{0:#,0.00}"
            Case GridStringId.MenuFooterMinFormat
                Return "Ελάχιστο ποσό " + "{0:#,0.00}"
            Case GridStringId.MenuFooterMaxFormat
                Return "Μέγιστο ποσό " + "{0:#,0.00}"
            Case GridStringId.MenuFooterCountFormat
                Return "Πλήθος " + "{0}"
            Case GridStringId.MenuFooterAverageFormat
                Return "Μέσος Όρος " + "{0:#,0.00}"
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

