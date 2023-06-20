Imports DevExpress.XtraScheduler.Localization
Public Class ScheduleGreekLocalizer
    Inherits SchedulerLocalizer

    Public Overrides ReadOnly Property Language() As String
        Get
            Return "Greek"
        End Get
    End Property
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
