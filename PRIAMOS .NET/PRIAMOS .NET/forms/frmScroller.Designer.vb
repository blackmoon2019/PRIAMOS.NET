<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScroller
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim SelectQuery1 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
        Dim AllColumns1 As DevExpress.DataAccess.Sql.AllColumns = New DevExpress.DataAccess.Sql.AllColumns()
        Dim Table1 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim SelectQuery2 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
        Dim AllColumns2 As DevExpress.DataAccess.Sql.AllColumns = New DevExpress.DataAccess.Sql.AllColumns()
        Dim Table2 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScroller))
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.BarRecords = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryBarRecords = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.BarViewsManage = New DevExpress.XtraBars.BarButtonItem()
        Me.PopMenuViews = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.popSaveView = New DevExpress.XtraBars.BarButtonItem()
        Me.popSaveAsView = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryPopSaveAsView = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.popSaveAsDefault = New DevExpress.XtraBars.BarButtonItem()
        Me.popDeleteView = New DevExpress.XtraBars.BarButtonItem()
        Me.popRestoreView = New DevExpress.XtraBars.BarButtonItem()
        Me.BBUpdateViewFromDB = New DevExpress.XtraBars.BarButtonItem()
        Me.BBUpdateViewFileFromServer = New DevExpress.XtraBars.BarButtonItem()
        Me.BarViews = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryBarViews = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.BarPrintPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenuExport = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarPDFExport = New DevExpress.XtraBars.BarButtonItem()
        Me.BarExportHTML = New DevExpress.XtraBars.BarButtonItem()
        Me.BarExportMHT = New DevExpress.XtraBars.BarButtonItem()
        Me.BarExportXLSX = New DevExpress.XtraBars.BarButtonItem()
        Me.BarExportXLS = New DevExpress.XtraBars.BarButtonItem()
        Me.BarExportDOCX = New DevExpress.XtraBars.BarButtonItem()
        Me.BarExportRTF = New DevExpress.XtraBars.BarButtonItem()
        Me.BarExportTEXT = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem2 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem3 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem4 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarPB = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarNewRec = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.BarRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.BarPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenuPrint = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarSYG = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEIDOP = New DevExpress.XtraBars.BarButtonItem()
        Me.BarRECEIPTS = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEmail = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar4 = New DevExpress.XtraBars.Bar()
        Me.cboDebitUsr = New DevExpress.XtraBars.BarEditItem()
        Me.Rep_DEBITUSR = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.CollectorsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet = New PRIAMOS.NET.Priamos_NETDataSet()
        Me.cboColMethod = New DevExpress.XtraBars.BarEditItem()
        Me.Rep_COL_METHOD = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwCOLMETHODBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboBank = New DevExpress.XtraBars.BarEditItem()
        Me.Rep_ΒΑΝΚ = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwBANKSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BBcolExtCollector = New DevExpress.XtraBars.BarButtonItem()
        Me.BBcolExtSave = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarStaticItem5 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarCopyCell = New DevExpress.XtraBars.BarButtonItem()
        Me.BarCopyRow = New DevExpress.XtraBars.BarButtonItem()
        Me.BarCopyAll = New DevExpress.XtraBars.BarButtonItem()
        Me.BarCopyCell_D = New DevExpress.XtraBars.BarButtonItem()
        Me.BarCopyRow_D = New DevExpress.XtraBars.BarButtonItem()
        Me.BarCopyAll_D = New DevExpress.XtraBars.BarButtonItem()
        Me.BarFilterWithCell = New DevExpress.XtraBars.BarButtonItem()
        Me.BarFilterWithoutCell = New DevExpress.XtraBars.BarButtonItem()
        Me.BarRemoveFilterWithCell = New DevExpress.XtraBars.BarButtonItem()
        Me.BarRemoveAllFilters = New DevExpress.XtraBars.BarButtonItem()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemBreadCrumbEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryPopRenameView = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemMarqueeProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar()
        Me.SQLMain = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.SSM = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.PRIAMOS.NET.WaitForm), False, False)
        Me.XtraSaveFileDialog1 = New DevExpress.XtraEditors.XtraSaveFileDialog(Me.components)
        Me.PopupMenuRows = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.PopupMenuRowsDetail = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarEditItem2 = New DevExpress.XtraBars.BarEditItem()
        Me.Vw_COL_METHODTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_COL_METHODTableAdapter()
        Me.Vw_BANKSTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_BANKSTableAdapter()
        Me.CollectorsTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.CollectorsTableAdapter()
        Me.PanelResults = New DevExpress.XtraEditors.PanelControl()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFullname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmob = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colemail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcct_cmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSTATUS_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colallowschedule = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALERS_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcolor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colADR_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRealName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAREAS_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colstatusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colsch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcompleted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtcompleted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreatedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colsalersID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALERS_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtReminderDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colREM_VALUES_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colremValueID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReminder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colS_CCT_M_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colS_CCT_M_Color = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colS_CCT_M_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltmReminder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtReceiveDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtDeliverDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCusSaler = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreatedby_Realname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colphn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PopupMenuEmail = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarEmailSYG = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEmailEIDOP = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEmailRECEIPTS = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBarRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopMenuViews, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPopSaveAsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBarViews, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_DEBITUSR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollectorsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_COL_METHOD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwCOLMETHODBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_ΒΑΝΚ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwBANKSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemBreadCrumbEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPopRenameView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMarqueeProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuRows, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuRowsDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelResults.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView2
        '
        Me.GridView2.DetailHeight = 619
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.GridView2.GridControl = Me.grdMain
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsBehavior.ReadOnly = True
        Me.GridView2.OptionsLayout.Columns.StoreAllOptions = True
        Me.GridView2.OptionsLayout.Columns.StoreAppearance = True
        Me.GridView2.OptionsLayout.StoreAllOptions = True
        Me.GridView2.OptionsLayout.StoreAppearance = True
        Me.GridView2.OptionsLayout.StoreFormatRules = True
        Me.GridView2.OptionsPrint.PrintPreview = True
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.EnableAppearanceEvenRow = True
        '
        'grdMain
        '
        Me.grdMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMain.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        GridLevelNode1.LevelTemplate = Me.GridView2
        GridLevelNode1.RelationName = "Level1"
        Me.grdMain.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdMain.Location = New System.Drawing.Point(46, 112)
        Me.grdMain.MainView = Me.GridView1
        Me.grdMain.Margin = New System.Windows.Forms.Padding(5)
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(1719, 1055)
        Me.grdMain.TabIndex = 5
        Me.grdMain.UseEmbeddedNavigator = True
        Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView2})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 619
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.GridView1.GridControl = Me.grdMain
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.GridView1.OptionsLayout.Columns.StoreAllOptions = True
        Me.GridView1.OptionsLayout.Columns.StoreAppearance = True
        Me.GridView1.OptionsLayout.StoreAllOptions = True
        Me.GridView1.OptionsLayout.StoreAppearance = True
        Me.GridView1.OptionsLayout.StoreFormatRules = True
        Me.GridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView1.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView1.OptionsMenu.ShowSummaryItemMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsPrint.PrintPreview = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar3, Me.Bar2, Me.Bar4})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarRecords, Me.BarViews, Me.popDeleteView, Me.popRestoreView, Me.popSaveAsView, Me.popSaveView, Me.BarViewsManage, Me.BarPrintPreview, Me.BarButtonItem1, Me.BarPDFExport, Me.BarExportHTML, Me.BarExportMHT, Me.BarExportXLSX, Me.BarExportXLS, Me.BarExportDOCX, Me.BarExportRTF, Me.BarExportTEXT, Me.BarNewRec, Me.BarDelete, Me.BarEdit, Me.BarRefresh, Me.BarStaticItem1, Me.BarStaticItem2, Me.BarStaticItem3, Me.BarStaticItem4, Me.BarStaticItem5, Me.popSaveAsDefault, Me.BarCopyCell, Me.BarCopyRow, Me.BarCopyAll, Me.BarCopyCell_D, Me.BarCopyRow_D, Me.BarCopyAll_D, Me.BBUpdateViewFromDB, Me.BarFilterWithCell, Me.BarFilterWithoutCell, Me.BarRemoveFilterWithCell, Me.BarRemoveAllFilters, Me.BBUpdateViewFileFromServer, Me.cboDebitUsr, Me.cboColMethod, Me.cboBank, Me.BBcolExtSave, Me.BBcolExtCollector, Me.BarPrint, Me.BarSYG, Me.BarEIDOP, Me.BarRECEIPTS, Me.BarEmail, Me.BarPB, Me.BarEmailSYG, Me.BarEmailEIDOP, Me.BarEmailRECEIPTS})
        Me.BarManager1.MainMenu = Me.Bar1
        Me.BarManager1.MaxItemId = 69
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryBarRecords, Me.RepositoryBarViews, Me.RepositoryItemButtonEdit1, Me.RepositoryItemBreadCrumbEdit1, Me.RepositoryItemButtonEdit2, Me.RepositoryPopRenameView, Me.RepositoryPopSaveAsView, Me.Rep_DEBITUSR, Me.Rep_COL_METHOD, Me.Rep_ΒΑΝΚ, Me.RepositoryItemMarqueeProgressBar1, Me.RepositoryItemProgressBar1})
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "MainMenu"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarRecords, DevExpress.XtraBars.BarItemPaintStyle.Caption), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarViewsManage, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarViews, DevExpress.XtraBars.BarItemPaintStyle.Caption), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarPrintPreview, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.MultiLine = True
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "MainMenu"
        '
        'BarRecords
        '
        Me.BarRecords.Caption = "Records"
        Me.BarRecords.Edit = Me.RepositoryBarRecords
        Me.BarRecords.EditWidth = 80
        Me.BarRecords.Id = 3
        Me.BarRecords.Name = "BarRecords"
        '
        'RepositoryBarRecords
        '
        Me.RepositoryBarRecords.AutoHeight = False
        Me.RepositoryBarRecords.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryBarRecords.Name = "RepositoryBarRecords"
        '
        'BarViewsManage
        '
        Me.BarViewsManage.ActAsDropDown = True
        Me.BarViewsManage.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BarViewsManage.Caption = "Διαχείριση Όψεων"
        Me.BarViewsManage.DropDownControl = Me.PopMenuViews
        Me.BarViewsManage.Id = 19
        Me.BarViewsManage.Name = "BarViewsManage"
        '
        'PopMenuViews
        '
        Me.PopMenuViews.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.popSaveView), New DevExpress.XtraBars.LinkPersistInfo(Me.popSaveAsView), New DevExpress.XtraBars.LinkPersistInfo(Me.popSaveAsDefault), New DevExpress.XtraBars.LinkPersistInfo(Me.popDeleteView), New DevExpress.XtraBars.LinkPersistInfo(Me.popRestoreView), New DevExpress.XtraBars.LinkPersistInfo(Me.BBUpdateViewFromDB), New DevExpress.XtraBars.LinkPersistInfo(Me.BBUpdateViewFileFromServer)})
        Me.PopMenuViews.Manager = Me.BarManager1
        Me.PopMenuViews.Name = "PopMenuViews"
        '
        'popSaveView
        '
        Me.popSaveView.Caption = "Αποθήκευση"
        Me.popSaveView.Id = 18
        Me.popSaveView.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_to_grid_16
        Me.popSaveView.Name = "popSaveView"
        '
        'popSaveAsView
        '
        Me.popSaveAsView.Caption = "Αποθήκευση Ως"
        Me.popSaveAsView.Edit = Me.RepositoryPopSaveAsView
        Me.popSaveAsView.EditWidth = 100
        Me.popSaveAsView.Id = 17
        Me.popSaveAsView.ImageOptions.LargeImage = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_as_16
        Me.popSaveAsView.Name = "popSaveAsView"
        '
        'RepositoryPopSaveAsView
        '
        Me.RepositoryPopSaveAsView.AutoHeight = False
        Me.RepositoryPopSaveAsView.Name = "RepositoryPopSaveAsView"
        '
        'popSaveAsDefault
        '
        Me.popSaveAsDefault.Caption = "Αποθήκευση ως Αρχική"
        Me.popSaveAsDefault.Id = 41
        Me.popSaveAsDefault.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_to_grid_16
        Me.popSaveAsDefault.Name = "popSaveAsDefault"
        '
        'popDeleteView
        '
        Me.popDeleteView.Caption = "Διαγραφή"
        Me.popDeleteView.Id = 13
        Me.popDeleteView.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_delete_document_16
        Me.popDeleteView.Name = "popDeleteView"
        '
        'popRestoreView
        '
        Me.popRestoreView.Caption = "Επαναφορά στην Αρχική"
        Me.popRestoreView.Id = 14
        Me.popRestoreView.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_advertisement_page_16
        Me.popRestoreView.Name = "popRestoreView"
        '
        'BBUpdateViewFromDB
        '
        Me.BBUpdateViewFromDB.Caption = "Ενημέρωση πεδίων όψης από Βάση"
        Me.BBUpdateViewFromDB.Id = 48
        Me.BBUpdateViewFromDB.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_oracle_pl_sql_16
        Me.BBUpdateViewFromDB.Name = "BBUpdateViewFromDB"
        '
        'BBUpdateViewFileFromServer
        '
        Me.BBUpdateViewFileFromServer.Caption = "Συγχρονισμός όψης από Server"
        Me.BBUpdateViewFileFromServer.Id = 53
        Me.BBUpdateViewFileFromServer.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_server_16
        Me.BBUpdateViewFileFromServer.Name = "BBUpdateViewFileFromServer"
        '
        'BarViews
        '
        Me.BarViews.AutoFillWidth = True
        Me.BarViews.Caption = "Όψεις"
        Me.BarViews.Edit = Me.RepositoryBarViews
        Me.BarViews.EditWidth = 150
        Me.BarViews.Id = 5
        Me.BarViews.Name = "BarViews"
        '
        'RepositoryBarViews
        '
        Me.RepositoryBarViews.AutoHeight = False
        Me.RepositoryBarViews.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryBarViews.Name = "RepositoryBarViews"
        Me.RepositoryBarViews.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'BarPrintPreview
        '
        Me.BarPrintPreview.Caption = "Print Preview"
        Me.BarPrintPreview.Id = 22
        Me.BarPrintPreview.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_analyze_32
        Me.BarPrintPreview.Name = "BarPrintPreview"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.ActAsDropDown = True
        Me.BarButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BarButtonItem1.Caption = "Export"
        Me.BarButtonItem1.DropDownControl = Me.PopupMenuExport
        Me.BarButtonItem1.Id = 23
        Me.BarButtonItem1.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Export_32x32
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'PopupMenuExport
        '
        Me.PopupMenuExport.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarPDFExport), New DevExpress.XtraBars.LinkPersistInfo(Me.BarExportHTML), New DevExpress.XtraBars.LinkPersistInfo(Me.BarExportMHT), New DevExpress.XtraBars.LinkPersistInfo(Me.BarExportXLSX), New DevExpress.XtraBars.LinkPersistInfo(Me.BarExportXLS), New DevExpress.XtraBars.LinkPersistInfo(Me.BarExportDOCX), New DevExpress.XtraBars.LinkPersistInfo(Me.BarExportRTF), New DevExpress.XtraBars.LinkPersistInfo(Me.BarExportTEXT)})
        Me.PopupMenuExport.Manager = Me.BarManager1
        Me.PopupMenuExport.Name = "PopupMenuExport"
        '
        'BarPDFExport
        '
        Me.BarPDFExport.Caption = "Export To PDF"
        Me.BarPDFExport.Id = 24
        Me.BarPDFExport.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.ExportPdfLarge
        Me.BarPDFExport.Name = "BarPDFExport"
        '
        'BarExportHTML
        '
        Me.BarExportHTML.Caption = "Export To HTML"
        Me.BarExportHTML.Id = 25
        Me.BarExportHTML.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.ExportHtmLarge
        Me.BarExportHTML.Name = "BarExportHTML"
        '
        'BarExportMHT
        '
        Me.BarExportMHT.Caption = "Export To MHT"
        Me.BarExportMHT.Id = 26
        Me.BarExportMHT.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.ExportMhtLarge
        Me.BarExportMHT.Name = "BarExportMHT"
        '
        'BarExportXLSX
        '
        Me.BarExportXLSX.Caption = "Export To XLSX"
        Me.BarExportXLSX.Id = 27
        Me.BarExportXLSX.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.ExportXlsxLarge
        Me.BarExportXLSX.Name = "BarExportXLSX"
        '
        'BarExportXLS
        '
        Me.BarExportXLS.Caption = "Export To XLS"
        Me.BarExportXLS.Id = 28
        Me.BarExportXLS.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.ExportXlsLarge
        Me.BarExportXLS.Name = "BarExportXLS"
        '
        'BarExportDOCX
        '
        Me.BarExportDOCX.Caption = "Export To DOCX"
        Me.BarExportDOCX.Id = 29
        Me.BarExportDOCX.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_microsoft_word_2019_32
        Me.BarExportDOCX.Name = "BarExportDOCX"
        '
        'BarExportRTF
        '
        Me.BarExportRTF.Caption = "Export To RTF"
        Me.BarExportRTF.Id = 30
        Me.BarExportRTF.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.ExportRtfLarge
        Me.BarExportRTF.Name = "BarExportRTF"
        '
        'BarExportTEXT
        '
        Me.BarExportTEXT.Caption = "Export To TEXT"
        Me.BarExportTEXT.Id = 31
        Me.BarExportTEXT.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.ExportTxtLarge
        Me.BarExportTEXT.Name = "BarExportTEXT"
        '
        'Bar3
        '
        Me.Bar3.BarName = "StatusBar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem4), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, Me.BarPB, "", False, True, True, 203)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "StatusBar"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.BarStaticItem1.Caption = "[Νέα Εγγραφή]"
        Me.BarStaticItem1.Id = 36
        Me.BarStaticItem1.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_f2_key_20
        Me.BarStaticItem1.Name = "BarStaticItem1"
        Me.BarStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticItem2
        '
        Me.BarStaticItem2.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.BarStaticItem2.Caption = "[Επεξεργασία]"
        Me.BarStaticItem2.Id = 37
        Me.BarStaticItem2.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_f3_key_20
        Me.BarStaticItem2.Name = "BarStaticItem2"
        Me.BarStaticItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticItem3
        '
        Me.BarStaticItem3.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.BarStaticItem3.Caption = "[Ανανέωση]"
        Me.BarStaticItem3.Id = 38
        Me.BarStaticItem3.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_f5_key_20
        Me.BarStaticItem3.Name = "BarStaticItem3"
        Me.BarStaticItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticItem4
        '
        Me.BarStaticItem4.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.BarStaticItem4.Caption = "[Διαγραφή]"
        Me.BarStaticItem4.Id = 39
        Me.BarStaticItem4.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_delete_key_20
        Me.BarStaticItem4.Name = "BarStaticItem4"
        Me.BarStaticItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarPB
        '
        Me.BarPB.Caption = "BarPB"
        Me.BarPB.Edit = Me.RepositoryItemProgressBar1
        Me.BarPB.Id = 65
        Me.BarPB.Name = "BarPB"
        Me.BarPB.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Custom 4"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Left
        Me.Bar2.FloatLocation = New System.Drawing.Point(16, 408)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarNewRec), New DevExpress.XtraBars.LinkPersistInfo(Me.BarDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.BarRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.BarPrint), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEmail)})
        Me.Bar2.Offset = 1
        Me.Bar2.Text = "Custom 4"
        '
        'BarNewRec
        '
        Me.BarNewRec.Caption = "Νέα Εγγραφή"
        Me.BarNewRec.Id = 32
        Me.BarNewRec.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.AddFile_16x16
        Me.BarNewRec.Name = "BarNewRec"
        '
        'BarDelete
        '
        Me.BarDelete.Caption = "Διαγραφή Εγγραφής"
        Me.BarDelete.Id = 33
        Me.BarDelete.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Remove_16x16
        Me.BarDelete.Name = "BarDelete"
        '
        'BarEdit
        '
        Me.BarEdit.Caption = "Διόρθωση Εγγραφής"
        Me.BarEdit.Id = 34
        Me.BarEdit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Edit_16x16
        Me.BarEdit.Name = "BarEdit"
        '
        'BarRefresh
        '
        Me.BarRefresh.Caption = "Ανανέωση Εγγραφών"
        Me.BarRefresh.Id = 35
        Me.BarRefresh.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_refresh_16
        Me.BarRefresh.Name = "BarRefresh"
        '
        'BarPrint
        '
        Me.BarPrint.ActAsDropDown = True
        Me.BarPrint.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BarPrint.Caption = "Εκτύπωση"
        Me.BarPrint.DropDownControl = Me.PopupMenuPrint
        Me.BarPrint.Id = 59
        Me.BarPrint.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_print_16
        Me.BarPrint.Name = "BarPrint"
        Me.BarPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'PopupMenuPrint
        '
        Me.PopupMenuPrint.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSYG), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEIDOP), New DevExpress.XtraBars.LinkPersistInfo(Me.BarRECEIPTS)})
        Me.PopupMenuPrint.Manager = Me.BarManager1
        Me.PopupMenuPrint.Name = "PopupMenuPrint"
        '
        'BarSYG
        '
        Me.BarSYG.Caption = "Συγκεντρωτική"
        Me.BarSYG.Id = 60
        Me.BarSYG.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_aggregator_16
        Me.BarSYG.Name = "BarSYG"
        '
        'BarEIDOP
        '
        Me.BarEIDOP.Caption = "Ειδοποιήσεις"
        Me.BarEIDOP.Id = 61
        Me.BarEIDOP.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_documents_16
        Me.BarEIDOP.Name = "BarEIDOP"
        '
        'BarRECEIPTS
        '
        Me.BarRECEIPTS.Caption = "Αποδείξεις"
        Me.BarRECEIPTS.Id = 62
        Me.BarRECEIPTS.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_receipt_approved_16
        Me.BarRECEIPTS.Name = "BarRECEIPTS"
        '
        'BarEmail
        '
        Me.BarEmail.ActAsDropDown = True
        Me.BarEmail.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BarEmail.Caption = "Email"
        Me.BarEmail.DropDownControl = Me.PopupMenuEmail
        Me.BarEmail.Id = 63
        Me.BarEmail.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_email_16
        Me.BarEmail.Name = "BarEmail"
        '
        'Bar4
        '
        Me.Bar4.BarName = "COL_EXT"
        Me.Bar4.DockCol = 0
        Me.Bar4.DockRow = 1
        Me.Bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, Me.cboDebitUsr, "", False, True, True, 179), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, Me.cboColMethod, "", False, True, True, 127), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, Me.cboBank, "", False, True, True, 130), New DevExpress.XtraBars.LinkPersistInfo(Me.BBcolExtCollector), New DevExpress.XtraBars.LinkPersistInfo(Me.BBcolExtSave)})
        Me.Bar4.Text = "Custom 5"
        Me.Bar4.Visible = False
        '
        'cboDebitUsr
        '
        Me.cboDebitUsr.Caption = "Εισπράκτορας"
        Me.cboDebitUsr.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cboDebitUsr.Edit = Me.Rep_DEBITUSR
        Me.cboDebitUsr.Id = 54
        Me.cboDebitUsr.Name = "cboDebitUsr"
        Me.cboDebitUsr.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption
        '
        'Rep_DEBITUSR
        '
        Me.Rep_DEBITUSR.AutoHeight = False
        Me.Rep_DEBITUSR.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Rep_DEBITUSR.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Εισπράκτορας", 106, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.Rep_DEBITUSR.DataSource = Me.CollectorsBindingSource
        Me.Rep_DEBITUSR.DisplayMember = "RealName"
        Me.Rep_DEBITUSR.Name = "Rep_DEBITUSR"
        Me.Rep_DEBITUSR.NullText = ""
        Me.Rep_DEBITUSR.ValueMember = "ID"
        '
        'CollectorsBindingSource
        '
        Me.CollectorsBindingSource.DataMember = "Collectors"
        Me.CollectorsBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'Priamos_NETDataSet
        '
        Me.Priamos_NETDataSet.DataSetName = "Priamos_NETDataSet"
        Me.Priamos_NETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboColMethod
        '
        Me.cboColMethod.Caption = "Τρόπος Πληρωμής"
        Me.cboColMethod.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cboColMethod.Edit = Me.Rep_COL_METHOD
        Me.cboColMethod.Id = 55
        Me.cboColMethod.Name = "cboColMethod"
        Me.cboColMethod.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption
        '
        'Rep_COL_METHOD
        '
        Me.Rep_COL_METHOD.AutoHeight = False
        Me.Rep_COL_METHOD.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Rep_COL_METHOD.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Τρόπος Πληρωμής", 62, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Real Name", 106, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.Rep_COL_METHOD.DataSource = Me.VwCOLMETHODBindingSource
        Me.Rep_COL_METHOD.DisplayMember = "name"
        Me.Rep_COL_METHOD.Name = "Rep_COL_METHOD"
        Me.Rep_COL_METHOD.NullText = ""
        Me.Rep_COL_METHOD.ValueMember = "ID"
        '
        'VwCOLMETHODBindingSource
        '
        Me.VwCOLMETHODBindingSource.DataMember = "vw_COL_METHOD"
        Me.VwCOLMETHODBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'cboBank
        '
        Me.cboBank.Caption = "Τράπεζα"
        Me.cboBank.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cboBank.Edit = Me.Rep_ΒΑΝΚ
        Me.cboBank.Id = 56
        Me.cboBank.Name = "cboBank"
        Me.cboBank.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption
        '
        'Rep_ΒΑΝΚ
        '
        Me.Rep_ΒΑΝΚ.AutoHeight = False
        Me.Rep_ΒΑΝΚ.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Rep_ΒΑΝΚ.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Real Name", 106, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Τράπεζα", 62, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdBy", "created By", 104, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.Rep_ΒΑΝΚ.DataSource = Me.VwBANKSBindingSource
        Me.Rep_ΒΑΝΚ.DisplayMember = "name"
        Me.Rep_ΒΑΝΚ.Name = "Rep_ΒΑΝΚ"
        Me.Rep_ΒΑΝΚ.NullText = ""
        Me.Rep_ΒΑΝΚ.ValueMember = "ID"
        '
        'VwBANKSBindingSource
        '
        Me.VwBANKSBindingSource.DataMember = "vw_BANKS"
        Me.VwBANKSBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'BBcolExtCollector
        '
        Me.BBcolExtCollector.Caption = "Χρέωση Εισπράκτορα"
        Me.BBcolExtCollector.Id = 58
        Me.BBcolExtCollector.Name = "BBcolExtCollector"
        '
        'BBcolExtSave
        '
        Me.BBcolExtSave.Caption = "Επιβεβαίωση Είσπραξης"
        Me.BBcolExtSave.Id = 57
        Me.BBcolExtSave.Name = "BBcolExtSave"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(5)
        Me.barDockControlTop.Size = New System.Drawing.Size(1765, 112)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 1167)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(5)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1765, 49)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 112)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(5)
        Me.barDockControlLeft.Size = New System.Drawing.Size(46, 1055)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1765, 112)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(5)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 1055)
        '
        'BarStaticItem5
        '
        Me.BarStaticItem5.Caption = "BarStaticItem5"
        Me.BarStaticItem5.Id = 40
        Me.BarStaticItem5.Name = "BarStaticItem5"
        '
        'BarCopyCell
        '
        Me.BarCopyCell.Caption = "Αντιγραφή Κελιού"
        Me.BarCopyCell.Id = 42
        Me.BarCopyCell.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_copy_16
        Me.BarCopyCell.Name = "BarCopyCell"
        '
        'BarCopyRow
        '
        Me.BarCopyRow.Caption = "Αντιγραφή Γραμμής"
        Me.BarCopyRow.Id = 43
        Me.BarCopyRow.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_copy_16
        Me.BarCopyRow.Name = "BarCopyRow"
        '
        'BarCopyAll
        '
        Me.BarCopyAll.Caption = "Αντιγραφή όλα"
        Me.BarCopyAll.Id = 44
        Me.BarCopyAll.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_copy_16
        Me.BarCopyAll.Name = "BarCopyAll"
        '
        'BarCopyCell_D
        '
        Me.BarCopyCell_D.Caption = "Αντιγραφή κελιού"
        Me.BarCopyCell_D.Id = 45
        Me.BarCopyCell_D.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_copy_16
        Me.BarCopyCell_D.Name = "BarCopyCell_D"
        '
        'BarCopyRow_D
        '
        Me.BarCopyRow_D.Caption = "Αντιγραφή Γραμμής"
        Me.BarCopyRow_D.Id = 46
        Me.BarCopyRow_D.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_copy_16
        Me.BarCopyRow_D.Name = "BarCopyRow_D"
        '
        'BarCopyAll_D
        '
        Me.BarCopyAll_D.Caption = "Αντιγραφή όλα"
        Me.BarCopyAll_D.Id = 47
        Me.BarCopyAll_D.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_copy_16
        Me.BarCopyAll_D.Name = "BarCopyAll_D"
        '
        'BarFilterWithCell
        '
        Me.BarFilterWithCell.Caption = "Φίλτρο με επιλογή"
        Me.BarFilterWithCell.Id = 49
        Me.BarFilterWithCell.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_filter_16
        Me.BarFilterWithCell.Name = "BarFilterWithCell"
        '
        'BarFilterWithoutCell
        '
        Me.BarFilterWithoutCell.Caption = "Φίλτρο με εξαίρεση"
        Me.BarFilterWithoutCell.Id = 50
        Me.BarFilterWithoutCell.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_filter_16
        Me.BarFilterWithoutCell.Name = "BarFilterWithoutCell"
        '
        'BarRemoveFilterWithCell
        '
        Me.BarRemoveFilterWithCell.Caption = "Αφαίρεση Φίλτρου"
        Me.BarRemoveFilterWithCell.Id = 51
        Me.BarRemoveFilterWithCell.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_clear_filters_16
        Me.BarRemoveFilterWithCell.Name = "BarRemoveFilterWithCell"
        '
        'BarRemoveAllFilters
        '
        Me.BarRemoveAllFilters.Caption = "Αφαίρεση όλων των φίλτρων"
        Me.BarRemoveAllFilters.Id = 52
        Me.BarRemoveAllFilters.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_clear_filters_16
        Me.BarRemoveAllFilters.Name = "BarRemoveAllFilters"
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'RepositoryItemBreadCrumbEdit1
        '
        Me.RepositoryItemBreadCrumbEdit1.AutoHeight = False
        Me.RepositoryItemBreadCrumbEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemBreadCrumbEdit1.Name = "RepositoryItemBreadCrumbEdit1"
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'RepositoryPopRenameView
        '
        Me.RepositoryPopRenameView.AutoHeight = False
        Me.RepositoryPopRenameView.Name = "RepositoryPopRenameView"
        '
        'RepositoryItemMarqueeProgressBar1
        '
        Me.RepositoryItemMarqueeProgressBar1.Name = "RepositoryItemMarqueeProgressBar1"
        '
        'SQLMain
        '
        Me.SQLMain.ConnectionName = "myConnectionString"
        Me.SQLMain.Name = "SQLMain"
        Table1.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""183"" />"
        Table1.Name = "USR"
        AllColumns1.Table = Table1
        SelectQuery1.Columns.Add(AllColumns1)
        SelectQuery1.Name = "USR"
        SelectQuery1.Tables.Add(Table1)
        Table2.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""303"" />"
        Table2.Name = "IAT"
        AllColumns2.Table = Table2
        SelectQuery2.Columns.Add(AllColumns2)
        SelectQuery2.Name = "IAT"
        SelectQuery2.Tables.Add(Table2)
        CustomSqlQuery1.Name = "INH"
        CustomSqlQuery1.Sql = "select top 1000 ""INH"".*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  from ""dbo"".""INH"" ""INH"""
        Me.SQLMain.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1, SelectQuery2, CustomSqlQuery1})
        Me.SQLMain.ResultSchemaSerializable = resources.GetString("SQLMain.ResultSchemaSerializable")
        '
        'SSM
        '
        Me.SSM.ClosingDelay = 500
        '
        'XtraSaveFileDialog1
        '
        Me.XtraSaveFileDialog1.FileName = "XtraSaveFileDialog1"
        '
        'PopupMenuRows
        '
        Me.PopupMenuRows.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarFilterWithCell, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarFilterWithoutCell), New DevExpress.XtraBars.LinkPersistInfo(Me.BarRemoveFilterWithCell), New DevExpress.XtraBars.LinkPersistInfo(Me.BarRemoveAllFilters), New DevExpress.XtraBars.LinkPersistInfo(Me.BarCopyCell, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarCopyRow), New DevExpress.XtraBars.LinkPersistInfo(Me.BarCopyAll)})
        Me.PopupMenuRows.Manager = Me.BarManager1
        Me.PopupMenuRows.Name = "PopupMenuRows"
        '
        'PopupMenuRowsDetail
        '
        Me.PopupMenuRowsDetail.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarCopyCell_D), New DevExpress.XtraBars.LinkPersistInfo(Me.BarCopyRow_D), New DevExpress.XtraBars.LinkPersistInfo(Me.BarCopyAll_D)})
        Me.PopupMenuRowsDetail.Manager = Me.BarManager1
        Me.PopupMenuRowsDetail.Name = "PopupMenuRowsDetail"
        '
        'BarEditItem2
        '
        Me.BarEditItem2.Caption = "Εισπράκτορας"
        Me.BarEditItem2.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.BarEditItem2.Edit = Me.Rep_DEBITUSR
        Me.BarEditItem2.Id = 54
        Me.BarEditItem2.Name = "BarEditItem2"
        Me.BarEditItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption
        '
        'Vw_COL_METHODTableAdapter
        '
        Me.Vw_COL_METHODTableAdapter.ClearBeforeFill = True
        '
        'Vw_BANKSTableAdapter
        '
        Me.Vw_BANKSTableAdapter.ClearBeforeFill = True
        '
        'CollectorsTableAdapter
        '
        Me.CollectorsTableAdapter.ClearBeforeFill = True
        '
        'PanelResults
        '
        Me.PanelResults.Controls.Add(Me.cmdExit)
        Me.PanelResults.Controls.Add(Me.GridControl1)
        Me.PanelResults.Location = New System.Drawing.Point(131, 213)
        Me.PanelResults.Margin = New System.Windows.Forms.Padding(5)
        Me.PanelResults.Name = "PanelResults"
        Me.PanelResults.Size = New System.Drawing.Size(1585, 775)
        Me.PanelResults.TabIndex = 11
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Location = New System.Drawing.Point(1428, 709)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(148, 50)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "Έξοδος"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.GridControl1.Location = New System.Drawing.Point(8, 5)
        Me.GridControl1.MainView = Me.GridView3
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1568, 694)
        Me.GridControl1.TabIndex = 7
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colFullname, Me.colmob, Me.colemail, Me.colcct_cmt, Me.colcode, Me.colSTATUS_Name, Me.colallowschedule, Me.colSALERS_Name, Me.colcolor, Me.colADR_Name, Me.colAr, Me.coltk, Me.colRealName, Me.colAREAS_Name, Me.colstatusID, Me.colcusID, Me.colsch, Me.colcompleted, Me.coldtcompleted, Me.colcmt, Me.colcreatedOn, Me.colmodifiedOn, Me.colsalersID, Me.colSALERS_Code, Me.coldtReminderDate, Me.colREM_VALUES_name, Me.colremValueID, Me.colReminder, Me.colS_CCT_M_Code, Me.colS_CCT_M_Color, Me.colS_CCT_M_name, Me.coltmReminder, Me.coldtReceiveDate, Me.coldtDeliverDate, Me.colCusSaler, Me.colcreatedby_Realname, Me.colphn})
        Me.GridView3.DetailHeight = 619
        Me.GridView3.GridControl = Me.GridControl1
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsBehavior.ReadOnly = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.MinWidth = 33
        Me.colID.Name = "colID"
        Me.colID.Width = 125
        '
        'colFullname
        '
        Me.colFullname.Caption = "ΠΕΛΑΤΗΣ"
        Me.colFullname.FieldName = "Fullname"
        Me.colFullname.MinWidth = 33
        Me.colFullname.Name = "colFullname"
        Me.colFullname.Visible = True
        Me.colFullname.VisibleIndex = 2
        Me.colFullname.Width = 125
        '
        'colmob
        '
        Me.colmob.Caption = "ΚΙΝΗΤΟ"
        Me.colmob.FieldName = "mob"
        Me.colmob.MinWidth = 33
        Me.colmob.Name = "colmob"
        Me.colmob.Width = 125
        '
        'colemail
        '
        Me.colemail.Caption = "EMAIL"
        Me.colemail.FieldName = "email"
        Me.colemail.MinWidth = 33
        Me.colemail.Name = "colemail"
        Me.colemail.Width = 125
        '
        'colcct_cmt
        '
        Me.colcct_cmt.FieldName = "cct_cmt"
        Me.colcct_cmt.MinWidth = 33
        Me.colcct_cmt.Name = "colcct_cmt"
        Me.colcct_cmt.Width = 125
        '
        'colcode
        '
        Me.colcode.FieldName = "code"
        Me.colcode.MinWidth = 33
        Me.colcode.Name = "colcode"
        Me.colcode.Width = 125
        '
        'colSTATUS_Name
        '
        Me.colSTATUS_Name.Caption = "STATUS"
        Me.colSTATUS_Name.FieldName = "STATUS_Name"
        Me.colSTATUS_Name.MinWidth = 33
        Me.colSTATUS_Name.Name = "colSTATUS_Name"
        Me.colSTATUS_Name.Visible = True
        Me.colSTATUS_Name.VisibleIndex = 0
        Me.colSTATUS_Name.Width = 125
        '
        'colallowschedule
        '
        Me.colallowschedule.FieldName = "allowschedule"
        Me.colallowschedule.MinWidth = 33
        Me.colallowschedule.Name = "colallowschedule"
        Me.colallowschedule.Width = 125
        '
        'colSALERS_Name
        '
        Me.colSALERS_Name.FieldName = "SALERS_Name"
        Me.colSALERS_Name.MinWidth = 33
        Me.colSALERS_Name.Name = "colSALERS_Name"
        Me.colSALERS_Name.Width = 125
        '
        'colcolor
        '
        Me.colcolor.FieldName = "color"
        Me.colcolor.MinWidth = 33
        Me.colcolor.Name = "colcolor"
        Me.colcolor.Width = 125
        '
        'colADR_Name
        '
        Me.colADR_Name.FieldName = "ADR_Name"
        Me.colADR_Name.MinWidth = 33
        Me.colADR_Name.Name = "colADR_Name"
        Me.colADR_Name.Width = 125
        '
        'colAr
        '
        Me.colAr.FieldName = "Ar"
        Me.colAr.MinWidth = 33
        Me.colAr.Name = "colAr"
        Me.colAr.Width = 125
        '
        'coltk
        '
        Me.coltk.FieldName = "tk"
        Me.coltk.MinWidth = 33
        Me.coltk.Name = "coltk"
        Me.coltk.Width = 125
        '
        'colRealName
        '
        Me.colRealName.FieldName = "RealName"
        Me.colRealName.MinWidth = 33
        Me.colRealName.Name = "colRealName"
        Me.colRealName.Width = 125
        '
        'colAREAS_Name
        '
        Me.colAREAS_Name.FieldName = "AREAS_Name"
        Me.colAREAS_Name.MinWidth = 33
        Me.colAREAS_Name.Name = "colAREAS_Name"
        Me.colAREAS_Name.Width = 125
        '
        'colstatusID
        '
        Me.colstatusID.FieldName = "statusID"
        Me.colstatusID.MinWidth = 33
        Me.colstatusID.Name = "colstatusID"
        Me.colstatusID.Width = 125
        '
        'colcusID
        '
        Me.colcusID.FieldName = "cusID"
        Me.colcusID.MinWidth = 33
        Me.colcusID.Name = "colcusID"
        Me.colcusID.Width = 125
        '
        'colsch
        '
        Me.colsch.FieldName = "sch"
        Me.colsch.MinWidth = 33
        Me.colsch.Name = "colsch"
        Me.colsch.Width = 125
        '
        'colcompleted
        '
        Me.colcompleted.FieldName = "completed"
        Me.colcompleted.MinWidth = 33
        Me.colcompleted.Name = "colcompleted"
        Me.colcompleted.Width = 125
        '
        'coldtcompleted
        '
        Me.coldtcompleted.FieldName = "dtcompleted"
        Me.coldtcompleted.MinWidth = 33
        Me.coldtcompleted.Name = "coldtcompleted"
        Me.coldtcompleted.Width = 125
        '
        'colcmt
        '
        Me.colcmt.FieldName = "cmt"
        Me.colcmt.MinWidth = 33
        Me.colcmt.Name = "colcmt"
        Me.colcmt.Width = 125
        '
        'colcreatedOn
        '
        Me.colcreatedOn.FieldName = "createdOn"
        Me.colcreatedOn.MinWidth = 33
        Me.colcreatedOn.Name = "colcreatedOn"
        Me.colcreatedOn.Width = 125
        '
        'colmodifiedOn
        '
        Me.colmodifiedOn.FieldName = "modifiedOn"
        Me.colmodifiedOn.MinWidth = 33
        Me.colmodifiedOn.Name = "colmodifiedOn"
        Me.colmodifiedOn.Width = 125
        '
        'colsalersID
        '
        Me.colsalersID.FieldName = "salersID"
        Me.colsalersID.MinWidth = 33
        Me.colsalersID.Name = "colsalersID"
        Me.colsalersID.Width = 125
        '
        'colSALERS_Code
        '
        Me.colSALERS_Code.FieldName = "SALERS_Code"
        Me.colSALERS_Code.MinWidth = 33
        Me.colSALERS_Code.Name = "colSALERS_Code"
        Me.colSALERS_Code.Width = 125
        '
        'coldtReminderDate
        '
        Me.coldtReminderDate.Caption = "ΗΜΕΡΟΜΗΝΙΑ ΕΙΔΟΠΟΙΗΣΗΣ"
        Me.coldtReminderDate.FieldName = "dtReminderDate"
        Me.coldtReminderDate.MinWidth = 33
        Me.coldtReminderDate.Name = "coldtReminderDate"
        Me.coldtReminderDate.Visible = True
        Me.coldtReminderDate.VisibleIndex = 3
        Me.coldtReminderDate.Width = 125
        '
        'colREM_VALUES_name
        '
        Me.colREM_VALUES_name.FieldName = "REM_VALUES_name"
        Me.colREM_VALUES_name.MinWidth = 33
        Me.colREM_VALUES_name.Name = "colREM_VALUES_name"
        Me.colREM_VALUES_name.Width = 125
        '
        'colremValueID
        '
        Me.colremValueID.FieldName = "remValueID"
        Me.colremValueID.MinWidth = 33
        Me.colremValueID.Name = "colremValueID"
        Me.colremValueID.Width = 125
        '
        'colReminder
        '
        Me.colReminder.FieldName = "Reminder"
        Me.colReminder.MinWidth = 33
        Me.colReminder.Name = "colReminder"
        Me.colReminder.Width = 125
        '
        'colS_CCT_M_Code
        '
        Me.colS_CCT_M_Code.FieldName = "S_CCT_M_Code"
        Me.colS_CCT_M_Code.MinWidth = 33
        Me.colS_CCT_M_Code.Name = "colS_CCT_M_Code"
        Me.colS_CCT_M_Code.Width = 125
        '
        'colS_CCT_M_Color
        '
        Me.colS_CCT_M_Color.Caption = "ΧΡΩΜΑ"
        Me.colS_CCT_M_Color.FieldName = "S_CCT_M_Color"
        Me.colS_CCT_M_Color.MinWidth = 33
        Me.colS_CCT_M_Color.Name = "colS_CCT_M_Color"
        Me.colS_CCT_M_Color.Width = 125
        '
        'colS_CCT_M_name
        '
        Me.colS_CCT_M_name.Caption = "ΠΩΛΗΤΗΣ"
        Me.colS_CCT_M_name.FieldName = "S_CCT_M_name"
        Me.colS_CCT_M_name.MinWidth = 33
        Me.colS_CCT_M_name.Name = "colS_CCT_M_name"
        Me.colS_CCT_M_name.Visible = True
        Me.colS_CCT_M_name.VisibleIndex = 1
        Me.colS_CCT_M_name.Width = 125
        '
        'coltmReminder
        '
        Me.coltmReminder.FieldName = "tmReminder"
        Me.coltmReminder.MinWidth = 33
        Me.coltmReminder.Name = "coltmReminder"
        Me.coltmReminder.Width = 125
        '
        'coldtReceiveDate
        '
        Me.coldtReceiveDate.FieldName = "dtReceiveDate"
        Me.coldtReceiveDate.MinWidth = 33
        Me.coldtReceiveDate.Name = "coldtReceiveDate"
        Me.coldtReceiveDate.Width = 125
        '
        'coldtDeliverDate
        '
        Me.coldtDeliverDate.FieldName = "dtDeliverDate"
        Me.coldtDeliverDate.MinWidth = 33
        Me.coldtDeliverDate.Name = "coldtDeliverDate"
        Me.coldtDeliverDate.Width = 125
        '
        'colCusSaler
        '
        Me.colCusSaler.FieldName = "CusSaler"
        Me.colCusSaler.MinWidth = 33
        Me.colCusSaler.Name = "colCusSaler"
        Me.colCusSaler.Width = 125
        '
        'colcreatedby_Realname
        '
        Me.colcreatedby_Realname.FieldName = "createdby_Realname"
        Me.colcreatedby_Realname.MinWidth = 33
        Me.colcreatedby_Realname.Name = "colcreatedby_Realname"
        Me.colcreatedby_Realname.Width = 125
        '
        'colphn
        '
        Me.colphn.Caption = "ΤΗΛΕΦΩΝΟ"
        Me.colphn.FieldName = "phn"
        Me.colphn.MinWidth = 33
        Me.colphn.Name = "colphn"
        Me.colphn.Visible = True
        Me.colphn.VisibleIndex = 4
        Me.colphn.Width = 125
        '
        'PopupMenuEmail
        '
        Me.PopupMenuEmail.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarEmailSYG), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEmailEIDOP), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEmailRECEIPTS), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSYG), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEIDOP), New DevExpress.XtraBars.LinkPersistInfo(Me.BarRECEIPTS)})
        Me.PopupMenuEmail.Manager = Me.BarManager1
        Me.PopupMenuEmail.Name = "PopupMenuEmail"
        '
        'BarEmailSYG
        '
        Me.BarEmailSYG.Caption = "Συγκεντρωτική"
        Me.BarEmailSYG.Id = 66
        Me.BarEmailSYG.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_aggregator_16
        Me.BarEmailSYG.Name = "BarEmailSYG"
        '
        'BarEmailEIDOP
        '
        Me.BarEmailEIDOP.Caption = "Ειδοποιήσεις"
        Me.BarEmailEIDOP.Id = 67
        Me.BarEmailEIDOP.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_documents_16
        Me.BarEmailEIDOP.Name = "BarEmailEIDOP"
        '
        'BarEmailRECEIPTS
        '
        Me.BarEmailRECEIPTS.Caption = "Αποδείξεις"
        Me.BarEmailRECEIPTS.Id = 68
        Me.BarEmailRECEIPTS.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_receipt_approved_16
        Me.BarEmailRECEIPTS.Name = "BarEmailRECEIPTS"
        '
        'frmScroller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1765, 1216)
        Me.Controls.Add(Me.PanelResults)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmScroller"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmScroller"
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryBarRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopMenuViews, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPopSaveAsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryBarViews, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuExport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_DEBITUSR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollectorsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_COL_METHOD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwCOLMETHODBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_ΒΑΝΚ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwBANKSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemBreadCrumbEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPopRenameView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMarqueeProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuRows, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuRowsDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelResults.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SQLMain As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents SSM As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents BarRecords As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryBarRecords As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents BarViews As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryBarViews As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemBreadCrumbEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents PopMenuViews As DevExpress.XtraBars.PopupMenu
    Friend WithEvents popDeleteView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents popRestoreView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryPopRenameView As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents popSaveAsView As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryPopSaveAsView As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents popSaveView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarViewsManage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarPrintPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenuExport As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarPDFExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarExportHTML As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarExportMHT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarExportXLSX As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarExportXLS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarExportDOCX As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarExportRTF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarExportTEXT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents XtraSaveFileDialog1 As DevExpress.XtraEditors.XtraSaveFileDialog
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarNewRec As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem2 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem3 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem4 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem5 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents popSaveAsDefault As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarCopyCell As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarCopyRow As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarCopyAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenuRows As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarCopyCell_D As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarCopyRow_D As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarCopyAll_D As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenuRowsDetail As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BBUpdateViewFromDB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarFilterWithCell As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarFilterWithoutCell As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarRemoveFilterWithCell As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarRemoveAllFilters As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBUpdateViewFileFromServer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar4 As DevExpress.XtraBars.Bar
    Friend WithEvents cboDebitUsr As DevExpress.XtraBars.BarEditItem
    Friend WithEvents Rep_DEBITUSR As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Priamos_NETDataSet As Priamos_NETDataSet
    Friend WithEvents cboColMethod As DevExpress.XtraBars.BarEditItem
    Friend WithEvents Rep_COL_METHOD As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BarEditItem2 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents VwCOLMETHODBindingSource As BindingSource
    Friend WithEvents Vw_COL_METHODTableAdapter As Priamos_NETDataSetTableAdapters.vw_COL_METHODTableAdapter
    Friend WithEvents cboBank As DevExpress.XtraBars.BarEditItem
    Friend WithEvents Rep_ΒΑΝΚ As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents VwBANKSBindingSource As BindingSource
    Friend WithEvents Vw_BANKSTableAdapter As Priamos_NETDataSetTableAdapters.vw_BANKSTableAdapter
    Friend WithEvents BBcolExtSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CollectorsBindingSource As BindingSource
    Friend WithEvents CollectorsTableAdapter As Priamos_NETDataSetTableAdapters.CollectorsTableAdapter
    Friend WithEvents BBcolExtCollector As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenuPrint As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarSYG As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEIDOP As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarRECEIPTS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEmail As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemMarqueeProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar
    Friend WithEvents BarPB As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents PanelResults As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFullname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmob As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colemail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcct_cmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSTATUS_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colallowschedule As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALERS_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcolor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colADR_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRealName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAREAS_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colstatusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colsch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcompleted As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtcompleted As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreatedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colsalersID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALERS_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtReminderDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colREM_VALUES_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colremValueID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReminder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colS_CCT_M_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colS_CCT_M_Color As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colS_CCT_M_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltmReminder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtReceiveDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtDeliverDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCusSaler As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreatedby_Realname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colphn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PopupMenuEmail As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarEmailSYG As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEmailEIDOP As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEmailRECEIPTS As DevExpress.XtraBars.BarButtonItem
End Class
