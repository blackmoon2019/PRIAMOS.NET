<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SygHeader
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
        Dim QueryParameter1 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SygHeader))
        Dim CrossTabColumnDefinition1 As DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition = New DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition(0.6992753!)
        Dim CrossTabColumnDefinition2 As DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition = New DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition(99.82156!)
        Dim CrossTabColumnDefinition3 As DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition = New DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition(0.6992685!)
        Dim CrossTabColumnField1 As DevExpress.XtraReports.UI.CrossTab.CrossTabColumnField = New DevExpress.XtraReports.UI.CrossTab.CrossTabColumnField()
        Dim CrossTabRowDefinition1 As DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition = New DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition(2.083332!)
        Dim DynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrCrossTab1 = New DevExpress.XtraReports.UI.XRCrossTab()
        Me.CrossTabHeaderCell1 = New DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell()
        Me.CrossTabDataCell1 = New DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell()
        Me.CrossTabHeaderCell2 = New DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell()
        Me.CrossTabHeaderCell3 = New DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell()
        Me.CrossTabHeaderCell4 = New DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell()
        Me.CrossTabTotalCell1 = New DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell()
        Me.CrossTabGeneralStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.CrossTabHeaderStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.CrossTabDataStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.CrossTabTotalStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.inhID = New DevExpress.XtraReports.Parameters.Parameter()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        CType(Me.XrCrossTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "PRIAMOS.NET.My.MySettings.Priamos_NETConnectionStringRemote"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        CustomSqlQuery1.Name = "vw_INC"
        QueryParameter1.Name = "inhID"
        QueryParameter1.Type = GetType(DevExpress.DataAccess.Expression)
        QueryParameter1.Value = New DevExpress.DataAccess.Expression("?inhID", GetType(System.Guid))
        CustomSqlQuery1.Parameters.AddRange(New DevExpress.DataAccess.Sql.QueryParameter() {QueryParameter1})
        CustomSqlQuery1.Sql = "select distinct inhID,mlcRepName,calcCatOrd from vw_inc where inhID= @inhID order" &
    " by calcCatOrd"
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 0!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 1.041667!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.HeightF = 0!
        Me.Detail.Name = "Detail"
        '
        'XrCrossTab1
        '
        Me.XrCrossTab1.Cells.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.CrossTabHeaderCell1, Me.CrossTabDataCell1, Me.CrossTabHeaderCell2, Me.CrossTabHeaderCell3, Me.CrossTabHeaderCell4, Me.CrossTabTotalCell1})
        CrossTabColumnDefinition1.Visible = False
        CrossTabColumnDefinition2.AutoWidthMode = DevExpress.XtraReports.UI.AutoSizeMode.ShrinkAndGrow
        CrossTabColumnDefinition3.Visible = False
        Me.XrCrossTab1.ColumnDefinitions.AddRange(New DevExpress.XtraReports.UI.CrossTab.CrossTabColumnDefinition() {CrossTabColumnDefinition1, CrossTabColumnDefinition2, CrossTabColumnDefinition3})
        CrossTabColumnField1.FieldName = "mlcRepName"
        Me.XrCrossTab1.ColumnFields.AddRange(New DevExpress.XtraReports.UI.CrossTab.CrossTabColumnField() {CrossTabColumnField1})
        Me.XrCrossTab1.DataAreaStyleName = "CrossTabDataStyle1"
        Me.XrCrossTab1.DataMember = "vw_INC"
        Me.XrCrossTab1.DataSource = Me.SqlDataSource1
        Me.XrCrossTab1.GeneralStyleName = "CrossTabGeneralStyle1"
        Me.XrCrossTab1.HeaderAreaStyleName = "CrossTabHeaderStyle1"
        Me.XrCrossTab1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrCrossTab1.Name = "XrCrossTab1"
        CrossTabRowDefinition1.Visible = False
        Me.XrCrossTab1.RowDefinitions.AddRange(New DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition() {New DevExpress.XtraReports.UI.CrossTab.CrossTabRowDefinition(18.54165!), CrossTabRowDefinition1})
        Me.XrCrossTab1.SizeF = New System.Drawing.SizeF(101.2201!, 20.62498!)
        Me.XrCrossTab1.TotalAreaStyleName = "CrossTabTotalStyle1"
        '
        'CrossTabHeaderCell1
        '
        Me.CrossTabHeaderCell1.ColumnIndex = 0
        Me.CrossTabHeaderCell1.Name = "CrossTabHeaderCell1"
        Me.CrossTabHeaderCell1.RowIndex = 0
        '
        'CrossTabDataCell1
        '
        Me.CrossTabDataCell1.ColumnIndex = 1
        Me.CrossTabDataCell1.Name = "CrossTabDataCell1"
        Me.CrossTabDataCell1.RowIndex = 1
        '
        'CrossTabHeaderCell2
        '
        Me.CrossTabHeaderCell2.ColumnIndex = 1
        Me.CrossTabHeaderCell2.Font = New DevExpress.Drawing.DXFont("Bookman Old Style", 9.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.CrossTabHeaderCell2.Name = "CrossTabHeaderCell2"
        Me.CrossTabHeaderCell2.RowIndex = 0
        '
        'CrossTabHeaderCell3
        '
        Me.CrossTabHeaderCell3.ColumnIndex = 0
        Me.CrossTabHeaderCell3.Name = "CrossTabHeaderCell3"
        Me.CrossTabHeaderCell3.RowIndex = 1
        '
        'CrossTabHeaderCell4
        '
        Me.CrossTabHeaderCell4.ColumnIndex = 2
        Me.CrossTabHeaderCell4.Name = "CrossTabHeaderCell4"
        Me.CrossTabHeaderCell4.RowIndex = 0
        Me.CrossTabHeaderCell4.Text = "Grand Total"
        '
        'CrossTabTotalCell1
        '
        Me.CrossTabTotalCell1.ColumnIndex = 2
        Me.CrossTabTotalCell1.Name = "CrossTabTotalCell1"
        Me.CrossTabTotalCell1.RowIndex = 1
        '
        'CrossTabGeneralStyle1
        '
        Me.CrossTabGeneralStyle1.BackColor = System.Drawing.Color.White
        Me.CrossTabGeneralStyle1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CrossTabGeneralStyle1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.CrossTabGeneralStyle1.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.CrossTabGeneralStyle1.ForeColor = System.Drawing.Color.Black
        Me.CrossTabGeneralStyle1.Name = "CrossTabGeneralStyle1"
        Me.CrossTabGeneralStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        '
        'CrossTabHeaderStyle1
        '
        Me.CrossTabHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CrossTabHeaderStyle1.Name = "CrossTabHeaderStyle1"
        Me.CrossTabHeaderStyle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'CrossTabDataStyle1
        '
        Me.CrossTabDataStyle1.Name = "CrossTabDataStyle1"
        Me.CrossTabDataStyle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'CrossTabTotalStyle1
        '
        Me.CrossTabTotalStyle1.Name = "CrossTabTotalStyle1"
        Me.CrossTabTotalStyle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'inhID
        '
        Me.inhID.Description = "inhID"
        Me.inhID.Name = "inhID"
        Me.inhID.Type = GetType(System.Guid)
        Me.inhID.ValueInfo = "936eacb0-936a-4952-831a-9886b55df64a"
        DynamicListLookUpSettings1.DataMember = "vw_INC"
        DynamicListLookUpSettings1.DataSource = Me.SqlDataSource1
        DynamicListLookUpSettings1.DisplayMember = "inhID"
        DynamicListLookUpSettings1.FilterString = Nothing
        DynamicListLookUpSettings1.SortMember = Nothing
        DynamicListLookUpSettings1.ValueMember = "inhID"
        Me.inhID.ValueSourceSettings = DynamicListLookUpSettings1
        Me.inhID.Visible = False
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrCrossTab1})
        Me.PageHeader.HeightF = 20.62498!
        Me.PageHeader.Name = "PageHeader"
        '
        'SygHeader
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.PageHeader})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.SqlDataSource1})
        Me.DataMember = "vw_INC"
        Me.DataSource = Me.SqlDataSource1
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(100, 100, 0, 1)
        Me.PageHeight = 1654
        Me.PageWidth = 1169
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A3
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.inhID})
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.CrossTabGeneralStyle1, Me.CrossTabHeaderStyle1, Me.CrossTabDataStyle1, Me.CrossTabTotalStyle1})
        Me.Version = "21.2"
        CType(Me.XrCrossTab1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents XrCrossTab1 As DevExpress.XtraReports.UI.XRCrossTab
    Friend WithEvents CrossTabHeaderCell1 As DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell
    Friend WithEvents CrossTabDataCell1 As DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell
    Friend WithEvents CrossTabHeaderCell2 As DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell
    Friend WithEvents CrossTabHeaderCell3 As DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell
    Friend WithEvents CrossTabGeneralStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents CrossTabHeaderStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents CrossTabDataStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents CrossTabTotalStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents inhID As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents CrossTabHeaderCell4 As DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell
    Friend WithEvents CrossTabTotalCell1 As DevExpress.XtraReports.UI.CrossTab.XRCrossTabCell
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
End Class
