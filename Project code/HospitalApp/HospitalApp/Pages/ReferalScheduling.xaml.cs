using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HospitalApp.Pages
{
    /// <summary>
    /// Interaction logic for ReferalScheduling.xaml
    /// </summary>
    public partial class ReferalScheduling : Page
    {
        public ObservableCollection<Appointment> AppointmentsToSchedule { get; set; }


        public ReferalScheduling()
        {
            InitializeComponent();
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            AppointmentsToSchedule.Clear();
            SchedulingInformation schedulingInformation = new SchedulingInformation()
            {
                TimeIntervalBeginning = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + ScheduleFrom.Text),
                TimeIntervalEnd = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + ScheduleTo.Text),
                PatientSchedulingPriority = (bool)radioDoctor.IsChecked ? Enums.PatientSchedulingPriority.DOCTOR : Enums.PatientSchedulingPriority.DATE_TIME,
                //Patient = this.Patient,
                //Room = this.Room,
                Doctor = (Doctor)DoctorPicker.SelectedItem
            };
            if (DateTime.Now > schedulingInformation.TimeIntervalBeginning)
            {
                MessageBox.Show("Can't schedule appointment in the past");
            }
            else
            {
                GetMyAppointments(schedulingInformation);
            }
        }

        private void GetMyAppointments(SchedulingInformation schedulingInformation)
        {
            var (appointmentList, priorityUsed) = Map.SchedulingService.GetAppointments(schedulingInformation);
            if (priorityUsed) MessageBox.Show("Priority was used");
            foreach (Appointment appointment in appointmentList)
            {
                AppointmentsToSchedule.Add(appointment);
            }
        }
        private void confirmSchedule(object sender, RoutedEventArgs e)
        {
            Appointment appointment = ((Appointment)dataGridAppointments.SelectedItem);
            Map.AppointmentController.PatientScheduleAppointment(appointment);
            AppointmentsToSchedule.Clear();
        }
    }
}
