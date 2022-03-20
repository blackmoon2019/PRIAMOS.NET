<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankCollectionInsert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankCollectionInsert))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.grdAPT = New DevExpress.XtraGrid.GridControl()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbdgID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colaptID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colinhID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcolHID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colttl1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreditusrID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebitusrID3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbankID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colColMethodID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreatedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colColMethod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBdgNam1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAptNam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcompleteDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedRealName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUsrCreditName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUsrDebittName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtDebit2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtCredit2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcredit1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebit1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbal1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltenant1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cboBDG = New DevExpress.XtraEditors.LookUpEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.grdAPT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.grdAPT)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.cboBDG)
        Me.LayoutControl1.Location = New System.Drawing.Point(12, 11)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1742, 1085)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'grdAPT
        '
        Me.grdAPT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdAPT.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.grdAPT.Location = New System.Drawing.Point(12, 82)
        Me.grdAPT.MainView = Me.GridView5
        Me.grdAPT.Margin = New System.Windows.Forms.Padding(5)
        Me.grdAPT.Name = "grdAPT"
        Me.grdAPT.Size = New System.Drawing.Size(1718, 948)
        Me.grdAPT.TabIndex = 24
        Me.grdAPT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colcode, Me.colbdgID, Me.colaptID, Me.colinhID, Me.colcolHID, Me.colttl1, Me.colcreditusrID, Me.coldebitusrID3, Me.colbankID2, Me.colColMethodID2, Me.colmodifiedBy, Me.colmodifiedOn, Me.colcreatedOn, Me.colColMethod, Me.colBankName, Me.colBdgNam1, Me.colAptNam, Me.colcompleteDate, Me.colmodifiedRealName, Me.colUsrCreditName, Me.colUsrDebittName, Me.coldtDebit2, Me.coldtCredit2, Me.colcredit1, Me.coldebit1, Me.colbal1, Me.coltenant1})
        Me.GridView5.DetailHeight = 619
        Me.GridView5.GridControl = Me.grdAPT
        Me.GridView5.LevelIndent = 0
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsBehavior.Editable = False
        Me.GridView5.OptionsBehavior.ReadOnly = True
        Me.GridView5.OptionsLayout.StoreAllOptions = True
        Me.GridView5.OptionsLayout.StoreAppearance = True
        Me.GridView5.OptionsLayout.StoreFormatRules = True
        Me.GridView5.OptionsMenu.EnableGroupRowMenu = True
        Me.GridView5.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView5.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView5.OptionsMenu.ShowFooterItem = True
        Me.GridView5.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView5.OptionsPrint.PrintPreview = True
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ColumnAutoWidth = False
        Me.GridView5.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView5.OptionsView.ShowFooter = True
        Me.GridView5.PreviewIndent = 0
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.MinWidth = 33
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        Me.colID.Width = 125
        '
        'colcode
        '
        Me.colcode.FieldName = "code"
        Me.colcode.MinWidth = 33
        Me.colcode.Name = "colcode"
        Me.colcode.Visible = True
        Me.colcode.VisibleIndex = 1
        Me.colcode.Width = 125
        '
        'colbdgID
        '
        Me.colbdgID.FieldName = "bdgID"
        Me.colbdgID.MinWidth = 33
        Me.colbdgID.Name = "colbdgID"
        Me.colbdgID.Visible = True
        Me.colbdgID.VisibleIndex = 2
        Me.colbdgID.Width = 125
        '
        'colaptID
        '
        Me.colaptID.FieldName = "aptID"
        Me.colaptID.MinWidth = 33
        Me.colaptID.Name = "colaptID"
        Me.colaptID.Visible = True
        Me.colaptID.VisibleIndex = 3
        Me.colaptID.Width = 125
        '
        'colinhID
        '
        Me.colinhID.FieldName = "inhID"
        Me.colinhID.MinWidth = 33
        Me.colinhID.Name = "colinhID"
        Me.colinhID.Visible = True
        Me.colinhID.VisibleIndex = 4
        Me.colinhID.Width = 125
        '
        'colcolHID
        '
        Me.colcolHID.FieldName = "colHID"
        Me.colcolHID.MinWidth = 33
        Me.colcolHID.Name = "colcolHID"
        Me.colcolHID.Visible = True
        Me.colcolHID.VisibleIndex = 5
        Me.colcolHID.Width = 125
        '
        'colttl1
        '
        Me.colttl1.FieldName = "ttl"
        Me.colttl1.MinWidth = 33
        Me.colttl1.Name = "colttl1"
        Me.colttl1.Visible = True
        Me.colttl1.VisibleIndex = 6
        Me.colttl1.Width = 125
        '
        'colcreditusrID
        '
        Me.colcreditusrID.FieldName = "creditusrID"
        Me.colcreditusrID.MinWidth = 33
        Me.colcreditusrID.Name = "colcreditusrID"
        Me.colcreditusrID.Visible = True
        Me.colcreditusrID.VisibleIndex = 7
        Me.colcreditusrID.Width = 125
        '
        'coldebitusrID3
        '
        Me.coldebitusrID3.FieldName = "debitusrID"
        Me.coldebitusrID3.MinWidth = 33
        Me.coldebitusrID3.Name = "coldebitusrID3"
        Me.coldebitusrID3.Visible = True
        Me.coldebitusrID3.VisibleIndex = 8
        Me.coldebitusrID3.Width = 125
        '
        'colbankID2
        '
        Me.colbankID2.FieldName = "bankID"
        Me.colbankID2.MinWidth = 33
        Me.colbankID2.Name = "colbankID2"
        Me.colbankID2.Visible = True
        Me.colbankID2.VisibleIndex = 9
        Me.colbankID2.Width = 125
        '
        'colColMethodID2
        '
        Me.colColMethodID2.FieldName = "ColMethodID"
        Me.colColMethodID2.MinWidth = 33
        Me.colColMethodID2.Name = "colColMethodID2"
        Me.colColMethodID2.Visible = True
        Me.colColMethodID2.VisibleIndex = 10
        Me.colColMethodID2.Width = 125
        '
        'colmodifiedBy
        '
        Me.colmodifiedBy.FieldName = "modifiedBy"
        Me.colmodifiedBy.MinWidth = 33
        Me.colmodifiedBy.Name = "colmodifiedBy"
        Me.colmodifiedBy.Visible = True
        Me.colmodifiedBy.VisibleIndex = 11
        Me.colmodifiedBy.Width = 125
        '
        'colmodifiedOn
        '
        Me.colmodifiedOn.FieldName = "modifiedOn"
        Me.colmodifiedOn.MinWidth = 33
        Me.colmodifiedOn.Name = "colmodifiedOn"
        Me.colmodifiedOn.Visible = True
        Me.colmodifiedOn.VisibleIndex = 12
        Me.colmodifiedOn.Width = 125
        '
        'colcreatedOn
        '
        Me.colcreatedOn.FieldName = "createdOn"
        Me.colcreatedOn.MinWidth = 33
        Me.colcreatedOn.Name = "colcreatedOn"
        Me.colcreatedOn.Visible = True
        Me.colcreatedOn.VisibleIndex = 13
        Me.colcreatedOn.Width = 125
        '
        'colColMethod
        '
        Me.colColMethod.FieldName = "ColMethod"
        Me.colColMethod.MinWidth = 33
        Me.colColMethod.Name = "colColMethod"
        Me.colColMethod.Visible = True
        Me.colColMethod.VisibleIndex = 14
        Me.colColMethod.Width = 125
        '
        'colBankName
        '
        Me.colBankName.FieldName = "BankName"
        Me.colBankName.MinWidth = 33
        Me.colBankName.Name = "colBankName"
        Me.colBankName.Visible = True
        Me.colBankName.VisibleIndex = 15
        Me.colBankName.Width = 125
        '
        'colBdgNam1
        '
        Me.colBdgNam1.FieldName = "BdgNam"
        Me.colBdgNam1.MinWidth = 33
        Me.colBdgNam1.Name = "colBdgNam1"
        Me.colBdgNam1.Visible = True
        Me.colBdgNam1.VisibleIndex = 16
        Me.colBdgNam1.Width = 125
        '
        'colAptNam
        '
        Me.colAptNam.FieldName = "AptNam"
        Me.colAptNam.MinWidth = 33
        Me.colAptNam.Name = "colAptNam"
        Me.colAptNam.Visible = True
        Me.colAptNam.VisibleIndex = 17
        Me.colAptNam.Width = 125
        '
        'colcompleteDate
        '
        Me.colcompleteDate.FieldName = "completeDate"
        Me.colcompleteDate.MinWidth = 33
        Me.colcompleteDate.Name = "colcompleteDate"
        Me.colcompleteDate.Visible = True
        Me.colcompleteDate.VisibleIndex = 18
        Me.colcompleteDate.Width = 125
        '
        'colmodifiedRealName
        '
        Me.colmodifiedRealName.FieldName = "modifiedRealName"
        Me.colmodifiedRealName.MinWidth = 33
        Me.colmodifiedRealName.Name = "colmodifiedRealName"
        Me.colmodifiedRealName.Visible = True
        Me.colmodifiedRealName.VisibleIndex = 19
        Me.colmodifiedRealName.Width = 125
        '
        'colUsrCreditName
        '
        Me.colUsrCreditName.FieldName = "UsrCreditName"
        Me.colUsrCreditName.MinWidth = 33
        Me.colUsrCreditName.Name = "colUsrCreditName"
        Me.colUsrCreditName.Visible = True
        Me.colUsrCreditName.VisibleIndex = 20
        Me.colUsrCreditName.Width = 125
        '
        'colUsrDebittName
        '
        Me.colUsrDebittName.FieldName = "UsrDebittName"
        Me.colUsrDebittName.MinWidth = 33
        Me.colUsrDebittName.Name = "colUsrDebittName"
        Me.colUsrDebittName.Visible = True
        Me.colUsrDebittName.VisibleIndex = 21
        Me.colUsrDebittName.Width = 125
        '
        'coldtDebit2
        '
        Me.coldtDebit2.FieldName = "dtDebit"
        Me.coldtDebit2.MinWidth = 33
        Me.coldtDebit2.Name = "coldtDebit2"
        Me.coldtDebit2.Visible = True
        Me.coldtDebit2.VisibleIndex = 22
        Me.coldtDebit2.Width = 125
        '
        'coldtCredit2
        '
        Me.coldtCredit2.FieldName = "dtCredit"
        Me.coldtCredit2.MinWidth = 33
        Me.coldtCredit2.Name = "coldtCredit2"
        Me.coldtCredit2.Visible = True
        Me.coldtCredit2.VisibleIndex = 23
        Me.coldtCredit2.Width = 125
        '
        'colcredit1
        '
        Me.colcredit1.FieldName = "credit"
        Me.colcredit1.MinWidth = 33
        Me.colcredit1.Name = "colcredit1"
        Me.colcredit1.Visible = True
        Me.colcredit1.VisibleIndex = 24
        Me.colcredit1.Width = 125
        '
        'coldebit1
        '
        Me.coldebit1.FieldName = "debit"
        Me.coldebit1.MinWidth = 33
        Me.coldebit1.Name = "coldebit1"
        Me.coldebit1.Visible = True
        Me.coldebit1.VisibleIndex = 25
        Me.coldebit1.Width = 125
        '
        'colbal1
        '
        Me.colbal1.FieldName = "bal"
        Me.colbal1.MinWidth = 33
        Me.colbal1.Name = "colbal1"
        Me.colbal1.Visible = True
        Me.colbal1.VisibleIndex = 26
        Me.colbal1.Width = 125
        '
        'coltenant1
        '
        Me.coltenant1.FieldName = "tenant"
        Me.coltenant1.MinWidth = 33
        Me.coltenant1.Name = "coltenant1"
        Me.coltenant1.Visible = True
        Me.coltenant1.VisibleIndex = 27
        Me.coltenant1.Width = 125
        '
        'SimpleButton1
        '
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Location = New System.Drawing.Point(1356, 1034)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(206, 39)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 7
        Me.SimpleButton1.Text = "Εισαγωγή"
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = CType(resources.GetObject("cmdExit.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(1566, 1034)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(164, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Έξοδος"
        '
        'cboBDG
        '
        Me.cboBDG.Location = New System.Drawing.Point(12, 40)
        Me.cboBDG.Margin = New System.Windows.Forms.Padding(5)
        Me.cboBDG.Name = "cboBDG"
        Me.cboBDG.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboBDG.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboBDG.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 68, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BdgNam", "Πολυκατοικίες", 85, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("debit", "debit", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("credit", "credit", 60, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bal", "bal", 38, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("debitusrID", "debitusr ID", 103, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtDebit", "dt Debit", 78, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtCredit", "dt Credit", 85, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 33, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nam", "nam", 48, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboBDG.Properties.DisplayMember = "BdgNam"
        Me.cboBDG.Properties.NullText = ""
        Me.cboBDG.Properties.PopupSizeable = False
        Me.cboBDG.Properties.ValueMember = "bdgID"
        Me.cboBDG.Size = New System.Drawing.Size(1718, 38)
        Me.cboBDG.StyleController = Me.LayoutControl1
        Me.cboBDG.TabIndex = 0
        Me.cboBDG.Tag = ""
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem11, Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1742, 1085)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cboBDG
        Me.LayoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem11.CustomizationFormText = "Κατηγορία"
        Me.LayoutControlItem11.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem11.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(1722, 70)
        Me.LayoutControlItem11.Text = "Τράπεζα"
        Me.LayoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(81, 23)
        Me.LayoutControlItem11.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdExit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1554, 1022)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(168, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 1022)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1344, 43)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(1344, 1022)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(210, 43)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.grdAPT
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 70)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1722, 952)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'frmBankCollectionInsert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1766, 1105)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmBankCollectionInsert"
        Me.Text = "frmBankCollectionInsert"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.grdAPT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboBDG As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grdAPT As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbdgID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colaptID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colinhID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcolHID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colttl1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreditusrID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebitusrID3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbankID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colColMethodID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreatedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colColMethod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBdgNam1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAptNam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcompleteDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedRealName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUsrCreditName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUsrDebittName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtDebit2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtCredit2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcredit1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebit1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbal1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltenant1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
