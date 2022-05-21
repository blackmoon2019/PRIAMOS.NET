Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraPrinting
Imports DevExpress.Export
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Localization

Public Class frmScroller
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private sDataTable As String
    Private sWhereCondition As String
    Private sDataDetail As String
    Private CurrentView As String
    Private ReadXml As New XmlUpdateFromDB
    Private LoadForms As New FormLoader
    Private bankID As String
    Private colMethodID As String
    Private debitUsrID As String


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public WriteOnly Property DataTableWhereCondition As String
        Set(value As String)
            sWhereCondition = value
        End Set
    End Property
    'Private settings = System.Configuration.ConfigurationManager.AppSettings
    Private Sub frmScroller_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            'TODO: This line of code loads data into the 'Priamos_NETDataSet.Collectors' table. You can move, or remove it, as needed.
            Me.CollectorsTableAdapter.Fill(Me.Priamos_NETDataSet.Collectors)
            'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_BANKS' table. You can move, or remove it, as needed.
            Me.Vw_BANKSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_BANKS)
            'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_COL_METHOD' table. You can move, or remove it, as needed.
            Me.Vw_COL_METHODTableAdapter.Fill(Me.Priamos_NETDataSet.vw_COL_METHOD)
            'Λίστα με τιμές για TOP RECORDS
            LoadComboRecordValues()
            popSaveAsView.EditValue = BarViews.EditValue
            If BarViews.EditValue = "" Then popSaveView.Enabled = False : popDeleteView.Enabled = False
            'Παίρνω το όνομα της όψης για τον συγκεκριμένο χρήστη και για τον συγκεκριμένο πίνακα 
            GetCurrentView(True)
            'Φόρτωση Εγγραφών
            LoadRecords()
            If sDataTable = "vw_COL_EXT" Then
                AddHandler Rep_DEBITUSR.EditValueChanged, AddressOf Rep_DEBITUSR_Changed
                AddHandler Rep_COL_METHOD.EditValueChanged, AddressOf Rep_COL_METHOD_Changed
                AddHandler Rep_ΒΑΝΚ.EditValueChanged, AddressOf Rep_ΒΑΝΚ_Changed
            End If

            'Φόρτωση Σχεδίων στην Λίστα βάση επιλογής από το μενού
            'LoadViews()
            'Φορτώνει όλες τις ονομασίες των στηλών από τον SQL. Από το πεδίο Description
            'LoadForms.LoadColumnDescriptionNames(grdMain, GridView1, , sDataTable)

            GridLocalizer.Active = New GreekGridLocalizer()
            'Localizer.Active = New GermanEditorsLocalizer()

            'Κρύψιμο Στηλών
            'HideColumns(GridView1, "ID")
            'Δικαιώματα
            BarNewRec.Enabled = UserProps.AllowInsert
            BarDelete.Enabled = UserProps.AllowDelete
            BarEdit.Enabled = UserProps.AllowEdit
            GridView1.OptionsBehavior.AutoExpandAllGroups = True
            GridView1.OptionsMenu.ShowFooterItem = True
            GridView1.OptionsMenu.EnableFooterMenu = True
            GridView1.OptionsMenu.EnableGroupPanelMenu = True
            GridView1.OptionsMenu.EnableGroupRowMenu = True
            GridView1.OptionsView.ShowFooter = True
            GridView1.OptionsMenu.ShowGroupSummaryEditorItem = True
            GridView1.OptionsMenu.ShowGroupSortSummaryItems = True
            GridView1.OptionsMenu.ShowConditionalFormattingItem = True
            GridView1.OptionsSelection.MultiSelect = True
            GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
            GridView1.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button

            GridView2.OptionsBehavior.AutoExpandAllGroups = True
            GridView2.OptionsMenu.ShowFooterItem = True
            GridView2.OptionsMenu.EnableFooterMenu = True
            GridView2.OptionsMenu.EnableGroupPanelMenu = True
            GridView2.OptionsMenu.EnableGroupRowMenu = True
            GridView2.OptionsView.ShowFooter = True
            GridView2.OptionsMenu.ShowGroupSummaryEditorItem = True
            GridView2.OptionsMenu.ShowGroupSortSummaryItems = True
            GridView2.OptionsMenu.ShowConditionalFormattingItem = True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Λίστα με τιμές για TOP RECORDS
    'Φόρτωση Λίστας με εγγραφές 
    Private Sub LoadComboRecordValues()
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("30")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("200")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("1000")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("10000")
        CType(BarRecords.Edit, RepositoryItemComboBox).Items.Add("ALL")
        BarRecords.EditValue = My.Settings.Records
    End Sub
    'Φόρτωση όψεων Per User στο Combo
    Private Sub LoadViews()
        Try
            BarViews.EditValue = ""
            'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
            If System.IO.File.Exists(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml") = False Then
                GridView1.OptionsLayout.LayoutVersion = "v1"
                GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)
            End If
            If System.IO.File.Exists(Application.StartupPath & "\DSGNS\DEF\D_" & sDataDetail & "_def.xml") = False Then
                If sDataDetail <> "" Then GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\D_" & sDataDetail & "_def.xml", OptionsLayoutBase.FullLayout)
            End If

            'Εαν δεν υπάρχει Folder Σχεδίου για το συγκεκριμένο πίνακα δημιουργεί
            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\DSGNS\" & sDataTable) = False Then _
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\DSGNS\" & sDataTable)

            'Εαν δεν υπάρχει Folder Σχεδίου για το Detail πίνακα δημιουργεί
            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\DSGNS\D_" & sDataDetail) = False Then _
                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\DSGNS\D_" & sDataDetail)

            CType(BarViews.Edit, RepositoryItemComboBox).Items.Clear()
            'Ψάχνει όλα τα σχέδια  του συκεκριμένου χρήστη για τον συγκεκριμένο πίνακα
            Dim files() As String = IO.Directory.GetFiles(Application.StartupPath & "\DSGNS\" & sDataTable, "*_" & UserProps.Code & "*")
            For Each sFile As String In files
                CType(BarViews.Edit, RepositoryItemComboBox).Items.Add(System.IO.Path.GetFileName(sFile))
            Next
            BarViews.EditValue = CurrentView
            If CurrentView = "" Then
                'grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml")
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)
                If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\D_" & sDataDetail & "_def.xml", OptionsLayoutBase.FullLayout)
            Else
                'grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
                If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\D_" & sDataDetail & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Διαγραφη Εγγραφής
    Private Sub DeleteRecord()
        Dim sSQL As String
        Dim sSQL2 As String
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") = Nothing Then Exit Sub
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Select Case sDataTable
                    Case "vw_USR" : sSQL = "DELETE FROM USR WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_MAILS" : sSQL = "DELETE FROM MAILS WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_RIGHTS" : sSQL = "DELETE FROM RIGHTS WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                        sSQL2 = "DELETE FROM FORM_RIGHTS WHERE RID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_BDG" : sSQL = "DELETE FROM BDG WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_COU" : sSQL = "DELETE FROM COU WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_AREAS" : sSQL = "DELETE FROM AREAS WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_ADR" : sSQL = "DELETE FROM ADR WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_DOY" : sSQL = "DELETE FROM DOY WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_PRF" : sSQL = "DELETE FROM PRF WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_CCT" : sSQL = "DELETE FROM CCT WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_FTYPES" : sSQL = "DELETE FROM FTYPES WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_PRM" : sSQL = "DELETE FROM PRM WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_CALC_TYPES" : sSQL = "DELETE FROM CALC_TYPES WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_MLC" : sSQL = "DELETE FROM MLC WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_TECH_CAT" : sSQL = "DELETE FROM TECH_CAT WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_TECH_SUP" : sSQL = "DELETE FROM TECH_SUP WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_CALC_CAT" : sSQL = "DELETE FROM CALC_CAT WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_EXP" : sSQL = "DELETE FROM EXP WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_TTL" : sSQL = "DELETE FROM TTL WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_ANN_MENTS" : sSQL = "DELETE FROM ANN_MENTS WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_APOL_TYPES" : sSQL = "DELETE FROM APOL_TYPES WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_APOL" : sSQL = "DELETE FROM APOL WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_BANKS" : sSQL = "DELETE FROM BANKS WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_COL_METHOD" : sSQL = "DELETE FROM COL_METHOD WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_COL" : sSQL = "DELETE FROM COL WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_TASKS_CAT" : sSQL = "DELETE FROM TASKS_CAT WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_TASKS" : sSQL = "DELETE FROM TASKS WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_CASES" : sSQL = "DELETE FROM CASES WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_FOLDER_CAT" : sSQL = "DELETE FROM FOLDER_CAT WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_COL_EXT" : sSQL = "DELETE FROM COL_EXT WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_PRIAMOSVER" : sSQL = "DELETE FROM PRIAMOS_VER WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                    Case "vw_INH"

                        ' Επαναφέρουμε σε διαθέσιμη την ώρα μέτρησης που επιλέχθηκε στο συγκεκριμένο παραστατικό
                        sSQL = "Update AHPB_H 
                                SET finalized=0
                                From INH
                                INNER Join AHPB_H ON INH.ahpb_HID = AHPB_H.ID
                                WHERE INH.ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using

                        'Επαναφέρουμε το υπόλοιπο των Διαμερισμάτων αν το παραστατικό επαναυπολογίζεται
                        sSQL = "UPDATE APT
	                            SET bal = APT.bal - COL.[bal]
	                            FROM APT
	                            INNER JOIN COL ON COL.aptID = APT.ID 
	                            where col.inhID   = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"

                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using


                        sSQL = "DELETE FROM INH WHERE ID = '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString & "'"

                End Select

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                If sSQL2 <> "" Then
                    Using oCmd As New SqlCommand(sSQL2, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If
                LoadRecords()
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Διαγραφη Εγγραφών
    Private Sub DeleteBatchRecords()
        Dim sSQL As String
        Dim sSQL2 As String
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
        Dim I As Integer
        Try
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)

                If GridView1.GetRowCellValue(selectedRowHandle, "ID") = Nothing Then Exit Sub
                Select Case sDataTable
                    Case "vw_USR" : sSQL = "DELETE FROM USR WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_MAILS" : sSQL = "DELETE FROM MAILS WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_RIGHTS" : sSQL = "DELETE FROM RIGHTS WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                        sSQL2 = "DELETE FROM FORM_RIGHTS WHERE RID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_BDG" : sSQL = "DELETE FROM BDG WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_COU" : sSQL = "DELETE FROM COU WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_AREAS" : sSQL = "DELETE FROM AREAS WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_ADR" : sSQL = "DELETE FROM ADR WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_DOY" : sSQL = "DELETE FROM DOY WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_PRF" : sSQL = "DELETE FROM PRF WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_CCT" : sSQL = "DELETE FROM CCT WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_FTYPES" : sSQL = "DELETE FROM FTYPES WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_PRM" : sSQL = "DELETE FROM PRM WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_CALC_TYPES" : sSQL = "DELETE FROM CALC_TYPES WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_MLC" : sSQL = "DELETE FROM MLC WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_TECH_CAT" : sSQL = "DELETE FROM TECH_CAT WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_TECH_SUP" : sSQL = "DELETE FROM TECH_SUP WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_CALC_CAT" : sSQL = "DELETE FROM CALC_CAT WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_EXP" : sSQL = "DELETE FROM EXP WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_TTL" : sSQL = "DELETE FROM TTL WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_ANN_MENTS" : sSQL = "DELETE FROM ANN_MENTS WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_APOL_TYPES" : sSQL = "DELETE FROM APOL_TYPES WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_APOL" : sSQL = "DELETE FROM APOL WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_BANKS" : sSQL = "DELETE FROM BANKS WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_COL_METHOD" : sSQL = "DELETE FROM COL_METHOD WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_COL" : sSQL = "DELETE FROM COL WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_TASKS_CAT" : sSQL = "DELETE FROM TASKS_CAT WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_TASKS" : sSQL = "DELETE FROM TASKS WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_CASES" : sSQL = "DELETE FROM CASES WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_COL_EXT" : sSQL = "DELETE FROM COL_EXT WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_PRIAMOSVER" : sSQL = "DELETE FROM PRIAMOS_VER WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                    Case "vw_INH"

                        ' Επαναφέρουμε σε διαθέσιμη την ώρα μέτρησης που επιλέχθηκε στο συγκεκριμένο παραστατικό
                        sSQL = "Update AHPB_H 
                                SET finalized=0
                                From INH
                                INNER Join AHPB_H ON INH.ahpb_HID = AHPB_H.ID
                                WHERE INH.ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"
                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using

                        'Επαναφέρουμε το υπόλοιπο των Διαμερισμάτων αν το παραστατικό επαναυπολογίζεται
                        sSQL = "UPDATE APT
	                            SET bal = APT.bal - COL.[bal]
	                            FROM APT
	                            INNER JOIN COL ON COL.aptID = APT.ID 
	                            where col.inhID   = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"

                        Using oCmd As New SqlCommand(sSQL, CNDB)
                            oCmd.ExecuteNonQuery()
                        End Using


                        sSQL = "DELETE FROM INH WHERE ID = '" & GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString & "'"

                End Select

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                If sSQL2 <> "" Then
                    Using oCmd As New SqlCommand(sSQL2, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                End If
            Next
            LoadRecords()
            XtraMessageBox.Show("Η εγγραφές διαγράφηκαν με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public WriteOnly Property DataTable As String
        Set(value As String)
            sDataTable = value
        End Set
    End Property
    Public WriteOnly Property DataDetail As String
        Set(value As String)
            sDataDetail = value
        End Set
    End Property
    'Επιλογή όψης
    Private Sub BarViews_EditValueChanged(sender As Object, e As EventArgs) Handles BarViews.EditValueChanged
        Try
            popSaveAsView.EditValue = BarViews.EditValue
            If BarViews.EditValue <> "" Then
                'grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
                If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\D_" & sDataDetail & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
                CurrentView = BarViews.EditValue
                popSaveView.Enabled = True
                popDeleteView.Enabled = True
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Κλείσιμο Φόρμας
    Private Sub frmScroller_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            'Παίρνω το όνομα της όψης για τον συγκεκριμένο χρήστη και για τον συγκεκριμένο πίνακα και το αποθηκεύω στην βάση
            GetCurrentView(False)
            If sDataDetail = "" Then
                If myReader IsNot Nothing Then myReader.Close()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    'Διαγραφή όψης
    Private Sub popDeleteView_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popDeleteView.ItemClick
        If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα όψη?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If BarViews.EditValue <> "" Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
                If sDataDetail <> "" Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\D_" & sDataDetail & "\" & BarViews.EditValue)
                CType(BarViews.Edit, RepositoryItemComboBox).Items.Remove(BarViews.EditValue)
                BarViews.EditValue = "" : CurrentView = "" : popSaveView.Enabled = False
            End If
        End If

    End Sub
    'Αποθήκευση ως όψης
    Private Sub RepositoryPopSaveAsView_KeyDown(sender As Object, e As KeyEventArgs) Handles RepositoryPopSaveAsView.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If GridView1.OptionsLayout.LayoutVersion <> "" Then
                    Dim sVer As Integer = GridView1.OptionsLayout.LayoutVersion.Replace("v", "")
                    GridView1.OptionsLayout.LayoutVersion = "v" & sVer + 1
                Else
                    GridView1.OptionsLayout.LayoutVersion = "v1"
                End If
                GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & sender.EditValue & "_" & UserProps.Code & ".xml", OptionsLayoutBase.FullLayout)
                If sDataDetail <> "" Then GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\D_" & sDataDetail & "\" & sender.EditValue & "_" & UserProps.Code & ".xml", OptionsLayoutBase.FullLayout)
                'grdMain.DefaultView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & sender.EditValue & "_" & UserProps.Code & ".xml")
                CType(BarViews.Edit, RepositoryItemComboBox).Items.Add(sender.EditValue & "_" & UserProps.Code & ".xml")

                BarViews.EditValue = sender.EditValue & "_" & UserProps.Code & ".xml"
                CurrentView = BarViews.EditValue
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Αποθήκευση όψης
    Private Sub popSaveView_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popSaveView.ItemClick
        If BarViews.EditValue <> "" Then
            'grdMain.DefaultView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
            If GridView1.OptionsLayout.LayoutVersion <> "" Then
                Dim sVer As Integer = GridView1.OptionsLayout.LayoutVersion.Replace("v", "")
                GridView1.OptionsLayout.LayoutVersion = "v" & sVer + 1
            Else
                GridView1.OptionsLayout.LayoutVersion = "v1"
            End If
            GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
            If sDataDetail <> "" Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\D_" & sDataDetail & "\" & BarViews.EditValue)
                GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\D_" & sDataDetail & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
            End If
            'GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & BarViews.EditValue)
            XtraMessageBox.Show("Η όψη αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    'Επαναφορά Default όψης
    Private Sub popRestoreView_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popRestoreView.ItemClick
        grdMain.DefaultView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)
        BarViews.EditValue = "" : popSaveAsView.EditValue = "" : popSaveView.Enabled = False : popDeleteView.Enabled = False
        CurrentView = ""
    End Sub

    Private Sub RepositoryBarViews_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepositoryBarViews.SelectedIndexChanged
        My.Settings.CurrentView = sender.EditValue
        My.Settings.Save()
    End Sub

    Private Sub RepositoryBarRecords_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepositoryBarRecords.SelectedIndexChanged
        My.Settings.Records = BarRecords.EditValue
        My.Settings.Save()
        LoadRecords()
    End Sub

    'Προσθήκη επιλογών στο Standar Header Menu
    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()

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

            End If
        Else
            PopupMenuRows.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub
    'Προσθήκη επιλογών στο Standar Detail Menu
    Private Sub GridView2_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView2.PopupMenuShowing
        If e.MenuType = GridMenuType.Column Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = TryCast(e.Menu, GridViewColumnMenu)
            Dim item As New DXEditMenuItem()
            Dim itemColor As New DXEditMenuItem()

            'menu.Items.Clear()
            If menu.Column IsNot Nothing Then
                'Για να προσθέσουμε menu item στο Default menu πρέπει πρώτα να προσθέσουμε ένα Repository Item 
                'Υπάρχουν πολλών ειδών Repositorys
                '1st Custom Menu Item
                Dim popRenameColumn As New RepositoryItemTextEdit
                popRenameColumn.Name = "RenameColumn"
                menu.Items.Add(New DXEditMenuItem("Μετονομασία Στήλης", popRenameColumn, AddressOf OnDetailEditValueChanged, Nothing, Nothing, 100, 0))
                item = menu.Items.Item("Μετονομασία Στήλης")
                item.EditValue = menu.Column.GetTextCaption
                item.Tag = menu.Column.AbsoluteIndex
                '2nd Custom Menu Item
                menu.Items.Add(CreateCheckItemDetail("Κλείδωμα Στήλης", menu.Column, Nothing))

                '3rd Custom Menu Item
                Dim popColorsColumn As New RepositoryItemColorEdit
                popColorsColumn.Name = "ColorsColumn"
                menu.Items.Add(New DXEditMenuItem("Χρώμα Στήλης", popColorsColumn, AddressOf OnDetailColumnsColorChanged, Nothing, Nothing, 100, 0))
                itemColor = menu.Items.Item("Χρώμα Στήλης")
                itemColor.EditValue = menu.Column.AppearanceCell.BackColor
                itemColor.Tag = menu.Column.AbsoluteIndex
            End If
        Else
            PopupMenuRowsDetail.ShowPopup(System.Windows.Forms.Control.MousePosition)
        End If
    End Sub
    'Αλλαγή Χρώματος Στήλης Master
    Private Sub OnColumnsColorChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView1.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Αλλαγή Χρώματος Στήλης Detail
    Private Sub OnDetailColumnsColorChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As DXEditMenuItem = TryCast(sender, DXEditMenuItem)
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView2.Columns(item.Tag).AppearanceCell.BackColor = item.EditValue
    End Sub
    'Μετονομασία Στήλης Master
    Private Sub OnEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView1.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
    End Sub
    'Μετονομασία Στήλης Detail
    Private Sub OnDetailEditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim item As New DXEditMenuItem()
        item = sender
        If item.Tag Is Nothing Then Exit Sub
        GridView2.Columns(item.Tag).Caption = item.EditValue
        'MessageBox.Show(item.EditValue.ToString())
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
    'Κλείδωμα Στήλης Detail
    Private Sub OnCanMoveItemClickDetail(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As DXMenuCheckItem = TryCast(sender, DXMenuCheckItem)
        Dim info As MenuColumnInfo = TryCast(item.Tag, MenuColumnInfo)
        If info Is Nothing Then
            Return
        End If
        info.Column.OptionsColumn.AllowMove = Not item.Checked
    End Sub
    Private Function CreateCheckItem(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    Private Function CreateCheckItemDetail(ByVal caption As String, ByVal column As GridColumn, ByVal image As Image) As DXMenuCheckItem
        Dim item As New DXMenuCheckItem(caption, (Not column.OptionsColumn.AllowMove), image, New EventHandler(AddressOf OnCanMoveItemClickDetail))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function
    'Print Preview
    Private Sub BarPrintPreview_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarPrintPreview.ItemClick
        GridView1.GridControl.ShowRibbonPrintPreview()
    End Sub
    'XLSX Export
    Private Sub BarExportXLSX_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarExportXLSX.ItemClick
        Dim options = New XlsxExportOptionsEx()
        options.UnboundExpressionExportMode = UnboundExpressionExportMode.AsFormula
        XtraSaveFileDialog1.Filter = "XLSX Files (*.xlsx*)|*.xlsx"
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView1.GridControl.ExportToXlsx(XtraSaveFileDialog1.FileName, options)
            Process.Start(XtraSaveFileDialog1.FileName)
        End If
    End Sub
    'PDF Export
    Private Sub BarPDFExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarPDFExport.ItemClick
        XtraSaveFileDialog1.Filter = "PDF Files (*.pdf*)|*.pdf"
        If XtraSaveFileDialog1.ShowDialog() = DialogResult.OK Then
            GridView1.GridControl.ExportToPdf(XtraSaveFileDialog1.FileName)
            Process.Start(XtraSaveFileDialog1.FileName)
        End If
    End Sub

    Friend Class MenuColumnInfo
        Public Sub New(ByVal column As GridColumn)
            Me.Column = column
        End Sub
        Public Column As GridColumn
    End Class
    ' Πάιρνω από την βάση την τρέχουσα όψη του χρήστη
    Private Sub GetCurrentView(ByVal GetVal As Boolean)
        Dim Cmd As SqlCommand, sdr As SqlDataReader
        Try
            If GetVal Then
                Cmd = New SqlCommand("SELECT currentview FROM USR_V WHERE USRID = '" & UserProps.ID.ToString & "' and  DATATABLE = '" & sDataTable & "'", CNDB)
                sdr = Cmd.ExecuteReader()
                If (sdr.Read() = True) Then
                    If sdr.IsDBNull(sdr.GetOrdinal("currentview")) = False Then CurrentView = sdr.GetString(sdr.GetOrdinal("currentview"))
                    'Έλεγχος αν το τελευταίο σχέδιο που έχει αποθηκευτεί στην βάση υπάρχει στον δίσκο
                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\" & sDataTable & "\" & CurrentView) = False Then CurrentView = ""
                Else
                    CurrentView = ""
                End If
                sdr.Close()

            Else
                If CurrentView <> "" Then
                    Cmd = CNDB.CreateCommand
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.Add(New SqlParameter("@sDataTable", sDataTable))
                    Cmd.Parameters.Add(New SqlParameter("@ID", UserProps.ID))
                    Cmd.Parameters.Add(New SqlParameter("@CurrentView", CurrentView))
                    Cmd.CommandText = "SetUserView"
                    Cmd.ExecuteNonQuery()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If GetVal Then sdr.Close()
        End Try

    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If GridView1.IsGroupRow(GridView1.FocusedRowHandle) Then Exit Sub Else EditRecord()
    End Sub
    'Νέα Εγγραφή
    Private Sub BarNewRec_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarNewRec.ItemClick
        NewRecord()
    End Sub
    'Επεξεργασία Εγγραφής
    Private Sub BarEdit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarEdit.ItemClick
        If GridView1.IsGroupRow(GridView1.FocusedRowHandle) Then Exit Sub Else EditRecord()
    End Sub
    'Διαγραφή Εγγραφής
    Private Sub BarDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarDelete.ItemClick
        If GridView1.IsGroupRow(GridView1.FocusedRowHandle) Then
            Exit Sub
        Else
            If GridView1.SelectedRowsCount = 1 Then
                DeleteRecord()
            Else
                DeleteBatchRecords()
            End If
        End If
    End Sub
    'Ανανέωση εγγραφών
    Private Sub BarRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarRefresh.ItemClick
        LoadRecords()
    End Sub
    'Επεξεργασία Εγγραφής
    Private Sub EditRecord()
        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID") Is Nothing Then Exit Sub
        Select Case sDataTable
            Case "vw_PRIAMOSVER"
                Dim frmVersions As frmVersions = New frmVersions()
                frmVersions.Text = "Εκδόσεις"
                frmVersions.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                frmVersions.MdiParent = frmMain
                frmVersions.Mode = FormMode.EditRecord
                frmVersions.Scroller = GridView1
                frmVersions.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(frmVersions), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                frmVersions.Show()
            Case "vw_COL_EXT"
                Dim fColEXT As frmColExt = New frmColExt()
                frmColExt.Text = "Λοιπές Εισπράξεις"
                frmColExt.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                frmColExt.ApolID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "apolID").ToString
                frmColExt.MdiParent = frmMain
                frmColExt.Mode = FormMode.EditRecord
                frmColExt.Scroller = GridView1
                frmColExt.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(frmColExt), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                frmColExt.Show()
            Case "vw_TASKS"
                Dim fTASKS As frmTasks = New frmTasks()
                fTASKS.Text = "Εργασίες Υποθέσεων"
                fTASKS.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fTASKS.MdiParent = frmMain
                fTASKS.Mode = FormMode.EditRecord
                fTASKS.Scroller = GridView1
                fTASKS.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fTASKS), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fTASKS.Show()
            Case "vw_CASES"
                Dim fCASES As frmCases = New frmCases()
                fCASES.Text = "Υποθέσεις"
                fCASES.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fCASES.MdiParent = frmMain
                fCASES.Mode = FormMode.EditRecord
                fCASES.Scroller = GridView1
                fCASES.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fCASES), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fCASES.Show()
            Case "vw_COL"
                Dim fcol As frmCollections = New frmCollections()
                fcol.Text = "Εισπράξεις"
                fcol.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fcol.BDGID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bdgID").ToString
                fcol.INHID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "inhID").ToString
                fcol.MdiParent = frmMain
                fcol.Mode = FormMode.EditRecord
                fcol.Scroller = GridView1
                fcol.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fcol), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fcol.Show()
            Case "vw_APOL"
                Dim fApol As frmApol = New frmApol()
                fApol.Text = "Απολυμάνσεις"
                fApol.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fApol.MdiParent = frmMain
                fApol.Mode = FormMode.EditRecord
                fApol.Scroller = GridView1
                fApol.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fApol), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fApol.Show()
            Case "vw_INH"
                Dim fINH As frmINH = New frmINH()
                fINH.Text = "Κοινόχρηστα"
                fINH.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fINH.MdiParent = frmMain
                fINH.Mode = FormMode.EditRecord
                fINH.Scroller = GridView1
                fINH.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fINH.Show()
            Case "vw_EXP"
                Dim fExp As frmEXP = New frmEXP()
                fExp.Text = "Έξοδα"
                fExp.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fExp.MdiParent = frmMain
                fExp.Mode = FormMode.EditRecord
                fExp.Scroller = GridView1
                fExp.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fExp), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fExp.Show()
            Case "vw_TECH_SUP"
                Dim fTechicalSupport As frmTecnicalSupport = New frmTecnicalSupport()
                fTechicalSupport.Text = "Διαχείριση Τεχνικής Υποστήριξης"
                fTechicalSupport.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fTechicalSupport.MdiParent = frmMain
                fTechicalSupport.Mode = FormMode.EditRecord
                fTechicalSupport.Scroller = GridView1
                fTechicalSupport.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fTechicalSupport), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fTechicalSupport.Show()
            Case "vw_USR"
                Dim fUsers As frmUsers = New frmUsers()
                fUsers.Text = "Διαχείριση Χρηστών"
                fUsers.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fUsers.MdiParent = frmMain
                fUsers.Mode = FormMode.EditRecord
                fUsers.Scroller = GridView1
                fUsers.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fUsers), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fUsers.Show()
            Case "vw_MAILS"
                Dim fMailSettings As frmMailSettings = New frmMailSettings()
                fMailSettings.Text = "Email Settings"
                fMailSettings.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fMailSettings.MdiParent = frmMain
                fMailSettings.Mode = FormMode.EditRecord
                fMailSettings.Scroller = GridView1
                fMailSettings.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fMailSettings), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fMailSettings.Show()
            Case "vw_RIGHTS"
                Dim fPermissions As frmPermissions = New frmPermissions()
                fPermissions.Text = "Δικαιώματα"
                fPermissions.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fPermissions.MdiParent = frmMain
                fPermissions.Mode = FormMode.EditRecord
                fPermissions.Scroller = GridView1
                fPermissions.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fPermissions), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fPermissions.Show()
            Case "vw_BDG"
                Dim fBDG As frmBDG = New frmBDG()
                fBDG.Text = "Πολυκατοικίες"
                fBDG.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fBDG.bManageID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bManageID").ToString
                fBDG.MdiParent = frmMain
                fBDG.Mode = FormMode.EditRecord
                fBDG.Scroller = GridView1
                fBDG.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fBDG), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fBDG.Show()
            Case "vw_CCT", "vw_CCT_PF"
                Dim fCustomers As frmCustomers = New frmCustomers()
                fCustomers.Text = "Επαφές"
                fCustomers.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fCustomers.MdiParent = frmMain
                fCustomers.Mode = FormMode.EditRecord
                fCustomers.Scroller = GridView1
                fCustomers.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fCustomers), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fCustomers.Show()
            Case "vw_PRM"
                Dim fParameters As frmParameters = New frmParameters()
                fParameters.Text = "Παράμετροι"
                fParameters.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fParameters.MdiParent = frmMain
                fParameters.Mode = FormMode.EditRecord
                fParameters.Scroller = GridView1
                fParameters.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fParameters), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fParameters.Show()
            Case "vw_AREAS"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Περιοχές"
                fGen.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.EditRecord
                fGen.Scroller = GridView1
                fGen.DataTable = "AREAS"
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Περιοχή"
                fGen.L3.Text = "Νομός"
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                fGen.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_ADR"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Διευθύνσεις"
                fGen.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.EditRecord
                fGen.Scroller = GridView1
                fGen.DataTable = "ADR"
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Διεύθυνση"
                fGen.L3.Text = "Νομός"
                fGen.L4.Text = "Περιοχές"
                fGen.L7.Text = "ΤΚ"
                fGen.L7.Control.Tag = "tk,0,1,2"
                fGen.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_CALC_TYPES"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Τύποι Υπολογισμού"
                fGen.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.EditRecord
                fGen.Scroller = GridView1
                fGen.DataTable = "CALC_TYPES"
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Όνομα"
                fGen.L7.Text = "Τύπος"
                fGen.chk1.Text = "Ενεργό"
                fGen.txtL7.Tag = "type,0,1,2"
                fGen.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_CALC_CAT"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Κατηγορίες Υπολογισμών"
                fGen.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.EditRecord
                fGen.Scroller = GridView1
                fGen.DataTable = "CALC_CAT"
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Όνομα"
                fGen.L3.Text = "Τύπος Υπολογισμού"
                fGen.L3.Control.Tag = "calcTypeID,0,1,2"
                fGen.L3.Tag = ""
                fGen.L3.ImageOptions.Image = Nothing
                fGen.L4.Text = "Κατηγορία Χιλιοστών"
                fGen.L4.Control.Tag = "mlcID,0,1,2"
                fGen.L4.Tag = ""
                fGen.L4.ImageOptions.Image = Nothing
                fGen.L7.Text = "Λεκτικό Εκτύπωσης"
                fGen.L7.Control.Tag = "repName,0,1,2"
                fGen.L7.Tag = ""
                fGen.L7.ImageOptions.Image = Nothing
                fGen.L8.Text = "Θέση Ταξινόμησης"
                fGen.txtNum.Tag = "ord,0,1,2"
                fGen.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_MLC"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Κατηγορίες Χιλιοστών"
                fGen.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.EditRecord
                fGen.Scroller = GridView1
                fGen.FormScroller = Me
                fGen.DataTable = "MLC"
                fGen.CalledFromControl = False
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Κατηγορία"
                fGen.L6.Text = "Χρώμα"
                fGen.L7.Text = "Λεκτικό Εκτύπωσης"
                fGen.L7.Control.Tag = "repName,0,1,2"
                fGen.L6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_BANKS"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Τράπεζες"
                fGen.DataTable = "BANKS"
                fGen.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.EditRecord
                fGen.Scroller = GridView1
                fGen.FormScroller = Me
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Τράπεζα"
                fGen.L9.Text = "Διαδρομή φακέλλου"
                fGen.L9.Control.Tag = "folderPath,0,1,2"
                fGen.L9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_ANN_MENTS", "vw_COU", "vw_DOY", "vw_PRF", "vw_HTYPES", "vw_BTYPES", "vw_FTYPES", "vw_TECH_CAT", "vw_CALC_CAT",
                 "vw_TTL", "vw_APOL_TYPES", "VW_COL_METHOD", "vw_TASKS_CAT", "vw_FOLDER_CAT"
                Dim fGen As frmGen = New frmGen()
                Select Case sDataTable
                    Case "vw_APOL_TYPES" : fGen.Text = "Τύποι Απολύμανσης" : fGen.DataTable = "APOL_TYPES" : fGen.L2.Text = "Τύπος"
                    Case "vw_ANN_MENTS" : fGen.Text = "Ανακοινώσεις" : fGen.DataTable = "ANN_MENTS" : fGen.L2.Text = "Ανακοίνωση"
                    Case "vw_TTL" : fGen.Text = "Λεκτικά Εκτυπώσεων" : fGen.DataTable = "TTL" : fGen.L2.Text = "Λεκτικό"
                    Case "vw_COU" : fGen.Text = "Νομοί" : fGen.DataTable = "COU" : fGen.L2.Text = "Νομός"
                    Case "vw_DOY" : fGen.Text = "ΔΟΥ" : fGen.DataTable = "DOY" : fGen.L2.Text = "ΔΟΥ"
                    Case "vw_PRF" : fGen.Text = "Επαγγέλματα" : fGen.DataTable = "PRF" : fGen.L2.Text = "Επάγγελμα"
                    Case "vw_FTYPES" : fGen.Text = "Τύποι Καυσίμων" : fGen.DataTable = "FTYPES" : fGen.L2.Text = "Τύπος"
                    Case "vw_TECH_CAT" : fGen.Text = "Κατηγορίες Τεχνικής Υποστήριξης" : fGen.DataTable = "TECH_CAT" : fGen.L2.Text = "Κατηγορία"
                    Case "vw_COL_METHOD" : fGen.Text = "Τρόποι Είσπραξης" : fGen.DataTable = "COL_METHOD" : fGen.L2.Text = "Τρόπος Είσπραξης"
                    Case "vw_TASKS_CAT" : fGen.Text = "Εργασίες" : fGen.DataTable = "TASKS_CAT" : fGen.L2.Text = "Εργασίες"
                    Case "vw_FOLDER_CAT" : fGen.Text = "Κατηγορίες Φακέλων" : fGen.DataTable = "FOLDER_CAT" : fGen.L2.Text = "Κατηγορία"
                End Select
                fGen.ID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID").ToString
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.EditRecord
                fGen.Scroller = GridView1
                fGen.FormScroller = Me
                fGen.L1.Text = "Κωδικός"
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
        End Select
    End Sub
    'Νέα Εγγραφή
    Private Sub NewRecord()
        Select Case sDataTable
            Case "vw_PRIAMOSVER"
                Dim frmVersions As frmVersions = New frmVersions()
                frmVersions.Text = "Εκδόσεις"
                frmVersions.MdiParent = frmMain
                frmVersions.Mode = FormMode.NewRecord
                frmVersions.Scroller = GridView1
                frmVersions.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(frmVersions), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                frmVersions.Show()
            Case "vw_COL_EXT"
                Dim fColEXT As frmColExt = New frmColExt()
                frmColExt.Text = "Λοιπές Εισπράξεις"
                frmColExt.MdiParent = frmMain
                frmColExt.Mode = FormMode.NewRecord
                frmColExt.Scroller = GridView1
                frmColExt.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(frmColExt), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                frmColExt.Show()
            Case "vw_TASKS"
                Dim fTASKS As frmTasks = New frmTasks()
                fTASKS.Text = "Εργασίες Υποθέσεων"
                fTASKS.MdiParent = frmMain
                fTASKS.Mode = FormMode.NewRecord
                fTASKS.Scroller = GridView1
                fTASKS.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fTASKS), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fTASKS.Show()
            Case "vw_CASES"
                Dim fCASES As frmCases = New frmCases()
                fCASES.Text = "Υποθέσεις"
                fCASES.MdiParent = frmMain
                fCASES.Mode = FormMode.NewRecord
                fCASES.Scroller = GridView1
                fCASES.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fCASES), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fCASES.Show()
            Case "vw_COL"
                Dim fcol As frmCollections = New frmCollections()
                fcol.Text = "Εισπράξεις"
                fcol.MdiParent = frmMain
                fcol.Mode = FormMode.NewRecord
                fcol.Scroller = GridView1
                fcol.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fcol), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fcol.Show()
            Case "vw_APOL"
                Dim fApol As frmApol = New frmApol()
                fApol.Text = "Απολυμάνσεις"
                fApol.MdiParent = frmMain
                fApol.Mode = FormMode.NewRecord
                fApol.Scroller = GridView1
                fApol.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fApol), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fApol.Show()
            Case "vw_INH"
                Dim fINH As frmINH = New frmINH()
                fINH.Text = "Έξοδα"
                fINH.MdiParent = frmMain
                fINH.Mode = FormMode.NewRecord
                fINH.Scroller = GridView1
                fINH.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fINH), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fINH.Show()
            Case "vw_EXP"
                Dim fExp As frmEXP = New frmEXP()
                fExp.Text = "Έξοδα"
                fExp.MdiParent = frmMain
                fExp.Mode = FormMode.NewRecord
                fExp.Scroller = GridView1
                fExp.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fExp), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fExp.Show()
            Case "vw_TECH_SUP"
                Dim fTechicalSupport As frmTecnicalSupport = New frmTecnicalSupport()
                fTechicalSupport.Text = "Διαχείριση Τεχνικής Υποστήριξης"
                fTechicalSupport.MdiParent = frmMain
                fTechicalSupport.Mode = FormMode.NewRecord
                fTechicalSupport.Scroller = GridView1
                fTechicalSupport.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fTechicalSupport), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fTechicalSupport.Show()
            Case "vw_USR"
                Dim fUsers As frmUsers = New frmUsers()
                fUsers.Text = "Διαχείριση Χρηστών"
                fUsers.MdiParent = frmMain
                fUsers.Mode = FormMode.NewRecord
                fUsers.Scroller = GridView1
                fUsers.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fUsers), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fUsers.Show()
            Case "vw_MAILS"
                Dim fMailSettings As frmMailSettings = New frmMailSettings()
                fMailSettings.Text = "Email Settings"
                fMailSettings.MdiParent = frmMain
                fMailSettings.Mode = FormMode.NewRecord
                fMailSettings.Scroller = GridView1
                fMailSettings.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fMailSettings), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fMailSettings.Show()
            Case "vw_RIGHTS"
                Dim fPermissions As frmPermissions = New frmPermissions()
                fPermissions.Text = "Δικαιώματα"
                fPermissions.MdiParent = frmMain
                fPermissions.Mode = FormMode.NewRecord
                fPermissions.Scroller = GridView1
                fPermissions.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fPermissions), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fPermissions.Show()
            Case "vw_BDG"
                Dim fBDG As frmBDG = New frmBDG()
                fBDG.Text = "Πολυκατοικίες"
                fBDG.MdiParent = frmMain
                fBDG.Mode = FormMode.NewRecord
                fBDG.Scroller = GridView1
                fBDG.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fBDG), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fBDG.Show()
            Case "vw_CCT"
                Dim fCustomers As frmCustomers = New frmCustomers()
                fCustomers.Text = "Πελάτες"
                fCustomers.MdiParent = frmMain
                fCustomers.Mode = FormMode.NewRecord
                fCustomers.Scroller = GridView1
                fCustomers.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fCustomers), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fCustomers.Show()
            Case "vw_PRM"
                Dim fParameters As frmParameters = New frmParameters()
                fParameters.Text = "Παράμετροι"
                fParameters.MdiParent = frmMain
                fParameters.Mode = FormMode.NewRecord
                fParameters.Scroller = GridView1
                fParameters.FormScroller = Me
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fParameters), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fParameters.Show()
            Case "vw_AREAS"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Περιοχές"
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.NewRecord
                fGen.Scroller = GridView1
                fGen.DataTable = "AREAS"
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Περιοχή"
                fGen.L3.Text = "Νομός"
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                fGen.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_ADR"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Διευθύνσεις"
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.NewRecord
                fGen.Scroller = GridView1
                fGen.DataTable = "ADR"
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Διεύθυνση"
                fGen.L3.Text = "Νομός"
                fGen.L4.Text = "Περιοχές"
                fGen.L7.Text = "ΤΚ"
                fGen.L7.Control.Tag = "tk,0,1,2"
                fGen.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_CALC_TYPES"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Τύποι Υπολογισμού"
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.NewRecord
                fGen.Scroller = GridView1
                fGen.DataTable = "CALC_TYPES"
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Όνομα"
                fGen.chk1.Text = "Ενεργό"
                fGen.L7.Text = "Τύπος"
                fGen.txtL7.Tag = "type,0,1,2"
                fGen.L5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_CALC_CAT"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Κατηγορίες Υπολογισμών"
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.NewRecord
                fGen.Scroller = GridView1
                fGen.DataTable = "CALC_CAT"
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Όνομα"
                fGen.L3.Text = "Τύπος Υπολογισμού"
                fGen.L3.Control.Tag = "calcTypeID,0,1,2"
                fGen.L3.Tag = ""
                fGen.L3.ImageOptions.Image = Nothing
                fGen.L4.Text = "Κατηγορία Χιλιοστών"
                fGen.L4.Control.Tag = "mlcID,0,1,2"
                fGen.L4.Tag = ""
                fGen.L4.ImageOptions.Image = Nothing
                fGen.L7.Text = "Λεκτικό Εκτύπωσης"
                fGen.L7.Control.Tag = "repName,0,1,2"
                fGen.L7.Tag = ""
                fGen.L7.ImageOptions.Image = Nothing
                fGen.L8.Text = "Θέση Ταξινόμησης"
                fGen.txtNum.Tag = "ord,0,1,2"
                fGen.L3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_MLC"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Κατηγορίες Χιλιοστών"
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.NewRecord
                fGen.Scroller = GridView1
                fGen.DataTable = "MLC"
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Κατηγορία"
                fGen.L6.Text = "Χρώμα"
                fGen.L7.Text = "Λεκτικό Εκτύπωσης"
                fGen.L7.Control.Tag = "repName,0,1,2"
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                fGen.L6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.L7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
            Case "vw_BANKS"
                Dim fGen As frmGen = New frmGen()
                fGen.Text = "Τράπεζες"
                fGen.DataTable = "BANKS"
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.NewRecord
                fGen.Scroller = GridView1
                fGen.FormScroller = Me
                fGen.L1.Text = "Κωδικός"
                fGen.L2.Text = "Τράπεζα"
                fGen.L9.Text = "Διαδρομή φακέλλου"
                fGen.L9.Control.Tag = "folderPath,0,1,2"
                fGen.L9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()

            Case "vw_ANN_MENTS", "vw_COU", "vw_DOY", "vw_PRF", "vw_HTYPES", "vw_BTYPES", "vw_FTYPES", "vw_TECH_CAT", "vw_CALC_CAT", "vw_TTL",
                 "vw_APOL_TYPES", "vw_COL_METHOD", "vw_TASKS_CAT", "vw_FOLDER_CAT"
                Dim fGen As frmGen = New frmGen()
                Select Case sDataTable
                    Case "vw_APOL_TYPES" : fGen.Text = "Τύποι Απολύμανσης" : fGen.DataTable = "APOL_TYPES" : fGen.L2.Text = "Τύπος"
                    Case "vw_ANN_MENTS" : fGen.Text = "Ανακοινώσεις" : fGen.DataTable = "ANN_MENTS" : fGen.L2.Text = "Ανακοίνωση"
                    Case "vw_TTL" : fGen.Text = "Λεκτικά Εκτυπώσεων" : fGen.DataTable = "TTL" : fGen.L2.Text = "Λεκτικό"
                    Case "vw_COU" : fGen.Text = "Νομοί" : fGen.DataTable = "COU" : fGen.L2.Text = "Νομός"
                    Case "vw_DOY" : fGen.Text = "ΔΟΥ" : fGen.DataTable = "DOY" : fGen.L2.Text = "ΔΟΥ"
                    Case "vw_PRF" : fGen.Text = "Επαγγέλματα" : fGen.DataTable = "PRF" : fGen.L2.Text = "Επάγγελμα"
                    Case "vw_FTYPES" : fGen.Text = "Τύποι Καυσίμων" : fGen.DataTable = "FTYPES" : fGen.L2.Text = "Τύπος"
                    Case "vw_TECH_CAT" : fGen.Text = "Κατηγορίες Τεχνικής Υποστήριξης" : fGen.DataTable = "TECH_CAT" : fGen.L2.Text = "Κατηγορία"
                    Case "vw_COL_METHOD" : fGen.Text = "Τρόποι Είσπραξης" : fGen.DataTable = "COL_METHOD" : fGen.L2.Text = "Τρόπος Είσπραξης"
                    Case "vw_TASKS_CAT" : fGen.Text = "Εργασίες" : fGen.DataTable = "TASKS_CAT" : fGen.L2.Text = "Εργασίες"
                    Case "vw_FOLDER_CAT" : fGen.Text = "Κατηγορίες Φακέλων" : fGen.DataTable = "FOLDER_CAT" : fGen.L2.Text = "Κατηγορία"
                End Select
                fGen.MdiParent = frmMain
                fGen.Mode = FormMode.NewRecord
                fGen.Scroller = GridView1
                fGen.FormScroller = Me
                fGen.L1.Text = "Κωδικός"
                fGen.FormScroller = Me
                fGen.CalledFromControl = False
                frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(fGen), New Point(CInt(Me.Parent.ClientRectangle.Width / 2 - Me.Width / 2), CInt(Me.Parent.ClientRectangle.Height / 2 - Me.Height / 2)))
                fGen.Show()
        End Select
    End Sub
    'Φορτώνω τις εγγραφές στο GRID
    Public Sub LoadRecords(Optional ByVal sDataTable2 As String = "", Optional ByVal sWhere As String = "", Optional ByVal CloseReader As Boolean = True)
        Try
            Dim sSQL As String
            Dim sSQL2 As String
            Dim sVal As Integer
            Dim sActiveFilter As String

            sActiveFilter = GridView1.ActiveFilterString
            sVal = RepositoryBarRecords.Items.IndexOf(BarRecords.EditValue)

            If sVal <> 4 And BarRecords.EditValue <> Nothing Then
                sSQL = "SELECT top " & BarRecords.EditValue & " * FROM " & IIf(sDataTable = "", sDataTable2, sDataTable) & " " & sWhereCondition
            Else
                sSQL = "SELECT  * FROM " & IIf(sDataTable = "", sDataTable2, sDataTable) & " " & sWhereCondition
            End If
            If sDataDetail <> "" Then sSQL2 = "SELECT  * FROM " & sDataDetail
            myCmd = CNDB.CreateCommand
            myCmd.CommandText = sSQL
            GridView1.Columns.Clear()
            myReader = myCmd.ExecuteReader()

            If sDataDetail = "" Then
                grdMain.DataSource = myReader
            Else
                Select Case sDataDetail
                    Case "vw_FORM_RIGHTS"
                        Dim AdapterMaster As New SqlDataAdapter(sSQL, CNDB)
                        Dim AdapterDetail As New SqlDataAdapter(sSQL2, CNDB)
                        Dim sdataSet As New DataSet()
                        AdapterMaster.Fill(sdataSet, IIf(sDataTable = "", sDataTable2, sDataTable))
                        AdapterDetail.Fill(sdataSet, sDataDetail)
                        Dim keyColumn As DataColumn = sdataSet.Tables(IIf(sDataTable = "", sDataTable2, sDataTable)).Columns("ID")
                        Dim foreignKeyColumn As DataColumn = sdataSet.Tables(sDataDetail).Columns("RID")
                        sdataSet.Relations.Add("Φόρμες", keyColumn, foreignKeyColumn)
                        GridView1.Columns.Clear()
                        GridView2.Columns.Clear()
                        grdMain.DataSource = sdataSet.Tables(IIf(sDataTable = "", sDataTable2, sDataTable))
                        grdMain.ForceInitialize()
                        If grdMain.LevelTree.Nodes.Count = 1 Then
                            Dim GrdView As New GridView(grdMain)
                            grdMain.LevelTree.Nodes.Add("Φόρμες", GridView2)
                            'Specify text to be displayed within detail tabs.
                            GrdView.ViewCaption = "Φόρμες"
                        End If
                    Case "vw_TASKS"
                        Dim AdapterMaster As New SqlDataAdapter(sSQL, CNDB)
                        Dim AdapterDetail As New SqlDataAdapter(sSQL2, CNDB)
                        Dim sdataSet As New DataSet()
                        AdapterMaster.Fill(sdataSet, IIf(sDataTable = "", sDataTable2, sDataTable))
                        AdapterDetail.Fill(sdataSet, sDataDetail)
                        Dim keyColumn As DataColumn = sdataSet.Tables(IIf(sDataTable = "", sDataTable2, sDataTable)).Columns("ID")
                        Dim foreignKeyColumn As DataColumn = sdataSet.Tables(sDataDetail).Columns("caseID")
                        sdataSet.Relations.Add("Εργασίες", keyColumn, foreignKeyColumn, False)
                        GridView1.Columns.Clear() : GridView2.Columns.Clear()
                        grdMain.DataSource = sdataSet.Tables(IIf(sDataTable = "", sDataTable2, sDataTable))
                        grdMain.ForceInitialize()
                        If grdMain.LevelTree.Nodes.Count = 1 Then
                            Dim GrdView As New GridView(grdMain)
                            grdMain.LevelTree.Nodes.Add("Εργασίες", GridView2)
                            'Specify text to be displayed within detail tabs.
                            GrdView.ViewCaption = "Εργασίες"
                        End If
                End Select
            End If
            grdMain.DefaultView.PopulateColumns()

            'Εαν δεν έχει data το Dataset αναγκαστικά προσθέτω μόνος μου τις στήλες
            If sDataDetail = "" Then
                If myReader.HasRows = False Then
                    GridView1.Columns.Clear()
                    For i As Integer = 0 To myReader.FieldCount - 1
                        Dim C As New GridColumn
                        C.Name = "col" & myReader.GetName(i).ToString
                        C.Caption = myReader.GetName(i).ToString
                        C.Visible = True
                        GridView1.Columns.Add(C)
                    Next i
                    'LoadViews()
                Else
                    'LoadViews()
                End If
            Else
                'LoadViews()
            End If
            LoadViews()
            GridView1.ActiveFilterString = sActiveFilter
            myCmd.Dispose()
            If CloseReader = True Then myReader.Close():myReader=nothing
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'If grdMain.DefaultView.DataRowCount <> 0 Then myReader.Close() 'myReader.Close()
    End Sub

    Private Sub grdMain_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMain.KeyDown
        Select Case e.KeyCode
            Case Keys.F2 : If UserProps.AllowInsert = True Then NewRecord()
            Case Keys.F3 : If UserProps.AllowEdit = True Then EditRecord()
            Case Keys.F5 : LoadRecords()
            Case Keys.Delete : If UserProps.AllowDelete = True Then DeleteRecord()
        End Select
    End Sub

    Private Sub frmScroller_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If e.Column.FieldName.Contains("pwd") Then e.DisplayText = StrDup(e.DisplayText.Length, "*")

    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        Dim view As GridView = CType(sender, GridView)
        If e.Control AndAlso e.KeyCode = Keys.C Then
            If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
                Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
            End If
            e.Handled = True
        ElseIf e.KeyCode = Keys.Enter Then
            If GridView1.IsGroupRow(GridView1.FocusedRowHandle) Then Exit Sub Else EditRecord()
        End If
    End Sub
    'Ορίζουμε το Detail View στο GridView2 που προσθέσαμε στο Design.  
    Private Sub grdMain_ViewRegistered(sender As Object, e As DevExpress.XtraGrid.ViewOperationEventArgs) Handles grdMain.ViewRegistered
        GridView2 = TryCast(e.View, GridView)
        GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridView2.OptionsBehavior.Editable = False
        GridView2.OptionsBehavior.ReadOnly = True
        GridView2.OptionsLayout.Columns.StoreAllOptions = True
        GridView2.OptionsLayout.Columns.StoreAppearance = True
        GridView2.OptionsLayout.StoreAllOptions = True
        GridView2.OptionsLayout.StoreAppearance = True
        GridView2.OptionsLayout.StoreFormatRules = True
        GridView2.OptionsPrint.PrintPreview = True
        GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView2.OptionsView.EnableAppearanceEvenRow = True
        If CurrentView = "" Then
            If sDataDetail <> "" Then
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\D_" & sDataDetail & "_def.xml") = False Then
                    If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\D_" & sDataDetail & "_def.xml", OptionsLayoutBase.FullLayout)
                End If
            End If
        Else
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\D_" & sDataDetail & "\" & BarViews.EditValue) = False Then
                If sDataDetail <> "" Then GridView2.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\D_" & sDataDetail & "\" & BarViews.EditValue, OptionsLayoutBase.FullLayout)
            End If
        End If
    End Sub
    'Αποθήκευση όψης ως Default
    Private Sub popSaveAsDefault_ItemClick(sender As Object, e As ItemClickEventArgs) Handles popSaveAsDefault.ItemClick
        If GridView1.OptionsLayout.LayoutVersion <> "" Then
            Dim sVer As Integer = GridView1.OptionsLayout.LayoutVersion.Replace("v", "")
            GridView1.OptionsLayout.LayoutVersion = "v" & sVer + 1
        Else
            GridView1.OptionsLayout.LayoutVersion = "v1"
        End If
        GridView1.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)
        If sDataDetail <> "" Then GridView2.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\D_" & sDataDetail & "_def.xml", OptionsLayoutBase.FullLayout)
        XtraMessageBox.Show("Η όψη αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If UserProps.ID.ToString.ToUpper = "E9CEFD11-47C0-4796-A46B-BC41C4C3606B" Or
           UserProps.ID.ToString.ToUpper = "526EAA73-3B21-4BEE-A575-F19BD2BC5FCF" Or
           UserProps.ID.ToString.ToUpper = "97E2CB01-93EA-4F97-B000-FDA359EC943C" Then
            If XtraMessageBox.Show("Θέλετε να γίνει κοινοποίηση της όψης? Εαν επιλέξετε 'Yes' όλοι οι χρήστες θα έχουν την ίδια όψη", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If My.Computer.FileSystem.FileExists(UserProps.ServerViewsPath & "DSGNS\DEF\" & sDataTable & "_def.xml") = False Then GridView1.OptionsLayout.LayoutVersion = "v1"
                GridView1.SaveLayoutToXml(UserProps.ServerViewsPath & "DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)
            End If
        End If

    End Sub
    ' Copy Cell
    Private Sub BarCopyCell_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyCell.ItemClick
        Dim view As GridView = CType(GridView1, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
        End If
    End Sub
    'Copy All
    Private Sub BarCopyAll_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyAll.ItemClick
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        GridView1.OptionsSelection.MultiSelect = False
    End Sub
    'Copy Row
    Private Sub BarCopyRow_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyRow.ItemClick
        Dim view As GridView = CType(GridView1, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            GridView1.OptionsSelection.MultiSelect = True
            GridView1.SelectRow(view.FocusedRowHandle)
            GridView1.CopyToClipboard()
            GridView1.OptionsSelection.MultiSelect = False
        End If
    End Sub
    'Copy Row
    Private Sub BarCopyRow_D_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyRow_D.ItemClick
        Dim view As GridView = CType(GridView2, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            GridView2.OptionsSelection.MultiSelect = True
            GridView2.SelectRow(view.FocusedRowHandle)
            GridView2.CopyToClipboard()
            GridView2.OptionsSelection.MultiSelect = False
        End If
    End Sub
    'Copy All
    Private Sub BarCopyAll_D_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyAll_D.ItemClick
        GridView2.OptionsSelection.MultiSelect = True
        GridView2.SelectAll()
        GridView2.CopyToClipboard()
        GridView2.OptionsSelection.MultiSelect = False
    End Sub
    ' Copy Cell
    Private Sub BarCopyCell_D_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCopyCell_D.ItemClick
        Dim view As GridView = CType(GridView2, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
        End If
    End Sub

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        Dim view As GridView = CType(sender, GridView)
        If e.Control AndAlso e.KeyCode = Keys.C Then
            If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
                Clipboard.SetText(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub BBUpdateViewFromDB_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBUpdateViewFromDB.ItemClick
        'ReadXml.UpdateXMLFile(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml")
        'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml")
        Try
            Dim col1 As GridColumn
            Dim Col2 As GridColumn
            Dim grdColumns As List(Of GridColumn)
            LoadRecords(,, False)
            If myReader Is Nothing Then Exit Sub
            'Εαν υπάρχουν πεδία που πρέπει να προστεθούν από την βάση
            If myReader.FieldCount >= GridView1.Columns.Count Then
                Dim schema As DataTable = myReader.GetSchemaTable()
                grdColumns = GridView1.Columns.ToList()
                For i As Integer = 0 To myReader.FieldCount - 1
                    Console.WriteLine(myReader.GetName(i))
                    If i < GridView1.Columns.Count Then
                        'Col2 = GridView1.Columns.Item(i)
                        Col2 = GridView1.Columns.ColumnByFieldName(myReader.GetName(i))
                    Else
                        Col2 = Nothing
                    End If
                    If Col2 Is Nothing Then
                        col1 = GridView1.Columns.AddField(myReader.GetName(i))
                        col1.FieldName = myReader.GetName(i)
                        col1.Visible = True
                        col1.VisibleIndex = 0
                        col1.AppearanceCell.BackColor = Color.Bisque
                    End If

                Next
                'Εαν έχουν σβηστεί πεδία από την βάση τα αφαιρεί και από το grid
            ElseIf myReader.FieldCount < GridView1.Columns.Count Then
                Dim schema As DataTable = myReader.GetSchemaTable()
                grdColumns = GridView1.Columns.ToList()

                For i As Integer = 0 To grdColumns.Count - 1
                    Try
                        Col2 = grdColumns(i)
                        Dim sOrd As String = myReader.GetOrdinal(Col2.FieldName)
                    Catch ex As Exception
                        Col2 = grdColumns(i)
                        GridView1.Columns.Remove(Col2)
                        Console.WriteLine(ex.Message)

                        Continue For
                    End Try

                Next

            End If
            LoadForms.LoadColumnDescriptionNames(grdMain, GridView1, , sDataTable)
            myReader.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    ' Φίλτρο Με επιλογή
    Private Sub BarFilterWithCell_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarFilterWithCell.ItemClick
        Dim view As GridView = CType(GridView1, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            Dim filterString As String = "[" & GridView1.FocusedColumn.FieldName & "]" & "=" & toSQLValueS(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
            GridView1.Columns(GridView1.FocusedColumn.FieldName).FilterInfo = New ColumnFilterInfo(filterString)
        End If

    End Sub
    ' Αφαίρεση Φίλτρου
    Private Sub BarRemoveFilterWithCell_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarRemoveFilterWithCell.ItemClick
        GridView1.Columns(GridView1.FocusedColumn.FieldName).ClearFilter()
    End Sub
    ' Φίλτρο Με εξαίρεση
    Private Sub BarFilterWithoutCell_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarFilterWithoutCell.ItemClick
        Dim view As GridView = CType(GridView1, GridView)
        If view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn) IsNot Nothing AndAlso view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString() <> [String].Empty Then
            Dim filterString As String = "[" & GridView1.FocusedColumn.FieldName & "]" & "<>" & toSQLValueS(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString())
            GridView1.Columns(GridView1.FocusedColumn.FieldName).FilterInfo = New ColumnFilterInfo(filterString)
        End If

    End Sub
    'Αφαίρεση όλων των φίλτρων
    Private Sub BarRemoveAllFilters_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarRemoveAllFilters.ItemClick
        GridView1.ClearColumnsFilter()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            Select Case e.Column.FieldName
                Case "color" : If Not IsDBNull(e.CellValue) Then e.Appearance.BackColor = Color.FromArgb(e.CellValue)
            End Select
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BBUpdateViewFileFromServer_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBUpdateViewFileFromServer.ItemClick
        If XtraMessageBox.Show("Θέλετε να γίνει μεταφορά της όψης από τον server?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            ' Έλεγχος αν υπάρχει όψη με μεταγενέστερη ημερομηνία στον Server
            If System.IO.File.Exists(UserProps.ServerViewsPath & "DSGNS\DEF\" & sDataTable & "_def.xml") = True Then
                My.Computer.FileSystem.CopyFile(UserProps.ServerViewsPath & "DSGNS\DEF\" & sDataTable & "_def.xml", Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", True)
                GridView1.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\" & sDataTable & "_def.xml", OptionsLayoutBase.FullLayout)

            End If
        End If
    End Sub

    Private Sub BBcolExtSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBcolExtSave.ItemClick
        Dim sSQL As String
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
        Dim I As Integer
        Dim credit As Decimal
        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)

                If GridView1.GetRowCellValue(selectedRowHandle, "ID") = Nothing Then Exit Sub
                If debitUsrID = Nothing Then XtraMessageBox.Show("Δεν έχετε επιλέξει εισπράκτορα", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If colMethodID = Nothing Then XtraMessageBox.Show("Δεν έχετε επιλέξει τρόπο πληρωμής", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                credit = Decimal.Parse(GridView1.GetRowCellValue(selectedRowHandle, "debit"))

                sSQL = "Update COL_EXT 
                        SET creditusrID = " & toSQLValueS(UserProps.ID.ToString) & " ," &
                        "debitusrID = " & toSQLValueS(debitUsrID) & " ," &
                        "colMethodID = " & toSQLValueS(colMethodID) & " ," &
                        "bankID = " & toSQLValueS(bankID) & " ," &
                        "credit = " & toSQLValueS(credit, True) & " ," &
                        "dtCredit = getdate() ," &
                        "completed = 1 ," &
                        "bal = 0 " &
                    "WHERE ID = " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next
            LoadRecords()

            XtraMessageBox.Show("Οι εγγραφές επιβεβαιώθηκαν με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Friend Sub Rep_DEBITUSR_Changed(sender As Object, e As EventArgs)

        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
            debitUsrID = editor.GetColumnValue("ID").ToString
            'debitUsrName = editor.GetColumnValue("RealName").ToString()

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Friend Sub Rep_COL_METHOD_Changed(sender As Object, e As EventArgs)

        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
            colMethodID = editor.EditValue.ToString
            'debitUsrName = editor.GetColumnValue("RealName").ToString()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Friend Sub Rep_ΒΑΝΚ_Changed(sender As Object, e As EventArgs)

        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
            bankID = editor.EditValue.ToString
            'debitUsrName = editor.GetColumnValue("RealName").ToString()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GridView1_CustomDrawColumnHeader(sender As Object, e As ColumnHeaderCustomDrawEventArgs) Handles GridView1.CustomDrawColumnHeader
        'If e.Column IsNot Nothing Then
        '    Dim filterIcon As Bitmap = My.Resources.icons8_filter_7

        '    'e.Info.InnerElements(e.Info.InnerElements.Count - 1).Alignment = StringAlignment.Far
        '    Dim filterBounds As Rectangle = Rectangle.Empty
        '    For Each info As DevExpress.Utils.Drawing.DrawElementInfo In e.Info.InnerElements
        '        Dim filterArguments As DevExpress.Utils.Drawing.ObjectInfoArgs = info.ElementInfo
        '        If filterArguments IsNot Nothing Then
        '            info.Visible = True
        '            e.Info.InnerElements.CalcBounds(e.Info, e.Cache, e.Bounds, e.Bounds)
        '            filterBounds = filterArguments.Bounds

        '        End If
        '    Next


        '    e.Painter.DrawObject(e.Info)
        '    e.Graphics.DrawImage(filterIcon, filterBounds)
        '    e.Handled = True
        'End If
    End Sub

    Private Sub BBcolExtCollector_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BBcolExtCollector.ItemClick
        Dim sSQL As String
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()
        Dim I As Integer
        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Int32 = selectedRowHandles(I)

                If GridView1.GetRowCellValue(selectedRowHandle, "ID") = Nothing Then Exit Sub
                If debitUsrID = Nothing Then XtraMessageBox.Show("Δεν έχετε επιλέξει εισπράκτορα", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub


                sSQL = "Update COL_EXT 
                        SET creditusrID = " & toSQLValueS(UserProps.ID.ToString) & " ," &
                        "debitusrID = " & toSQLValueS(debitUsrID) &
                    "WHERE ID = " & toSQLValueS(GridView1.GetRowCellValue(selectedRowHandle, "ID").ToString)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next
            LoadRecords()

            XtraMessageBox.Show("Οι εγγραφές χρεώθηκαν με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class