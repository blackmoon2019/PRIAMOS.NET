<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbUsers = New DevExpress.XtraBars.BarButtonItem()
        Me.bbMailSettings = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRights = New DevExpress.XtraBars.BarButtonItem()
        Me.SkinDropDownButtonItem1 = New DevExpress.XtraBars.SkinDropDownButtonItem()
        Me.BarMdiChildrenListItem1 = New DevExpress.XtraBars.BarMdiChildrenListItem()
        Me.bbDate = New DevExpress.XtraBars.BarStaticItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemCalcEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.BarEditItem2 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.bbUser = New DevExpress.XtraBars.BarStaticItem()
        Me.bbServer = New DevExpress.XtraBars.BarStaticItem()
        Me.bbDB = New DevExpress.XtraBars.BarStaticItem()
        Me.bbLink = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RepositoryItemHypertextLabel1 = New DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel()
        Me.RepositoryItemHypertextLabel2 = New DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel()
        Me.RepositoryItemHyperLinkEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.MainstatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHypertextLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHypertextLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.bbUsers, Me.bbMailSettings, Me.BarButtonItem1, Me.BarClose, Me.bbRights, Me.SkinDropDownButtonItem1, Me.BarMdiChildrenListItem1, Me.bbDate, Me.BarEditItem1, Me.BarEditItem2, Me.bbUser, Me.bbServer, Me.bbDB, Me.bbLink})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 21
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1, Me.RibbonPage2})
        Me.RibbonControl1.QuickToolbarItemLinks.Add(Me.BarClose)
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCalcEdit1, Me.RepositoryItemDateEdit1, Me.RepositoryItemHyperLinkEdit1, Me.RepositoryItemHypertextLabel1, Me.RepositoryItemHypertextLabel2, Me.RepositoryItemHyperLinkEdit2})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019
        Me.RibbonControl1.Size = New System.Drawing.Size(1177, 146)
        Me.RibbonControl1.StatusBar = Me.MainstatusBar
        '
        'bbUsers
        '
        Me.bbUsers.Caption = "Χρήστες"
        Me.bbUsers.Id = 1
        Me.bbUsers.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_user_account_40
        Me.bbUsers.Name = "bbUsers"
        Me.bbUsers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'bbMailSettings
        '
        Me.bbMailSettings.Caption = "Ρυθμίσεις Email"
        Me.bbMailSettings.Id = 2
        Me.bbMailSettings.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_mail_configuration_40
        Me.bbMailSettings.Name = "bbMailSettings"
        Me.bbMailSettings.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 3
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarClose
        '
        Me.BarClose.Caption = "Έξοδος"
        Me.BarClose.Id = 5
        Me.BarClose.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.BarClose.Name = "BarClose"
        Me.BarClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'bbRights
        '
        Me.bbRights.Caption = "Δικαιώματα"
        Me.bbRights.Id = 8
        Me.bbRights.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_user_arrow_right_icon
        Me.bbRights.Name = "bbRights"
        Me.bbRights.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'SkinDropDownButtonItem1
        '
        Me.SkinDropDownButtonItem1.Id = 9
        Me.SkinDropDownButtonItem1.Name = "SkinDropDownButtonItem1"
        '
        'BarMdiChildrenListItem1
        '
        Me.BarMdiChildrenListItem1.Caption = "Παράθυρα"
        Me.BarMdiChildrenListItem1.Id = 10
        Me.BarMdiChildrenListItem1.Name = "BarMdiChildrenListItem1"
        '
        'bbDate
        '
        Me.bbDate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bbDate.Caption = "Ημερομηνία"
        Me.bbDate.Id = 11
        Me.bbDate.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bbDate.ItemAppearance.Normal.Options.UseFont = True
        Me.bbDate.Name = "bbDate"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "Αριθμομηχανή"
        Me.BarEditItem1.Edit = Me.RepositoryItemCalcEdit1
        Me.BarEditItem1.EditWidth = 75
        Me.BarEditItem1.Id = 12
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'RepositoryItemCalcEdit1
        '
        Me.RepositoryItemCalcEdit1.AutoHeight = False
        Me.RepositoryItemCalcEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit1.Name = "RepositoryItemCalcEdit1"
        '
        'BarEditItem2
        '
        Me.BarEditItem2.Caption = "Ημερολόγιο"
        Me.BarEditItem2.Edit = Me.RepositoryItemDateEdit1
        Me.BarEditItem2.EditWidth = 90
        Me.BarEditItem2.Id = 13
        Me.BarEditItem2.Name = "BarEditItem2"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'bbUser
        '
        Me.bbUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bbUser.Caption = "Χρήστης"
        Me.bbUser.Id = 14
        Me.bbUser.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bbUser.ItemAppearance.Normal.Options.UseFont = True
        Me.bbUser.Name = "bbUser"
        '
        'bbServer
        '
        Me.bbServer.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bbServer.Caption = "SQL SERVER"
        Me.bbServer.Id = 15
        Me.bbServer.ItemAppearance.Normal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bbServer.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.bbServer.ItemAppearance.Normal.Options.UseBackColor = True
        Me.bbServer.ItemAppearance.Normal.Options.UseFont = True
        Me.bbServer.Name = "bbServer"
        '
        'bbDB
        '
        Me.bbDB.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bbDB.Caption = "Database"
        Me.bbDB.Id = 16
        Me.bbDB.ItemAppearance.Normal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bbDB.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bbDB.ItemAppearance.Normal.Options.UseBackColor = True
        Me.bbDB.ItemAppearance.Normal.Options.UseFont = True
        Me.bbDB.Name = "bbDB"
        '
        'bbLink
        '
        Me.bbLink.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.bbLink.Edit = Me.RepositoryItemHyperLinkEdit1
        Me.bbLink.EditValue = "http://www.priamoservice.gr/"
        Me.bbLink.EditWidth = 170
        Me.bbLink.Id = 20
        Me.bbLink.Name = "bbLink"
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.RepositoryItemHyperLinkEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        Me.RepositoryItemHyperLinkEdit1.SingleClick = True
        Me.RepositoryItemHyperLinkEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Κεντρικές Λειτουργίες"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.bbUsers)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2})
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "Βοηθητικές Λειτουργίες"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bbMailSettings)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bbRights)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "RibbonPageGroup2"
        '
        'RepositoryItemHypertextLabel1
        '
        Me.RepositoryItemHypertextLabel1.Name = "RepositoryItemHypertextLabel1"
        '
        'RepositoryItemHypertextLabel2
        '
        Me.RepositoryItemHypertextLabel2.Name = "RepositoryItemHypertextLabel2"
        '
        'RepositoryItemHyperLinkEdit2
        '
        Me.RepositoryItemHyperLinkEdit2.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit2.Name = "RepositoryItemHyperLinkEdit2"
        '
        'MainstatusBar
        '
        Me.MainstatusBar.ItemLinks.Add(Me.SkinDropDownButtonItem1)
        Me.MainstatusBar.ItemLinks.Add(Me.BarMdiChildrenListItem1)
        Me.MainstatusBar.ItemLinks.Add(Me.BarEditItem1)
        Me.MainstatusBar.ItemLinks.Add(Me.BarEditItem2)
        Me.MainstatusBar.ItemLinks.Add(Me.bbUser)
        Me.MainstatusBar.ItemLinks.Add(Me.bbDate)
        Me.MainstatusBar.ItemLinks.Add(Me.bbServer)
        Me.MainstatusBar.ItemLinks.Add(Me.bbDB)
        Me.MainstatusBar.ItemLinks.Add(Me.bbLink)
        Me.MainstatusBar.Location = New System.Drawing.Point(0, 752)
        Me.MainstatusBar.Name = "MainstatusBar"
        Me.MainstatusBar.Ribbon = Me.RibbonControl1
        Me.MainstatusBar.Size = New System.Drawing.Size(1177, 22)
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InTabControlHeader
        Me.XtraTabbedMdiManager1.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabbedMdiManager1.HeaderButtons = CType((DevExpress.XtraTab.TabButtons.Close Or DevExpress.XtraTab.TabButtons.[Default]), DevExpress.XtraTab.TabButtons)
        Me.XtraTabbedMdiManager1.MdiParent = Me
        Me.XtraTabbedMdiManager1.ShowFloatingDropHint = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabbedMdiManager1.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.[True]
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 774)
        Me.Controls.Add(Me.MainstatusBar)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRIAMOS .NET"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHypertextLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHypertextLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents MainstatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents bbUsers As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents bbMailSettings As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbRights As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SkinDropDownButtonItem1 As DevExpress.XtraBars.SkinDropDownButtonItem
    Friend WithEvents BarMdiChildrenListItem1 As DevExpress.XtraBars.BarMdiChildrenListItem
    Friend WithEvents bbDate As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemCalcEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents BarEditItem2 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents bbUser As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bbServer As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents bbDB As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RepositoryItemHypertextLabel2 As DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents RepositoryItemHypertextLabel1 As DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel
    Friend WithEvents bbLink As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemHyperLinkEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
End Class
