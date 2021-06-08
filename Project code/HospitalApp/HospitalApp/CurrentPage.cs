using System.Windows;
using System.Windows.Controls;
using HospitalApp.View;

namespace HospitalApp
{
    public static class CurrentPage
    {
        private static Frame frame;
        public static Frame Frame
        {
            get { return frame; }
            set
            {
                frame = value;
                Initialize();
            } 
        }
        private static Home Home { get; set; }
        private static AppointmentsAndTherapy AppointmentsAndTherapy { get; set; }
        private static Anamnesis Anamnesis { get; set; }
        private static Reminders Reminders { get; set; }
        private static Help Help { get; set; }
        private static ScheduleAppointment ScheduleAppointment { get; set; }
        private static Settings Settings { get; set; }
        public static AppointmentObservable AppointmentObservable { get; set; }
        private static WeeklyLog WeeklyLog { get; set; }

        public static void Initialize()
        {
            AppointmentObservable = new AppointmentObservable();
            //instantiating classes that implement IUpdateAppointmentsView
            ViewModel.Home ViewModelHome = new ViewModel.Home();
            ViewModel.AppointmentsAndTherapy ViewModelppointmentsAndTherapy = new ViewModel.AppointmentsAndTherapy();
            ViewModel.Reminders ViewModelReminders = new ViewModel.Reminders();
            //Adding observers
            AppointmentObservable.AddObserver(ViewModelHome);
            AppointmentObservable.AddObserver(ViewModelppointmentsAndTherapy);
            AppointmentObservable.AddObserver(ViewModelReminders);

            Home = new Home(ViewModelHome);
            AppointmentsAndTherapy = new AppointmentsAndTherapy(ViewModelppointmentsAndTherapy);
            Anamnesis = new Anamnesis();
            Reminders = new Reminders(ViewModelReminders);
            Help = new Help();
            ScheduleAppointment = new ScheduleAppointment();
            Settings = new Settings();
            WeeklyLog = new WeeklyLog();

            SetToHome();
        }
    
        public static void SetToHome()
        {
            if(frame != null && Home != null)
            {
                frame.Content = Home;
            }
        }

        public static void SetToAnamnesis()
        {
            if (frame != null && Anamnesis != null)
            {
                frame.Content = Anamnesis;
            }
        }

        public static void SetToAppointmentsAndTherapy()
        {
            if (frame != null && AppointmentsAndTherapy != null)
            {
                frame.Content = AppointmentsAndTherapy;
            }
        }


        public static void SetToReminders()
        {
            if (frame != null && Reminders != null)
            {
                frame.Content = Reminders;
            }
        }


        public static void SetToHelp()
        {
            if (frame != null && Help != null)
            {
                frame.Content = Help;
            }
        }

        public static void SetToScheduleAppointment()
        {
            if (frame != null && ScheduleAppointment != null)
            {
                frame.Content = ScheduleAppointment;
            }
        }

        public static void SetToSettings()
        {
            if (frame != null && Settings != null)
            {
                frame.Content = Settings;
            }
        }

        public static void SetToWeeklyLog()
        {
            if (frame != null && Home != null)
            {
                frame.Content = WeeklyLog;
            }
        }
    }
}
