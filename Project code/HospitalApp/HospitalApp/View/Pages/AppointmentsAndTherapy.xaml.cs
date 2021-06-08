using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalApp.View
{
    /// <summary>
    /// Interaction logic for AppointmentsAndTherapy.xaml
    /// </summary>
    public partial class AppointmentsAndTherapy : Page
    {
        private ViewModel.AppointmentsAndTherapy AppointmentsAndTherapyViewModel;
        Appointment appointmentToBeRescheduled;
        public AppointmentsAndTherapy(ViewModel.AppointmentsAndTherapy appointmentsAndTherapy)
        {
            InitializeComponent();
            AppointmentsAndTherapyViewModel = appointmentsAndTherapy;
            this.DataContext = AppointmentsAndTherapyViewModel;
        }

        private void buttonDeleteApp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Appointment appointment = AppointmentsDataGrid.SelectedItem as Appointment;
                Map.AppointmentController.Delete(appointment.AppointmentId);
                CurrentPage.AppointmentObservable.NotifyObserver();
            }
            catch (Exception)
            {

            }
        }

        private void Confirm_Reschedule_button(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)ReScheduledAppointmentsDG.SelectedItem;
            if (appointment != null)
            {
                appointment.AppointmentId = appointmentToBeRescheduled.AppointmentId;
                Map.AppointmentController.PatientReScheduleAppointment(appointment);
                CurrentPage.AppointmentObservable.NotifyObserver();
                AppointmentsAndTherapyViewModel.AppointmentsToBeRescheduled.Clear();
            }
        }

        private void confirmIntervalReSchedule(object sender, RoutedEventArgs e)
        {
            Appointment appointment = ((Appointment)AppointmentsDataGrid.SelectedItem);
            if (appointment != null && DateDate.SelectedDate!=null)
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
                    Doctor = _Doctor,
                    Appointment = appointment
                };
                GetMyRescheduledAppointments(schedulingInformation);
                appointmentToBeRescheduled = appointment;
            }
        }

        private void GetMyRescheduledAppointments(SchedulingInformation schedulingInformation)
        {
            if (Map.SchedulingService.ReSchedulingInformationValid(schedulingInformation))
            {
                AppointmentsAndTherapyViewModel.AppointmentsToBeRescheduled.Clear();
                //dataGridScheduledAppointmentsAppointments
                var (appointmentList, priorityUsed) = Map.SchedulingService.GetAppointments(schedulingInformation);
                if (priorityUsed) MessageBox.Show("Priority was used");
                foreach (Appointment appointment in appointmentList)
                {
                    AppointmentsAndTherapyViewModel.AppointmentsToBeRescheduled.Add(appointment);
                }
            }
            else
            {
                MessageBox.Show("Error:\nYou can't reschedule an appointment");
            }
        }
    }
}
