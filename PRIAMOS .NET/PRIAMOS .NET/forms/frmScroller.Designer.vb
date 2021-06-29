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
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarNewRec = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.BarRefresh = New DevExpress.XtraBars.BarButtonItem()
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
        Me.SQLMain = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.SSM = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.PRIAMOS.NET.WaitForm), False, False)
        Me.XtraSaveFileDialog1 = New DevExpress.XtraEditors.XtraSaveFileDialog(Me.components)
        Me.PopupMenuRows = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.PopupMenuRowsDetail = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBarRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopMenuViews, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPopSaveAsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBarViews, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuExport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemBreadCrumbEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPopRenameView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuRows, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuRowsDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView2
        '
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
        GridLevelNode1.LevelTemplate = Me.GridView2
        GridLevelNode1.RelationName = "Level1"
        Me.grdMain.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdMain.Location = New System.Drawing.Point(27, 43)
        Me.grdMain.MainView = Me.GridView1
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(1008, 585)
        Me.grdMain.TabIndex = 5
        Me.grdMain.UseEmbeddedNavigator = True
        Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView2})
        '
        'GridView1
        '
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
        Me.GridView1.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView1.OptionsPrint.PrintPreview = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar3, Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarRecords, Me.BarViews, Me.popDeleteView, Me.popRestoreView, Me.popSaveAsView, Me.popSaveView, Me.BarViewsManage, Me.BarPrintPreview, Me.BarButtonItem1, Me.BarPDFExport, Me.BarExportHTML, Me.BarExportMHT, Me.BarExportXLSX, Me.BarExportXLS, Me.BarExportDOCX, Me.BarExportRTF, Me.BarExportTEXT, Me.BarNewRec, Me.BarDelete, Me.BarEdit, Me.BarRefresh, Me.BarStaticItem1, Me.BarStaticItem2, Me.BarStaticItem3, Me.BarStaticItem4, Me.BarStaticItem5, Me.popSaveAsDefault, Me.BarCopyCell, Me.BarCopyRow, Me.BarCopyAll, Me.BarCopyCell_D, Me.BarCopyRow_D, Me.BarCopyAll_D, Me.BBUpdateViewFromDB, Me.BarFilterWithCell, Me.BarFilterWithoutCell, Me.BarRemoveFilterWithCell, Me.BarRemoveAllFilters})
        Me.BarManager1.MainMenu = Me.Bar1
        Me.BarManager1.MaxItemId = 53
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryBarRecords, Me.RepositoryBarViews, Me.RepositoryItemButtonEdit1, Me.RepositoryItemBreadCrumbEdit1, Me.RepositoryItemButtonEdit2, Me.RepositoryPopRenameView, Me.RepositoryPopSaveAsView})
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
        Me.PopMenuViews.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.popSaveView), New DevExpress.XtraBars.LinkPersistInfo(Me.popSaveAsView), New DevExpress.XtraBars.LinkPersistInfo(Me.popSaveAsDefault), New DevExpress.XtraBars.LinkPersistInfo(Me.popDeleteView), New DevExpress.XtraBars.LinkPersistInfo(Me.popRestoreView), New DevExpress.XtraBars.LinkPersistInfo(Me.BBUpdateViewFromDB)})
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
        Me.BBUpdateViewFromDB.Name = "BBUpdateViewFromDB"
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
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.BarStaticItem4)})
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
        'Bar2
        '
        Me.Bar2.BarName = "Custom 4"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Left
        Me.Bar2.FloatLocation = New System.Drawing.Point(49, 225)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarNewRec), New DevExpress.XtraBars.LinkPersistInfo(Me.BarDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.BarRefresh)})
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
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1035, 43)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 628)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1035, 29)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 43)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(27, 585)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1035, 43)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 585)
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
        'frmScroller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 657)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmScroller"
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
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemBreadCrumbEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPopRenameView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuRows, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuRowsDetail, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
