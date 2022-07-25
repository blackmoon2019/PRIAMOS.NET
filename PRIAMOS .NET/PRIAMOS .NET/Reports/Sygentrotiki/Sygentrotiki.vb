Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI

Public Class Rep_Sygentrotiki
    Private bHasFI As Boolean
    Private bHasFIBoiler As Boolean
    Public WriteOnly Property HasFI As Boolean
        Set(value As Boolean)
            bHasFI = value
        End Set
    End Property

    Public WriteOnly Property HasFIBoiler As Boolean
        Set(value As Boolean)
            bHasFIBoiler = value
        End Set
    End Property
    Private Sub Rep_Sygentrotiki_AfterPrint(sender As Object, e As EventArgs) Handles Me.AfterPrint


    End Sub
    'Ενημέρωση ημερομηνίας εκτύπωσης
    Private Sub Rep_Sygentrotiki_PrintProgress(sender As Object, e As PrintProgressEventArgs) Handles Me.PrintProgress
        Dim sSQL As String
        sSQL = "UPDATE INH SET DATEOFPRINT = GETDATE() WHERE DATEOFPRINT IS NULL AND ID = " & toSQLValueS(inhID.Value.ToString)
        Using oCmd As New SqlCommand(sSQL, CNDB)
            oCmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub XrTable1_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTable1.BeforePrint
        'Τον παρακάτω έλεγχο τον έβαλα γιατί για κάποιο λόγο φορτωνεται 2 φορές το Report
        'If XrTable6.Rows(0).Cells(0).ExpressionBindings.Count = 1 Then Exit Sub
        FillMlcHeader()
        FillExodaHeader()
    End Sub
    Private Sub FillMlcHeader()
        Dim i As Integer = 0
        Try
            Dim sSQL As String
            sSQL = "select distinct mlcRepName,calcCatOrd from vw_inc where inhID= " & toSQLValueS(Parameters.Item(0).Value.ToString) &
                    IIf(bHasFI, " UNION select 'FI ΘΕΡΜ.',10   ", " ") &
                    IIf(bHasFIBoiler, " UNION select 'FI BOIL.',11   ", " ") &
                    "order by calcCatOrd"
            Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            While sdr.Read()
                Console.WriteLine(sdr.Item(0).ToString())
                If sdr.IsDBNull(sdr.GetOrdinal("mlcRepName")) = False Then
                    'ΠΟΣΟΣΤΑ ΣΥΝΤΕΛΕΣΤΩΝ ΚΑΤΑΜΕΡΙΣΜΟΥ ΕΞΟΔΩΝ ΚΑΤΑΜΕΡΙΣΜΟΥ 
                    XrTable1.Rows(0).Cells(i).Text = sdr.GetString(sdr.GetOrdinal("mlcRepName"))
                    XrTable1.Rows(0).Cells(i).Visible = True
                End If
                i = i + 1
            End While
            If bHasFI = True Then
                XrTable1.Rows(0).Cells(i).Text = "ΩΡΕΣ Θ."
                XrTable1.Rows(0).Cells(i).Visible = True
                i = i + 1
            End If
            If bHasFIBoiler = True Then
                XrTable1.Rows(0).Cells(i).Text = "ΩΡΕΣ B."
                XrTable1.Rows(0).Cells(i).Visible = True
            End If
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error:  {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub FillExodaHeader()
        Dim i As Integer = 0
        Try
            Dim sSQL As String
            Dim SumofEnoik As New System.Text.StringBuilder
            Dim SumofIdiok As New System.Text.StringBuilder
            Dim TotalSumofEnoik As New System.Text.StringBuilder
            Dim TotalSumofIdiok As New System.Text.StringBuilder
            Dim SumofAll As New System.Text.StringBuilder
            Dim GenTot As New System.Text.StringBuilder

            sSQL = "select distinct apmilNam,calcCatRepName,calcCatOrd from vw_inc where inhID= " & toSQLValueS(Parameters.Item(0).Value.ToString) &
                    IIf(bHasFI, " UNION select 'fi','fi',10    ", " ") &
                    IIf(bHasFIBoiler, " UNION select 'fiBoiler','fiBoiler',11 ", " ") &
                    "order by calcCatOrd"

            Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            Dim summary As New XRSummary()
            summary.Func = SummaryFunc.Sum
            summary.Running = SummaryRunning.Group
            summary.IgnoreNullValues = True
            summary.TreatStringsAsNumerics = True
            summary.FormatString = "{0:N2}"

            While sdr.Read()
                Console.WriteLine(sdr.Item(0).ToString())
                If sdr.IsDBNull(sdr.GetOrdinal("calcCatRepName")) = False Then
                    XrTable2.Rows(0).Cells(i).Text = sdr.GetString(sdr.GetOrdinal("calcCatRepName"))
                    XrTable2.Rows(0).Cells(i).Visible = True
                    XrTable3.Rows(0).Cells(i).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", sdr.GetString(sdr.GetOrdinal("apmilNam"))))
                    XrTable3.Rows(0).Cells(i).Visible = True
                    XrTable5.Rows(0).Cells(i).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", "[Exodavw_APMIL]." & "[" & sdr.GetString(sdr.GetOrdinal("apmilNam")) & "]"))
                    XrTable5.Rows(0).Cells(i).Visible = True
                    XrTable7.Rows(0).Cells(i).Summary = summary
                    XrTable7.Rows(0).Cells(i).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", "Sum([Exodavw_APMIL]." & "[" & sdr.GetString(sdr.GetOrdinal("apmilNam")) & "])"))
                    XrTable7.Rows(0).Cells(i).Visible = True
                    XrTable8.Rows(0).Cells(i).Summary = summary
                    XrTable8.Rows(0).Cells(i).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", "Sum(" & sdr.GetString(sdr.GetOrdinal("apmilNam")) & ")"))
                    XrTable8.Rows(0).Cells(i).Visible = True
                    'Μόνο για ενοίκους
                    '    If sdr.GetString(sdr.GetOrdinal("apmilNam")) <> "owners" Then
                    '        If SumofEnoik.Length > 0 Then
                    '            SumofEnoik.Append(" + ")
                    '            TotalSumofEnoik.Append(" + ")
                    '            SumofIdiok.Append(" + ")
                    '            TotalSumofIdiok.Append(" + ")
                    '        End If
                    '        SumofEnoik.Append("[Exodavw_INC_TENANT]." & "[" & sdr.GetString(sdr.GetOrdinal("apmilNam")) & "]")
                    '        TotalSumofEnoik.Append("sum([Exodavw_INC_TENANT].[" & sdr.GetString(sdr.GetOrdinal("apmilNam")) & "]) ")
                    '        SumofIdiok.Append("IsNull([Exodavw_INC_OWNER]." & "[" & sdr.GetString(sdr.GetOrdinal("apmilNam")) & "], 0)")
                    '        TotalSumofIdiok.Append("sum(IsNull([Exodavw_INC_OWNER]." & "[" & sdr.GetString(sdr.GetOrdinal("apmilNam")) & "],0)) ")
                    '    End If
                End If
                i = i + 1
            End While
            If bHasFI = True Then
                XrTable5.Rows(0).Cells(i).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", "[ExodaahpbH].[mesDif]"))
                XrTable5.Rows(0).Cells(i).Visible = True
                XrTable7.Rows(0).Cells(i).Summary = summary
                XrTable7.Rows(0).Cells(i).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", "Sum([ExodaahpbH].[mesDif])"))
                XrTable7.Rows(0).Cells(i).Visible = True
                i = i + 1
            End If
            If bHasFIBoiler = True Then
                XrTable5.Rows(0).Cells(i).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", "[ExodaahpbB].[mesDif]"))
                XrTable5.Rows(0).Cells(i).Visible = True
                XrTable7.Rows(0).Cells(i).Summary = summary
                XrTable7.Rows(0).Cells(i).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", "Sum([ExodaahpbB].[mesDif])"))
                XrTable7.Rows(0).Cells(i).Visible = True
            End If
            sdr.Close()
            'Σύνολο γραμμών ενοίκου
            '  XrTable6.Rows(0).Cells(0).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", SumofEnoik.ToString))
            'Σύνολο γραμμών Ιδιοκτητών
            'XrTable6.Rows(0).Cells(1).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", SumofIdiok.ToString))
            'Γενικό Σύνολο ( ΙΔΙΟΚ. + ΕΝΟΙΚ)
            'SumofAll.Append(SumofIdiok.ToString & " + " & SumofEnoik.ToString)
            '  XrTable6.Rows(0).Cells(2).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", SumofAll.ToString))
            'Γενικό Σύνολο γραμμών ενοίκου
            ' XrTable9.Rows(0).Cells(0).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", TotalSumofEnoik.ToString))
            'Γενικό Σύνολο γραμμών Ιδιοκτητών
            'XrTable9.Rows(0).Cells(1).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", TotalSumofIdiok.ToString))

            'GenTot.Append(TotalSumofIdiok.ToString & " + " & TotalSumofEnoik.ToString)
            'XrTable9.Rows(0).Cells(2).ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", GenTot.ToString))
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub XrTableCell18_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell18.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell19_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell19.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell20_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell20.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell21_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell21.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell22_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell22.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell23_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell23.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell24_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell24.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell25_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell25.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell28_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell28.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub

    Private Sub XrTableCell29_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell29.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub

    Private Sub XrTableCell30_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell30.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell31_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell31.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell32_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell32.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell33_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell33.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell34_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell34.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell35_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell35.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell36_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell36.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell37_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell37.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell38_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell38.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell39_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell39.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell40_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell40.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell41_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell41.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell42_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell42.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell43_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell43.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell44_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell44.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell45_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell45.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell46_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell46.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell47_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell47.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell48_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell48.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell49_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell49.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell50_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell50.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell51_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell51.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell52_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell52.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell53_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell53.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell54_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell54.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell55_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell55.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell56_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell56.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell57_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell57.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell58_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell58.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub
    Private Sub XrTableCell59_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrTableCell59.BeforePrint
        Dim c As XRTableCell = CType(sender, XRTableCell)
        Dim CVAL As Double = Convert.ToDouble(c.Value)
        If CVAL = 0 Then c.Text = ""
    End Sub

End Class