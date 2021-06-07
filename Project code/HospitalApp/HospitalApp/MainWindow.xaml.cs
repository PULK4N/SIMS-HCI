using HospitalApp.Model;
using HospitalApp.Service;
using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Bolnica
{

    public partial class MainWindow : Window
    {
        Doctor ActiveDoctor;
        CancellationTokenSource CancellationTokenSource { get; set; }
        CancellationToken cancellationToken { get; set; }
        public Patient Patient { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Map.Instantiate();
            this.DataContext = this;
            CancellationTokenSource = new CancellationTokenSource();
            cancellationToken = CancellationTokenSource.Token;
            Map.PatientController.StartWeeklyAttemptsRestarting(cancellationToken);
        }


        #region MainCanvasReg

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            RegisteredUser registeredUser = Map.LoginController.Login(LoginUsername.Text, LoginPassword.Text);
            if(registeredUser != null)
            {
                switch (registeredUser.UserType)
                {
                    case Enums.UserType.PATIENT:
                        Patient = Map.PatientController.GetPatientByUsername(registeredUser.Username);
                        LoginGrid.Visibility = Visibility.Hidden;
                        //PatientWindow patientWindow = new PatientWindow();
                        //patientWindow.Show();
                        new NotificationService().StartTimer(cancellationToken);
                        ScheduleReminders();
                        break;
                    case Enums.UserType.DOCTOR:
                        ActiveDoctor = Map.DoctorController.GetByUsername(registeredUser.Username);
                        long docId = ActiveDoctor.DoctorId;
                        var s = new DoctorWindow(docId);
                        s.Show();
                        this.Close();
                        break;

                }
                LoginGrid.Visibility = Visibility.Hidden;
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
