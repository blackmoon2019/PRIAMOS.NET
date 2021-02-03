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
        Me.cboDatabases = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtLogin = New DevExpress.XtraEditors.TextEdit()
        Me.txtPWD = New DevExpress.XtraEditors.TextEdit()
        Me.cmdConnect = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtServerName = New DevExpress.XtraEditors.TextEdit()
        Me.cboAuthentication = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Authentication = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.Databases = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboDatabases.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLogin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAuthentication.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Authentication, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Databases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cboDatabases)
        Me.LayoutControl1.Controls.Add(Me.txtLogin)
        Me.LayoutControl1.Controls.Add(Me.txtPWD)
        Me.LayoutControl1.Controls.Add(Me.cmdConnect)
        Me.LayoutControl1.Controls.Add(Me.cmdCancel)
        Me.LayoutControl1.Controls.Add(Me.txtServerName)
        Me.LayoutControl1.Controls.Add(Me.cboAuthentication)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(358, 169)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cboDatabases
        '
        Me.cboDatabases.Location = New System.Drawing.Point(94, 108)
        Me.cboDatabases.Name = "cboDatabases"
        Me.cboDatabases.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cboDatabases.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.cboDatabases.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDatabases.Properties.NullText = ""
        Me.cboDatabases.Size = New System.Drawing.Size(252, 20)
        Me.cboDatabases.StyleController = Me.LayoutControl1
        Me.cboDatabases.TabIndex = 11
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
        Me.cmdConnect.Location = New System.Drawing.Point(208, 132)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(65, 22)
        Me.cmdConnect.StyleController = Me.LayoutControl1
        Me.cmdConnect.TabIndex = 8
        Me.cmdConnect.Text = "Connect"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(277, 132)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(69, 22)
        Me.cmdCancel.StyleController = Me.LayoutControl1
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(94, 12)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(252, 20)
        Me.txtServerName.StyleController = Me.LayoutControl1
        Me.txtServerName.TabIndex = 6
        '
        'cboAuthentication
        '
        Me.cboAuthentication.Location = New System.Drawing.Point(94, 36)
        Me.cboAuthentication.Name = "cboAuthentication"
        Me.cboAuthentication.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAuthentication.Properties.DropDownRows = 3
        Me.cboAuthentication.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboAuthentication.Size = New System.Drawing.Size(252, 20)
        Me.cboAuthentication.StyleController = Me.LayoutControl1
        Me.cboAuthentication.TabIndex = 10
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem1, Me.Authentication, Me.EmptySpaceItem1, Me.Databases})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(358, 169)
        Me.LayoutControlGroup1.TextVisible = False
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
        Me.LayoutControlItem5.Location = New System.Drawing.Point(196, 120)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(69, 29)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdCancel
        Me.LayoutControlItem6.Location = New System.Drawing.Point(265, 120)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(73, 29)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtServerName
        Me.LayoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem1.CustomizationFormText = "Login"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(338, 24)
        Me.LayoutControlItem1.Text = "Server name"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(70, 13)
        '
        'Authentication
        '
        Me.Authentication.Control = Me.cboAuthentication
        Me.Authentication.Location = New System.Drawing.Point(0, 24)
        Me.Authentication.Name = "Authentication"
        Me.Authentication.Size = New System.Drawing.Size(338, 24)
        Me.Authentication.TextSize = New System.Drawing.Size(70, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 120)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(196, 29)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'Databases
        '
        Me.Databases.Control = Me.cboDatabases
        Me.Databases.Location = New System.Drawing.Point(0, 96)
        Me.Databases.Name = "Databases"
        Me.Databases.Size = New System.Drawing.Size(338, 24)
        Me.Databases.TextSize = New System.Drawing.Size(70, 13)
        '
        'frmDBConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 169)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmDBConnection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Διαχείριση Σύνδεσης"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboDatabases.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLogin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAuthentication.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Authentication, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Databases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtLogin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPWD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdConnect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtServerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboAuthentication As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Authentication As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboDatabases As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Databases As DevExpress.XtraLayout.LayoutControlItem
End Class
