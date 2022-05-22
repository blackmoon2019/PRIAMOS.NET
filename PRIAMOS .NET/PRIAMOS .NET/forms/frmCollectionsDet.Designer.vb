<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCollectionsDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCollectionsDet))
        Me.VwCOLDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet2 = New PRIAMOS.NET.Priamos_NETDataSet2()
        Me.Vw_COL_DTableAdapter = New PRIAMOS.NET.Priamos_NETDataSet2TableAdapters.vw_COL_DTableAdapter()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdCol_D_Del = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colold_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbdgNam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colttl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcompleteDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCredit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreatedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreditUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebitUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcolID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbdgID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colaptID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colinhID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebitusrID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltenant = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.colagreed = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.VwCOLDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VwCOLDBindingSource
        '
        Me.VwCOLDBindingSource.DataMember = "vw_COL_D"
        Me.VwCOLDBindingSource.DataSource = Me.Priamos_NETDataSet2
        '
        'Priamos_NETDataSet2
        '
        Me.Priamos_NETDataSet2.DataSetName = "Priamos_NETDataSet2"
        Me.Priamos_NETDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Vw_COL_DTableAdapter
        '
        Me.Vw_COL_DTableAdapter.ClearBeforeFill = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.cmdCol_D_Del)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Location = New System.Drawing.Point(9, 1)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1808, 777)
        Me.LayoutControl1.TabIndex = 16
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdCol_D_Del
        '
        Me.cmdCol_D_Del.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Remove_16x16
        Me.cmdCol_D_Del.Location = New System.Drawing.Point(12, 48)
        Me.cmdCol_D_Del.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdCol_D_Del.Name = "cmdCol_D_Del"
        Me.cmdCol_D_Del.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdCol_D_Del.Size = New System.Drawing.Size(26, 39)
        Me.cmdCol_D_Del.StyleController = Me.LayoutControl1
        Me.cmdCol_D_Del.TabIndex = 25
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = CType(resources.GetObject("cmdExit.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(1599, 726)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(197, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 17
        Me.cmdExit.Text = "Έξοδος"
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.VwCOLDBindingSource
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.GridControl1.Location = New System.Drawing.Point(42, 12)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1754, 710)
        Me.GridControl1.TabIndex = 16
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colold_code, Me.colbdgNam, Me.colttl, Me.colcompleteDate, Me.coldebit, Me.colCredit, Me.colBal, Me.colmodifiedOn, Me.colcreatedOn, Me.colmodifiedBy, Me.colcreditUser, Me.coldebitUser, Me.colID, Me.colcode, Me.colcolID, Me.colbdgID, Me.colaptID, Me.colinhID, Me.coldebitusrID, Me.coltenant, Me.colagreed})
        Me.GridView1.DetailHeight = 619
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsLayout.StoreAllOptions = True
        Me.GridView1.OptionsLayout.StoreFormatRules = True
        Me.GridView1.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView1.OptionsMenu.ShowFooterItem = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colold_code
        '
        Me.colold_code.FieldName = "old_code"
        Me.colold_code.MinWidth = 35
        Me.colold_code.Name = "colold_code"
        Me.colold_code.Width = 131
        '
        'colbdgNam
        '
        Me.colbdgNam.Caption = "ΠΟΛΥΚΑΤΟΙΚΙΑ"
        Me.colbdgNam.FieldName = "bdgNam"
        Me.colbdgNam.MinWidth = 35
        Me.colbdgNam.Name = "colbdgNam"
        Me.colbdgNam.OptionsColumn.AllowEdit = False
        Me.colbdgNam.Visible = True
        Me.colbdgNam.VisibleIndex = 0
        Me.colbdgNam.Width = 343
        '
        'colttl
        '
        Me.colttl.Caption = "ΔΙΑΜΕΡΙΣΜΑ"
        Me.colttl.FieldName = "ttl"
        Me.colttl.MinWidth = 35
        Me.colttl.Name = "colttl"
        Me.colttl.OptionsColumn.AllowEdit = False
        Me.colttl.Visible = True
        Me.colttl.VisibleIndex = 1
        Me.colttl.Width = 343
        '
        'colcompleteDate
        '
        Me.colcompleteDate.Caption = "ΠΑΡΑΣΤΑΤΙΚΟ"
        Me.colcompleteDate.FieldName = "completeDate"
        Me.colcompleteDate.MinWidth = 35
        Me.colcompleteDate.Name = "colcompleteDate"
        Me.colcompleteDate.OptionsColumn.AllowEdit = False
        Me.colcompleteDate.Visible = True
        Me.colcompleteDate.VisibleIndex = 2
        Me.colcompleteDate.Width = 343
        '
        'coldebit
        '
        Me.coldebit.Caption = "ΧΡΕΩΣΗ"
        Me.coldebit.DisplayFormat.FormatString = "c2"
        Me.coldebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.coldebit.FieldName = "debit"
        Me.coldebit.MinWidth = 35
        Me.coldebit.Name = "coldebit"
        Me.coldebit.OptionsColumn.AllowEdit = False
        Me.coldebit.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "Σύνολο={0:c2}")})
        Me.coldebit.Visible = True
        Me.coldebit.VisibleIndex = 4
        Me.coldebit.Width = 372
        '
        'colCredit
        '
        Me.colCredit.Caption = "ΠΙΣΤΩΣΗ"
        Me.colCredit.DisplayFormat.FormatString = "c2"
        Me.colCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCredit.FieldName = "Credit"
        Me.colCredit.MinWidth = 35
        Me.colCredit.Name = "colCredit"
        Me.colCredit.OptionsColumn.AllowEdit = False
        Me.colCredit.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "Σύνολο={0:c2}")})
        Me.colCredit.Visible = True
        Me.colCredit.VisibleIndex = 5
        Me.colCredit.Width = 372
        '
        'colBal
        '
        Me.colBal.Caption = "ΥΠΟΛΟΙΠΟ"
        Me.colBal.DisplayFormat.FormatString = "c2"
        Me.colBal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colBal.FieldName = "Bal"
        Me.colBal.MinWidth = 35
        Me.colBal.Name = "colBal"
        Me.colBal.OptionsColumn.AllowEdit = False
        Me.colBal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bal", "Σύνολο={0:c2}")})
        Me.colBal.Visible = True
        Me.colBal.VisibleIndex = 6
        Me.colBal.Width = 372
        '
        'colmodifiedOn
        '
        Me.colmodifiedOn.FieldName = "modifiedOn"
        Me.colmodifiedOn.MinWidth = 35
        Me.colmodifiedOn.Name = "colmodifiedOn"
        Me.colmodifiedOn.Width = 131
        '
        'colcreatedOn
        '
        Me.colcreatedOn.Caption = "ΗΜΕΡ/ΝΙΑ ΚΑΤΑΧΩΡΗΣΗΣ"
        Me.colcreatedOn.DisplayFormat.FormatString = "M/d/yyyy HH:mm:ss"
        Me.colcreatedOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colcreatedOn.FieldName = "createdOn"
        Me.colcreatedOn.MinWidth = 35
        Me.colcreatedOn.Name = "colcreatedOn"
        Me.colcreatedOn.OptionsColumn.AllowEdit = False
        Me.colcreatedOn.Visible = True
        Me.colcreatedOn.VisibleIndex = 7
        Me.colcreatedOn.Width = 372
        '
        'colmodifiedBy
        '
        Me.colmodifiedBy.FieldName = "modifiedBy"
        Me.colmodifiedBy.MinWidth = 35
        Me.colmodifiedBy.Name = "colmodifiedBy"
        Me.colmodifiedBy.Width = 131
        '
        'colcreditUser
        '
        Me.colcreditUser.Caption = "ΧΡΗΣΤΗΣ ΠΙΣΤΩΣΗΣ"
        Me.colcreditUser.FieldName = "creditUser"
        Me.colcreditUser.MinWidth = 35
        Me.colcreditUser.Name = "colcreditUser"
        Me.colcreditUser.OptionsColumn.AllowEdit = False
        Me.colcreditUser.Visible = True
        Me.colcreditUser.VisibleIndex = 8
        Me.colcreditUser.Width = 372
        '
        'coldebitUser
        '
        Me.coldebitUser.Caption = "ΧΡΗΣΤΗΣ ΧΡΕΩΣΗΣ"
        Me.coldebitUser.FieldName = "debitUser"
        Me.coldebitUser.MinWidth = 35
        Me.coldebitUser.Name = "coldebitUser"
        Me.coldebitUser.OptionsColumn.AllowEdit = False
        Me.coldebitUser.Visible = True
        Me.coldebitUser.VisibleIndex = 9
        Me.coldebitUser.Width = 384
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.MinWidth = 35
        Me.colID.Name = "colID"
        Me.colID.Width = 131
        '
        'colcode
        '
        Me.colcode.FieldName = "code"
        Me.colcode.MinWidth = 35
        Me.colcode.Name = "colcode"
        Me.colcode.Width = 131
        '
        'colcolID
        '
        Me.colcolID.FieldName = "colID"
        Me.colcolID.MinWidth = 35
        Me.colcolID.Name = "colcolID"
        Me.colcolID.Width = 131
        '
        'colbdgID
        '
        Me.colbdgID.FieldName = "bdgID"
        Me.colbdgID.MinWidth = 35
        Me.colbdgID.Name = "colbdgID"
        Me.colbdgID.Width = 131
        '
        'colaptID
        '
        Me.colaptID.FieldName = "aptID"
        Me.colaptID.MinWidth = 35
        Me.colaptID.Name = "colaptID"
        Me.colaptID.Width = 131
        '
        'colinhID
        '
        Me.colinhID.FieldName = "inhID"
        Me.colinhID.MinWidth = 35
        Me.colinhID.Name = "colinhID"
        Me.colinhID.Width = 131
        '
        'coldebitusrID
        '
        Me.coldebitusrID.FieldName = "debitusrID"
        Me.coldebitusrID.MinWidth = 35
        Me.coldebitusrID.Name = "coldebitusrID"
        Me.coldebitusrID.Width = 131
        '
        'coltenant
        '
        Me.coltenant.Caption = "ΕΝΟΙΚΟΣ"
        Me.coltenant.FieldName = "tenant"
        Me.coltenant.MinWidth = 35
        Me.coltenant.Name = "coltenant"
        Me.coltenant.Visible = True
        Me.coltenant.VisibleIndex = 3
        Me.coltenant.Width = 165
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.EmptySpaceItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1808, 777)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmdExit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(1587, 714)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(201, 43)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(30, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1758, 714)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 714)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1587, 43)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 79)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(30, 635)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdCol_D_Del
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 36)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(30, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(30, 36)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'colagreed
        '
        Me.colagreed.Caption = "ΣΥΜΦΩΝΙΑ ΠΙΣΤΩΣΗΣ"
        Me.colagreed.FieldName = "agreed"
        Me.colagreed.MinWidth = 35
        Me.colagreed.Name = "colagreed"
        Me.colagreed.Visible = True
        Me.colagreed.VisibleIndex = 10
        Me.colagreed.Width = 131
        '
        'frmCollectionsDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(1827, 791)
        Me.Controls.Add(Me.LayoutControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCollectionsDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ανάλυση Είσπραξης"
        CType(Me.VwCOLDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VwCOLDBindingSource As BindingSource
    Friend WithEvents Priamos_NETDataSet2 As Priamos_NETDataSet2
    Friend WithEvents Vw_COL_DTableAdapter As Priamos_NETDataSet2TableAdapters.vw_COL_DTableAdapter
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colold_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbdgNam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colttl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcompleteDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCredit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreatedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreditUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebitUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcolID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbdgID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colaptID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colinhID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebitusrID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cmdCol_D_Del As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents coltenant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colagreed As DevExpress.XtraGrid.Columns.GridColumn
End Class
