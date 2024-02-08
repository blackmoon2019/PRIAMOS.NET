Imports System.Data.SqlClient
Imports DevExpress.PivotGrid.QueryMode
Imports DevExpress.Utils
Imports DevExpress.XtraEditors

Public Class InvOilGas
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Private LoadForms As New FormLoader

    Public Sub AddNewOilInv(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup, Optional ExceptFields As List(Of String) = Nothing)
        Cls.ClearGroupCtrls(GRP, ExceptFields)
    End Sub
    Public Sub AddNewGasInv(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup, Optional ExceptFields As List(Of String) = Nothing)
        Cls.ClearGroupCtrls(GRP, ExceptFields)
    End Sub
    Public Function InsertOilData(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup, ByVal sGuid As String, ByVal ExtraFields As String, ByVal ExtraValues As String) As Boolean
        Return DBQ.InsertNewData(DBQueries.InsertMode.GroupLayoutControl, "INV_OIL",,, GRP, sGuid,, ExtraFields, toSQLValueS(ExtraValues))
    End Function
    Public Function InsertGasData(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup, ByVal sGuid As String, ByVal ExtraFields As String, ByVal ExtraValues As String) As Boolean
        Return DBQ.InsertNewData(DBQueries.InsertMode.GroupLayoutControl, "INV_GAS",,, GRP, sGuid,, "bdgid", toSQLValueS(ExtraValues))
    End Function

    Public Function UpdateOilData(ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sGuid As String, ByVal FieldsToBeUpdate As List(Of String))
        Return DBQ.UpdateNewData(DBQueries.InsertMode.GridControl, "INV_OIL",,,, sGuid,, GRD, FieldsToBeUpdate)
    End Function
    Public Function UpdateGasData(ByVal GRD As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sGuid As String, ByVal FieldsToBeUpdate As List(Of String))
        Return DBQ.UpdateNewData(DBQueries.InsertMode.GridControl, "INV_GAS",,,, sGuid,, GRD, FieldsToBeUpdate)
    End Function

    Public Sub LoadOilRecords(ByRef GRDControl As DevExpress.XtraGrid.GridControl, ByRef GRDView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sSQL As String)
        LoadForms.LoadDataToGrid(GRDControl, GRDView, sSQL, True)
        LoadForms.RestoreLayoutFromXml(GRDView, "INV_OIL_def.xml")
    End Sub
    Public Sub LoadGasRecords(ByRef GRDControl As DevExpress.XtraGrid.GridControl, ByRef GRDView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sSQL As String)
        LoadForms.LoadDataToGrid(GRDControl, GRDView, sSQL, True)
        LoadForms.RestoreLayoutFromXml(GRDView, "INV_GAS_def.xml")
    End Sub
    Public Sub DeleteRecord(ByVal sID As String, ByVal sTable As String)
        Dim sSQL As String
        Try
            Select Case sTable
                Case "INV_OIL"
                    If CheckifINVIsUsed(sID, sTable) = True Then
                        XtraMessageBox.Show("Το τιμολόγιο χρησιμοποιείται σε Κατανάλωση(Δεξαμενή)", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Case "INV_GAS"
                    If CheckifINVIsUsed(sID, sTable) = True Then
                        XtraMessageBox.Show("Το τιμολόγιο χρησιμοποιείται σε Κατανάλωση. Πρέπει να ακυρώσετε τον υπολογισμό", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

            End Select
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", ProgProps.ProgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                sSQL = "DELETE FROM " & sTable & " WHERE ID = " & toSQLValueS(sID)

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch sqlex As SqlException
            Select Case sqlex.ErrorCode
                Case -2146232060
                    XtraMessageBox.Show("Το τιμολόγιο δεν μπορεί να διαγραφέι γιατί συμμετέχει σε παραστατικό.", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function CheckifINVIsUsed(ByVal sID As String, ByVal sTable As String) As Boolean
        Dim sSQL As String
        Dim sinvID As String
        Select Case sTable
            Case "INV_OIL" : sSQL = "select top 1 ID from INV_OILD where   INVoILid = " & toSQLValueS(sID)
            Case "INV_GAS" : sSQL = "select top 1 ID from CONSUMPTIONS where  invGasID = " & toSQLValueS(sID)
        End Select
        Dim cmd As SqlCommand
        Dim sdr As SqlDataReader
        cmd = New SqlCommand(sSQL, CNDB)
        sdr = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            sinvID = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
            sdr.Close()
            Return True
        Else
            sdr.Close()
            Return False
        End If
    End Function


    Public Sub DeleteRecordWithoutQuestion(ByVal sID As String, ByVal sTable As String)
        Dim sSQL As String
        Try

            sSQL = "DELETE FROM " & sTable & " WHERE ID = " & toSQLValueS(sID)

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            'XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
