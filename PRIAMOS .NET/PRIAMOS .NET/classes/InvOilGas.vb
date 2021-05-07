Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors

Public Class InvOilGas
    Private DBQ As New DBQueries
    Private Cls As New ClearControls
    Private LoadForms As New FormLoader

    Public Sub AddNewOilInv(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup)
        Cls.ClearGroupCtrls(GRP)
    End Sub
    Public Sub AddNewGasInv(ByVal GRP As DevExpress.XtraLayout.LayoutControlGroup)
        Cls.ClearGroupCtrls(GRP)
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
        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\INV_OIL_def.xml") = False Then
            GRDView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\INV_OIL_def.xml", OptionsLayoutBase.FullLayout)
        Else
            GRDView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\INV_OIL_def.xml", OptionsLayoutBase.FullLayout)
        End If

    End Sub
    Public Sub LoadGasRecords(ByRef GRDControl As DevExpress.XtraGrid.GridControl, ByRef GRDView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal sSQL As String)
        LoadForms.LoadDataToGrid(GRDControl, GRDView, sSQL, True)
        'Εαν δεν υπάρχει Default Σχέδιο δημιουργεί
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\DSGNS\DEF\INV_GAS_def.xml") = False Then
            GRDView.SaveLayoutToXml(Application.StartupPath & "\DSGNS\DEF\INV_GAS_def.xml", OptionsLayoutBase.FullLayout)
        Else
            GRDView.RestoreLayoutFromXml(Application.StartupPath & "\DSGNS\DEF\INV_GAS_def.xml", OptionsLayoutBase.FullLayout)
        End If

    End Sub
    Public Sub DeleteRecord(ByVal sID As String, ByVal sTable As String)
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή?", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                sSQL = "DELETE FROM " & sTable & " WHERE ID = " & toSQLValueS(sID)

                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
                XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecordWithoutQuestion(ByVal sID As String, ByVal sTable As String)
        Dim sSQL As String
        Try

            sSQL = "DELETE FROM " & sTable & " WHERE ID = " & toSQLValueS(sID)

            Using oCmd As New SqlCommand(sSQL, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            'XtraMessageBox.Show("Η εγγραφή διαγράφηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
