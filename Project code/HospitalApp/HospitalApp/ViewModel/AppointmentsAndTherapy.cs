using Enums;
using HospitalApp.Model;
using HospitalApp.Observers;
using HospitalApp.View;
using System;
using System.Collections.ObjectModel;

namespace HospitalApp.ViewModel
{
    public class AppointmentsAndTherapy : ViewModel, IObserveAppointments
    {
        public AppointmentsAndTherapy() : base()
        {
            InstantiateAppointments();
        }
        private void InstantiateAppointments()
        {
            Appointments = new ObservableCollection<Appointment>(Map.AppointmentController.GetAllByPatientId(PatientWindow.Patient.PatientId));
            Therapy = new ObservableCollection<MedicalTreatment>();
            AppointmentsToBeRescheduled = new ObservableCollection<Appointment>();
            Doctors = new ObservableCollection<Doctor>(Map.DoctorController.GetAll());

            Therapy.Add(new MedicalTreatment(1, Enums.MedicalTreatementPeriod.EVERY_DAY, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-10),
                "Phasellus finibus dignissim placerat. Praesent egestas risus in vehicula sollicitudin. Quisque sodales aliquet imperdiet. Nullam a consequat quam. Pellentesque dictum tristique odio, in bibendum libero venenatis a. Donec quis sem rutrum, imperdiet turpis vitae, sollicitudin nulla. Ut in felis auctor, viverra mauris in, ullamcorper sapien. Phasellus ut auctor diam. Phasellus lobortis at augue nec eleifend. Integer venenatis risus mauris, sit amet interdum purus commodo id. Vivamus non odio mauris. Ut ultrices mattis elit, et mattis nunc varius ut."));
            
            Therapy.Add(new MedicalTreatment(1, Enums.MedicalTreatementPeriod.ONCE_A_WEEK, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-10),
                "Donec eget tellus scelerisque, pharetra leo vel, tincidunt arcu. Mauris gravida dui non arcu sodales, elementum varius velit aliquam. Fusce porttitor leo id ex euismod aliquet. Nullam euismod nisi vel sapien vehicula, sed semper magna fringilla. Integer condimentum, velit vitae finibus sollicitudin, odio velit pellentesque risus, ac molestie est justo sed massa. Curabitur id bibendum sem. Fusce lacinia vehicula diam quis scelerisque."));

            Therapy.Add(new MedicalTreatment(1, Enums.MedicalTreatementPeriod.EVERY_DAY, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-10),
                "Nullam nec facilisis est. Donec rutrum varius odio. Integer rutrum, lacus eu hendrerit tristique, lectus ex fermentum est, id volutpat mauris dui et metus. Maecenas et mollis enim. Mauris accumsan eros faucibus risus laoreet sodales. Nunc aliquet facilisis felis quis suscipit. Pellentesque at porttitor neque. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos."));
            Therapy.Add(new MedicalTreatment(1, Enums.MedicalTreatementPeriod.THREE_TIMES_A_WEEK, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-10),
                "Suspendisse in tortor vel eros vulputate hendrerit. Proin placerat nisi finibus sem aliquet porta. Proin ornare, magna nec fermentum tempor, urna ante porttitor nibh, id rutrum turpis neque ac orci. Duis in vestibulum mauris. Etiam commodo, massa vitae rhoncus commodo,"));

            createWeeklyLog();
        }

        private void createWeeklyLog()
        {
            therapyWeeklyLog = "";
            foreach(var t in Therapy)
            {
                if(DateTime.Now.AddDays(-7).CompareTo(t.Beginning)<0 && DateTime.Now.CompareTo(t.Beginning)>0)
                    therapyWeeklyLog += t.ToString();
            }
        }

        private string therapyWeeklyLog;
        public string TherapyWeeklyLog { get => therapyWeeklyLog; set { therapyWeeklyLog = value; OnPropertyChanged(); } }

        public ObservableCollection<Appointment> Appointments { get; set; }
        public ObservableCollection<MedicalTreatment> Therapy { get; set; }
        public ObservableCollection<Appointment> AppointmentsToBeRescheduled { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }

        public void RefreshAppointments()
        {

        }

        public void UpdateAppointmentsView()
        {
            Appointments.Clear();
            foreach (Appointment appointment in Map.AppointmentController.GetAllByPatientId(PatientWindow.Patient.PatientId))
            {
                Appointments.Add(appointment);
            }
        }
    }
}
