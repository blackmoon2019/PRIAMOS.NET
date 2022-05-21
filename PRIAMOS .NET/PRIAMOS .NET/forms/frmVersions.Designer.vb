<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVersions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVersions))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtNam = New DevExpress.XtraEditors.TextEdit()
        Me.txtComments = New DevExpress.XtraEditors.MemoEdit()
        Me.cboType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.dtFDate = New DevExpress.XtraEditors.DateEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem53 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.cbotechnical = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlItem125 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.VwTECHSUPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PriamosNETDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Priamos_NETDataSet = New PRIAMOS.NET.Priamos_NETDataSet()
        Me.Vw_TECH_SUPTableAdapter = New PRIAMOS.NET.Priamos_NETDataSetTableAdapters.vw_TECH_SUPTableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNam.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbotechnical.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem125, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwTECHSUPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PriamosNETDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.txtCode)
        Me.LayoutControl1.Controls.Add(Me.txtNam)
        Me.LayoutControl1.Controls.Add(Me.txtComments)
        Me.LayoutControl1.Controls.Add(Me.cboType)
        Me.LayoutControl1.Controls.Add(Me.dtFDate)
        Me.LayoutControl1.Controls.Add(Me.cbotechnical)
        Me.LayoutControl1.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1240, 864)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "s"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 813)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(884, 39)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 51
        Me.SimpleButton1.Text = "Δημιουργία νέας έκδοσης"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_24
        Me.cmdExit.Location = New System.Drawing.Point(1064, 813)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(164, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 49
        Me.cmdExit.Text = "Έξοδος"
        '
        'cmdSave
        '
        Me.cmdSave.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_save_close_24
        Me.cmdSave.Location = New System.Drawing.Point(900, 813)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(160, 39)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 50
        Me.cmdSave.Text = "Αποθήκευση"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(213, 12)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(5)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Properties.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCode.Properties.Appearance.Options.UseBackColor = True
        Me.txtCode.Properties.Appearance.Options.UseFont = True
        Me.txtCode.Properties.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(87, 38)
        Me.txtCode.StyleController = Me.LayoutControl1
        Me.txtCode.TabIndex = 4
        Me.txtCode.Tag = "code,0"
        '
        'txtNam
        '
        Me.txtNam.Location = New System.Drawing.Point(213, 54)
        Me.txtNam.Margin = New System.Windows.Forms.Padding(5)
        Me.txtNam.Name = "txtNam"
        Me.txtNam.Size = New System.Drawing.Size(1015, 38)
        Me.txtNam.StyleController = Me.LayoutControl1
        Me.txtNam.TabIndex = 9
        Me.txtNam.Tag = "ver,0,1,2"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(12, 248)
        Me.txtComments.Margin = New System.Windows.Forms.Padding(5)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(1216, 561)
        Me.txtComments.StyleController = Me.LayoutControl1
        Me.txtComments.TabIndex = 17
        Me.txtComments.Tag = "descr,0,1,2"
        '
        'cboType
        '
        Me.cboType.Location = New System.Drawing.Point(213, 96)
        Me.cboType.Margin = New System.Windows.Forms.Padding(5)
        Me.cboType.Name = "cboType"
        Me.cboType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboType.Properties.Items.AddRange(New Object() {"ΝΕΑ ΛΕΙΤΟΥΡΓΙΑ", "ΠΡΟΣΘΗΚΗ", "ΔΙΟΡΘΩΣΗ"})
        Me.cboType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboType.Size = New System.Drawing.Size(1015, 38)
        Me.cboType.StyleController = Me.LayoutControl1
        Me.cboType.TabIndex = 48
        Me.cboType.Tag = "type,0,1,2"
        '
        'dtFDate
        '
        Me.dtFDate.EditValue = Nothing
        Me.dtFDate.Location = New System.Drawing.Point(213, 138)
        Me.dtFDate.Margin = New System.Windows.Forms.Padding(5)
        Me.dtFDate.Name = "dtFDate"
        Me.dtFDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtFDate.Properties.MaskSettings.Set("mask", "d")
        Me.dtFDate.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.[True]
        Me.dtFDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtFDate.Size = New System.Drawing.Size(1015, 38)
        Me.dtFDate.StyleController = Me.LayoutControl1
        Me.dtFDate.TabIndex = 38
        Me.dtFDate.Tag = "dtVer,0,1,2"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem14, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem53, Me.EmptySpaceItem1, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem125})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1240, 864)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtCode
        Me.LayoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem4.CustomizationFormText = "Κωδικός"
        Me.LayoutControlItem4.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(292, 42)
        Me.LayoutControlItem4.Text = "Κωδικός"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.txtComments
        Me.LayoutControlItem14.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem14.CustomizationFormText = "Σχόλια"
        Me.LayoutControlItem14.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 210)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(1220, 591)
        Me.LayoutControlItem14.Text = "Περιγραφή"
        Me.LayoutControlItem14.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtNam
        Me.LayoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem1.CustomizationFormText = "Επωνυμία"
        Me.LayoutControlItem1.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem1.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1220, 42)
        Me.LayoutControlItem1.Text = "Έκδοση"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboType
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1220, 42)
        Me.LayoutControlItem2.Text = "Τύπος"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(189, 23)
        '
        'LayoutControlItem53
        '
        Me.LayoutControlItem53.Control = Me.dtFDate
        Me.LayoutControlItem53.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem53.CustomizationFormText = "Ημερομηνία Τιμ."
        Me.LayoutControlItem53.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem53.ImageOptions.Image = CType(resources.GetObject("LayoutControlItem53.ImageOptions.Image"), System.Drawing.Image)
        Me.LayoutControlItem53.Location = New System.Drawing.Point(0, 126)
        Me.LayoutControlItem53.Name = "LayoutControlItem53"
        Me.LayoutControlItem53.Size = New System.Drawing.Size(1220, 42)
        Me.LayoutControlItem53.Text = "Ημερομηνία Έκδοσης"
        Me.LayoutControlItem53.TextSize = New System.Drawing.Size(189, 23)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(292, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(928, 42)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdExit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1052, 801)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(168, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cmdSave
        Me.LayoutControlItem5.Location = New System.Drawing.Point(888, 801)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(164, 43)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.SimpleButton1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 801)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(888, 43)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'cbotechnical
        '
        Me.cbotechnical.Location = New System.Drawing.Point(213, 180)
        Me.cbotechnical.Margin = New System.Windows.Forms.Padding(5)
        Me.cbotechnical.Name = "cbotechnical"
        Me.cbotechnical.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cbotechnical.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cbotechnical.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 35, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "TechnicalID", 55, DevExpress.Utils.FormatType.Numeric, "", True, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("subject", "Θέμα", 150, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("descr", "Περιγραφή", 150, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.cbotechnical.Properties.DataSource = Me.VwTECHSUPBindingSource
        Me.cbotechnical.Properties.DisplayMember = "subject"
        Me.cbotechnical.Properties.NullText = ""
        Me.cbotechnical.Properties.PopupSizeable = False
        Me.cbotechnical.Properties.ValueMember = "ID"
        Me.cbotechnical.Size = New System.Drawing.Size(1015, 38)
        Me.cbotechnical.StyleController = Me.LayoutControl1
        Me.cbotechnical.TabIndex = 27
        Me.cbotechnical.Tag = "technicalID,0,1,2"
        '
        'LayoutControlItem125
        '
        Me.LayoutControlItem125.Control = Me.cbotechnical
        Me.LayoutControlItem125.ControlAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.LayoutControlItem125.CustomizationFormText = "ΔΟΥ"
        Me.LayoutControlItem125.HighlightFocusedItem = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlItem125.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem125.Name = "LayoutControlItem125"
        Me.LayoutControlItem125.Size = New System.Drawing.Size(1220, 42)
        Me.LayoutControlItem125.Text = "TechnicalID"
        Me.LayoutControlItem125.TextSize = New System.Drawing.Size(189, 23)
        '
        'VwTECHSUPBindingSource
        '
        Me.VwTECHSUPBindingSource.DataMember = "vw_TECH_SUP"
        Me.VwTECHSUPBindingSource.DataSource = Me.PriamosNETDataSetBindingSource
        '
        'PriamosNETDataSetBindingSource
        '
        Me.PriamosNETDataSetBindingSource.DataSource = Me.Priamos_NETDataSet
        Me.PriamosNETDataSetBindingSource.Position = 0
        '
        'Priamos_NETDataSet
        '
        Me.Priamos_NETDataSet.DataSetName = "Priamos_NETDataSet"
        Me.Priamos_NETDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Vw_TECH_SUPTableAdapter
        '
        Me.Vw_TECH_SUPTableAdapter.ClearBeforeFill = True
        '
        'frmVersions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1255, 874)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmVersions"
        Me.Text = "frmVersions"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNam.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbotechnical.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem125, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwTECHSUPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PriamosNETDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NETDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNam As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtComments As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cboType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dtFDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem53 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cbotechnical As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem125 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PriamosNETDataSetBindingSource As BindingSource
    Friend WithEvents Priamos_NETDataSet As Priamos_NETDataSet
    Friend WithEvents VwTECHSUPBindingSource As BindingSource
    Friend WithEvents Vw_TECH_SUPTableAdapter As Priamos_NETDataSetTableAdapters.vw_TECH_SUPTableAdapter
End Class
