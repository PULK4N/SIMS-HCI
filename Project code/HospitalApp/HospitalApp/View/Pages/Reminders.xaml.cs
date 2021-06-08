using HospitalApp.Model;
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
    /// Interaction logic for Reminders.xaml
    /// </summary>
    public partial class Reminders : Page
    {
        private ViewModel.Reminders RemindersVM;
        public Reminders(ViewModel.Reminders remindersViewModel)
        {
            InitializeComponent();
            RemindersVM = remindersViewModel;
            this.DataContext = RemindersVM;
            ListReminders();
            //ShowReviewsAndAppointments();
        }

        private void SubmitReminder(object sender, RoutedEventArgs e)
        {
            if (RemindersList.SelectedItem == null)
            {
                var RemindersTime = DateTime.Parse(DateTime.Now.Date.ToString().Split(' ')[0] + " " + ReminderTimePicker.Text);
                Map.ReminderController.Create(new Reminder(ReminderName.Text, RemindersTime, Int16.Parse(ReminderInterval.Text), ReminderPeriod.SelectedDate.Value, ReminderDescription.Text, PatientWindow.Patient));
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
            RemindersVM.RemindersOC.Clear();

            foreach (Reminder reminder in Map.ReminderController.GetAllByPatientId(PatientWindow.Patient.PatientId))
            {
                RemindersVM.RemindersOC.Add(reminder);
            }
        }

        private void reviewAppointment(object sender, RoutedEventArgs e)
        {
            var appointment = dataGridCompletedAppointments.SelectedItem as Appointment;
            appointment.AppointmentStatus = Enums.AppointmentStatus.REVIEWED;

            Review review = new Review((int)ReviewScore.SelectedItem, "no description", Enums.ReviewType.DOCTOR, appointment);//(int score, string comment, ReviewType reviewType, Appointment appointment)
            Map.ReviewController.Create(review);
            CurrentPage.AppointmentObservable.NotifyObserver();
        }
    }
}