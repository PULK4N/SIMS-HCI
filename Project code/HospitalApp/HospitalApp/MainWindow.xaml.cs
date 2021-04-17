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

namespace Bolnica
{

    public partial class MainWindow : Window
    {
        private AppointmentController _appointmentController;
        public MainWindow()
        {
            InitializeComponent();

            //HospitalDB hospitalDB = new HospitalDB();
            //RegisteredUser tRegisterUser = new RegisteredUser { EncryptedID = "a121a", Username = "regUsernamae" };
            //User tUser = new User { FirstName = "QQQQ", LastName = "PuRRRps", RegisteredUser = tRegisterUser, DateOfBirth = new DateTime(2015, 12, 25,10,0,0), Address = "AA", EMail = "AA@A", Jmbg = 2122999812132, PhoneNumber = "11111111", RelationshipStatus = Enums.RelationshipStatus.DIVORCED, Sex = Enums.Sex.HERMAPHRODITE };
            //Patient patient = new Patient() { User = tUser };
            //hospitalDB.CreatePatient(patient);
            //List<Patient> patients = hospitalDB.GetAllPatients();

            GetMyAppointments();

        }

        private void DoctorButton(object sender, RoutedEventArgs e)
        {
            //var s = new HospitalApp.Pages.Doctor();
            //s.Show();
        }

        private void SecretaryButton(object sender, RoutedEventArgs e)
        {
            //var s = new HospitalApp.Pages.Secretary();
            //s.Show();
        }

        private void PatientButton(object sender, RoutedEventArgs e)
        {
            MainCanvas.Visibility = Visibility.Hidden;
            MainCanvas.IsEnabled = false;
            PatientSchedulingCanvas.Visibility = Visibility.Visible;
            PatientSchedulingCanvas.IsEnabled = true;

            //var s = new Hospital.Pages.Patient();
            //s.Show();
        }

        private void ScheduleAppointments(object sender, RoutedEventArgs e)
        {
            this.PatientSchedulingTime.Visibility = Visibility.Visible;
            this.PatientSchedulingTime.IsEnabled = true;
            this.PatientListAppointments.IsEnabled = false;
            this.PatientListAppointments.Visibility = Visibility.Hidden;
        }

        private void ViewScheduledAppointments(object sender, RoutedEventArgs e)
        {
            this.PatientSchedulingTime.Visibility = Visibility.Hidden;
            this.PatientSchedulingTime.IsEnabled = false;
            this.PatientListAppointments.IsEnabled = true;
            this.PatientListAppointments.Visibility = Visibility.Visible;
            //GetMyAppointments();

        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Begining = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + TimeInput.Text);
            appointment.AppointmentStatus = Enums.AppointmentStatus.PENDING;
            appointment.AppointmentType = Enums.AppointmentType.MEDICAL_EXAMINATION;
            appointment.End = appointment.Begining;
        }

        public ObservableCollection<Appointment> Appointments { get; set; }
        public ObservableCollection<Appointment> ReSchAppointments { get; set; }
        private void GetMyAppointments()
        {
            this.DataContext = this;
            Appointments = new ObservableCollection<Appointment>();
            //var aa = HospitalDB.Instance.DoctorListAppointments(1);
            _appointmentController = new AppointmentController(new AppointmentService(new AppointmentContextDB()));
            var appointmentList = _appointmentController.DoctorListAppointments(1);
            foreach (Appointment appointment in appointmentList)
            {
                Appointments.Add(appointment);
            }
            //Appointments.Add(new Appointment() { AppointmentId = 0, AppointmentStatus = Enums.AppointmentStatus.ACTIVE, AppointmentType = Enums.AppointmentType.MEDICAL_EXAMINATION, Doctor = null, Patient = null, Room = null, Begining = new DateTime(2015, 12, 25, 10, 0, 0), End = new DateTime(2015, 12, 25, 10, 0, 0) });
            //Appointments.Add(new Appointment() { AppointmentId = 0, AppointmentStatus = Enums.AppointmentStatus.ACTIVE, AppointmentType = Enums.AppointmentType.MEDICAL_EXAMINATION, Doctor = null, Patient = null, Room = null, Begining = new DateTime(2015, 12, 25, 10, 0, 0), End = new DateTime(2015, 12, 25, 10, 0, 0) });
            //Appointments.Add(new Appointment() { AppointmentId = 0, AppointmentStatus = Enums.AppointmentStatus.ACTIVE, AppointmentType = Enums.AppointmentType.MEDICAL_EXAMINATION, Doctor = null, Patient = null, Room = null, Begining = new DateTime(2015, 12, 25, 10, 0, 0), End = new DateTime(2015, 12, 25, 10, 0, 0) });
            //Appointments.Add(new Appointment() { AppointmentId = 0, AppointmentStatus = Enums.AppointmentStatus.ACTIVE, AppointmentType = Enums.AppointmentType.MEDICAL_EXAMINATION, Doctor = null, Patient = null, Room = null, Begining = new DateTime(2015, 12, 25, 10, 0, 0), End = new DateTime(2015, 12, 25, 10, 0, 0) });

        }


        //TODO
        private void deleteAppointment(object sender, RoutedEventArgs e)
        {
            
            Appointment appointment = dataGridAppointments.SelectedItem as Appointment;
            
            Appointments.Remove(appointment);
        }

        private void modifyAppointment(object sender, RoutedEventArgs e)
        {

        }

        private void reScheduleAppointment(object sender, RoutedEventArgs e)
        {
            Appointment appointment = dataGridReScheduledAppointments.SelectedItem as Appointment;
        }
    }
}
