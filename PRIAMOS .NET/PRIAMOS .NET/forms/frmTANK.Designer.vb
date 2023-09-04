<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTANK
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
        Me.cmdRefreshMeasurement = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdDeleteMeasurement = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdAddMeasurement = New DevExpress.XtraEditors.CheckButton()
        Me.cboBDG = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwBDGBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NET_DataSet_BDG = New PRIAMOS.NET.Priamos_NET_DataSet_BDG()
        Me.grdTank = New DevExpress.XtraGrid.GridControl()
        Me.VwTANKBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbdgID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtMeasurement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colusrID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEditMeasurer = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwMEASURERSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colmeasurementcatID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEditMeasurementCat = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VwMEASUREMENTCATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colmes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmesB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmodifiedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreatedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMachineName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmeasurementCatName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colModifierName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbdgNam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeasurerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboMeasurementUsr = New DevExpress.XtraEditors.LookUpEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.txtLpcH = New DevExpress.XtraEditors.TextEdit()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.dtMeasurement = New DevExpress.XtraEditors.DateEdit()
        Me.cboMeasurementcat = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Vw_TANKTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_BDGTableAdapters.vw_TANKTableAdapter()
        Me.Vw_MEASURERSTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_BDGTableAdapters.vw_MEASURERSTableAdapter()
        Me.Vw_MEASUREMENT_CATTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_BDGTableAdapters.vw_MEASUREMENT_CATTableAdapter()
        Me.Vw_BDGTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_BDGTableAdapters.vw_BDGTableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwBDGBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NET_DataSet_BDG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwTANKBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEditMeasurer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwMEASURERSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEditMeasurementCat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwMEASUREMENTCATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMeasurementUsr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLpcH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtMeasurement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtMeasurement.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMeasurementcat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdRefreshMeasurement)
        Me.LayoutControl1.Controls.Add(Me.cmdDeleteMeasurement)
        Me.LayoutControl1.Controls.Add(Me.cmdAddMeasurement)
        Me.LayoutControl1.Controls.Add(Me.cboBDG)
        Me.LayoutControl1.Controls.Add(Me.grdTank)
        Me.LayoutControl1.Controls.Add(Me.cboMeasurementUsr)
        Me.LayoutControl1.Controls.Add(Me.TextEdit1)
        Me.LayoutControl1.Controls.Add(Me.txtLpcH)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.dtMeasurement)
        Me.LayoutControl1.Controls.Add(Me.cboMeasurementcat)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1472, 492, 1137, 700)
        Me.LayoutControl1.OptionsFocus.MoveFocusRightToLeft = False
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1585, 888)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdRefreshMeasurement
        '
        Me.cmdRefreshMeasurement.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_refresh_16
        Me.cmdRefreshMeasurement.Location = New System.Drawing.Point(12, 435)
        Me.cmdRefreshMeasurement.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdRefreshMeasurement.Name = "cmdRefreshMeasurement"
        Me.cmdRefreshMeasurement.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdRefreshMeasurement.Size = New System.Drawing.Size(31, 39)
        Me.cmdRefreshMeasurement.StyleController = Me.LayoutControl1
        Me.cmdRefreshMeasurement.TabIndex = 12
        '
        'cmdDeleteMeasurement
        '
        Me.cmdDeleteMeasurement.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.Remove_16x16
        Me.cmdDeleteMeasurement.Location = New System.Drawing.Point(12, 392)
        Me.cmdDeleteMeasurement.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdDeleteMeasurement.Name = "cmdDeleteMeasurement"
        Me.cmdDeleteMeasurement.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.cmdDeleteMeasurement.Size = New System.Drawing.Size(31, 39)
        Me.cmdDeleteMeasurement.StyleController = Me.LayoutControl1
        Me.cmdDeleteMeasurement.TabIndex = 11
        '
        'cmdAddMeasurement
        '
        Me.cmdAddMeasurement.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.AddFile_16x16
        Me.cmdAddMeasurement.Location = New System.Drawing.Point(12, 349)
        Me.cmdAddMeasurement.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdAddMeasurement.Name = "cmdAddMeasurement"
        Me.cmdAddMeasurement.Size = New System.Drawing.Size(31, 39)
        Me.cmdAddMeasurement.StyleController = Me.LayoutControl1
        Me.cmdAddMeasurement.TabIndex = 9
        '
        'cboBDG
        '
        Me.cboBDG.Location = New System.Drawing.Point(234, 54)
        Me.cboBDG.Margin = New System.Windows.Forms.Padding(5)
        Me.cboBDG.Name = "cboBDG"
        Me.cboBDG.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboBDG.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboBDG.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboBDG.Properties.DataSource = Me.VwBDGBindingSource
        Me.cboBDG.Properties.DisplayMember = "nam"
        Me.cboBDG.Properties.NullText = ""
        Me.cboBDG.Properties.PopupSizeable = False
        Me.cboBDG.Properties.ReadOnly = True
        Me.cboBDG.Properties.ValueMember = "ID"
        Me.cboBDG.Size = New System.Drawing.Size(1339, 38)
        Me.cboBDG.StyleController = Me.LayoutControl1
        Me.cboBDG.TabIndex = 2
        Me.cboBDG.Tag = "bdgid,0,1,2"
        '
        'VwBDGBindingSource
        '
        Me.VwBDGBindingSource.DataMember = "vw_BDG"
        Me.VwBDGBindingSource.DataSource = Me.Priamos_NET_DataSet_BDG
        '
        'Priamos_NET_DataSet_BDG
        '
        Me.Priamos_NET_DataSet_BDG.DataSetName = "Priamos_NET_DataSet_BDG"
        Me.Priamos_NET_DataSet_BDG.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'grdTank
        '
        Me.grdTank.DataSource = Me.VwTANKBindingSource
        Me.grdTank.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.grdTank.Location = New System.Drawing.Point(47, 349)
        Me.grdTank.MainView = Me.GridView3
        Me.grdTank.Margin = New System.Windows.Forms.Padding(5)
        Me.grdTank.Name = "grdTank"
        Me.grdTank.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEditMeasurementCat, Me.RepositoryItemLookUpEditMeasurer})
        Me.grdTank.Size = New System.Drawing.Size(1526, 527)
        Me.grdTank.TabIndex = 10
        Me.grdTank.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'VwTANKBindingSource
        '
        Me.VwTANKBindingSource.DataMember = "vw_TANK"
        Me.VwTANKBindingSource.DataSource = Me.Priamos_NET_DataSet_BDG
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colcode, Me.colbdgID, Me.coldtMeasurement, Me.colusrID, Me.colmeasurementcatID, Me.colmes, Me.colmesB, Me.colmodifiedBy, Me.colmodifiedOn, Me.colcreatedOn, Me.colcreatedBy, Me.colMachineName, Me.colmeasurementCatName, Me.colModifierName, Me.colbdgNam, Me.colMeasurerName})
        Me.GridView3.DetailHeight = 619
        Me.GridView3.GridControl = Me.grdTank
        Me.GridView3.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GridView3.LevelIndent = 0
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.PreviewIndent = 0
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
        'colbdgID
        '
        Me.colbdgID.FieldName = "bdgID"
        Me.colbdgID.MinWidth = 35
        Me.colbdgID.Name = "colbdgID"
        Me.colbdgID.Width = 131
        '
        'coldtMeasurement
        '
        Me.coldtMeasurement.Caption = "Ημερ/νία Μέτρησης"
        Me.coldtMeasurement.FieldName = "dtMeasurement"
        Me.coldtMeasurement.MinWidth = 35
        Me.coldtMeasurement.Name = "coldtMeasurement"
        Me.coldtMeasurement.Visible = True
        Me.coldtMeasurement.VisibleIndex = 0
        Me.coldtMeasurement.Width = 229
        '
        'colusrID
        '
        Me.colusrID.Caption = "Επιμετρητής"
        Me.colusrID.ColumnEdit = Me.RepositoryItemLookUpEditMeasurer
        Me.colusrID.FieldName = "usrID"
        Me.colusrID.MinWidth = 35
        Me.colusrID.Name = "colusrID"
        Me.colusrID.Visible = True
        Me.colusrID.VisibleIndex = 2
        Me.colusrID.Width = 265
        '
        'RepositoryItemLookUpEditMeasurer
        '
        Me.RepositoryItemLookUpEditMeasurer.AutoHeight = False
        Me.RepositoryItemLookUpEditMeasurer.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEditMeasurer.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("un", "un", 37, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("pwd", "pwd", 51, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Επιμετρητής", 106, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtLogin", "dt Login", 83, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("M_ID", "M_ID", 60, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("M_code", "M_code", 80, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("server", "server", 66, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("M_un", "M_un", 62, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("M_pwd", "M_pwd", 76, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("port", "port", 49, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ssl", "ssl", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MailID", "Mail ID", 74, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("m_RealName", "m_Real Name", 132, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtLogout", "dt Logout", 95, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Status", "Status", 67, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("isCollector", "is Collector", 104, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsMeasurer", "Is Measurer", 114, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemLookUpEditMeasurer.DataSource = Me.VwMEASURERSBindingSource
        Me.RepositoryItemLookUpEditMeasurer.DisplayMember = "RealName"
        Me.RepositoryItemLookUpEditMeasurer.Name = "RepositoryItemLookUpEditMeasurer"
        Me.RepositoryItemLookUpEditMeasurer.NullText = ""
        Me.RepositoryItemLookUpEditMeasurer.ValueMember = "ID"
        '
        'VwMEASURERSBindingSource
        '
        Me.VwMEASURERSBindingSource.DataMember = "vw_MEASURERS"
        Me.VwMEASURERSBindingSource.DataSource = Me.Priamos_NET_DataSet_BDG
        '
        'colmeasurementcatID
        '
        Me.colmeasurementcatID.Caption = "Κατηγορία Μέτρησης"
        Me.colmeasurementcatID.ColumnEdit = Me.RepositoryItemLookUpEditMeasurementCat
        Me.colmeasurementcatID.FieldName = "measurementcatID"
        Me.colmeasurementcatID.MinWidth = 35
        Me.colmeasurementcatID.Name = "colmeasurementcatID"
        Me.colmeasurementcatID.Visible = True
        Me.colmeasurementcatID.VisibleIndex = 1
        Me.colmeasurementcatID.Width = 261
        '
        'RepositoryItemLookUpEditMeasurementCat
        '
        Me.RepositoryItemLookUpEditMeasurementCat.AutoHeight = False
        Me.RepositoryItemLookUpEditMeasurementCat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEditMeasurementCat.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Κατηγορία", 62, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("isInvoice", "is Invoice", 93, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdBy", "created By", 104, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MachineName", "Machine Name", 140, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ModifierName", "Modifier Name", 137, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Fullname", "Fullname", 91, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("phn", "phn", 48, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mob", "mob", 52, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fax", "fax", 40, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("email", "email", 59, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("email2", "email2", 69, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("email3", "email3", 69, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("website", "website", 78, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("afm", "afm", 47, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("cmt", "cmt", 46, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Real Name", 106, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Name", "COU_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AREAS_Name", "AREAS_Name", 130, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Name", "ADR_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PRF_Name", "PRF_Name", 106, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CouID", "Cou ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AreaID", "Area ID", 79, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdrID", "Adr ID", 70, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DoyID", "Doy ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PrfID", "Prf ID", 64, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ar", "Ar", 33, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tk", "tk", 31, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("company", "company", 91, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Isprivate", "Isprivate", 87, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Isworkshop", "Isworkshop", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Issupplier", "Issupplier", 96, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsPartner", "Is Partner", 97, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdrAr", "Adr Ar", 68, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("color", "color", 55, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemLookUpEditMeasurementCat.DataSource = Me.VwMEASUREMENTCATBindingSource
        Me.RepositoryItemLookUpEditMeasurementCat.DisplayMember = "name"
        Me.RepositoryItemLookUpEditMeasurementCat.Name = "RepositoryItemLookUpEditMeasurementCat"
        Me.RepositoryItemLookUpEditMeasurementCat.NullText = ""
        Me.RepositoryItemLookUpEditMeasurementCat.ValueMember = "ID"
        '
        'VwMEASUREMENTCATBindingSource
        '
        Me.VwMEASUREMENTCATBindingSource.DataMember = "vw_MEASUREMENT_CAT"
        Me.VwMEASUREMENTCATBindingSource.DataSource = Me.Priamos_NET_DataSet_BDG
        '
        'colmes
        '
        Me.colmes.Caption = "Πόντοι(Τωρινή Μέτρηση)"
        Me.colmes.FieldName = "mes"
        Me.colmes.MinWidth = 35
        Me.colmes.Name = "colmes"
        Me.colmes.Visible = True
        Me.colmes.VisibleIndex = 3
        Me.colmes.Width = 247
        '
        'colmesB
        '
        Me.colmesB.Caption = "Πόντοι(Προηγ. Μέτρηση)"
        Me.colmesB.FieldName = "mesB"
        Me.colmesB.MinWidth = 35
        Me.colmesB.Name = "colmesB"
        Me.colmesB.Visible = True
        Me.colmesB.VisibleIndex = 4
        Me.colmesB.Width = 223
        '
        'colmodifiedBy
        '
        Me.colmodifiedBy.FieldName = "modifiedBy"
        Me.colmodifiedBy.MinWidth = 35
        Me.colmodifiedBy.Name = "colmodifiedBy"
        Me.colmodifiedBy.Width = 131
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
        Me.colcreatedOn.FieldName = "createdOn"
        Me.colcreatedOn.MinWidth = 35
        Me.colcreatedOn.Name = "colcreatedOn"
        Me.colcreatedOn.Width = 131
        '
        'colcreatedBy
        '
        Me.colcreatedBy.FieldName = "createdBy"
        Me.colcreatedBy.MinWidth = 35
        Me.colcreatedBy.Name = "colcreatedBy"
        Me.colcreatedBy.Width = 131
        '
        'colMachineName
        '
        Me.colMachineName.FieldName = "MachineName"
        Me.colMachineName.MinWidth = 35
        Me.colMachineName.Name = "colMachineName"
        Me.colMachineName.Width = 131
        '
        'colmeasurementCatName
        '
        Me.colmeasurementCatName.FieldName = "measurementCatName"
        Me.colmeasurementCatName.MinWidth = 35
        Me.colmeasurementCatName.Name = "colmeasurementCatName"
        Me.colmeasurementCatName.Width = 131
        '
        'colModifierName
        '
        Me.colModifierName.FieldName = "ModifierName"
        Me.colModifierName.MinWidth = 35
        Me.colModifierName.Name = "colModifierName"
        Me.colModifierName.Width = 131
        '
        'colbdgNam
        '
        Me.colbdgNam.FieldName = "bdgNam"
        Me.colbdgNam.MinWidth = 35
        Me.colbdgNam.Name = "colbdgNam"
        Me.colbdgNam.Width = 131
        '
        'colMeasurerName
        '
        Me.colMeasurerName.FieldName = "MeasurerName"
        Me.colMeasurerName.MinWidth = 35
        Me.colMeasurerName.Name = "colMeasurerName"
        Me.colMeasurerName.Width = 131
        '
        'cboMeasurementUsr
        '
        Me.cboMeasurementUsr.Location = New System.Drawing.Point(234, 138)
        Me.cboMeasurementUsr.Margin = New System.Windows.Forms.Padding(5)
        Me.cboMeasurementUsr.Name = "cboMeasurementUsr"
        Me.cboMeasurementUsr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboMeasurementUsr.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboMeasurementUsr.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Εισπράκτορας", 107, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboMeasurementUsr.Properties.DataSource = Me.VwMEASURERSBindingSource
        Me.cboMeasurementUsr.Properties.DisplayMember = "RealName"
        Me.cboMeasurementUsr.Properties.NullText = ""
        Me.cboMeasurementUsr.Properties.PopupSizeable = False
        Me.cboMeasurementUsr.Properties.ValueMember = "ID"
        Me.cboMeasurementUsr.Size = New System.Drawing.Size(1339, 38)
        Me.cboMeasurementUsr.StyleController = Me.LayoutControl1
        Me.cboMeasurementUsr.TabIndex = 4
        Me.cboMeasurementUsr.Tag = "usrID,0,1,2"
        '
        'TextEdit1
        '
        Me.TextEdit1.EditValue = "0,00"
        Me.TextEdit1.Location = New System.Drawing.Point(234, 264)
        Me.TextEdit1.Margin = New System.Windows.Forms.Padding(5)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit1.Properties.EditFormat.FormatString = "n2"
        Me.TextEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextEdit1.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextEdit1.Properties.MaskSettings.Set("mask", "n2")
        Me.TextEdit1.Size = New System.Drawing.Size(1339, 38)
        Me.TextEdit1.StyleController = Me.LayoutControl1
        Me.TextEdit1.TabIndex = 7
        Me.TextEdit1.Tag = "mesB,0,1,2"
        '
        'txtLpcH
        '
        Me.txtLpcH.EditValue = "0,00"
        Me.txtLpcH.Location = New System.Drawing.Point(234, 222)
        Me.txtLpcH.Margin = New System.Windows.Forms.Padding(5)
        Me.txtLpcH.Name = "txtLpcH"
        Me.txtLpcH.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLpcH.Properties.EditFormat.FormatString = "n2"
        Me.txtLpcH.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLpcH.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtLpcH.Properties.MaskSettings.Set("mask", "n2")
        Me.txtLpcH.Size = New System.Drawing.Size(1339, 38)
        Me.txtLpcH.StyleController = Me.LayoutControl1
        Me.txtLpcH.TabIndex = 6
        Me.txtLpcH.Tag = "mes,0,1,2"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(12, 306)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(1561, 39)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 8
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'dtMeasurement
        '
        Me.dtMeasurement.EditValue = Nothing
        Me.dtMeasurement.Location = New System.Drawing.Point(234, 96)
        Me.dtMeasurement.Margin = New System.Windows.Forms.Padding(5)
        Me.dtMeasurement.Name = "dtMeasurement"
        Me.dtMeasurement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtMeasurement.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtMeasurement.Properties.MaskSettings.Set("mask", "d")
        Me.dtMeasurement.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtMeasurement.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtMeasurement.Size = New System.Drawing.Size(1339, 38)
        Me.dtMeasurement.StyleController = Me.LayoutControl1
        Me.dtMeasurement.TabIndex = 3
        Me.dtMeasurement.Tag = "dtMeasurement,0,1,2"
        '
        'cboMeasurementcat
        '
        Me.cboMeasurementcat.Location = New System.Drawing.Point(234, 180)
        Me.cboMeasurementcat.Margin = New System.Windows.Forms.Padding(5)
        Me.cboMeasurementcat.Name = "cboMeasurementcat"
        Me.cboMeasurementcat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboMeasurementcat.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboMeasurementcat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboMeasurementcat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Κατηγορία", 62, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("isInvoice", "is Invoice", 93, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdBy", "created By", 104, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MachineName", "Machine Name", 140, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ModifierName", "Modifier Name", 137, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboMeasurementcat.Properties.DataSource = Me.VwMEASUREMENTCATBindingSource
        Me.cboMeasurementcat.Properties.DisplayMember = "name"
        Me.cboMeasurementcat.Properties.NullText = ""
        Me.cboMeasurementcat.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboMeasurementcat.Properties.PopupSizeable = False
        Me.cboMeasurementcat.Properties.ValueMember = "ID"
        Me.cboMeasurementcat.Size = New System.Drawing.Size(1339, 38)
        Me.cboMeasurementcat.StyleController = Me.LayoutControl1
        Me.cboMeasurementcat.TabIndex = 5
        Me.cboMeasurementcat.Tag = "measurementcatID,0,1,2"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(234, 12)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(5)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(215, 38)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 0
        Me.txtCode.Tag = "code,0"
        '
        'Root
        '
        Me.Root.CustomizationFormText = "Root"
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem6, Me.LayoutControlItem3, Me.LayoutControlItem9, Me.LayoutControlItem8, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem12})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1585, 888)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dtMeasurement
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1565, 42)
        Me.LayoutControlItem1.Text = "Ημερομηνία Μέτρησης"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(210, 23)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboMeasurementcat
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1565, 42)
        Me.LayoutControlItem2.Text = "Κατηγορία Μέτρησης"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(210, 23)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtLpcH
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 210)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1565, 42)
        Me.LayoutControlItem4.Text = "Πόντοι(Τωρινή Μέτρηση)"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(210, 23)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TextEdit1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 252)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1565, 42)
        Me.LayoutControlItem5.Text = "Πόντοι(Προηγ. Μέτρηση)"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(210, 23)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.grdTank
        Me.LayoutControlItem7.Location = New System.Drawing.Point(35, 337)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(1530, 531)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cboMeasurementUsr
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 126)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1565, 42)
        Me.LayoutControlItem6.Text = "Επιμετρητής"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(210, 23)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdSave
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 294)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1565, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtCode
        Me.LayoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem9.CustomizationFormText = "Κωδικός"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(441, 42)
        Me.LayoutControlItem9.Text = "Κωδικός"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(210, 23)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cboBDG
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(1565, 42)
        Me.LayoutControlItem8.Text = "Πολυκατοικία"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(210, 23)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(441, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1124, 42)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 466)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(35, 402)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.cmdAddMeasurement
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 337)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(35, 43)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cmdDeleteMeasurement
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 380)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(35, 43)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.cmdRefreshMeasurement
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 423)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(35, 43)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'Vw_TANKTableAdapter
        '
        Me.Vw_TANKTableAdapter.ClearBeforeFill = True
        '
        'Vw_MEASURERSTableAdapter
        '
        Me.Vw_MEASURERSTableAdapter.ClearBeforeFill = True
        '
        'Vw_MEASUREMENT_CATTableAdapter
        '
        Me.Vw_MEASUREMENT_CATTableAdapter.ClearBeforeFill = True
        '
        'Vw_BDGTableAdapter
        '
        Me.Vw_BDGTableAdapter.ClearBeforeFill = True
        '
        'frmTANK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1585, 888)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmTANK"
        Me.Text = "frmTANK"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwBDGBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NET_DataSet_BDG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwTANKBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEditMeasurer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwMEASURERSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEditMeasurementCat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwMEASUREMENTCATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMeasurementUsr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLpcH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtMeasurement.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtMeasurement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMeasurementcat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents dtMeasurement As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboMeasurementcat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtLpcH As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboMeasurementUsr As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grdTank As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemLookUpEditMeasurementCat As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboBDG As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwTANKBindingSource As BindingSource
    Friend WithEvents Priamos_NET_DataSet_BDG As Priamos_NET_DataSet_BDG
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbdgID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmeasurementcatID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colusrID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmodifiedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreatedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMachineName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmeasurementCatName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colModifierName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbdgNam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeasurerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Vw_TANKTableAdapter As Priamos_NET_DataSet_BDGTableAdapters.vw_TANKTableAdapter
    Friend WithEvents VwMEASURERSBindingSource As BindingSource
    Friend WithEvents Vw_MEASURERSTableAdapter As Priamos_NET_DataSet_BDGTableAdapters.vw_MEASURERSTableAdapter
    Friend WithEvents VwMEASUREMENTCATBindingSource As BindingSource
    Friend WithEvents Vw_MEASUREMENT_CATTableAdapter As Priamos_NET_DataSet_BDGTableAdapters.vw_MEASUREMENT_CATTableAdapter
    Friend WithEvents RepositoryItemLookUpEditMeasurer As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents coldtMeasurement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwBDGBindingSource As BindingSource
    Friend WithEvents Vw_BDGTableAdapter As Priamos_NET_DataSet_BDGTableAdapters.vw_BDGTableAdapter
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cmdAddMeasurement As DevExpress.XtraEditors.CheckButton
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdDeleteMeasurement As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdRefreshMeasurement As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colmes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmesB As DevExpress.XtraGrid.Columns.GridColumn
End Class
