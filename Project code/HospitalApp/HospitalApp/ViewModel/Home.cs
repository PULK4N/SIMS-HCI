using HospitalApp.Model;
using HospitalApp.View;
using System;
using System.Collections.ObjectModel;

namespace HospitalApp.ViewModel
{
    class Home : ViewModel
    {
        public Home() : base()
        {
            InstantiateAppointments();
            //CurrentPage.Frame.LayoutUpdated += (obj,sender) => refreshLists();

        }

        private void InstantiateAppointments()
        {
            ScheduledAppointments = new ObservableCollection<Appointment>(Map.AppointmentController.GetAllByPatientId(PatientWindow.Patient.PatientId));
            CompletedAppointments = new ObservableCollection<Appointment>(Map.AppointmentController.GetAllCompletedOrReviewedByPatient(PatientWindow.Patient.PatientId));
            Prescriptions = new ObservableCollection<Prescription>(Map.PrescriptionController.GetAllByPatientId(PatientWindow.Patient.PatientId));
        }

        private void refreshLists()
        {
            ScheduledAppointments.Clear();
            CompletedAppointments.Clear();
            Prescriptions.Clear();
            foreach(Appointment a in Map.AppointmentController.GetAllByPatientId(PatientWindow.Patient.PatientId))
            {
                ScheduledAppointments.Add(a);
            }

            foreach (Appointment a in Map.AppointmentController.GetAllCompletedOrReviewedByPatient(PatientWindow.Patient.PatientId))
            {
                CompletedAppointments.Add(a);
            }

            foreach (Prescription p in Map.PrescriptionController.GetAllByPatientId(PatientWindow.Patient.PatientId))
            {
                Prescriptions.Add(p);
            }

        }

        public ObservableCollection<Appointment> ScheduledAppointments { get; set; }
        public ObservableCollection<Appointment> CompletedAppointments { get; set; }
        public ObservableCollection<Prescription> Prescriptions { get; set; }


    }
}
