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
        Me.txtUN = New DevExpress.XtraEditors.TextEdit()
        CType(Me.chkRememberUN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 22)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Όνομα Χρήστη"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(14, 80)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Κωδικός"
        '
        'cmdLogin
        '
        Me.cmdLogin.Location = New System.Drawing.Point(14, 172)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(209, 23)
        Me.cmdLogin.TabIndex = 4
        Me.cmdLogin.Text = "Είσοδος"
        '
        'cmdConnect
        '
        Me.cmdConnect.BackgroundImage = Global.PRIAMOS.NET.My.Resources.Resources.icons8_database_administrator_40
        Me.cmdConnect.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_database_administrator_24
        Me.cmdConnect.Location = New System.Drawing.Point(231, 183)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(30, 27)
        Me.cmdConnect.TabIndex = 6
        Me.cmdConnect.Visible = False
        '
        'chkRememberUN
        '
        Me.chkRememberUN.Location = New System.Drawing.Point(14, 136)
        Me.chkRememberUN.Name = "chkRememberUN"
        Me.chkRememberUN.Properties.Caption = "Απομνημόνευση ""Όνομα Χρήστη"""
        Me.chkRememberUN.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.chkRememberUN.Size = New System.Drawing.Size(214, 18)
        Me.chkRememberUN.TabIndex = 5
        '
        'txtPWD
        '
        Me.txtPWD.Location = New System.Drawing.Point(13, 100)
        Me.txtPWD.Name = "txtPWD"
        Me.txtPWD.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtPWD.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.txtPWD.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPWD.Size = New System.Drawing.Size(226, 20)
        Me.txtPWD.TabIndex = 2
        '
        'txtUN
        '
        Me.txtUN.Location = New System.Drawing.Point(12, 42)
        Me.txtUN.Name = "txtUN"
        Me.txtUN.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtUN.Properties.AppearanceFocused.Options.UseBackColor = True
        Me.txtUN.Size = New System.Drawing.Size(227, 20)
        Me.txtUN.TabIndex = 0
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 211)
        Me.Controls.Add(Me.cmdConnect)
        Me.Controls.Add(Me.chkRememberUN)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtPWD)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtUN)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRIAMOS .NET"
        CType(Me.chkRememberUN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPWD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPWD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkRememberUN As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdConnect As DevExpress.XtraEditors.SimpleButton
End Class
