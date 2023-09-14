<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCollections
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode3 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCollections))
        Me.grdVAPT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colord = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colttl2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColFixBalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Rep_FixAptBalance = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colAptbal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebit2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcredit2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Rep_Credit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colbal2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebitusrID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Rep_DEBITUSR = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwUSRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet = New PRIAMOS.NET.Priamos_NETDataSet()
        Me.colbankID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Rep_ΒΑΝΚ = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwBANKSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colColMethodID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Rep_COL_METHOD = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwCOLMETHODBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.coldtDebit1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtCredit1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbdgID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colaptID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdBDG = New DevExpress.XtraGrid.GridControl()
        Me.VwCOLBDGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet2 = New PRIAMOS.NET.Priamos_NETDataSet2()
        Me.grdVBDG = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colBTN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Rep_AddnewCOL = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colBdgCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBdgNam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcredit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebitusrID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDebitUsrID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdVINH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEtos1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcompleteDate1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebit3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcredit3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbal3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebitusrID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbankID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colColMethodID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtDebit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtCredit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcmt1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colinhID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebitusrName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdVO_T = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltenant = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colttl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdRestore = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdColAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdConfirmation = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.VwCOLDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colold_code1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbdgNam2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colaptNam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcompleteDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCredit1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebit4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBal1 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.coldebitusrID3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colttl1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltenant1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colagreed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colETOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colord1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdCol_Refresh = New DevExpress.XtraEditors.SimpleButton()
        Me.cboDebitUsr = New DevExpress.XtraEditors.LookUpEdit()
        Me.grdAPT = New DevExpress.XtraGrid.GridControl()
        Me.COLREPORTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colold_code2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebit5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRealName1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBdgNam3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colArea_Name1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboINH = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwINHBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cboBDG = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwBDGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkShowAgree = New DevExpress.XtraEditors.ToggleSwitch()
        Me.cboBDG1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtBDGCode = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem97 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.YEARSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VwINHBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.vw_COL_INHBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.vw_COLBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Vw_COL_METHODTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_COL_METHODTableAdapter()
        Me.Vw_BANKSTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_BANKSTableAdapter()
        Me.Vw_USRTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_USRTableAdapter()
        Me.vw_COL_APTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Vw_COL_BDGTableAdapter = New PRIAMOS.NET.Priamos_NETDataSet2TableAdapters.vw_COL_BDGTableAdapter()
        Me.Vw_COLTableAdapter = New PRIAMOS.NET.Priamos_NETDataSet2TableAdapters.vw_COLTableAdapter()
        Me.SvgImageCollection1 = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.COL_REPORTTableAdapter = New PRIAMOS.NET.Priamos_NETDataSet2TableAdapters.COL_REPORTTableAdapter()
        Me.colold_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBdgNam1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldebit1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRealName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colArea_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Vw_INHTableAdapter = New PRIAMOS.NET.Priamos_NETDataSet2TableAdapters.vw_INHTableAdapter()
        Me.Vw_COL_DTableAdapter = New PRIAMOS.NET.Priamos_NETDataSet2TableAdapters.vw_COL_DTableAdapter()
        Me.Vw_BDGTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_BDGTableAdapter()
        Me.YEARSTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.YEARSTableAdapter()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        CType(Me.grdVAPT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_FixAptBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_Credit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_DEBITUSR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwUSRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_ΒΑΝΚ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwBANKSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_COL_METHOD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwCOLMETHODBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBDG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwCOLBDGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVBDG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_AddnewCOL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVINH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVO_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwCOLDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDebitUsr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAPT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COLREPORTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboINH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINHBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwBDGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowAgree.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBDG1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBDGCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem97, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.YEARSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINHBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vw_COL_INHBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vw_COLBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vw_COL_APTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SvgImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdVAPT
        '
        Me.grdVAPT.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdVAPT.Appearance.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.grdVAPT.Appearance.GroupRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.grdVAPT.Appearance.ViewCaption.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.grdVAPT.Appearance.ViewCaption.BackColor2 = System.Drawing.Color.White
        Me.grdVAPT.Appearance.ViewCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.grdVAPT.Appearance.ViewCaption.Options.UseBackColor = True
        Me.grdVAPT.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colord, Me.colttl2, Me.colnam, Me.ColFixBalance, Me.colAptbal, Me.coldebit2, Me.colcredit2, Me.colbal2, Me.coldebitusrID1, Me.colbankID, Me.colColMethodID, Me.coldtDebit1, Me.coldtCredit1, Me.colbdgID1, Me.colaptID1})
        Me.grdVAPT.DetailHeight = 619
        Me.grdVAPT.GridControl = Me.grdBDG
        Me.grdVAPT.Name = "grdVAPT"
        Me.grdVAPT.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVAPT.OptionsLayout.Columns.StoreAllOptions = True
        Me.grdVAPT.OptionsLayout.Columns.StoreAppearance = True
        Me.grdVAPT.OptionsLayout.LayoutVersion = "2.0"
        Me.grdVAPT.OptionsLayout.StoreAllOptions = True
        Me.grdVAPT.OptionsLayout.StoreAppearance = True
        Me.grdVAPT.OptionsLayout.StoreFormatRules = True
        Me.grdVAPT.OptionsMenu.ShowConditionalFormattingItem = True
        Me.grdVAPT.OptionsMenu.ShowFooterItem = True
        Me.grdVAPT.OptionsView.ShowFooter = True
        Me.grdVAPT.OptionsView.ShowGroupPanel = False
        Me.grdVAPT.ViewCaption = "Διαμερίσματα"
        '
        'colord
        '
        Me.colord.Caption = "AA"
        Me.colord.FieldName = "ord"
        Me.colord.MinWidth = 35
        Me.colord.Name = "colord"
        Me.colord.Visible = True
        Me.colord.VisibleIndex = 0
        Me.colord.Width = 142
        '
        'colttl2
        '
        Me.colttl2.Caption = "Διαμερίσματα"
        Me.colttl2.FieldName = "ttl"
        Me.colttl2.MinWidth = 33
        Me.colttl2.Name = "colttl2"
        Me.colttl2.OptionsColumn.AllowEdit = False
        Me.colttl2.Visible = True
        Me.colttl2.VisibleIndex = 1
        Me.colttl2.Width = 527
        '
        'colnam
        '
        Me.colnam.Caption = "Τίτλος Εκτύπωσης"
        Me.colnam.FieldName = "nam"
        Me.colnam.MinWidth = 35
        Me.colnam.Name = "colnam"
        Me.colnam.Visible = True
        Me.colnam.VisibleIndex = 2
        Me.colnam.Width = 131
        '
        'ColFixBalance
        '
        Me.ColFixBalance.Caption = "Διόρθωση υπολοίπου"
        Me.ColFixBalance.ColumnEdit = Me.Rep_FixAptBalance
        Me.ColFixBalance.MinWidth = 35
        Me.ColFixBalance.Name = "ColFixBalance"
        Me.ColFixBalance.Visible = True
        Me.ColFixBalance.VisibleIndex = 3
        Me.ColFixBalance.Width = 131
        '
        'Rep_FixAptBalance
        '
        Me.Rep_FixAptBalance.AutoHeight = False
        EditorButtonImageOptions1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[True]
        EditorButtonImageOptions1.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_balance_16_1_
        SerializableAppearanceObject1.Options.UseImage = True
        Me.Rep_FixAptBalance.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.Rep_FixAptBalance.ContextImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_balance_16_1_
        Me.Rep_FixAptBalance.Name = "Rep_FixAptBalance"
        Me.Rep_FixAptBalance.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'colAptbal
        '
        Me.colAptbal.Caption = "Υπόλοιπο Διαμερίσματος"
        Me.colAptbal.DisplayFormat.FormatString = "c2"
        Me.colAptbal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colAptbal.FieldName = "Aptbal"
        Me.colAptbal.MinWidth = 33
        Me.colAptbal.Name = "colAptbal"
        Me.colAptbal.OptionsColumn.AllowEdit = False
        Me.colAptbal.Visible = True
        Me.colAptbal.VisibleIndex = 4
        Me.colAptbal.Width = 323
        '
        'coldebit2
        '
        Me.coldebit2.Caption = "Χρέωση"
        Me.coldebit2.DisplayFormat.FormatString = "c2"
        Me.coldebit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.coldebit2.FieldName = "debit"
        Me.coldebit2.MinWidth = 33
        Me.coldebit2.Name = "coldebit2"
        Me.coldebit2.OptionsColumn.AllowEdit = False
        Me.coldebit2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "Σύνολο={0:c2}")})
        Me.coldebit2.Visible = True
        Me.coldebit2.VisibleIndex = 5
        Me.coldebit2.Width = 575
        '
        'colcredit2
        '
        Me.colcredit2.Caption = "Πίστωση"
        Me.colcredit2.ColumnEdit = Me.Rep_Credit
        Me.colcredit2.DisplayFormat.FormatString = "c2"
        Me.colcredit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colcredit2.FieldName = "credit"
        Me.colcredit2.MinWidth = 33
        Me.colcredit2.Name = "colcredit2"
        Me.colcredit2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "Σύνολο={0:c2}")})
        Me.colcredit2.Visible = True
        Me.colcredit2.VisibleIndex = 6
        Me.colcredit2.Width = 575
        '
        'Rep_Credit
        '
        Me.Rep_Credit.AutoHeight = False
        Me.Rep_Credit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Left), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear), New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Rep_Credit.Name = "Rep_Credit"
        '
        'colbal2
        '
        Me.colbal2.Caption = "Υπόλοιπο"
        Me.colbal2.DisplayFormat.FormatString = "c2"
        Me.colbal2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colbal2.FieldName = "bal"
        Me.colbal2.MinWidth = 33
        Me.colbal2.Name = "colbal2"
        Me.colbal2.OptionsColumn.AllowEdit = False
        Me.colbal2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bal", "Σύνολο={0:c2}")})
        Me.colbal2.Visible = True
        Me.colbal2.VisibleIndex = 7
        Me.colbal2.Width = 575
        '
        'coldebitusrID1
        '
        Me.coldebitusrID1.Caption = "Χρήστης Χρέωσης"
        Me.coldebitusrID1.ColumnEdit = Me.Rep_DEBITUSR
        Me.coldebitusrID1.FieldName = "debitusrID"
        Me.coldebitusrID1.MinWidth = 33
        Me.coldebitusrID1.Name = "coldebitusrID1"
        Me.coldebitusrID1.Visible = True
        Me.coldebitusrID1.VisibleIndex = 8
        Me.coldebitusrID1.Width = 593
        '
        'Rep_DEBITUSR
        '
        Me.Rep_DEBITUSR.AutoHeight = False
        Me.Rep_DEBITUSR.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.Rep_DEBITUSR.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 30, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 50, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Χρήστης", 97, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.Rep_DEBITUSR.DataSource = Me.VwUSRBindingSource
        Me.Rep_DEBITUSR.DisplayMember = "RealName"
        Me.Rep_DEBITUSR.KeyMember = "RealName"
        Me.Rep_DEBITUSR.Name = "Rep_DEBITUSR"
        Me.Rep_DEBITUSR.NullText = ""
        Me.Rep_DEBITUSR.ValueMember = "ID"
        '
        'VwUSRBindingSource
        '
        Me.VwUSRBindingSource.DataMember = "vw_USR"
        Me.VwUSRBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'Priamos_NETDataSet
        '
        Me.Priamos_NETDataSet.DataSetName = "Priamos_NETDataSet"
        Me.Priamos_NETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'colbankID
        '
        Me.colbankID.Caption = "Τράπεζα"
        Me.colbankID.ColumnEdit = Me.Rep_ΒΑΝΚ
        Me.colbankID.FieldName = "bankID"
        Me.colbankID.MinWidth = 33
        Me.colbankID.Name = "colbankID"
        Me.colbankID.Width = 125
        '
        'Rep_ΒΑΝΚ
        '
        Me.Rep_ΒΑΝΚ.AutoHeight = False
        Me.Rep_ΒΑΝΚ.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.Rep_ΒΑΝΚ.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Real Name", 100, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 33, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 53, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Τράπεζα", 58, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 107, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 110, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 105, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdBy", "created By", 102, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.Rep_ΒΑΝΚ.DataSource = Me.VwBANKSBindingSource
        Me.Rep_ΒΑΝΚ.DisplayMember = "name"
        Me.Rep_ΒΑΝΚ.KeyMember = "name"
        Me.Rep_ΒΑΝΚ.Name = "Rep_ΒΑΝΚ"
        Me.Rep_ΒΑΝΚ.NullText = ""
        Me.Rep_ΒΑΝΚ.ValueMember = "ID"
        '
        'VwBANKSBindingSource
        '
        Me.VwBANKSBindingSource.DataMember = "vw_BANKS"
        Me.VwBANKSBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'colColMethodID
        '
        Me.colColMethodID.Caption = "Τρόπος Είσπραξης"
        Me.colColMethodID.ColumnEdit = Me.Rep_COL_METHOD
        Me.colColMethodID.FieldName = "ColMethodID"
        Me.colColMethodID.MinWidth = 33
        Me.colColMethodID.Name = "colColMethodID"
        Me.colColMethodID.Width = 125
        '
        'Rep_COL_METHOD
        '
        Me.Rep_COL_METHOD.AutoHeight = False
        Me.Rep_COL_METHOD.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.Rep_COL_METHOD.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 33, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 53, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Τρόπος Είσπραξης", 58, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 107, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 110, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 105, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Real Name", 100, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.Rep_COL_METHOD.DataSource = Me.VwCOLMETHODBindingSource
        Me.Rep_COL_METHOD.DisplayMember = "name"
        Me.Rep_COL_METHOD.KeyMember = "name"
        Me.Rep_COL_METHOD.Name = "Rep_COL_METHOD"
        Me.Rep_COL_METHOD.NullText = ""
        Me.Rep_COL_METHOD.ValueMember = "ID"
        '
        'VwCOLMETHODBindingSource
        '
        Me.VwCOLMETHODBindingSource.DataMember = "vw_COL_METHOD"
        Me.VwCOLMETHODBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'coldtDebit1
        '
        Me.coldtDebit1.Caption = "Ημερ/νία Χρέωσης"
        Me.coldtDebit1.FieldName = "dtDebit"
        Me.coldtDebit1.MinWidth = 33
        Me.coldtDebit1.Name = "coldtDebit1"
        Me.coldtDebit1.OptionsColumn.AllowEdit = False
        Me.coldtDebit1.Width = 125
        '
        'coldtCredit1
        '
        Me.coldtCredit1.Caption = "Ημερ/νία Πίστωσης"
        Me.coldtCredit1.FieldName = "dtCredit"
        Me.coldtCredit1.MinWidth = 33
        Me.coldtCredit1.Name = "coldtCredit1"
        Me.coldtCredit1.Width = 125
        '
        'colbdgID1
        '
        Me.colbdgID1.Caption = "ID Πολυκατοικίας"
        Me.colbdgID1.FieldName = "bdgID"
        Me.colbdgID1.MinWidth = 35
        Me.colbdgID1.Name = "colbdgID1"
        Me.colbdgID1.Width = 132
        '
        'colaptID1
        '
        Me.colaptID1.Caption = "ID Διαμερίσματος"
        Me.colaptID1.FieldName = "aptID"
        Me.colaptID1.MinWidth = 35
        Me.colaptID1.Name = "colaptID1"
        Me.colaptID1.Width = 132
        '
        'grdBDG
        '
        Me.grdBDG.DataSource = Me.VwCOLBDGBindingSource
        Me.grdBDG.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.grdBDG.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.grdBDG.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.grdBDG.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.grdBDG.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.grdBDG.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        GridLevelNode1.LevelTemplate = Me.grdVAPT
        GridLevelNode2.LevelTemplate = Me.grdVINH
        GridLevelNode3.LevelTemplate = Me.grdVO_T
        GridLevelNode3.RelationName = "vw_COL_INH_vw_COL"
        GridLevelNode2.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode3})
        GridLevelNode2.RelationName = "vw_COL_APT_vw_COL_INH"
        GridLevelNode1.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        GridLevelNode1.RelationName = "vw_COL_BDG_vw_COL_APT"
        Me.grdBDG.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdBDG.Location = New System.Drawing.Point(25, 132)
        Me.grdBDG.MainView = Me.grdVBDG
        Me.grdBDG.Margin = New System.Windows.Forms.Padding(5)
        Me.grdBDG.Name = "grdBDG"
        Me.grdBDG.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.Rep_DEBITUSR, Me.Rep_ΒΑΝΚ, Me.Rep_COL_METHOD, Me.Rep_Credit, Me.Rep_AddnewCOL, Me.Rep_FixAptBalance})
        Me.grdBDG.Size = New System.Drawing.Size(2343, 1242)
        Me.grdBDG.TabIndex = 5
        Me.grdBDG.UseEmbeddedNavigator = True
        Me.grdBDG.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVBDG, Me.grdVINH, Me.grdVO_T, Me.grdVAPT})
        '
        'VwCOLBDGBindingSource
        '
        Me.VwCOLBDGBindingSource.DataMember = "vw_COL_BDG"
        Me.VwCOLBDGBindingSource.DataSource = Me.Priamos_NETDataSet2
        '
        'Priamos_NETDataSet2
        '
        Me.Priamos_NETDataSet2.DataSetName = "Priamos_NETDataSet2"
        Me.Priamos_NETDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'grdVBDG
        '
        Me.grdVBDG.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colBTN, Me.colBdgCode, Me.colBdgNam, Me.coldebit, Me.colcredit, Me.colbal, Me.coldebitusrID, Me.GridColumnDebitUsrID})
        Me.grdVBDG.DetailHeight = 619
        Me.grdVBDG.GridControl = Me.grdBDG
        Me.grdVBDG.Name = "grdVBDG"
        Me.grdVBDG.OptionsLayout.Columns.StoreAllOptions = True
        Me.grdVBDG.OptionsLayout.StoreAllOptions = True
        Me.grdVBDG.OptionsLayout.StoreFormatRules = True
        Me.grdVBDG.OptionsMenu.ShowConditionalFormattingItem = True
        Me.grdVBDG.OptionsMenu.ShowFooterItem = True
        Me.grdVBDG.OptionsView.ShowFooter = True
        Me.grdVBDG.OptionsView.ShowGroupPanel = False
        '
        'colBTN
        '
        Me.colBTN.ColumnEdit = Me.Rep_AddnewCOL
        Me.colBTN.MinWidth = 35
        Me.colBTN.Name = "colBTN"
        Me.colBTN.Visible = True
        Me.colBTN.VisibleIndex = 0
        Me.colBTN.Width = 132
        '
        'Rep_AddnewCOL
        '
        Me.Rep_AddnewCOL.AutoHeight = False
        Me.Rep_AddnewCOL.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)})
        Me.Rep_AddnewCOL.Name = "Rep_AddnewCOL"
        Me.Rep_AddnewCOL.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'colBdgCode
        '
        Me.colBdgCode.Caption = "Κωδικός"
        Me.colBdgCode.FieldName = "BdgCode"
        Me.colBdgCode.MinWidth = 35
        Me.colBdgCode.Name = "colBdgCode"
        Me.colBdgCode.Visible = True
        Me.colBdgCode.VisibleIndex = 1
        Me.colBdgCode.Width = 131
        '
        'colBdgNam
        '
        Me.colBdgNam.Caption = "Πολυκατοικία"
        Me.colBdgNam.FieldName = "BdgNam"
        Me.colBdgNam.MinWidth = 33
        Me.colBdgNam.Name = "colBdgNam"
        Me.colBdgNam.OptionsColumn.AllowEdit = False
        Me.colBdgNam.Visible = True
        Me.colBdgNam.VisibleIndex = 2
        Me.colBdgNam.Width = 587
        '
        'coldebit
        '
        Me.coldebit.Caption = "Χρέωση"
        Me.coldebit.FieldName = "debit"
        Me.coldebit.MinWidth = 33
        Me.coldebit.Name = "coldebit"
        Me.coldebit.OptionsColumn.AllowEdit = False
        Me.coldebit.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "Σύνολο={0:c2}")})
        Me.coldebit.Visible = True
        Me.coldebit.VisibleIndex = 3
        Me.coldebit.Width = 587
        '
        'colcredit
        '
        Me.colcredit.Caption = "Πίστωση"
        Me.colcredit.FieldName = "credit"
        Me.colcredit.MinWidth = 33
        Me.colcredit.Name = "colcredit"
        Me.colcredit.OptionsColumn.AllowEdit = False
        Me.colcredit.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "Σύνολο={0:c2}")})
        Me.colcredit.Visible = True
        Me.colcredit.VisibleIndex = 4
        Me.colcredit.Width = 587
        '
        'colbal
        '
        Me.colbal.Caption = "Υπόλοιπο"
        Me.colbal.FieldName = "bal"
        Me.colbal.MinWidth = 33
        Me.colbal.Name = "colbal"
        Me.colbal.OptionsColumn.AllowEdit = False
        Me.colbal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bal", "Σύνολο={0:c2}")})
        Me.colbal.Visible = True
        Me.colbal.VisibleIndex = 5
        Me.colbal.Width = 343
        '
        'coldebitusrID
        '
        Me.coldebitusrID.Caption = "Χρήστης Χρέωσης"
        Me.coldebitusrID.ColumnEdit = Me.Rep_DEBITUSR
        Me.coldebitusrID.FieldName = "debitusrID"
        Me.coldebitusrID.MinWidth = 33
        Me.coldebitusrID.Name = "coldebitusrID"
        Me.coldebitusrID.Width = 125
        '
        'GridColumnDebitUsrID
        '
        Me.GridColumnDebitUsrID.Caption = "Χρήστης Χρέωσης"
        Me.GridColumnDebitUsrID.ColumnEdit = Me.Rep_DEBITUSR
        Me.GridColumnDebitUsrID.MinWidth = 33
        Me.GridColumnDebitUsrID.Name = "GridColumnDebitUsrID"
        Me.GridColumnDebitUsrID.Visible = True
        Me.GridColumnDebitUsrID.VisibleIndex = 6
        Me.GridColumnDebitUsrID.Width = 417
        '
        'grdVINH
        '
        Me.grdVINH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEtos1, Me.colcompleteDate1, Me.coldebit3, Me.colcredit3, Me.colbal3, Me.coldebitusrID2, Me.colbankID1, Me.colColMethodID1, Me.coldtDebit, Me.coldtCredit, Me.colcmt1, Me.colinhID1, Me.coldebitusrName})
        Me.grdVINH.DetailHeight = 619
        Me.grdVINH.GridControl = Me.grdBDG
        Me.grdVINH.Name = "grdVINH"
        Me.grdVINH.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVINH.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVINH.OptionsLayout.Columns.StoreAllOptions = True
        Me.grdVINH.OptionsLayout.Columns.StoreAppearance = True
        Me.grdVINH.OptionsLayout.LayoutVersion = "1.0"
        Me.grdVINH.OptionsLayout.StoreAllOptions = True
        Me.grdVINH.OptionsLayout.StoreAppearance = True
        Me.grdVINH.OptionsLayout.StoreFormatRules = True
        Me.grdVINH.OptionsMenu.ShowConditionalFormattingItem = True
        Me.grdVINH.OptionsMenu.ShowFooterItem = True
        Me.grdVINH.OptionsView.ShowFooter = True
        Me.grdVINH.OptionsView.ShowGroupPanel = False
        Me.grdVINH.ViewCaption = "Παραστατικά"
        '
        'colEtos1
        '
        Me.colEtos1.Caption = "Έτος"
        Me.colEtos1.FieldName = "Etos"
        Me.colEtos1.MinWidth = 35
        Me.colEtos1.Name = "colEtos1"
        Me.colEtos1.Visible = True
        Me.colEtos1.VisibleIndex = 0
        Me.colEtos1.Width = 132
        '
        'colcompleteDate1
        '
        Me.colcompleteDate1.Caption = "Παραστατικά"
        Me.colcompleteDate1.FieldName = "completeDate"
        Me.colcompleteDate1.MinWidth = 33
        Me.colcompleteDate1.Name = "colcompleteDate1"
        Me.colcompleteDate1.OptionsColumn.AllowEdit = False
        Me.colcompleteDate1.Visible = True
        Me.colcompleteDate1.VisibleIndex = 1
        Me.colcompleteDate1.Width = 125
        '
        'coldebit3
        '
        Me.coldebit3.Caption = "Χρέωση"
        Me.coldebit3.DisplayFormat.FormatString = "c2"
        Me.coldebit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.coldebit3.FieldName = "debit"
        Me.coldebit3.MinWidth = 33
        Me.coldebit3.Name = "coldebit3"
        Me.coldebit3.OptionsColumn.AllowEdit = False
        Me.coldebit3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "Σύνολο={0:c2}")})
        Me.coldebit3.Visible = True
        Me.coldebit3.VisibleIndex = 2
        Me.coldebit3.Width = 125
        '
        'colcredit3
        '
        Me.colcredit3.Caption = "Πίστωση"
        Me.colcredit3.ColumnEdit = Me.Rep_Credit
        Me.colcredit3.DisplayFormat.FormatString = "c2"
        Me.colcredit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colcredit3.FieldName = "credit"
        Me.colcredit3.MinWidth = 33
        Me.colcredit3.Name = "colcredit3"
        Me.colcredit3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "Σύνολο={0:c2}")})
        Me.colcredit3.Visible = True
        Me.colcredit3.VisibleIndex = 3
        Me.colcredit3.Width = 125
        '
        'colbal3
        '
        Me.colbal3.Caption = "Υπόλοιπο"
        Me.colbal3.DisplayFormat.FormatString = "c2"
        Me.colbal3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colbal3.FieldName = "bal"
        Me.colbal3.MinWidth = 33
        Me.colbal3.Name = "colbal3"
        Me.colbal3.OptionsColumn.AllowEdit = False
        Me.colbal3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bal", "Σύνολο={0:c2}")})
        Me.colbal3.Visible = True
        Me.colbal3.VisibleIndex = 4
        Me.colbal3.Width = 125
        '
        'coldebitusrID2
        '
        Me.coldebitusrID2.Caption = "Χρήστης Χρέωσης"
        Me.coldebitusrID2.ColumnEdit = Me.Rep_DEBITUSR
        Me.coldebitusrID2.FieldName = "debitusrID"
        Me.coldebitusrID2.MinWidth = 33
        Me.coldebitusrID2.Name = "coldebitusrID2"
        Me.coldebitusrID2.OptionsColumn.AllowEdit = False
        Me.coldebitusrID2.Visible = True
        Me.coldebitusrID2.VisibleIndex = 7
        Me.coldebitusrID2.Width = 125
        '
        'colbankID1
        '
        Me.colbankID1.Caption = "Τράπεζα"
        Me.colbankID1.ColumnEdit = Me.Rep_ΒΑΝΚ
        Me.colbankID1.FieldName = "bankID"
        Me.colbankID1.MinWidth = 33
        Me.colbankID1.Name = "colbankID1"
        Me.colbankID1.Width = 125
        '
        'colColMethodID1
        '
        Me.colColMethodID1.Caption = "Τρόπος Είσπραξης"
        Me.colColMethodID1.ColumnEdit = Me.Rep_COL_METHOD
        Me.colColMethodID1.FieldName = "ColMethodID"
        Me.colColMethodID1.MinWidth = 33
        Me.colColMethodID1.Name = "colColMethodID1"
        Me.colColMethodID1.Width = 125
        '
        'coldtDebit
        '
        Me.coldtDebit.Caption = "Ημερ/νία Χρέωσης"
        Me.coldtDebit.FieldName = "dtDebit"
        Me.coldtDebit.MinWidth = 33
        Me.coldtDebit.Name = "coldtDebit"
        Me.coldtDebit.OptionsColumn.AllowEdit = False
        Me.coldtDebit.Visible = True
        Me.coldtDebit.VisibleIndex = 6
        Me.coldtDebit.Width = 125
        '
        'coldtCredit
        '
        Me.coldtCredit.Caption = "Ημερ/νία Πίστωσης"
        Me.coldtCredit.FieldName = "dtCredit"
        Me.coldtCredit.MinWidth = 33
        Me.coldtCredit.Name = "coldtCredit"
        Me.coldtCredit.Visible = True
        Me.coldtCredit.VisibleIndex = 5
        Me.coldtCredit.Width = 125
        '
        'colcmt1
        '
        Me.colcmt1.Caption = "Σχόλια"
        Me.colcmt1.FieldName = "cmt"
        Me.colcmt1.MinWidth = 35
        Me.colcmt1.Name = "colcmt1"
        Me.colcmt1.Width = 132
        '
        'colinhID1
        '
        Me.colinhID1.FieldName = "inhID"
        Me.colinhID1.MinWidth = 35
        Me.colinhID1.Name = "colinhID1"
        Me.colinhID1.Width = 132
        '
        'coldebitusrName
        '
        Me.coldebitusrName.Caption = "Χρήστης Χρέωσης"
        Me.coldebitusrName.FieldName = "debitusrName"
        Me.coldebitusrName.MinWidth = 35
        Me.coldebitusrName.Name = "coldebitusrName"
        Me.coldebitusrName.Visible = True
        Me.coldebitusrName.VisibleIndex = 8
        Me.coldebitusrName.Width = 132
        '
        'grdVO_T
        '
        Me.grdVO_T.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdVO_T.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn17, Me.coltenant, Me.colttl, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35})
        Me.grdVO_T.DetailHeight = 619
        Me.grdVO_T.GridControl = Me.grdBDG
        Me.grdVO_T.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "name", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "owner_tenant", Nothing, "")})
        Me.grdVO_T.LevelIndent = 0
        Me.grdVO_T.Name = "grdVO_T"
        Me.grdVO_T.OptionsMenu.ShowConditionalFormattingItem = True
        Me.grdVO_T.OptionsMenu.ShowFooterItem = True
        Me.grdVO_T.OptionsPrint.PrintPreview = True
        Me.grdVO_T.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grdVO_T.OptionsView.EnableAppearanceEvenRow = True
        Me.grdVO_T.OptionsView.ShowFooter = True
        Me.grdVO_T.OptionsView.ShowGroupedColumns = True
        Me.grdVO_T.OptionsView.ShowGroupPanel = False
        Me.grdVO_T.PreviewIndent = 0
        Me.grdVO_T.ViewCaption = "Ένοικος-Ιδιοκτήτης"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Πολυκατοικία"
        Me.GridColumn3.FieldName = "BdgNam"
        Me.GridColumn3.MinWidth = 33
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.Width = 125
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Παραστατικό"
        Me.GridColumn17.FieldName = "completeDate"
        Me.GridColumn17.MinWidth = 33
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.Width = 125
        '
        'coltenant
        '
        Me.coltenant.Caption = "Ένοικος"
        Me.coltenant.FieldName = "tenant"
        Me.coltenant.MinWidth = 33
        Me.coltenant.Name = "coltenant"
        Me.coltenant.OptionsColumn.AllowEdit = False
        Me.coltenant.Visible = True
        Me.coltenant.VisibleIndex = 0
        Me.coltenant.Width = 125
        '
        'colttl
        '
        Me.colttl.Caption = "Διαμέρισμα"
        Me.colttl.FieldName = "ttl"
        Me.colttl.MinWidth = 33
        Me.colttl.Name = "colttl"
        Me.colttl.OptionsColumn.AllowEdit = False
        Me.colttl.Width = 125
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Ημερ/νία Καταχώρησης"
        Me.GridColumn23.FieldName = "createdOn"
        Me.GridColumn23.MinWidth = 33
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 1
        Me.GridColumn23.Width = 125
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Χρέωση"
        Me.GridColumn24.DisplayFormat.FormatString = "c2"
        Me.GridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn24.FieldName = "debit"
        Me.GridColumn24.MinWidth = 33
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "Σύνολο={0:c2}")})
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 2
        Me.GridColumn24.Width = 125
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Πίστωση"
        Me.GridColumn25.ColumnEdit = Me.Rep_Credit
        Me.GridColumn25.DisplayFormat.FormatString = "c2"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn25.FieldName = "credit"
        Me.GridColumn25.MinWidth = 33
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "Σύνολο={0:c2}")})
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 3
        Me.GridColumn25.Width = 125
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Υπόλοιπο"
        Me.GridColumn26.DisplayFormat.FormatString = "c2"
        Me.GridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn26.FieldName = "bal"
        Me.GridColumn26.MinWidth = 33
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        Me.GridColumn26.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bal", "Σύνολο={0:c2}")})
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 4
        Me.GridColumn26.Width = 125
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Τρόπος Είσπραξης"
        Me.GridColumn27.ColumnEdit = Me.Rep_COL_METHOD
        Me.GridColumn27.FieldName = "ColMethodID"
        Me.GridColumn27.MinWidth = 33
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 6
        Me.GridColumn27.Width = 140
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Τράπεζα"
        Me.GridColumn28.ColumnEdit = Me.Rep_ΒΑΝΚ
        Me.GridColumn28.FieldName = "bankID"
        Me.GridColumn28.MinWidth = 33
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 5
        Me.GridColumn28.Width = 140
        '
        'GridColumn29
        '
        Me.GridColumn29.FieldName = "ID"
        Me.GridColumn29.MinWidth = 33
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Width = 125
        '
        'GridColumn30
        '
        Me.GridColumn30.FieldName = "bdgID"
        Me.GridColumn30.MinWidth = 33
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Width = 125
        '
        'GridColumn31
        '
        Me.GridColumn31.FieldName = "inhID"
        Me.GridColumn31.MinWidth = 33
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.Width = 125
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Ημερ/νία Χρέωσης"
        Me.GridColumn32.FieldName = "dtDebit"
        Me.GridColumn32.MinWidth = 33
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 8
        Me.GridColumn32.Width = 125
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Ημερ/νία Πίστωσης"
        Me.GridColumn33.DisplayFormat.FormatString = "d"
        Me.GridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn33.FieldName = "dtCredit"
        Me.GridColumn33.MinWidth = 33
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 7
        Me.GridColumn33.Width = 125
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Χρήστης Πίστωσης"
        Me.GridColumn34.FieldName = "creditusrID"
        Me.GridColumn34.MinWidth = 33
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.Width = 140
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "Χρήστης Χρέωσης"
        Me.GridColumn35.ColumnEdit = Me.Rep_DEBITUSR
        Me.GridColumn35.FieldName = "debitusrID"
        Me.GridColumn35.MinWidth = 33
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 9
        Me.GridColumn35.Width = 160
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.cmdRestore)
        Me.LayoutControl1.Controls.Add(Me.cmdColAdd)
        Me.LayoutControl1.Controls.Add(Me.cmdConfirmation)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.cmdCol_Refresh)
        Me.LayoutControl1.Controls.Add(Me.cboDebitUsr)
        Me.LayoutControl1.Controls.Add(Me.grdAPT)
        Me.LayoutControl1.Controls.Add(Me.cboINH)
        Me.LayoutControl1.Controls.Add(Me.grdBDG)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.cboBDG)
        Me.LayoutControl1.Controls.Add(Me.chkShowAgree)
        Me.LayoutControl1.Controls.Add(Me.cboBDG1)
        Me.LayoutControl1.Controls.Add(Me.txtBDGCode)
        Me.LayoutControl1.Location = New System.Drawing.Point(-5, -5)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(718, 214, 1107, 936)
        Me.LayoutControl1.OptionsView.DrawItemBorders = True
        Me.LayoutControl1.OptionsView.ItemBorderColor = System.Drawing.Color.Blue
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(2393, 1443)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdRestore
        '
        Me.cmdRestore.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRestore.ImageOptions.Image = CType(resources.GetObject("cmdRestore.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdRestore.Location = New System.Drawing.Point(1748, 1334)
        Me.cmdRestore.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdRestore.Name = "cmdRestore"
        Me.cmdRestore.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdRestore.Size = New System.Drawing.Size(256, 40)
        Me.cmdRestore.StyleController = Me.LayoutControl1
        Me.cmdRestore.TabIndex = 9
        Me.cmdRestore.Text = "Επαναφορά στις Οφειλές"
        Me.cmdRestore.ToolTip = "Επαναφορά Εγγραφών στις Οφειλες"
        '
        'cmdColAdd
        '
        Me.cmdColAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdColAdd.ImageOptions.Image = CType(resources.GetObject("cmdColAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdColAdd.Location = New System.Drawing.Point(25, 62)
        Me.cmdColAdd.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdColAdd.Name = "cmdColAdd"
        Me.cmdColAdd.Size = New System.Drawing.Size(181, 40)
        Me.cmdColAdd.StyleController = Me.LayoutControl1
        Me.cmdColAdd.TabIndex = 8
        Me.cmdColAdd.Text = "Νέα Είσπραξη"
        '
        'cmdConfirmation
        '
        Me.cmdConfirmation.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdConfirmation.ImageOptions.Image = CType(resources.GetObject("cmdConfirmation.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdConfirmation.Location = New System.Drawing.Point(25, 1334)
        Me.cmdConfirmation.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdConfirmation.Name = "cmdConfirmation"
        Me.cmdConfirmation.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdConfirmation.Size = New System.Drawing.Size(276, 40)
        Me.cmdConfirmation.StyleController = Me.LayoutControl1
        Me.cmdConfirmation.TabIndex = 1
        Me.cmdConfirmation.Text = "Επιβεβαίωση"
        Me.cmdConfirmation.ToolTip = "Επιβεβαίωση Συμφωνίας Πίστωσης"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.DataSource = Me.VwCOLDBindingSource
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.GridControl1.Location = New System.Drawing.Point(25, 132)
        Me.GridControl1.MainView = Me.GridView6
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(2343, 1198)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6})
        '
        'VwCOLDBindingSource
        '
        Me.VwCOLDBindingSource.DataMember = "vw_COL_D"
        Me.VwCOLDBindingSource.DataSource = Me.Priamos_NETDataSet2
        '
        'GridView6
        '
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colold_code1, Me.colbdgNam2, Me.colaptNam, Me.colcompleteDate, Me.colCredit1, Me.coldebit4, Me.colBal1, Me.colmodifiedOn, Me.colcreatedOn, Me.colmodifiedBy, Me.colcreditUser, Me.coldebitUser, Me.colID, Me.colcode, Me.colcolID, Me.colbdgID, Me.colaptID, Me.colinhID, Me.coldebitusrID3, Me.colttl1, Me.coltenant1, Me.colagreed, Me.colfDate, Me.coltDate, Me.colETOS, Me.colord1})
        Me.GridView6.DetailHeight = 619
        Me.GridView6.GridControl = Me.GridControl1
        Me.GridView6.LevelIndent = 0
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsBehavior.Editable = False
        Me.GridView6.OptionsBehavior.ReadOnly = True
        Me.GridView6.OptionsLayout.StoreAllOptions = True
        Me.GridView6.OptionsLayout.StoreAppearance = True
        Me.GridView6.OptionsLayout.StoreFormatRules = True
        Me.GridView6.OptionsMenu.EnableGroupRowMenu = True
        Me.GridView6.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView6.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView6.OptionsMenu.ShowFooterItem = True
        Me.GridView6.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView6.OptionsPrint.PrintPreview = True
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsSelection.MultiSelect = True
        Me.GridView6.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView6.OptionsView.ColumnAutoWidth = False
        Me.GridView6.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView6.OptionsView.ShowFooter = True
        Me.GridView6.PreviewIndent = 0
        '
        'colold_code1
        '
        Me.colold_code1.Caption = "ΚΩΔΙΚΟΣ ΠΟΛΥΚΑΤΟΙΚΙΑΣ"
        Me.colold_code1.FieldName = "old_code"
        Me.colold_code1.MinWidth = 35
        Me.colold_code1.Name = "colold_code1"
        Me.colold_code1.Visible = True
        Me.colold_code1.VisibleIndex = 1
        Me.colold_code1.Width = 132
        '
        'colbdgNam2
        '
        Me.colbdgNam2.Caption = "ΠΟΛΥΚΑΤΟΙΚΙΑ"
        Me.colbdgNam2.FieldName = "bdgNam"
        Me.colbdgNam2.MinWidth = 35
        Me.colbdgNam2.Name = "colbdgNam2"
        Me.colbdgNam2.Visible = True
        Me.colbdgNam2.VisibleIndex = 2
        Me.colbdgNam2.Width = 132
        '
        'colaptNam
        '
        Me.colaptNam.Caption = "ΔΙΑΜΕΡΙΣΜΑ"
        Me.colaptNam.FieldName = "aptNam"
        Me.colaptNam.MinWidth = 35
        Me.colaptNam.Name = "colaptNam"
        Me.colaptNam.Visible = True
        Me.colaptNam.VisibleIndex = 3
        Me.colaptNam.Width = 132
        '
        'colcompleteDate
        '
        Me.colcompleteDate.Caption = "ΠΑΡΑΣΤΑΤΙΚΟ"
        Me.colcompleteDate.FieldName = "completeDate"
        Me.colcompleteDate.MinWidth = 35
        Me.colcompleteDate.Name = "colcompleteDate"
        Me.colcompleteDate.Visible = True
        Me.colcompleteDate.VisibleIndex = 4
        Me.colcompleteDate.Width = 132
        '
        'colCredit1
        '
        Me.colCredit1.Caption = "ΠΙΣΤΩΣΗ"
        Me.colCredit1.FieldName = "Credit"
        Me.colCredit1.MinWidth = 35
        Me.colCredit1.Name = "colCredit1"
        Me.colCredit1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "Σύνολο={0:c2}")})
        Me.colCredit1.Visible = True
        Me.colCredit1.VisibleIndex = 5
        Me.colCredit1.Width = 132
        '
        'coldebit4
        '
        Me.coldebit4.Caption = "ΧΡΕΩΣΗ"
        Me.coldebit4.FieldName = "debit"
        Me.coldebit4.MinWidth = 35
        Me.coldebit4.Name = "coldebit4"
        Me.coldebit4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "Σύνολο={0:c2}")})
        Me.coldebit4.Visible = True
        Me.coldebit4.VisibleIndex = 6
        Me.coldebit4.Width = 132
        '
        'colBal1
        '
        Me.colBal1.Caption = "ΥΠΟΛΟΙΠΟ"
        Me.colBal1.FieldName = "Bal"
        Me.colBal1.MinWidth = 35
        Me.colBal1.Name = "colBal1"
        Me.colBal1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bal", "Σύνολο={0:c2}")})
        Me.colBal1.Visible = True
        Me.colBal1.VisibleIndex = 7
        Me.colBal1.Width = 132
        '
        'colmodifiedOn
        '
        Me.colmodifiedOn.Caption = "ΗΜΕΡ/ΝΙΑ ΤΡΟΠΟΠΟΙΗΣΗΣ"
        Me.colmodifiedOn.FieldName = "modifiedOn"
        Me.colmodifiedOn.MinWidth = 35
        Me.colmodifiedOn.Name = "colmodifiedOn"
        Me.colmodifiedOn.Visible = True
        Me.colmodifiedOn.VisibleIndex = 8
        Me.colmodifiedOn.Width = 132
        '
        'colcreatedOn
        '
        Me.colcreatedOn.Caption = "ΗΜΕΡ/ΝΙΑ ΔΗΜΙΟΥΡΓΙΑΣ"
        Me.colcreatedOn.FieldName = "createdOn"
        Me.colcreatedOn.MinWidth = 35
        Me.colcreatedOn.Name = "colcreatedOn"
        Me.colcreatedOn.Visible = True
        Me.colcreatedOn.VisibleIndex = 9
        Me.colcreatedOn.Width = 132
        '
        'colmodifiedBy
        '
        Me.colmodifiedBy.Caption = "ΧΡΗΣΤΗΣ ΤΡΟΠΟΠΟΙΗΣΗΣ"
        Me.colmodifiedBy.FieldName = "modifiedBy"
        Me.colmodifiedBy.MinWidth = 35
        Me.colmodifiedBy.Name = "colmodifiedBy"
        Me.colmodifiedBy.Visible = True
        Me.colmodifiedBy.VisibleIndex = 10
        Me.colmodifiedBy.Width = 132
        '
        'colcreditUser
        '
        Me.colcreditUser.Caption = "ΧΡΗΣΤΗΣ ΠΙΣΤΩΣΗΣ"
        Me.colcreditUser.FieldName = "creditUser"
        Me.colcreditUser.MinWidth = 35
        Me.colcreditUser.Name = "colcreditUser"
        Me.colcreditUser.Visible = True
        Me.colcreditUser.VisibleIndex = 11
        Me.colcreditUser.Width = 132
        '
        'coldebitUser
        '
        Me.coldebitUser.Caption = "ΧΡΗΣΤΗΣ ΧΡΕΩΣΗΣ"
        Me.coldebitUser.FieldName = "debitUser"
        Me.coldebitUser.MinWidth = 35
        Me.coldebitUser.Name = "coldebitUser"
        Me.coldebitUser.Visible = True
        Me.coldebitUser.VisibleIndex = 12
        Me.coldebitUser.Width = 132
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.MinWidth = 35
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 13
        Me.colID.Width = 132
        '
        'colcode
        '
        Me.colcode.Caption = "ΚΩΔΙΚΟΣ ΕΙΣΠΡΑΞΗΣ"
        Me.colcode.FieldName = "code"
        Me.colcode.MinWidth = 35
        Me.colcode.Name = "colcode"
        Me.colcode.Visible = True
        Me.colcode.VisibleIndex = 14
        Me.colcode.Width = 132
        '
        'colcolID
        '
        Me.colcolID.Caption = "ID ΕΙΣΠΡΑΞΗΣ"
        Me.colcolID.FieldName = "colID"
        Me.colcolID.MinWidth = 35
        Me.colcolID.Name = "colcolID"
        Me.colcolID.Visible = True
        Me.colcolID.VisibleIndex = 15
        Me.colcolID.Width = 132
        '
        'colbdgID
        '
        Me.colbdgID.Caption = "ID ΠΟΛΥΚΑΤΟΙΚΙΑΣ"
        Me.colbdgID.FieldName = "bdgID"
        Me.colbdgID.MinWidth = 35
        Me.colbdgID.Name = "colbdgID"
        Me.colbdgID.Visible = True
        Me.colbdgID.VisibleIndex = 16
        Me.colbdgID.Width = 132
        '
        'colaptID
        '
        Me.colaptID.Caption = "ID ΔΙΑΜΕΡΙΣΜΑΤΟΣ"
        Me.colaptID.FieldName = "aptID"
        Me.colaptID.MinWidth = 35
        Me.colaptID.Name = "colaptID"
        Me.colaptID.Visible = True
        Me.colaptID.VisibleIndex = 17
        Me.colaptID.Width = 132
        '
        'colinhID
        '
        Me.colinhID.Caption = "ID ΠΑΡΑΣΤΑΤΙΚΟΥ"
        Me.colinhID.FieldName = "inhID"
        Me.colinhID.MinWidth = 35
        Me.colinhID.Name = "colinhID"
        Me.colinhID.Visible = True
        Me.colinhID.VisibleIndex = 18
        Me.colinhID.Width = 132
        '
        'coldebitusrID3
        '
        Me.coldebitusrID3.Caption = "ID ΧΡΗΣΤΗ ΧΡΕΩΣΗΣ"
        Me.coldebitusrID3.FieldName = "debitusrID"
        Me.coldebitusrID3.MinWidth = 35
        Me.coldebitusrID3.Name = "coldebitusrID3"
        Me.coldebitusrID3.Visible = True
        Me.coldebitusrID3.VisibleIndex = 19
        Me.coldebitusrID3.Width = 132
        '
        'colttl1
        '
        Me.colttl1.Caption = "ΤΙΤΛΟΣ"
        Me.colttl1.FieldName = "ttl"
        Me.colttl1.MinWidth = 35
        Me.colttl1.Name = "colttl1"
        Me.colttl1.Visible = True
        Me.colttl1.VisibleIndex = 20
        Me.colttl1.Width = 132
        '
        'coltenant1
        '
        Me.coltenant1.Caption = "ΕΝΟΙΚΟΣ"
        Me.coltenant1.FieldName = "tenant"
        Me.coltenant1.MinWidth = 35
        Me.coltenant1.Name = "coltenant1"
        Me.coltenant1.Visible = True
        Me.coltenant1.VisibleIndex = 21
        Me.coltenant1.Width = 132
        '
        'colagreed
        '
        Me.colagreed.Caption = "ΣΥΜΦΩΝΙΑ ΠΙΣΤΩΣΗΣ"
        Me.colagreed.FieldName = "agreed"
        Me.colagreed.MinWidth = 35
        Me.colagreed.Name = "colagreed"
        Me.colagreed.Visible = True
        Me.colagreed.VisibleIndex = 26
        Me.colagreed.Width = 132
        '
        'colfDate
        '
        Me.colfDate.FieldName = "fDate"
        Me.colfDate.MinWidth = 35
        Me.colfDate.Name = "colfDate"
        Me.colfDate.Visible = True
        Me.colfDate.VisibleIndex = 22
        Me.colfDate.Width = 132
        '
        'coltDate
        '
        Me.coltDate.FieldName = "tDate"
        Me.coltDate.MinWidth = 35
        Me.coltDate.Name = "coltDate"
        Me.coltDate.Visible = True
        Me.coltDate.VisibleIndex = 23
        Me.coltDate.Width = 132
        '
        'colETOS
        '
        Me.colETOS.FieldName = "ETOS"
        Me.colETOS.MinWidth = 35
        Me.colETOS.Name = "colETOS"
        Me.colETOS.Visible = True
        Me.colETOS.VisibleIndex = 24
        Me.colETOS.Width = 132
        '
        'colord1
        '
        Me.colord1.Caption = "AA"
        Me.colord1.FieldName = "ord"
        Me.colord1.MinWidth = 35
        Me.colord1.Name = "colord1"
        Me.colord1.Visible = True
        Me.colord1.VisibleIndex = 25
        Me.colord1.Width = 131
        '
        'cmdCol_Refresh
        '
        Me.cmdCol_Refresh.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Refresh
        Me.cmdCol_Refresh.Location = New System.Drawing.Point(12, 1391)
        Me.cmdCol_Refresh.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdCol_Refresh.Name = "cmdCol_Refresh"
        Me.cmdCol_Refresh.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdCol_Refresh.Size = New System.Drawing.Size(42, 40)
        Me.cmdCol_Refresh.StyleController = Me.LayoutControl1
        Me.cmdCol_Refresh.TabIndex = 6
        Me.cmdCol_Refresh.ToolTip = "Ανανέωση"
        Me.cmdCol_Refresh.Visible = False
        '
        'cboDebitUsr
        '
        Me.cboDebitUsr.Location = New System.Drawing.Point(389, 90)
        Me.cboDebitUsr.Margin = New System.Windows.Forms.Padding(5)
        Me.cboDebitUsr.Name = "cboDebitUsr"
        Me.cboDebitUsr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboDebitUsr.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboDebitUsr.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Χρήστης", 107, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboDebitUsr.Properties.DataSource = Me.VwUSRBindingSource
        Me.cboDebitUsr.Properties.DisplayMember = "RealName"
        Me.cboDebitUsr.Properties.NullText = ""
        Me.cboDebitUsr.Properties.PopupSizeable = False
        Me.cboDebitUsr.Properties.ValueMember = "ID"
        Me.cboDebitUsr.Size = New System.Drawing.Size(460, 38)
        Me.cboDebitUsr.StyleController = Me.LayoutControl1
        Me.cboDebitUsr.TabIndex = 2
        Me.cboDebitUsr.Tag = ""
        '
        'grdAPT
        '
        Me.grdAPT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdAPT.DataSource = Me.COLREPORTBindingSource
        Me.grdAPT.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.grdAPT.Location = New System.Drawing.Point(25, 62)
        Me.grdAPT.MainView = Me.GridView5
        Me.grdAPT.Margin = New System.Windows.Forms.Padding(5)
        Me.grdAPT.Name = "grdAPT"
        Me.grdAPT.Size = New System.Drawing.Size(2343, 1312)
        Me.grdAPT.TabIndex = 1
        Me.grdAPT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'COLREPORTBindingSource
        '
        Me.COLREPORTBindingSource.DataMember = "COL_REPORT"
        Me.COLREPORTBindingSource.DataSource = Me.Priamos_NETDataSet2
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colold_code2, Me.coldebit5, Me.colRealName1, Me.colBdgNam3, Me.colArea_Name1})
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
        'colold_code2
        '
        Me.colold_code2.FieldName = "old_code"
        Me.colold_code2.MinWidth = 35
        Me.colold_code2.Name = "colold_code2"
        Me.colold_code2.Visible = True
        Me.colold_code2.VisibleIndex = 0
        Me.colold_code2.Width = 131
        '
        'coldebit5
        '
        Me.coldebit5.FieldName = "debit"
        Me.coldebit5.MinWidth = 35
        Me.coldebit5.Name = "coldebit5"
        Me.coldebit5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "Σύνολο={0:c2}")})
        Me.coldebit5.Visible = True
        Me.coldebit5.VisibleIndex = 1
        Me.coldebit5.Width = 131
        '
        'colRealName1
        '
        Me.colRealName1.FieldName = "RealName"
        Me.colRealName1.MinWidth = 35
        Me.colRealName1.Name = "colRealName1"
        Me.colRealName1.Visible = True
        Me.colRealName1.VisibleIndex = 2
        Me.colRealName1.Width = 131
        '
        'colBdgNam3
        '
        Me.colBdgNam3.FieldName = "BdgNam"
        Me.colBdgNam3.MinWidth = 35
        Me.colBdgNam3.Name = "colBdgNam3"
        Me.colBdgNam3.Visible = True
        Me.colBdgNam3.VisibleIndex = 3
        Me.colBdgNam3.Width = 131
        '
        'colArea_Name1
        '
        Me.colArea_Name1.FieldName = "Area_Name"
        Me.colArea_Name1.MinWidth = 35
        Me.colArea_Name1.Name = "colArea_Name1"
        Me.colArea_Name1.Visible = True
        Me.colArea_Name1.VisibleIndex = 4
        Me.colArea_Name1.Width = 131
        '
        'cboINH
        '
        Me.cboINH.Location = New System.Drawing.Point(1646, 90)
        Me.cboINH.Margin = New System.Windows.Forms.Padding(5)
        Me.cboINH.Name = "cboINH"
        Me.cboINH.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboINH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboINH.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fDate", "Από Ημερ/νία", 67, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tDate", "t Date", 67, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nam", "nam", 52, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("cmt", "cmt", 47, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("completeDate", "Παραστατικό", 137, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Calculated", "Calculated", 102, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ahpb_HID", "ahpb_HID", 102, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mdt", "mdt", 48, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DateOfPrint", "Date Of Print", 123, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TotalInh", "Total Inh", 92, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("isPrinted", "is Printed", 92, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("announcement", "announcement", 142, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("extraordinary", "extraordinary", 127, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpc", "hpc", 47, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpb", "hpb", 48, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ETOS", "Έτος", 62, DevExpress.Utils.FormatType.Numeric, "", True, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboINH.Properties.DataSource = Me.VwINHBindingSource1
        Me.cboINH.Properties.DisplayMember = "completeDate"
        Me.cboINH.Properties.NullText = ""
        Me.cboINH.Properties.PopupSizeable = False
        Me.cboINH.Properties.ValueMember = "ID"
        Me.cboINH.Size = New System.Drawing.Size(722, 38)
        Me.cboINH.StyleController = Me.LayoutControl1
        Me.cboINH.TabIndex = 4
        Me.cboINH.Tag = ""
        '
        'VwINHBindingSource1
        '
        Me.VwINHBindingSource1.DataMember = "vw_INH"
        Me.VwINHBindingSource1.DataSource = Me.Priamos_NETDataSet2
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = CType(resources.GetObject("cmdExit.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(2189, 1391)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(192, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 7
        Me.cmdExit.Text = "Έξοδος"
        '
        'cboBDG
        '
        Me.cboBDG.Location = New System.Drawing.Point(971, 90)
        Me.cboBDG.Margin = New System.Windows.Forms.Padding(5)
        Me.cboBDG.Name = "cboBDG"
        Me.cboBDG.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboBDG.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboBDG.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 90, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nam", "Πολυκατοικία", 52, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdrID", "Adr ID", 70, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("cmt", "cmt", 47, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("aam", "aam", 52, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("iam", "iam", 45, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dts", "dts", 40, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_ID", "ADR_ID", 82, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Code", "ADR_Code", 103, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Name", "ADR_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tk", "tk", 32, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AreaID", "Area ID", 78, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CouID", "Cou ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_ID", "Area_ID", 83, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_Code", "Area_Code", 105, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_CouID", "Area_Cou ID", 122, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_Name", "Περιοχή", 112, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_ID", "COU_ID", 82, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Code", "COU_Code", 103, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Name", "COU_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ar", "ar", 32, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("prd", "prd", 43, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HTypeID", "HType ID", 95, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BTypeID", "BType ID", 93, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HTYPE_Name", "HTYPE_Name", 130, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BTYPE_Name", "BTYPE_Name", 128, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FBTYPE_Name", "FBTYPE_Name", 138, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FTypeID", "FType ID", 92, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpc", "hpc", 47, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpb", "hpb", 48, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("calH", "cal H", 57, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("calB", "cal B", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tacH", "tac H", 58, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tacB", "tac B", 57, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("lpcH", "lpc H", 58, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("lpcB", "lpc B", 57, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bCommon", "b Common", 107, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bSeperate", "b Seperate", 107, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bManageID", "b Manage ID", 125, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eName", "e Name", 80, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eCounter", "e Counter", 97, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ePaymentCode", "e Payment Code", 152, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eServiceNum", "e Service Num", 137, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fName", "f Name", 77, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fCounter", "f Counter", 93, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fPaymentCode", "f Payment Code", 147, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fServiceNum", "f Service Num", 133, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wName", "w Name", 83, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wCounter", "w Counter", 102, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wRegisterNum", "w Register Num", 148, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fUN", "f UN", 52, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fPWD", "f PWD", 67, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fCusCode", "f Cus Code", 105, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fHkasp", "f Hkasp", 78, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fDeposit", "f Deposit", 88, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("isManaged", "is Managed", 112, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManagerName", "Manager Name", 143, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("managerID", "manager ID", 117, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BdgNam", "Bdg Nam", 93, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("debit", "debit", 57, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("credit", "credit", 62, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bal", "bal", 40, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("debitusrID", "debitusr ID", 108, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtDebit", "dt Debit", 82, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtCredit", "dt Credit", 87, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboBDG.Properties.DataSource = Me.VwBDGBindingSource
        Me.cboBDG.Properties.DisplayMember = "nam"
        Me.cboBDG.Properties.NullText = ""
        Me.cboBDG.Properties.PopupSizeable = False
        Me.cboBDG.Properties.ValueMember = "ID"
        Me.cboBDG.Size = New System.Drawing.Size(671, 38)
        Me.cboBDG.StyleController = Me.LayoutControl1
        Me.cboBDG.TabIndex = 3
        Me.cboBDG.Tag = ""
        '
        'VwBDGBindingSource
        '
        Me.VwBDGBindingSource.DataMember = "vw_BDG"
        Me.VwBDGBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'chkShowAgree
        '
        Me.chkShowAgree.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkShowAgree.EditValue = True
        Me.chkShowAgree.Location = New System.Drawing.Point(2008, 1339)
        Me.chkShowAgree.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkShowAgree.Name = "chkShowAgree"
        Me.chkShowAgree.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.chkShowAgree.Properties.OffText = "Εμφάνιση Όλων"
        Me.chkShowAgree.Properties.OnText = "Εμφάνιση μη συμφωνηθέντων"
        Me.chkShowAgree.Size = New System.Drawing.Size(350, 35)
        Me.chkShowAgree.StyleController = Me.LayoutControl1
        Me.chkShowAgree.TabIndex = 1
        '
        'cboBDG1
        '
        Me.cboBDG1.Location = New System.Drawing.Point(25, 90)
        Me.cboBDG1.Margin = New System.Windows.Forms.Padding(5)
        Me.cboBDG1.Name = "cboBDG1"
        Me.cboBDG1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboBDG1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboBDG1.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 90, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nam", "Πολυκατοικια", 52, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdrID", "Adr ID", 70, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("cmt", "cmt", 47, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("aam", "aam", 52, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("iam", "iam", 45, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dts", "dts", 40, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_ID", "ADR_ID", 82, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Code", "ADR_Code", 103, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Name", "ADR_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tk", "tk", 32, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AreaID", "Area ID", 78, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CouID", "Cou ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_ID", "Area_ID", 83, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_Code", "Area_Code", 105, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_CouID", "Area_Cou ID", 122, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_Name", "Περιοχή", 112, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_ID", "COU_ID", 82, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Code", "COU_Code", 103, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Name", "COU_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ar", "ar", 32, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("prd", "prd", 43, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HTypeID", "HType ID", 95, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BTypeID", "BType ID", 93, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HTYPE_Name", "HTYPE_Name", 130, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BTYPE_Name", "BTYPE_Name", 128, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FBTYPE_Name", "FBTYPE_Name", 138, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FTypeID", "FType ID", 92, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpc", "hpc", 47, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpb", "hpb", 48, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("calH", "cal H", 57, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("calB", "cal B", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tacH", "tac H", 58, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tacB", "tac B", 57, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("lpcH", "lpc H", 58, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("lpcB", "lpc B", 57, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bCommon", "b Common", 107, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bSeperate", "b Seperate", 107, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bManageID", "b Manage ID", 125, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eName", "e Name", 80, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eCounter", "e Counter", 97, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ePaymentCode", "e Payment Code", 152, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eServiceNum", "e Service Num", 137, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fName", "f Name", 77, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fCounter", "f Counter", 93, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fPaymentCode", "f Payment Code", 147, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fServiceNum", "f Service Num", 133, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wName", "w Name", 83, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wCounter", "w Counter", 102, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wRegisterNum", "w Register Num", 148, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fUN", "f UN", 52, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fPWD", "f PWD", 67, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fCusCode", "f Cus Code", 105, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fHkasp", "f Hkasp", 78, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fDeposit", "f Deposit", 88, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("isManaged", "is Managed", 112, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManagerName", "Manager Name", 143, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("managerID", "manager ID", 117, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboBDG1.Properties.DataSource = Me.VwBDGBindingSource
        Me.cboBDG1.Properties.DisplayMember = "nam"
        Me.cboBDG1.Properties.NullText = ""
        Me.cboBDG1.Properties.PopupSizeable = False
        Me.cboBDG1.Properties.ValueMember = "ID"
        Me.cboBDG1.Size = New System.Drawing.Size(839, 38)
        Me.cboBDG1.StyleController = Me.LayoutControl1
        Me.cboBDG1.TabIndex = 1
        Me.cboBDG1.Tag = ""
        '
        'txtBDGCode
        '
        Me.txtBDGCode.Location = New System.Drawing.Point(853, 90)
        Me.txtBDGCode.Margin = New System.Windows.Forms.Padding(5)
        Me.txtBDGCode.Name = "txtBDGCode"
        Me.txtBDGCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtBDGCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtBDGCode.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtBDGCode.Properties.MaskSettings.Set("mask", "######")
        Me.txtBDGCode.Properties.Tag = "old_code,0,1,2"
        Me.txtBDGCode.Size = New System.Drawing.Size(114, 38)
        Me.txtBDGCode.StyleController = Me.LayoutControl1
        Me.txtBDGCode.TabIndex = 29
        Me.txtBDGCode.Tag = "old_code,0,1,2"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.TabbedControlGroup1, Me.LayoutControlItem6})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(2393, 1443)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(46, 1379)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(2131, 44)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdExit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(2177, 1379)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(196, 44)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup3
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(2373, 1379)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem11, Me.LayoutControlItem1, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem12, Me.EmptySpaceItem4, Me.LayoutControlItem97})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(2347, 1316)
        Me.LayoutControlGroup1.Text = "Οφειλές"
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cboBDG
        Me.LayoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem11.CustomizationFormText = "Κατηγορία"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(946, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(675, 70)
        Me.LayoutControlItem11.Text = "Πολυκατοικία"
        Me.LayoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(110, 23)
        Me.LayoutControlItem11.TextToControlDistance = 5
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboINH
        Me.LayoutControlItem1.Location = New System.Drawing.Point(1621, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(726, 70)
        Me.LayoutControlItem1.Text = "Παραστατικά"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(109, 23)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.grdBDG
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 70)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(2347, 1246)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboDebitUsr
        Me.LayoutControlItem5.Location = New System.Drawing.Point(364, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(464, 70)
        Me.LayoutControlItem5.Text = "Χρήστης Χρέωσης"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(152, 23)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.cmdColAdd
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(185, 70)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(185, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(179, 70)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem97
        '
        Me.LayoutControlItem97.Control = Me.txtBDGCode
        Me.LayoutControlItem97.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem97.CustomizationFormText = "Κωδικός"
        Me.LayoutControlItem97.Location = New System.Drawing.Point(828, 0)
        Me.LayoutControlItem97.Name = "LayoutControlItem97"
        Me.LayoutControlItem97.Size = New System.Drawing.Size(118, 70)
        Me.LayoutControlItem97.Text = "Κωδικός"
        Me.LayoutControlItem97.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem97.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem97.TextSize = New System.Drawing.Size(67, 23)
        Me.LayoutControlItem97.TextToControlDistance = 5
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(2347, 1316)
        Me.LayoutControlGroup2.Text = "Εκτύπωση Χρεώσεων"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.grdAPT
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(2347, 1316)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.BorderColor = System.Drawing.Color.Blue
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseBorderColor = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.EmptySpaceItem2, Me.LayoutControlItem9, Me.LayoutControlItem8, Me.LayoutControlItem10, Me.EmptySpaceItem3, Me.LayoutControlItem13, Me.EmptySpaceItem5, Me.EmptySpaceItem6})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(2347, 1316)
        Me.LayoutControlGroup3.Text = "Συμφωνία Πιστώσεων"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.GridControl1
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 70)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(2347, 1202)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(2337, 1272)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(10, 44)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.chkShowAgree
        Me.LayoutControlItem9.Location = New System.Drawing.Point(1983, 1272)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(354, 44)
        Me.LayoutControlItem9.Spacing = New DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 0)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cmdConfirmation
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 1272)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(280, 44)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.cboBDG1
        Me.LayoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem10.CustomizationFormText = "Κατηγορία"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(843, 70)
        Me.LayoutControlItem10.Text = "Πολυκατοικία"
        Me.LayoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(110, 23)
        Me.LayoutControlItem10.TextToControlDistance = 5
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(843, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1504, 70)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.cmdRestore
        Me.LayoutControlItem13.Location = New System.Drawing.Point(1723, 1272)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(260, 44)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(280, 1272)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(1350, 44)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(1630, 1272)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(93, 44)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdCol_Refresh
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 1379)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(46, 44)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'YEARSBindingSource
        '
        Me.YEARSBindingSource.DataMember = "YEARS"
        Me.YEARSBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'VwINHBindingSource
        '
        Me.VwINHBindingSource.DataMember = "vw_INH"
        Me.VwINHBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'vw_COL_INHBindingSource
        '
        Me.vw_COL_INHBindingSource.DataMember = "COL_INH"
        Me.vw_COL_INHBindingSource.DataSource = Me.Priamos_NETDataSet2
        '
        'vw_COLBindingSource
        '
        Me.vw_COLBindingSource.DataMember = "vw_COL"
        Me.vw_COLBindingSource.DataSource = Me.Priamos_NETDataSet2
        '
        'Vw_COL_METHODTableAdapter
        '
        Me.Vw_COL_METHODTableAdapter.ClearBeforeFill = True
        '
        'Vw_BANKSTableAdapter
        '
        Me.Vw_BANKSTableAdapter.ClearBeforeFill = True
        '
        'Vw_USRTableAdapter
        '
        Me.Vw_USRTableAdapter.ClearBeforeFill = True
        '
        'vw_COL_APTBindingSource
        '
        Me.vw_COL_APTBindingSource.DataMember = "COL_APT"
        Me.vw_COL_APTBindingSource.DataSource = Me.Priamos_NETDataSet2
        '
        'Vw_COL_BDGTableAdapter
        '
        Me.Vw_COL_BDGTableAdapter.ClearBeforeFill = True
        '
        'Vw_COLTableAdapter
        '
        Me.Vw_COLTableAdapter.ClearBeforeFill = True
        '
        'SvgImageCollection1
        '
        Me.SvgImageCollection1.Add("bo_address", "image://svgimages/business objects/bo_address.svg")
        Me.SvgImageCollection1.Add("bo_invoice", "image://svgimages/business objects/bo_invoice.svg")
        Me.SvgImageCollection1.Add("bo_employee", "image://svgimages/business objects/bo_employee.svg")
        '
        'COL_REPORTTableAdapter
        '
        Me.COL_REPORTTableAdapter.ClearBeforeFill = True
        '
        'colold_code
        '
        Me.colold_code.Caption = "ΚΩΔΙΚΟΣ"
        Me.colold_code.FieldName = "old_code"
        Me.colold_code.MinWidth = 35
        Me.colold_code.Name = "colold_code"
        Me.colold_code.OptionsColumn.AllowEdit = False
        Me.colold_code.Visible = True
        Me.colold_code.VisibleIndex = 0
        Me.colold_code.Width = 131
        '
        'colBdgNam1
        '
        Me.colBdgNam1.Caption = "ΠΟΛΥΚΑΤΟΙΚΙΑ"
        Me.colBdgNam1.FieldName = "BdgNam"
        Me.colBdgNam1.MinWidth = 35
        Me.colBdgNam1.Name = "colBdgNam1"
        Me.colBdgNam1.OptionsColumn.AllowEdit = False
        Me.colBdgNam1.Visible = True
        Me.colBdgNam1.VisibleIndex = 1
        Me.colBdgNam1.Width = 169
        '
        'coldebit1
        '
        Me.coldebit1.Caption = "ΧΡΕΩΣΗ"
        Me.coldebit1.FieldName = "debit"
        Me.coldebit1.MinWidth = 35
        Me.coldebit1.Name = "coldebit1"
        Me.coldebit1.OptionsColumn.AllowEdit = False
        Me.coldebit1.Visible = True
        Me.coldebit1.VisibleIndex = 3
        Me.coldebit1.Width = 131
        '
        'colRealName
        '
        Me.colRealName.Caption = "ΕΙΣΠΡΑΚΤΟΡΑΣ"
        Me.colRealName.FieldName = "RealName"
        Me.colRealName.MinWidth = 35
        Me.colRealName.Name = "colRealName"
        Me.colRealName.OptionsColumn.AllowEdit = False
        Me.colRealName.Visible = True
        Me.colRealName.VisibleIndex = 4
        Me.colRealName.Width = 168
        '
        'colArea_Name
        '
        Me.colArea_Name.Caption = "ΠΕΡΙΟΧΗ"
        Me.colArea_Name.FieldName = "Area_Name"
        Me.colArea_Name.MinWidth = 35
        Me.colArea_Name.Name = "colArea_Name"
        Me.colArea_Name.OptionsColumn.AllowEdit = False
        Me.colArea_Name.Visible = True
        Me.colArea_Name.VisibleIndex = 2
        Me.colArea_Name.Width = 131
        '
        'Vw_INHTableAdapter
        '
        Me.Vw_INHTableAdapter.ClearBeforeFill = True
        '
        'Vw_COL_DTableAdapter
        '
        Me.Vw_COL_DTableAdapter.ClearBeforeFill = True
        '
        'Vw_BDGTableAdapter
        '
        Me.Vw_BDGTableAdapter.ClearBeforeFill = True
        '
        'YEARSTableAdapter
        '
        Me.YEARSTableAdapter.ClearBeforeFill = True
        '
        'Bar2
        '
        Me.Bar2.BarName = "Custom 4"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Left
        Me.Bar2.FloatLocation = New System.Drawing.Point(49, 225)
        Me.Bar2.Offset = 3
        Me.Bar2.Text = "Custom 4"
        '
        'Bar1
        '
        Me.Bar1.BarName = "Custom 4"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Left
        Me.Bar1.FloatLocation = New System.Drawing.Point(49, 225)
        Me.Bar1.Offset = 3
        Me.Bar1.Text = "Custom 4"
        '
        'frmCollections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2380, 1434)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmCollections"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Εισπράξεις Κοινοχρήστων"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.grdVAPT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_FixAptBalance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_Credit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_DEBITUSR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwUSRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_ΒΑΝΚ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwBANKSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_COL_METHOD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwCOLMETHODBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBDG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwCOLBDGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVBDG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_AddnewCOL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVINH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVO_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwCOLDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDebitUsr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAPT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COLREPORTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboINH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINHBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwBDGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowAgree.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBDG1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBDGCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem97, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.YEARSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINHBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vw_COL_INHBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vw_COLBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vw_COL_APTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SvgImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents Priamos_NETDataSet As Priamos_NETDataSet
    Friend WithEvents VwCOLMETHODBindingSource As BindingSource
    Friend WithEvents Vw_COL_METHODTableAdapter As Priamos_NETDataSetTableAdapters.vw_COL_METHODTableAdapter
    Friend WithEvents VwBANKSBindingSource As BindingSource
    Friend WithEvents Vw_BANKSTableAdapter As Priamos_NETDataSetTableAdapters.vw_BANKSTableAdapter
    Friend WithEvents VwUSRBindingSource As BindingSource
    Friend WithEvents Vw_USRTableAdapter As Priamos_NETDataSetTableAdapters.vw_USRTableAdapter
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents Vw_USR_CREDITTableAdapter As Priamos_NETDataSetTableAdapters.vw_USR_creditTableAdapter
    'Friend WithEvents Vw_COLTableAdapter1 As Priamos_NETDataSet2TableAdapters.vw_COLTableAdapter
    Friend WithEvents grdBDG As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVBDG As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Priamos_NETDataSet2 As Priamos_NETDataSet2
    Friend WithEvents grdVAPT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdVINH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents vw_COL_APTBindingSource As BindingSource
    Friend WithEvents vw_COLBindingSource As BindingSource
    'Friend WithEvents Vw_COLTableAdapter2 As Priamos_NETDataSet2TableAdapters.vw_COLTableAdapter
    Friend WithEvents colttl2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcompleteDate1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VwCOLBDGBindingSource As BindingSource
    Friend WithEvents Vw_COL_BDGTableAdapter As Priamos_NETDataSet2TableAdapters.vw_COL_BDGTableAdapter
    Friend WithEvents grdVO_T As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents vw_COL_INHBindingSource As BindingSource
    Friend WithEvents Vw_COL_INHTableAdapter As Priamos_NETDataSet2TableAdapters.vw_COL_INHTableAdapter
    Friend WithEvents Vw_COLTableAdapter As Priamos_NETDataSet2TableAdapters.vw_COLTableAdapter
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltenant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebit2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcredit2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbal2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebit3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcredit3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbal3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colttl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Rep_DEBITUSR As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents coldebitusrID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBdgNam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcredit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebitusrID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebitusrID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SvgImageCollection1 As DevExpress.Utils.SvgImageCollection
    Friend WithEvents colbankID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Rep_ΒΑΝΚ As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colColMethodID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Rep_COL_METHOD As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents coldtDebit1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtCredit1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbankID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colColMethodID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtDebit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtCredit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDebitUsrID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboBDG As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboINH As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Rep_Credit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents colAptbal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents colcmt1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboDebitUsr As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colinhID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbdgID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colaptID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents COLREPORTBindingSource As BindingSource
    Friend WithEvents COL_REPORTTableAdapter As Priamos_NETDataSet2TableAdapters.COL_REPORTTableAdapter
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents colold_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBdgNam1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebit1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRealName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colArea_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdCol_Refresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwINHBindingSource As BindingSource
    Friend WithEvents VwINHBindingSource1 As BindingSource
    Friend WithEvents Vw_INHTableAdapter As Priamos_NETDataSet2TableAdapters.vw_INHTableAdapter
    Friend WithEvents grdAPT As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwCOLDBindingSource As BindingSource
    Friend WithEvents colold_code1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbdgNam2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colaptNam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcompleteDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCredit1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebit4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBal1 As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents coldebitusrID3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colttl1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltenant1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colagreed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Vw_COL_DTableAdapter As Priamos_NETDataSet2TableAdapters.vw_COL_DTableAdapter
    Friend WithEvents cmdConfirmation As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkShowAgree As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboBDG1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwBDGBindingSource As BindingSource
    Friend WithEvents Vw_BDGTableAdapter As Priamos_NETDataSetTableAdapters.vw_BDGTableAdapter
    Friend WithEvents YEARSBindingSource As BindingSource
    Friend WithEvents YEARSTableAdapter As Priamos_NETDataSetTableAdapters.YEARSTableAdapter
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents colfDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colETOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEtos1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colord As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBTN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Rep_AddnewCOL As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents cmdColAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents coldebitusrName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdRestore As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Rep_FixAptBalance As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ColFixBalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents colnam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colold_code2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldebit5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRealName1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBdgNam3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colArea_Name1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents colord1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtBDGCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem97 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colBdgCode As DevExpress.XtraGrid.Columns.GridColumn
End Class
