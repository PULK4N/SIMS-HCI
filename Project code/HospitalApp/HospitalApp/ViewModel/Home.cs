using Enums;
using HospitalApp.Model;
using HospitalApp.Observers;
using HospitalApp.View;
using System;
using System.Collections.ObjectModel;

namespace HospitalApp.ViewModel
{
    public class Home : ViewModel, IObserveAppointments
    {
        public ObservableCollection<Appointment> ScheduledAppointments { get; set; }
        public ObservableCollection<Appointment> CompletedAppointments { get; set; }
        public ObservableCollection<Prescription> Prescriptions { get; set; }
        public Home() : base()
        {
            InstantiateAppointments();
        }

        private void InstantiateAppointments()
        {
            ScheduledAppointments = new ObservableCollection<Appointment>(Map.AppointmentController.GetAllByPatientId(PatientWindow.Patient.PatientId));
            CompletedAppointments = new ObservableCollection<Appointment>(Map.AppointmentController.GetAllCompletedOrReviewedByPatient(PatientWindow.Patient.PatientId));
            Prescriptions = new ObservableCollection<Prescription>(Map.PrescriptionController.GetAllByPatientId(PatientWindow.Patient.PatientId));
        }

        public void UpdateAppointmentsView()
        {
            ScheduledAppointments.Clear();
            CompletedAppointments.Clear();

            foreach (Appointment a in Map.AppointmentController.GetAllByPatientId(PatientWindow.Patient.PatientId))
            {
                ScheduledAppointments.Add(a);
            }

            foreach (Appointment a in Map.AppointmentController.GetAllCompletedOrReviewedByPatient(PatientWindow.Patient.PatientId))
            {
                CompletedAppointments.Add(a);
            }
        }
    }
}
