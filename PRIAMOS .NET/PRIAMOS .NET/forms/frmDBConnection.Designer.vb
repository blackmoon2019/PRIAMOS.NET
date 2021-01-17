<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBConnection
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
        Me.txtLogin = New DevExpress.XtraEditors.TextEdit()
        Me.txtPWD = New DevExpress.XtraEditors.TextEdit()
        Me.cmdConnect = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cboSQLServer = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboAuthentication = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtLogin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSQLServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAuthentication.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtLogin)
        Me.LayoutControl1.Controls.Add(Me.txtPWD)
        Me.LayoutControl1.Controls.Add(Me.cmdConnect)
        Me.LayoutControl1.Controls.Add(Me.cmdCancel)
        Me.LayoutControl1.Controls.Add(Me.cboSQLServer)
        Me.LayoutControl1.Controls.Add(Me.cboAuthentication)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(358, 268)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(94, 60)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(252, 20)
        Me.txtLogin.StyleController = Me.LayoutControl1
        Me.txtLogin.TabIndex = 6
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(94, 84)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Size = New System.Drawing.Size(252, 20)
        Me.txtPWD.StyleController = Me.LayoutControl1
        Me.txtPWD.TabIndex = 7
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(12, 108)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(165, 22)
        Me.cmdConnect.StyleController = Me.LayoutControl1
        Me.cmdConnect.TabIndex = 8
        Me.cmdConnect.Text = "Connect"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(181, 108)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(165, 22)
        Me.cmdCancel.StyleController = Me.LayoutControl1
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        '
        'cboSQLServer
        '
        Me.cboSQLServer.Location = New System.Drawing.Point(94, 12)
        Me.cboSQLServer.Name = "cboSQLServer"
        Me.cboSQLServer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSQLServer.Properties.NullText = ""
        Me.cboSQLServer.Properties.PopupSizeable = False
        Me.cboSQLServer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboSQLServer.Size = New System.Drawing.Size(252, 20)
        Me.cboSQLServer.StyleController = Me.LayoutControl1
        Me.cboSQLServer.TabIndex = 4
        '
        'cboAuthentication
        '
        Me.cboAuthentication.Location = New System.Drawing.Point(94, 36)
        Me.cboAuthentication.Name = "cboAuthentication"
        Me.cboAuthentication.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAuthentication.Properties.NullText = ""
        Me.cboAuthentication.Properties.PopupSizeable = False
        Me.cboAuthentication.Size = New System.Drawing.Size(252, 20)
        Me.cboAuthentication.StyleController = Me.LayoutControl1
        Me.cboAuthentication.TabIndex = 5
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(358, 268)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboSQLServer
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(338, 24)
        Me.LayoutControlItem1.Text = "Server Name"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboAuthentication
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(338, 24)
        Me.LayoutControlItem2.Text = "Authentication"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtLogin
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(338, 24)
        Me.LayoutControlItem3.Text = "Login"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtPWD
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(338, 24)
        Me.LayoutControlItem4.Text = "Password"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cmdConnect
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(169, 152)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdCancel
        Me.LayoutControlItem6.Location = New System.Drawing.Point(169, 96)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(169, 152)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'frmDBConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 268)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmDBConnection"
        Me.Text = "frmDBConnection"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtLogin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSQLServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAuthentication.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtLogin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPWD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdConnect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboSQLServer As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboAuthentication As DevExpress.XtraEditors.LookUpEdit
End Class
