Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class frmPermissions
    Private sID As String
    Private Ctrl As DevExpress.XtraGrid.Views.Grid.GridView
    Private Frm As DevExpress.XtraEditors.XtraForm
    Public Mode As Byte
    Private Valid As New ValidateControls
    Private Log As New Transactions
    Private FillCbo As New FillCombos
    Private DBQ As New DBQueries
    Public WriteOnly Property ID As String
        Set(value As String)
            sID = value
        End Set
    End Property
    Public WriteOnly Property Scroller As DevExpress.XtraGrid.Views.Grid.GridView
        Set(value As DevExpress.XtraGrid.Views.Grid.GridView)
            Ctrl = value
        End Set
    End Property
    Public WriteOnly Property FormScroller As DevExpress.XtraEditors.XtraForm
        Set(value As DevExpress.XtraEditors.XtraForm)
            Frm = value
        End Set
    End Property

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub frmPermissions_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' Γεμίζω τους χρήστες στον Combo
            FillCbo.USERS(cboUsers)
            FillCheckedList()
            Select Case Mode
                Case FormMode.EditRecord
                    Dim cmd As SqlCommand = New SqlCommand("Select * from vw_RIGHTS where id ='" + sID + "'", CNDB)
                    Dim sdr As SqlDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        If sdr.IsDBNull(sdr.GetOrdinal("insert")) = False Then chkInsert.Checked = sdr.GetBoolean(sdr.GetOrdinal("insert"))
                        If sdr.IsDBNull(sdr.GetOrdinal("edit")) = False Then chkEdit.Checked = sdr.GetBoolean(sdr.GetOrdinal("edit"))
                        If sdr.IsDBNull(sdr.GetOrdinal("delete")) = False Then chkDelete.Checked = sdr.GetBoolean(sdr.GetOrdinal("delete"))
                        If sdr.IsDBNull(sdr.GetOrdinal("Uid")) = False Then cboUsers.EditValue = sdr.GetGuid(sdr.GetOrdinal("Uid"))
                        cboUsers.ReadOnly = True
                        'If sdr.IsDBNull(sdr.GetOrdinal("Fid")) = False Then chkLstUsers.get.EditValue = sdr.GetGuid(sdr.GetOrdinal("Uid"))
                        sdr.Close()
                    End If
                    cmdSave.Enabled = UserProps.AllowEdit
                Case FormMode.NewRecord
                    cmdSave.Enabled = UserProps.AllowInsert
            End Select

            Me.CenterToScreen()
            My.Settings.frmUsers = Me.Location
            My.Settings.Save()

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FillCheckedList()
        Try
            Dim ds As DataSet = New DataSet
            Dim sSQL As String
            If Mode = FormMode.NewRecord Then
                sSQL = "Select id,name from vw_FORMS"
            Else
                sSQL = "SELECT F.id,F.name,isnull(( 
					    select case when VF.id is not null then 1 else 0 end as checked
					    from vw_FORMs VF
					    inner join vw_FORM_RIGHTS FR on FR.F_ID  = VF.ID 
					    inner join vw_RIGHTS R on R.ID  = FR.rID 
					    where R.ID = '" + sID + "'  and VF.ID=F.ID),0) as checked
                        from vw_FORMs F "
            End If
            Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
            Dim sdr As SqlDataReader = cmd.ExecuteReader()

            'chkLstUsers.DataSource = sdr
            chkLstUsers.DisplayMember = "name"
            chkLstUsers.ValueMember = "id"
            While sdr.Read()
                Dim chkLstItem As New DevExpress.XtraEditors.Controls.CheckedListBoxItem
                chkLstItem.Value = sdr.Item(1).ToString
                chkLstItem.Tag = sdr.Item(0).ToString
                If Mode = FormMode.EditRecord Then chkLstItem.CheckState = sdr.Item(2).ToString

                chkLstUsers.Items.Add(chkLstItem)
            End While
            sdr.Close()
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim sSQL As String
        Dim sGuid As String
        Dim sResult As Boolean
        Try
            If Valid.ValidateForm(LayoutControl1) Then
                Select Case Mode
                    Case FormMode.NewRecord
                        ' Καταχώρηση General Permissions
                        sGuid = System.Guid.NewGuid.ToString
                        sResult = DBQ.InsertData(LayoutControl1, "RIGHTS", sGuid)
                        If sResult Then
                            ' Καταχώρηση Permissions Per Form
                            For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In chkLstUsers.CheckedItems
                                sSQL = "INSERT INTO FORM_RIGHTS ([RID],[FID],[modifiedBy],[createdOn])  
                                        values (" & toSQLValueS(sGuid) & "," & toSQLValueS(item.Tag.ToString()) & "," &
                                                    toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                                Using oCmd As New SqlCommand(sSQL, CNDB)
                                    oCmd.ExecuteNonQuery()
                                End Using
                            Next
                        End If
                    Case FormMode.EditRecord
                        sResult = DBQ.UpdateData(LayoutControl1, "RIGHTS", sID)
                        If sResult Then
                            sSQL = "DELETE FROM FORM_RIGHTS where RID = '" & sID & "'"
                            Using oCmd As New SqlCommand(sSQL, CNDB)
                                oCmd.ExecuteNonQuery()
                            End Using
                            ' Καταχώρηση Permissions Per Form
                            For Each item As DevExpress.XtraEditors.Controls.CheckedListBoxItem In chkLstUsers.CheckedItems
                                sSQL = "INSERT INTO FORM_RIGHTS ([RID],[FID],[modifiedBy],[createdOn])  
                                    values (" & toSQLValueS(sID) & "," & toSQLValueS(item.Tag.ToString) & "," &
                                                    toSQLValueS(UserProps.ID.ToString) & ", getdate() )"
                                Using oCmd As New SqlCommand(sSQL, CNDB)
                                    oCmd.ExecuteNonQuery()
                                End Using
                            Next
                        End If
                End Select
                Dim form As frmScroller = Frm
                form.LoadRecords("vw_RIGHTS")
                If sResult Then XtraMessageBox.Show("Η εγγραφή αποθηκέυτηκε με επιτυχία", "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmPermissions_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then frmMain.XtraTabbedMdiManager1.Dock(Me, frmMain.XtraTabbedMdiManager1)
    End Sub
End Class