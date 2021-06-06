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
    /// Interaction logic for PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        public Patient thisPatient { get; set; }
        public Frame mainFrame { get; set; }

        public long activeDoctorId;
        public PatientPage(Patient patient, long doctorId, Frame MainFrame)
        {
            InitializeComponent();
            Ime.Text = ScheduledAppointments.patient.User.FirstName;
            Prezime.Text = ScheduledAppointments.patient.User.LastName;
            Bday.Text = ScheduledAppointments.patient.User.DateOfBirth.ToString().Split(' ')[0];
            Sex.Text = ScheduledAppointments.patient.User.Sex.ToString();
            Adress.Text = ScheduledAppointments.patient.User.Address;
            Email.Text = ScheduledAppointments.patient.User.EMail;
            Phone.Text = ScheduledAppointments.patient.User.PhoneNumber;
            JMBG.Text = ScheduledAppointments.patient.User.Jmbg.ToString();
            Anamnesis.Text = ScheduledAppointments.patient.MedicalRecord.Anamnesis.Description;
            thisPatient = patient;
            mainFrame = MainFrame;
            activeDoctorId = doctorId;
        }

        private void WritePrescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionPage prescriptionPage = new PrescriptionPage(thisPatient, activeDoctorId, mainFrame);
            mainFrame.Content = prescriptionPage;
        }

        private void UpdateAnamnesisButton_Click(object sender, RoutedEventArgs e)
        {
            Anamnesis UpdatedAnamnesis = ScheduledAppointments.patient.MedicalRecord.Anamnesis;
            UpdatedAnamnesis.Description = Anamnesis.Text;
            Map.AnamnesisController.Update(UpdatedAnamnesis);
            //ControllerMaapper.Instance.AnamnesisController.UpdateAnamnesis(UpdatedAnamnesis);
        }

        private void Anamnesis_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Anamnesis_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ReferalScheduling_Click(object sender, RoutedEventArgs e)
        {
            ReferalSchedulingPage referalSchedulingPage = new ReferalSchedulingPage(thisPatient);
            mainFrame.Content = referalSchedulingPage;
        }

        private void HospitalTreatment_Click(object sender, RoutedEventArgs e)
        {
            HospitalTreatmentPage hospitalTreatmentPage = new HospitalTreatmentPage(thisPatient);
            mainFrame.Content = hospitalTreatmentPage;
        }
    }
}
