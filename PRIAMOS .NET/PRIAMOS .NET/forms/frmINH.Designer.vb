<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmINH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmINH))
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdAPM = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSelectedFiles = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.VwINDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PriamosNETDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet = New PRIAMOS.NET.Priamos_NETDataSet()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colinhID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcalcCatID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwCALCCATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.colpaid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdCancelCalculate = New DevExpress.XtraEditors.SimpleButton()
        Me.chkPrintReceipt = New DevExpress.XtraEditors.CheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.chkPrintEidop = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPrintSyg = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCalculated = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.txtHpb = New DevExpress.XtraEditors.TextEdit()
        Me.cboAhpbHB = New DevExpress.XtraEditors.LookUpEdit()
        Me.AHPBB = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblCancel = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancelInvoice = New DevExpress.XtraEditors.SimpleButton()
        Me.DataNavigator1 = New DevExpress.XtraEditors.DataNavigator()
        Me.vwINHBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkExtraordinary = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdNewInh = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPrintAll = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.cmdExport = New DevExpress.XtraEditors.SimpleButton()
        Me.lbldate = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCalculate = New DevExpress.XtraEditors.SimpleButton()
        Me.cboOwnerTenant = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cmdDel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSaveInd = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtComments = New DevExpress.XtraEditors.MemoEdit()
        Me.cmdSaveINH = New DevExpress.XtraEditors.SimpleButton()
        Me.cboBDG = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwBDGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtAmt = New DevExpress.XtraEditors.TextEdit()
        Me.chkCALC_CAT = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.dtFDate = New DevExpress.XtraEditors.DateEdit()
        Me.dtTDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtHeatingType = New DevExpress.XtraEditors.TextEdit()
        Me.txtBoilerType = New DevExpress.XtraEditors.TextEdit()
        Me.cboRepname = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwTTLBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboAhpbH = New DevExpress.XtraEditors.LookUpEdit()
        Me.AHPBH = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        Me.TabNavigationPage1 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.FlyoutPanel1 = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.cmdCancelMES = New DevExpress.XtraEditors.SimpleButton()
        Me.cboAhpbB = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboAhpb = New DevExpress.XtraEditors.LookUpEdit()
        Me.TabNavigationPage2 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridINH = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.apt = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.TabNavigationPage3 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.txtHpc = New DevExpress.XtraEditors.TextEdit()
        Me.cboAnnouncements = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwANNMENTSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtBdgCmt = New DevExpress.XtraEditors.MemoEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem53 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lCanceled = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem30 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem31 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem32 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem33 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem34 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem35 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.AHPBHBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VwINCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VwEXCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Vw_BDGTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_BDGTableAdapter()
        Me.Vw_EXCTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_EXCTableAdapter()
        Me.Vw_INDTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_INDTableAdapter()
        Me.Vw_CALC_CATTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_CALC_CATTableAdapter()
        Me.Vw_INCTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_INCTableAdapter()
        Me.Vw_TTLTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_TTLTableAdapter()
        Me.AHPB_H = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.AHPB_HTableAdapter()
        Me.XtraSaveFileDialog1 = New DevExpress.XtraEditors.XtraSaveFileDialog(Me.components)
        Me.Vw_ANN_MENTSTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_ANN_MENTSTableAdapter()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.PRIAMOS.NET.WaitForm), True, True)
        Me.XtraOpenFileDialog1 = New DevExpress.XtraEditors.XtraOpenFileDialog(Me.components)
        Me.Vw_INHTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_INHTableAdapter()
        Me.TableAdapterManager = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.TableAdapterManager()
        Me.AHPB_H1TableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.AHPB_H1TableAdapter()
        Me.AHPBH1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AHPB_Β = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.AHPB_ΒTableAdapter()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.LayoutControlItem36 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PriamosNETDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwCALCCATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.chkPrintReceipt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintEidop.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintSyg.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCalculated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHpb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAhpbHB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AHPBB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwINHBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExtraordinary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOwnerTenant.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwBDGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCALC_CAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHeatingType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBoilerType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRepname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwTTLBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAhpbH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AHPBH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPane1.SuspendLayout()
        Me.TabNavigationPage1.SuspendLayout()
        CType(Me.FlyoutPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanel1.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        CType(Me.cboAhpbB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAhpb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNavigationPage2.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridINH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNavigationPage3.SuspendLayout()
        CType(Me.txtHpc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAnnouncements.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwANNMENTSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBdgCmt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lCanceled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AHPBHBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwEXCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AHPBH1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView7
        '
        Me.GridView7.GridControl = Me.grdAPM
        Me.GridView7.Name = "GridView7"
        Me.GridView7.OptionsBehavior.Editable = False
        Me.GridView7.OptionsView.ShowGroupPanel = False
        '
        'grdAPM
        '
        Me.grdAPM.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.GridView7
        GridLevelNode1.RelationName = "ΧΙΛΙΟΣΤΑ ΜΕ ΜΕΙΩΣΕΙΣ"
        Me.grdAPM.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdAPM.Location = New System.Drawing.Point(0, 0)
        Me.grdAPM.MainView = Me.GridView1
        Me.grdAPM.Name = "grdAPM"
        Me.grdAPM.Size = New System.Drawing.Size(1045, 714)
        Me.grdAPM.TabIndex = 23
        Me.grdAPM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView7})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdAPM
        Me.GridView1.LevelIndent = 0
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowSort = False
        Me.GridView1.OptionsLayout.StoreAllOptions = True
        Me.GridView1.OptionsLayout.StoreAppearance = True
        Me.GridView1.OptionsLayout.StoreFormatRules = True
        Me.GridView1.OptionsPrint.PrintPreview = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.PreviewIndent = 0
        '
        'RepositoryItemLookUpEdit2
        '
        Me.RepositoryItemLookUpEdit2.AutoHeight = False
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.RepositoryItemLookUpEdit2.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 18, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Κατηγορία", 33, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemLookUpEdit2.DisplayMember = "name"
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.ValueMember = "ID"
        '
        'colSelectedFiles
        '
        Me.colSelectedFiles.FieldName = "SelectedFiles"
        Me.colSelectedFiles.Name = "colSelectedFiles"
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.VwINDBindingSource
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView5
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit3})
        Me.GridControl1.Size = New System.Drawing.Size(997, 713)
        Me.GridControl1.TabIndex = 54
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'VwINDBindingSource
        '
        Me.VwINDBindingSource.DataMember = "vw_IND"
        Me.VwINDBindingSource.DataSource = Me.PriamosNETDataSetBindingSource
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
        'GridView5
        '
        Me.GridView5.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colcode, Me.colinhID, Me.colcalcCatID, Me.colrepName, Me.colamt, Me.colmodifiedBy, Me.colmodifiedOn, Me.colcreatedOn, Me.colnam, Me.colfDate, Me.coltDate, Me.colname, Me.colowner_tenant, Me.colSelectedFiles, Me.colpaid})
        Me.GridView5.GridControl = Me.GridControl1
        Me.GridView5.GroupCount = 1
        Me.GridView5.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amt", Me.colamt, " Σύνολο {0:n2}€"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "name", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "owner_tenant", Nothing, "")})
        Me.GridView5.LevelIndent = 0
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsBehavior.AutoExpandAllGroups = True
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
        'colcalcCatID
        '
        Me.colcalcCatID.Caption = "Κατηγορία Υπολογισμού"
        Me.colcalcCatID.ColumnEdit = Me.RepositoryItemLookUpEdit3
        Me.colcalcCatID.FieldName = "calcCatID"
        Me.colcalcCatID.Name = "colcalcCatID"
        Me.colcalcCatID.Visible = True
        Me.colcalcCatID.VisibleIndex = 0
        Me.colcalcCatID.Width = 131
        '
        'RepositoryItemLookUpEdit3
        '
        Me.RepositoryItemLookUpEdit3.AutoHeight = False
        Me.RepositoryItemLookUpEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
        Me.RepositoryItemLookUpEdit3.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 21, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Κατηγορία", 37, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemLookUpEdit3.DataSource = Me.VwCALCCATBindingSource
        Me.RepositoryItemLookUpEdit3.DisplayMember = "name"
        Me.RepositoryItemLookUpEdit3.Name = "RepositoryItemLookUpEdit3"
        Me.RepositoryItemLookUpEdit3.ValueMember = "ID"
        '
        'VwCALCCATBindingSource
        '
        Me.VwCALCCATBindingSource.DataMember = "vw_CALC_CAT"
        Me.VwCALCCATBindingSource.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'colrepName
        '
        Me.colrepName.Caption = "Λεκτικό Εκτύπωσης"
        Me.colrepName.FieldName = "repName"
        Me.colrepName.Name = "colrepName"
        Me.colrepName.Visible = True
        Me.colrepName.VisibleIndex = 2
        Me.colrepName.Width = 181
        '
        'colamt
        '
        Me.colamt.Caption = "Ποσό"
        Me.colamt.FieldName = "amt"
        Me.colamt.Name = "colamt"
        Me.colamt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amt", "SUM={0:0.##}")})
        Me.colamt.Visible = True
        Me.colamt.VisibleIndex = 1
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
        '
        'colfDate
        '
        Me.colfDate.FieldName = "fDate"
        Me.colfDate.Name = "colfDate"
        '
        'coltDate
        '
        Me.coltDate.FieldName = "tDate"
        Me.coltDate.Name = "coltDate"
        '
        'colname
        '
        Me.colname.FieldName = "name"
        Me.colname.Name = "colname"
        Me.colname.Width = 139
        '
        'colowner_tenant
        '
        Me.colowner_tenant.Caption = "Ένοικος/Ιδιοκτήτης"
        Me.colowner_tenant.FieldName = "owner_tenant"
        Me.colowner_tenant.Name = "colowner_tenant"
        Me.colowner_tenant.Visible = True
        Me.colowner_tenant.VisibleIndex = 4
        '
        'colpaid
        '
        Me.colpaid.Caption = "Πληρώθηκε"
        Me.colpaid.FieldName = "paid"
        Me.colpaid.Name = "colpaid"
        Me.colpaid.Visible = True
        Me.colpaid.VisibleIndex = 3
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 18, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 33, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemLookUpEdit1.DisplayMember = "name"
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.RepositoryItemLookUpEdit1.ValueMember = "ID"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.CheckEdit1)
        Me.LayoutControl1.Controls.Add(Me.cmdCancelCalculate)
        Me.LayoutControl1.Controls.Add(Me.chkPrintReceipt)
        Me.LayoutControl1.Controls.Add(Me.chkPrintEidop)
        Me.LayoutControl1.Controls.Add(Me.chkPrintSyg)
        Me.LayoutControl1.Controls.Add(Me.chkCalculated)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.txtHpb)
        Me.LayoutControl1.Controls.Add(Me.cboAhpbHB)
        Me.LayoutControl1.Controls.Add(Me.lblCancel)
        Me.LayoutControl1.Controls.Add(Me.cmdCancelInvoice)
        Me.LayoutControl1.Controls.Add(Me.DataNavigator1)
        Me.LayoutControl1.Controls.Add(Me.chkExtraordinary)
        Me.LayoutControl1.Controls.Add(Me.cmdNewInh)
        Me.LayoutControl1.Controls.Add(Me.cmdPrintAll)
        Me.LayoutControl1.Controls.Add(Me.cmdExport)
        Me.LayoutControl1.Controls.Add(Me.lbldate)
        Me.LayoutControl1.Controls.Add(Me.cmdCalculate)
        Me.LayoutControl1.Controls.Add(Me.cboOwnerTenant)
        Me.LayoutControl1.Controls.Add(Me.cmdDel)
        Me.LayoutControl1.Controls.Add(Me.cmdRefresh)
        Me.LayoutControl1.Controls.Add(Me.cmdSaveInd)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Controls.Add(Me.txtComments)
        Me.LayoutControl1.Controls.Add(Me.cmdSaveINH)
        Me.LayoutControl1.Controls.Add(Me.cboBDG)
        Me.LayoutControl1.Controls.Add(Me.txtAmt)
        Me.LayoutControl1.Controls.Add(Me.chkCALC_CAT)
        Me.LayoutControl1.Controls.Add(Me.dtFDate)
        Me.LayoutControl1.Controls.Add(Me.dtTDate)
        Me.LayoutControl1.Controls.Add(Me.txtHeatingType)
        Me.LayoutControl1.Controls.Add(Me.txtBoilerType)
        Me.LayoutControl1.Controls.Add(Me.cboRepname)
        Me.LayoutControl1.Controls.Add(Me.cboAhpbH)
        Me.LayoutControl1.Controls.Add(Me.TabPane1)
        Me.LayoutControl1.Controls.Add(Me.txtHpc)
        Me.LayoutControl1.Controls.Add(Me.cboAnnouncements)
        Me.LayoutControl1.Controls.Add(Me.txtBdgCmt)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.MinimumSize = New System.Drawing.Size(0, 311)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(760, 228, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1520, 764)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdCancelCalculate
        '
        Me.cmdCancelCalculate.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_cancel_subscription_24
        Me.cmdCancelCalculate.Location = New System.Drawing.Point(249, 313)
        Me.cmdCancelCalculate.Name = "cmdCancelCalculate"
        Me.cmdCancelCalculate.Size = New System.Drawing.Size(144, 28)
        Me.cmdCancelCalculate.StyleController = Me.LayoutControl1
        Me.cmdCancelCalculate.TabIndex = 73
        Me.cmdCancelCalculate.Text = "Ακύρωση υπολογισμού"
        '
        'chkPrintReceipt
        '
        Me.chkPrintReceipt.EditValue = CType(0, Byte)
        Me.chkPrintReceipt.Location = New System.Drawing.Point(397, 7)
        Me.chkPrintReceipt.MenuManager = Me.BarManager1
        Me.chkPrintReceipt.Name = "chkPrintReceipt"
        Me.chkPrintReceipt.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkPrintReceipt.Properties.Appearance.ForeColor = System.Drawing.Color.Green
        Me.chkPrintReceipt.Properties.Appearance.Options.UseFont = True
        Me.chkPrintReceipt.Properties.Appearance.Options.UseForeColor = True
        Me.chkPrintReceipt.Properties.Caption = "ΑΠΟΔΕΙΞΗ"
        Me.chkPrintReceipt.Properties.ReadOnly = True
        Me.chkPrintReceipt.Properties.ValueChecked = CType(1, Byte)
        Me.chkPrintReceipt.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkPrintReceipt.Size = New System.Drawing.Size(93, 18)
        Me.chkPrintReceipt.StyleController = Me.LayoutControl1
        Me.chkPrintReceipt.TabIndex = 72
        Me.chkPrintReceipt.Tag = "isPrintedEisp,0"
        Me.chkPrintReceipt.ToolTipController = Me.ToolTipController1
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3})
        Me.BarManager1.MaxItemId = 3
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1520, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 764)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1520, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 764)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1520, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 764)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Συγκεντρωτική"
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Ειδοποιήσεις"
        Me.BarButtonItem2.Id = 1
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Αποδείξεις"
        Me.BarButtonItem3.Id = 2
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'ToolTipController1
        '
        Me.ToolTipController1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolTipController1.Appearance.Options.UseFont = True
        Me.ToolTipController1.Appearance.Options.UseTextOptions = True
        Me.ToolTipController1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.ToolTipController1.Rounded = True
        Me.ToolTipController1.ToolTipType = DevExpress.Utils.ToolTipType.Flyout
        '
        'chkPrintEidop
        '
        Me.chkPrintEidop.EditValue = CType(0, Byte)
        Me.chkPrintEidop.Location = New System.Drawing.Point(281, 7)
        Me.chkPrintEidop.MenuManager = Me.BarManager1
        Me.chkPrintEidop.Name = "chkPrintEidop"
        Me.chkPrintEidop.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkPrintEidop.Properties.Appearance.ForeColor = System.Drawing.Color.Green
        Me.chkPrintEidop.Properties.Appearance.Options.UseFont = True
        Me.chkPrintEidop.Properties.Appearance.Options.UseForeColor = True
        Me.chkPrintEidop.Properties.Caption = "ΕΙΔΟΠΟΙΗΣΗ"
        Me.chkPrintEidop.Properties.ReadOnly = True
        Me.chkPrintEidop.Properties.ValueChecked = CType(1, Byte)
        Me.chkPrintEidop.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkPrintEidop.Size = New System.Drawing.Size(114, 18)
        Me.chkPrintEidop.StyleController = Me.LayoutControl1
        Me.chkPrintEidop.TabIndex = 71
        Me.chkPrintEidop.Tag = "isPrintedEidop,0"
        Me.chkPrintEidop.ToolTipController = Me.ToolTipController1
        '
        'chkPrintSyg
        '
        Me.chkPrintSyg.EditValue = CType(0, Byte)
        Me.chkPrintSyg.Location = New System.Drawing.Point(140, 7)
        Me.chkPrintSyg.MenuManager = Me.BarManager1
        Me.chkPrintSyg.Name = "chkPrintSyg"
        Me.chkPrintSyg.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkPrintSyg.Properties.Appearance.ForeColor = System.Drawing.Color.Green
        Me.chkPrintSyg.Properties.Appearance.Options.UseFont = True
        Me.chkPrintSyg.Properties.Appearance.Options.UseForeColor = True
        Me.chkPrintSyg.Properties.Caption = "ΣΥΓΕΚΝΤΡΩΤΙΚΗ"
        Me.chkPrintSyg.Properties.ReadOnly = True
        Me.chkPrintSyg.Properties.ValueChecked = CType(1, Byte)
        Me.chkPrintSyg.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkPrintSyg.Size = New System.Drawing.Size(139, 18)
        Me.chkPrintSyg.StyleController = Me.LayoutControl1
        Me.chkPrintSyg.TabIndex = 70
        Me.chkPrintSyg.Tag = "isPrinted,0"
        Me.chkPrintSyg.ToolTipController = Me.ToolTipController1
        '
        'chkCalculated
        '
        Me.chkCalculated.EditValue = CType(0, Byte)
        Me.chkCalculated.Location = New System.Drawing.Point(7, 7)
        Me.chkCalculated.MenuManager = Me.BarManager1
        Me.chkCalculated.Name = "chkCalculated"
        Me.chkCalculated.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkCalculated.Properties.Appearance.ForeColor = System.Drawing.Color.Green
        Me.chkCalculated.Properties.Appearance.Options.UseFont = True
        Me.chkCalculated.Properties.Appearance.Options.UseForeColor = True
        Me.chkCalculated.Properties.Caption = "ΥΠΟΛΟΓΙΣΜΕΝΟ"
        Me.chkCalculated.Properties.ReadOnly = True
        Me.chkCalculated.Properties.ValueChecked = CType(1, Byte)
        Me.chkCalculated.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkCalculated.Size = New System.Drawing.Size(131, 18)
        Me.chkCalculated.StyleController = Me.LayoutControl1
        Me.chkCalculated.TabIndex = 69
        Me.chkCalculated.Tag = "Calculated,0"
        Me.chkCalculated.ToolTipController = Me.ToolTipController1
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(405, 729)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(85, 28)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 58
        Me.cmdExit.Text = "Έξοδος"
        '
        'txtHpb
        '
        Me.txtHpb.EditValue = "0"
        Me.txtHpb.Location = New System.Drawing.Point(361, 241)
        Me.txtHpb.Name = "txtHpb"
        Me.txtHpb.Properties.DisplayFormat.FormatString = "p0"
        Me.txtHpb.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHpb.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHpb.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtHpb.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtHpb.Properties.MaskSettings.Set("mask", "P0")
        Me.txtHpb.Properties.ReadOnly = True
        Me.txtHpb.Size = New System.Drawing.Size(122, 20)
        Me.txtHpb.StyleController = Me.LayoutControl1
        Me.txtHpb.TabIndex = 68
        Me.txtHpb.Tag = "hpb,0"
        '
        'cboAhpbHB
        '
        Me.cboAhpbHB.Location = New System.Drawing.Point(361, 263)
        Me.cboAhpbHB.Name = "cboAhpbHB"
        Me.cboAhpbHB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboAhpbHB.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 21, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 33, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 44, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mdt", "ΗΜΕΡ/ΝΙΑ ΜΕΤΡΗΣΗΣ", 29, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("finalized", "finalized", 50, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 65, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 54, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("boiler", "BOILER", 37, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAhpbHB.Properties.DataSource = Me.AHPBB
        Me.cboAhpbHB.Properties.DisplayMember = "mdt"
        Me.cboAhpbHB.Properties.NullText = ""
        Me.cboAhpbHB.Properties.ValueMember = "ID"
        Me.cboAhpbHB.Size = New System.Drawing.Size(122, 20)
        Me.cboAhpbHB.StyleController = Me.LayoutControl1
        Me.cboAhpbHB.TabIndex = 67
        Me.cboAhpbHB.Tag = "ahpb_HIDB,0"
        '
        'AHPBB
        '
        Me.AHPBB.DataMember = "AHPB_Β"
        Me.AHPBB.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'lblCancel
        '
        Me.lblCancel.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.lblCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCancel.Appearance.ForeColor = System.Drawing.Color.Red
        Me.lblCancel.Appearance.Options.UseFont = True
        Me.lblCancel.Appearance.Options.UseForeColor = True
        Me.lblCancel.Location = New System.Drawing.Point(14, 55)
        Me.lblCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(80, 16)
        Me.lblCancel.StyleController = Me.LayoutControl1
        Me.lblCancel.TabIndex = 66
        Me.lblCancel.Tag = "canceled,0"
        Me.lblCancel.Text = "ΑΚΥΡΩΜΕΝΟ"
        '
        'cmdCancelInvoice
        '
        Me.cmdCancelInvoice.Enabled = False
        Me.cmdCancelInvoice.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_cancel_subscription_24
        Me.cmdCancelInvoice.Location = New System.Drawing.Point(98, 313)
        Me.cmdCancelInvoice.Name = "cmdCancelInvoice"
        Me.cmdCancelInvoice.Size = New System.Drawing.Size(149, 28)
        Me.cmdCancelInvoice.StyleController = Me.LayoutControl1
        Me.cmdCancelInvoice.TabIndex = 58
        Me.cmdCancelInvoice.Text = "Ακύρωση Παραστατικού"
        '
        'DataNavigator1
        '
        Me.DataNavigator1.Appearance.BorderColor = System.Drawing.Color.Maroon
        Me.DataNavigator1.Appearance.Options.UseBorderColor = True
        Me.DataNavigator1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.DataNavigator1.Buttons.Append.Visible = False
        Me.DataNavigator1.Buttons.CancelEdit.Visible = False
        Me.DataNavigator1.Buttons.EndEdit.Visible = False
        Me.DataNavigator1.Buttons.NextPage.Visible = False
        Me.DataNavigator1.Buttons.PrevPage.Visible = False
        Me.DataNavigator1.Buttons.Remove.Visible = False
        Me.DataNavigator1.DataSource = Me.vwINHBindingSource
        Me.DataNavigator1.Location = New System.Drawing.Point(14, 285)
        Me.DataNavigator1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DataNavigator1.Name = "DataNavigator1"
        Me.DataNavigator1.Size = New System.Drawing.Size(241, 19)
        Me.DataNavigator1.StyleController = Me.LayoutControl1
        Me.DataNavigator1.TabIndex = 65
        Me.DataNavigator1.Text = "Παραστατικά"
        Me.DataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center
        Me.DataNavigator1.TextStringFormat = " Παραστατικά {0} of {1}"
        '
        'vwINHBindingSource
        '
        Me.vwINHBindingSource.DataMember = "vw_INH"
        Me.vwINHBindingSource.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'chkExtraordinary
        '
        Me.chkExtraordinary.EditValue = CType(0, Byte)
        Me.chkExtraordinary.Location = New System.Drawing.Point(193, 73)
        Me.chkExtraordinary.MenuManager = Me.BarManager1
        Me.chkExtraordinary.Name = "chkExtraordinary"
        Me.chkExtraordinary.Properties.Caption = "Έκτακτα"
        Me.chkExtraordinary.Properties.ValueChecked = CType(1, Byte)
        Me.chkExtraordinary.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkExtraordinary.Size = New System.Drawing.Size(74, 18)
        Me.chkExtraordinary.StyleController = Me.LayoutControl1
        Me.chkExtraordinary.TabIndex = 64
        Me.chkExtraordinary.Tag = "extraordinary,0,1,2"
        '
        'cmdNewInh
        '
        Me.cmdNewInh.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_new_file_24
        Me.cmdNewInh.Location = New System.Drawing.Point(7, 313)
        Me.cmdNewInh.Name = "cmdNewInh"
        Me.cmdNewInh.Size = New System.Drawing.Size(89, 28)
        Me.cmdNewInh.StyleController = Me.LayoutControl1
        Me.cmdNewInh.TabIndex = 63
        Me.cmdNewInh.Text = "Καθαρισμός"
        '
        'cmdPrintAll
        '
        Me.cmdPrintAll.DropDownControl = Me.PopupMenu1
        Me.cmdPrintAll.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_estimates_24
        Me.cmdPrintAll.Location = New System.Drawing.Point(151, 729)
        Me.cmdPrintAll.Name = "cmdPrintAll"
        Me.cmdPrintAll.Size = New System.Drawing.Size(128, 28)
        Me.cmdPrintAll.StyleController = Me.LayoutControl1
        Me.cmdPrintAll.TabIndex = 62
        Me.cmdPrintAll.Text = "Εκτύπωση"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem3)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'cmdExport
        '
        Me.cmdExport.ImageOptions.Image = CType(resources.GetObject("cmdExport.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdExport.Location = New System.Drawing.Point(492, 391)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdExport.Size = New System.Drawing.Size(22, 22)
        Me.cmdExport.StyleController = Me.LayoutControl1
        Me.cmdExport.TabIndex = 60
        Me.cmdExport.ToolTip = "Εξαγωγή σε Excel"
        '
        'lbldate
        '
        Me.lbldate.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbldate.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbldate.Appearance.Options.UseFont = True
        Me.lbldate.Appearance.Options.UseForeColor = True
        Me.lbldate.Location = New System.Drawing.Point(405, 73)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(78, 13)
        Me.lbldate.StyleController = Me.LayoutControl1
        Me.lbldate.TabIndex = 55
        Me.lbldate.Tag = "completeDate,0"
        Me.lbldate.Text = "ΗΜΕΡΟΜΗΝΙΑ"
        '
        'cmdCalculate
        '
        Me.cmdCalculate.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_estimates_24
        Me.cmdCalculate.Location = New System.Drawing.Point(281, 729)
        Me.cmdCalculate.Name = "cmdCalculate"
        Me.cmdCalculate.Size = New System.Drawing.Size(122, 28)
        Me.cmdCalculate.StyleController = Me.LayoutControl1
        Me.cmdCalculate.TabIndex = 53
        Me.cmdCalculate.Text = "Υπολογισμός"
        '
        'cboOwnerTenant
        '
        Me.cboOwnerTenant.Location = New System.Drawing.Point(126, 371)
        Me.cboOwnerTenant.Name = "cboOwnerTenant"
        Me.cboOwnerTenant.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboOwnerTenant.Properties.Items.AddRange(New Object() {"Ιδιοκτήτης", "Ένοικος"})
        Me.cboOwnerTenant.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboOwnerTenant.Size = New System.Drawing.Size(357, 20)
        Me.cboOwnerTenant.StyleController = Me.LayoutControl1
        Me.cboOwnerTenant.TabIndex = 51
        Me.cboOwnerTenant.Tag = "owner_tenant,0,1,2"
        '
        'cmdDel
        '
        Me.cmdDel.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Remove_16x16
        Me.cmdDel.Location = New System.Drawing.Point(492, 343)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdDel.Size = New System.Drawing.Size(22, 22)
        Me.cmdDel.StyleController = Me.LayoutControl1
        Me.cmdDel.TabIndex = 50
        '
        'cmdRefresh
        '
        Me.cmdRefresh.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_refresh_16
        Me.cmdRefresh.Location = New System.Drawing.Point(492, 367)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdRefresh.Size = New System.Drawing.Size(22, 22)
        Me.cmdRefresh.StyleController = Me.LayoutControl1
        Me.cmdRefresh.TabIndex = 49
        '
        'cmdSaveInd
        '
        Me.cmdSaveInd.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSaveInd.Location = New System.Drawing.Point(14, 437)
        Me.cmdSaveInd.Name = "cmdSaveInd"
        Me.cmdSaveInd.Size = New System.Drawing.Size(469, 28)
        Me.cmdSaveInd.StyleController = Me.LayoutControl1
        Me.cmdSaveInd.TabIndex = 48
        Me.cmdSaveInd.Text = "Καταχώρηση Εξόδου"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(126, 73)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(65, 20)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 47
        Me.txtCode.Tag = "code,0"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(124, 162)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(359, 33)
        Me.txtComments.StyleController = Me.LayoutControl1
        Me.txtComments.TabIndex = 46
        Me.txtComments.Tag = "cmt,0,1,2"
        '
        'cmdSaveINH
        '
        Me.cmdSaveINH.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSaveINH.Location = New System.Drawing.Point(395, 313)
        Me.cmdSaveINH.Name = "cmdSaveINH"
        Me.cmdSaveINH.Size = New System.Drawing.Size(95, 28)
        Me.cmdSaveINH.StyleController = Me.LayoutControl1
        Me.cmdSaveINH.TabIndex = 45
        Me.cmdSaveINH.Text = "Καταχώρηση"
        '
        'cboBDG
        '
        Me.cboBDG.Location = New System.Drawing.Point(126, 95)
        Me.cboBDG.Name = "cboBDG"
        Me.cboBDG.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboBDG.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboBDG.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboBDG.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 18, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 30, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 50, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nam", "Όνομα", 63, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdrID", "Adr ID", 38, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("cmt", "Σχόλια", 24, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("aam", "aam", 27, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("iam", "iam", 23, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dts", "dts", 22, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtu", "dtu", 23, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("iad", "iad", 21, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 62, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 64, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 61, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_ID", "ADR_ID", 45, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Code", "ADR_Code", 59, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Name", "Διέυθυνση", 61, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tk", "tk", 16, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AreaID", "Area ID", 44, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CouID", "Cou ID", 40, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_ID", "Area_ID", 47, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_Code", "Area_Code", 61, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_CouID", "Area_Cou ID", 69, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_Name", "Περιοχή", 63, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_ID", "COU_ID", 46, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Code", "COU_Code", 60, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Name", "COU_Name", 62, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ar", "ar", 17, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("prd", "prd", 23, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("rmg", "rmg", 25, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HTypeID", "HType ID", 52, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BTypeID", "BType ID", 51, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HTYPE_Name", "HTYPE_Name", 71, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BTYPE_Name", "BTYPE_Name", 70, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FBTYPE_Name", "FBTYPE_Name", 76, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FTypeID", "FType ID", 51, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpc", "hpc", 24, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpb", "hpb", 25, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("calH", "cal H", 30, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("calB", "cal B", 29, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tacH", "tac H", 32, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tacB", "tac B", 31, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("lpcH", "lpc H", 30, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("lpcB", "lpc B", 29, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bCommon", "b Common", 57, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bSeperate", "b Seperate", 60, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bManageID", "b Manage ID", 68, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eName", "e Name", 43, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eCounter", "e Counter", 55, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ePaymentCode", "e Payment Code", 86, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eServiceNum", "e Service Num", 75, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fName", "f Name", 41, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fCounter", "f Counter", 53, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fPaymentCode", "f Payment Code", 84, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fServiceNum", "f Service Num", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wName", "w Name", 45, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wCounter", "w Counter", 57, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wRegisterNum", "w Register Num", 82, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fUN", "f UN", 28, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fPWD", "f PWD", 37, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fCusCode", "f Cus Code", 60, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fHkasp", "f Hkasp", 43, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fDeposit", "f Deposit", 50, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("isManaged", "is Managed", 61, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboBDG.Properties.DataSource = Me.VwBDGBindingSource
        Me.cboBDG.Properties.DisplayMember = "nam"
        Me.cboBDG.Properties.NullText = ""
        Me.cboBDG.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboBDG.Properties.PopupSizeable = False
        Me.cboBDG.Properties.ValueMember = "ID"
        Me.cboBDG.Size = New System.Drawing.Size(357, 20)
        Me.cboBDG.StyleController = Me.LayoutControl1
        Me.cboBDG.TabIndex = 44
        Me.cboBDG.Tag = "bdgid,0,1,2"
        '
        'VwBDGBindingSource
        '
        Me.VwBDGBindingSource.DataMember = "vw_BDG"
        Me.VwBDGBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'txtAmt
        '
        Me.txtAmt.EditValue = "0,00 €"
        Me.txtAmt.Location = New System.Drawing.Point(126, 415)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Properties.DisplayFormat.FormatString = "c"
        Me.txtAmt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmt.Properties.EditFormat.FormatString = "n2"
        Me.txtAmt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmt.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtAmt.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtAmt.Properties.MaskSettings.Set("mask", "c2")
        Me.txtAmt.Properties.Tag = "BenchExtraPrice"
        Me.txtAmt.Size = New System.Drawing.Size(357, 20)
        Me.txtAmt.StyleController = Me.LayoutControl1
        Me.txtAmt.TabIndex = 43
        Me.txtAmt.Tag = "amt,0,1,2"
        '
        'chkCALC_CAT
        '
        Me.chkCALC_CAT.CheckMode = DevExpress.XtraEditors.CheckMode.[Single]
        Me.chkCALC_CAT.CheckOnClick = True
        Me.chkCALC_CAT.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chkCALC_CAT.DataSource = Me.VwCALCCATBindingSource
        Me.chkCALC_CAT.DisplayMember = "name"
        Me.chkCALC_CAT.HorizontalScrollbar = True
        Me.chkCALC_CAT.Location = New System.Drawing.Point(14, 467)
        Me.chkCALC_CAT.Name = "chkCALC_CAT"
        Me.chkCALC_CAT.Size = New System.Drawing.Size(469, 253)
        Me.chkCALC_CAT.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.chkCALC_CAT.StyleController = Me.LayoutControl1
        Me.chkCALC_CAT.TabIndex = 28
        Me.chkCALC_CAT.Tag = ""
        Me.chkCALC_CAT.ValueMember = "ID"
        '
        'dtFDate
        '
        Me.dtFDate.EditValue = Nothing
        Me.dtFDate.Location = New System.Drawing.Point(126, 117)
        Me.dtFDate.Name = "dtFDate"
        Me.dtFDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFDate.Properties.MaskSettings.Set("mask", "d")
        Me.dtFDate.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtFDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtFDate.Size = New System.Drawing.Size(154, 20)
        Me.dtFDate.StyleController = Me.LayoutControl1
        Me.dtFDate.TabIndex = 38
        Me.dtFDate.Tag = "fDate,0,1,2"
        '
        'dtTDate
        '
        Me.dtTDate.EditValue = Nothing
        Me.dtTDate.Location = New System.Drawing.Point(319, 117)
        Me.dtTDate.Name = "dtTDate"
        Me.dtTDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtTDate.Size = New System.Drawing.Size(164, 20)
        Me.dtTDate.StyleController = Me.LayoutControl1
        Me.dtTDate.TabIndex = 38
        Me.dtTDate.Tag = "tDate,0,1,2"
        '
        'txtHeatingType
        '
        Me.txtHeatingType.Location = New System.Drawing.Point(126, 219)
        Me.txtHeatingType.Name = "txtHeatingType"
        Me.txtHeatingType.Properties.ReadOnly = True
        Me.txtHeatingType.Size = New System.Drawing.Size(121, 20)
        Me.txtHeatingType.StyleController = Me.LayoutControl1
        Me.txtHeatingType.TabIndex = 46
        Me.txtHeatingType.Tag = ""
        '
        'txtBoilerType
        '
        Me.txtBoilerType.Location = New System.Drawing.Point(126, 241)
        Me.txtBoilerType.Name = "txtBoilerType"
        Me.txtBoilerType.Properties.ReadOnly = True
        Me.txtBoilerType.Size = New System.Drawing.Size(121, 20)
        Me.txtBoilerType.StyleController = Me.LayoutControl1
        Me.txtBoilerType.TabIndex = 46
        Me.txtBoilerType.Tag = ""
        '
        'cboRepname
        '
        Me.cboRepname.Location = New System.Drawing.Point(126, 393)
        Me.cboRepname.Name = "cboRepname"
        Me.cboRepname.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboRepname.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboRepname.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 18, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 33, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboRepname.Properties.DataSource = Me.VwTTLBindingSource
        Me.cboRepname.Properties.DisplayMember = "name"
        Me.cboRepname.Properties.NullText = ""
        Me.cboRepname.Properties.PopupSizeable = False
        Me.cboRepname.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboRepname.Properties.ValueMember = "name"
        Me.cboRepname.Size = New System.Drawing.Size(357, 20)
        Me.cboRepname.StyleController = Me.LayoutControl1
        Me.cboRepname.TabIndex = 29
        Me.cboRepname.Tag = "repname,0,1,2"
        '
        'VwTTLBindingSource
        '
        Me.VwTTLBindingSource.DataMember = "vw_TTL"
        Me.VwTTLBindingSource.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'cboAhpbH
        '
        Me.cboAhpbH.Location = New System.Drawing.Point(126, 263)
        Me.cboAhpbH.Name = "cboAhpbH"
        Me.cboAhpbH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboAhpbH.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 21, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 33, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 44, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mdt", "ΗΜΕΡ/ΝΙΑ ΜΕΤΡΗΣΗΣ", 29, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("finalized", "finalized", 50, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 65, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 54, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("boiler", "BOILER", 37, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAhpbH.Properties.DataSource = Me.AHPBH
        Me.cboAhpbH.Properties.DisplayMember = "mdt"
        Me.cboAhpbH.Properties.NullText = ""
        Me.cboAhpbH.Properties.ValueMember = "ID"
        Me.cboAhpbH.Size = New System.Drawing.Size(121, 20)
        Me.cboAhpbH.StyleController = Me.LayoutControl1
        Me.cboAhpbH.TabIndex = 46
        Me.cboAhpbH.Tag = "ahpb_HID,0"
        '
        'AHPBH
        '
        Me.AHPBH.DataMember = "AHPB_H"
        Me.AHPBH.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'TabPane1
        '
        Me.TabPane1.Controls.Add(Me.TabNavigationPage1)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage2)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage3)
        Me.TabPane1.Location = New System.Drawing.Point(516, 7)
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPage1, Me.TabNavigationPage2, Me.TabNavigationPage3})
        Me.TabPane1.RegularSize = New System.Drawing.Size(997, 750)
        Me.TabPane1.SelectedPage = Me.TabNavigationPage1
        Me.TabPane1.Size = New System.Drawing.Size(997, 750)
        Me.TabPane1.TabIndex = 54
        Me.TabPane1.Text = "Χιλιοστά Διαμερισμάτων"
        '
        'TabNavigationPage1
        '
        Me.TabNavigationPage1.Caption = "Έξοδα"
        Me.TabNavigationPage1.Controls.Add(Me.FlyoutPanel1)
        Me.TabNavigationPage1.Controls.Add(Me.GridControl1)
        Me.TabNavigationPage1.Name = "TabNavigationPage1"
        Me.TabNavigationPage1.Size = New System.Drawing.Size(997, 713)
        '
        'FlyoutPanel1
        '
        Me.FlyoutPanel1.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanel1.Location = New System.Drawing.Point(307, 211)
        Me.FlyoutPanel1.Name = "FlyoutPanel1"
        Me.FlyoutPanel1.Size = New System.Drawing.Size(443, 140)
        Me.FlyoutPanel1.TabIndex = 57
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.FlyoutPanelControl1.Controls.Add(Me.cmdCancelMES)
        Me.FlyoutPanelControl1.Controls.Add(Me.cboAhpbB)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl2)
        Me.FlyoutPanelControl1.Controls.Add(Me.cmdOK)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl1)
        Me.FlyoutPanelControl1.Controls.Add(Me.cboAhpb)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanel1
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(443, 140)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'cmdCancelMES
        '
        Me.cmdCancelMES.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdCancelMES.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelMES.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdCancelMES.Location = New System.Drawing.Point(344, 78)
        Me.cmdCancelMES.Name = "cmdCancelMES"
        Me.cmdCancelMES.Size = New System.Drawing.Size(80, 28)
        Me.cmdCancelMES.TabIndex = 61
        Me.cmdCancelMES.Text = "Ακύρωση"
        '
        'cboAhpbB
        '
        Me.cboAhpbB.Location = New System.Drawing.Point(228, 44)
        Me.cboAhpbB.Name = "cboAhpbB"
        Me.cboAhpbB.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboAhpbB.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboAhpbB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAhpbB.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 21, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 33, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 44, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mdt", "ΗΜΕΡ/ΝΙΑ ΜΕΤΡΗΣΗΣ", 29, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("finalized", "finalized", 50, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 65, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 54, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("boiler", "BOILER", 37, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAhpbB.Properties.DataSource = Me.AHPBB
        Me.cboAhpbB.Properties.DisplayMember = "mdt"
        Me.cboAhpbB.Properties.NullText = ""
        Me.cboAhpbB.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboAhpbB.Properties.PopupSizeable = False
        Me.cboAhpbB.Properties.ValueMember = "ID"
        Me.cboAhpbB.Size = New System.Drawing.Size(193, 20)
        Me.cboAhpbB.StyleController = Me.LayoutControl1
        Me.cboAhpbB.TabIndex = 60
        Me.cboAhpbB.Tag = "bdgid,0,1,2"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(228, 25)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(112, 13)
        Me.LabelControl2.TabIndex = 59
        Me.LabelControl2.Text = "Ώρες Μετρήσεων Boiler"
        '
        'cmdOK
        '
        Me.cmdOK.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_estimates_24
        Me.cmdOK.Location = New System.Drawing.Point(254, 79)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(74, 28)
        Me.cmdOK.StyleController = Me.LayoutControl1
        Me.cmdOK.TabIndex = 57
        Me.cmdOK.Text = "OK"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 25)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(140, 13)
        Me.LabelControl1.TabIndex = 56
        Me.LabelControl1.Text = "Ώρες Μετρήσεων Θέρμανσης"
        '
        'cboAhpb
        '
        Me.cboAhpb.Location = New System.Drawing.Point(5, 44)
        Me.cboAhpb.Name = "cboAhpb"
        Me.cboAhpb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboAhpb.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboAhpb.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAhpb.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 21, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 33, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 44, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mdt", "ΗΜΕΡ/ΝΙΑ ΜΕΤΡΗΣΗΣ", 29, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("finalized", "finalized", 50, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 65, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 54, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("boiler", "BOILER", 37, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAhpb.Properties.DataSource = Me.AHPBH
        Me.cboAhpb.Properties.DisplayMember = "mdt"
        Me.cboAhpb.Properties.NullText = ""
        Me.cboAhpb.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboAhpb.Properties.PopupSizeable = False
        Me.cboAhpb.Properties.ValueMember = "ID"
        Me.cboAhpb.Size = New System.Drawing.Size(182, 20)
        Me.cboAhpb.StyleController = Me.LayoutControl1
        Me.cboAhpb.TabIndex = 55
        Me.cboAhpb.Tag = "bdgid,0,1,2"
        '
        'TabNavigationPage2
        '
        Me.TabNavigationPage2.Caption = "Υπολογισμένα"
        Me.TabNavigationPage2.Controls.Add(Me.GridControl2)
        Me.TabNavigationPage2.Name = "TabNavigationPage2"
        Me.TabNavigationPage2.Size = New System.Drawing.Size(1045, 714)
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridINH
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1045, 714)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridINH})
        '
        'GridINH
        '
        Me.GridINH.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.apt})
        Me.GridINH.GridControl = Me.GridControl2
        Me.GridINH.Name = "GridINH"
        Me.GridINH.OptionsBehavior.Editable = False
        Me.GridINH.OptionsBehavior.ReadOnly = True
        Me.GridINH.OptionsCustomization.AllowChangeColumnParent = True
        Me.GridINH.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast
        Me.GridINH.OptionsView.ShowFooter = True
        Me.GridINH.OptionsView.ShowGroupPanel = False
        '
        'apt
        '
        Me.apt.Name = "apt"
        Me.apt.VisibleIndex = 0
        Me.apt.Width = 158
        '
        'TabNavigationPage3
        '
        Me.TabNavigationPage3.Caption = "Χιλιοστά Διαμερισμάτων"
        Me.TabNavigationPage3.Controls.Add(Me.grdAPM)
        Me.TabNavigationPage3.Name = "TabNavigationPage3"
        Me.TabNavigationPage3.Size = New System.Drawing.Size(1045, 714)
        '
        'txtHpc
        '
        Me.txtHpc.EditValue = "0"
        Me.txtHpc.Location = New System.Drawing.Point(361, 219)
        Me.txtHpc.Name = "txtHpc"
        Me.txtHpc.Properties.DisplayFormat.FormatString = "p0"
        Me.txtHpc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHpc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHpc.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtHpc.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtHpc.Properties.MaskSettings.Set("mask", "P0")
        Me.txtHpc.Properties.ReadOnly = True
        Me.txtHpc.Size = New System.Drawing.Size(122, 20)
        Me.txtHpc.StyleController = Me.LayoutControl1
        Me.txtHpc.TabIndex = 8
        Me.txtHpc.Tag = "hpc,0"
        '
        'cboAnnouncements
        '
        Me.cboAnnouncements.Location = New System.Drawing.Point(126, 197)
        Me.cboAnnouncements.Name = "cboAnnouncements"
        Me.cboAnnouncements.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboAnnouncements.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboAnnouncements.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 18, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 33, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAnnouncements.Properties.DataSource = Me.VwANNMENTSBindingSource
        Me.cboAnnouncements.Properties.DisplayMember = "name"
        Me.cboAnnouncements.Properties.NullText = ""
        Me.cboAnnouncements.Properties.PopupSizeable = False
        Me.cboAnnouncements.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboAnnouncements.Properties.ValueMember = "name"
        Me.cboAnnouncements.Size = New System.Drawing.Size(357, 20)
        Me.cboAnnouncements.StyleController = Me.LayoutControl1
        Me.cboAnnouncements.TabIndex = 29
        Me.cboAnnouncements.Tag = "announcement,0,1,2"
        Me.cboAnnouncements.ToolTipController = Me.ToolTipController1
        '
        'VwANNMENTSBindingSource
        '
        Me.VwANNMENTSBindingSource.DataMember = "vw_ANN_MENTS"
        Me.VwANNMENTSBindingSource.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'txtBdgCmt
        '
        Me.txtBdgCmt.Location = New System.Drawing.Point(124, 139)
        Me.txtBdgCmt.Name = "txtBdgCmt"
        Me.txtBdgCmt.Properties.ReadOnly = True
        Me.txtBdgCmt.Size = New System.Drawing.Size(359, 21)
        Me.txtBdgCmt.StyleController = Me.LayoutControl1
        Me.txtBdgCmt.TabIndex = 17
        Me.txtBdgCmt.Tag = ""
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.EmptySpaceItem3, Me.EmptySpaceItem4, Me.LayoutControlItem16, Me.LayoutControlItem17, Me.LayoutControlItem18, Me.EmptySpaceItem5, Me.LayoutControlItem23, Me.EmptySpaceItem7, Me.LayoutControlItem29, Me.LayoutControlItem31, Me.LayoutControlItem32, Me.LayoutControlItem33, Me.LayoutControlItem34, Me.LayoutControlItem21, Me.LayoutControlItem26, Me.LayoutControlItem7, Me.LayoutControlItem35, Me.EmptySpaceItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1520, 764)
        Me.Root.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem53, Me.LayoutControlItem6, Me.LayoutControlItem5, Me.LayoutControlItem9, Me.LayoutControlItem1, Me.LayoutControlItem15, Me.LayoutControlItem14, Me.LayoutControlItem19, Me.LayoutControlItem8, Me.LayoutControlItem20, Me.LayoutControlItem22, Me.EmptySpaceItem2, Me.LayoutControlItem24, Me.lCanceled, Me.LayoutControlItem27, Me.LayoutControlItem28, Me.LayoutControlItem30, Me.LayoutControlItem25, Me.LayoutControlItem36})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 20)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(485, 286)
        Me.LayoutControlGroup1.Text = "Στοιχεία Παραστατικού"
        '
        'LayoutControlItem53
        '
        Me.LayoutControlItem53.Control = Me.dtFDate
        Me.LayoutControlItem53.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem53.CustomizationFormText = "Ημερομηνία Τιμ."
        Me.LayoutControlItem53.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem53.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem53.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem53.Location = New System.Drawing.Point(0, 62)
        Me.LayoutControlItem53.Name = "LayoutControlItem53"
        Me.LayoutControlItem53.Size = New System.Drawing.Size(268, 22)
        Me.LayoutControlItem53.Tag = "1"
        Me.LayoutControlItem53.Text = "Από"
        Me.LayoutControlItem53.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.dtTDate
        Me.LayoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem6.CustomizationFormText = "Ημερομηνία Τιμ."
        Me.LayoutControlItem6.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem6.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem6.Location = New System.Drawing.Point(268, 62)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(203, 22)
        Me.LayoutControlItem6.Tag = "1"
        Me.LayoutControlItem6.Text = "Έως"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(32, 13)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboBDG
        Me.LayoutControlItem5.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem5.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(471, 22)
        Me.LayoutControlItem5.Tag = "1"
        Me.LayoutControlItem5.Text = "Πολυκατοικία"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtCode
        Me.LayoutControlItem9.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 18)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(179, 22)
        Me.LayoutControlItem9.Text = "Κωδικός"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtHeatingType
        Me.LayoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem1.CustomizationFormText = "Σχόλια"
        Me.LayoutControlItem1.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 164)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(235, 22)
        Me.LayoutControlItem1.Text = "Τύπος Θέρμανσης"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.txtBoilerType
        Me.LayoutControlItem15.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem15.CustomizationFormText = "Σχόλια"
        Me.LayoutControlItem15.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 186)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(235, 22)
        Me.LayoutControlItem15.Text = "Τύπος Boiler"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.lbldate
        Me.LayoutControlItem14.Location = New System.Drawing.Point(391, 18)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(80, 22)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.cboAhpbH
        Me.LayoutControlItem19.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem19.CustomizationFormText = "Σχόλια"
        Me.LayoutControlItem19.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 208)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(235, 22)
        Me.LayoutControlItem19.Text = "Ώρες Μετρ."
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem8.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LayoutControlItem8.Control = Me.txtComments
        Me.LayoutControlItem8.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 107)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.OptionsPrint.AppearanceItem.Options.UseTextOptions = True
        Me.LayoutControlItem8.OptionsPrint.AppearanceItem.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LayoutControlItem8.Size = New System.Drawing.Size(471, 35)
        Me.LayoutControlItem8.Text = "Γενικές σημειώσεις πραστατικού"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Left
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(109, 13)
        Me.LayoutControlItem8.TextToControlDistance = 1
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.txtHpc
        Me.LayoutControlItem20.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem20.CustomizationFormText = "Πάγιο Θέρμανσης"
        Me.LayoutControlItem20.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem20.Location = New System.Drawing.Point(235, 164)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(236, 22)
        Me.LayoutControlItem20.Text = "Πάγιο Θέρμανσης"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.cboAnnouncements
        Me.LayoutControlItem22.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem22.CustomizationFormText = "Ανακοινώσεις"
        Me.LayoutControlItem22.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 142)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(471, 22)
        Me.LayoutControlItem22.Text = "Ανακοινώσεις"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(105, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(357, 18)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(34, 22)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.chkExtraordinary
        Me.LayoutControlItem24.Location = New System.Drawing.Point(179, 18)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(76, 22)
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem24.TextVisible = False
        '
        'lCanceled
        '
        Me.lCanceled.Control = Me.lblCancel
        Me.lCanceled.Location = New System.Drawing.Point(0, 0)
        Me.lCanceled.Name = "lCanceled"
        Me.lCanceled.Size = New System.Drawing.Size(471, 18)
        Me.lCanceled.TextSize = New System.Drawing.Size(0, 0)
        Me.lCanceled.TextVisible = False
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.cboAhpbHB
        Me.LayoutControlItem27.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem27.Location = New System.Drawing.Point(235, 208)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(236, 22)
        Me.LayoutControlItem27.Text = "Ώρες Μετρ.Boiler"
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.txtHpb
        Me.LayoutControlItem28.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem28.Location = New System.Drawing.Point(235, 186)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(236, 22)
        Me.LayoutControlItem28.Text = "Πάγιο Boiler"
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem30
        '
        Me.LayoutControlItem30.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem30.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LayoutControlItem30.Control = Me.txtBdgCmt
        Me.LayoutControlItem30.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem30.CustomizationFormText = "Γενικά Σχόλια Πολυκατοικίας "
        Me.LayoutControlItem30.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem30.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem30.Name = "LayoutControlItem30"
        Me.LayoutControlItem30.Size = New System.Drawing.Size(471, 23)
        Me.LayoutControlItem30.Text = "Σχόλια Πολυκατοικίας"
        Me.LayoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem30.TextLocation = DevExpress.Utils.Locations.Left
        Me.LayoutControlItem30.TextSize = New System.Drawing.Size(109, 13)
        Me.LayoutControlItem30.TextToControlDistance = 1
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.DataNavigator1
        Me.LayoutControlItem25.Location = New System.Drawing.Point(0, 230)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(471, 21)
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem25.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem2, Me.LayoutControlItem13, Me.LayoutControlItem10})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 336)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(485, 386)
        Me.LayoutControlGroup2.Text = "Στοιχεία Εξόδων"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtAmt
        Me.LayoutControlItem4.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem4.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 44)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(471, 22)
        Me.LayoutControlItem4.Tag = "1"
        Me.LayoutControlItem4.Text = "Ποσό"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboRepname
        Me.LayoutControlItem3.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 22)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(471, 22)
        Me.LayoutControlItem3.Text = "Λεκτικό Εκτύπωσης"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.chkCALC_CAT
        Me.LayoutControlItem2.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(471, 255)
        Me.LayoutControlItem2.Tag = "1"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.cboOwnerTenant
        Me.LayoutControlItem13.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem13.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(471, 22)
        Me.LayoutControlItem13.Tag = "1"
        Me.LayoutControlItem13.Text = "Ένοικος/Ιδιοκτήτης"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.cmdSaveInd
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 66)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(471, 30)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cmdRefresh
        Me.LayoutControlItem11.Location = New System.Drawing.Point(485, 360)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(24, 24)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.cmdDel
        Me.LayoutControlItem12.Location = New System.Drawing.Point(485, 336)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(24, 24)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(485, 408)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(24, 344)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(485, 20)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(24, 316)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.cmdCalculate
        Me.LayoutControlItem16.Location = New System.Drawing.Point(274, 722)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(124, 30)
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem16.TextVisible = False
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.TabPane1
        Me.LayoutControlItem17.Location = New System.Drawing.Point(509, 0)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(999, 752)
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem17.TextVisible = False
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.cmdExport
        Me.LayoutControlItem18.Location = New System.Drawing.Point(485, 384)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(24, 24)
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextVisible = False
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 722)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(11, 30)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.cmdPrintAll
        Me.LayoutControlItem23.Location = New System.Drawing.Point(144, 722)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(130, 30)
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem23.TextVisible = False
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(11, 722)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(133, 30)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.Control = Me.cmdExit
        Me.LayoutControlItem29.Location = New System.Drawing.Point(398, 722)
        Me.LayoutControlItem29.Name = "LayoutControlItem29"
        Me.LayoutControlItem29.Size = New System.Drawing.Size(87, 30)
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem29.TextVisible = False
        '
        'LayoutControlItem31
        '
        Me.LayoutControlItem31.Control = Me.chkCalculated
        Me.LayoutControlItem31.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem31.Name = "LayoutControlItem31"
        Me.LayoutControlItem31.Size = New System.Drawing.Size(133, 20)
        Me.LayoutControlItem31.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem31.TextVisible = False
        '
        'LayoutControlItem32
        '
        Me.LayoutControlItem32.Control = Me.chkPrintSyg
        Me.LayoutControlItem32.Location = New System.Drawing.Point(133, 0)
        Me.LayoutControlItem32.Name = "LayoutControlItem32"
        Me.LayoutControlItem32.Size = New System.Drawing.Size(141, 20)
        Me.LayoutControlItem32.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem32.TextVisible = False
        '
        'LayoutControlItem33
        '
        Me.LayoutControlItem33.Control = Me.chkPrintEidop
        Me.LayoutControlItem33.Location = New System.Drawing.Point(274, 0)
        Me.LayoutControlItem33.Name = "LayoutControlItem33"
        Me.LayoutControlItem33.Size = New System.Drawing.Size(116, 20)
        Me.LayoutControlItem33.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem33.TextVisible = False
        '
        'LayoutControlItem34
        '
        Me.LayoutControlItem34.Control = Me.chkPrintReceipt
        Me.LayoutControlItem34.Location = New System.Drawing.Point(390, 0)
        Me.LayoutControlItem34.Name = "LayoutControlItem34"
        Me.LayoutControlItem34.Size = New System.Drawing.Size(95, 20)
        Me.LayoutControlItem34.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem34.TextVisible = False
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.cmdNewInh
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 306)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(91, 30)
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem21.TextVisible = False
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.cmdCancelInvoice
        Me.LayoutControlItem26.Location = New System.Drawing.Point(91, 306)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(151, 30)
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem26.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdSaveINH
        Me.LayoutControlItem7.Location = New System.Drawing.Point(388, 306)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(97, 30)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem35
        '
        Me.LayoutControlItem35.Control = Me.cmdCancelCalculate
        Me.LayoutControlItem35.Location = New System.Drawing.Point(242, 306)
        Me.LayoutControlItem35.Name = "LayoutControlItem35"
        Me.LayoutControlItem35.Size = New System.Drawing.Size(146, 30)
        Me.LayoutControlItem35.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem35.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(485, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(24, 20)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'AHPBHBindingSource
        '
        Me.AHPBHBindingSource.DataMember = "AHPB_H"
        Me.AHPBHBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'VwINCBindingSource
        '
        Me.VwINCBindingSource.DataMember = "vw_INC"
        Me.VwINCBindingSource.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'VwEXCBindingSource
        '
        Me.VwEXCBindingSource.DataMember = "vw_EXC"
        Me.VwEXCBindingSource.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'Vw_BDGTableAdapter
        '
        Me.Vw_BDGTableAdapter.ClearBeforeFill = True
        '
        'Vw_EXCTableAdapter
        '
        Me.Vw_EXCTableAdapter.ClearBeforeFill = True
        '
        'Vw_INDTableAdapter
        '
        Me.Vw_INDTableAdapter.ClearBeforeFill = True
        '
        'Vw_CALC_CATTableAdapter
        '
        Me.Vw_CALC_CATTableAdapter.ClearBeforeFill = True
        '
        'Vw_INCTableAdapter
        '
        Me.Vw_INCTableAdapter.ClearBeforeFill = True
        '
        'Vw_TTLTableAdapter
        '
        Me.Vw_TTLTableAdapter.ClearBeforeFill = True
        '
        'AHPB_H
        '
        Me.AHPB_H.ClearBeforeFill = True
        '
        'XtraSaveFileDialog1
        '
        Me.XtraSaveFileDialog1.FileName = "XtraSaveFileDialog1"
        '
        'Vw_ANN_MENTSTableAdapter
        '
        Me.Vw_ANN_MENTSTableAdapter.ClearBeforeFill = True
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'XtraOpenFileDialog1
        '
        Me.XtraOpenFileDialog1.Multiselect = True
        Me.XtraOpenFileDialog1.Title = "Επιλογή αρχείων"
        '
        'Vw_INHTableAdapter
        '
        Me.Vw_INHTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AHPB_H1TableAdapter = Nothing
        Me.TableAdapterManager.AHPB_HTableAdapter = Nothing
        Me.TableAdapterManager.AHPB_ΒTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = PRIAMOS.NET.Priamos_NETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.YEARSTableAdapter = Nothing
        '
        'AHPB_H1TableAdapter
        '
        Me.AHPB_H1TableAdapter.ClearBeforeFill = True
        '
        'AHPBH1BindingSource
        '
        Me.AHPBH1BindingSource.DataMember = "AHPB_H1"
        Me.AHPBH1BindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'AHPB_Β
        '
        Me.AHPB_Β.ClearBeforeFill = True
        '
        'CheckEdit1
        '
        Me.CheckEdit1.EditValue = CType(0, Byte)
        Me.CheckEdit1.Location = New System.Drawing.Point(269, 73)
        Me.CheckEdit1.MenuManager = Me.BarManager1
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Θερμιδομέτρηση"
        Me.CheckEdit1.Properties.ValueChecked = CType(1, Byte)
        Me.CheckEdit1.Properties.ValueUnchecked = CType(0, Byte)
        Me.CheckEdit1.Size = New System.Drawing.Size(100, 18)
        Me.CheckEdit1.StyleController = Me.LayoutControl1
        Me.CheckEdit1.TabIndex = 74
        Me.CheckEdit1.Tag = "Calorimetric,0,1,2"
        '
        'LayoutControlItem36
        '
        Me.LayoutControlItem36.Control = Me.CheckEdit1
        Me.LayoutControlItem36.Location = New System.Drawing.Point(255, 18)
        Me.LayoutControlItem36.Name = "LayoutControlItem36"
        Me.LayoutControlItem36.Size = New System.Drawing.Size(102, 22)
        Me.LayoutControlItem36.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem36.TextVisible = False
        '
        'frmINH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1520, 764)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmINH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmParast"
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PriamosNETDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwCALCCATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.chkPrintReceipt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintEidop.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintSyg.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCalculated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHpb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAhpbHB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AHPBB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwINHBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExtraordinary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOwnerTenant.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwBDGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCALC_CAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHeatingType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBoilerType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRepname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwTTLBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAhpbH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AHPBH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPane1.ResumeLayout(False)
        Me.TabNavigationPage1.ResumeLayout(False)
        CType(Me.FlyoutPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanel1.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        Me.FlyoutPanelControl1.PerformLayout()
        CType(Me.cboAhpbB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAhpb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNavigationPage2.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridINH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNavigationPage3.ResumeLayout(False)
        CType(Me.txtHpc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAnnouncements.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwANNMENTSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBdgCmt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lCanceled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AHPBHBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwEXCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AHPBH1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents chkCALC_CAT As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtAmt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboBDG As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Priamos_NETDataSet As Priamos_NETDataSet
    Friend WithEvents VwBDGBindingSource As BindingSource
    Friend WithEvents Vw_BDGTableAdapter As Priamos_NETDataSetTableAdapters.vw_BDGTableAdapter
    Friend WithEvents dtFDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtTDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem53 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdSaveINH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtComments As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PriamosNETDataSetBindingSource As BindingSource
    Friend WithEvents VwEXCBindingSource As BindingSource
    Friend WithEvents Vw_EXCTableAdapter As Priamos_NETDataSetTableAdapters.vw_EXCTableAdapter
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwINDBindingSource As BindingSource
    Friend WithEvents Vw_INDTableAdapter As Priamos_NETDataSetTableAdapters.vw_INDTableAdapter
    Friend WithEvents cmdSaveInd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmdRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboOwnerTenant As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwCALCCATBindingSource As BindingSource
    Friend WithEvents Vw_CALC_CATTableAdapter As Priamos_NETDataSetTableAdapters.vw_CALC_CATTableAdapter
    Friend WithEvents txtHeatingType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBoilerType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdCalculate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPage1 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPage2 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwINCBindingSource As BindingSource
    Friend WithEvents Vw_INCTableAdapter As Priamos_NETDataSetTableAdapters.vw_INCTableAdapter
    Friend WithEvents lbldate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colinhID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcalcCatID As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridINH As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents apt As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents TabNavigationPage3 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents grdAPM As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboRepname As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents VwTTLBindingSource As BindingSource
    Friend WithEvents Vw_TTLTableAdapter As Priamos_NETDataSetTableAdapters.vw_TTLTableAdapter
    Friend WithEvents FlyoutPanel1 As DevExpress.Utils.FlyoutPanel
    Friend WithEvents AHPBHBindingSource As BindingSource
    Friend WithEvents AHPB_H As Priamos_NETDataSetTableAdapters.AHPB_HTableAdapter
    Friend WithEvents cmdExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents XtraSaveFileDialog1 As DevExpress.XtraEditors.XtraSaveFileDialog
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboAhpbH As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtHpc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboAnnouncements As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents VwANNMENTSBindingSource As BindingSource
    Friend WithEvents Vw_ANN_MENTSTableAdapter As Priamos_NETDataSetTableAdapters.vw_ANN_MENTSTableAdapter
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents cmdPrintAll As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents XtraOpenFileDialog1 As DevExpress.XtraEditors.XtraOpenFileDialog
    Friend WithEvents colSelectedFiles As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colpaid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdNewInh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemLookUpEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents vwINHBindingSource As BindingSource
    Friend WithEvents Vw_INHTableAdapter As Priamos_NETDataSetTableAdapters.vw_INHTableAdapter
    Friend WithEvents TableAdapterManager As Priamos_NETDataSetTableAdapters.TableAdapterManager
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents AHPB_H1TableAdapter As Priamos_NETDataSetTableAdapters.AHPB_H1TableAdapter
    Friend WithEvents AHPBH1BindingSource As BindingSource
    Friend WithEvents AHPBH As BindingSource
    Friend WithEvents chkExtraordinary As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DataNavigator1 As DevExpress.XtraEditors.DataNavigator
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdCancelInvoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblCancel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lCanceled As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboAhpbHB As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AHPBB As BindingSource
    Friend WithEvents AHPB_Β As Priamos_NETDataSetTableAdapters.AHPB_ΒTableAdapter
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents cmdCancelMES As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboAhpbB As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboAhpb As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtHpb As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem29 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBdgCmt As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem30 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkPrintReceipt As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintEidop As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPrintSyg As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCalculated As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem31 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem32 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem33 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem34 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdCancelCalculate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem35 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem36 As DevExpress.XtraLayout.LayoutControlItem
End Class
