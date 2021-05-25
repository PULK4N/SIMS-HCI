using Bolnica;
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
using System.Windows.Shapes;

namespace HospitalApp.Pages
{
    /// <summary>
    /// Interaction logic for ReferalSchedulingWindow.xaml
    /// </summary>
    public partial class ReferalSchedulingWindow : Window
    {
        public Patient thisPatient { get; set; }
        public Room thisRoom { get; set; }
        public ObservableCollection<Appointment> AppointmentsToSchedule { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Enums.Specialization> Specializations { get; set; }
        public ReferalSchedulingWindow(Patient patient)
        {
            InitializeComponent();
            this.DataContext = this;
            thisPatient = patient;
            thisRoom = Map.RoomController.Get(1);
            AppointmentsToSchedule = new ObservableCollection<Appointment>();
            Doctors = new ObservableCollection<Doctor>();
            Specializations = new ObservableCollection<Enums.Specialization>();
            GetDoctors();
            GetSpecializations();
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            AppointmentsToSchedule.Clear();
            SchedulingInformation schedulingInformation = new SchedulingInformation()
            {
                TimeIntervalBeginning = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + ScheduleFrom.Text),
                TimeIntervalEnd = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + ScheduleTo.Text),
                PatientSchedulingPriority = Enums.PatientSchedulingPriority.DOCTOR,
                Patient = thisPatient,
                Room = thisRoom,
                Doctor = (Doctor)DoctorPicker.SelectedItem
            };
            if (DateTime.Now > schedulingInformation.TimeIntervalBeginning)
            {
                MessageBox.Show("Can't schedule appointment in the past");
            }
            else
            {
                GetAppointments(schedulingInformation);
            }
        }

        private void GetAppointments(SchedulingInformation schedulingInformation)
        {
            var (appointmentList, priorityUsed) = Map.SchedulingService.GetAppointments(schedulingInformation);
            if (priorityUsed) MessageBox.Show("Priority was used");

            foreach (Appointment appointment in appointmentList)
            {
                AppointmentsToSchedule.Add(appointment);
            }
        }

        private void GetDoctors()
        {
            foreach (Doctor doctor in Map.DoctorController.GetAll())
            {
                Doctors.Add(doctor);
            }
        }
        private void GetSpecializations()
        {
            ReadOnlyCollection<Enums.Specialization> AllSpecializationValues 
            = Array.AsReadOnly((Enums.Specialization[])Enum.GetValues(typeof(Enums.Specialization)));
            foreach(Enums.Specialization spec in AllSpecializationValues)
            {
                Specializations.Add(spec);
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
