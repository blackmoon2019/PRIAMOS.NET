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
        Me.grdIND = New DevExpress.XtraGrid.GridControl()
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
        Me.lblAHPB = New DevExpress.XtraEditors.LabelControl()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.chkreserveAPT = New DevExpress.XtraEditors.CheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarSygentrotiki = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEidop = New DevExpress.XtraBars.BarButtonItem()
        Me.BarReceipt = New DevExpress.XtraBars.BarButtonItem()
        Me.chkEmail = New DevExpress.XtraEditors.CheckEdit()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.chkCalorimetric = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdCancelCalculate = New DevExpress.XtraEditors.SimpleButton()
        Me.chkPrintReceipt = New DevExpress.XtraEditors.CheckEdit()
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
        Me.txtColAnnouncement = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem53 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lCanceled = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem30 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem36 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem38 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem39 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem40 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LcmdSaveInd = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LcmdCalculate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LcmdPrintAll = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem31 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem32 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem33 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem34 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LcmdNewInh = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LcmdCancelInvoice = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LcmdSaveINH = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LcmdCancelCalculate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem37 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Priamos_NETDataSet3 = New PRIAMOS.NET.Priamos_NETDataSet3()
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
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAPM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdIND, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PriamosNETDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwCALCCATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkreserveAPT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCalorimetric.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPrintReceipt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.txtColAnnouncement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lCanceled, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcmdSaveInd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcmdCalculate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcmdPrintAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcmdNewInh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcmdCancelInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcmdSaveINH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LcmdCancelCalculate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AHPBHBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwEXCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AHPBH1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView7
        '
        Me.GridView7.DetailHeight = 619
        Me.GridView7.GridControl = Me.grdAPM
        Me.GridView7.Name = "GridView7"
        Me.GridView7.OptionsBehavior.Editable = False
        Me.GridView7.OptionsView.ShowGroupPanel = False
        '
        'grdAPM
        '
        Me.grdAPM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAPM.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        GridLevelNode1.LevelTemplate = Me.GridView7
        GridLevelNode1.RelationName = "ΧΙΛΙΟΣΤΑ ΜΕ ΜΕΙΩΣΕΙΣ"
        Me.grdAPM.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdAPM.Location = New System.Drawing.Point(0, 0)
        Me.grdAPM.MainView = Me.GridView1
        Me.grdAPM.Margin = New System.Windows.Forms.Padding(5)
        Me.grdAPM.Name = "grdAPM"
        Me.grdAPM.Size = New System.Drawing.Size(1742, 1263)
        Me.grdAPM.TabIndex = 23
        Me.grdAPM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView7})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 619
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
        Me.colSelectedFiles.MinWidth = 33
        Me.colSelectedFiles.Name = "colSelectedFiles"
        Me.colSelectedFiles.Width = 125
        '
        'grdIND
        '
        Me.grdIND.DataSource = Me.VwINDBindingSource
        Me.grdIND.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdIND.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.grdIND.Location = New System.Drawing.Point(0, 0)
        Me.grdIND.MainView = Me.GridView5
        Me.grdIND.Margin = New System.Windows.Forms.Padding(5)
        Me.grdIND.Name = "grdIND"
        Me.grdIND.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit3})
        Me.grdIND.Size = New System.Drawing.Size(1566, 1263)
        Me.grdIND.TabIndex = 54
        Me.grdIND.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
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
        Me.GridView5.DetailHeight = 619
        Me.GridView5.GridControl = Me.grdIND
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
        Me.colID.MinWidth = 33
        Me.colID.Name = "colID"
        Me.colID.Width = 125
        '
        'colcode
        '
        Me.colcode.FieldName = "code"
        Me.colcode.MinWidth = 33
        Me.colcode.Name = "colcode"
        Me.colcode.Width = 125
        '
        'colinhID
        '
        Me.colinhID.FieldName = "inhID"
        Me.colinhID.MinWidth = 33
        Me.colinhID.Name = "colinhID"
        Me.colinhID.Width = 125
        '
        'colcalcCatID
        '
        Me.colcalcCatID.Caption = "Κατηγορία Υπολογισμού"
        Me.colcalcCatID.ColumnEdit = Me.RepositoryItemLookUpEdit3
        Me.colcalcCatID.FieldName = "calcCatID"
        Me.colcalcCatID.MinWidth = 33
        Me.colcalcCatID.Name = "colcalcCatID"
        Me.colcalcCatID.Visible = True
        Me.colcalcCatID.VisibleIndex = 0
        Me.colcalcCatID.Width = 218
        '
        'RepositoryItemLookUpEdit3
        '
        Me.RepositoryItemLookUpEdit3.AutoHeight = False
        Me.RepositoryItemLookUpEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
        Me.RepositoryItemLookUpEdit3.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Κατηγορία", 62, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
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
        Me.colrepName.MinWidth = 33
        Me.colrepName.Name = "colrepName"
        Me.colrepName.Visible = True
        Me.colrepName.VisibleIndex = 2
        Me.colrepName.Width = 302
        '
        'colamt
        '
        Me.colamt.Caption = "Ποσό"
        Me.colamt.FieldName = "amt"
        Me.colamt.MinWidth = 33
        Me.colamt.Name = "colamt"
        Me.colamt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amt", "SUM={0:0.##}")})
        Me.colamt.Visible = True
        Me.colamt.VisibleIndex = 1
        Me.colamt.Width = 155
        '
        'colmodifiedBy
        '
        Me.colmodifiedBy.FieldName = "modifiedBy"
        Me.colmodifiedBy.MinWidth = 33
        Me.colmodifiedBy.Name = "colmodifiedBy"
        Me.colmodifiedBy.Width = 125
        '
        'colmodifiedOn
        '
        Me.colmodifiedOn.FieldName = "modifiedOn"
        Me.colmodifiedOn.MinWidth = 33
        Me.colmodifiedOn.Name = "colmodifiedOn"
        Me.colmodifiedOn.Width = 125
        '
        'colcreatedOn
        '
        Me.colcreatedOn.FieldName = "createdOn"
        Me.colcreatedOn.MinWidth = 33
        Me.colcreatedOn.Name = "colcreatedOn"
        Me.colcreatedOn.Width = 125
        '
        'colnam
        '
        Me.colnam.Caption = "Πολυκατοικία"
        Me.colnam.FieldName = "nam"
        Me.colnam.MinWidth = 33
        Me.colnam.Name = "colnam"
        Me.colnam.Width = 125
        '
        'colfDate
        '
        Me.colfDate.FieldName = "fDate"
        Me.colfDate.MinWidth = 33
        Me.colfDate.Name = "colfDate"
        Me.colfDate.Width = 125
        '
        'coltDate
        '
        Me.coltDate.FieldName = "tDate"
        Me.coltDate.MinWidth = 33
        Me.coltDate.Name = "coltDate"
        Me.coltDate.Width = 125
        '
        'colname
        '
        Me.colname.FieldName = "name"
        Me.colname.MinWidth = 33
        Me.colname.Name = "colname"
        Me.colname.Width = 232
        '
        'colowner_tenant
        '
        Me.colowner_tenant.Caption = "Ένοικος/Ιδιοκτήτης"
        Me.colowner_tenant.FieldName = "owner_tenant"
        Me.colowner_tenant.MinWidth = 33
        Me.colowner_tenant.Name = "colowner_tenant"
        Me.colowner_tenant.Visible = True
        Me.colowner_tenant.VisibleIndex = 4
        Me.colowner_tenant.Width = 125
        '
        'colpaid
        '
        Me.colpaid.Caption = "Πληρώθηκε"
        Me.colpaid.FieldName = "paid"
        Me.colpaid.MinWidth = 33
        Me.colpaid.Name = "colpaid"
        Me.colpaid.Visible = True
        Me.colpaid.VisibleIndex = 3
        Me.colpaid.Width = 125
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
        Me.LayoutControl1.Controls.Add(Me.lblAHPB)
        Me.LayoutControl1.Controls.Add(Me.TextEdit1)
        Me.LayoutControl1.Controls.Add(Me.chkreserveAPT)
        Me.LayoutControl1.Controls.Add(Me.chkEmail)
        Me.LayoutControl1.Controls.Add(Me.chkCalorimetric)
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
        Me.LayoutControl1.Controls.Add(Me.txtColAnnouncement)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.LayoutControl1.MinimumSize = New System.Drawing.Size(0, 550)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1173, 253, 1441, 1052)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(2533, 1352)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'lblAHPB
        '
        Me.lblAHPB.Appearance.Font = New System.Drawing.Font("Tahoma", 8.142858!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAHPB.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAHPB.Appearance.Options.UseFont = True
        Me.lblAHPB.Appearance.Options.UseForeColor = True
        Me.lblAHPB.Location = New System.Drawing.Point(25, 702)
        Me.lblAHPB.Name = "lblAHPB"
        Me.lblAHPB.Size = New System.Drawing.Size(134, 23)
        Me.lblAHPB.StyleController = Me.LayoutControl1
        Me.lblAHPB.TabIndex = 78
        '
        'TextEdit1
        '
        Me.TextEdit1.EditValue = "0,00 €"
        Me.TextEdit1.Location = New System.Drawing.Point(697, 656)
        Me.TextEdit1.Margin = New System.Windows.Forms.Padding(5)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TextEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextEdit1.Properties.Appearance.Options.UseFont = True
        Me.TextEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.TextEdit1.Properties.DisplayFormat.FormatString = "c"
        Me.TextEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit1.Properties.EditFormat.FormatString = "n2"
        Me.TextEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TextEdit1.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextEdit1.Properties.MaskSettings.Set("mask", "c2")
        Me.TextEdit1.Properties.Tag = "BenchExtraPrice"
        Me.TextEdit1.Size = New System.Drawing.Size(211, 42)
        Me.TextEdit1.StyleController = Me.LayoutControl1
        Me.TextEdit1.TabIndex = 76
        Me.TextEdit1.Tag = "TotalInh,0"
        '
        'chkreserveAPT
        '
        Me.chkreserveAPT.EditValue = CType(0, Byte)
        Me.chkreserveAPT.Location = New System.Drawing.Point(609, 129)
        Me.chkreserveAPT.Margin = New System.Windows.Forms.Padding(5)
        Me.chkreserveAPT.MenuManager = Me.BarManager1
        Me.chkreserveAPT.Name = "chkreserveAPT"
        Me.chkreserveAPT.Properties.Caption = "Έναντι Διαμερίσματος"
        Me.chkreserveAPT.Properties.ReadOnly = True
        Me.chkreserveAPT.Properties.ValueChecked = CType(1, Byte)
        Me.chkreserveAPT.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkreserveAPT.Size = New System.Drawing.Size(299, 32)
        Me.chkreserveAPT.StyleController = Me.LayoutControl1
        Me.chkreserveAPT.TabIndex = 75
        Me.chkreserveAPT.Tag = "reserveAPT,0,1,2"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSygentrotiki, Me.BarEidop, Me.BarReceipt})
        Me.BarManager1.MaxItemId = 3
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(5)
        Me.barDockControlTop.Size = New System.Drawing.Size(2533, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 1352)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(5)
        Me.barDockControlBottom.Size = New System.Drawing.Size(2533, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(5)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 1352)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(2533, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(5)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 1352)
        '
        'BarSygentrotiki
        '
        Me.BarSygentrotiki.Caption = "Συγκεντρωτική"
        Me.BarSygentrotiki.Id = 0
        Me.BarSygentrotiki.Name = "BarSygentrotiki"
        '
        'BarEidop
        '
        Me.BarEidop.Caption = "Ειδοποιήσεις"
        Me.BarEidop.Id = 1
        Me.BarEidop.Name = "BarEidop"
        '
        'BarReceipt
        '
        Me.BarReceipt.Caption = "Αποδείξεις"
        Me.BarReceipt.Id = 2
        Me.BarReceipt.Name = "BarReceipt"
        '
        'chkEmail
        '
        Me.chkEmail.EditValue = CType(0, Byte)
        Me.chkEmail.Location = New System.Drawing.Point(743, 12)
        Me.chkEmail.Margin = New System.Windows.Forms.Padding(5)
        Me.chkEmail.MenuManager = Me.BarManager1
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.chkEmail.Properties.Appearance.ForeColor = System.Drawing.Color.Green
        Me.chkEmail.Properties.Appearance.Options.UseFont = True
        Me.chkEmail.Properties.Appearance.Options.UseForeColor = True
        Me.chkEmail.Properties.Caption = "EMAIL"
        Me.chkEmail.Properties.ReadOnly = True
        Me.chkEmail.Properties.ValueChecked = CType(1, Byte)
        Me.chkEmail.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkEmail.Size = New System.Drawing.Size(178, 32)
        Me.chkEmail.StyleController = Me.LayoutControl1
        Me.chkEmail.TabIndex = 73
        Me.chkEmail.Tag = "email,0"
        Me.chkEmail.ToolTipController = Me.ToolTipController1
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
        'chkCalorimetric
        '
        Me.chkCalorimetric.EditValue = CType(0, Byte)
        Me.chkCalorimetric.Location = New System.Drawing.Point(429, 129)
        Me.chkCalorimetric.Margin = New System.Windows.Forms.Padding(5)
        Me.chkCalorimetric.MenuManager = Me.BarManager1
        Me.chkCalorimetric.Name = "chkCalorimetric"
        Me.chkCalorimetric.Properties.Caption = "Θερμιδομέτρηση"
        Me.chkCalorimetric.Properties.ValueChecked = CType(1, Byte)
        Me.chkCalorimetric.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkCalorimetric.Size = New System.Drawing.Size(176, 32)
        Me.chkCalorimetric.StyleController = Me.LayoutControl1
        Me.chkCalorimetric.TabIndex = 74
        Me.chkCalorimetric.Tag = "Calorimetric,0,1,2"
        '
        'cmdCancelCalculate
        '
        Me.cmdCancelCalculate.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_cancel_subscription_24
        Me.cmdCancelCalculate.Location = New System.Drawing.Point(464, 748)
        Me.cmdCancelCalculate.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdCancelCalculate.Name = "cmdCancelCalculate"
        Me.cmdCancelCalculate.Size = New System.Drawing.Size(228, 39)
        Me.cmdCancelCalculate.StyleController = Me.LayoutControl1
        Me.cmdCancelCalculate.TabIndex = 73
        Me.cmdCancelCalculate.Text = "Ακύρωση υπολογισμού"
        '
        'chkPrintReceipt
        '
        Me.chkPrintReceipt.EditValue = CType(0, Byte)
        Me.chkPrintReceipt.Location = New System.Drawing.Point(598, 12)
        Me.chkPrintReceipt.Margin = New System.Windows.Forms.Padding(5)
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
        Me.chkPrintReceipt.Size = New System.Drawing.Size(141, 32)
        Me.chkPrintReceipt.StyleController = Me.LayoutControl1
        Me.chkPrintReceipt.TabIndex = 72
        Me.chkPrintReceipt.Tag = "isPrintedEisp,0"
        Me.chkPrintReceipt.ToolTipController = Me.ToolTipController1
        '
        'chkPrintEidop
        '
        Me.chkPrintEidop.EditValue = CType(0, Byte)
        Me.chkPrintEidop.Location = New System.Drawing.Point(427, 12)
        Me.chkPrintEidop.Margin = New System.Windows.Forms.Padding(5)
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
        Me.chkPrintEidop.Size = New System.Drawing.Size(167, 32)
        Me.chkPrintEidop.StyleController = Me.LayoutControl1
        Me.chkPrintEidop.TabIndex = 71
        Me.chkPrintEidop.Tag = "isPrintedEidop,0"
        Me.chkPrintEidop.ToolTipController = Me.ToolTipController1
        '
        'chkPrintSyg
        '
        Me.chkPrintSyg.EditValue = CType(0, Byte)
        Me.chkPrintSyg.Location = New System.Drawing.Point(222, 12)
        Me.chkPrintSyg.Margin = New System.Windows.Forms.Padding(5)
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
        Me.chkPrintSyg.Size = New System.Drawing.Size(201, 32)
        Me.chkPrintSyg.StyleController = Me.LayoutControl1
        Me.chkPrintSyg.TabIndex = 70
        Me.chkPrintSyg.Tag = "isPrinted,0"
        Me.chkPrintSyg.ToolTipController = Me.ToolTipController1
        '
        'chkCalculated
        '
        Me.chkCalculated.EditValue = CType(0, Byte)
        Me.chkCalculated.Location = New System.Drawing.Point(12, 12)
        Me.chkCalculated.Margin = New System.Windows.Forms.Padding(5)
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
        Me.chkCalculated.Size = New System.Drawing.Size(206, 32)
        Me.chkCalculated.StyleController = Me.LayoutControl1
        Me.chkCalculated.TabIndex = 69
        Me.chkCalculated.Tag = "Calculated,0"
        Me.chkCalculated.ToolTipController = Me.ToolTipController1
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(744, 1301)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(177, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 58
        Me.cmdExit.Text = "Έξοδος"
        '
        'txtHpb
        '
        Me.txtHpb.EditValue = "0"
        Me.txtHpb.Location = New System.Drawing.Point(697, 572)
        Me.txtHpb.Margin = New System.Windows.Forms.Padding(5)
        Me.txtHpb.Name = "txtHpb"
        Me.txtHpb.Properties.DisplayFormat.FormatString = "p0"
        Me.txtHpb.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHpb.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHpb.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtHpb.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtHpb.Properties.MaskSettings.Set("mask", "P0")
        Me.txtHpb.Properties.ReadOnly = True
        Me.txtHpb.Size = New System.Drawing.Size(211, 38)
        Me.txtHpb.StyleController = Me.LayoutControl1
        Me.txtHpb.TabIndex = 68
        Me.txtHpb.Tag = "hpb,0"
        '
        'cboAhpbHB
        '
        Me.cboAhpbHB.Location = New System.Drawing.Point(697, 614)
        Me.cboAhpbHB.Margin = New System.Windows.Forms.Padding(5)
        Me.cboAhpbHB.Name = "cboAhpbHB"
        Me.cboAhpbHB.Properties.AllowMouseWheel = False
        Me.cboAhpbHB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboAhpbHB.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mdt", "ΗΜΕΡ/ΝΙΑ ΜΕΤΡΗΣΗΣ", 48, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("finalized", "finalized", 83, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 90, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("boiler", "BOILER", 62, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAhpbHB.Properties.DataSource = Me.AHPBB
        Me.cboAhpbHB.Properties.DisplayMember = "mdt"
        Me.cboAhpbHB.Properties.NullText = ""
        Me.cboAhpbHB.Properties.ValueMember = "ID"
        Me.cboAhpbHB.Size = New System.Drawing.Size(211, 38)
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
        Me.lblCancel.Location = New System.Drawing.Point(25, 97)
        Me.lblCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(151, 28)
        Me.lblCancel.StyleController = Me.LayoutControl1
        Me.lblCancel.TabIndex = 66
        Me.lblCancel.Tag = "canceled,0"
        Me.lblCancel.Text = "ΑΚΥΡΩΜΕΝΟ"
        '
        'cmdCancelInvoice
        '
        Me.cmdCancelInvoice.Enabled = False
        Me.cmdCancelInvoice.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_cancel_subscription_24
        Me.cmdCancelInvoice.Location = New System.Drawing.Point(220, 748)
        Me.cmdCancelInvoice.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdCancelInvoice.Name = "cmdCancelInvoice"
        Me.cmdCancelInvoice.Size = New System.Drawing.Size(240, 39)
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
        Me.DataNavigator1.Location = New System.Drawing.Point(496, 702)
        Me.DataNavigator1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataNavigator1.Name = "DataNavigator1"
        Me.DataNavigator1.Size = New System.Drawing.Size(412, 29)
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
        Me.chkExtraordinary.Location = New System.Drawing.Point(317, 129)
        Me.chkExtraordinary.Margin = New System.Windows.Forms.Padding(5)
        Me.chkExtraordinary.MenuManager = Me.BarManager1
        Me.chkExtraordinary.Name = "chkExtraordinary"
        Me.chkExtraordinary.Properties.Caption = "Έκτακτα"
        Me.chkExtraordinary.Properties.ValueChecked = CType(1, Byte)
        Me.chkExtraordinary.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkExtraordinary.Size = New System.Drawing.Size(108, 32)
        Me.chkExtraordinary.StyleController = Me.LayoutControl1
        Me.chkExtraordinary.TabIndex = 64
        Me.chkExtraordinary.Tag = "extraordinary,0,1,2"
        '
        'cmdNewInh
        '
        Me.cmdNewInh.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_new_file_24
        Me.cmdNewInh.Location = New System.Drawing.Point(12, 748)
        Me.cmdNewInh.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdNewInh.Name = "cmdNewInh"
        Me.cmdNewInh.Size = New System.Drawing.Size(204, 39)
        Me.cmdNewInh.StyleController = Me.LayoutControl1
        Me.cmdNewInh.TabIndex = 63
        Me.cmdNewInh.Text = "Νέο Παραστατικό"
        '
        'cmdPrintAll
        '
        Me.cmdPrintAll.DropDownControl = Me.PopupMenu1
        Me.cmdPrintAll.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_estimates_24
        Me.cmdPrintAll.Location = New System.Drawing.Point(284, 1301)
        Me.cmdPrintAll.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdPrintAll.Name = "cmdPrintAll"
        Me.cmdPrintAll.Size = New System.Drawing.Size(242, 37)
        Me.cmdPrintAll.StyleController = Me.LayoutControl1
        Me.cmdPrintAll.TabIndex = 62
        Me.cmdPrintAll.Text = "Εκτύπωση"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSygentrotiki), New DevExpress.XtraBars.LinkPersistInfo(Me.BarEidop), New DevExpress.XtraBars.LinkPersistInfo(Me.BarReceipt)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'cmdExport
        '
        Me.cmdExport.ImageOptions.Image = CType(resources.GetObject("cmdExport.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdExport.Location = New System.Drawing.Point(925, 877)
        Me.cmdExport.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdExport.Size = New System.Drawing.Size(26, 39)
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
        Me.lbldate.Location = New System.Drawing.Point(768, 213)
        Me.lbldate.Margin = New System.Windows.Forms.Padding(5)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(140, 23)
        Me.lbldate.StyleController = Me.LayoutControl1
        Me.lbldate.TabIndex = 55
        Me.lbldate.Tag = "completeDate,0"
        Me.lbldate.Text = "ΗΜΕΡΟΜΗΝΙΑ"
        '
        'cmdCalculate
        '
        Me.cmdCalculate.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_estimates_24
        Me.cmdCalculate.Location = New System.Drawing.Point(530, 1301)
        Me.cmdCalculate.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdCalculate.Name = "cmdCalculate"
        Me.cmdCalculate.Size = New System.Drawing.Size(210, 39)
        Me.cmdCalculate.StyleController = Me.LayoutControl1
        Me.cmdCalculate.TabIndex = 53
        Me.cmdCalculate.Text = "Υπολογισμός"
        '
        'cboOwnerTenant
        '
        Me.cboOwnerTenant.Location = New System.Drawing.Point(226, 840)
        Me.cboOwnerTenant.Margin = New System.Windows.Forms.Padding(5)
        Me.cboOwnerTenant.Name = "cboOwnerTenant"
        Me.cboOwnerTenant.Properties.AllowMouseWheel = False
        Me.cboOwnerTenant.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboOwnerTenant.Properties.Items.AddRange(New Object() {"Ιδιοκτήτης", "Ένοικος"})
        Me.cboOwnerTenant.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboOwnerTenant.Size = New System.Drawing.Size(682, 38)
        Me.cboOwnerTenant.StyleController = Me.LayoutControl1
        Me.cboOwnerTenant.TabIndex = 51
        Me.cboOwnerTenant.Tag = "owner_tenant,0,1,2"
        '
        'cmdDel
        '
        Me.cmdDel.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Remove_16x16
        Me.cmdDel.Location = New System.Drawing.Point(925, 791)
        Me.cmdDel.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdDel.Size = New System.Drawing.Size(26, 39)
        Me.cmdDel.StyleController = Me.LayoutControl1
        Me.cmdDel.TabIndex = 50
        '
        'cmdRefresh
        '
        Me.cmdRefresh.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_refresh_16
        Me.cmdRefresh.Location = New System.Drawing.Point(925, 834)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdRefresh.Size = New System.Drawing.Size(26, 39)
        Me.cmdRefresh.StyleController = Me.LayoutControl1
        Me.cmdRefresh.TabIndex = 49
        '
        'cmdSaveInd
        '
        Me.cmdSaveInd.Appearance.Options.UseTextOptions = True
        Me.cmdSaveInd.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Show
        Me.cmdSaveInd.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSaveInd.Location = New System.Drawing.Point(25, 966)
        Me.cmdSaveInd.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSaveInd.Name = "cmdSaveInd"
        Me.cmdSaveInd.Size = New System.Drawing.Size(883, 39)
        Me.cmdSaveInd.StyleController = Me.LayoutControl1
        Me.cmdSaveInd.TabIndex = 48
        Me.cmdSaveInd.Text = "Καταχώρηση Εξόδου(alt+s)"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(226, 129)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(5)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(87, 38)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 47
        Me.txtCode.Tag = "code,0"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(208, 359)
        Me.txtComments.Margin = New System.Windows.Forms.Padding(5)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(700, 83)
        Me.txtComments.StyleController = Me.LayoutControl1
        Me.txtComments.TabIndex = 46
        Me.txtComments.Tag = "cmt,0,1,2"
        '
        'cmdSaveINH
        '
        Me.cmdSaveINH.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSaveINH.Location = New System.Drawing.Point(696, 748)
        Me.cmdSaveINH.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSaveINH.Name = "cmdSaveINH"
        Me.cmdSaveINH.Size = New System.Drawing.Size(225, 39)
        Me.cmdSaveINH.StyleController = Me.LayoutControl1
        Me.cmdSaveINH.TabIndex = 45
        Me.cmdSaveINH.Text = "Καταχώρηση"
        '
        'cboBDG
        '
        Me.cboBDG.Location = New System.Drawing.Point(226, 171)
        Me.cboBDG.Margin = New System.Windows.Forms.Padding(5)
        Me.cboBDG.Name = "cboBDG"
        Me.cboBDG.Properties.AllowMouseWheel = False
        Me.cboBDG.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboBDG.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboBDG.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboBDG.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 90, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nam", "Πολυκατοικία", 52, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdrID", "Adr ID", 70, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("cmt", "cmt", 46, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("aam", "aam", 51, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("iam", "iam", 45, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dts", "dts", 40, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_ID", "ADR_ID", 81, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Code", "ADR_Code", 103, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Name", "ADR_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tk", "tk", 31, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AreaID", "Area ID", 79, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CouID", "Cou ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_ID", "Area_ID", 83, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_Code", "Area_Code", 105, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_CouID", "Area_Cou ID", 121, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area_Name", "Area_Name", 112, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_ID", "COU_ID", 81, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Code", "COU_Code", 103, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Name", "COU_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ar", "ar", 32, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("prd", "prd", 44, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HTypeID", "HType ID", 95, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BTypeID", "BType ID", 93, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("HTYPE_Name", "HTYPE_Name", 130, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("BTYPE_Name", "BTYPE_Name", 128, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FBTYPE_Name", "FBTYPE_Name", 138, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FTypeID", "FType ID", 92, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpc", "hpc", 46, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("hpb", "hpb", 48, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("calH", "cal H", 57, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("calB", "cal B", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tacH", "tac H", 59, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tacB", "tac B", 57, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("lpcH", "lpc H", 58, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("lpcB", "lpc B", 56, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bCommon", "b Common", 106, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bSeperate", "b Seperate", 107, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bManageID", "b Manage ID", 125, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eName", "e Name", 80, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eCounter", "e Counter", 97, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ePaymentCode", "e Payment Code", 151, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eServiceNum", "e Service Num", 137, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fName", "f Name", 76, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fCounter", "f Counter", 93, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fPaymentCode", "f Payment Code", 147, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fServiceNum", "f Service Num", 133, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wName", "w Name", 84, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wCounter", "w Counter", 101, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("wRegisterNum", "w Register Num", 149, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fUN", "f UN", 52, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fPWD", "f PWD", 67, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fCusCode", "f Cus Code", 105, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fHkasp", "f Hkasp", 78, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fDeposit", "f Deposit", 89, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("isManaged", "is Managed", 111, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ManagerName", "Manager Name", 144, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("managerID", "manager ID", 116, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("eAmt", "e Amt", 64, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("haselevator", "haselevator", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtcheckcarrier", "dtcheckcarrier", 134, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("iscertified", "iscertified", 94, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtcertifiedEndDate", "dtcertified End Date", 183, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("notes", "notes", 60, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("afm", "afm", 47, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("doyID", "doy ID", 71, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("extraCostH", "extra Cost H", 117, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("extraCostB", "extra Cost B", 115, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("freeCostLimit", "free Cost Limit", 134, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TotBalAdm", "Tot Bal Adm", 117, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TotBalNotAdm", "Tot Bal Not Adm", 152, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("GenTotBalAdm", "Gen Tot Bal Adm", 157, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("debitCollectorName", "debit Collector Name", 189, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tmIn", "tm In", 61, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tmOut", "tm Out", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("debitCollectorID", "debit Collector ID", 160, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("annGroupID", "ann Group ID", 131, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AnnGrpName", "Ann Grp Name", 140, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtu", "dtu", 43, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("iad", "iad", 40, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("rmg", "rmg", 49, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboBDG.Properties.DataSource = Me.VwBDGBindingSource
        Me.cboBDG.Properties.DisplayMember = "nam"
        Me.cboBDG.Properties.NullText = ""
        Me.cboBDG.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboBDG.Properties.PopupSizeable = False
        Me.cboBDG.Properties.ValueMember = "ID"
        Me.cboBDG.Size = New System.Drawing.Size(682, 38)
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
        Me.txtAmt.Location = New System.Drawing.Point(226, 924)
        Me.txtAmt.Margin = New System.Windows.Forms.Padding(5)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Properties.DisplayFormat.FormatString = "c"
        Me.txtAmt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmt.Properties.EditFormat.FormatString = "n2"
        Me.txtAmt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmt.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtAmt.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtAmt.Properties.MaskSettings.Set("mask", "c2")
        Me.txtAmt.Properties.Tag = "BenchExtraPrice"
        Me.txtAmt.Size = New System.Drawing.Size(682, 38)
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
        Me.chkCALC_CAT.Location = New System.Drawing.Point(25, 1009)
        Me.chkCALC_CAT.Margin = New System.Windows.Forms.Padding(5)
        Me.chkCALC_CAT.Name = "chkCALC_CAT"
        Me.chkCALC_CAT.Size = New System.Drawing.Size(883, 275)
        Me.chkCALC_CAT.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.chkCALC_CAT.StyleController = Me.LayoutControl1
        Me.chkCALC_CAT.TabIndex = 28
        Me.chkCALC_CAT.Tag = ""
        Me.chkCALC_CAT.ValueMember = "ID"
        '
        'dtFDate
        '
        Me.dtFDate.EditValue = Nothing
        Me.dtFDate.Location = New System.Drawing.Point(226, 213)
        Me.dtFDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtFDate.Name = "dtFDate"
        Me.dtFDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFDate.Properties.MaskSettings.Set("mask", "d")
        Me.dtFDate.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtFDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtFDate.Size = New System.Drawing.Size(214, 38)
        Me.dtFDate.StyleController = Me.LayoutControl1
        Me.dtFDate.TabIndex = 38
        Me.dtFDate.Tag = "fDate,0,1,2"
        '
        'dtTDate
        '
        Me.dtTDate.EditValue = Nothing
        Me.dtTDate.Location = New System.Drawing.Point(496, 213)
        Me.dtTDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtTDate.Name = "dtTDate"
        Me.dtTDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtTDate.Size = New System.Drawing.Size(268, 38)
        Me.dtTDate.StyleController = Me.LayoutControl1
        Me.dtTDate.TabIndex = 38
        Me.dtTDate.Tag = "tDate,0,1,2"
        '
        'txtHeatingType
        '
        Me.txtHeatingType.Location = New System.Drawing.Point(226, 530)
        Me.txtHeatingType.Margin = New System.Windows.Forms.Padding(5)
        Me.txtHeatingType.Name = "txtHeatingType"
        Me.txtHeatingType.Properties.ReadOnly = True
        Me.txtHeatingType.Size = New System.Drawing.Size(266, 38)
        Me.txtHeatingType.StyleController = Me.LayoutControl1
        Me.txtHeatingType.TabIndex = 46
        Me.txtHeatingType.Tag = ""
        '
        'txtBoilerType
        '
        Me.txtBoilerType.Location = New System.Drawing.Point(226, 572)
        Me.txtBoilerType.Margin = New System.Windows.Forms.Padding(5)
        Me.txtBoilerType.Name = "txtBoilerType"
        Me.txtBoilerType.Properties.ReadOnly = True
        Me.txtBoilerType.Size = New System.Drawing.Size(266, 38)
        Me.txtBoilerType.StyleController = Me.LayoutControl1
        Me.txtBoilerType.TabIndex = 46
        Me.txtBoilerType.Tag = ""
        '
        'cboRepname
        '
        Me.cboRepname.Location = New System.Drawing.Point(226, 882)
        Me.cboRepname.Margin = New System.Windows.Forms.Padding(5)
        Me.cboRepname.Name = "cboRepname"
        Me.cboRepname.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboRepname.Properties.AllowMouseWheel = False
        Me.cboRepname.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboRepname.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 30, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 55, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboRepname.Properties.DataSource = Me.VwTTLBindingSource
        Me.cboRepname.Properties.DisplayMember = "name"
        Me.cboRepname.Properties.NullText = ""
        Me.cboRepname.Properties.PopupSizeable = False
        Me.cboRepname.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboRepname.Properties.ValueMember = "name"
        Me.cboRepname.Size = New System.Drawing.Size(682, 38)
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
        Me.cboAhpbH.Location = New System.Drawing.Point(226, 614)
        Me.cboAhpbH.Margin = New System.Windows.Forms.Padding(5)
        Me.cboAhpbH.Name = "cboAhpbH"
        Me.cboAhpbH.Properties.AllowMouseWheel = False
        Me.cboAhpbH.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboAhpbH.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mdt", "ΗΜΕΡ/ΝΙΑ ΜΕΤΡΗΣΗΣ", 48, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("finalized", "finalized", 83, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 90, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("boiler", "BOILER", 62, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAhpbH.Properties.DataSource = Me.AHPBH
        Me.cboAhpbH.Properties.DisplayMember = "mdt"
        Me.cboAhpbH.Properties.NullText = ""
        Me.cboAhpbH.Properties.ValueMember = "ID"
        Me.cboAhpbH.Size = New System.Drawing.Size(266, 38)
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
        Me.TabPane1.Location = New System.Drawing.Point(955, 12)
        Me.TabPane1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPage1, Me.TabNavigationPage2, Me.TabNavigationPage3})
        Me.TabPane1.RegularSize = New System.Drawing.Size(1566, 1328)
        Me.TabPane1.SelectedPage = Me.TabNavigationPage1
        Me.TabPane1.Size = New System.Drawing.Size(1566, 1328)
        Me.TabPane1.TabIndex = 54
        Me.TabPane1.Text = "Χιλιοστά Διαμερισμάτων"
        '
        'TabNavigationPage1
        '
        Me.TabNavigationPage1.Caption = "Έξοδα"
        Me.TabNavigationPage1.Controls.Add(Me.FlyoutPanel1)
        Me.TabNavigationPage1.Controls.Add(Me.grdIND)
        Me.TabNavigationPage1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabNavigationPage1.Name = "TabNavigationPage1"
        Me.TabNavigationPage1.Size = New System.Drawing.Size(1566, 1263)
        '
        'FlyoutPanel1
        '
        Me.FlyoutPanel1.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanel1.Location = New System.Drawing.Point(512, 373)
        Me.FlyoutPanel1.Margin = New System.Windows.Forms.Padding(5)
        Me.FlyoutPanel1.Name = "FlyoutPanel1"
        Me.FlyoutPanel1.OptionsButtonPanel.ButtonPanelHeight = 53
        Me.FlyoutPanel1.Size = New System.Drawing.Size(738, 248)
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
        Me.FlyoutPanelControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(738, 248)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'cmdCancelMES
        '
        Me.cmdCancelMES.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdCancelMES.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelMES.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdCancelMES.Location = New System.Drawing.Point(573, 138)
        Me.cmdCancelMES.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdCancelMES.Name = "cmdCancelMES"
        Me.cmdCancelMES.Size = New System.Drawing.Size(133, 50)
        Me.cmdCancelMES.TabIndex = 61
        Me.cmdCancelMES.Text = "Ακύρωση"
        '
        'cboAhpbB
        '
        Me.cboAhpbB.Location = New System.Drawing.Point(380, 78)
        Me.cboAhpbB.Margin = New System.Windows.Forms.Padding(5)
        Me.cboAhpbB.Name = "cboAhpbB"
        Me.cboAhpbB.Properties.AllowMouseWheel = False
        Me.cboAhpbB.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboAhpbB.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboAhpbB.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
        Me.cboAhpbB.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mdt", "ΗΜΕΡ/ΝΙΑ ΜΕΤΡΗΣΗΣ", 48, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("finalized", "finalized", 83, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 90, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("boiler", "BOILER", 62, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAhpbB.Properties.DataSource = Me.AHPBB
        Me.cboAhpbB.Properties.DisplayMember = "mdt"
        Me.cboAhpbB.Properties.NullText = ""
        Me.cboAhpbB.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboAhpbB.Properties.PopupSizeable = False
        Me.cboAhpbB.Properties.ValueMember = "ID"
        Me.cboAhpbB.Size = New System.Drawing.Size(322, 38)
        Me.cboAhpbB.StyleController = Me.LayoutControl1
        Me.cboAhpbB.TabIndex = 60
        Me.cboAhpbB.Tag = "bdgid,0,1,2"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(380, 44)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(5)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(197, 23)
        Me.LabelControl2.TabIndex = 59
        Me.LabelControl2.Text = "Ώρες Μετρήσεων Boiler"
        '
        'cmdOK
        '
        Me.cmdOK.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_estimates_24
        Me.cmdOK.Location = New System.Drawing.Point(423, 140)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(123, 50)
        Me.cmdOK.StyleController = Me.LayoutControl1
        Me.cmdOK.TabIndex = 57
        Me.cmdOK.Text = "OK"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(8, 44)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(245, 23)
        Me.LabelControl1.TabIndex = 56
        Me.LabelControl1.Text = "Ώρες Μετρήσεων Θέρμανσης"
        '
        'cboAhpb
        '
        Me.cboAhpb.Location = New System.Drawing.Point(8, 78)
        Me.cboAhpb.Margin = New System.Windows.Forms.Padding(5)
        Me.cboAhpb.Name = "cboAhpb"
        Me.cboAhpb.Properties.AllowMouseWheel = False
        Me.cboAhpb.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboAhpb.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboAhpb.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
        Me.cboAhpb.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mdt", "ΗΜΕΡ/ΝΙΑ ΜΕΤΡΗΣΗΣ", 48, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("finalized", "finalized", 83, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("old_code", "old_code", 90, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("boiler", "BOILER", 62, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAhpb.Properties.DataSource = Me.AHPBH
        Me.cboAhpb.Properties.DisplayMember = "mdt"
        Me.cboAhpb.Properties.NullText = ""
        Me.cboAhpb.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboAhpb.Properties.PopupSizeable = False
        Me.cboAhpb.Properties.ValueMember = "ID"
        Me.cboAhpb.Size = New System.Drawing.Size(303, 38)
        Me.cboAhpb.StyleController = Me.LayoutControl1
        Me.cboAhpb.TabIndex = 55
        Me.cboAhpb.Tag = "bdgid,0,1,2"
        '
        'TabNavigationPage2
        '
        Me.TabNavigationPage2.Caption = "Υπολογισμένα"
        Me.TabNavigationPage2.Controls.Add(Me.GridControl2)
        Me.TabNavigationPage2.Margin = New System.Windows.Forms.Padding(5)
        Me.TabNavigationPage2.Name = "TabNavigationPage2"
        Me.TabNavigationPage2.Size = New System.Drawing.Size(1742, 1263)
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridINH
        Me.GridControl2.Margin = New System.Windows.Forms.Padding(5)
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1742, 1263)
        Me.GridControl2.TabIndex = 0
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridINH})
        '
        'GridINH
        '
        Me.GridINH.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.apt})
        Me.GridINH.DetailHeight = 619
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
        Me.apt.MinWidth = 17
        Me.apt.Name = "apt"
        Me.apt.VisibleIndex = 0
        Me.apt.Width = 263
        '
        'TabNavigationPage3
        '
        Me.TabNavigationPage3.Caption = "Χιλιοστά Διαμερισμάτων"
        Me.TabNavigationPage3.Controls.Add(Me.grdAPM)
        Me.TabNavigationPage3.Margin = New System.Windows.Forms.Padding(5)
        Me.TabNavigationPage3.Name = "TabNavigationPage3"
        Me.TabNavigationPage3.Size = New System.Drawing.Size(1742, 1263)
        '
        'txtHpc
        '
        Me.txtHpc.EditValue = "0"
        Me.txtHpc.Location = New System.Drawing.Point(697, 530)
        Me.txtHpc.Margin = New System.Windows.Forms.Padding(5)
        Me.txtHpc.Name = "txtHpc"
        Me.txtHpc.Properties.DisplayFormat.FormatString = "p0"
        Me.txtHpc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHpc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHpc.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtHpc.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtHpc.Properties.MaskSettings.Set("mask", "P0")
        Me.txtHpc.Properties.ReadOnly = True
        Me.txtHpc.Size = New System.Drawing.Size(211, 38)
        Me.txtHpc.StyleController = Me.LayoutControl1
        Me.txtHpc.TabIndex = 8
        Me.txtHpc.Tag = "hpc,0"
        '
        'cboAnnouncements
        '
        Me.cboAnnouncements.Location = New System.Drawing.Point(226, 446)
        Me.cboAnnouncements.Margin = New System.Windows.Forms.Padding(5)
        Me.cboAnnouncements.Name = "cboAnnouncements"
        Me.cboAnnouncements.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboAnnouncements.Properties.AllowMouseWheel = False
        Me.cboAnnouncements.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboAnnouncements.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 30, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 55, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboAnnouncements.Properties.DataSource = Me.VwANNMENTSBindingSource
        Me.cboAnnouncements.Properties.DisplayMember = "name"
        Me.cboAnnouncements.Properties.NullText = ""
        Me.cboAnnouncements.Properties.PopupSizeable = False
        Me.cboAnnouncements.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboAnnouncements.Properties.ValueMember = "name"
        Me.cboAnnouncements.Size = New System.Drawing.Size(682, 38)
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
        Me.txtBdgCmt.Location = New System.Drawing.Point(208, 255)
        Me.txtBdgCmt.Margin = New System.Windows.Forms.Padding(5)
        Me.txtBdgCmt.Name = "txtBdgCmt"
        Me.txtBdgCmt.Properties.ReadOnly = True
        Me.txtBdgCmt.Size = New System.Drawing.Size(700, 100)
        Me.txtBdgCmt.StyleController = Me.LayoutControl1
        Me.txtBdgCmt.TabIndex = 17
        Me.txtBdgCmt.Tag = ""
        Me.txtBdgCmt.ToolTipController = Me.ToolTipController1
        '
        'txtColAnnouncement
        '
        Me.txtColAnnouncement.Location = New System.Drawing.Point(226, 488)
        Me.txtColAnnouncement.Margin = New System.Windows.Forms.Padding(5)
        Me.txtColAnnouncement.Name = "txtColAnnouncement"
        Me.txtColAnnouncement.Properties.ReadOnly = True
        Me.txtColAnnouncement.Size = New System.Drawing.Size(682, 38)
        Me.txtColAnnouncement.StyleController = Me.LayoutControl1
        Me.txtColAnnouncement.TabIndex = 77
        Me.txtColAnnouncement.Tag = "colannouncement,0,1,2"
        Me.txtColAnnouncement.ToolTipController = Me.ToolTipController1
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.EmptySpaceItem3, Me.EmptySpaceItem4, Me.LcmdCalculate, Me.LayoutControlItem17, Me.LayoutControlItem18, Me.LcmdPrintAll, Me.EmptySpaceItem7, Me.LayoutControlItem29, Me.LayoutControlItem31, Me.LayoutControlItem32, Me.LayoutControlItem33, Me.LayoutControlItem34, Me.LcmdNewInh, Me.LcmdCancelInvoice, Me.LcmdSaveINH, Me.LcmdCancelCalculate, Me.EmptySpaceItem1, Me.LayoutControlItem37})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(2533, 1352)
        Me.Root.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem53, Me.LayoutControlItem6, Me.LayoutControlItem5, Me.LayoutControlItem9, Me.LayoutControlItem1, Me.LayoutControlItem15, Me.LayoutControlItem19, Me.LayoutControlItem8, Me.LayoutControlItem20, Me.LayoutControlItem22, Me.LayoutControlItem24, Me.lCanceled, Me.LayoutControlItem27, Me.LayoutControlItem28, Me.LayoutControlItem30, Me.LayoutControlItem36, Me.EmptySpaceItem2, Me.LayoutControlItem38, Me.LayoutControlItem14, Me.LayoutControlItem39, Me.EmptySpaceItem6, Me.LayoutControlItem25, Me.EmptySpaceItem8, Me.LayoutControlItem40, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 36)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(913, 700)
        Me.LayoutControlGroup1.Text = "Στοιχεία Παραστατικού"
        '
        'LayoutControlItem53
        '
        Me.LayoutControlItem53.Control = Me.dtFDate
        Me.LayoutControlItem53.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem53.CustomizationFormText = "Ημερομηνία Τιμ."
        Me.LayoutControlItem53.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem53.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem53.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem53.Location = New System.Drawing.Point(0, 116)
        Me.LayoutControlItem53.Name = "LayoutControlItem53"
        Me.LayoutControlItem53.Size = New System.Drawing.Size(419, 42)
        Me.LayoutControlItem53.Tag = "1"
        Me.LayoutControlItem53.Text = "Από"
        Me.LayoutControlItem53.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.dtTDate
        Me.LayoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem6.CustomizationFormText = "Ημερομηνία Τιμ."
        Me.LayoutControlItem6.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem6.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem6.Location = New System.Drawing.Point(419, 116)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(324, 42)
        Me.LayoutControlItem6.Tag = "1"
        Me.LayoutControlItem6.Text = "Έως"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(47, 23)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboBDG
        Me.LayoutControlItem5.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem5.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 74)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(887, 42)
        Me.LayoutControlItem5.Tag = "1"
        Me.LayoutControlItem5.Text = "Πολυκατοικία"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtCode
        Me.LayoutControlItem9.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(292, 42)
        Me.LayoutControlItem9.Text = "Κωδικός"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtHeatingType
        Me.LayoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem1.CustomizationFormText = "Σχόλια"
        Me.LayoutControlItem1.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 433)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(471, 42)
        Me.LayoutControlItem1.Text = "Τύπος Θέρμανσης"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.txtBoilerType
        Me.LayoutControlItem15.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem15.CustomizationFormText = "Σχόλια"
        Me.LayoutControlItem15.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 475)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(471, 42)
        Me.LayoutControlItem15.Text = "Τύπος Boiler"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.cboAhpbH
        Me.LayoutControlItem19.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem19.CustomizationFormText = "Σχόλια"
        Me.LayoutControlItem19.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 517)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(471, 42)
        Me.LayoutControlItem19.Text = "Ώρες Μετρ."
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem8.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LayoutControlItem8.Control = Me.txtComments
        Me.LayoutControlItem8.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 262)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.OptionsPrint.AppearanceItem.Options.UseTextOptions = True
        Me.LayoutControlItem8.OptionsPrint.AppearanceItem.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LayoutControlItem8.Size = New System.Drawing.Size(887, 87)
        Me.LayoutControlItem8.Text = "Γενικές σημειώσεις πραστατικού"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Left
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(182, 23)
        Me.LayoutControlItem8.TextToControlDistance = 1
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.txtHpc
        Me.LayoutControlItem20.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem20.CustomizationFormText = "Πάγιο Θέρμανσης"
        Me.LayoutControlItem20.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem20.Location = New System.Drawing.Point(471, 433)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(416, 42)
        Me.LayoutControlItem20.Text = "Πάγιο Θέρμανσης"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.cboAnnouncements
        Me.LayoutControlItem22.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem22.CustomizationFormText = "Ανακοινώσεις"
        Me.LayoutControlItem22.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 349)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(887, 42)
        Me.LayoutControlItem22.Text = "Ανακοινώσεις"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.chkExtraordinary
        Me.LayoutControlItem24.Location = New System.Drawing.Point(292, 32)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(112, 42)
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem24.TextVisible = False
        '
        'lCanceled
        '
        Me.lCanceled.Control = Me.lblCancel
        Me.lCanceled.Location = New System.Drawing.Point(0, 0)
        Me.lCanceled.Name = "lCanceled"
        Me.lCanceled.Size = New System.Drawing.Size(155, 32)
        Me.lCanceled.TextSize = New System.Drawing.Size(0, 0)
        Me.lCanceled.TextVisible = False
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.cboAhpbHB
        Me.LayoutControlItem27.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem27.Location = New System.Drawing.Point(471, 517)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(416, 42)
        Me.LayoutControlItem27.Text = "Ώρες Μετρ.Boiler"
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.txtHpb
        Me.LayoutControlItem28.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem28.Location = New System.Drawing.Point(471, 475)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(416, 42)
        Me.LayoutControlItem28.Text = "Πάγιο Boiler"
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem30
        '
        Me.LayoutControlItem30.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem30.AppearanceItemCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LayoutControlItem30.Control = Me.txtBdgCmt
        Me.LayoutControlItem30.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem30.CustomizationFormText = "Γενικά Σχόλια Πολυκατοικίας "
        Me.LayoutControlItem30.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem30.Location = New System.Drawing.Point(0, 158)
        Me.LayoutControlItem30.Name = "LayoutControlItem30"
        Me.LayoutControlItem30.Size = New System.Drawing.Size(887, 104)
        Me.LayoutControlItem30.Text = "Σχόλια Πολυκατοικίας"
        Me.LayoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem30.TextLocation = DevExpress.Utils.Locations.Left
        Me.LayoutControlItem30.TextSize = New System.Drawing.Size(182, 23)
        Me.LayoutControlItem30.TextToControlDistance = 1
        '
        'LayoutControlItem36
        '
        Me.LayoutControlItem36.Control = Me.chkCalorimetric
        Me.LayoutControlItem36.Location = New System.Drawing.Point(404, 32)
        Me.LayoutControlItem36.Name = "LayoutControlItem36"
        Me.LayoutControlItem36.Size = New System.Drawing.Size(180, 42)
        Me.LayoutControlItem36.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem36.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(155, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(732, 32)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem38
        '
        Me.LayoutControlItem38.Control = Me.chkreserveAPT
        Me.LayoutControlItem38.Location = New System.Drawing.Point(584, 32)
        Me.LayoutControlItem38.Name = "LayoutControlItem38"
        Me.LayoutControlItem38.Size = New System.Drawing.Size(303, 42)
        Me.LayoutControlItem38.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem38.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.lbldate
        Me.LayoutControlItem14.Location = New System.Drawing.Point(743, 116)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(144, 42)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem39
        '
        Me.LayoutControlItem39.Control = Me.TextEdit1
        Me.LayoutControlItem39.Location = New System.Drawing.Point(471, 559)
        Me.LayoutControlItem39.Name = "LayoutControlItem39"
        Me.LayoutControlItem39.Size = New System.Drawing.Size(416, 46)
        Me.LayoutControlItem39.Text = "Σύνολο Παραστατικού"
        Me.LayoutControlItem39.TextSize = New System.Drawing.Size(189, 23)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(0, 559)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(471, 46)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.DataNavigator1
        Me.LayoutControlItem25.Location = New System.Drawing.Point(471, 605)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(416, 33)
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem25.TextVisible = False
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(138, 605)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(333, 33)
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem40
        '
        Me.LayoutControlItem40.Control = Me.txtColAnnouncement
        Me.LayoutControlItem40.Location = New System.Drawing.Point(0, 391)
        Me.LayoutControlItem40.Name = "LayoutControlItem40"
        Me.LayoutControlItem40.Size = New System.Drawing.Size(887, 42)
        Me.LayoutControlItem40.Tag = "colAnnouncement,0,1,2"
        Me.LayoutControlItem40.Text = "Ανακοίνωση είσπραξης"
        Me.LayoutControlItem40.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.lblAHPB
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 605)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(138, 33)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem2, Me.LayoutControlItem13, Me.LcmdSaveInd})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 779)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(913, 510)
        Me.LayoutControlGroup2.Text = "Στοιχεία Εξόδων"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtAmt
        Me.LayoutControlItem4.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem4.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(887, 42)
        Me.LayoutControlItem4.Tag = "1"
        Me.LayoutControlItem4.Text = "Ποσό"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboRepname
        Me.LayoutControlItem3.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(887, 42)
        Me.LayoutControlItem3.Text = "Λεκτικό Εκτύπωσης"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.chkCALC_CAT
        Me.LayoutControlItem2.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 169)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(887, 279)
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
        Me.LayoutControlItem13.Size = New System.Drawing.Size(887, 42)
        Me.LayoutControlItem13.Tag = "1"
        Me.LayoutControlItem13.Text = "Ένοικος/Ιδιοκτήτης"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(189, 23)
        '
        'LcmdSaveInd
        '
        Me.LcmdSaveInd.Control = Me.cmdSaveInd
        Me.LcmdSaveInd.Location = New System.Drawing.Point(0, 126)
        Me.LcmdSaveInd.Name = "LcmdSaveInd"
        Me.LcmdSaveInd.Size = New System.Drawing.Size(887, 43)
        Me.LcmdSaveInd.TextSize = New System.Drawing.Size(0, 0)
        Me.LcmdSaveInd.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cmdRefresh
        Me.LayoutControlItem11.Location = New System.Drawing.Point(913, 822)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(30, 43)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.cmdDel
        Me.LayoutControlItem12.Location = New System.Drawing.Point(913, 779)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(30, 43)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(913, 908)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(30, 424)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(913, 36)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(30, 743)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LcmdCalculate
        '
        Me.LcmdCalculate.Control = Me.cmdCalculate
        Me.LcmdCalculate.Location = New System.Drawing.Point(518, 1289)
        Me.LcmdCalculate.Name = "LcmdCalculate"
        Me.LcmdCalculate.Size = New System.Drawing.Size(214, 43)
        Me.LcmdCalculate.TextSize = New System.Drawing.Size(0, 0)
        Me.LcmdCalculate.TextVisible = False
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.TabPane1
        Me.LayoutControlItem17.Location = New System.Drawing.Point(943, 0)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(1570, 1332)
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem17.TextVisible = False
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.cmdExport
        Me.LayoutControlItem18.Location = New System.Drawing.Point(913, 865)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(30, 43)
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextVisible = False
        '
        'LcmdPrintAll
        '
        Me.LcmdPrintAll.Control = Me.cmdPrintAll
        Me.LcmdPrintAll.Location = New System.Drawing.Point(272, 1289)
        Me.LcmdPrintAll.Name = "LcmdPrintAll"
        Me.LcmdPrintAll.Size = New System.Drawing.Size(246, 43)
        Me.LcmdPrintAll.TextSize = New System.Drawing.Size(0, 0)
        Me.LcmdPrintAll.TextVisible = False
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(0, 1289)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(272, 43)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.Control = Me.cmdExit
        Me.LayoutControlItem29.Location = New System.Drawing.Point(732, 1289)
        Me.LayoutControlItem29.Name = "LayoutControlItem29"
        Me.LayoutControlItem29.Size = New System.Drawing.Size(181, 43)
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem29.TextVisible = False
        '
        'LayoutControlItem31
        '
        Me.LayoutControlItem31.Control = Me.chkCalculated
        Me.LayoutControlItem31.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem31.Name = "LayoutControlItem31"
        Me.LayoutControlItem31.Size = New System.Drawing.Size(210, 36)
        Me.LayoutControlItem31.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem31.TextVisible = False
        '
        'LayoutControlItem32
        '
        Me.LayoutControlItem32.Control = Me.chkPrintSyg
        Me.LayoutControlItem32.Location = New System.Drawing.Point(210, 0)
        Me.LayoutControlItem32.Name = "LayoutControlItem32"
        Me.LayoutControlItem32.Size = New System.Drawing.Size(205, 36)
        Me.LayoutControlItem32.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem32.TextVisible = False
        '
        'LayoutControlItem33
        '
        Me.LayoutControlItem33.Control = Me.chkPrintEidop
        Me.LayoutControlItem33.Location = New System.Drawing.Point(415, 0)
        Me.LayoutControlItem33.Name = "LayoutControlItem33"
        Me.LayoutControlItem33.Size = New System.Drawing.Size(171, 36)
        Me.LayoutControlItem33.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem33.TextVisible = False
        '
        'LayoutControlItem34
        '
        Me.LayoutControlItem34.Control = Me.chkPrintReceipt
        Me.LayoutControlItem34.Location = New System.Drawing.Point(586, 0)
        Me.LayoutControlItem34.Name = "LayoutControlItem34"
        Me.LayoutControlItem34.Size = New System.Drawing.Size(145, 36)
        Me.LayoutControlItem34.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem34.TextVisible = False
        '
        'LcmdNewInh
        '
        Me.LcmdNewInh.Control = Me.cmdNewInh
        Me.LcmdNewInh.Location = New System.Drawing.Point(0, 736)
        Me.LcmdNewInh.Name = "LcmdNewInh"
        Me.LcmdNewInh.Size = New System.Drawing.Size(208, 43)
        Me.LcmdNewInh.TextSize = New System.Drawing.Size(0, 0)
        Me.LcmdNewInh.TextVisible = False
        '
        'LcmdCancelInvoice
        '
        Me.LcmdCancelInvoice.Control = Me.cmdCancelInvoice
        Me.LcmdCancelInvoice.Location = New System.Drawing.Point(208, 736)
        Me.LcmdCancelInvoice.Name = "LcmdCancelInvoice"
        Me.LcmdCancelInvoice.Size = New System.Drawing.Size(244, 43)
        Me.LcmdCancelInvoice.TextSize = New System.Drawing.Size(0, 0)
        Me.LcmdCancelInvoice.TextVisible = False
        '
        'LcmdSaveINH
        '
        Me.LcmdSaveINH.Control = Me.cmdSaveINH
        Me.LcmdSaveINH.Location = New System.Drawing.Point(684, 736)
        Me.LcmdSaveINH.Name = "LcmdSaveINH"
        Me.LcmdSaveINH.Size = New System.Drawing.Size(229, 43)
        Me.LcmdSaveINH.TextSize = New System.Drawing.Size(0, 0)
        Me.LcmdSaveINH.TextVisible = False
        '
        'LcmdCancelCalculate
        '
        Me.LcmdCancelCalculate.Control = Me.cmdCancelCalculate
        Me.LcmdCancelCalculate.Location = New System.Drawing.Point(452, 736)
        Me.LcmdCancelCalculate.Name = "LcmdCancelCalculate"
        Me.LcmdCancelCalculate.Size = New System.Drawing.Size(232, 43)
        Me.LcmdCancelCalculate.TextSize = New System.Drawing.Size(0, 0)
        Me.LcmdCancelCalculate.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(913, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(30, 36)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem37
        '
        Me.LayoutControlItem37.Control = Me.chkEmail
        Me.LayoutControlItem37.Location = New System.Drawing.Point(731, 0)
        Me.LayoutControlItem37.Name = "LayoutControlItem37"
        Me.LayoutControlItem37.Size = New System.Drawing.Size(182, 36)
        Me.LayoutControlItem37.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem37.TextVisible = False
        '
        'Priamos_NETDataSet3
        '
        Me.Priamos_NETDataSet3.DataSetName = "Priamos_NETDataSet3"
        Me.Priamos_NETDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.TableAdapterManager.ANN_GRPSTableAdapter = Nothing
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
        'frmINH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(2533, 1352)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmINH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmParast"
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAPM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdIND, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PriamosNETDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwCALCCATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkreserveAPT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCalorimetric.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPrintReceipt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.txtColAnnouncement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lCanceled, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcmdSaveInd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcmdCalculate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcmdPrintAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcmdNewInh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcmdCancelInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcmdSaveINH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LcmdCancelCalculate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AHPBHBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwEXCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AHPBH1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LcmdSaveINH As DevExpress.XtraLayout.LayoutControlItem
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
    Friend WithEvents LcmdSaveInd As DevExpress.XtraLayout.LayoutControlItem
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
    Friend WithEvents LcmdCalculate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPage1 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPage2 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwINCBindingSource As BindingSource
    Friend WithEvents Vw_INCTableAdapter As Priamos_NETDataSetTableAdapters.vw_INCTableAdapter
    Friend WithEvents lbldate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grdIND As DevExpress.XtraGrid.GridControl
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
    Friend WithEvents LcmdPrintAll As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarSygentrotiki As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEidop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents XtraOpenFileDialog1 As DevExpress.XtraEditors.XtraOpenFileDialog
    Friend WithEvents colSelectedFiles As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colpaid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdNewInh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LcmdNewInh As DevExpress.XtraLayout.LayoutControlItem
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
    Friend WithEvents LcmdCancelInvoice As DevExpress.XtraLayout.LayoutControlItem
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
    Friend WithEvents BarReceipt As DevExpress.XtraBars.BarButtonItem
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
    Friend WithEvents LcmdCancelCalculate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents chkCalorimetric As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem36 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkEmail As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem37 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkreserveAPT As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem38 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem39 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtColAnnouncement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem40 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Priamos_NETDataSet3 As Priamos_NETDataSet3
    Friend WithEvents lblAHPB As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
End Class
