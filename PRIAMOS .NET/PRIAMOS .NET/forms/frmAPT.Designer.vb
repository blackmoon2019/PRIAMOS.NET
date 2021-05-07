<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAPT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAPT))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboBDG = New DevExpress.XtraEditors.LookUpEdit()
        Me.chkOut = New DevExpress.XtraEditors.CheckEdit()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.cboTenant = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboOwner = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtComments = New DevExpress.XtraEditors.MemoEdit()
        Me.chkClosed = New DevExpress.XtraEditors.CheckEdit()
        Me.cboFloor = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtOrd = New DevExpress.XtraEditors.SpinEdit()
        Me.txtBal = New DevExpress.XtraEditors.TextEdit()
        Me.txtTtl = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTenant.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOwner.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkClosed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFloor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTtl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cboBDG)
        Me.LayoutControl1.Controls.Add(Me.chkOut)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.cboTenant)
        Me.LayoutControl1.Controls.Add(Me.cboOwner)
        Me.LayoutControl1.Controls.Add(Me.txtComments)
        Me.LayoutControl1.Controls.Add(Me.chkClosed)
        Me.LayoutControl1.Controls.Add(Me.cboFloor)
        Me.LayoutControl1.Controls.Add(Me.txtOrd)
        Me.LayoutControl1.Controls.Add(Me.txtBal)
        Me.LayoutControl1.Controls.Add(Me.txtTtl)
        Me.LayoutControl1.Location = New System.Drawing.Point(-4, -9)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1244, 259, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(477, 341)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cboBDG
        '
        Me.cboBDG.Location = New System.Drawing.Point(129, 36)
        Me.cboBDG.Name = "cboBDG"
        Me.cboBDG.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboBDG.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboBDG.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboBDG.Properties.NullText = ""
        Me.cboBDG.Properties.PopupSizeable = False
        Me.cboBDG.Properties.ReadOnly = True
        Me.cboBDG.Size = New System.Drawing.Size(223, 20)
        Me.cboBDG.StyleController = Me.LayoutControl1
        Me.cboBDG.TabIndex = 23
        Me.cboBDG.Tag = "bdgid,0,1,2"
        '
        'chkOut
        '
        Me.chkOut.EditValue = CType(0, Byte)
        Me.chkOut.Location = New System.Drawing.Point(174, 156)
        Me.chkOut.Name = "chkOut"
        Me.chkOut.Properties.Caption = "Εκτός"
        Me.chkOut.Properties.ValueChecked = CType(1, Byte)
        Me.chkOut.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkOut.Size = New System.Drawing.Size(291, 18)
        Me.chkOut.StyleController = Me.LayoutControl1
        Me.chkOut.TabIndex = 22
        Me.chkOut.Tag = "out,0,1,2"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(129, 12)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(57, 20)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 4
        Me.txtCode.Tag = "code,0"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(129, 60)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(82, 20)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 8
        Me.txtName.Tag = "nam,0,1,2"
        '
        'cboTenant
        '
        Me.cboTenant.Location = New System.Drawing.Point(129, 108)
        Me.cboTenant.Name = "cboTenant"
        Me.cboTenant.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboTenant.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboTenant.Properties.NullText = ""
        Me.cboTenant.Properties.PopupSizeable = False
        Me.cboTenant.Size = New System.Drawing.Size(336, 20)
        Me.cboTenant.StyleController = Me.LayoutControl1
        Me.cboTenant.TabIndex = 6
        Me.cboTenant.Tag = "TenantID,0,1,2"
        '
        'cboOwner
        '
        Me.cboOwner.Location = New System.Drawing.Point(129, 132)
        Me.cboOwner.Name = "cboOwner"
        Me.cboOwner.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboOwner.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboOwner.Properties.NullText = ""
        Me.cboOwner.Properties.PopupSizeable = False
        Me.cboOwner.Size = New System.Drawing.Size(336, 20)
        Me.cboOwner.StyleController = Me.LayoutControl1
        Me.cboOwner.TabIndex = 5
        Me.cboOwner.Tag = "OwnerID,0,1,2"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(45, 178)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(420, 103)
        Me.txtComments.StyleController = Me.LayoutControl1
        Me.txtComments.TabIndex = 17
        Me.txtComments.Tag = "cmt,0,1,2"
        '
        'chkClosed
        '
        Me.chkClosed.EditValue = CType(0, Byte)
        Me.chkClosed.Location = New System.Drawing.Point(12, 156)
        Me.chkClosed.Name = "chkClosed"
        Me.chkClosed.Properties.Caption = "Κλειστό"
        Me.chkClosed.Properties.ValueChecked = CType(1, Byte)
        Me.chkClosed.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkClosed.Size = New System.Drawing.Size(158, 18)
        Me.chkClosed.StyleController = Me.LayoutControl1
        Me.chkClosed.TabIndex = 18
        Me.chkClosed.Tag = "closed,0,1,2"
        '
        'cboFloor
        '
        Me.cboFloor.Location = New System.Drawing.Point(129, 84)
        Me.cboFloor.Name = "cboFloor"
        Me.cboFloor.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboFloor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFloor.Properties.NullText = ""
        Me.cboFloor.Properties.PopupSizeable = False
        Me.cboFloor.Size = New System.Drawing.Size(99, 20)
        Me.cboFloor.StyleController = Me.LayoutControl1
        Me.cboFloor.TabIndex = 6
        Me.cboFloor.Tag = "flrid,0,1,2"
        '
        'txtOrd
        '
        Me.txtOrd.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtOrd.Location = New System.Drawing.Point(255, 84)
        Me.txtOrd.Name = "txtOrd"
        Me.txtOrd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtOrd.Properties.IsFloatValue = False
        Me.txtOrd.Properties.MaskSettings.Set("mask", "N00")
        Me.txtOrd.Size = New System.Drawing.Size(210, 20)
        Me.txtOrd.StyleController = Me.LayoutControl1
        Me.txtOrd.TabIndex = 21
        Me.txtOrd.Tag = "ord,0,1,2"
        '
        'txtBal
        '
        Me.txtBal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtBal.Location = New System.Drawing.Point(129, 309)
        Me.txtBal.Name = "txtBal"
        Me.txtBal.Properties.DisplayFormat.FormatString = "c"
        Me.txtBal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtBal.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtBal.Properties.ReadOnly = True
        Me.txtBal.Size = New System.Drawing.Size(86, 20)
        Me.txtBal.StyleController = Me.LayoutControl1
        Me.txtBal.TabIndex = 15
        Me.txtBal.Tag = "bal,0"
        '
        'txtTtl
        '
        Me.txtTtl.Location = New System.Drawing.Point(129, 285)
        Me.txtTtl.Name = "txtTtl"
        Me.txtTtl.Size = New System.Drawing.Size(336, 20)
        Me.txtTtl.StyleController = Me.LayoutControl1
        Me.txtTtl.TabIndex = 8
        Me.txtTtl.Tag = "ttl,0,1,2"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem2, Me.LayoutControlItem14, Me.LayoutControlItem3, Me.LayoutControlItem18, Me.LayoutControlItem5, Me.LayoutControlItem4, Me.EmptySpaceItem5, Me.LayoutControlItem6, Me.LayoutControlItem15, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem7, Me.EmptySpaceItem6, Me.LayoutControlItem20, Me.LayoutControlItem19})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(477, 341)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(178, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(279, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.txtComments
        Me.LayoutControlItem14.CustomizationFormText = "Σχόλια"
        Me.LayoutControlItem14.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 166)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(457, 107)
        Me.LayoutControlItem14.Text = "Σχόλια"
        Me.LayoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(32, 13)
        Me.LayoutControlItem14.TextToControlDistance = 1
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboTenant
        Me.LayoutControlItem3.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(457, 24)
        Me.LayoutControlItem3.Text = "Ένοικος"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.cboFloor
        Me.LayoutControlItem18.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem18.CustomizationFormText = "Ένοικος"
        Me.LayoutControlItem18.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(220, 24)
        Me.LayoutControlItem18.Tag = ""
        Me.LayoutControlItem18.Text = "Όροφος"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtName
        Me.LayoutControlItem5.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem5.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(203, 24)
        Me.LayoutControlItem5.Tag = "1"
        Me.LayoutControlItem5.Text = "Διαμέρισμα"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtBal
        Me.LayoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem4.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 297)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.OptionsPrint.AppearanceItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem4.OptionsPrint.AppearanceItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LayoutControlItem4.OptionsPrint.AppearanceItem.Options.UseFont = True
        Me.LayoutControlItem4.OptionsPrint.AppearanceItem.Options.UseForeColor = True
        Me.LayoutControlItem4.OptionsPrint.AppearanceItemControl.ForeColor = System.Drawing.Color.Navy
        Me.LayoutControlItem4.OptionsPrint.AppearanceItemControl.Options.UseForeColor = True
        Me.LayoutControlItem4.OptionsPrint.AppearanceItemText.ForeColor = System.Drawing.Color.Navy
        Me.LayoutControlItem4.OptionsPrint.AppearanceItemText.Options.UseForeColor = True
        Me.LayoutControlItem4.Size = New System.Drawing.Size(207, 24)
        Me.LayoutControlItem4.Text = "Υπόλοιπο"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(105, 13)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(207, 297)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(250, 24)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtTtl
        Me.LayoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem6.CustomizationFormText = "Διαμέρισμα"
        Me.LayoutControlItem6.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem6.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 273)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(457, 24)
        Me.LayoutControlItem6.Tag = "1"
        Me.LayoutControlItem6.Text = "Λεκτικό Εκτύπωσης"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.chkClosed
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(162, 22)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboOwner
        Me.LayoutControlItem2.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(457, 24)
        Me.LayoutControlItem2.Text = "Ιδιοκτήτης"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(105, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(203, 48)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(254, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtCode
        Me.LayoutControlItem1.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(178, 24)
        Me.LayoutControlItem1.Text = "Κωδικός"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cboBDG
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(344, 24)
        Me.LayoutControlItem7.Text = "Πολυκατοικία"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(105, 13)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(344, 24)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(113, 24)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.chkOut
        Me.LayoutControlItem20.Location = New System.Drawing.Point(162, 144)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(295, 22)
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem20.TextVisible = False
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.txtOrd
        Me.LayoutControlItem19.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem19.Location = New System.Drawing.Point(220, 72)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(237, 24)
        Me.LayoutControlItem19.Text = "Α/Α"
        Me.LayoutControlItem19.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(18, 13)
        Me.LayoutControlItem19.TextToControlDistance = 5
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(352, 325)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(110, 28)
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Έξοδος"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(235, 325)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(111, 28)
        Me.cmdSave.TabIndex = 13
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'frmAPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 362)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmAPT"
        Me.Text = "frmAPT"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboBDG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTenant.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOwner.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkClosed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFloor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTtl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtComments As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents chkClosed As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboTenant As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboOwner As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboFloor As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtOrd As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkOut As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtTtl As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboBDG As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
End Class
