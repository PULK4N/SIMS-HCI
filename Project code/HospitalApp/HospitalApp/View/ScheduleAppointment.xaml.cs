using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HospitalApp.View
{
    /// <summary>
    /// Interaction logic for ScheduleAppointment.xaml
    /// </summary>
    public partial class ScheduleAppointment : Page
    {
        ViewModel.ScheduleAppointment ScheduleAppointmentViewModel;
        
        public ScheduleAppointment()
        {
            InitializeComponent();
            ScheduleAppointmentViewModel = new ViewModel.ScheduleAppointment();
            this.DataContext = ScheduleAppointmentViewModel;
        }

        private void TryToSchedule(object sender, RoutedEventArgs e)
        {

            var _TimeIntervalBeginning = DateTime.Parse(DateDate.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + StartTime.Text);
            var _TimeIntervalEnd = DateTime.Parse(DateDate.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + EndTime.Text);
            var _PatientSchedulingPriority = Priority.SelectedItem.ToString().Split(' ')[1].Equals("Doctor") || Priority.SelectedItem.ToString().Split(' ')[1].Equals("Doktor") ? Enums.PatientSchedulingPriority.DOCTOR : Enums.PatientSchedulingPriority.DATE_TIME;
                
            var _Patient = PatientWindow.Patient;
            var _Room = Map.RoomController.Get(1);
            var _Doctor = (Doctor)DoctorPicker.SelectedItem;

            SchedulingInformation schedulingInformation = new SchedulingInformation()
            {
                TimeIntervalBeginning = _TimeIntervalBeginning,
                TimeIntervalEnd = _TimeIntervalEnd,
                PatientSchedulingPriority = _PatientSchedulingPriority,

                Patient = _Patient,
                Room = _Room,
                Doctor = _Doctor
            };
            if (DateTime.Now > schedulingInformation.TimeIntervalBeginning)
            {
                MessageBox.Show("Can't schedule appointment in the past");
            }
            else
            {
                ScheduleAppointmentViewModel.GetMyAppointments(schedulingInformation);
            }
        }

        private void confirmSchedule(object sender, RoutedEventArgs e)
        {
            if (AppointmentsToScheduleDG.SelectedItem is Appointment appointment)
            {
                ScheduleAppointmentViewModel.confirmSchedule(appointment);
            }
            ViewModel.Home.RefreshAppointmentEventHandler.Invoke(null, null);
        }
    }
}
