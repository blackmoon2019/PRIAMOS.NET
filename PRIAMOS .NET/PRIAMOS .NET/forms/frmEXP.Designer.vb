<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEXP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEXP))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPartner = New DevExpress.XtraEditors.CheckEdit()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtNam = New DevExpress.XtraEditors.TextEdit()
        Me.cboEXC = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboMLC = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtTK = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPartner.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNam.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEXC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMLC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.CheckEdit1)
        Me.LayoutControl1.Controls.Add(Me.chkPartner)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Controls.Add(Me.txtNam)
        Me.LayoutControl1.Controls.Add(Me.cboEXC)
        Me.LayoutControl1.Controls.Add(Me.cboMLC)
        Me.LayoutControl1.Controls.Add(Me.txtTK)
        Me.LayoutControl1.Location = New System.Drawing.Point(-2, 16)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(943, 340)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem1, Me.LayoutControlItem9, Me.LayoutControlItem5, Me.LayoutControlItem3, Me.LayoutControlItem7, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.EmptySpaceItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(913, 346)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(639, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(240, 270)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(319, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(320, 46)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(738, 366)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(183, 50)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "Έξοδος"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(543, 366)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(185, 50)
        Me.cmdSave.TabIndex = 15
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'CheckEdit1
        '
        Me.CheckEdit1.EditValue = CType(0, Byte)
        Me.CheckEdit1.Location = New System.Drawing.Point(20, 292)
        Me.CheckEdit1.Margin = New System.Windows.Forms.Padding(5)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "Ενεργό"
        Me.CheckEdit1.Properties.ValueChecked = CType(1, Byte)
        Me.CheckEdit1.Properties.ValueUnchecked = CType(0, Byte)
        Me.CheckEdit1.Size = New System.Drawing.Size(873, 32)
        Me.CheckEdit1.StyleController = Me.LayoutControl1
        Me.CheckEdit1.TabIndex = 41
        Me.CheckEdit1.Tag = "active,0,1,2"
        '
        'chkPartner
        '
        Me.chkPartner.EditValue = CType(0, Byte)
        Me.chkPartner.Location = New System.Drawing.Point(20, 252)
        Me.chkPartner.Margin = New System.Windows.Forms.Padding(5)
        Me.chkPartner.Name = "chkPartner"
        Me.chkPartner.Properties.Caption = "Εμφάνιση από/έως"
        Me.chkPartner.Properties.ValueChecked = CType(1, Byte)
        Me.chkPartner.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkPartner.Size = New System.Drawing.Size(633, 32)
        Me.chkPartner.StyleController = Me.LayoutControl1
        Me.chkPartner.TabIndex = 40
        Me.chkPartner.Tag = "fromto,0,1,2"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(230, 22)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(5)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(103, 38)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 4
        Me.txtCode.Tag = "code,0"
        '
        'txtNam
        '
        Me.txtNam.Location = New System.Drawing.Point(230, 68)
        Me.txtNam.Margin = New System.Windows.Forms.Padding(5)
        Me.txtNam.Name = "txtNam"
        Me.txtNam.Size = New System.Drawing.Size(423, 38)
        Me.txtNam.StyleController = Me.LayoutControl1
        Me.txtNam.TabIndex = 9
        Me.txtNam.Tag = "name,0,1,2"
        '
        'cboEXC
        '
        Me.cboEXC.Location = New System.Drawing.Point(230, 160)
        Me.cboEXC.Margin = New System.Windows.Forms.Padding(5)
        Me.cboEXC.Name = "cboEXC"
        Me.cboEXC.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboEXC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboEXC.Properties.NullText = ""
        Me.cboEXC.Properties.PopupSizeable = False
        Me.cboEXC.Size = New System.Drawing.Size(423, 38)
        Me.cboEXC.StyleController = Me.LayoutControl1
        Me.cboEXC.TabIndex = 5
        Me.cboEXC.Tag = "excID,0,1,2"
        '
        'cboMLC
        '
        Me.cboMLC.Location = New System.Drawing.Point(230, 206)
        Me.cboMLC.Margin = New System.Windows.Forms.Padding(5)
        Me.cboMLC.Name = "cboMLC"
        Me.cboMLC.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboMLC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboMLC.Properties.NullText = ""
        Me.cboMLC.Properties.PopupSizeable = False
        Me.cboMLC.Size = New System.Drawing.Size(423, 38)
        Me.cboMLC.StyleController = Me.LayoutControl1
        Me.cboMLC.TabIndex = 6
        Me.cboMLC.Tag = "mlcID,0,1,2"
        '
        'txtTK
        '
        Me.txtTK.Location = New System.Drawing.Point(230, 114)
        Me.txtTK.Margin = New System.Windows.Forms.Padding(5)
        Me.txtTK.Name = "txtTK"
        Me.txtTK.Size = New System.Drawing.Size(423, 38)
        Me.txtTK.StyleController = Me.LayoutControl1
        Me.txtTK.TabIndex = 8
        Me.txtTK.Tag = "repname,0,1,2"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtCode
        Me.LayoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem4.CustomizationFormText = "Κωδικός"
        Me.LayoutControlItem4.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(319, 46)
        Me.LayoutControlItem4.Text = "Κωδικός"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(190, 23)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtNam
        Me.LayoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem1.CustomizationFormText = "Έξοδο"
        Me.LayoutControlItem1.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem1.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 46)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(639, 46)
        Me.LayoutControlItem1.Tag = "1"
        Me.LayoutControlItem1.Text = "Περιγραφή"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(190, 23)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cboEXC
        Me.LayoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem9.CustomizationFormText = "Νομός"
        Me.LayoutControlItem9.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem9.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 138)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(639, 46)
        Me.LayoutControlItem9.Tag = "1"
        Me.LayoutControlItem9.Text = "Κατηγορίες Εξόδων"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(190, 23)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboMLC
        Me.LayoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem5.CustomizationFormText = "Περιοχή"
        Me.LayoutControlItem5.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem5.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 184)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(639, 46)
        Me.LayoutControlItem5.Tag = "1"
        Me.LayoutControlItem5.Text = "Κατηγορίες Χιλιοστών"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(190, 23)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.chkPartner
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 230)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(639, 40)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.CheckEdit1
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 270)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(879, 40)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtTK
        Me.LayoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem6.CustomizationFormText = "Τ.Κ"
        Me.LayoutControlItem6.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 92)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(639, 46)
        Me.LayoutControlItem6.Text = "Λεκτικό Εκτύπωσης"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(190, 23)
        '
        'frmEXP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 430)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "frmEXP"
        Me.Text = "Έξοδα"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPartner.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNam.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEXC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMLC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtNam As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboEXC As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboMLC As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtTK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPartner As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
End Class
