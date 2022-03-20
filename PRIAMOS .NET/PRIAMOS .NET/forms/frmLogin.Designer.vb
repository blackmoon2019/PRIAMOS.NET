<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdConnect = New DevExpress.XtraEditors.SimpleButton()
        Me.chkRememberUN = New DevExpress.XtraEditors.CheckEdit()
        Me.txtPWD = New DevExpress.XtraEditors.TextEdit()
        Me.txtUN = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.chkRememberUN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 39)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(125, 23)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Όνομα Χρήστη"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(23, 142)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(67, 23)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Κωδικός"
        '
        'cmdLogin
        '
        Me.cmdLogin.Location = New System.Drawing.Point(23, 304)
        Me.cmdLogin.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(348, 41)
        Me.cmdLogin.TabIndex = 4
        Me.cmdLogin.Text = "Είσοδος"
        '
        'cmdConnect
        '
        Me.cmdConnect.BackgroundImage = Global.PRIAMOS.NET.My.Resources.Resources.icons8_database_administrator_40
        Me.cmdConnect.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_database_administrator_24
        Me.cmdConnect.Location = New System.Drawing.Point(382, 304)
        Me.cmdConnect.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(50, 48)
        Me.cmdConnect.TabIndex = 6
        '
        'chkRememberUN
        '
        Me.chkRememberUN.Location = New System.Drawing.Point(23, 241)
        Me.chkRememberUN.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.chkRememberUN.Name = "chkRememberUN"
        Me.chkRememberUN.Properties.Caption = "Απομνημόνευση ""Όνομα Χρήστη"""
        Me.chkRememberUN.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.chkRememberUN.Size = New System.Drawing.Size(357, 32)
        Me.chkRememberUN.TabIndex = 5
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(22, 177)
        Me.txtPWD.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtPWD.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.txtPWD.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(395, 38)
        Me.txtPWD.TabIndex = 2
        '
        'txtUN
        '
        Me.txtUN.Location = New System.Drawing.Point(20, 73)
        Me.txtUN.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtUN.Name = "txtUN"
        Me.txtUN.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtUN.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.txtUN.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtUN.Properties.NullText = ""
        Me.txtUN.Size = New System.Drawing.Size(397, 38)
        Me.txtUN.TabIndex = 7
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(437, 363)
        Me.Controls.Add(Me.txtUN)
        Me.Controls.Add(Me.cmdConnect)
        Me.Controls.Add(Me.chkRememberUN)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtPWD)
        Me.Controls.Add(Me.LabelControl1)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRIAMOS .NET"
        CType(Me.chkRememberUN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPWD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkRememberUN As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdConnect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtUN As DevExpress.XtraEditors.LookUpEdit
End Class
