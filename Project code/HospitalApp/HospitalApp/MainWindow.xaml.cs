using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Bolnica
{

    public partial class MainWindow : Window
    {
        private Appointment appointmentToBeRescheduled { get; set; }
        public ObservableCollection<Appointment> AppointmentsToSchedule { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Appointment> ScheduledAppointments { get; set; }
        public ObservableCollection<Appointment> ReSchAppointments { get; set; }
        CancellationTokenSource CancellationTokenSource { get; set; }
        CancellationToken cancellationToken { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InstantiateLists();
            this.DataContext = this;
            CancellationTokenSource = new CancellationTokenSource();
            cancellationToken = CancellationTokenSource.Token;
            
        }

        private void InstantiateLists()
        {
            AppointmentsToSchedule = new ObservableCollection<Appointment>();
            ScheduledAppointments = new ObservableCollection<Appointment>();
            ReSchAppointments = new ObservableCollection<Appointment>();
            Doctors = new ObservableCollection<Doctor>();
            Room = ControllerMapper.Instance.RoomController.GetRoom(1);
            Patient = ControllerMapper.Instance.PatientController.GetPatient(1);

            foreach (Doctor doctor in ControllerMapper.Instance.DoctorController.GetAllDoctors(Enums.Specialization.NONE))
            {
                Doctors.Add(doctor);
            }
        }

        private void DoctorButton(object sender, RoutedEventArgs e)
        {
            var s = new DoctorWindow();
            s.Show();
        }

        private void SecretaryButton(object sender, RoutedEventArgs e)
        {
            //var s = new HospitalApp.Pages.Secretary();
            //s.Show();
        }

        private void PatientButton(object sender, RoutedEventArgs e)
        {
            MainCanvas.Visibility = Visibility.Hidden;
            PatientSchedulingCanvas.Visibility = Visibility.Visible;
            
            
        }

        private void StartNotifications(object sender, RoutedEventArgs e)
        {
            new NotificationManager().StartTimer(cancellationToken);
        }

        private void EndNotifications(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource.Cancel();
        }

        private void ScheduleAppointments(object sender, RoutedEventArgs e)
        {
            this.PatientSchedulingTime.Visibility = Visibility.Visible;
            this.PatientListAppointments.Visibility = Visibility.Hidden;
        }

        private void ViewScheduledAppointments(object sender, RoutedEventArgs e)
        {
            this.PatientSchedulingTime.Visibility = Visibility.Hidden;
            this.PatientListAppointments.Visibility = Visibility.Visible;
            addPatientScheduledAppointments();
        }

        private void addPatientScheduledAppointments()
        {
            ScheduledAppointments.Clear();
            List<Appointment> appointments = ControllerMapper.Instance.AppointmentController.PatientListAppointments(Patient);
            foreach(Appointment appointment in appointments)
            {
                ScheduledAppointments.Add(appointment);
            }
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            SchedulingInformation schedulingInformation = new SchedulingInformation()
            {
                TimeIntervalBeginning = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + ScheduleFrom.Text),
                TimeIntervalEnd = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + ScheduleTo.Text),
                PatientSchedulingPriority = (bool)radioDoctor.IsChecked ? Enums.PatientSchedulingPriority.DOCTOR : Enums.PatientSchedulingPriority.DATE_TIME,
                Patient = this.Patient,
                Room = this.Room,
                Doctor = (Doctor)DoctorPicker.SelectedItem
            };
            GetMyAppointments(schedulingInformation);
        }

        private void GetMyAppointments(SchedulingInformation schedulingInformation)
        {
            var (appointmentList, priorityUsed) = SchedulingManager.GetAppointments(schedulingInformation);
            foreach (Appointment appointment in appointmentList)
            {
                AppointmentsToSchedule.Add(appointment);
            }
        }


        private void deleteAppointment(object sender, RoutedEventArgs e)
        {
            
            Appointment appointment = dataGridScheduledAppointmentsAppointments.SelectedItem as Appointment;
            ControllerMapper.Instance.AppointmentController.PatientCancelAppointment(appointment);
            ScheduledAppointments.Remove(appointment);
        }

        private void confirmIntervalReSchedule(object sender, RoutedEventArgs e)
        {
            Appointment appointment = ((Appointment)dataGridScheduledAppointmentsAppointments.SelectedItem);
            if (appointment != null)
            {
                SchedulingInformation schedulingInformation = new SchedulingInformation()
                {
                    Appointment = appointment,
                    TimeIntervalBeginning = DateTime.Parse(ReScheduleDate.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + reScheduleFrom.Text),
                    TimeIntervalEnd = DateTime.Parse(ReScheduleDate.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + reScheduleTo.Text),
                    PatientSchedulingPriority = Enums.PatientSchedulingPriority.DOCTOR,
                    Patient = this.Patient,
                    Room = this.Room,
                    Doctor = appointment.Doctor
                };
                GetMyRescheduledAppointments(schedulingInformation);
                appointmentToBeRescheduled = appointment;
            }
        }

        private void GetMyRescheduledAppointments(SchedulingInformation schedulingInformation)
        {
            if (SchedulingManager.ReSchedulingInformationValid(schedulingInformation))
            {
                //dataGridScheduledAppointmentsAppointments
                var (appointmentList, priorityUsed) = SchedulingManager.GetAppointmentsToReschedule(schedulingInformation);
                foreach (Appointment appointment in appointmentList)
                {
                    ReSchAppointments.Add(appointment);
                }
            }
            else
            {
                MessageBox.Show("Error:\nYou can't reschedule an appointment");
            }
        }
        private void confirmSchedule(object sender, RoutedEventArgs e)
        {
            Appointment appointment = ((Appointment)dataGridAppointments.SelectedItem);
            ControllerMapper.Instance.AppointmentController.PatientScheduleAppointment(appointment);
            AppointmentsToSchedule.Clear();
        }

        private void reScheduleAppointment(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)dataGridReScheduledAppointments.SelectedItem;
            if (appointment != null)
            {
                appointment.AppointmentId = appointmentToBeRescheduled.AppointmentId;
                ControllerMapper.Instance.AppointmentController.PatientReScheduleAppointment(appointment);
                ReSchAppointments.Clear();
                addPatientScheduledAppointments();
            }    
        }
    }
}
