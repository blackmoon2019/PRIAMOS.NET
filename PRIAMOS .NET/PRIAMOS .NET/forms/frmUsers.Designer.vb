<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtPWD = New DevExpress.XtraEditors.TextEdit()
        Me.txtRealName = New DevExpress.XtraEditors.TextEdit()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtUN = New DevExpress.XtraEditors.TextEdit()
        Me.cboMail = New DevExpress.XtraEditors.LookUpEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.chkisCollector = New DevExpress.XtraEditors.CheckEdit()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRealName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkisCollector.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkisCollector)
        Me.LayoutControl1.Controls.Add(Me.txtPWD)
        Me.LayoutControl1.Controls.Add(Me.txtRealName)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.txtUN)
        Me.LayoutControl1.Controls.Add(Me.cboMail)
        Me.LayoutControl1.Location = New System.Drawing.Point(-6, -8)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(416, 136, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(838, 280)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(162, 54)
        Me.txtPWD.Margin = New System.Windows.Forms.Padding(5)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(664, 38)
        Me.txtPWD.StyleController = Me.LayoutControl1
        Me.txtPWD.TabIndex = 4
        Me.txtPWD.Tag = "pwd,0,1,2"
        '
        'txtRealName
        '
        Me.txtRealName.Location = New System.Drawing.Point(162, 96)
        Me.txtRealName.Margin = New System.Windows.Forms.Padding(5)
        Me.txtRealName.Name = "txtRealName"
        Me.txtRealName.Size = New System.Drawing.Size(664, 38)
        Me.txtRealName.StyleController = Me.LayoutControl1
        Me.txtRealName.TabIndex = 5
        Me.txtRealName.Tag = "Realname,0,1,2"
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(423, 216)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(195, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Έξοδος"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(622, 216)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(204, 39)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 7
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'txtUN
        '
        Me.txtUN.EditValue = ""
        Me.txtUN.Location = New System.Drawing.Point(162, 12)
        Me.txtUN.Margin = New System.Windows.Forms.Padding(5)
        Me.txtUN.Name = "txtUN"
        Me.txtUN.Size = New System.Drawing.Size(664, 38)
        Me.txtUN.StyleController = Me.LayoutControl1
        Me.txtUN.TabIndex = 0
        Me.txtUN.Tag = "un,0,1,2"
        '
        'cboMail
        '
        Me.cboMail.Location = New System.Drawing.Point(162, 138)
        Me.cboMail.Margin = New System.Windows.Forms.Padding(5)
        Me.cboMail.Name = "cboMail"
        Me.cboMail.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboMail.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboMail.Properties.NullText = ""
        Me.cboMail.Properties.PopupSizeable = False
        Me.cboMail.Size = New System.Drawing.Size(664, 38)
        Me.cboMail.StyleController = Me.LayoutControl1
        Me.cboMail.TabIndex = 8
        Me.cboMail.Tag = "mailid,0,1,2"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.LayoutControlItem7})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(838, 280)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AppearanceItemCaption.Options.UseImage = True
        Me.LayoutControlItem1.Control = Me.txtUN
        Me.LayoutControlItem1.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem1.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(818, 42)
        Me.LayoutControlItem1.Tag = "1"
        Me.LayoutControlItem1.Text = "User Name"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(138, 23)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtPWD
        Me.LayoutControlItem2.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem2.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(818, 42)
        Me.LayoutControlItem2.Tag = "1"
        Me.LayoutControlItem2.Text = "Password"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(138, 23)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtRealName
        Me.LayoutControlItem3.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(818, 42)
        Me.LayoutControlItem3.Text = "Ονοματεπώνυμο"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(138, 23)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdExit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(411, 204)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(199, 56)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cmdSave
        Me.LayoutControlItem5.Location = New System.Drawing.Point(610, 204)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(208, 56)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cboMail
        Me.LayoutControlItem6.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 126)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(818, 42)
        Me.LayoutControlItem6.Text = "Email"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(138, 23)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 204)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(411, 56)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'chkisCollector
        '
        Me.chkisCollector.EditValue = CType(0, Byte)
        Me.chkisCollector.Location = New System.Drawing.Point(12, 180)
        Me.chkisCollector.Margin = New System.Windows.Forms.Padding(5)
        Me.chkisCollector.Name = "chkisCollector"
        Me.chkisCollector.Properties.Caption = "Δυνατότητα είσπραξης"
        Me.chkisCollector.Properties.ValueChecked = CType(1, Byte)
        Me.chkisCollector.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkisCollector.Size = New System.Drawing.Size(814, 32)
        Me.chkisCollector.StyleController = Me.LayoutControl1
        Me.chkisCollector.TabIndex = 25
        Me.chkisCollector.Tag = "isCollector,0,1,2"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.chkisCollector
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(818, 36)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(831, 272)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmUsers"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRealName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkisCollector.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtPWD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRealName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtUN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboMail As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents chkisCollector As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
End Class
