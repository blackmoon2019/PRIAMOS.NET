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
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.chkMail = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRealName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkMail)
        Me.LayoutControl1.Controls.Add(Me.txtPWD)
        Me.LayoutControl1.Controls.Add(Me.txtRealName)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.txtUN)
        Me.LayoutControl1.Location = New System.Drawing.Point(-9, -10)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(416, 136, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(503, 134)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(95, 36)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(235, 20)
        Me.txtPWD.StyleController = Me.LayoutControl1
        Me.txtPWD.TabIndex = 4
        Me.txtPWD.Tag = ""
        '
        'txtRealName
        '
        Me.txtRealName.Location = New System.Drawing.Point(95, 60)
        Me.txtRealName.Name = "txtRealName"
        Me.txtRealName.Size = New System.Drawing.Size(235, 20)
        Me.txtRealName.StyleController = Me.LayoutControl1
        Me.txtRealName.TabIndex = 5
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(12, 84)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(157, 28)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 6
        Me.cmdExit.Text = "Έξοδος"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(173, 84)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(157, 28)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 7
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'txtUN
        '
        Me.txtUN.EditValue = ""
        Me.txtUN.Location = New System.Drawing.Point(95, 12)
        Me.txtUN.Name = "txtUN"
        Me.txtUN.Size = New System.Drawing.Size(235, 20)
        Me.txtUN.StyleController = Me.LayoutControl1
        Me.txtUN.TabIndex = 0
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(503, 134)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AppearanceItemCaption.Options.UseImage = True
        Me.LayoutControlItem1.Control = Me.txtUN
        Me.LayoutControlItem1.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutControlItem1.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight
        Me.LayoutControlItem1.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exclamation_mark_16
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(322, 24)
        Me.LayoutControlItem1.Tag = "1"
        Me.LayoutControlItem1.Text = "User Name"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(80, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtPWD
        Me.LayoutControlItem2.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleRight
        Me.LayoutControlItem2.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exclamation_mark_16
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(322, 24)
        Me.LayoutControlItem2.Tag = "1"
        Me.LayoutControlItem2.Text = "Password"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(80, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtRealName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(322, 24)
        Me.LayoutControlItem3.Text = "Ονοματεπώνυμο"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(80, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdExit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(161, 42)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cmdSave
        Me.LayoutControlItem5.Location = New System.Drawing.Point(161, 72)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(161, 42)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'chkMail
        '
        Me.chkMail.Location = New System.Drawing.Point(334, 12)
        Me.chkMail.Name = "chkMail"
        Me.chkMail.Size = New System.Drawing.Size(157, 110)
        Me.chkMail.StyleController = Me.LayoutControl1
        Me.chkMail.TabIndex = 2
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.chkMail
        Me.LayoutControlItem6.Location = New System.Drawing.Point(322, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(161, 114)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(487, 118)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmUsers"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRealName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents chkMail As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
End Class
