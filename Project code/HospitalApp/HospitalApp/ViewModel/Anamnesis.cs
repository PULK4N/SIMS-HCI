using ControlzEx.Theming;
using HospitalApp.Model;
using HospitalApp.View;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace HospitalApp.ViewModel
{
    class Anamnesis : ViewModel
    {
        public String FullName { get; set; }
        public String Sex { get; set; }
        public String MaritalStatus { get; set; }
        public String AnamnesisDescription { get; set; }
        public String Height { get; set; }

        public String Weight { get; set; }
        
        public ObservableCollection<Appointment> CompletedAppointments { get; set; }
        public Anamnesis() : base()
        {
            InstantiateData();
        }

        private void InstantiateData()
        {
            AnamnesisDescription = PatientWindow.Patient.MedicalRecord.Anamnesis.Description;
            FullName = PatientWindow.Patient.User.FirstName + " " + PatientWindow.Patient.User.LastName;
            MaritalStatus = PatientWindow.Patient.User.MaritalStatus.ToString();
            Sex = PatientWindow.Patient.User.Sex.ToString();
            Height = PatientWindow.Patient.MedicalRecord.LastMesuredHeight.ToString() + " cm";
            Weight = PatientWindow.Patient.MedicalRecord.LastMesuredWeight.ToString() + " kg";
            CompletedAppointments = new ObservableCollection<Appointment>(Map.AppointmentController.GetAllCompletedOrReviewedByPatient(PatientWindow.Patient.PatientId));
        }

        private void refreshData()
        {
            FullName = PatientWindow.Patient.User.FirstName + " " + PatientWindow.Patient.User.LastName;
            MaritalStatus = PatientWindow.Patient.User.MaritalStatus.ToString();
            Sex = PatientWindow.Patient.User.Sex.ToString();
            Height = PatientWindow.Patient.MedicalRecord.LastMesuredHeight.ToString() + " cm";
            Weight = PatientWindow.Patient.MedicalRecord.LastMesuredWeight.ToString() + " kg";
            CompletedAppointments.Clear();

            foreach (Appointment a in Map.AppointmentController.GetAllCompletedOrReviewedByPatient(PatientWindow.Patient.PatientId))
            {
                CompletedAppointments.Add(a);
            }

        }
    }
}
