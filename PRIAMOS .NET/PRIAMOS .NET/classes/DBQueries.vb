Imports System.Data.SqlClient
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors
Imports Microsoft.SqlServer.Server

Public Class DBQueries
    Public Function GetNextId(ByVal sTable As String) As Integer
        Dim cmd As SqlCommand = New SqlCommand("SELECT IDENT_CURRENT('" & sTable & "') + 1 AS ID", CNDB)
        Dim ID As Integer = cmd.ExecuteScalar()
        Return ID
    End Function
    Public Function InsertData(ByVal control As DevExpress.XtraLayout.LayoutControl, ByVal sTable As String, Optional ByVal sGuid As String = "") As Boolean
        Dim sSQLF As New System.Text.StringBuilder ' Το 1ο StringField αφορά τα πεδία
        Dim sSQLV As New System.Text.StringBuilder ' Το 2ο StringField αφορά τις τιμές
        Dim IsFirstField As Boolean = True
        Try
            'Εαν η function καλεστεί με sGuid σημαίνει ότι θα πρε΄πει να καταχωρίσουμε εμείς το ID
            If sGuid.Length > 0 Then IsFirstField = False
            'FIELDS
            sSQLF.AppendLine("INSERT INTO " & sTable & "(" & IIf(sGuid.Length > 0, "ID", ""))
            'VALUES
            sSQLV.AppendLine("VALUES(" & IIf(sGuid.Length > 0, toSQLValueS(sGuid), ""))
            For Each item As BaseLayoutItem In control.Items
                If TypeOf item Is LayoutControlItem Then
                    Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                    If LItem.ControlName <> Nothing Then
                        ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                        If LItem.Control.Tag <> "" Then
                            ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                            If LItem.Control.Visible = True Then
                                ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                sSQLF.Append(IIf(IsFirstField = True, "", ",") & LItem.Control.Tag)
                                ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                                ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                                Dim Ctrl As Control = LItem.Control
                                If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                    Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                    cbo = Ctrl
                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(cbo.EditValue.ToString))
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                    Dim txt As DevExpress.XtraEditors.TextEdit
                                    txt = Ctrl
                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & toSQLValueS(txt.Text))
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                    Dim chk As DevExpress.XtraEditors.CheckEdit
                                    chk = Ctrl
                                    sSQLV.Append(IIf(IsFirstField = True, "", ",") & chk.EditValue)
                                End If
                                IsFirstField = False
                            End If
                        End If
                    End If
                End If
            Next
            sSQLF.Append(", [modifiedBy],[createdOn]) ")
            sSQLV.Append("," & toSQLValueS(UserProps.ID.ToString) & ", getdate() )")
            sSQLF.AppendLine(sSQLV.ToString)
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQLF.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function UpdateData(ByVal control As DevExpress.XtraLayout.LayoutControl, ByVal sTable As String, ByVal sID As String) As Boolean
        Dim sSQL As New System.Text.StringBuilder ' Το 1ο StringField αφορά τα πεδία
        Dim IsFirstField As Boolean = True
        Try
            'Εαν η function καλεστεί με sGuid σημαίνει ότι θα πρε΄πει να καταχωρίσουμε εμείς το ID
            'FIELDS
            sSQL.AppendLine("UPDATE " & sTable & " SET ")
            For Each item As BaseLayoutItem In control.Items
                If TypeOf item Is LayoutControlItem Then
                    Dim LItem As LayoutControlItem = CType(item, LayoutControlItem)
                    If LItem.ControlName <> Nothing Then
                        ' Εαν δεν έχω ορίσει tag στο Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                        If LItem.Control.Tag <> "" Then
                            ' Εαν δεν είναι visible το Control δεν θα συμπεριληφθεί στο INSERT-UPDATE
                            If LItem.Control.Visible = True Then
                                ' Παίρνω το Tag του  Control και το προσθέτω για το INSERT-UPDATE
                                sSQL.Append(IIf(IsFirstField = True, "", ",") & LItem.Control.Tag & " = ")
                                ' Παίρνω τον τύπο του Control ώστε να δώ με ποιον τρόπ θα πάρω το value.
                                ' Αλλιώς το παίρνουμε όταν είναι text και αλλιώς όταν είναι LookupEdit
                                Dim Ctrl As Control = LItem.Control
                                If TypeOf Ctrl Is DevExpress.XtraEditors.LookUpEdit Then
                                    Dim cbo As DevExpress.XtraEditors.LookUpEdit
                                    cbo = Ctrl
                                    sSQL.Append(toSQLValueS(cbo.EditValue.ToString))
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.TextEdit Then
                                    Dim txt As DevExpress.XtraEditors.TextEdit
                                    txt = Ctrl
                                    sSQL.Append(toSQLValueS(txt.Text))
                                ElseIf TypeOf Ctrl Is DevExpress.XtraEditors.CheckEdit Then
                                    Dim chk As DevExpress.XtraEditors.CheckEdit
                                    chk = Ctrl
                                    sSQL.Append(chk.EditValue)
                                End If
                                IsFirstField = False
                            End If
                        End If
                    End If
                End If
            Next
            sSQL.Append(", [modifiedBy] = " & toSQLValueS(UserProps.ID.ToString))
            sSQL.Append("WHERE ID = " & toSQLValueS(sID))
            'Εκτέλεση QUERY
            Using oCmd As New SqlCommand(sSQL.ToString, CNDB)
                oCmd.ExecuteNonQuery()
            End Using
            Return True
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
