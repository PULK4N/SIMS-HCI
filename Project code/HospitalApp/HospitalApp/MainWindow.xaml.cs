using HospitalApp.Model;
using HospitalApp.Service;
using HospitalApp.View;
using MahApps.Metro.Controls;
using System.Threading;
using System.Windows;

namespace HospitalApp
{

    public partial class MainWindow : MetroWindow
    {
        Doctor ActiveDoctor;
        public Patient Patient { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Map.Instantiate();
            this.DataContext = this;
        }


        #region MainCanvasReg

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            RegisteredUser registeredUser = Map.LoginController.Login(LoginUsername.Text, LoginPassword.Password);
            if(registeredUser != null)
            {
                switch (registeredUser.UserType)
                {
                    case Enums.UserType.PATIENT:
                        Patient = Map.PatientController.GetPatientByUsername(registeredUser.Username);
                        LoginGrid.Visibility = Visibility.Hidden;
                        PatientWindow patientWindow = new PatientWindow(Patient);
                        patientWindow.Show();
                        ScheduleReminders();
                        break;
                    case Enums.UserType.DOCTOR:
                        ActiveDoctor = Map.DoctorController.GetByUsername(registeredUser.Username);
                        long docId = ActiveDoctor.DoctorId;
                        var s = new DoctorWindow(docId);
                        s.Show();
                        break;

                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }

        }

        private void ScheduleReminders()
        {
            foreach(Reminder reminder in Map.ReminderController.GetAllByPatientId(Patient.PatientId))
            {
                Map.ReminderSchedulingService.ScheduleReminder(reminder);
            }
        }
        #endregion

 

    }
}
