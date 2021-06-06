using System.Windows;
using System.Windows.Controls;

namespace HospitalApp.View
{
    public static class CurrentPage
    {
        private static Frame frame;
        public static Frame Frame
        {
            get { return frame; }
            set
            {
                if (frame == null)
                {
                    frame = value;
                    Initialize();
                }
                else
                {
                    MessageBox.Show("You should not change frame refference");
                }
            } 
        }
        private static Home Home { get; set; }
        private static AppointmentsAndTherapy AppointmentsAndTherapy { get; set; }
        private static Anamnesis Anamnesis { get; set; }
        private static Prescriptions Prescriptions { get; set; }
        private static Reminders Reminders { get; set; }
        private static MedicalClinics MedicalClinics { get; set; }
        private static Doctors Doctors { get; set; }
        private static Help Help { get; set; }
        private static ScheduleAppointment ScheduleAppointment { get; set; }
        private static Settings Settings { get; set; }

        

        public static void Initialize()
        {
            Home = new Home();
            AppointmentsAndTherapy = new AppointmentsAndTherapy();
            Anamnesis = new Anamnesis();
            Prescriptions = new Prescriptions();
            Reminders = new Reminders();
            MedicalClinics = new MedicalClinics();
            Doctors = new Doctors();
            Help = new Help();
            ScheduleAppointment = new ScheduleAppointment();
            Settings = new Settings();

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

        public static void SetToPrescriptions()
        {
            if (frame != null && Prescriptions != null)
            {
                frame.Content = Prescriptions;
            }
        }

        public static void SetToReminders()
        {
            if (frame != null && Reminders != null)
            {
                frame.Content = Reminders;
            }
        }

        public static void SetToMedicalClinics()
        {
            if (frame != null && MedicalClinics != null)
            {
                frame.Content = MedicalClinics;
            }
        }

        public static void SetToDoctors()
        {
            if (frame != null && Doctors != null)
            {
                frame.Content = Doctors;
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
    }
}
