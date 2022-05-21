Imports System.Data.SqlClient
Imports System.Text
Imports DevExpress.Utils.Menu
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Commands
Imports DevExpress.XtraScheduler.Localization
Imports DevExpress.XtraScheduler.Services

Public Class frmCalendarApol
    Private Calendar As New InitializeCalendar
    Private Sub frmCalendarDecontaminatin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SchedulerLocalizer.Active = New MySchedulerLocalizer()
            'TODO: This line of code loads data into the 'Priamos_NETDataSet.vw_WORKSHOPS' table. You can move, or remove it, as needed.
            Me.Vw_WORKSHOPSTableAdapter.Fill(Me.Priamos_NETDataSet.vw_WORKSHOPS)
            Dim sSQL As String
            sSQL = "SELECT * FROM vw_APOL "
            'Δημιουργία Appointments
            Calendar.Initialize(SchedulerControl1, SchedulerDataStorage1, sSQL, True)
            cboCompleted.Items.Add("Όχι", True)
            cboCompleted.Items(0).Tag = 0
            cboCompleted.Items(0).CheckState = CheckState.Checked
            cboCompleted.Items.Add("Ναι", True)
            cboCompleted.Items(1).Tag = 1
            cboCompleted.Items(1).CheckState = CheckState.Unchecked

            SchedulerControl1.Start = Now.Date
            SchedulerControl1.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.All

        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SchedulerControl1_DoubleClick(sender As Object, e As EventArgs) Handles SchedulerControl1.DoubleClick
        Dim form1 As frmApol = New frmApol()
        form1.Text = "Απολυμάνσεις"
        form1.Scroller = frmScroller.GridView1
        form1.FormScroller = frmScroller
        form1.FormScrollerExist = False
        form1.MdiParent = frmMain
        If SchedulerControl1.SelectedAppointments.Count = 0 Then
            form1.Mode = FormMode.NewRecord
            form1.dtEdt.EditValue = SchedulerControl1.SelectedInterval.Start
            form1.tmIN.EditValue = CDate(SchedulerControl1.SelectedInterval.Start.ToString).ToString("HH:mm")
            form1.tmOUT.EditValue = CDate(SchedulerControl1.SelectedInterval.Start.ToString).ToString("HH:mm")
        Else
            For i As Integer = 0 To SchedulerControl1.SelectedAppointments.Count - 1
                Dim apt As Appointment = SchedulerControl1.SelectedAppointments(i)
                form1.ID = apt.Id
                form1.Mode = FormMode.EditRecord
            Next i
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()
    End Sub

    Private Sub SchedulerControl1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles SchedulerControl1.PopupMenuShowing
        If e.Menu.Id = DevExpress.XtraScheduler.SchedulerMenuItemId.DefaultMenu Then
            ' Hide the "Change View To" menu item.
            'Dim itemChangeViewTo As SchedulerPopupMenu = e.Menu.GetPopupMenuById(SchedulerMenuItemId.LabelSubMenu)
            'itemChangeViewTo.Visible = False
            Dim itemChangeViewTo As SchedulerPopupMenu = e.Menu.GetPopupMenuById(SchedulerMenuItemId.SwitchViewMenu)
            itemChangeViewTo.Visible = False
            ' Remove unnecessary items.
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent)
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAppointment)
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent)
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.DeleteAppointment)
            ' Disable the "New Recurring Appointment" menu item.
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment)
            ' Create a menu item for the Scheduler command.
            Dim service As ISchedulerCommandFactoryService = SchedulerControl1.GetService(Of ISchedulerCommandFactoryService)()
            Dim cmd As SchedulerCommand = service.CreateCommand(SchedulerCommandId.SwitchToGroupByResource)
            Dim menuItemCommandAdapter As New SchedulerMenuItemCommandWinAdapter(cmd)
            Dim menuItem As DXMenuItem = CType(menuItemCommandAdapter.CreateMenuItem(DXMenuItemPriority.Normal), DXMenuItem)
            menuItem.BeginGroup = True
            e.Menu.Items.Add(menuItem)

            ' Insert a new item into the Scheduler popup menu and handle its click event.
            e.Menu.Items.Add(New SchedulerMenuItem("Δημιουργία Απολύμανσης", AddressOf MyClickHandler))
        ElseIf e.Menu.Id = DevExpress.XtraScheduler.SchedulerMenuItemId.AppointmentMenu Then
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu)
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.EditSeries)
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu)
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.DeleteAppointment)
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.OpenAppointment)
            e.Menu.Items.Add(New SchedulerMenuItem("Διαγραφή", AddressOf SetApolAsDeleted))
            e.Menu.Items.Add(New SchedulerMenuItem("Ορισμός ως Εκτελεσμένη", AddressOf SetApolAsCompleted))
            e.Menu.Items.Add(New SchedulerMenuItem("Ορισμός ως Ακυρωμένη", AddressOf SetApolAsCanceled))
            'e.Menu.Items.Item(SchedulerMenuItemId.DeleteAppointment).Enabled = True
        End If
    End Sub
    Private Sub SetApolAsDeleted(ByVal sender As Object, ByVal e As EventArgs)
        DeleteApol()
    End Sub
    Private Sub SetApolAsCanceled(ByVal sender As Object, ByVal e As EventArgs)
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να ακυρωθεί η τρέχουσα εγγραφή? " & vbCrLf &
                               "Προσοχή θα διαγραφεί και η είσπραξη που αφορά την εργασία και θα επηρεάσει το ταμείο σας.", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                For i As Integer = 0 To SchedulerControl1.SelectedAppointments.Count - 1

                    Dim apol As Appointment = SchedulerControl1.SelectedAppointments(i)
                    sSQL = "UPDATE APOL SET cancelled=1 WHERE ID = " & toSQLValueS(apol.Id)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                    sSQL = "DELETE FROM COL_EXT WHERE APOLID = " & toSQLValueS(apol.Id)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                Next i
                SetCalendarFilter()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub SetApolAsCompleted(ByVal sender As Object, ByVal e As EventArgs)
        Dim sSQL As String
        Try
            If XtraMessageBox.Show("Θέλετε να ορισθεί εκτελεσμένη η τρέχουσα εγγραφή? ", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                For i As Integer = 0 To SchedulerControl1.SelectedAppointments.Count - 1

                    Dim apol As Appointment = SchedulerControl1.SelectedAppointments(i)
                    sSQL = "UPDATE APOL SET completed=1 WHERE ID = " & toSQLValueS(apol.Id)
                    Using oCmd As New SqlCommand(sSQL, CNDB)
                        oCmd.ExecuteNonQuery()
                    End Using
                Next i
                SetCalendarFilter()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), "PRIAMOS .NET", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub MyClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        Dim form1 As frmApol = New frmApol()
        form1.Text = "Απολυμάνσεις"
        form1.Scroller = frmScroller.GridView1
        form1.FormScroller = frmScroller
        form1.FormScrollerExist = False
        form1.MdiParent = frmMain
        If SchedulerControl1.SelectedAppointments.Count = 0 Then
            form1.Mode = FormMode.NewRecord
            form1.dtEdt.EditValue = SchedulerControl1.SelectedInterval.Start
            form1.tmIN.EditValue = CDate(SchedulerControl1.SelectedInterval.Start.ToString).ToString("HH:mm")
            form1.tmOUT.EditValue = CDate(SchedulerControl1.SelectedInterval.Start.ToString).ToString("HH:mm")
        End If
        frmMain.XtraTabbedMdiManager1.Float(frmMain.XtraTabbedMdiManager1.Pages(form1), New Point(CInt(form1.Parent.ClientRectangle.Width / 2 - form1.Width / 2), CInt(form1.Parent.ClientRectangle.Height / 2 - form1.Height / 2)))
        form1.Show()

    End Sub

    Private Sub BBrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBrefresh.ItemClick
        SetCalendarFilter()
    End Sub
    Private Sub SetCalendarFilter(Optional ByVal sWhere As String = "")
        Dim sSQL As String
        Dim sIDS As New StringBuilder
        SchedulerDataStorage1.Appointments.Clear()
        sSQL = "SELECT * FROM vw_APOL "
        If sWhere.Length > 0 Then sSQL = sSQL & " where workshopid=  " & toSQLValueS(sWhere)
        For i As Integer = 0 To cboCompleted.Items.Count - 1
            If cboCompleted.Items(i).CheckState = CheckState.Checked Then
                If sIDS.Length > 0 Then sIDS.Append(",")
                sIDS.Append(toSQLValueS(cboCompleted.Items(i).Tag.ToString))
            End If

        Next
        If sIDS.Length > 0 And sWhere.Length > 0 Then
            sSQL = sSQL + " and completed in (" & sIDS.ToString & ")"
        ElseIf sIDS.Length > 0 Then
            sSQL = sSQL + " where completed in (" & sIDS.ToString & ")"
        End If
        Calendar.Initialize(SchedulerControl1, SchedulerDataStorage1, sSQL, False)
        SchedulerControl1.Start = Now.Date
    End Sub
    Private Sub OkButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        SetCalendarFilter()
    End Sub
    Private Sub OkComletedButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        SetCalendarFilter()
    End Sub

    Private Sub cboCompleted_Popup(sender As Object, e As EventArgs) Handles cboCompleted.Popup
        Dim edit = TryCast(sender, CheckedComboBoxEdit)
        Dim form = edit.GetPopupEditForm()
        RemoveHandler form.OkButton.Click, AddressOf OkComletedButton_Click
        AddHandler form.OkButton.Click, AddressOf OkComletedButton_Click

    End Sub

    Private Sub cboWorkshop_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboWorkshop.ButtonClick
        Select Case e.Button.Index
            Case 1 : bWorkshop.EditValue = Nothing
            Case 2
            Case 3
        End Select
    End Sub

    Private Sub cboWorkshop_EditValueChanged(sender As Object, e As EventArgs) Handles cboWorkshop.EditValueChanged
        Dim value As Object = (TryCast(sender, LookUpEdit)).EditValue
        Dim teText As String = If(value Is Nothing, String.Empty, value.ToString())
        SetCalendarFilter(teText)
    End Sub

    Private Sub SchedulerControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles SchedulerControl1.KeyDown
        If e.KeyCode = Keys.Delete Then DeleteApol()
    End Sub
    Private Function DeleteApol() As Boolean
        Dim sSQL As String
        If XtraMessageBox.Show("Θέλετε να διαγραφεί η τρέχουσα εγγραφή? " & vbCrLf &
                               "Προσοχή θα διαγραφεί και η είσπραξη που αφορά την εργασία και θα επηρεάσει το ταμείο σας.", "PRIAMOS .NET", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            For i As Integer = 0 To SchedulerControl1.SelectedAppointments.Count - 1

                Dim apol As Appointment = SchedulerControl1.SelectedAppointments(i)
                sSQL = "DELETE FROM APOL WHERE ID = " & toSQLValueS(apol.Id)
                Using oCmd As New SqlCommand(sSQL, CNDB)
                    oCmd.ExecuteNonQuery()
                End Using
            Next i
            SetCalendarFilter()
            DeleteApol = True
        Else
            DeleteApol = False
        End If
    End Function

    Private Sub SchedulerDataStorage1_AppointmentDeleting(sender As Object, e As PersistentObjectCancelEventArgs) Handles SchedulerDataStorage1.AppointmentDeleting
        If DeleteApol() = False Then e.Cancel = True
    End Sub

    Public Class MySchedulerLocalizer
        Inherits SchedulerLocalizer
        Public Overrides Function GetLocalizedString(ByVal id As SchedulerStringId) As String
            Select Case id
                Case SchedulerStringId.FlyoutCaption_Location : Return "Συνεργείο:"
                Case SchedulerStringId.FlyoutCaption_Start : Return "Από:"
                Case SchedulerStringId.FlyoutCaption_End : Return "Έως:"
                Case SchedulerStringId.FlyoutCaption_Reminder : Return "Υπενθύμιση:"
            End Select
            Return MyBase.GetLocalizedString(id)
        End Function
    End Class
End Class