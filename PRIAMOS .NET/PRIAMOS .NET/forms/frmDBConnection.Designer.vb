﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtLogin = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboDatabases = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPWD = New DevExpress.XtraEditors.TextEdit()
        Me.cmdConnect = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtServerName = New DevExpress.XtraEditors.TextEdit()
        Me.cboAuthentication = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboSavedServers = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Authentication = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.Databases = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLogin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboDatabases.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAuthentication.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSavedServers.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Authentication, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Databases, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem1, Me.Authentication, Me.EmptySpaceItem1, Me.Databases, Me.LayoutControlItem2, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(598, 365)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtLogin
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 138)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(564, 46)
        Me.LayoutControlItem3.Tag = ""
        Me.LayoutControlItem3.Text = "Login"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(131, 23)
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(171, 160)
        Me.txtLogin.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(407, 38)
        Me.txtLogin.StyleController = Me.LayoutControl1
        Me.txtLogin.TabIndex = 6
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
        Me.LayoutControl1.Controls.Add(Me.cboSavedServers)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(407, 0, 650, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(598, 365)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cboDatabases
        '
        Me.cboDatabases.Location = New System.Drawing.Point(171, 252)
        Me.cboDatabases.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.cboDatabases.Name = "cboDatabases"
        Me.cboDatabases.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cboDatabases.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.cboDatabases.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)})
        Me.cboDatabases.Properties.NullText = ""
        Me.cboDatabases.Size = New System.Drawing.Size(407, 38)
        Me.cboDatabases.StyleController = Me.LayoutControl1
        Me.cboDatabases.TabIndex = 11
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(171, 206)
        Me.txtPWD.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(407, 38)
        Me.txtPWD.StyleController = Me.LayoutControl1
        Me.txtPWD.TabIndex = 7
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(347, 298)
        Me.cmdConnect.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(109, 39)
        Me.cmdConnect.StyleController = Me.LayoutControl1
        Me.cmdConnect.TabIndex = 8
        Me.cmdConnect.Text = "Connect"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(462, 298)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(116, 39)
        Me.cmdCancel.StyleController = Me.LayoutControl1
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Έξοδος"
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(171, 68)
        Me.txtServerName.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(407, 38)
        Me.txtServerName.StyleController = Me.LayoutControl1
        Me.txtServerName.TabIndex = 6
        '
        'cboAuthentication
        '
        Me.cboAuthentication.Location = New System.Drawing.Point(171, 114)
        Me.cboAuthentication.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.cboAuthentication.Name = "cboAuthentication"
        Me.cboAuthentication.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAuthentication.Properties.DropDownRows = 3
        Me.cboAuthentication.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboAuthentication.Size = New System.Drawing.Size(407, 38)
        Me.cboAuthentication.StyleController = Me.LayoutControl1
        Me.cboAuthentication.TabIndex = 10
        '
        'cboSavedServers
        '
        Me.cboSavedServers.Location = New System.Drawing.Point(171, 22)
        Me.cboSavedServers.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.cboSavedServers.Name = "cboSavedServers"
        Me.cboSavedServers.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)})
        Me.cboSavedServers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboSavedServers.Size = New System.Drawing.Size(407, 38)
        Me.cboSavedServers.StyleController = Me.LayoutControl1
        Me.cboSavedServers.TabIndex = 12
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cmdConnect
        Me.LayoutControlItem5.Location = New System.Drawing.Point(327, 276)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(115, 53)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdCancel
        Me.LayoutControlItem6.Location = New System.Drawing.Point(442, 276)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(122, 53)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtServerName
        Me.LayoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem1.CustomizationFormText = "Login"
        Me.LayoutControlItem1.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 46)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(564, 46)
        Me.LayoutControlItem1.Tag = "1"
        Me.LayoutControlItem1.Text = "Server name"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(131, 23)
        '
        'Authentication
        '
        Me.Authentication.Control = Me.cboAuthentication
        Me.Authentication.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.Authentication.Location = New System.Drawing.Point(0, 92)
        Me.Authentication.Name = "Authentication"
        Me.Authentication.Size = New System.Drawing.Size(564, 46)
        Me.Authentication.Tag = "1"
        Me.Authentication.TextSize = New System.Drawing.Size(131, 23)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 276)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(327, 53)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'Databases
        '
        Me.Databases.Control = Me.cboDatabases
        Me.Databases.Location = New System.Drawing.Point(0, 230)
        Me.Databases.Name = "Databases"
        Me.Databases.Size = New System.Drawing.Size(564, 46)
        Me.Databases.TextSize = New System.Drawing.Size(131, 23)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboSavedServers
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(564, 46)
        Me.LayoutControlItem2.Text = "Servers"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(131, 23)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtPWD
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 184)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(564, 46)
        Me.LayoutControlItem4.Tag = ""
        Me.LayoutControlItem4.Text = "Password"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(131, 23)
        '
        'frmDBConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(598, 365)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "frmDBConnection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Διαχείριση Σύνδεσης"
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLogin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboDatabases.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAuthentication.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSavedServers.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Authentication, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Databases, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtLogin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents cboDatabases As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtPWD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdConnect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtServerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboAuthentication As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboSavedServers As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Authentication As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents Databases As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
