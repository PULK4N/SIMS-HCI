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
        public ObservableCollection<Appointment> Appointments { get; set; }
        public ObservableCollection<Appointment> ReSchAppointments { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Appointments = new ObservableCollection<Appointment>();
            ReSchAppointments = new ObservableCollection<Appointment>();
            this.DataContext = this;
            //HospitalDB hospitalDB = new HospitalDB();
            //RegisteredUser tRegisterUser = new RegisteredUser { EncryptedID = "a121a", Username = "regUsernamae" };
            //User tUser = new User { FirstName = "QQQQ", LastName = "PuRRRps", RegisteredUser = tRegisterUser, DateOfBirth = new DateTime(2015, 12, 25,10,0,0), Address = "AA", EMail = "AA@A", Jmbg = 2122999812132, PhoneNumber = "11111111", RelationshipStatus = Enums.RelationshipStatus.DIVORCED, Sex = Enums.Sex.HERMAPHRODITE };
            //Patient patient = new Patient() { User = tUser };
            //hospitalDB.CreatePatient(patient);
            //List<Patient> patients = hospitalDB.GetAllPatients();

            //GetMyAppointments(new SchedulingInformation() { 
            //    TimeIntervalBeginning = new DateTime(2021,11,10,11,15,00),
            //    TimeIntervalEnd = new DateTime(2021, 11, 10, 12, 30, 00)
            //});;

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
            PatientSchedulingCanvas.Visibility = Visibility.Visible;

            //var s = new Hospital.Pages.Patient();
            //s.Show();
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
            //GetMyAppointments();

        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            SchedulingInformation schedulingInformation = new SchedulingInformation()
            {
                TimeIntervalBeginning = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + TimeInput.Text),
                TimeIntervalEnd = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + TimeInput.Text).AddHours(2),
                PatientSchedulingPriority = Enums.PatientSchedulingPriority.DATE_TIME
            };
            GetMyAppointments(schedulingInformation);
        }

        private void GetMyAppointments(SchedulingInformation schedulingInformation)
        {
            schedulingInformation.Doctor = ControllerMapper.Instance.DoctorController.GetDoctorById(1);


            var (appointmentList, priorityUsed) = SchedulingManager.GetAppointments(schedulingInformation);
            foreach (Appointment appointment in appointmentList)
            {
                Appointments.Add(appointment);
            }

            this.PatientSchedulingTime.Visibility = Visibility.Hidden;
            this.PatientListAppointments.Visibility = Visibility.Visible;
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
