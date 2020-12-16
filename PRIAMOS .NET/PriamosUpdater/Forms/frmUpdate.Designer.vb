Partial Public Class frmUpdate
    Inherits DevExpress.XtraEditors.XtraForm

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.ProgressBarControl2 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.cmdUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTotal = New DevExpress.XtraEditors.LabelControl()
        Me.peImage = New DevExpress.XtraEditors.PictureEdit()
        Me.lblFileCounter = New DevExpress.XtraEditors.LabelControl()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.peImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(15, 563)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Size = New System.Drawing.Size(1240, 36)
        Me.ProgressBarControl1.TabIndex = 0
        '
        'ProgressBarControl2
        '
        Me.ProgressBarControl2.Location = New System.Drawing.Point(15, 653)
        Me.ProgressBarControl2.Name = "ProgressBarControl2"
        Me.ProgressBarControl2.Properties.ShowTitle = True
        Me.ProgressBarControl2.Size = New System.Drawing.Size(1240, 36)
        Me.ProgressBarControl2.TabIndex = 1
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(1102, 717)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(150, 46)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.Text = "Ενημέρωση"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(941, 717)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(150, 46)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "Έξοδος"
        '
        'lblTotal
        '
        Me.lblTotal.Location = New System.Drawing.Point(27, 619)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 25)
        Me.lblTotal.TabIndex = 4
        '
        'peImage
        '
        Me.peImage.Cursor = System.Windows.Forms.Cursors.Default
        Me.peImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.peImage.EditValue = Global.PriamosUpdater.My.Resources.Resources.logo
        Me.peImage.Location = New System.Drawing.Point(0, 0)
        Me.peImage.Margin = New System.Windows.Forms.Padding(6)
        Me.peImage.Name = "peImage"
        Me.peImage.Properties.AllowFocused = False
        Me.peImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.peImage.Properties.Appearance.Options.UseBackColor = True
        Me.peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.peImage.Properties.ShowMenu = False
        Me.peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.peImage.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.peImage.Size = New System.Drawing.Size(1264, 509)
        Me.peImage.TabIndex = 15
        '
        'lblFileCounter
        '
        Me.lblFileCounter.Location = New System.Drawing.Point(27, 518)
        Me.lblFileCounter.Name = "lblFileCounter"
        Me.lblFileCounter.Size = New System.Drawing.Size(0, 25)
        Me.lblFileCounter.TabIndex = 16
        '
        'frmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 775)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblFileCounter)
        Me.Controls.Add(Me.peImage)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.ProgressBarControl2)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.Name = "frmUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.peImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents ProgressBarControl2 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents cmdUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTotal As DevExpress.XtraEditors.LabelControl
    Private WithEvents peImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblFileCounter As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

#End Region

End Class
