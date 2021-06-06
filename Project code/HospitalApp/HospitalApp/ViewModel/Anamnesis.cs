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
        private string fullName;
        public string FullName { get => fullName; set {fullName = value; OnPropertyChanged(); } }

        private string sex;
        public string Sex { get => sex; set { sex = value; OnPropertyChanged(); } }

        private string maritalStatus;
        public string MaritalStatus { get => maritalStatus; set { maritalStatus = value; OnPropertyChanged(); } }

        private string anamnesisDescription;
        public string AnamnesisDescription { get => anamnesisDescription; set { anamnesisDescription = value; OnPropertyChanged(); } }

        private string height;
        public string Height { get => height; set { height = value; OnPropertyChanged(); }
}

        private string weight;
        public string Weight { get => weight; set { weight = value; OnPropertyChanged(); }
}

        private string prescriptionDesc;
        public string PrescriptionDesc { get => prescriptionDesc; set { prescriptionDesc = value; OnPropertyChanged(); } }

        private string drugName;
        public string DrugName { get => drugName; set { drugName = value; OnPropertyChanged(); } }


        private RelayCommand showPrescriptionCommand;
        public RelayCommand ShowPrescriptionCommand { get => showPrescriptionCommand; set => showPrescriptionCommand = value; }

        public ObservableCollection<Appointment> CompletedAppointments { get; set; }
        public ObservableCollection<Prescription> Prescriptions { get; set; }
        

        public Anamnesis() : base()
        {
            InstantiateData();
        }

        private void InstantiateData()
        {
            showPrescriptionCommand = new RelayCommand(Executed_showPrescriptionCommand, CanExecute_showPrescriptionCommand);

            AnamnesisDescription = PatientWindow.Patient.MedicalRecord.Anamnesis.Description;
            FullName = PatientWindow.Patient.User.FirstName + " " + PatientWindow.Patient.User.LastName;
            MaritalStatus = PatientWindow.Patient.User.MaritalStatus.ToString();
            Sex = PatientWindow.Patient.User.Sex.ToString();
            Height = PatientWindow.Patient.MedicalRecord.LastMesuredHeight.ToString() + " cm";
            Weight = PatientWindow.Patient.MedicalRecord.LastMesuredWeight.ToString() + " kg";
            CompletedAppointments = new ObservableCollection<Appointment>(Map.AppointmentController.GetAllCompletedOrReviewedByPatient(PatientWindow.Patient.PatientId));
            Prescriptions = new ObservableCollection<Prescription>(Map.PrescriptionController.GetAllByPatientId(PatientWindow.Patient.PatientId));
        }

        private void refreshData()
        {
            FullName = PatientWindow.Patient.User.FirstName + " " + PatientWindow.Patient.User.LastName;
            MaritalStatus = PatientWindow.Patient.User.MaritalStatus.ToString();
            Sex = PatientWindow.Patient.User.Sex.ToString();
            Height = PatientWindow.Patient.MedicalRecord.LastMesuredHeight.ToString() + " cm";
            Weight = PatientWindow.Patient.MedicalRecord.LastMesuredWeight.ToString() + " kg";
            CompletedAppointments.Clear();
            Prescriptions.Clear();

            foreach (Appointment a in Map.AppointmentController.GetAllCompletedOrReviewedByPatient(PatientWindow.Patient.PatientId))
            {
                CompletedAppointments.Add(a);
            }

            foreach (Prescription p in Map.PrescriptionController.GetAllByPatientId(PatientWindow.Patient.PatientId))
            {
                Prescriptions.Add(p);
            }

        }

        public void Executed_showPrescriptionCommand(object obj)
        {
            if(obj is Prescription p)
            {
                PrescriptionDesc = p.Drug.Details;
                DrugName = p.Drug.Name;
            }
            else
            {
                MessageBox.Show("Error, not a prescription object");
            }
        }
        public bool CanExecute_showPrescriptionCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
    }
}
