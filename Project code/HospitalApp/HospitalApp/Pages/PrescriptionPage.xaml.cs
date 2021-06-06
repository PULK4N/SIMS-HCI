using HospitalApp.Controller;
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

namespace HospitalApp.Pages
{
    /// <summary>
    /// Interaction logic for PrescriptionPage.xaml
    /// </summary>
    public partial class PrescriptionPage : Page
    {
        private bool requestStop = false;
        public Patient thisPatient { get; set; }
        public Frame mainFrame { get; set; }

        public long activeDoctorId;
        public PrescriptionPage(Patient patient, long doctorId, Frame MainFrame)
        {
            InitializeComponent();
            thisPatient = patient;
            mainFrame = MainFrame;
            activeDoctorId = doctorId;
        }

        private void CreatePrescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (Medicine.Text == "" || Dosage.Text == "" || Period.Text == "" || SelectPrescriptionTime.Text == "")
            {
                MessageBox.Show("Prescription failed, some inputs are missing");
            }
            else
            {
                string drug = Medicine.Text;
                if (isAlergicTo(drug))
                {
                    MessageBox.Show("This drug is not safe for the patient");
                }
                else
                {
                    Prescription newPrescription = new Prescription();
                    Drug newMedicine = Map.DrugController.GetByName(Medicine.Text);
                    newMedicine.Name = Medicine.Text;
                    newPrescription.Drug = newMedicine;
                    newPrescription.Dosage = int.Parse(Dosage.Text);
                    newPrescription.Usage = Usage.Text;
                    newPrescription.Date = SelectPrescriptionTime.Value.Value;
                    newPrescription.Period = Period.Text;
                    newPrescription.Doctor = Map.DoctorController.Get(activeDoctorId);
                    thisPatient.MedicalRecord.Anamnesis.AddPrescription(newPrescription);
                    Map.PrescriptionController.Create(newPrescription);
                    MessageBox.Show("Medicine successfully prescribed");
                    Medicine.Clear();
                    Dosage.Clear();
                    Usage.Text = "Usage details: ";
                    Period.Clear();
                }
            }
        }

        public bool isAlergicTo(string prescribedDrug)
        {
            List<string> myAllergies = GetPatientsAllergies();
            foreach(string s in myAllergies)
            {
                if (s == prescribedDrug)
                    return true;
            }
            return false;
        }

        private List<string> GetPatientsAllergies()
        {
            List<PatientAllergies> patientAllergies = new List<PatientAllergies>();
            patientAllergies = Map.PatientAllergiesController.GetAllByPatientId(thisPatient.PatientId);
            List<string> myAllergies = new List<string>();
            foreach (PatientAllergies pa in patientAllergies)
            {
                myAllergies.Add(pa.Allergies.AllergieType);
            }
            return myAllergies;
        }

        private async void Demo_Click(object sender, RoutedEventArgs e)
        {
            Medicine.IsReadOnly = true;
            Dosage.IsReadOnly = true;
            Period.IsReadOnly = true;
            Usage.IsReadOnly = true;
            SelectPrescriptionTime.IsReadOnly = true;
            DemoPlayingText.Visibility = Visibility.Visible;

            requestStop = false;

            StopButton.Visibility = Visibility.Visible;
            DemoButton.Visibility = Visibility.Hidden;
            while (true)
            {
                Medicine.Text = "";
                Dosage.Text = "";
                Period.Text = "";
                Usage.Text = "Usage details:\n";
                SelectPrescriptionTime.Text = "";
                await Task.Delay(1100);

                if (requestStop)
                {
                    Medicine.IsReadOnly = false;
                    Dosage.IsReadOnly = false;
                    Period.IsReadOnly = false;
                    Usage.IsReadOnly = false;
                    SelectPrescriptionTime.IsReadOnly = false;
                    break;
                }

                Medicine.Text = "Probiotik";
                await Task.Delay(1000);
                Dosage.Text = "400";
                await Task.Delay(1000);
                Period.Text = "7";
                await Task.Delay(1000);
                SelectPrescriptionTime.Text = DateTime.Now.ToString().Split(' ')[0];
                await Task.Delay(1000);
                Usage.Text = "Usage details:\n\nInstructions on how to use the drug safely";
                await Task.Delay(2000);
                CreatePrescriptionButton.Background = Brushes.LightSkyBlue;
                await Task.Delay(40);
                CreatePrescriptionButton.Background = Brushes.White;

            }
            DemoStoppingText.Visibility = Visibility.Hidden;
            DemoButton.Visibility = Visibility.Visible;
            StopButton.Visibility = Visibility.Hidden;
            StopButton.IsEnabled = true;
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            DemoPlayingText.Visibility = Visibility.Hidden;
            DemoStoppingText.Visibility = Visibility.Visible;
            requestStop = true;
            StopButton.IsEnabled = false;
        }
    }
}
