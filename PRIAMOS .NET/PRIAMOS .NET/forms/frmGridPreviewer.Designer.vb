<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGridPreviewer
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
        Me.components = New System.ComponentModel.Container()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Rep_Credit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.Priamos_NET_DataSet_BDG = New PRIAMOS.NET.Priamos_NET_DataSet_BDG()
        Me.VwINVOILDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Vw_INV_OILDTableAdapter = New PRIAMOS.NET.Priamos_NET_DataSet_BDGTableAdapters.vw_INV_OILDTableAdapter()
        Me.colinvNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colinvDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colliters = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcreatedOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRealName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMachineName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmdtH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmdtB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltotalBdgMesDifH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltotalBdgMesDifB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcalH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcalB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltotalCal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colconsumptionH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colconsumptionB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltotConsumption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colconsumptionLiterH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colconsumptionLiterB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltotConsumptionLiter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMeasurementCatName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldtMeasurement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltankmes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltankmesB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltankmesT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltankLiters = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltankLitersB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltankLitersT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltankID = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rep_Credit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Priamos_NET_DataSet_BDG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwINVOILDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdExit)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1593, 782)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.ImageOptions.Image = Global.PRIAMOS.NET.My.Resources.Resources.icons8_exit_16
        Me.cmdExit.Location = New System.Drawing.Point(1349, 731)
        Me.cmdExit.Margin = New System.Windows.Forms.Padding(5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(232, 39)
        Me.cmdExit.StyleController = Me.LayoutControl1
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Έξοδος"
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.VwINVOILDBindingSource
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.GridControl1.Location = New System.Drawing.Point(12, 12)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.Rep_Credit})
        Me.GridControl1.Size = New System.Drawing.Size(1569, 715)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colinvNumber, Me.colinvDate, Me.colliters, Me.colcreatedOn, Me.colRealName, Me.colMachineName, Me.colmdtH, Me.colmdtB, Me.coltotalBdgMesDifH, Me.coltotalBdgMesDifB, Me.colcalH, Me.colcalB, Me.coltotalCal, Me.colconsumptionH, Me.colconsumptionB, Me.coltotConsumption, Me.colconsumptionLiterH, Me.colconsumptionLiterB, Me.coltotConsumptionLiter, Me.colMeasurementCatName, Me.coldtMeasurement, Me.coltankmes, Me.coltankmesB, Me.coltankmesT, Me.coltankLiters, Me.coltankLitersB, Me.coltankLitersT, Me.coltankID})
        Me.GridView1.DetailHeight = 619
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsLayout.StoreAllOptions = True
        Me.GridView1.OptionsLayout.StoreFormatRules = True
        Me.GridView1.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView1.OptionsMenu.ShowFooterItem = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Rep_Credit
        '
        Me.Rep_Credit.AutoHeight = False
        Me.Rep_Credit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Left), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.Rep_Credit.Name = "Rep_Credit"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1593, 782)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1573, 719)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdExit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1337, 719)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(236, 43)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 719)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1337, 43)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'Priamos_NET_DataSet_BDG
        '
        Me.Priamos_NET_DataSet_BDG.DataSetName = "Priamos_NET_DataSet_BDG"
        Me.Priamos_NET_DataSet_BDG.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VwINVOILDBindingSource
        '
        Me.VwINVOILDBindingSource.DataMember = "vw_INV_OILD"
        Me.VwINVOILDBindingSource.DataSource = Me.Priamos_NET_DataSet_BDG
        '
        'Vw_INV_OILDTableAdapter
        '
        Me.Vw_INV_OILDTableAdapter.ClearBeforeFill = True
        '
        'colinvNumber
        '
        Me.colinvNumber.FieldName = "invNumber"
        Me.colinvNumber.MinWidth = 35
        Me.colinvNumber.Name = "colinvNumber"
        Me.colinvNumber.Visible = True
        Me.colinvNumber.VisibleIndex = 0
        Me.colinvNumber.Width = 131
        '
        'colinvDate
        '
        Me.colinvDate.FieldName = "invDate"
        Me.colinvDate.MinWidth = 35
        Me.colinvDate.Name = "colinvDate"
        Me.colinvDate.Visible = True
        Me.colinvDate.VisibleIndex = 1
        Me.colinvDate.Width = 131
        '
        'colliters
        '
        Me.colliters.FieldName = "liters"
        Me.colliters.MinWidth = 35
        Me.colliters.Name = "colliters"
        Me.colliters.Visible = True
        Me.colliters.VisibleIndex = 2
        Me.colliters.Width = 131
        '
        'colcreatedOn
        '
        Me.colcreatedOn.FieldName = "createdOn"
        Me.colcreatedOn.MinWidth = 35
        Me.colcreatedOn.Name = "colcreatedOn"
        Me.colcreatedOn.Visible = True
        Me.colcreatedOn.VisibleIndex = 3
        Me.colcreatedOn.Width = 131
        '
        'colRealName
        '
        Me.colRealName.FieldName = "RealName"
        Me.colRealName.MinWidth = 35
        Me.colRealName.Name = "colRealName"
        Me.colRealName.Visible = True
        Me.colRealName.VisibleIndex = 4
        Me.colRealName.Width = 131
        '
        'colMachineName
        '
        Me.colMachineName.FieldName = "MachineName"
        Me.colMachineName.MinWidth = 35
        Me.colMachineName.Name = "colMachineName"
        Me.colMachineName.Visible = True
        Me.colMachineName.VisibleIndex = 5
        Me.colMachineName.Width = 131
        '
        'colmdtH
        '
        Me.colmdtH.FieldName = "mdtH"
        Me.colmdtH.MinWidth = 35
        Me.colmdtH.Name = "colmdtH"
        Me.colmdtH.Visible = True
        Me.colmdtH.VisibleIndex = 6
        Me.colmdtH.Width = 131
        '
        'colmdtB
        '
        Me.colmdtB.FieldName = "mdtB"
        Me.colmdtB.MinWidth = 35
        Me.colmdtB.Name = "colmdtB"
        Me.colmdtB.Visible = True
        Me.colmdtB.VisibleIndex = 7
        Me.colmdtB.Width = 131
        '
        'coltotalBdgMesDifH
        '
        Me.coltotalBdgMesDifH.FieldName = "totalBdgMesDifH"
        Me.coltotalBdgMesDifH.MinWidth = 35
        Me.coltotalBdgMesDifH.Name = "coltotalBdgMesDifH"
        Me.coltotalBdgMesDifH.Visible = True
        Me.coltotalBdgMesDifH.VisibleIndex = 8
        Me.coltotalBdgMesDifH.Width = 131
        '
        'coltotalBdgMesDifB
        '
        Me.coltotalBdgMesDifB.FieldName = "totalBdgMesDifB"
        Me.coltotalBdgMesDifB.MinWidth = 35
        Me.coltotalBdgMesDifB.Name = "coltotalBdgMesDifB"
        Me.coltotalBdgMesDifB.Visible = True
        Me.coltotalBdgMesDifB.VisibleIndex = 9
        Me.coltotalBdgMesDifB.Width = 131
        '
        'colcalH
        '
        Me.colcalH.FieldName = "calH"
        Me.colcalH.MinWidth = 35
        Me.colcalH.Name = "colcalH"
        Me.colcalH.Visible = True
        Me.colcalH.VisibleIndex = 10
        Me.colcalH.Width = 131
        '
        'colcalB
        '
        Me.colcalB.FieldName = "calB"
        Me.colcalB.MinWidth = 35
        Me.colcalB.Name = "colcalB"
        Me.colcalB.Visible = True
        Me.colcalB.VisibleIndex = 11
        Me.colcalB.Width = 131
        '
        'coltotalCal
        '
        Me.coltotalCal.FieldName = "totalCal"
        Me.coltotalCal.MinWidth = 35
        Me.coltotalCal.Name = "coltotalCal"
        Me.coltotalCal.Visible = True
        Me.coltotalCal.VisibleIndex = 12
        Me.coltotalCal.Width = 131
        '
        'colconsumptionH
        '
        Me.colconsumptionH.FieldName = "consumptionH"
        Me.colconsumptionH.MinWidth = 35
        Me.colconsumptionH.Name = "colconsumptionH"
        Me.colconsumptionH.Visible = True
        Me.colconsumptionH.VisibleIndex = 13
        Me.colconsumptionH.Width = 131
        '
        'colconsumptionB
        '
        Me.colconsumptionB.FieldName = "consumptionB"
        Me.colconsumptionB.MinWidth = 35
        Me.colconsumptionB.Name = "colconsumptionB"
        Me.colconsumptionB.Visible = True
        Me.colconsumptionB.VisibleIndex = 14
        Me.colconsumptionB.Width = 131
        '
        'coltotConsumption
        '
        Me.coltotConsumption.FieldName = "totConsumption"
        Me.coltotConsumption.MinWidth = 35
        Me.coltotConsumption.Name = "coltotConsumption"
        Me.coltotConsumption.Visible = True
        Me.coltotConsumption.VisibleIndex = 15
        Me.coltotConsumption.Width = 131
        '
        'colconsumptionLiterH
        '
        Me.colconsumptionLiterH.FieldName = "consumptionLiterH"
        Me.colconsumptionLiterH.MinWidth = 35
        Me.colconsumptionLiterH.Name = "colconsumptionLiterH"
        Me.colconsumptionLiterH.Visible = True
        Me.colconsumptionLiterH.VisibleIndex = 16
        Me.colconsumptionLiterH.Width = 131
        '
        'colconsumptionLiterB
        '
        Me.colconsumptionLiterB.FieldName = "consumptionLiterB"
        Me.colconsumptionLiterB.MinWidth = 35
        Me.colconsumptionLiterB.Name = "colconsumptionLiterB"
        Me.colconsumptionLiterB.Visible = True
        Me.colconsumptionLiterB.VisibleIndex = 17
        Me.colconsumptionLiterB.Width = 131
        '
        'coltotConsumptionLiter
        '
        Me.coltotConsumptionLiter.FieldName = "totConsumptionLiter"
        Me.coltotConsumptionLiter.MinWidth = 35
        Me.coltotConsumptionLiter.Name = "coltotConsumptionLiter"
        Me.coltotConsumptionLiter.Visible = True
        Me.coltotConsumptionLiter.VisibleIndex = 18
        Me.coltotConsumptionLiter.Width = 131
        '
        'colMeasurementCatName
        '
        Me.colMeasurementCatName.FieldName = "MeasurementCatName"
        Me.colMeasurementCatName.MinWidth = 35
        Me.colMeasurementCatName.Name = "colMeasurementCatName"
        Me.colMeasurementCatName.Visible = True
        Me.colMeasurementCatName.VisibleIndex = 19
        Me.colMeasurementCatName.Width = 131
        '
        'coldtMeasurement
        '
        Me.coldtMeasurement.FieldName = "dtMeasurement"
        Me.coldtMeasurement.MinWidth = 35
        Me.coldtMeasurement.Name = "coldtMeasurement"
        Me.coldtMeasurement.Visible = True
        Me.coldtMeasurement.VisibleIndex = 20
        Me.coldtMeasurement.Width = 131
        '
        'coltankmes
        '
        Me.coltankmes.FieldName = "tankmes"
        Me.coltankmes.MinWidth = 35
        Me.coltankmes.Name = "coltankmes"
        Me.coltankmes.Visible = True
        Me.coltankmes.VisibleIndex = 21
        Me.coltankmes.Width = 131
        '
        'coltankmesB
        '
        Me.coltankmesB.FieldName = "tankmesB"
        Me.coltankmesB.MinWidth = 35
        Me.coltankmesB.Name = "coltankmesB"
        Me.coltankmesB.Visible = True
        Me.coltankmesB.VisibleIndex = 22
        Me.coltankmesB.Width = 131
        '
        'coltankmesT
        '
        Me.coltankmesT.FieldName = "tankmesT"
        Me.coltankmesT.MinWidth = 35
        Me.coltankmesT.Name = "coltankmesT"
        Me.coltankmesT.Visible = True
        Me.coltankmesT.VisibleIndex = 23
        Me.coltankmesT.Width = 131
        '
        'coltankLiters
        '
        Me.coltankLiters.FieldName = "tankLiters"
        Me.coltankLiters.MinWidth = 35
        Me.coltankLiters.Name = "coltankLiters"
        Me.coltankLiters.Visible = True
        Me.coltankLiters.VisibleIndex = 24
        Me.coltankLiters.Width = 131
        '
        'coltankLitersB
        '
        Me.coltankLitersB.FieldName = "tankLitersB"
        Me.coltankLitersB.MinWidth = 35
        Me.coltankLitersB.Name = "coltankLitersB"
        Me.coltankLitersB.Visible = True
        Me.coltankLitersB.VisibleIndex = 25
        Me.coltankLitersB.Width = 131
        '
        'coltankLitersT
        '
        Me.coltankLitersT.FieldName = "tankLitersT"
        Me.coltankLitersT.MinWidth = 35
        Me.coltankLitersT.Name = "coltankLitersT"
        Me.coltankLitersT.Visible = True
        Me.coltankLitersT.VisibleIndex = 26
        Me.coltankLitersT.Width = 131
        '
        'coltankID
        '
        Me.coltankID.FieldName = "tankID"
        Me.coltankID.MinWidth = 35
        Me.coltankID.Name = "coltankID"
        Me.coltankID.Visible = True
        Me.coltankID.VisibleIndex = 27
        Me.coltankID.Width = 131
        '
        'frmGridPreviewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1593, 782)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmGridPreviewer"
        Me.Text = "frmGridPreviewer"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rep_Credit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Priamos_NET_DataSet_BDG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwINVOILDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Rep_Credit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents Priamos_NET_DataSet_BDG As Priamos_NET_DataSet_BDG
    Friend WithEvents VwINVOILDBindingSource As BindingSource
    Friend WithEvents Vw_INV_OILDTableAdapter As Priamos_NET_DataSet_BDGTableAdapters.vw_INV_OILDTableAdapter
    Friend WithEvents colinvNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colinvDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colliters As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcreatedOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRealName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMachineName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmdtH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmdtB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltotalBdgMesDifH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltotalBdgMesDifB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcalH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcalB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltotalCal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colconsumptionH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colconsumptionB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltotConsumption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colconsumptionLiterH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colconsumptionLiterB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltotConsumptionLiter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMeasurementCatName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldtMeasurement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltankmes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltankmesB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltankmesT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltankLiters As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltankLitersB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltankLitersT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltankID As DevExpress.XtraGrid.Columns.GridColumn
End Class
