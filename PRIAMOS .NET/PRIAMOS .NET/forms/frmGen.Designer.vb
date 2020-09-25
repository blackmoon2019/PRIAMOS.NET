<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGen
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
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdNew = New DevExpress.XtraEditors.SimpleButton()
        Me.cbo2 = New DevExpress.XtraEditors.LookUpEdit()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtID = New DevExpress.XtraEditors.TextEdit()
        Me.cbo1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.L2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.L3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.L1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.L4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cbo2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.L4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(179, 255)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(105, 28)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 12
        Me.cmdExit.Text = "Έξοδος"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdNew)
        Me.LayoutControl1.Controls.Add(Me.cbo2)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtID)
        Me.LayoutControl1.Controls.Add(Me.cbo1)
        Me.LayoutControl1.Location = New System.Drawing.Point(-8, -10)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(342, 0, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(400, 295)
        Me.LayoutControl1.TabIndex = 14
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdNew
        '
        Me.cmdNew.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdNew.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.AddFile_16x16
        Me.cmdNew.Location = New System.Drawing.Point(12, 258)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(96, 22)
        Me.cmdNew.StyleController = Me.LayoutControl1
        Me.cmdNew.TabIndex = 17
        Me.cmdNew.Text = "Νέα Εγγραφή"
        '
        'cbo2
        '
        Me.cbo2.Location = New System.Drawing.Point(37, 60)
        Me.cbo2.Name = "cbo2"
        Me.cbo2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo2.Properties.NullText = ""
        Me.cbo2.Properties.PopupSizeable = False
        Me.cbo2.Size = New System.Drawing.Size(351, 20)
        Me.cbo2.StyleController = Me.LayoutControl1
        Me.cbo2.TabIndex = 16
        Me.cbo2.Visible = False
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(288, 255)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(100, 28)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 13
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(131, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(257, 20)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 14
        Me.txtName.Tag = ""
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(37, 12)
        Me.txtID.Name = "txtID"
        Me.txtID.Properties.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(65, 20)
        Me.txtID.StyleController = Me.LayoutControl1
        Me.txtID.TabIndex = 14
        '
        'cbo1
        '
        Me.cbo1.Location = New System.Drawing.Point(37, 36)
        Me.cbo1.Name = "cbo1"
        Me.cbo1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo1.Properties.NullText = ""
        Me.cbo1.Properties.PopupSizeable = False
        Me.cbo1.Size = New System.Drawing.Size(351, 20)
        Me.cbo1.StyleController = Me.LayoutControl1
        Me.cbo1.TabIndex = 15
        Me.cbo1.Tag = ""
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem1, Me.L2, Me.L3, Me.L1, Me.L4, Me.LayoutControlItem3, Me.EmptySpaceItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(400, 295)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(380, 171)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdExit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(167, 243)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(109, 32)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmdSave
        Me.LayoutControlItem1.Location = New System.Drawing.Point(276, 243)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(104, 32)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'L2
        '
        Me.L2.Control = Me.txtName
        Me.L2.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.L2.Location = New System.Drawing.Point(94, 0)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(286, 24)
        Me.L2.Tag = "1"
        Me.L2.TextSize = New System.Drawing.Size(22, 13)
        '
        'L3
        '
        Me.L3.Control = Me.cbo1
        Me.L3.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.L3.Location = New System.Drawing.Point(0, 24)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(380, 24)
        Me.L3.Tag = "1"
        Me.L3.TextSize = New System.Drawing.Size(22, 13)
        '
        'L1
        '
        Me.L1.Control = Me.txtID
        Me.L1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.L1.CustomizationFormText = "LayoutControlItem3"
        Me.L1.Location = New System.Drawing.Point(0, 0)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(94, 24)
        Me.L1.Tag = "1"
        Me.L1.TextSize = New System.Drawing.Size(22, 13)
        '
        'L4
        '
        Me.L4.Control = Me.cbo2
        Me.L4.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.L4.Location = New System.Drawing.Point(0, 48)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(380, 24)
        Me.L4.Tag = "1"
        Me.L4.TextSize = New System.Drawing.Size(22, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdNew
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 243)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(100, 32)
        Me.LayoutControlItem3.Spacing = New DevExpress.XtraLayout.Utils.Padding(0, 0, 3, 0)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(100, 243)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(67, 32)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmGen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 276)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmGen"
        Me.Text = "frmGen"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cbo2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.L4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents L2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents L3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents L1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cbo2 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents L4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cbo1 As DevExpress.XtraEditors.LookUpEdit
End Class
