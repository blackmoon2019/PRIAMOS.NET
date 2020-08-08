<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScroller
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
        Dim SelectQuery5 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
        Dim AllColumns5 As DevExpress.DataAccess.Sql.AllColumns = New DevExpress.DataAccess.Sql.AllColumns()
        Dim Table5 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim SelectQuery6 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
        Dim AllColumns6 As DevExpress.DataAccess.Sql.AllColumns = New DevExpress.DataAccess.Sql.AllColumns()
        Dim Table6 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim CustomSqlQuery3 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScroller))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.BarRecords = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.BarViewsManage = New DevExpress.XtraBars.BarButtonItem()
        Me.PopMenuViews = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.popSaveView = New DevExpress.XtraBars.BarButtonItem()
        Me.popSaveAsView = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryPopSaveAsView = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryPopRenameView = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.popDeleteView = New DevExpress.XtraBars.BarButtonItem()
        Me.popRestoreView = New DevExpress.XtraBars.BarButtonItem()
        Me.BarViews = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemBreadCrumbEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SQLMain = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.SSM = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.PRIAMOS.NET.WaitForm), False, False)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopMenuViews, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPopSaveAsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPopRenameView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemBreadCrumbEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarRecords, Me.BarViews, Me.popDeleteView, Me.popRestoreView, Me.popSaveAsView, Me.popSaveView, Me.BarViewsManage})
        Me.BarManager1.MainMenu = Me.Bar1
        Me.BarManager1.MaxItemId = 21
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemComboBox2, Me.RepositoryItemButtonEdit1, Me.RepositoryItemBreadCrumbEdit1, Me.RepositoryItemButtonEdit2, Me.RepositoryPopRenameView, Me.RepositoryPopSaveAsView})
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "MainMenu"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarRecords, DevExpress.XtraBars.BarItemPaintStyle.Caption), New DevExpress.XtraBars.LinkPersistInfo(Me.BarViewsManage, True), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarViews, DevExpress.XtraBars.BarItemPaintStyle.Caption)})
        Me.Bar1.OptionsBar.MultiLine = True
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "MainMenu"
        '
        'BarRecords
        '
        Me.BarRecords.Caption = "Records"
        Me.BarRecords.Edit = Me.RepositoryItemComboBox1
        Me.BarRecords.EditWidth = 80
        Me.BarRecords.Id = 3
        Me.BarRecords.Name = "BarRecords"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'BarViewsManage
        '
        Me.BarViewsManage.ActAsDropDown = True
        Me.BarViewsManage.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BarViewsManage.Caption = "Διαχείριση Όψεων"
        Me.BarViewsManage.DropDownControl = Me.PopMenuViews
        Me.BarViewsManage.Id = 19
        Me.BarViewsManage.Name = "BarViewsManage"
        '
        'PopMenuViews
        '
        Me.PopMenuViews.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.popSaveView), New DevExpress.XtraBars.LinkPersistInfo(Me.popSaveAsView), New DevExpress.XtraBars.LinkPersistInfo(Me.popDeleteView), New DevExpress.XtraBars.LinkPersistInfo(Me.popRestoreView)})
        Me.PopMenuViews.Manager = Me.BarManager1
        Me.PopMenuViews.Name = "PopMenuViews"
        '
        'popSaveView
        '
        Me.popSaveView.Caption = "Αποθήκευση"
        Me.popSaveView.Id = 18
        Me.popSaveView.Name = "popSaveView"
        '
        'popSaveAsView
        '
        Me.popSaveAsView.Caption = "Αποθήκευση Ως"
        Me.popSaveAsView.Edit = Me.RepositoryPopSaveAsView
        Me.popSaveAsView.EditWidth = 100
        Me.popSaveAsView.Id = 17
        Me.popSaveAsView.Name = "popSaveAsView"
        '
        'RepositoryPopSaveAsView
        '
        Me.RepositoryPopSaveAsView.AutoHeight = False
        Me.RepositoryPopSaveAsView.Name = "RepositoryPopSaveAsView"
        '
        'RepositoryPopRenameView
        '
        Me.RepositoryPopRenameView.AutoHeight = False
        Me.RepositoryPopRenameView.Name = "RepositoryPopRenameView"
        '
        'popDeleteView
        '
        Me.popDeleteView.Caption = "Διαγραφή"
        Me.popDeleteView.Id = 13
        Me.popDeleteView.Name = "popDeleteView"
        '
        'popRestoreView
        '
        Me.popRestoreView.Caption = "Επαναφορά στην Αρχική"
        Me.popRestoreView.Id = 14
        Me.popRestoreView.Name = "popRestoreView"
        '
        'BarViews
        '
        Me.BarViews.AutoFillWidth = True
        Me.BarViews.Caption = "Όψεις"
        Me.BarViews.Edit = Me.RepositoryItemComboBox2
        Me.BarViews.EditWidth = 150
        Me.BarViews.Id = 5
        Me.BarViews.Name = "BarViews"
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        Me.RepositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'Bar3
        '
        Me.Bar3.BarName = "StatusBar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "StatusBar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1035, 23)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 638)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1035, 19)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 23)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 615)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1035, 23)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 615)
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'RepositoryItemBreadCrumbEdit1
        '
        Me.RepositoryItemBreadCrumbEdit1.AutoHeight = False
        Me.RepositoryItemBreadCrumbEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemBreadCrumbEdit1.Name = "RepositoryItemBreadCrumbEdit1"
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'grdMain
        '
        Me.grdMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMain.Location = New System.Drawing.Point(0, 23)
        Me.grdMain.MainView = Me.GridView1
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(1035, 615)
        Me.grdMain.TabIndex = 5
        Me.grdMain.UseEmbeddedNavigator = True
        Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdMain
        Me.GridView1.Name = "GridView1"
        '
        'SQLMain
        '
        Me.SQLMain.ConnectionName = "myConnectionString"
        Me.SQLMain.Name = "SQLMain"
        Table5.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""183"" />"
        Table5.Name = "USR"
        AllColumns5.Table = Table5
        SelectQuery5.Columns.Add(AllColumns5)
        SelectQuery5.Name = "USR"
        SelectQuery5.Tables.Add(Table5)
        Table6.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""303"" />"
        Table6.Name = "IAT"
        AllColumns6.Table = Table6
        SelectQuery6.Columns.Add(AllColumns6)
        SelectQuery6.Name = "IAT"
        SelectQuery6.Tables.Add(Table6)
        CustomSqlQuery3.Name = "INH"
        CustomSqlQuery3.Sql = "select top 1000 ""INH"".*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  from ""dbo"".""INH"" ""INH"""
        Me.SQLMain.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery5, SelectQuery6, CustomSqlQuery3})
        Me.SQLMain.ResultSchemaSerializable = resources.GetString("SQLMain.ResultSchemaSerializable")
        '
        'SSM
        '
        Me.SSM.ClosingDelay = 500
        '
        'frmScroller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 657)
        Me.Controls.Add(Me.grdMain)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "frmScroller"
        Me.Text = "frmScroller"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopMenuViews, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPopSaveAsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPopRenameView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemBreadCrumbEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SQLMain As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents SSM As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents BarRecords As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents BarViews As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemBreadCrumbEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemBreadCrumbEdit
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents PopMenuViews As DevExpress.XtraBars.PopupMenu
    Friend WithEvents popDeleteView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents popRestoreView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryPopRenameView As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents popSaveAsView As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryPopSaveAsView As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents popSaveView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarViewsManage As DevExpress.XtraBars.BarButtonItem
End Class
