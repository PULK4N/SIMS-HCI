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
        private Appointment appointmentToBeRescheduled { get; set; }
        public ObservableCollection<Appointment> AppointmentsToSchedule { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Appointment> ScheduledAppointments { get; set; }
        public ObservableCollection<Appointment> ReSchAppointments { get; set; }
        public ObservableCollection<Appointment> CompletedAppointmentsNotReviewed { get; set; }
        public ObservableCollection<Review> Reviews { get; set; }
        public ObservableCollection<string> ScoresOC { get; set; }
        public ObservableCollection<Reminder> Reminders { get; set; }
        public ObservableCollection<Prescription> Prescriptions { get; set; }
        public ObservableCollection<Appointment> SpecialAppointments { get; set; }
        public ObservableCollection<Referral> Referrals { get; set; }
        CancellationTokenSource CancellationTokenSource { get; set; }
        CancellationToken cancellationToken { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Map.Instantiate();
            InstantiateLists();
            this.DataContext = this;
            CancellationTokenSource = new CancellationTokenSource();
            cancellationToken = CancellationTokenSource.Token;
            Map.PatientController.StartWeeklyAttemptsRestarting(cancellationToken);
        }

        private void InstantiateLists()
        {
            LoginGrid.Visibility = Visibility.Visible;
            AppointmentsToSchedule = new ObservableCollection<Appointment>();
            ScheduledAppointments = new ObservableCollection<Appointment>();
            Reviews = new ObservableCollection<Review>();
            Reminders = new ObservableCollection<Reminder>();
            CompletedAppointmentsNotReviewed = new ObservableCollection<Appointment>();
            ReSchAppointments = new ObservableCollection<Appointment>();
            Doctors = new ObservableCollection<Doctor>();
            Prescriptions = new ObservableCollection<Prescription>();
            Referrals = new ObservableCollection<Referral>();
            SpecialAppointments = new ObservableCollection<Appointment>();
            Room = Map.RoomController.Get(1);
            ScoresOC = new ObservableCollection<string>();

            foreach (Doctor doctor in Map.DoctorController.GetAllBySpecialization(Enums.Specialization.NONE))
            {
                Doctors.Add(doctor);
            }

            for(int i=1; i <= 5; i++)
            {
                ScoresOC.Add(i.ToString());
            }
        }

        #region MedicalRecordReg

        private void addMedicalRecordData()
        {
            Prescriptions.Clear();
            Referrals.Clear();
            SpecialAppointments.Clear();

            CurrentPatientAnamensis.Text = Patient.MedicalRecord.Anamnesis.Description;
            PatientsSex.Text = Patient.User.Sex.ToString();
            PatientsMaritalStatus.Text = Patient.User.MaritalStatus.ToString();


            foreach (Appointment appointment in Map.AppointmentController.GetAllByPatientRefered(Patient.PatientId))
            {
                SpecialAppointments.Add(appointment);
            }

            foreach(Prescription prescription in Map.PrescriptionController.GetAllByPatientId(Patient.PatientId))
            {
                Prescriptions.Add(prescription);
            }

            foreach(Referral referal in Map.ReferralController.GetAllByPatientId(Patient.PatientId))
            {
                Referrals.Add(referal);
            }
        }

        #endregion

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
                        PatientSchedulingCanvas.Visibility = Visibility.Visible;
                        PatientWindow patientWindow = new PatientWindow();
                        patientWindow.Show();
                        new NotificationService().StartTimer(cancellationToken);
                        ScheduleReminders();
                        break;
                    case Enums.UserType.DOCTOR:
                        var d = Map.DoctorController.GetByUsername(registeredUser.Username);
                        var s = new DoctorWindow();
                        s.Show();
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

        #region PatientSchedulingCanvasReg
        private void EndNotifications(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource.Cancel();
        }

        private void ScheduleAppointments(object sender, RoutedEventArgs e)
        {
            this.MedicalRecordView.Visibility = Visibility.Hidden;
            this.PatientSchedulingTime.Visibility = Visibility.Visible;
            this.PatientReviews.Visibility = Visibility.Hidden;
            this.RemindersGrid.Visibility = Visibility.Hidden;
            this.PatientListAppointments.Visibility = Visibility.Hidden;
        }

        private void ViewScheduledAppointments(object sender, RoutedEventArgs e)
        {
            this.MedicalRecordView.Visibility = Visibility.Hidden;
            this.PatientSchedulingTime.Visibility = Visibility.Hidden;
            this.PatientReviews.Visibility = Visibility.Hidden;
            this.RemindersGrid.Visibility = Visibility.Hidden;
            this.PatientListAppointments.Visibility = Visibility.Visible;
            addPatientScheduledAppointments();
        }
        private void addPatientScheduledAppointments()
        {
            ScheduledAppointments.Clear();
            List<Appointment> appointments = Map.AppointmentController.GetAllByPatientId(Patient.PatientId);
            foreach(Appointment appointment in appointments)
            {
                ScheduledAppointments.Add(appointment);
            }
        }

        private void OpenReviews(object sender, RoutedEventArgs e)
        {
            this.MedicalRecordView.Visibility = Visibility.Hidden;
            this.PatientSchedulingTime.Visibility = Visibility.Hidden;
            this.PatientListAppointments.Visibility = Visibility.Hidden;
            this.RemindersGrid.Visibility = Visibility.Hidden;
            this.PatientReviews.Visibility = Visibility.Visible;
            ShowReviewsAndAppointments();

        }
        private void ViewReminders(object sender, RoutedEventArgs e)
        {
            this.MedicalRecordView.Visibility = Visibility.Hidden;
            this.PatientSchedulingTime.Visibility = Visibility.Hidden;
            this.PatientListAppointments.Visibility = Visibility.Hidden;
            this.PatientReviews.Visibility = Visibility.Hidden;
            this.RemindersGrid.Visibility = Visibility.Visible;

            ListReminders();
        }

        private void OpenMedicalRecords(object sender, RoutedEventArgs e)
        {
            this.PatientSchedulingTime.Visibility = Visibility.Hidden;
            this.PatientListAppointments.Visibility = Visibility.Hidden;
            this.PatientReviews.Visibility = Visibility.Hidden;
            this.RemindersGrid.Visibility = Visibility.Hidden;
            this.MedicalRecordView.Visibility = Visibility.Visible;
            
            addMedicalRecordData();
        }

        #endregion

        #region ReviewRegion

        private void ShowReviewsAndAppointments()
        {
            List<Appointment> appointments = Map.AppointmentController.GetAllCompletedByPatientId(1);
            List<Review> reviews = Map.ReviewController.GetAllByPatientId(1);

            CompletedAppointmentsNotReviewed.Clear();
            foreach (Appointment appointment in appointments)
            {
                CompletedAppointmentsNotReviewed.Add(appointment);
            }

            Reviews.Clear();
            foreach(Review review in reviews)
            {
                Reviews.Add(review);
            }
            if(Map.ReviewController.GetAllByClinicId(1) != null)
            {
                ReviewClinicComment.Text = Map.ReviewController.GetAllByClinicId(1).Comment;
            }

        }

        private void reviewAppointment(object sender, RoutedEventArgs e)
        {
            var appointment = dataGridCompletedAppointments.SelectedItem as Appointment;
            appointment.AppointmentStatus = Enums.AppointmentStatus.REVIEWED;
            
            string description = ReviewComment.Text;
            Review review = new Review((int)ReviewScore.SelectedItem, description,Enums.ReviewType.DOCTOR, appointment);//(int score, string comment, ReviewType reviewType, Appointment appointment)
            Map.ReviewController.Create(review);
            ShowReviewsAndAppointments();
        }

        private void reviewClinic(object sender, RoutedEventArgs e)
        {
            Review review = Map.ReviewController.GetAllByClinicId(1);
            if (review == null){
                review = new Review();
                review.Comment = ReviewClinicComment.Text;
                review.ReviewType = Enums.ReviewType.CLINIC;
                Map.ReviewController.Create(review);
            }
            else
            {
                review.Comment = ReviewClinicComment.Text;
                Map.ReviewController.Update(review);
            }
        }
        #endregion

        #region RemindersReg

        private void SubmitReminder(object sender, RoutedEventArgs e)
        {
            if(RemindersList.SelectedItem == null)
            {
                var RemindersTime = DateTime.Parse(DateTime.Now.Date.ToString().Split(' ')[0] + " " + ReminderTimePicker.Text);
                Map.ReminderController.Create(new Reminder(ReminderName.Text, RemindersTime, Int16.Parse(ReminderInterval.Text), ReminderPeriod.SelectedDate.Value, ReminderDescription.Text,Patient));
            }
            else
            {
                Reminder reminder = RemindersList.SelectedItem as Reminder;
                var RemindersTime = DateTime.Parse(DateTime.Now.Date.ToString().Split(' ')[0] + " " + ReminderTimePicker.Text);
                reminder.Name = ReminderName.Text;
                reminder.StartTime = RemindersTime;
                reminder.TimeInterval = Int16.Parse(ReminderInterval.Text);
                reminder.Description = ReminderDescription.Text;
                Map.ReminderController.Update(reminder);

            }
            ListReminders();
        }

        private void DeleteReminder(object sender, RoutedEventArgs e)
        {
            if (RemindersList.SelectedItem != null)
            {
                Map.ReminderController.Delete((RemindersList.SelectedItem as Reminder).ReminderId);    
            }
            ListReminders();
        }

        private void ListReminders()
        {
            Reminders.Clear();

            foreach (Reminder reminder in Map.ReminderController.GetAllByPatientId(Patient.PatientId))
            {
                Reminders.Add(reminder);
            }
        }

        #endregion

        #region ScheduleAppointmentReg
        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            AppointmentsToSchedule.Clear();
            SchedulingInformation schedulingInformation = new SchedulingInformation()
            {
                TimeIntervalBeginning = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + ScheduleFrom.Text),
                TimeIntervalEnd = DateTime.Parse(DateInput.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + ScheduleTo.Text),
                PatientSchedulingPriority = (bool)radioDoctor.IsChecked ? Enums.PatientSchedulingPriority.DOCTOR : Enums.PatientSchedulingPriority.DATE_TIME,
                Patient = this.Patient,
                Room = this.Room,
                Doctor = (Doctor)DoctorPicker.SelectedItem
            };
            if(DateTime.Now > schedulingInformation.TimeIntervalBeginning)
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
        #endregion

        #region RescheduleAppointmentReg
        private void deleteAppointment(object sender, RoutedEventArgs e)
        {
            
            Appointment appointment = dataGridScheduledAppointmentsAppointments.SelectedItem as Appointment;
            Map.AppointmentController.Delete(appointment.AppointmentId);
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
                    PatientSchedulingPriority = (bool)radioDoctor2.IsChecked ? Enums.PatientSchedulingPriority.DOCTOR : Enums.PatientSchedulingPriority.DATE_TIME,
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
            if (Map.SchedulingService.ReSchedulingInformationValid(schedulingInformation))
            {
                //dataGridScheduledAppointmentsAppointments
                var (appointmentList, priorityUsed) = Map.SchedulingService.GetAppointments(schedulingInformation);
                if (priorityUsed) MessageBox.Show("Priority was used");
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

        private void reScheduleAppointment(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)dataGridReScheduledAppointments.SelectedItem;
            if (appointment != null)
            {
                appointment.AppointmentId = appointmentToBeRescheduled.AppointmentId;
                Map.AppointmentController.PatientReScheduleAppointment(appointment);
                ReSchAppointments.Clear();
                addPatientScheduledAppointments();
            }    
        }
        #endregion

    }
}
