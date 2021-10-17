<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFilePreviwer
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.VwINDFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PriamosNETDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet = New PRIAMOS.NET.Priamos_NETDataSet()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colrepName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colindID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfiles = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfilename = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcomefrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colextension = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PdfViewer1 = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.PdfCommandBar1 = New DevExpress.XtraPdfViewer.Bars.PdfCommandBar()
        Me.PdfFileOpenBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFileOpenBarItem()
        Me.PdfFileSaveAsBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFileSaveAsBarItem()
        Me.PdfFilePrintBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem()
        Me.PdfFindTextBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFindTextBarItem()
        Me.PdfPreviousPageBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem()
        Me.PdfNextPageBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem()
        Me.PdfSetPageNumberBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetPageNumberBarItem()
        Me.RepositoryItemPageNumberEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPageNumberEdit()
        Me.PdfZoomOutBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem()
        Me.PdfZoomInBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem()
        Me.PdfExactZoomListBarSubItem1 = New DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem()
        Me.PdfZoom10CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom10CheckItem()
        Me.PdfZoom25CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom25CheckItem()
        Me.PdfZoom50CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom50CheckItem()
        Me.PdfZoom75CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom75CheckItem()
        Me.PdfZoom100CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom100CheckItem()
        Me.PdfZoom125CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom125CheckItem()
        Me.PdfZoom150CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom150CheckItem()
        Me.PdfZoom200CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom200CheckItem()
        Me.PdfZoom400CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom400CheckItem()
        Me.PdfZoom500CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom500CheckItem()
        Me.PdfSetActualSizeZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetActualSizeZoomModeCheckItem()
        Me.PdfSetPageLevelZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetPageLevelZoomModeCheckItem()
        Me.PdfSetFitWidthZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetFitWidthZoomModeCheckItem()
        Me.PdfSetFitVisibleZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetFitVisibleZoomModeCheckItem()
        Me.PdfExportFormDataBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfExportFormDataBarItem()
        Me.PdfImportFormDataBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfImportFormDataBarItem()
        Me.PdfCommentBar1 = New DevExpress.XtraPdfViewer.Bars.PdfCommentBar()
        Me.PdfTextHighlightBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfTextHighlightBarItem()
        Me.PdfTextStrikethroughBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfTextStrikethroughBarItem()
        Me.PdfTextUnderlineBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfTextUnderlineBarItem()
        Me.PdfStickyNoteBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfStickyNoteBarItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.Vw_IND_FTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_IND_FTableAdapter()
        Me.PdfBarController1 = New DevExpress.XtraPdfViewer.Bars.PdfBarController(Me.components)
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINDFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PriamosNETDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPageNumberEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PdfBarController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdMain
        '
        Me.grdMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdMain.DataSource = Me.VwINDFBindingSource
        Me.grdMain.Location = New System.Drawing.Point(8, 33)
        Me.grdMain.MainView = Me.GridView1
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(568, 734)
        Me.grdMain.TabIndex = 6
        Me.grdMain.UseEmbeddedNavigator = True
        Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'VwINDFBindingSource
        '
        Me.VwINDFBindingSource.DataMember = "vw_IND_F"
        Me.VwINDFBindingSource.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'PriamosNETDataSetBindingSource
        '
        Me.PriamosNETDataSetBindingSource.DataSource = Me.Priamos_NETDataSet
        Me.PriamosNETDataSetBindingSource.Position = 0
        '
        'Priamos_NETDataSet
        '
        Me.Priamos_NETDataSet.DataSetName = "Priamos_NETDataSet"
        Me.Priamos_NETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colrepName, Me.colID, Me.colindID, Me.colfiles, Me.colfilename, Me.colcomefrom, Me.colextension, Me.colcode})
        Me.GridView1.GridControl = Me.grdMain
        Me.GridView1.GroupCount = 1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colrepName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colrepName
        '
        Me.colrepName.Caption = "Έξοδο"
        Me.colrepName.FieldName = "repName"
        Me.colrepName.Name = "colrepName"
        Me.colrepName.Visible = True
        Me.colrepName.VisibleIndex = 0
        Me.colrepName.Width = 308
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        '
        'colindID
        '
        Me.colindID.FieldName = "indID"
        Me.colindID.Name = "colindID"
        '
        'colfiles
        '
        Me.colfiles.FieldName = "files"
        Me.colfiles.Name = "colfiles"
        '
        'colfilename
        '
        Me.colfilename.Caption = "Όνομα Αρχείου"
        Me.colfilename.FieldName = "filename"
        Me.colfilename.Name = "colfilename"
        Me.colfilename.Visible = True
        Me.colfilename.VisibleIndex = 0
        Me.colfilename.Width = 246
        '
        'colcomefrom
        '
        Me.colcomefrom.Caption = "Διαδρομή"
        Me.colcomefrom.FieldName = "comefrom"
        Me.colcomefrom.Name = "colcomefrom"
        Me.colcomefrom.Visible = True
        Me.colcomefrom.VisibleIndex = 1
        Me.colcomefrom.Width = 1189
        '
        'colextension
        '
        Me.colextension.FieldName = "extension"
        Me.colextension.Name = "colextension"
        '
        'colcode
        '
        Me.colcode.FieldName = "code"
        Me.colcode.Name = "colcode"
        '
        'PdfViewer1
        '
        Me.PdfViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PdfViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PdfViewer1.DetachStreamAfterLoadComplete = True
        Me.PdfViewer1.Location = New System.Drawing.Point(582, 33)
        Me.PdfViewer1.MenuManager = Me.BarManager1
        Me.PdfViewer1.Name = "PdfViewer1"
        Me.PdfViewer1.Size = New System.Drawing.Size(652, 734)
        Me.PdfViewer1.TabIndex = 0
        Me.PdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.PdfCommandBar1, Me.PdfCommentBar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.PdfFileOpenBarItem1, Me.PdfFileSaveAsBarItem1, Me.PdfFilePrintBarItem1, Me.PdfFindTextBarItem1, Me.PdfPreviousPageBarItem1, Me.PdfNextPageBarItem1, Me.PdfSetPageNumberBarItem1, Me.PdfZoomOutBarItem1, Me.PdfZoomInBarItem1, Me.PdfExactZoomListBarSubItem1, Me.PdfZoom10CheckItem1, Me.PdfZoom25CheckItem1, Me.PdfZoom50CheckItem1, Me.PdfZoom75CheckItem1, Me.PdfZoom100CheckItem1, Me.PdfZoom125CheckItem1, Me.PdfZoom150CheckItem1, Me.PdfZoom200CheckItem1, Me.PdfZoom400CheckItem1, Me.PdfZoom500CheckItem1, Me.PdfSetActualSizeZoomModeCheckItem1, Me.PdfSetPageLevelZoomModeCheckItem1, Me.PdfSetFitWidthZoomModeCheckItem1, Me.PdfSetFitVisibleZoomModeCheckItem1, Me.PdfTextHighlightBarItem1, Me.PdfTextStrikethroughBarItem1, Me.PdfTextUnderlineBarItem1, Me.PdfStickyNoteBarItem1, Me.PdfExportFormDataBarItem1, Me.PdfImportFormDataBarItem1})
        Me.BarManager1.MaxItemId = 30
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemPageNumberEdit1})
        '
        'PdfCommandBar1
        '
        Me.PdfCommandBar1.Control = Me.PdfViewer1
        Me.PdfCommandBar1.DockCol = 0
        Me.PdfCommandBar1.DockRow = 0
        Me.PdfCommandBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.PdfCommandBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PdfFileOpenBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfFileSaveAsBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfFilePrintBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfFindTextBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfPreviousPageBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfNextPageBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfSetPageNumberBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoomOutBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoomInBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfExactZoomListBarSubItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfExportFormDataBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfImportFormDataBarItem1)})
        '
        'PdfFileOpenBarItem1
        '
        Me.PdfFileOpenBarItem1.Id = 0
        Me.PdfFileOpenBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O))
        Me.PdfFileOpenBarItem1.Name = "PdfFileOpenBarItem1"
        '
        'PdfFileSaveAsBarItem1
        '
        Me.PdfFileSaveAsBarItem1.Id = 1
        Me.PdfFileSaveAsBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S))
        Me.PdfFileSaveAsBarItem1.Name = "PdfFileSaveAsBarItem1"
        '
        'PdfFilePrintBarItem1
        '
        Me.PdfFilePrintBarItem1.Id = 2
        Me.PdfFilePrintBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P))
        Me.PdfFilePrintBarItem1.Name = "PdfFilePrintBarItem1"
        '
        'PdfFindTextBarItem1
        '
        Me.PdfFindTextBarItem1.Id = 3
        Me.PdfFindTextBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F))
        Me.PdfFindTextBarItem1.Name = "PdfFindTextBarItem1"
        '
        'PdfPreviousPageBarItem1
        '
        Me.PdfPreviousPageBarItem1.Id = 4
        Me.PdfPreviousPageBarItem1.Name = "PdfPreviousPageBarItem1"
        '
        'PdfNextPageBarItem1
        '
        Me.PdfNextPageBarItem1.Id = 5
        Me.PdfNextPageBarItem1.Name = "PdfNextPageBarItem1"
        '
        'PdfSetPageNumberBarItem1
        '
        Me.PdfSetPageNumberBarItem1.Edit = Me.RepositoryItemPageNumberEdit1
        Me.PdfSetPageNumberBarItem1.EditValue = 0
        Me.PdfSetPageNumberBarItem1.Enabled = False
        Me.PdfSetPageNumberBarItem1.Id = 6
        Me.PdfSetPageNumberBarItem1.Name = "PdfSetPageNumberBarItem1"
        '
        'RepositoryItemPageNumberEdit1
        '
        Me.RepositoryItemPageNumberEdit1.AutoHeight = False
        Me.RepositoryItemPageNumberEdit1.Mask.EditMask = "########;"
        Me.RepositoryItemPageNumberEdit1.Name = "RepositoryItemPageNumberEdit1"
        Me.RepositoryItemPageNumberEdit1.Orientation = DevExpress.XtraEditors.PagerOrientation.Horizontal
        '
        'PdfZoomOutBarItem1
        '
        Me.PdfZoomOutBarItem1.Id = 7
        Me.PdfZoomOutBarItem1.Name = "PdfZoomOutBarItem1"
        '
        'PdfZoomInBarItem1
        '
        Me.PdfZoomInBarItem1.Id = 8
        Me.PdfZoomInBarItem1.Name = "PdfZoomInBarItem1"
        '
        'PdfExactZoomListBarSubItem1
        '
        Me.PdfExactZoomListBarSubItem1.Id = 23
        Me.PdfExactZoomListBarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom10CheckItem1, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom25CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom50CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom75CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom100CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom125CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom150CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom200CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom400CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfZoom500CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfSetActualSizeZoomModeCheckItem1, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfSetPageLevelZoomModeCheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfSetFitWidthZoomModeCheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfSetFitVisibleZoomModeCheckItem1)})
        Me.PdfExactZoomListBarSubItem1.Name = "PdfExactZoomListBarSubItem1"
        Me.PdfExactZoomListBarSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
        '
        'PdfZoom10CheckItem1
        '
        Me.PdfZoom10CheckItem1.Id = 9
        Me.PdfZoom10CheckItem1.Name = "PdfZoom10CheckItem1"
        '
        'PdfZoom25CheckItem1
        '
        Me.PdfZoom25CheckItem1.Id = 10
        Me.PdfZoom25CheckItem1.Name = "PdfZoom25CheckItem1"
        '
        'PdfZoom50CheckItem1
        '
        Me.PdfZoom50CheckItem1.Id = 11
        Me.PdfZoom50CheckItem1.Name = "PdfZoom50CheckItem1"
        '
        'PdfZoom75CheckItem1
        '
        Me.PdfZoom75CheckItem1.Id = 12
        Me.PdfZoom75CheckItem1.Name = "PdfZoom75CheckItem1"
        '
        'PdfZoom100CheckItem1
        '
        Me.PdfZoom100CheckItem1.Id = 13
        Me.PdfZoom100CheckItem1.Name = "PdfZoom100CheckItem1"
        '
        'PdfZoom125CheckItem1
        '
        Me.PdfZoom125CheckItem1.Id = 14
        Me.PdfZoom125CheckItem1.Name = "PdfZoom125CheckItem1"
        '
        'PdfZoom150CheckItem1
        '
        Me.PdfZoom150CheckItem1.Id = 15
        Me.PdfZoom150CheckItem1.Name = "PdfZoom150CheckItem1"
        '
        'PdfZoom200CheckItem1
        '
        Me.PdfZoom200CheckItem1.Id = 16
        Me.PdfZoom200CheckItem1.Name = "PdfZoom200CheckItem1"
        '
        'PdfZoom400CheckItem1
        '
        Me.PdfZoom400CheckItem1.Id = 17
        Me.PdfZoom400CheckItem1.Name = "PdfZoom400CheckItem1"
        '
        'PdfZoom500CheckItem1
        '
        Me.PdfZoom500CheckItem1.Id = 18
        Me.PdfZoom500CheckItem1.Name = "PdfZoom500CheckItem1"
        '
        'PdfSetActualSizeZoomModeCheckItem1
        '
        Me.PdfSetActualSizeZoomModeCheckItem1.Id = 19
        Me.PdfSetActualSizeZoomModeCheckItem1.Name = "PdfSetActualSizeZoomModeCheckItem1"
        '
        'PdfSetPageLevelZoomModeCheckItem1
        '
        Me.PdfSetPageLevelZoomModeCheckItem1.Id = 20
        Me.PdfSetPageLevelZoomModeCheckItem1.Name = "PdfSetPageLevelZoomModeCheckItem1"
        '
        'PdfSetFitWidthZoomModeCheckItem1
        '
        Me.PdfSetFitWidthZoomModeCheckItem1.Id = 21
        Me.PdfSetFitWidthZoomModeCheckItem1.Name = "PdfSetFitWidthZoomModeCheckItem1"
        '
        'PdfSetFitVisibleZoomModeCheckItem1
        '
        Me.PdfSetFitVisibleZoomModeCheckItem1.Id = 22
        Me.PdfSetFitVisibleZoomModeCheckItem1.Name = "PdfSetFitVisibleZoomModeCheckItem1"
        '
        'PdfExportFormDataBarItem1
        '
        Me.PdfExportFormDataBarItem1.Id = 28
        Me.PdfExportFormDataBarItem1.Name = "PdfExportFormDataBarItem1"
        '
        'PdfImportFormDataBarItem1
        '
        Me.PdfImportFormDataBarItem1.Id = 29
        Me.PdfImportFormDataBarItem1.Name = "PdfImportFormDataBarItem1"
        '
        'PdfCommentBar1
        '
        Me.PdfCommentBar1.Control = Me.PdfViewer1
        Me.PdfCommentBar1.DockCol = 1
        Me.PdfCommentBar1.DockRow = 0
        Me.PdfCommentBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.PdfCommentBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PdfTextHighlightBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfTextStrikethroughBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfTextUnderlineBarItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.PdfStickyNoteBarItem1)})
        '
        'PdfTextHighlightBarItem1
        '
        Me.PdfTextHighlightBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
        Me.PdfTextHighlightBarItem1.Id = 24
        Me.PdfTextHighlightBarItem1.Name = "PdfTextHighlightBarItem1"
        '
        'PdfTextStrikethroughBarItem1
        '
        Me.PdfTextStrikethroughBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
        Me.PdfTextStrikethroughBarItem1.Id = 25
        Me.PdfTextStrikethroughBarItem1.Name = "PdfTextStrikethroughBarItem1"
        '
        'PdfTextUnderlineBarItem1
        '
        Me.PdfTextUnderlineBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
        Me.PdfTextUnderlineBarItem1.Id = 26
        Me.PdfTextUnderlineBarItem1.Name = "PdfTextUnderlineBarItem1"
        '
        'PdfStickyNoteBarItem1
        '
        Me.PdfStickyNoteBarItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
        Me.PdfStickyNoteBarItem1.Id = 27
        Me.PdfStickyNoteBarItem1.Name = "PdfStickyNoteBarItem1"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1240, 27)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 768)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1240, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 27)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 741)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1240, 27)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 741)
        '
        'Vw_IND_FTableAdapter
        '
        Me.Vw_IND_FTableAdapter.ClearBeforeFill = True
        '
        'PdfBarController1
        '
        Me.PdfBarController1.BarItems.Add(Me.PdfFileOpenBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfFileSaveAsBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfFilePrintBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfFindTextBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfPreviousPageBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfNextPageBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfSetPageNumberBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoomOutBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoomInBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom10CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom25CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom50CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom75CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom100CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom125CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom150CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom200CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom400CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfZoom500CheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfSetActualSizeZoomModeCheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfSetPageLevelZoomModeCheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfSetFitWidthZoomModeCheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfSetFitVisibleZoomModeCheckItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfExactZoomListBarSubItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfTextHighlightBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfTextStrikethroughBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfTextUnderlineBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfStickyNoteBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfExportFormDataBarItem1)
        Me.PdfBarController1.BarItems.Add(Me.PdfImportFormDataBarItem1)
        Me.PdfBarController1.Control = Me.PdfViewer1
        '
        'frmFilePreviwer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 768)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.PdfViewer1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmFilePreviwer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmFilePreviwer"
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINDFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PriamosNETDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPageNumberEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PdfBarController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PdfViewer1 As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents PriamosNETDataSetBindingSource As BindingSource
    Friend WithEvents Priamos_NETDataSet As Priamos_NETDataSet
    Friend WithEvents VwINDFBindingSource As BindingSource
    Friend WithEvents Vw_IND_FTableAdapter As Priamos_NETDataSetTableAdapters.vw_IND_FTableAdapter
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colrepName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colindID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfiles As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfilename As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcomefrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colextension As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents PdfCommandBar1 As DevExpress.XtraPdfViewer.Bars.PdfCommandBar
    Friend WithEvents PdfFileOpenBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFileOpenBarItem
    Friend WithEvents PdfFileSaveAsBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFileSaveAsBarItem
    Friend WithEvents PdfFilePrintBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem
    Friend WithEvents PdfFindTextBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFindTextBarItem
    Friend WithEvents PdfPreviousPageBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem
    Friend WithEvents PdfNextPageBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem
    Friend WithEvents PdfSetPageNumberBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetPageNumberBarItem
    Friend WithEvents RepositoryItemPageNumberEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPageNumberEdit
    Friend WithEvents PdfZoomOutBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem
    Friend WithEvents PdfZoomInBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem
    Friend WithEvents PdfExactZoomListBarSubItem1 As DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem
    Friend WithEvents PdfZoom10CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom10CheckItem
    Friend WithEvents PdfZoom25CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom25CheckItem
    Friend WithEvents PdfZoom50CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom50CheckItem
    Friend WithEvents PdfZoom75CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom75CheckItem
    Friend WithEvents PdfZoom100CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom100CheckItem
    Friend WithEvents PdfZoom125CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom125CheckItem
    Friend WithEvents PdfZoom150CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom150CheckItem
    Friend WithEvents PdfZoom200CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom200CheckItem
    Friend WithEvents PdfZoom400CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom400CheckItem
    Friend WithEvents PdfZoom500CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom500CheckItem
    Friend WithEvents PdfSetActualSizeZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetActualSizeZoomModeCheckItem
    Friend WithEvents PdfSetPageLevelZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetPageLevelZoomModeCheckItem
    Friend WithEvents PdfSetFitWidthZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetFitWidthZoomModeCheckItem
    Friend WithEvents PdfSetFitVisibleZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetFitVisibleZoomModeCheckItem
    Friend WithEvents PdfExportFormDataBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfExportFormDataBarItem
    Friend WithEvents PdfImportFormDataBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfImportFormDataBarItem
    Friend WithEvents PdfCommentBar1 As DevExpress.XtraPdfViewer.Bars.PdfCommentBar
    Friend WithEvents PdfTextHighlightBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfTextHighlightBarItem
    Friend WithEvents PdfTextStrikethroughBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfTextStrikethroughBarItem
    Friend WithEvents PdfTextUnderlineBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfTextUnderlineBarItem
    Friend WithEvents PdfStickyNoteBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfStickyNoteBarItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents PdfBarController1 As DevExpress.XtraPdfViewer.Bars.PdfBarController
End Class
