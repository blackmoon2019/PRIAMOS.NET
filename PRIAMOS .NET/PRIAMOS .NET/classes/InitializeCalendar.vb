Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports DevExpress.Data.Async
Imports DevExpress.XtraEditors
Imports DevExpress.XtraScheduler


Public Class InitializeCalendar
    Public Sub Initialize(ByVal SCH As DevExpress.XtraScheduler.SchedulerControl, ByVal SCH_Storage As DevExpress.XtraScheduler.SchedulerDataStorage, ByVal sSQL As String, ByVal Reminder As Boolean)
        Dim sDate As String
        Dim sStatus As String
        Dim sReminder As Integer
        Dim sColor As Color
        Dim sStatusColor As Color
        Dim WorkshopCode As Integer
        Dim apolTypeName As String
        Dim SalersCode As Integer
        Dim sWorkshopName As String
        Dim sBdgName As String
        Dim sRemValues As String
        Dim sID As String
        Dim StartTime As String
        Dim EndTime As String
        Dim sCompleted As Boolean
        'Color.FromArgb(e.CellValue)
        'Αλλαγή όψης
        SCH.ActiveViewType = SchedulerViewType.FullWeek
        SCH.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None
        SCH.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None
        SCH.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None
        Dim cmd As SqlCommand = New SqlCommand(sSQL, CNDB)
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        If sdr.HasRows Then
            While sdr.Read()
                If sdr.IsDBNull(sdr.GetOrdinal("dtEDT")) = False Then sDate = sdr.GetDateTime(sdr.GetOrdinal("dtEDT"))
                If sdr.IsDBNull(sdr.GetOrdinal("bdgNam")) = False Then sBdgName = sdr.GetString(sdr.GetOrdinal("bdgNam"))
                sID = sdr.GetGuid(sdr.GetOrdinal("ID")).ToString
                If sdr.IsDBNull(sdr.GetOrdinal("color")) = False Then sColor = Color.FromArgb(sdr.GetInt32(sdr.GetOrdinal("color")))
                If sdr.IsDBNull(sdr.GetOrdinal("WorkshopName")) = False Then sWorkshopName = sdr.GetString(sdr.GetOrdinal("WorkshopName"))
                If sdr.IsDBNull(sdr.GetOrdinal("tmIn")) = False Then StartTime = sdr.GetString(sdr.GetOrdinal("tmIn"))
                If sdr.IsDBNull(sdr.GetOrdinal("tmOut")) = False Then EndTime = sdr.GetString(sdr.GetOrdinal("tmOut"))
                sRemValues = ""
                If sdr.IsDBNull(sdr.GetOrdinal("apolTypeName")) = False Then apolTypeName = sdr.GetString(sdr.GetOrdinal("apolTypeName"))
                If sdr.IsDBNull(sdr.GetOrdinal("code")) = False Then SalersCode = sdr.GetInt32(sdr.GetOrdinal("code"))
                If sdr.IsDBNull(sdr.GetOrdinal("WorkshopCode")) = False Then WorkshopCode = sdr.GetInt32(sdr.GetOrdinal("WorkshopCode"))
                If sdr.IsDBNull(sdr.GetOrdinal("completed")) = False Then sCompleted = sdr.GetBoolean(sdr.GetOrdinal("completed"))

                CreateAppointmentApol(sID, SCH_Storage, sDate, sStatus, sReminder, sColor, apolTypeName, WorkshopCode, sBdgName, sRemValues, StartTime, EndTime, sCompleted, sWorkshopName, Reminder)

            End While
        End If
        sdr.Close()
        sdr = Nothing
    End Sub
    Public Sub CreateAppointmentApol(ByVal ID As String, ByVal SCH_Storage As DevExpress.XtraScheduler.SchedulerDataStorage,
                                      ByVal AptDate As String, ByVal AptSubject As String, ByVal sReminder As Integer,
                                      ByVal sColor As Color, ByVal Cmt As String, ByVal sLabelID As Integer,
                                      ByVal sBdgName As String, ByVal sRemValues As String, ByVal AptStartTime As String, ByVal AptEndTime As String,
                                      ByVal Completed As Boolean, ByVal sWorkshopName As String, Optional ByVal EnableReminder As Boolean = False
                                      )
        Dim apt As Appointment = SCH_Storage.CreateAppointment(AppointmentType.Normal, CDate(AptDate), CDate(AptDate),
                                                               "Πολυκατοικία: " & sBdgName & vbCrLf & "Εργασία: " & Cmt)
        Try

            Dim Field As New DevExpress.XtraScheduler.Native.CustomField("StatusColor", sColor)

            apt.CustomFields.Add(Field)
            apt.Description = Cmt
            apt.Location = sWorkshopName
            'apt.AllDay = True
            If AptStartTime <> Nothing Then
                apt.Start = CDate(AptDate) & " " & AptStartTime
                '2/29/2016 22:00:00
                apt.End = CDate(AptDate) & " " & AptEndTime
            Else
                apt.Start = CDate(AptDate)
                apt.End = CDate(AptDate)
            End If
            ' Κλειδί
            apt.SetId(ID)
            apt.LabelKey = sLabelID

            'apt.RecurrenceInfo.Type = RecurrenceType.Daily
            'apt.RecurrenceInfo.Periodicity = 2
            'apt.RecurrenceInfo.Start = apt.Start
            'apt.RecurrenceInfo.Range = RecurrenceRange.OccurrenceCount
            'apt.RecurrenceInfo.OccurrenceCount = 5
            'apt.LabelKey = sLabelID

            If EnableReminder Then
                Dim reminder As Reminder = apt.CreateNewReminder()
                reminder.TimeBeforeStart = New TimeSpan(0, sReminder, 0)
                Select Case sRemValues
                    Case "Λεπτά" : reminder.TimeBeforeStart = TimeSpan.FromMinutes(sReminder)
                    Case "Ώρες" : reminder.TimeBeforeStart = TimeSpan.FromHours(sReminder)
                    Case "Μέρες" : reminder.TimeBeforeStart = TimeSpan.FromDays(sReminder)
                    Case "Εβδομάδες" : reminder.TimeBeforeStart = TimeSpan.FromDays(sReminder * 7)
                End Select
                If Completed = False Then
                    If sReminder <> 0 And sRemValues <> "" Then apt.Reminders.Add(reminder)
                End If
            End If
            SCH_Storage.Appointments.Add(apt)


            'Dim lbl = SCH_Storage.Appointments.Labels.CreateNewLabel("vi", "Very Important")
            'lbl.SetColor(sColor)
            'SCH_Storage.Appointments.Labels.Add(lbl)

            'Dim status = SCH_Storage.Appointments.Statuses.CreateNewStatus("vb", "Very Busy")
            'status.SetBrush(New HatchBrush(HatchStyle.ForwardDiagonal, sColor, sColor))
            'SCH_Storage.Appointments.Statuses.Add(status)

            'apt.StatusKey = "vb"
            'apt.LabelKey = "vi"
        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CreateAppointmentPersonal(ByVal ID As String, ByVal SCH_Storage As DevExpress.XtraScheduler.SchedulerDataStorage,
                                      ByVal AptDate As String, ByVal AptSubject As String, ByVal sReminder As Integer,
                                      ByVal sColor As Color, ByVal Cmt As String, ByVal sLabelID As Integer,
                                      ByVal sTitle As String, ByVal sRemValues As String, ByVal AptTime As String, ByVal Completed As Boolean,
                                       ByVal SalerName As String, Optional ByVal EnableReminder As Boolean = False
                                      )
        Dim apt As Appointment = SCH_Storage.CreateAppointment(AppointmentType.Normal, CDate(AptDate), CDate(AptDate), AptSubject & "(Θέμα: " & sTitle & ")")
        Try

            'Dim Field As New DevExpress.XtraScheduler.Native.CustomField("StatusColor", sColor)

            'apt.CustomFields.Add(Field)
            'apt.Location = sTitle
            apt.Description = Cmt

            apt.AllDay = True
            'If AptTime <> Nothing Then
            '    apt.Start = CDate(AptDate) & " " & AptTime
            '    '2/29/2016 22:00:00
            '    apt.End = CDate(AptDate) & " " & AptTime
            'Else
            '    apt.Start = CDate(AptDate)
            '    apt.End = CDate(AptDate)
            'End If
            ' Κλειδί
            apt.SetId(ID)
            apt.LabelKey = sLabelID

            'If EnableReminder Then
            '    Dim reminder As Reminder = apt.CreateNewReminder()
            '    reminder.TimeBeforeStart = New TimeSpan(0, sReminder, 0)
            '    Select Case sRemValues
            '        Case "Λεπτά" : reminder.TimeBeforeStart = TimeSpan.FromMinutes(sReminder)
            '        Case "Ώρες" : reminder.TimeBeforeStart = TimeSpan.FromHours(sReminder)
            '        Case "Μέρες" : reminder.TimeBeforeStart = TimeSpan.FromDays(sReminder)
            '        Case "Εβδομάδες" : reminder.TimeBeforeStart = TimeSpan.FromDays(sReminder * 7)
            '    End Select
            '    If Completed = False Then
            '        If sReminder <> 0 And sRemValues <> "" Then apt.Reminders.Add(reminder)
            '    End If
            'End If
            SCH_Storage.Appointments.Add(apt)


        Catch ex As Exception
            XtraMessageBox.Show(String.Format("Error: {0}", ex.Message), ProgProps.ProgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
