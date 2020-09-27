<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMailSettings
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtServer = New DevExpress.XtraEditors.TextEdit()
        Me.txtUN = New DevExpress.XtraEditors.TextEdit()
        Me.txtPWD = New DevExpress.XtraEditors.TextEdit()
        Me.txtPort = New DevExpress.XtraEditors.TextEdit()
        Me.chkSSL = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdCheckMail = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSSL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.txtServer)
        Me.LayoutControl1.Controls.Add(Me.txtUN)
        Me.LayoutControl1.Controls.Add(Me.txtPWD)
        Me.LayoutControl1.Controls.Add(Me.txtPort)
        Me.LayoutControl1.Controls.Add(Me.chkSSL)
        Me.LayoutControl1.Controls.Add(Me.cmdCheckMail)
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 1)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(554, 0, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(520, 104)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(241, 60)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(131, 28)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 8
        Me.cmdExit.Text = "Έξοδος"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(376, 60)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(132, 28)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 9
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(64, 36)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(173, 20)
        Me.txtServer.StyleController = Me.LayoutControl1
        Me.txtServer.TabIndex = 10
        Me.txtServer.Tag = "server,0,1,2"
        '
        'txtUN
        '
        Me.txtUN.Location = New System.Drawing.Point(64, 12)
        Me.txtUN.Name = "txtUN"
        Me.txtUN.Size = New System.Drawing.Size(173, 20)
        Me.txtUN.StyleController = Me.LayoutControl1
        Me.txtUN.TabIndex = 12
        Me.txtUN.Tag = "un,0,1,2"
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(293, 12)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(215, 20)
        Me.txtPWD.StyleController = Me.LayoutControl1
        Me.txtPWD.TabIndex = 13
        Me.txtPWD.Tag = "pwd,0,1,2"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(293, 36)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPort.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPort.Properties.Mask.EditMask = "n0"
        Me.txtPort.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPort.Size = New System.Drawing.Size(79, 20)
        Me.txtPort.StyleController = Me.LayoutControl1
        Me.txtPort.TabIndex = 14
        Me.txtPort.Tag = "port,0,1,2"
        '
        'chkSSL
        '
        Me.chkSSL.EditValue = CType(0, Byte)
        Me.chkSSL.Location = New System.Drawing.Point(376, 36)
        Me.chkSSL.Name = "chkSSL"
        Me.chkSSL.Properties.Caption = "SSL"
        Me.chkSSL.Properties.ValueChecked = CType(1, Byte)
        Me.chkSSL.Properties.ValueUnchecked = CType(0, Byte)
        Me.chkSSL.Size = New System.Drawing.Size(132, 18)
        Me.chkSSL.StyleController = Me.LayoutControl1
        Me.chkSSL.TabIndex = 15
        Me.chkSSL.Tag = "ssl,0,1,2"
        '
        'cmdCheckMail
        '
        Me.cmdCheckMail.Location = New System.Drawing.Point(12, 70)
        Me.cmdCheckMail.Name = "cmdCheckMail"
        Me.cmdCheckMail.Size = New System.Drawing.Size(225, 22)
        Me.cmdCheckMail.StyleController = Me.LayoutControl1
        Me.cmdCheckMail.TabIndex = 16
        Me.cmdCheckMail.Text = "Check Mail Settings"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem7, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem3, Me.LayoutControlItem8, Me.LayoutControlItem2, Me.LayoutControlItem1, Me.LayoutControlItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(520, 104)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 48)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(229, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtPort
        Me.LayoutControlItem7.Location = New System.Drawing.Point(229, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(135, 24)
        Me.LayoutControlItem7.Text = "Port"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(49, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtUN
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(229, 24)
        Me.LayoutControlItem5.Text = "UserName"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(49, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtPWD
        Me.LayoutControlItem6.Location = New System.Drawing.Point(229, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(271, 24)
        Me.LayoutControlItem6.Text = "Password"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(49, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtServer
        Me.LayoutControlItem3.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight
        Me.LayoutControlItem3.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(229, 24)
        Me.LayoutControlItem3.Tag = "1"
        Me.LayoutControlItem3.Text = "Server"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(49, 19)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.chkSSL
        Me.LayoutControlItem8.Location = New System.Drawing.Point(364, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(136, 24)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdSave
        Me.LayoutControlItem2.Location = New System.Drawing.Point(364, 48)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(136, 36)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmdExit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(229, 48)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(135, 36)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdCheckMail
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 58)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(229, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'frmMailSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(518, 104)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmMailSettings"
        Me.Text = "frmMailSettings"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSSL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtUN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPWD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPort As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkSSL As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cmdCheckMail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
End Class
