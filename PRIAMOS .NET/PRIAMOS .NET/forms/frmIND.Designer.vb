<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIND
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIND))
        Me.LayoutControl9 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.VwINDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet = New PRIAMOS.NET.Priamos_NETDataSet()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colinhID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colrepName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colamt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreatedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colowner_tenant = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSelectedFiles = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colpaid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colETOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcompleteDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.SimpleButton39 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup31 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem246 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Vw_INDTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_INDTableAdapter()
        Me.XtraSaveFileDialog1 = New DevExpress.XtraEditors.XtraSaveFileDialog(Me.components)
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl5 = New DevExpress.XtraBars.BarDockControl()
        Me.BBOpenInh = New DevExpress.XtraBars.BarButtonItem()
        Me.BBOpenBdg = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenuRows = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.colbdgID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbManageID = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LayoutControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl9.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem246, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuRows, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl9
        '
        Me.LayoutControl9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl9.Controls.Add(Me.GridControl1)
        Me.LayoutControl9.Controls.Add(Me.SimpleButton39)
        Me.LayoutControl9.Location = New System.Drawing.Point(-7, -9)
        Me.LayoutControl9.Name = "LayoutControl9"
        Me.LayoutControl9.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(704, 399, 650, 400)
        Me.LayoutControl9.Root = Me.LayoutControlGroup31
        Me.LayoutControl9.Size = New System.Drawing.Size(1345, 796)
        Me.LayoutControl9.TabIndex = 3
        Me.LayoutControl9.Text = "LayoutControl1"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.DataSource = Me.VwINDBindingSource
        Me.GridControl1.Location = New System.Drawing.Point(38, 12)
        Me.GridControl1.MainView = Me.GridView5
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit3})
        Me.GridControl1.Size = New System.Drawing.Size(1295, 772)
        Me.GridControl1.TabIndex = 60
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'VwINDBindingSource
        '
        Me.VwINDBindingSource.DataMember = "vw_IND"
        Me.VwINDBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'Priamos_NETDataSet
        '
        Me.Priamos_NETDataSet.DataSetName = "Priamos_NETDataSet"
        Me.Priamos_NETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView5
        '
        Me.GridView5.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colcode, Me.colinhID, Me.colrepName, Me.colamt, Me.colmodifiedBy, Me.colmodifiedOn, Me.colcreatedOn, Me.colnam, Me.colfDate, Me.coltDate, Me.colname, Me.colowner_tenant, Me.colSelectedFiles, Me.colpaid, Me.colETOS, Me.colcompleteDate, Me.colbdgID, Me.colbManageID})
        Me.GridView5.GridControl = Me.GridControl1
        Me.GridView5.GroupCount = 1
        Me.GridView5.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amt", Me.colamt, " Σύνολο {0:n2}€"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "name", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "owner_tenant", Nothing, "")})
        Me.GridView5.LevelIndent = 0
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView5.OptionsBehavior.Editable = False
        Me.GridView5.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView5.OptionsPrint.PrintPreview = True
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView5.OptionsView.ShowFooter = True
        Me.GridView5.OptionsView.ShowGroupedColumns = True
        Me.GridView5.PreviewIndent = 0
        Me.GridView5.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colowner_tenant, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        '
        'colcode
        '
        Me.colcode.FieldName = "code"
        Me.colcode.Name = "colcode"
        '
        'colinhID
        '
        Me.colinhID.FieldName = "inhID"
        Me.colinhID.Name = "colinhID"
        '
        'colrepName
        '
        Me.colrepName.Caption = "Λεκτικό Εκτύπωσης"
        Me.colrepName.FieldName = "repName"
        Me.colrepName.Name = "colrepName"
        Me.colrepName.Visible = True
        Me.colrepName.VisibleIndex = 1
        Me.colrepName.Width = 181
        '
        'colamt
        '
        Me.colamt.Caption = "Ποσό"
        Me.colamt.FieldName = "amt"
        Me.colamt.Name = "colamt"
        Me.colamt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amt", "SUM={0:0.##}")})
        Me.colamt.Visible = True
        Me.colamt.VisibleIndex = 0
        Me.colamt.Width = 93
        '
        'colmodifiedBy
        '
        Me.colmodifiedBy.FieldName = "modifiedBy"
        Me.colmodifiedBy.Name = "colmodifiedBy"
        '
        'colmodifiedOn
        '
        Me.colmodifiedOn.FieldName = "modifiedOn"
        Me.colmodifiedOn.Name = "colmodifiedOn"
        '
        'colcreatedOn
        '
        Me.colcreatedOn.FieldName = "createdOn"
        Me.colcreatedOn.Name = "colcreatedOn"
        '
        'colnam
        '
        Me.colnam.Caption = "Πολυκατοικία"
        Me.colnam.FieldName = "nam"
        Me.colnam.Name = "colnam"
        Me.colnam.Visible = True
        Me.colnam.VisibleIndex = 9
        '
        'colfDate
        '
        Me.colfDate.Caption = "Από Ημερ/νία"
        Me.colfDate.FieldName = "fDate"
        Me.colfDate.Name = "colfDate"
        Me.colfDate.Visible = True
        Me.colfDate.VisibleIndex = 6
        '
        'coltDate
        '
        Me.coltDate.Caption = "Έως  Ημερ/νία"
        Me.coltDate.FieldName = "tDate"
        Me.coltDate.Name = "coltDate"
        Me.coltDate.Visible = True
        Me.coltDate.VisibleIndex = 7
        '
        'colname
        '
        Me.colname.Caption = "Κατηγορία Υπολογισμού"
        Me.colname.FieldName = "name"
        Me.colname.Name = "colname"
        Me.colname.Visible = True
        Me.colname.VisibleIndex = 5
        Me.colname.Width = 139
        '
        'colowner_tenant
        '
        Me.colowner_tenant.Caption = "Ένοικος/Ιδιοκτήτης"
        Me.colowner_tenant.FieldName = "owner_tenant"
        Me.colowner_tenant.Name = "colowner_tenant"
        Me.colowner_tenant.Visible = True
        Me.colowner_tenant.VisibleIndex = 3
        '
        'colSelectedFiles
        '
        Me.colSelectedFiles.FieldName = "SelectedFiles"
        Me.colSelectedFiles.Name = "colSelectedFiles"
        '
        'colpaid
        '
        Me.colpaid.Caption = "Πληρώθηκε"
        Me.colpaid.FieldName = "paid"
        Me.colpaid.Name = "colpaid"
        Me.colpaid.Visible = True
        Me.colpaid.VisibleIndex = 2
        '
        'colETOS
        '
        Me.colETOS.Caption = "Έτος"
        Me.colETOS.FieldName = "ETOS"
        Me.colETOS.Name = "colETOS"
        Me.colETOS.Visible = True
        Me.colETOS.VisibleIndex = 4
        '
        'colcompleteDate
        '
        Me.colcompleteDate.Caption = "Περίοδος"
        Me.colcompleteDate.FieldName = "completeDate"
        Me.colcompleteDate.Name = "colcompleteDate"
        Me.colcompleteDate.Visible = True
        Me.colcompleteDate.VisibleIndex = 8
        '
        'RepositoryItemLookUpEdit3
        '
        Me.RepositoryItemLookUpEdit3.AutoHeight = False
        Me.RepositoryItemLookUpEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
        Me.RepositoryItemLookUpEdit3.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 18, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Κατηγορία", 33, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemLookUpEdit3.DisplayMember = "name"
        Me.RepositoryItemLookUpEdit3.KeyMember = "name"
        Me.RepositoryItemLookUpEdit3.Name = "RepositoryItemLookUpEdit3"
        Me.RepositoryItemLookUpEdit3.ValueMember = "ID"
        '
        'SimpleButton39
        '
        Me.SimpleButton39.ImageOptions.Image = CType(resources.GetObject("SimpleButton39.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton39.Location = New System.Drawing.Point(12, 12)
        Me.SimpleButton39.Name = "SimpleButton39"
        Me.SimpleButton39.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.SimpleButton39.Size = New System.Drawing.Size(22, 22)
        Me.SimpleButton39.StyleController = Me.LayoutControl9
        Me.SimpleButton39.TabIndex = 59
        '
        'LayoutControlGroup31
        '
        Me.LayoutControlGroup31.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup31.GroupBordersVisible = False
        Me.LayoutControlGroup31.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem246})
        Me.LayoutControlGroup31.Name = "Root"
        Me.LayoutControlGroup31.Size = New System.Drawing.Size(1345, 796)
        Me.LayoutControlGroup31.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(26, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1299, 776)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem246
        '
        Me.LayoutControlItem246.Control = Me.SimpleButton39
        Me.LayoutControlItem246.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem246.Name = "LayoutControlItem107"
        Me.LayoutControlItem246.Size = New System.Drawing.Size(26, 776)
        Me.LayoutControlItem246.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem246.TextVisible = False
        '
        'Vw_INDTableAdapter
        '
        Me.Vw_INDTableAdapter.ClearBeforeFill = True
        '
        'XtraSaveFileDialog1
        '
        Me.XtraSaveFileDialog1.FileName = "XtraSaveFileDialog1"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.BarDockControl2)
        Me.BarManager1.DockControls.Add(Me.BarDockControl3)
        Me.BarManager1.DockControls.Add(Me.BarDockControl4)
        Me.BarManager1.DockControls.Add(Me.BarDockControl5)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBOpenInh, Me.BBOpenBdg})
        Me.BarManager1.MaxItemId = 2
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl2.Manager = Me.BarManager1
        Me.BarDockControl2.Size = New System.Drawing.Size(1329, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 779)
        Me.BarDockControl3.Manager = Me.BarManager1
        Me.BarDockControl3.Size = New System.Drawing.Size(1329, 0)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl4.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl4.Manager = Me.BarManager1
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 779)
        '
        'BarDockControl5
        '
        Me.BarDockControl5.CausesValidation = False
        Me.BarDockControl5.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl5.Location = New System.Drawing.Point(1329, 0)
        Me.BarDockControl5.Manager = Me.BarManager1
        Me.BarDockControl5.Size = New System.Drawing.Size(0, 779)
        '
        'BBOpenInh
        '
        Me.BBOpenInh.Caption = "Άνοιγμα Παραστατικού"
        Me.BBOpenInh.Id = 0
        Me.BBOpenInh.Name = "BBOpenInh"
        '
        'BBOpenBdg
        '
        Me.BBOpenBdg.Caption = "Άνοιγμα Πολυκατοικίας"
        Me.BBOpenBdg.Id = 1
        Me.BBOpenBdg.Name = "BBOpenBdg"
        '
        'PopupMenuRows
        '
        Me.PopupMenuRows.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBOpenInh), New DevExpress.XtraBars.LinkPersistInfo(Me.BBOpenBdg)})
        Me.PopupMenuRows.Manager = Me.BarManager1
        Me.PopupMenuRows.Name = "PopupMenuRows"
        '
        'colbdgID
        '
        Me.colbdgID.FieldName = "bdgID"
        Me.colbdgID.Name = "colbdgID"
        '
        'colbManageID
        '
        Me.colbManageID.FieldName = "bManageID"
        Me.colbManageID.Name = "colbManageID"
        '
        'frmIND
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1329, 779)
        Me.Controls.Add(Me.LayoutControl9)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl5)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Name = "frmIND"
        Me.Text = "frmIND"
        CType(Me.LayoutControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl9.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem246, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuRows, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl9 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton39 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup31 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem246 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwINDBindingSource As BindingSource
    Friend WithEvents Priamos_NETDataSet As Priamos_NETDataSet
    Friend WithEvents Vw_INDTableAdapter As Priamos_NETDataSetTableAdapters.vw_INDTableAdapter
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colinhID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colrepName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colamt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreatedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colowner_tenant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSelectedFiles As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colpaid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colETOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcompleteDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraSaveFileDialog1 As DevExpress.XtraEditors.XtraSaveFileDialog
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl5 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BBOpenInh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBOpenBdg As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenuRows As DevExpress.XtraBars.PopupMenu
    Friend WithEvents colbdgID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbManageID As DevExpress.XtraGrid.Columns.GridColumn
End Class
