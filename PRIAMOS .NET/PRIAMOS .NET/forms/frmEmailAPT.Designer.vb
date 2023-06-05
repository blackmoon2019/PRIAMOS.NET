<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmailAPT
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtBody = New DevExpress.XtraEditors.MemoEdit()
        Me.txtSubject = New DevExpress.XtraEditors.TextEdit()
        Me.cmdBatchSend = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.grdAPT = New DevExpress.XtraGrid.GridControl()
        Me.APTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet3 = New PRIAMOS.NET.Priamos_NETDataSet3()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colttl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colsendEmailOwner = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colsendEmailTenant = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colsendEmailRepresentative = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcctOwnerEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcctTenantEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcctRepresentativeEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSend = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepSendEmail = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.coleidop1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colsyg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colreceipt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbal_adm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LSubject = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LBody = New DevExpress.XtraLayout.LayoutControlItem()
        Me.APTTableAdapter = New PRIAMOS.NET.Priamos_NETDataSet3TableAdapters.APTTableAdapter()
        Me.SSM = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.PRIAMOS.NET.WaitForm), True, True)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtBody.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAPT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepSendEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LSubject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtBody)
        Me.LayoutControl1.Controls.Add(Me.txtSubject)
        Me.LayoutControl1.Controls.Add(Me.cmdBatchSend)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.grdAPT)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1230, 528, 1137, 700)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(2282, 978)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtBody
        '
        Me.txtBody.Location = New System.Drawing.Point(98, 54)
        Me.txtBody.Name = "txtBody"
        Me.txtBody.Size = New System.Drawing.Size(2172, 216)
        Me.txtBody.StyleController = Me.LayoutControl1
        Me.txtBody.TabIndex = 6
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(98, 12)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(2172, 38)
        Me.txtSubject.StyleController = Me.LayoutControl1
        Me.txtSubject.TabIndex = 5
        '
        'cmdBatchSend
        '
        Me.cmdBatchSend.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdBatchSend.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_email_send_24
        Me.cmdBatchSend.Location = New System.Drawing.Point(12, 927)
        Me.cmdBatchSend.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdBatchSend.Name = "cmdBatchSend"
        Me.cmdBatchSend.Size = New System.Drawing.Size(246, 39)
        Me.cmdBatchSend.StyleController = Me.LayoutControl1
        Me.cmdBatchSend.TabIndex = 4
        Me.cmdBatchSend.Text = "Μαζική απόστολή"
        '
        'cmdExit
        '
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(2003, 927)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(267, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "Έξοδος"
        '
        'grdAPT
        '
        Me.grdAPT.DataSource = Me.APTBindingSource
        Me.grdAPT.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.grdAPT.Location = New System.Drawing.Point(12, 274)
        Me.grdAPT.MainView = Me.GridView1
        Me.grdAPT.Margin = New System.Windows.Forms.Padding(5)
        Me.grdAPT.Name = "grdAPT"
        Me.grdAPT.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepSendEmail})
        Me.grdAPT.Size = New System.Drawing.Size(2258, 649)
        Me.grdAPT.TabIndex = 0
        Me.grdAPT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'APTBindingSource
        '
        Me.APTBindingSource.DataMember = "APT"
        Me.APTBindingSource.DataSource = Me.Priamos_NETDataSet3
        '
        'Priamos_NETDataSet3
        '
        Me.Priamos_NETDataSet3.DataSetName = "Priamos_NETDataSet3"
        Me.Priamos_NETDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colid, Me.colttl, Me.colnam, Me.colsendEmailOwner, Me.colsendEmailTenant, Me.colsendEmailRepresentative, Me.colcctOwnerEmail, Me.colcctTenantEmail, Me.colcctRepresentativeEmail, Me.colSend, Me.coleidop1, Me.colsyg, Me.colreceipt, Me.colbal_adm})
        Me.GridView1.DetailHeight = 619
        Me.GridView1.GridControl = Me.grdAPT
        Me.GridView1.LevelIndent = 0
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsLayout.StoreAllOptions = True
        Me.GridView1.OptionsLayout.StoreAppearance = True
        Me.GridView1.OptionsLayout.StoreFormatRules = True
        Me.GridView1.OptionsPrint.PrintPreview = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.PreviewIndent = 0
        '
        'colid
        '
        Me.colid.FieldName = "id"
        Me.colid.MinWidth = 35
        Me.colid.Name = "colid"
        Me.colid.OptionsColumn.AllowEdit = False
        Me.colid.Width = 131
        '
        'colttl
        '
        Me.colttl.Caption = "Διαμέρισμα"
        Me.colttl.FieldName = "ttl"
        Me.colttl.MinWidth = 35
        Me.colttl.Name = "colttl"
        Me.colttl.OptionsColumn.AllowEdit = False
        Me.colttl.Visible = True
        Me.colttl.VisibleIndex = 0
        Me.colttl.Width = 131
        '
        'colnam
        '
        Me.colnam.Caption = "Λεκτικό Εκτύπ."
        Me.colnam.FieldName = "nam"
        Me.colnam.MinWidth = 35
        Me.colnam.Name = "colnam"
        Me.colnam.OptionsColumn.AllowEdit = False
        Me.colnam.Visible = True
        Me.colnam.VisibleIndex = 1
        Me.colnam.Width = 183
        '
        'colsendEmailOwner
        '
        Me.colsendEmailOwner.Caption = "Αποστολή στον Ιδιοκτήτη"
        Me.colsendEmailOwner.FieldName = "sendEmailOwner"
        Me.colsendEmailOwner.MinWidth = 35
        Me.colsendEmailOwner.Name = "colsendEmailOwner"
        Me.colsendEmailOwner.Visible = True
        Me.colsendEmailOwner.VisibleIndex = 5
        Me.colsendEmailOwner.Width = 242
        '
        'colsendEmailTenant
        '
        Me.colsendEmailTenant.Caption = "Αποστολή στον Ένοικο"
        Me.colsendEmailTenant.FieldName = "sendEmailTenant"
        Me.colsendEmailTenant.MinWidth = 35
        Me.colsendEmailTenant.Name = "colsendEmailTenant"
        Me.colsendEmailTenant.Visible = True
        Me.colsendEmailTenant.VisibleIndex = 6
        Me.colsendEmailTenant.Width = 238
        '
        'colsendEmailRepresentative
        '
        Me.colsendEmailRepresentative.Caption = "Αποστολή στον Εκπρόσωπο"
        Me.colsendEmailRepresentative.FieldName = "sendEmailRepresentative"
        Me.colsendEmailRepresentative.MinWidth = 35
        Me.colsendEmailRepresentative.Name = "colsendEmailRepresentative"
        Me.colsendEmailRepresentative.Visible = True
        Me.colsendEmailRepresentative.VisibleIndex = 7
        Me.colsendEmailRepresentative.Width = 287
        '
        'colcctOwnerEmail
        '
        Me.colcctOwnerEmail.Caption = "Email Ιδιοκτήτη"
        Me.colcctOwnerEmail.FieldName = "cctOwnerEmail"
        Me.colcctOwnerEmail.MinWidth = 35
        Me.colcctOwnerEmail.Name = "colcctOwnerEmail"
        Me.colcctOwnerEmail.OptionsColumn.AllowEdit = False
        Me.colcctOwnerEmail.Visible = True
        Me.colcctOwnerEmail.VisibleIndex = 2
        Me.colcctOwnerEmail.Width = 156
        '
        'colcctTenantEmail
        '
        Me.colcctTenantEmail.Caption = "Email Ενοίκου"
        Me.colcctTenantEmail.FieldName = "cctTenantEmail"
        Me.colcctTenantEmail.MinWidth = 35
        Me.colcctTenantEmail.Name = "colcctTenantEmail"
        Me.colcctTenantEmail.OptionsColumn.AllowEdit = False
        Me.colcctTenantEmail.Visible = True
        Me.colcctTenantEmail.VisibleIndex = 3
        Me.colcctTenantEmail.Width = 131
        '
        'colcctRepresentativeEmail
        '
        Me.colcctRepresentativeEmail.Caption = "Email Εκπροσώπου"
        Me.colcctRepresentativeEmail.FieldName = "cctRepresentativeEmail"
        Me.colcctRepresentativeEmail.MinWidth = 35
        Me.colcctRepresentativeEmail.Name = "colcctRepresentativeEmail"
        Me.colcctRepresentativeEmail.OptionsColumn.AllowEdit = False
        Me.colcctRepresentativeEmail.Visible = True
        Me.colcctRepresentativeEmail.VisibleIndex = 4
        Me.colcctRepresentativeEmail.Width = 175
        '
        'colSend
        '
        Me.colSend.Caption = "Αποστολή Email"
        Me.colSend.ColumnEdit = Me.RepSendEmail
        Me.colSend.MinWidth = 35
        Me.colSend.Name = "colSend"
        Me.colSend.Visible = True
        Me.colSend.VisibleIndex = 11
        Me.colSend.Width = 157
        '
        'RepSendEmail
        '
        Me.RepSendEmail.AutoHeight = False
        EditorButtonImageOptions1.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_sent_24
        Me.RepSendEmail.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Αποστολή", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepSendEmail.Name = "RepSendEmail"
        Me.RepSendEmail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'coleidop1
        '
        Me.coleidop1.Caption = "Ειδοποίηση"
        Me.coleidop1.FieldName = "eidop"
        Me.coleidop1.MinWidth = 35
        Me.coleidop1.Name = "coleidop1"
        Me.coleidop1.Visible = True
        Me.coleidop1.VisibleIndex = 8
        Me.coleidop1.Width = 131
        '
        'colsyg
        '
        Me.colsyg.Caption = "Συγκεντρωτική"
        Me.colsyg.FieldName = "syg"
        Me.colsyg.MinWidth = 35
        Me.colsyg.Name = "colsyg"
        Me.colsyg.Visible = True
        Me.colsyg.VisibleIndex = 9
        Me.colsyg.Width = 152
        '
        'colreceipt
        '
        Me.colreceipt.Caption = "Απόδειξη"
        Me.colreceipt.FieldName = "receipt"
        Me.colreceipt.MinWidth = 35
        Me.colreceipt.Name = "colreceipt"
        Me.colreceipt.Visible = True
        Me.colreceipt.VisibleIndex = 10
        Me.colreceipt.Width = 131
        '
        'colbal_adm
        '
        Me.colbal_adm.FieldName = "bal_adm"
        Me.colbal_adm.MinWidth = 35
        Me.colbal_adm.Name = "colbal_adm"
        Me.colbal_adm.Width = 131
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlItem3, Me.LSubject, Me.LBody})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(2282, 978)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.grdAPT
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 262)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(2262, 653)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdExit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1991, 915)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(271, 43)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(250, 915)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1741, 43)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdBatchSend
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 915)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(250, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LSubject
        '
        Me.LSubject.Control = Me.txtSubject
        Me.LSubject.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LSubject.Location = New System.Drawing.Point(0, 0)
        Me.LSubject.Name = "LSubject"
        Me.LSubject.Size = New System.Drawing.Size(2262, 42)
        Me.LSubject.Tag = "1"
        Me.LSubject.Text = "Θέμα"
        Me.LSubject.TextSize = New System.Drawing.Size(74, 23)
        '
        'LBody
        '
        Me.LBody.Control = Me.txtBody
        Me.LBody.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.rsz_11rsz_asterisk
        Me.LBody.Location = New System.Drawing.Point(0, 42)
        Me.LBody.Name = "LBody"
        Me.LBody.Size = New System.Drawing.Size(2262, 220)
        Me.LBody.Tag = "1"
        Me.LBody.Text = "Κείμενο"
        Me.LBody.TextSize = New System.Drawing.Size(74, 23)
        '
        'APTTableAdapter
        '
        Me.APTTableAdapter.ClearBeforeFill = True
        '
        'SSM
        '
        Me.SSM.ClosingDelay = 500
        '
        'frmEmailAPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2282, 978)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmEmailAPT"
        Me.Text = "frmEmailAPT"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtBody.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAPT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepSendEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LSubject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents grdAPT As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents Priamos_NETDataSet3 As Priamos_NETDataSet3
    Friend WithEvents APTBindingSource As BindingSource
    Friend WithEvents APTTableAdapter As Priamos_NETDataSet3TableAdapters.APTTableAdapter
    Friend WithEvents colid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colttl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcctOwnerEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcctTenantEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcctRepresentativeEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSend As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepSendEmail As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents colsendEmailOwner As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colsendEmailTenant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colsendEmailRepresentative As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coleidop1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colsyg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colreceipt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SSM As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents colbal_adm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdBatchSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBody As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtSubject As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LSubject As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LBody As DevExpress.XtraLayout.LayoutControlItem
End Class
