<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTasks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTasks))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.dtCompleteDate = New DevExpress.XtraEditors.DateEdit()
        Me.cboCCT = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwPARTNERANDWORKSHOPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet = New PRIAMOS.NET.Priamos_NETDataSet()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtComments = New DevExpress.XtraEditors.MemoEdit()
        Me.txtdescription = New DevExpress.XtraEditors.TextEdit()
        Me.cboCase = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwCASESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbotaskCat = New DevExpress.XtraEditors.LookUpEdit()
        Me.VwTASKSCATBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem53 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Vw_CASESTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_CASESTableAdapter()
        Me.Vw_PARTNER_AND_WORKSHOPTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_PARTNER_AND_WORKSHOPTableAdapter()
        Me.Vw_TASKS_CATTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_TASKS_CATTableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.dtCompleteDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCompleteDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCCT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwPARTNERANDWORKSHOPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwCASESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbotaskCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwTASKSCATBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.dtCompleteDate)
        Me.LayoutControl1.Controls.Add(Me.cboCCT)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Controls.Add(Me.txtComments)
        Me.LayoutControl1.Controls.Add(Me.txtdescription)
        Me.LayoutControl1.Controls.Add(Me.cboCase)
        Me.LayoutControl1.Controls.Add(Me.cbotaskCat)
        Me.LayoutControl1.Location = New System.Drawing.Point(8, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(963, 742)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(713, 691)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(238, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 50
        Me.cmdExit.Text = "Έξοδος"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(468, 691)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(241, 39)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 49
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'dtCompleteDate
        '
        Me.dtCompleteDate.EditValue = Nothing
        Me.dtCompleteDate.Location = New System.Drawing.Point(223, 226)
        Me.dtCompleteDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtCompleteDate.Name = "dtCompleteDate"
        Me.dtCompleteDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtCompleteDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtCompleteDate.Properties.MaskSettings.Set("mask", "d")
        Me.dtCompleteDate.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtCompleteDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtCompleteDate.Size = New System.Drawing.Size(728, 38)
        Me.dtCompleteDate.StyleController = Me.LayoutControl1
        Me.dtCompleteDate.TabIndex = 38
        Me.dtCompleteDate.Tag = "dtVisit,0,1,2"
        '
        'cboCCT
        '
        Me.cboCCT.Location = New System.Drawing.Point(223, 138)
        Me.cboCCT.Margin = New System.Windows.Forms.Padding(5)
        Me.cboCCT.Name = "cboCCT"
        Me.cboCCT.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCCT.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboCCT.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboCCT.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Fullname", "Όνομα", 91, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("phn", "phn", 48, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mob", "mob", 52, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("fax", "fax", 40, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("email", "email", 59, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("email2", "email2", 69, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("email3", "email3", 69, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("website", "website", 78, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("afm", "afm", 47, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("cmt", "cmt", 46, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 62, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Real Name", 106, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("COU_Name", "COU_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AREAS_Name", "AREAS_Name", 130, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADR_Name", "ADR_Name", 110, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PRF_Name", "PRF_Name", 106, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CouID", "Cou ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AreaID", "Area ID", 79, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdrID", "Adr ID", 70, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DoyID", "Doy ID", 73, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PrfID", "Prf ID", 64, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ar", "Ar", 33, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tk", "tk", 31, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("company", "company", 91, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Isprivate", "Isprivate", 87, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Isworkshop", "Συνεργέιο", 110, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Issupplier", "Issupplier", 96, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsPartner", "Συνεργάτης", 97, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdrAr", "Adr Ar", 68, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("color", "color", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboCCT.Properties.DataSource = Me.VwPARTNERANDWORKSHOPBindingSource
        Me.cboCCT.Properties.DisplayMember = "Fullname"
        Me.cboCCT.Properties.NullText = ""
        Me.cboCCT.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboCCT.Properties.PopupSizeable = False
        Me.cboCCT.Properties.ValueMember = "ID"
        Me.cboCCT.Size = New System.Drawing.Size(728, 38)
        Me.cboCCT.StyleController = Me.LayoutControl1
        Me.cboCCT.TabIndex = 44
        Me.cboCCT.Tag = "cctid,0,1,2"
        '
        'VwPARTNERANDWORKSHOPBindingSource
        '
        Me.VwPARTNERANDWORKSHOPBindingSource.DataMember = "vw_PARTNER_AND_WORKSHOP"
        Me.VwPARTNERANDWORKSHOPBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'Priamos_NETDataSet
        '
        Me.Priamos_NETDataSet.DataSetName = "Priamos_NETDataSet"
        Me.Priamos_NETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(223, 12)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(5)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(101, 38)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 47
        Me.txtCode.Tag = "code,0"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(223, 268)
        Me.txtComments.Margin = New System.Windows.Forms.Padding(5)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(728, 419)
        Me.txtComments.StyleController = Me.LayoutControl1
        Me.txtComments.TabIndex = 46
        Me.txtComments.Tag = "cmt,0,1,2"
        '
        'txtdescription
        '
        Me.txtdescription.Location = New System.Drawing.Point(224, 182)
        Me.txtdescription.Margin = New System.Windows.Forms.Padding(5)
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(726, 38)
        Me.txtdescription.StyleController = Me.LayoutControl1
        Me.txtdescription.TabIndex = 9
        Me.txtdescription.Tag = "description,0,1,2"
        '
        'cboCase
        '
        Me.cboCase.Location = New System.Drawing.Point(223, 54)
        Me.cboCase.Margin = New System.Windows.Forms.Padding(5)
        Me.cboCase.Name = "cboCase"
        Me.cboCase.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCase.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboCase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboCase.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nam", "", 52, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Real Name", 106, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("description", "Υπόθεση", 106, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bdgID", "bdg ID", 74, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("complete", "complete", 91, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("dtDateComplete", "dt Date Complete", 161, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("cmt", "cmt", 46, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cboCase.Properties.DataSource = Me.VwCASESBindingSource
        Me.cboCase.Properties.DisplayMember = "description"
        Me.cboCase.Properties.NullText = ""
        Me.cboCase.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cboCase.Properties.PopupSizeable = False
        Me.cboCase.Properties.ValueMember = "ID"
        Me.cboCase.Size = New System.Drawing.Size(728, 38)
        Me.cboCase.StyleController = Me.LayoutControl1
        Me.cboCase.TabIndex = 44
        Me.cboCase.Tag = "caseid,0,1,2"
        '
        'VwCASESBindingSource
        '
        Me.VwCASESBindingSource.DataMember = "vw_CASES"
        Me.VwCASESBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'cbotaskCat
        '
        Me.cbotaskCat.Location = New System.Drawing.Point(223, 96)
        Me.cbotaskCat.Margin = New System.Windows.Forms.Padding(5)
        Me.cbotaskCat.Name = "cbotaskCat"
        Me.cbotaskCat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cbotaskCat.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cbotaskCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cbotaskCat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code", 55, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Εργασία", 62, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedBy", "modified By", 113, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("modifiedOn", "modified On", 117, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("createdOn", "created On", 108, DevExpress.Utils.FormatType.DateTime, "d/M/yyyy", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RealName", "Real Name", 106, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cbotaskCat.Properties.DataSource = Me.VwTASKSCATBindingSource
        Me.cbotaskCat.Properties.DisplayMember = "name"
        Me.cbotaskCat.Properties.NullText = ""
        Me.cbotaskCat.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.cbotaskCat.Properties.PopupSizeable = False
        Me.cbotaskCat.Properties.ValueMember = "ID"
        Me.cbotaskCat.Size = New System.Drawing.Size(728, 38)
        Me.cbotaskCat.StyleController = Me.LayoutControl1
        Me.cbotaskCat.TabIndex = 44
        Me.cbotaskCat.Tag = "taskCatid,0,1,2"
        '
        'VwTASKSCATBindingSource
        '
        Me.VwTASKSCATBindingSource.DataMember = "vw_TASKS_CAT"
        Me.VwTASKSCATBindingSource.DataSource = Me.Priamos_NETDataSet
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem9, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.LayoutControlItem8, Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem53, Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(963, 742)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboCCT
        Me.LayoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem5.CustomizationFormText = "Πολυκατοικία"
        Me.LayoutControlItem5.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 126)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(943, 42)
        Me.LayoutControlItem5.Tag = "1"
        Me.LayoutControlItem5.Text = "Συνεργείο/Συνεργάτης"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(199, 23)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtCode
        Me.LayoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem9.CustomizationFormText = "Κωδικός"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(316, 42)
        Me.LayoutControlItem9.Text = "Κωδικός"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(199, 23)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(316, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(627, 42)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdSave
        Me.LayoutControlItem2.Location = New System.Drawing.Point(456, 679)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(245, 43)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 679)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(456, 43)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdExit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(701, 679)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(242, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtComments
        Me.LayoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem8.CustomizationFormText = "Σχόλια"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 256)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(943, 423)
        Me.LayoutControlItem8.Text = "Σχόλια"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(199, 23)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtdescription
        Me.LayoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem4.CustomizationFormText = "Έξοδο"
        Me.LayoutControlItem4.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem4.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 4, 4)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(943, 46)
        Me.LayoutControlItem4.Tag = "1"
        Me.LayoutControlItem4.Text = "Περιγραφή"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(199, 23)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cboCase
        Me.LayoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem6.CustomizationFormText = "Πολυκατοικία"
        Me.LayoutControlItem6.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(943, 42)
        Me.LayoutControlItem6.Tag = "1"
        Me.LayoutControlItem6.Text = "Υπόθεση"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(199, 23)
        '
        'LayoutControlItem53
        '
        Me.LayoutControlItem53.Control = Me.dtCompleteDate
        Me.LayoutControlItem53.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem53.CustomizationFormText = "Ημερομηνία Τιμ."
        Me.LayoutControlItem53.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem53.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem53.Location = New System.Drawing.Point(0, 214)
        Me.LayoutControlItem53.Name = "LayoutControlItem53"
        Me.LayoutControlItem53.Size = New System.Drawing.Size(943, 42)
        Me.LayoutControlItem53.Tag = "1"
        Me.LayoutControlItem53.Text = "Ημερ/νία Επίσκεψης"
        Me.LayoutControlItem53.TextSize = New System.Drawing.Size(199, 23)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cbotaskCat
        Me.LayoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem1.CustomizationFormText = "Πολυκατοικία"
        Me.LayoutControlItem1.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(943, 42)
        Me.LayoutControlItem1.Text = "Εργασία"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(199, 23)
        '
        'Vw_CASESTableAdapter
        '
        Me.Vw_CASESTableAdapter.ClearBeforeFill = True
        '
        'Vw_PARTNER_AND_WORKSHOPTableAdapter
        '
        Me.Vw_PARTNER_AND_WORKSHOPTableAdapter.ClearBeforeFill = True
        '
        'Vw_TASKS_CATTableAdapter
        '
        Me.Vw_TASKS_CATTableAdapter.ClearBeforeFill = True
        '
        'frmTasks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 746)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmTasks"
        Me.Text = "Εργασίες"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.dtCompleteDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCompleteDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCCT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwPARTNERANDWORKSHOPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwCASESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbotaskCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwTASKSCATBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtCompleteDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboCCT As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtComments As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtdescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem53 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboCase As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Priamos_NETDataSet As Priamos_NETDataSet
    Friend WithEvents VwCASESBindingSource As BindingSource
    Friend WithEvents Vw_CASESTableAdapter As Priamos_NETDataSetTableAdapters.vw_CASESTableAdapter
    Friend WithEvents VwPARTNERANDWORKSHOPBindingSource As BindingSource
    Friend WithEvents Vw_PARTNER_AND_WORKSHOPTableAdapter As Priamos_NETDataSetTableAdapters.vw_PARTNER_AND_WORKSHOPTableAdapter
    Friend WithEvents cbotaskCat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VwTASKSCATBindingSource As BindingSource
    Friend WithEvents Vw_TASKS_CATTableAdapter As Priamos_NETDataSetTableAdapters.vw_TASKS_CATTableAdapter
End Class
