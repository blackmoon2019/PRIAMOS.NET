<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIEP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIEP))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.chkCreateCol = New DevExpress.XtraEditors.CheckEdit()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.cboCaclCat = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtrepname = New DevExpress.XtraEditors.TextEdit()
        Me.txtAmt = New DevExpress.XtraEditors.TextEdit()
        Me.cboOwnerTenant = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem45 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.chkCreateCol.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCaclCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtrepname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOwnerTenant.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkCreateCol)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Controls.Add(Me.cboCaclCat)
        Me.LayoutControl1.Controls.Add(Me.txtrepname)
        Me.LayoutControl1.Controls.Add(Me.txtAmt)
        Me.LayoutControl1.Controls.Add(Me.cboOwnerTenant)
        Me.LayoutControl1.Location = New System.Drawing.Point(-2, -9)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(697, 382)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'chkCreateCol
        '
        Me.chkCreateCol.EditValue = CType(0, Byte)
        Me.chkCreateCol.Location = New System.Drawing.Point(12, 222)
        Me.chkCreateCol.Margin = New System.Windows.Forms.Padding(5)
        Me.chkCreateCol.Name = "chkCreateCol"
        Me.chkCreateCol.Properties.Caption = "Δημιουργία είσπραξης"
        Me.chkCreateCol.Properties.ValueChecked = CType(1, Byte)
        Me.chkCreateCol.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkCreateCol.Size = New System.Drawing.Size(673, 32)
        Me.chkCreateCol.StyleController = Me.LayoutControl1
        Me.chkCreateCol.TabIndex = 52
        Me.chkCreateCol.Tag = "createCol,0,1,2"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(194, 12)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(5)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(192, 38)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 4
        Me.txtCode.Tag = "code,0"
        '
        'cboCaclCat
        '
        Me.cboCaclCat.Location = New System.Drawing.Point(194, 138)
        Me.cboCaclCat.Margin = New System.Windows.Forms.Padding(5)
        Me.cboCaclCat.Name = "cboCaclCat"
        Me.cboCaclCat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboCaclCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboCaclCat.Properties.NullText = ""
        Me.cboCaclCat.Properties.PopupSizeable = False
        Me.cboCaclCat.Size = New System.Drawing.Size(491, 38)
        Me.cboCaclCat.StyleController = Me.LayoutControl1
        Me.cboCaclCat.TabIndex = 5
        Me.cboCaclCat.Tag = "calcCatID,0,1,2"
        '
        'txtrepname
        '
        Me.txtrepname.Location = New System.Drawing.Point(194, 54)
        Me.txtrepname.Margin = New System.Windows.Forms.Padding(5)
        Me.txtrepname.Name = "txtrepname"
        Me.txtrepname.Size = New System.Drawing.Size(491, 38)
        Me.txtrepname.StyleController = Me.LayoutControl1
        Me.txtrepname.TabIndex = 8
        Me.txtrepname.Tag = "repname,0,1,2"
        '
        'txtAmt
        '
        Me.txtAmt.EditValue = "0,00 €"
        Me.txtAmt.Location = New System.Drawing.Point(194, 180)
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
        Me.txtAmt.Size = New System.Drawing.Size(491, 38)
        Me.txtAmt.StyleController = Me.LayoutControl1
        Me.txtAmt.TabIndex = 42
        Me.txtAmt.Tag = "amt,0,1,2"
        '
        'cboOwnerTenant
        '
        Me.cboOwnerTenant.EditValue = CType(0, Byte)
        Me.cboOwnerTenant.Location = New System.Drawing.Point(194, 96)
        Me.cboOwnerTenant.Margin = New System.Windows.Forms.Padding(5)
        Me.cboOwnerTenant.Name = "cboOwnerTenant"
        Me.cboOwnerTenant.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboOwnerTenant.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cboOwnerTenant.Properties.Items.AddRange(New Object() {"Ιδιοκτήτης", "Ένοικος"})
        Me.cboOwnerTenant.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboOwnerTenant.Size = New System.Drawing.Size(491, 38)
        Me.cboOwnerTenant.StyleController = Me.LayoutControl1
        Me.cboOwnerTenant.TabIndex = 51
        Me.cboOwnerTenant.Tag = "owner_tenant,0,1,2"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem9, Me.LayoutControlItem6, Me.EmptySpaceItem2, Me.LayoutControlItem45, Me.LayoutControlItem13, Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(697, 382)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtCode
        Me.LayoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem4.CustomizationFormText = "Κωδικός"
        Me.LayoutControlItem4.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(378, 42)
        Me.LayoutControlItem4.Text = "Κωδικός"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(170, 23)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cboCaclCat
        Me.LayoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem9.CustomizationFormText = "Τύπος Υπολογισμού"
        Me.LayoutControlItem9.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 126)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(677, 42)
        Me.LayoutControlItem9.Tag = ""
        Me.LayoutControlItem9.Text = "Τύπος Υπολογισμού"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(170, 23)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtrepname
        Me.LayoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem6.CustomizationFormText = "Τ.Κ"
        Me.LayoutControlItem6.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(677, 42)
        Me.LayoutControlItem6.Text = "Λεκτικό Εκτύπωσης"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(170, 23)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(378, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(299, 42)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem45
        '
        Me.LayoutControlItem45.Control = Me.txtAmt
        Me.LayoutControlItem45.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem45.CustomizationFormText = "Ποσό"
        Me.LayoutControlItem45.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem45.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem45.Name = "LayoutControlItem45"
        Me.LayoutControlItem45.Size = New System.Drawing.Size(677, 42)
        Me.LayoutControlItem45.Text = "Ποσό"
        Me.LayoutControlItem45.TextSize = New System.Drawing.Size(170, 23)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.cboOwnerTenant
        Me.LayoutControlItem13.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem13.CustomizationFormText = "Ένοικος/Ιδιοκτήτης"
        Me.LayoutControlItem13.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem13.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(677, 42)
        Me.LayoutControlItem13.Text = "Ένοικος/Ιδιοκτήτης"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(170, 23)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.chkCreateCol
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 210)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(677, 152)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(493, 368)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(183, 50)
        Me.cmdExit.TabIndex = 16
        Me.cmdExit.Text = "Έξοδος"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(298, 368)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(185, 50)
        Me.cmdSave.TabIndex = 17
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'frmIEP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(692, 428)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmIEP"
        Me.Text = "Πάγια έξοδα πολυκατοικίας"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.chkCreateCol.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCaclCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtrepname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOwnerTenant.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboCaclCat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtrepname As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtAmt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem45 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboOwnerTenant As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkCreateCol As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
End Class
