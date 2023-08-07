<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBatchCreateIND
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdDel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCreateIND = New DevExpress.XtraEditors.SimpleButton()
        Me.grdIND = New DevExpress.XtraGrid.GridControl()
        Me.VwINDBATCHBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NET_DataSet_INH = New PRIAMOS.NET.Priamos_NET_DataSet_INH()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colBdgNam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colrepName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colowner_tenant = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcalcCatID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepCalcCat = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwCALCCATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colinhID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepINH = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwINHNotCalculatedBYBDGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colamt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcompleteDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbdgID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdSaveINH = New DevExpress.XtraEditors.SimpleButton()
        Me.cboRepname = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwTTLBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboOwnerTenant = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboCalcCat = New DevExpress.XtraEditors.LookUpEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.VwINHNotCalculatedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Vw_TTLTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_INHTableAdapters.vw_TTLTableAdapter()
        Me.Vw_CALC_CATTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_INHTableAdapters.vw_CALC_CATTableAdapter()
        Me.Vw_IND_BATCHTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_INHTableAdapters.vw_IND_BATCHTableAdapter()
        Me.Vw_INHNotCalculatedTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_INHTableAdapters.vw_INHNotCalculatedTableAdapter()
        Me.Vw_INHNotCalculatedBYBDGTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_INHTableAdapters.vw_INHNotCalculatedBYBDGTableAdapter()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl5 = New DevExpress.XtraBars.BarDockControl()
        Me.BBOpenInh = New DevExpress.XtraBars.BarButtonItem()
        Me.BBOpenBdg = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenuRows = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.images = New DevExpress.Utils.SvgImageCollection(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.grdIND, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINDBATCHBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NET_DataSet_INH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepCalcCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwCALCCATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepINH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINHNotCalculatedBYBDGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRepname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwTTLBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOwnerTenant.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCalcCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINHNotCalculatedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuRows, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.images, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdRefresh)
        Me.LayoutControl1.Controls.Add(Me.cmdDel)
        Me.LayoutControl1.Controls.Add(Me.cmdCreateIND)
        Me.LayoutControl1.Controls.Add(Me.grdIND)
        Me.LayoutControl1.Controls.Add(Me.cmdSaveINH)
        Me.LayoutControl1.Controls.Add(Me.cboRepname)
        Me.LayoutControl1.Controls.Add(Me.cboOwnerTenant)
        Me.LayoutControl1.Controls.Add(Me.cboCalcCat)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1863, 1246)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_refresh_16
        Me.cmdRefresh.Location = New System.Drawing.Point(12, 159)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdRefresh.Size = New System.Drawing.Size(26, 39)
        Me.cmdRefresh.StyleController = Me.LayoutControl1
        Me.cmdRefresh.TabIndex = 59
        '
        'cmdDel
        '
        Me.cmdDel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDel.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Remove_16x16
        Me.cmdDel.Location = New System.Drawing.Point(12, 116)
        Me.cmdDel.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdDel.Size = New System.Drawing.Size(26, 39)
        Me.cmdDel.StyleController = Me.LayoutControl1
        Me.cmdDel.TabIndex = 58
        '
        'cmdCreateIND
        '
        Me.cmdCreateIND.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdCreateIND.Location = New System.Drawing.Point(1606, 1195)
        Me.cmdCreateIND.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdCreateIND.Name = "cmdCreateIND"
        Me.cmdCreateIND.Size = New System.Drawing.Size(245, 39)
        Me.cmdCreateIND.StyleController = Me.LayoutControl1
        Me.cmdCreateIND.TabIndex = 57
        Me.cmdCreateIND.Text = "Δημιουργία Εξόδων"
        '
        'grdIND
        '
        Me.grdIND.DataSource = Me.VwINDBATCHBindingSource
        Me.grdIND.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.grdIND.Location = New System.Drawing.Point(42, 159)
        Me.grdIND.MainView = Me.GridView5
        Me.grdIND.Margin = New System.Windows.Forms.Padding(5)
        Me.grdIND.Name = "grdIND"
        Me.grdIND.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepCalcCat, Me.RepINH})
        Me.grdIND.Size = New System.Drawing.Size(1809, 1032)
        Me.grdIND.TabIndex = 56
        Me.grdIND.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'VwINDBATCHBindingSource
        '
        Me.VwINDBATCHBindingSource.DataMember = "vw_IND_BATCH"
        Me.VwINDBATCHBindingSource.DataSource = Me.Priamos_NET_DataSet_INH
        '
        'Priamos_NET_DataSet_INH
        '
        Me.Priamos_NET_DataSet_INH.DataSetName = "Priamos_NET_DataSet_INH"
        Me.Priamos_NET_DataSet_INH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView5
        '
        Me.GridView5.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colBdgNam, Me.colrepName, Me.colowner_tenant, Me.colcalcCatID, Me.colinhID, Me.colamt, Me.colcompleteDate, Me.colbdgID})
        Me.GridView5.FixedLineWidth = 3
        Me.GridView5.GridControl = Me.grdIND
        Me.GridView5.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "name", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "owner_tenant", Nothing, "")})
        Me.GridView5.LevelIndent = 0
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView5.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView5.OptionsPrint.PrintPreview = True
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsSelection.MultiSelect = True
        Me.GridView5.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView5.OptionsView.ShowFooter = True
        Me.GridView5.OptionsView.ShowGroupedColumns = True
        Me.GridView5.PreviewIndent = 0
        '
        'colBdgNam
        '
        Me.colBdgNam.Caption = "Πολυκατοικία"
        Me.colBdgNam.FieldName = "BdgNam"
        Me.colBdgNam.MinWidth = 35
        Me.colBdgNam.Name = "colBdgNam"
        Me.colBdgNam.OptionsColumn.AllowEdit = False
        Me.colBdgNam.OptionsColumn.ReadOnly = True
        Me.colBdgNam.Visible = True
        Me.colBdgNam.VisibleIndex = 0
        Me.colBdgNam.Width = 132
        '
        'colrepName
        '
        Me.colrepName.Caption = "Λεκτικό Εκτύπωσης"
        Me.colrepName.FieldName = "repName"
        Me.colrepName.MinWidth = 35
        Me.colrepName.Name = "colrepName"
        Me.colrepName.Visible = True
        Me.colrepName.VisibleIndex = 1
        Me.colrepName.Width = 132
        '
        'colowner_tenant
        '
        Me.colowner_tenant.Caption = "Ένοικος/Ιδιοκτήτης"
        Me.colowner_tenant.FieldName = "owner_tenant"
        Me.colowner_tenant.MinWidth = 35
        Me.colowner_tenant.Name = "colowner_tenant"
        Me.colowner_tenant.Visible = True
        Me.colowner_tenant.VisibleIndex = 2
        Me.colowner_tenant.Width = 132
        '
        'colcalcCatID
        '
        Me.colcalcCatID.Caption = "Κατηγορία Χιλιοστών"
        Me.colcalcCatID.ColumnEdit = Me.RepCalcCat
        Me.colcalcCatID.FieldName = "calcCatID"
        Me.colcalcCatID.MinWidth = 35
        Me.colcalcCatID.Name = "colcalcCatID"
        Me.colcalcCatID.Visible = True
        Me.colcalcCatID.VisibleIndex = 3
        Me.colcalcCatID.Width = 132
        '
        'RepCalcCat
        '
        Me.RepCalcCat.AutoHeight = False
        Me.RepCalcCat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepCalcCat.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Κατηγορία", 62, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepCalcCat.DataSource = Me.VwCALCCATBindingSource
        Me.RepCalcCat.DisplayMember = "name"
        Me.RepCalcCat.Name = "RepCalcCat"
        Me.RepCalcCat.NullText = ""
        Me.RepCalcCat.ValueMember = "ID"
        '
        'VwCALCCATBindingSource
        '
        Me.VwCALCCATBindingSource.DataMember = "vw_CALC_CAT"
        Me.VwCALCCATBindingSource.DataSource = Me.Priamos_NET_DataSet_INH
        '
        'colinhID
        '
        Me.colinhID.Caption = "Παραστατικό"
        Me.colinhID.ColumnEdit = Me.RepINH
        Me.colinhID.FieldName = "inhID"
        Me.colinhID.MinWidth = 35
        Me.colinhID.Name = "colinhID"
        Me.colinhID.Visible = True
        Me.colinhID.VisibleIndex = 4
        Me.colinhID.Width = 132
        '
        'RepINH
        '
        Me.RepINH.AutoHeight = False
        Me.RepINH.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepINH.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("completeDate", "Παραστατικό", 136, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepINH.DataSource = Me.VwINHNotCalculatedBYBDGBindingSource
        Me.RepINH.DisplayMember = "completeDate"
        Me.RepINH.Name = "RepINH"
        Me.RepINH.NullText = ""
        Me.RepINH.ValueMember = "ID"
        '
        'VwINHNotCalculatedBYBDGBindingSource
        '
        Me.VwINHNotCalculatedBYBDGBindingSource.DataMember = "vw_INHNotCalculatedBYBDG"
        Me.VwINHNotCalculatedBYBDGBindingSource.DataSource = Me.Priamos_NET_DataSet_INH
        '
        'colamt
        '
        Me.colamt.Caption = "Ποσό"
        Me.colamt.DisplayFormat.FormatString = "c2"
        Me.colamt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colamt.FieldName = "amt"
        Me.colamt.MinWidth = 35
        Me.colamt.Name = "colamt"
        Me.colamt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amt", "SUM={0:c2}")})
        Me.colamt.Visible = True
        Me.colamt.VisibleIndex = 5
        Me.colamt.Width = 132
        '
        'colcompleteDate
        '
        Me.colcompleteDate.FieldName = "completeDate"
        Me.colcompleteDate.MinWidth = 35
        Me.colcompleteDate.Name = "colcompleteDate"
        Me.colcompleteDate.Width = 132
        '
        'colbdgID
        '
        Me.colbdgID.FieldName = "bdgID"
        Me.colbdgID.MinWidth = 35
        Me.colbdgID.Name = "colbdgID"
        Me.colbdgID.Width = 131
        '
        'cmdSaveINH
        '
        Me.cmdSaveINH.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSaveINH.Location = New System.Drawing.Point(1705, 116)
        Me.cmdSaveINH.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSaveINH.Name = "cmdSaveINH"
        Me.cmdSaveINH.Size = New System.Drawing.Size(146, 39)
        Me.cmdSaveINH.StyleController = Me.LayoutControl1
        Me.cmdSaveINH.TabIndex = 55
        Me.cmdSaveINH.Text = "Καταχώρηση"
        '
        'cboRepname
        '
        Me.cboRepname.Location = New System.Drawing.Point(221, 61)
        Me.cboRepname.Margin = New System.Windows.Forms.Padding(5)
        Me.cboRepname.Name = "cboRepname"
        Me.cboRepname.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboRepname.Properties.AllowMouseWheel = False
        Me.cboRepname.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboRepname.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 30, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Λεκτικό", 55, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboRepname.Properties.DataSource = Me.VwTTLBindingSource
        Me.cboRepname.Properties.DisplayMember = "name"
        Me.cboRepname.Properties.NullText = ""
        Me.cboRepname.Properties.PopupSizeable = False
        Me.cboRepname.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboRepname.Properties.ValueMember = "name"
        Me.cboRepname.Size = New System.Drawing.Size(620, 38)
        Me.cboRepname.StyleController = Me.LayoutControl1
        Me.cboRepname.TabIndex = 53
        Me.cboRepname.Tag = "repname,0,1,2"
        '
        'VwTTLBindingSource
        '
        Me.VwTTLBindingSource.DataMember = "vw_TTL"
        Me.VwTTLBindingSource.DataSource = Me.Priamos_NET_DataSet_INH
        '
        'cboOwnerTenant
        '
        Me.cboOwnerTenant.Location = New System.Drawing.Point(1610, 61)
        Me.cboOwnerTenant.Margin = New System.Windows.Forms.Padding(5)
        Me.cboOwnerTenant.Name = "cboOwnerTenant"
        Me.cboOwnerTenant.Properties.AllowMouseWheel = False
        Me.cboOwnerTenant.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboOwnerTenant.Properties.Items.AddRange(New Object() {"Ιδιοκτήτης", "Ένοικος"})
        Me.cboOwnerTenant.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboOwnerTenant.Size = New System.Drawing.Size(228, 38)
        Me.cboOwnerTenant.StyleController = Me.LayoutControl1
        Me.cboOwnerTenant.TabIndex = 52
        Me.cboOwnerTenant.Tag = "owner_tenant,0,1,2"
        '
        'cboCalcCat
        '
        Me.cboCalcCat.Location = New System.Drawing.Point(1041, 61)
        Me.cboCalcCat.Margin = New System.Windows.Forms.Padding(5)
        Me.cboCalcCat.Name = "cboCalcCat"
        Me.cboCalcCat.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCalcCat.Properties.AllowMouseWheel = False
        Me.cboCalcCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboCalcCat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Κατηγορία Υπολογισμού", 62, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboCalcCat.Properties.DataSource = Me.VwCALCCATBindingSource
        Me.cboCalcCat.Properties.DisplayMember = "name"
        Me.cboCalcCat.Properties.NullText = ""
        Me.cboCalcCat.Properties.PopupSizeable = False
        Me.cboCalcCat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboCalcCat.Properties.ValueMember = "ID"
        Me.cboCalcCat.Size = New System.Drawing.Size(369, 38)
        Me.cboCalcCat.StyleController = Me.LayoutControl1
        Me.cboCalcCat.TabIndex = 53
        Me.cboCalcCat.Tag = "repname,0,1,2"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlItem4, Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1863, 1246)
        Me.Root.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AppearanceGroup.BorderColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.LayoutControlGroup1.AppearanceGroup.Options.UseBorderColor = True
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1843, 104)
        Me.LayoutControlGroup1.Text = "Επιλογή Εξόδου"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboOwnerTenant
        Me.LayoutControlItem1.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem1.Location = New System.Drawing.Point(1389, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(428, 42)
        Me.LayoutControlItem1.Tag = "1"
        Me.LayoutControlItem1.Text = "Ένοικος/Ιδιοκτήτης"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(184, 23)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboRepname
        Me.LayoutControlItem2.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(820, 42)
        Me.LayoutControlItem2.Tag = "1"
        Me.LayoutControlItem2.Text = "Λεκτικό Εκτύπωσης"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(184, 23)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboCalcCat
        Me.LayoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem5.CustomizationFormText = "Κατηγορία Υπολογισμού"
        Me.LayoutControlItem5.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem5.Location = New System.Drawing.Point(820, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(569, 42)
        Me.LayoutControlItem5.Tag = "1"
        Me.LayoutControlItem5.Text = "Κατηγορία Χιλιοστών"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(184, 23)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdSaveINH
        Me.LayoutControlItem4.Location = New System.Drawing.Point(1693, 104)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(150, 43)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(30, 104)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1663, 43)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.grdIND
        Me.LayoutControlItem3.Location = New System.Drawing.Point(30, 147)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1813, 1036)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdCreateIND
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1594, 1183)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(249, 43)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(30, 1183)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1564, 43)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdDel
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(30, 43)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cmdRefresh
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 147)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(30, 1079)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'VwINHNotCalculatedBindingSource
        '
        Me.VwINHNotCalculatedBindingSource.DataMember = "vw_INHNotCalculated"
        Me.VwINHNotCalculatedBindingSource.DataSource = Me.Priamos_NET_DataSet_INH
        '
        'Vw_TTLTableAdapter
        '
        Me.Vw_TTLTableAdapter.ClearBeforeFill = True
        '
        'Vw_CALC_CATTableAdapter
        '
        Me.Vw_CALC_CATTableAdapter.ClearBeforeFill = True
        '
        'Vw_IND_BATCHTableAdapter
        '
        Me.Vw_IND_BATCHTableAdapter.ClearBeforeFill = True
        '
        'Vw_INHNotCalculatedTableAdapter
        '
        Me.Vw_INHNotCalculatedTableAdapter.ClearBeforeFill = True
        '
        'Vw_INHNotCalculatedBYBDGTableAdapter
        '
        Me.Vw_INHNotCalculatedBYBDGTableAdapter.ClearBeforeFill = True
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.BarDockControl2)
        Me.BarManager1.DockControls.Add(Me.BarDockControl3)
        Me.BarManager1.DockControls.Add(Me.BarDockControl4)
        Me.BarManager1.DockControls.Add(Me.BarDockControl5)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBOpenInh, Me.BBOpenBdg})
        Me.BarManager1.MaxItemId = 5
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl2.Manager = Me.BarManager1
        Me.BarDockControl2.Margin = New System.Windows.Forms.Padding(5)
        Me.BarDockControl2.Size = New System.Drawing.Size(1863, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 1246)
        Me.BarDockControl3.Manager = Me.BarManager1
        Me.BarDockControl3.Margin = New System.Windows.Forms.Padding(5)
        Me.BarDockControl3.Size = New System.Drawing.Size(1863, 0)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl4.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl4.Manager = Me.BarManager1
        Me.BarDockControl4.Margin = New System.Windows.Forms.Padding(5)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 1246)
        '
        'BarDockControl5
        '
        Me.BarDockControl5.CausesValidation = False
        Me.BarDockControl5.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl5.Location = New System.Drawing.Point(1863, 0)
        Me.BarDockControl5.Manager = Me.BarManager1
        Me.BarDockControl5.Margin = New System.Windows.Forms.Padding(5)
        Me.BarDockControl5.Size = New System.Drawing.Size(0, 1246)
        '
        'BBOpenInh
        '
        Me.BBOpenInh.Caption = "Άνοιγμα Παραστατικού"
        Me.BBOpenInh.Id = 0
        Me.BBOpenInh.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_documents_16
        Me.BBOpenInh.Name = "BBOpenInh"
        '
        'BBOpenBdg
        '
        Me.BBOpenBdg.Caption = "Άνοιγμα Πολυκατοικίας"
        Me.BBOpenBdg.Id = 1
        Me.BBOpenBdg.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_building_16
        Me.BBOpenBdg.Name = "BBOpenBdg"
        '
        'PopupMenuRows
        '
        Me.PopupMenuRows.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBOpenInh), New DevExpress.XtraBars.LinkPersistInfo(Me.BBOpenBdg)})
        Me.PopupMenuRows.Manager = Me.BarManager1
        Me.PopupMenuRows.Name = "PopupMenuRows"
        '
        'images
        '
        Me.images.Add("new", "image://svgimages/actions/new.svg")
        Me.images.Add("open", "image://svgimages/actions/open.svg")
        Me.images.Add("documentpdf", "image://svgimages/pdf viewer/documentpdf.svg")
        Me.images.Add("exporttoxlsx", "image://svgimages/export/exporttoxlsx.svg")
        Me.images.Add("underlineword", "image://svgimages/outlook inspired/underlineword.svg")
        '
        'frmBatchCreateIND
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1863, 1246)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl5)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Name = "frmBatchCreateIND"
        Me.Text = "frmBachCreateIND"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.grdIND, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINDBATCHBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NET_DataSet_INH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepCalcCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwCALCCATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepINH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINHNotCalculatedBYBDGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRepname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwTTLBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOwnerTenant.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCalcCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINHNotCalculatedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuRows, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.images, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboOwnerTenant As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboRepname As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdSaveINH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboCalcCat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grdIND As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepCalcCat As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdCreateIND As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents Priamos_NET_DataSet_INH As Priamos_NET_DataSet_INH
    Friend WithEvents VwTTLBindingSource As BindingSource
    Friend WithEvents Vw_TTLTableAdapter As Priamos_NET_DataSet_INHTableAdapters.vw_TTLTableAdapter
    Friend WithEvents VwCALCCATBindingSource As BindingSource
    Friend WithEvents Vw_CALC_CATTableAdapter As Priamos_NET_DataSet_INHTableAdapters.vw_CALC_CATTableAdapter
    Friend WithEvents VwINDBATCHBindingSource As BindingSource
    Friend WithEvents Vw_IND_BATCHTableAdapter As Priamos_NET_DataSet_INHTableAdapters.vw_IND_BATCHTableAdapter
    Friend WithEvents colBdgNam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colrepName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colowner_tenant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcalcCatID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colinhID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colamt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepINH As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents VwINHNotCalculatedBindingSource As BindingSource
    Friend WithEvents Vw_INHNotCalculatedTableAdapter As Priamos_NET_DataSet_INHTableAdapters.vw_INHNotCalculatedTableAdapter
    Friend WithEvents VwINHNotCalculatedBYBDGBindingSource As BindingSource
    Friend WithEvents Vw_INHNotCalculatedBYBDGTableAdapter As Priamos_NET_DataSet_INHTableAdapters.vw_INHNotCalculatedBYBDGTableAdapter
    Friend WithEvents colcompleteDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl5 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BBOpenInh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBOpenBdg As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenuRows As DevExpress.XtraBars.PopupMenu
    Private WithEvents images As DevExpress.Utils.SvgImageCollection
    Friend WithEvents colbdgID As DevExpress.XtraGrid.Columns.GridColumn
End Class
