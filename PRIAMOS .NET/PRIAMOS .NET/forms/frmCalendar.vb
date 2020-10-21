'Imports DevExpress.LookAndFeel
'Imports DevExpress.Skins
'Imports System
'Imports System.Drawing
'Imports DevExpress.XtraScheduler
'Imports DevExpress.XtraScheduler.Localization

Public Class frmCalendar
	'Inherits DevExpress.XtraEditors.XtraForm

	'Public Sub New()
	'	SchedulerLocalizer.Active = New MySchedulerLocalizer()
	'	InitializeComponent()
	'	AddHandler Me.schedulerControl1.AppointmentFlyoutShowing, AddressOf SchedulerControl1_AppointmentFlyoutShowing
	'End Sub
	'Private Sub SchedulerControl1_AppointmentFlyoutShowing(ByVal sender As Object, ByVal e As AppointmentFlyoutShowingEventArgs)
	'	'e.Control = new System.Windows.Forms.Control();
	'End Sub
End Class
Public Class MySchedulerLocalizer
	'Inherits SchedulerLocalizer
	'Public Overrides Function GetLocalizedString(ByVal id As SchedulerStringId) As String
	'	If id = SchedulerStringId.FlyoutCaption_Location Then
	'		Return "My text"
	'	End If
	'	Return MyBase.GetLocalizedString(id)
	'End Function
End Class