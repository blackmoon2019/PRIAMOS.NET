<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeysManager
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.grdKeysM = New DevExpress.XtraGrid.GridControl()
        Me.VwBDGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet = New PRIAMOS.NET.Priamos_NETDataSet()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colold_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAdrID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colaam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coliam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldts = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreatedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colADR_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colADR_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colADR_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAreaID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCouID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colArea_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colArea_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colArea_CouID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colArea_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOU_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOU_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOU_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colprd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHTypeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBTypeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHTYPE_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBTYPE_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFTYPE_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFTypeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colhpc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colhpb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcalH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcalB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltacH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltacB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.collpcH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.collpcB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbCommon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbSeperate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbManageID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coleName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coleCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colePaymentCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coleServiceNum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfPaymentCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfServiceNum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colwName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colwCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colwRegisterNum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfUN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfPWD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfCusCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfHkasp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfDeposit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colisManaged = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colManagerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmanagerID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboKeysManager = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwCCTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem145 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Vw_BDGTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_BDGTableAdapter()
        Me.Vw_CCTTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_CCTTableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.grdKeysM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwBDGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKeysManager.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwCCTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem145, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdRefresh)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.grdKeysM)
        Me.LayoutControl1.Controls.Add(Me.cboKeysManager)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1704, 572, 1137, 700)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1619, 1022)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Refresh
        Me.cmdRefresh.Location = New System.Drawing.Point(12, 970)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdRefresh.Size = New System.Drawing.Size(47, 40)
        Me.cmdRefresh.StyleController = Me.LayoutControl1
        Me.cmdRefresh.TabIndex = 34
        Me.cmdRefresh.ToolTip = "Ανανέωση"
        Me.cmdRefresh.Visible = False
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(1390, 970)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(217, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 33
        Me.cmdExit.Text = "Έξοδος"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(1118, 970)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(268, 39)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 32
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'grdKeysM
        '
        Me.grdKeysM.DataSource = Me.VwBDGBindingSource
        Me.grdKeysM.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.grdKeysM.Location = New System.Drawing.Point(12, 54)
        Me.grdKeysM.MainView = Me.GridView1
        Me.grdKeysM.Margin = New System.Windows.Forms.Padding(5)
        Me.grdKeysM.Name = "grdKeysM"
        Me.grdKeysM.Size = New System.Drawing.Size(1595, 912)
        Me.grdKeysM.TabIndex = 31
        Me.grdKeysM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'VwBDGBindingSource
        '
        Me.VwBDGBindingSource.DataMember = "vw_BDG"
        Me.VwBDGBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'Priamos_NETDataSet
        '
        Me.Priamos_NETDataSet.DataSetName = "Priamos_NETDataSet"
        Me.Priamos_NETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colcode, Me.colold_code, Me.colnam, Me.colAdrID, Me.colcmt, Me.colaam, Me.coliam, Me.coldts, Me.colmodifiedBy, Me.colmodifiedOn, Me.colcreatedOn, Me.colADR_ID, Me.colADR_Code, Me.colADR_Name, Me.coltk, Me.colAreaID, Me.colCouID, Me.colArea_ID, Me.colArea_Code, Me.colArea_CouID, Me.colArea_Name, Me.colCOU_ID, Me.colCOU_Code, Me.colCOU_Name, Me.colar, Me.colprd, Me.colHTypeID, Me.colBTypeID, Me.colHTYPE_Name, Me.colBTYPE_Name, Me.colFTYPE_Name, Me.colFTypeID, Me.colhpc, Me.colhpb, Me.colcalH, Me.colcalB, Me.coltacH, Me.coltacB, Me.collpcH, Me.collpcB, Me.colbCommon, Me.colbSeperate, Me.colbManageID, Me.coleName, Me.coleCounter, Me.colePaymentCode, Me.coleServiceNum, Me.colfName, Me.colfCounter, Me.colfPaymentCode, Me.colfServiceNum, Me.colwName, Me.colwCounter, Me.colwRegisterNum, Me.colfUN, Me.colfPWD, Me.colfCusCode, Me.colfHkasp, Me.colfDeposit, Me.colisManaged, Me.colManagerName, Me.colmanagerID})
        Me.GridView1.DetailHeight = 619
        Me.GridView1.GridControl = Me.grdKeysM
        Me.GridView1.LevelIndent = 0
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsLayout.StoreAllOptions = True
        Me.GridView1.OptionsLayout.StoreAppearance = True
        Me.GridView1.OptionsLayout.StoreFormatRules = True
        Me.GridView1.OptionsPrint.PrintPreview = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.PreviewIndent = 0
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.MinWidth = 35
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 1
        Me.colID.Width = 131
        '
        'colcode
        '
        Me.colcode.FieldName = "code"
        Me.colcode.MinWidth = 35
        Me.colcode.Name = "colcode"
        Me.colcode.Visible = True
        Me.colcode.VisibleIndex = 2
        Me.colcode.Width = 131
        '
        'colold_code
        '
        Me.colold_code.FieldName = "old_code"
        Me.colold_code.MinWidth = 35
        Me.colold_code.Name = "colold_code"
        Me.colold_code.Visible = True
        Me.colold_code.VisibleIndex = 3
        Me.colold_code.Width = 131
        '
        'colnam
        '
        Me.colnam.FieldName = "nam"
        Me.colnam.MinWidth = 35
        Me.colnam.Name = "colnam"
        Me.colnam.Visible = True
        Me.colnam.VisibleIndex = 4
        Me.colnam.Width = 131
        '
        'colAdrID
        '
        Me.colAdrID.FieldName = "AdrID"
        Me.colAdrID.MinWidth = 35
        Me.colAdrID.Name = "colAdrID"
        Me.colAdrID.Visible = True
        Me.colAdrID.VisibleIndex = 5
        Me.colAdrID.Width = 131
        '
        'colcmt
        '
        Me.colcmt.FieldName = "cmt"
        Me.colcmt.MinWidth = 35
        Me.colcmt.Name = "colcmt"
        Me.colcmt.Visible = True
        Me.colcmt.VisibleIndex = 6
        Me.colcmt.Width = 131
        '
        'colaam
        '
        Me.colaam.FieldName = "aam"
        Me.colaam.MinWidth = 35
        Me.colaam.Name = "colaam"
        Me.colaam.Visible = True
        Me.colaam.VisibleIndex = 7
        Me.colaam.Width = 131
        '
        'coliam
        '
        Me.coliam.FieldName = "iam"
        Me.coliam.MinWidth = 35
        Me.coliam.Name = "coliam"
        Me.coliam.Visible = True
        Me.coliam.VisibleIndex = 8
        Me.coliam.Width = 131
        '
        'coldts
        '
        Me.coldts.FieldName = "dts"
        Me.coldts.MinWidth = 35
        Me.coldts.Name = "coldts"
        Me.coldts.Visible = True
        Me.coldts.VisibleIndex = 9
        Me.coldts.Width = 131
        '
        'colmodifiedBy
        '
        Me.colmodifiedBy.FieldName = "modifiedBy"
        Me.colmodifiedBy.MinWidth = 35
        Me.colmodifiedBy.Name = "colmodifiedBy"
        Me.colmodifiedBy.Visible = True
        Me.colmodifiedBy.VisibleIndex = 10
        Me.colmodifiedBy.Width = 131
        '
        'colmodifiedOn
        '
        Me.colmodifiedOn.FieldName = "modifiedOn"
        Me.colmodifiedOn.MinWidth = 35
        Me.colmodifiedOn.Name = "colmodifiedOn"
        Me.colmodifiedOn.Visible = True
        Me.colmodifiedOn.VisibleIndex = 11
        Me.colmodifiedOn.Width = 131
        '
        'colcreatedOn
        '
        Me.colcreatedOn.FieldName = "createdOn"
        Me.colcreatedOn.MinWidth = 35
        Me.colcreatedOn.Name = "colcreatedOn"
        Me.colcreatedOn.Visible = True
        Me.colcreatedOn.VisibleIndex = 12
        Me.colcreatedOn.Width = 131
        '
        'colADR_ID
        '
        Me.colADR_ID.FieldName = "ADR_ID"
        Me.colADR_ID.MinWidth = 35
        Me.colADR_ID.Name = "colADR_ID"
        Me.colADR_ID.Visible = True
        Me.colADR_ID.VisibleIndex = 13
        Me.colADR_ID.Width = 131
        '
        'colADR_Code
        '
        Me.colADR_Code.FieldName = "ADR_Code"
        Me.colADR_Code.MinWidth = 35
        Me.colADR_Code.Name = "colADR_Code"
        Me.colADR_Code.Visible = True
        Me.colADR_Code.VisibleIndex = 14
        Me.colADR_Code.Width = 131
        '
        'colADR_Name
        '
        Me.colADR_Name.FieldName = "ADR_Name"
        Me.colADR_Name.MinWidth = 35
        Me.colADR_Name.Name = "colADR_Name"
        Me.colADR_Name.Visible = True
        Me.colADR_Name.VisibleIndex = 15
        Me.colADR_Name.Width = 131
        '
        'coltk
        '
        Me.coltk.FieldName = "tk"
        Me.coltk.MinWidth = 35
        Me.coltk.Name = "coltk"
        Me.coltk.Visible = True
        Me.coltk.VisibleIndex = 16
        Me.coltk.Width = 131
        '
        'colAreaID
        '
        Me.colAreaID.FieldName = "AreaID"
        Me.colAreaID.MinWidth = 35
        Me.colAreaID.Name = "colAreaID"
        Me.colAreaID.Visible = True
        Me.colAreaID.VisibleIndex = 17
        Me.colAreaID.Width = 131
        '
        'colCouID
        '
        Me.colCouID.FieldName = "CouID"
        Me.colCouID.MinWidth = 35
        Me.colCouID.Name = "colCouID"
        Me.colCouID.Visible = True
        Me.colCouID.VisibleIndex = 18
        Me.colCouID.Width = 131
        '
        'colArea_ID
        '
        Me.colArea_ID.FieldName = "Area_ID"
        Me.colArea_ID.MinWidth = 35
        Me.colArea_ID.Name = "colArea_ID"
        Me.colArea_ID.Visible = True
        Me.colArea_ID.VisibleIndex = 19
        Me.colArea_ID.Width = 131
        '
        'colArea_Code
        '
        Me.colArea_Code.FieldName = "Area_Code"
        Me.colArea_Code.MinWidth = 35
        Me.colArea_Code.Name = "colArea_Code"
        Me.colArea_Code.Visible = True
        Me.colArea_Code.VisibleIndex = 20
        Me.colArea_Code.Width = 131
        '
        'colArea_CouID
        '
        Me.colArea_CouID.FieldName = "Area_CouID"
        Me.colArea_CouID.MinWidth = 35
        Me.colArea_CouID.Name = "colArea_CouID"
        Me.colArea_CouID.Visible = True
        Me.colArea_CouID.VisibleIndex = 21
        Me.colArea_CouID.Width = 131
        '
        'colArea_Name
        '
        Me.colArea_Name.FieldName = "Area_Name"
        Me.colArea_Name.MinWidth = 35
        Me.colArea_Name.Name = "colArea_Name"
        Me.colArea_Name.Visible = True
        Me.colArea_Name.VisibleIndex = 22
        Me.colArea_Name.Width = 131
        '
        'colCOU_ID
        '
        Me.colCOU_ID.FieldName = "COU_ID"
        Me.colCOU_ID.MinWidth = 35
        Me.colCOU_ID.Name = "colCOU_ID"
        Me.colCOU_ID.Visible = True
        Me.colCOU_ID.VisibleIndex = 23
        Me.colCOU_ID.Width = 131
        '
        'colCOU_Code
        '
        Me.colCOU_Code.FieldName = "COU_Code"
        Me.colCOU_Code.MinWidth = 35
        Me.colCOU_Code.Name = "colCOU_Code"
        Me.colCOU_Code.Visible = True
        Me.colCOU_Code.VisibleIndex = 24
        Me.colCOU_Code.Width = 131
        '
        'colCOU_Name
        '
        Me.colCOU_Name.FieldName = "COU_Name"
        Me.colCOU_Name.MinWidth = 35
        Me.colCOU_Name.Name = "colCOU_Name"
        Me.colCOU_Name.Visible = True
        Me.colCOU_Name.VisibleIndex = 25
        Me.colCOU_Name.Width = 131
        '
        'colar
        '
        Me.colar.FieldName = "ar"
        Me.colar.MinWidth = 35
        Me.colar.Name = "colar"
        Me.colar.Visible = True
        Me.colar.VisibleIndex = 26
        Me.colar.Width = 131
        '
        'colprd
        '
        Me.colprd.FieldName = "prd"
        Me.colprd.MinWidth = 35
        Me.colprd.Name = "colprd"
        Me.colprd.Visible = True
        Me.colprd.VisibleIndex = 27
        Me.colprd.Width = 131
        '
        'colHTypeID
        '
        Me.colHTypeID.FieldName = "HTypeID"
        Me.colHTypeID.MinWidth = 35
        Me.colHTypeID.Name = "colHTypeID"
        Me.colHTypeID.Visible = True
        Me.colHTypeID.VisibleIndex = 28
        Me.colHTypeID.Width = 131
        '
        'colBTypeID
        '
        Me.colBTypeID.FieldName = "BTypeID"
        Me.colBTypeID.MinWidth = 35
        Me.colBTypeID.Name = "colBTypeID"
        Me.colBTypeID.Visible = True
        Me.colBTypeID.VisibleIndex = 29
        Me.colBTypeID.Width = 131
        '
        'colHTYPE_Name
        '
        Me.colHTYPE_Name.FieldName = "HTYPE_Name"
        Me.colHTYPE_Name.MinWidth = 35
        Me.colHTYPE_Name.Name = "colHTYPE_Name"
        Me.colHTYPE_Name.Visible = True
        Me.colHTYPE_Name.VisibleIndex = 30
        Me.colHTYPE_Name.Width = 131
        '
        'colBTYPE_Name
        '
        Me.colBTYPE_Name.FieldName = "BTYPE_Name"
        Me.colBTYPE_Name.MinWidth = 35
        Me.colBTYPE_Name.Name = "colBTYPE_Name"
        Me.colBTYPE_Name.Visible = True
        Me.colBTYPE_Name.VisibleIndex = 31
        Me.colBTYPE_Name.Width = 131
        '
        'colFTYPE_Name
        '
        Me.colFTYPE_Name.FieldName = "FTYPE_Name"
        Me.colFTYPE_Name.MinWidth = 35
        Me.colFTYPE_Name.Name = "colFTYPE_Name"
        Me.colFTYPE_Name.Visible = True
        Me.colFTYPE_Name.VisibleIndex = 32
        Me.colFTYPE_Name.Width = 131
        '
        'colFTypeID
        '
        Me.colFTypeID.FieldName = "FTypeID"
        Me.colFTypeID.MinWidth = 35
        Me.colFTypeID.Name = "colFTypeID"
        Me.colFTypeID.Visible = True
        Me.colFTypeID.VisibleIndex = 33
        Me.colFTypeID.Width = 131
        '
        'colhpc
        '
        Me.colhpc.FieldName = "hpc"
        Me.colhpc.MinWidth = 35
        Me.colhpc.Name = "colhpc"
        Me.colhpc.Visible = True
        Me.colhpc.VisibleIndex = 34
        Me.colhpc.Width = 131
        '
        'colhpb
        '
        Me.colhpb.FieldName = "hpb"
        Me.colhpb.MinWidth = 35
        Me.colhpb.Name = "colhpb"
        Me.colhpb.Visible = True
        Me.colhpb.VisibleIndex = 35
        Me.colhpb.Width = 131
        '
        'colcalH
        '
        Me.colcalH.FieldName = "calH"
        Me.colcalH.MinWidth = 35
        Me.colcalH.Name = "colcalH"
        Me.colcalH.Visible = True
        Me.colcalH.VisibleIndex = 36
        Me.colcalH.Width = 131
        '
        'colcalB
        '
        Me.colcalB.FieldName = "calB"
        Me.colcalB.MinWidth = 35
        Me.colcalB.Name = "colcalB"
        Me.colcalB.Visible = True
        Me.colcalB.VisibleIndex = 37
        Me.colcalB.Width = 131
        '
        'coltacH
        '
        Me.coltacH.FieldName = "tacH"
        Me.coltacH.MinWidth = 35
        Me.coltacH.Name = "coltacH"
        Me.coltacH.Visible = True
        Me.coltacH.VisibleIndex = 38
        Me.coltacH.Width = 131
        '
        'coltacB
        '
        Me.coltacB.FieldName = "tacB"
        Me.coltacB.MinWidth = 35
        Me.coltacB.Name = "coltacB"
        Me.coltacB.Visible = True
        Me.coltacB.VisibleIndex = 39
        Me.coltacB.Width = 131
        '
        'collpcH
        '
        Me.collpcH.FieldName = "lpcH"
        Me.collpcH.MinWidth = 35
        Me.collpcH.Name = "collpcH"
        Me.collpcH.Visible = True
        Me.collpcH.VisibleIndex = 40
        Me.collpcH.Width = 131
        '
        'collpcB
        '
        Me.collpcB.FieldName = "lpcB"
        Me.collpcB.MinWidth = 35
        Me.collpcB.Name = "collpcB"
        Me.collpcB.Visible = True
        Me.collpcB.VisibleIndex = 41
        Me.collpcB.Width = 131
        '
        'colbCommon
        '
        Me.colbCommon.FieldName = "bCommon"
        Me.colbCommon.MinWidth = 35
        Me.colbCommon.Name = "colbCommon"
        Me.colbCommon.Visible = True
        Me.colbCommon.VisibleIndex = 42
        Me.colbCommon.Width = 131
        '
        'colbSeperate
        '
        Me.colbSeperate.FieldName = "bSeperate"
        Me.colbSeperate.MinWidth = 35
        Me.colbSeperate.Name = "colbSeperate"
        Me.colbSeperate.Visible = True
        Me.colbSeperate.VisibleIndex = 43
        Me.colbSeperate.Width = 131
        '
        'colbManageID
        '
        Me.colbManageID.FieldName = "bManageID"
        Me.colbManageID.MinWidth = 35
        Me.colbManageID.Name = "colbManageID"
        Me.colbManageID.Visible = True
        Me.colbManageID.VisibleIndex = 44
        Me.colbManageID.Width = 131
        '
        'coleName
        '
        Me.coleName.FieldName = "eName"
        Me.coleName.MinWidth = 35
        Me.coleName.Name = "coleName"
        Me.coleName.Visible = True
        Me.coleName.VisibleIndex = 45
        Me.coleName.Width = 131
        '
        'coleCounter
        '
        Me.coleCounter.FieldName = "eCounter"
        Me.coleCounter.MinWidth = 35
        Me.coleCounter.Name = "coleCounter"
        Me.coleCounter.Visible = True
        Me.coleCounter.VisibleIndex = 46
        Me.coleCounter.Width = 131
        '
        'colePaymentCode
        '
        Me.colePaymentCode.FieldName = "ePaymentCode"
        Me.colePaymentCode.MinWidth = 35
        Me.colePaymentCode.Name = "colePaymentCode"
        Me.colePaymentCode.Visible = True
        Me.colePaymentCode.VisibleIndex = 47
        Me.colePaymentCode.Width = 131
        '
        'coleServiceNum
        '
        Me.coleServiceNum.FieldName = "eServiceNum"
        Me.coleServiceNum.MinWidth = 35
        Me.coleServiceNum.Name = "coleServiceNum"
        Me.coleServiceNum.Visible = True
        Me.coleServiceNum.VisibleIndex = 48
        Me.coleServiceNum.Width = 131
        '
        'colfName
        '
        Me.colfName.FieldName = "fName"
        Me.colfName.MinWidth = 35
        Me.colfName.Name = "colfName"
        Me.colfName.Visible = True
        Me.colfName.VisibleIndex = 49
        Me.colfName.Width = 131
        '
        'colfCounter
        '
        Me.colfCounter.FieldName = "fCounter"
        Me.colfCounter.MinWidth = 35
        Me.colfCounter.Name = "colfCounter"
        Me.colfCounter.Visible = True
        Me.colfCounter.VisibleIndex = 50
        Me.colfCounter.Width = 131
        '
        'colfPaymentCode
        '
        Me.colfPaymentCode.FieldName = "fPaymentCode"
        Me.colfPaymentCode.MinWidth = 35
        Me.colfPaymentCode.Name = "colfPaymentCode"
        Me.colfPaymentCode.Visible = True
        Me.colfPaymentCode.VisibleIndex = 51
        Me.colfPaymentCode.Width = 131
        '
        'colfServiceNum
        '
        Me.colfServiceNum.FieldName = "fServiceNum"
        Me.colfServiceNum.MinWidth = 35
        Me.colfServiceNum.Name = "colfServiceNum"
        Me.colfServiceNum.Visible = True
        Me.colfServiceNum.VisibleIndex = 52
        Me.colfServiceNum.Width = 131
        '
        'colwName
        '
        Me.colwName.FieldName = "wName"
        Me.colwName.MinWidth = 35
        Me.colwName.Name = "colwName"
        Me.colwName.Visible = True
        Me.colwName.VisibleIndex = 53
        Me.colwName.Width = 131
        '
        'colwCounter
        '
        Me.colwCounter.FieldName = "wCounter"
        Me.colwCounter.MinWidth = 35
        Me.colwCounter.Name = "colwCounter"
        Me.colwCounter.Visible = True
        Me.colwCounter.VisibleIndex = 54
        Me.colwCounter.Width = 131
        '
        'colwRegisterNum
        '
        Me.colwRegisterNum.FieldName = "wRegisterNum"
        Me.colwRegisterNum.MinWidth = 35
        Me.colwRegisterNum.Name = "colwRegisterNum"
        Me.colwRegisterNum.Visible = True
        Me.colwRegisterNum.VisibleIndex = 55
        Me.colwRegisterNum.Width = 131
        '
        'colfUN
        '
        Me.colfUN.FieldName = "fUN"
        Me.colfUN.MinWidth = 35
        Me.colfUN.Name = "colfUN"
        Me.colfUN.Visible = True
        Me.colfUN.VisibleIndex = 56
        Me.colfUN.Width = 131
        '
        'colfPWD
        '
        Me.colfPWD.FieldName = "fPWD"
        Me.colfPWD.MinWidth = 35
        Me.colfPWD.Name = "colfPWD"
        Me.colfPWD.Visible = True
        Me.colfPWD.VisibleIndex = 57
        Me.colfPWD.Width = 131
        '
        'colfCusCode
        '
        Me.colfCusCode.FieldName = "fCusCode"
        Me.colfCusCode.MinWidth = 35
        Me.colfCusCode.Name = "colfCusCode"
        Me.colfCusCode.Visible = True
        Me.colfCusCode.VisibleIndex = 58
        Me.colfCusCode.Width = 131
        '
        'colfHkasp
        '
        Me.colfHkasp.FieldName = "fHkasp"
        Me.colfHkasp.MinWidth = 35
        Me.colfHkasp.Name = "colfHkasp"
        Me.colfHkasp.Visible = True
        Me.colfHkasp.VisibleIndex = 59
        Me.colfHkasp.Width = 131
        '
        'colfDeposit
        '
        Me.colfDeposit.FieldName = "fDeposit"
        Me.colfDeposit.MinWidth = 35
        Me.colfDeposit.Name = "colfDeposit"
        Me.colfDeposit.Visible = True
        Me.colfDeposit.VisibleIndex = 60
        Me.colfDeposit.Width = 131
        '
        'colisManaged
        '
        Me.colisManaged.FieldName = "isManaged"
        Me.colisManaged.MinWidth = 35
        Me.colisManaged.Name = "colisManaged"
        Me.colisManaged.Visible = True
        Me.colisManaged.VisibleIndex = 61
        Me.colisManaged.Width = 131
        '
        'colManagerName
        '
        Me.colManagerName.FieldName = "ManagerName"
        Me.colManagerName.MinWidth = 35
        Me.colManagerName.Name = "colManagerName"
        Me.colManagerName.Visible = True
        Me.colManagerName.VisibleIndex = 62
        Me.colManagerName.Width = 131
        '
        'colmanagerID
        '
        Me.colmanagerID.FieldName = "managerID"
        Me.colmanagerID.MinWidth = 35
        Me.colmanagerID.Name = "colmanagerID"
        Me.colmanagerID.Visible = True
        Me.colmanagerID.VisibleIndex = 63
        Me.colmanagerID.Width = 131
        '
        'cboKeysManager
        '
        Me.cboKeysManager.Location = New System.Drawing.Point(189, 12)
        Me.cboKeysManager.Margin = New System.Windows.Forms.Padding(5)
        Me.cboKeysManager.Name = "cboKeysManager"
        Me.cboKeysManager.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboKeysManager.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboKeysManager.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("sKey", "s Key", 59, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Fullname", "Επωνυμία", 91, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Isprivate", "Ιδιώτης", 87, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsPartner", "Συνεργάτης", 97, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Isworkshop", "Συνεργείο", 110, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Issupplier", "Προμηθευτής", 96, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsEmployer", "Προσωπικό", 114, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboKeysManager.Properties.DataSource = Me.VwCCTBindingSource
        Me.cboKeysManager.Properties.DisplayMember = "Fullname"
        Me.cboKeysManager.Properties.NullText = ""
        Me.cboKeysManager.Properties.PopupSizeable = False
        Me.cboKeysManager.Properties.ValueMember = "ID"
        Me.cboKeysManager.Size = New System.Drawing.Size(1418, 38)
        Me.cboKeysManager.StyleController = Me.LayoutControl1
        Me.cboKeysManager.TabIndex = 30
        Me.cboKeysManager.Tag = "KeyManager,0,1,2"
        '
        'VwCCTBindingSource
        '
        Me.VwCCTBindingSource.DataMember = "vw_CCT"
        Me.VwCCTBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem145, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem1, Me.LayoutControlItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1619, 1022)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem145
        '
        Me.LayoutControlItem145.Control = Me.cboKeysManager
        Me.LayoutControlItem145.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem145.CustomizationFormText = "Διαχειριστής"
        Me.LayoutControlItem145.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem145.Name = "LayoutControlItem145"
        Me.LayoutControlItem145.Size = New System.Drawing.Size(1599, 42)
        Me.LayoutControlItem145.Tag = "1"
        Me.LayoutControlItem145.Text = "Υπεύθυνος κλειδιών"
        Me.LayoutControlItem145.TextSize = New System.Drawing.Size(165, 23)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.grdKeysM
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1599, 916)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdSave
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1106, 958)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(272, 44)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdExit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1378, 958)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(221, 44)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(51, 958)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1055, 44)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdRefresh
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 958)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(51, 44)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'Vw_BDGTableAdapter
        '
        Me.Vw_BDGTableAdapter.ClearBeforeFill = True
        '
        'Vw_CCTTableAdapter
        '
        Me.Vw_CCTTableAdapter.ClearBeforeFill = True
        '
        'frmKeysManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1619, 1022)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmKeysManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmKeysManager"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.grdKeysM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwBDGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKeysManager.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwCCTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem145, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboKeysManager As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem145 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grdKeysM As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Priamos_NETDataSet As Priamos_NETDataSet
    Friend WithEvents VwBDGBindingSource As BindingSource
    Friend WithEvents Vw_BDGTableAdapter As Priamos_NETDataSetTableAdapters.vw_BDGTableAdapter
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colold_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAdrID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colaam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coliam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldts As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreatedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colADR_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colADR_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colADR_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAreaID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCouID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colArea_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colArea_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colArea_CouID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colArea_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOU_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOU_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOU_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colprd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHTypeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBTypeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHTYPE_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBTYPE_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFTYPE_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFTypeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colhpc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colhpb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcalH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcalB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltacH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltacB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents collpcH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents collpcB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbCommon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbSeperate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbManageID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coleName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coleCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colePaymentCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coleServiceNum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfPaymentCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfServiceNum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colwName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colwCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colwRegisterNum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfUN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfPWD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfCusCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfHkasp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfDeposit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colisManaged As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colManagerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmanagerID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VwCCTBindingSource As BindingSource
    Friend WithEvents Vw_CCTTableAdapter As Priamos_NETDataSetTableAdapters.vw_CCTTableAdapter
    Friend WithEvents cmdRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
End Class
