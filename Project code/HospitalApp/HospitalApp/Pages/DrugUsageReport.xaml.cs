using HospitalApp.Adapter;
using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DrugUsageReport.xaml
    /// </summary>
    public partial class DrugUsageReport : Page
    {
        public DoctorWindow doctorWindow { get; set; }
        public long activeDoctorId;
        public ObservableCollection<Prescription> Prescriptions { get; set; }
        public DrugUsageReport(long doctorId, DoctorWindow doctorWindow)
        {
            InitializeComponent();

            this.doctorWindow = doctorWindow;

            activeDoctorId = doctorId;

            this.DataContext = this;

            Prescriptions = new ObservableCollection<Prescription>();
            //Prescription fake = new Prescription();
            //fake.Dosage = 420;
            //Prescriptions.Add(fake);
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (InputStartDate.Text == "" || InputEndDate.Text == "")
            {
                MessageBox.Show("Generation failed, time range missing");
            }
            else
            {
                UpdatePrescriptionsForReport();

                Doctor activeDoctor = Map.DoctorController.Get(activeDoctorId);
                DoctorName.Text = activeDoctor.Employee.User.FirstName + " " + activeDoctor.Employee.User.LastName;

                SubmissionDate.Text = DateTime.Now.ToString().Split(' ')[0];

                StartDateDisplay.Text = InputStartDate.SelectedDate.Value.Date.ToString().Split(' ')[0];
                EndDateDisplay.Text = InputEndDate.SelectedDate.Value.Date.ToString().Split(' ')[0];

                Save.IsEnabled = true;
            }
        }

        private void UpdatePrescriptionsForReport()
        {
            Prescriptions.Clear();
            List<Prescription> allPrescriptions = Map.PrescriptionController.GetAll();
            foreach (Prescription p in allPrescriptions)
            {
                if (p.HandoutDate >= InputStartDate.SelectedDate && p.HandoutDate <= InputEndDate.SelectedDate && p.Doctor.DoctorId == activeDoctorId)
                    Prescriptions.Add(p);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            doctorWindow.isSubmitted = true;
            MessageBox.Show("Report successfully saved");
            Save.IsEnabled = false;
        }

        private void CreateDocument_Click(object sender, RoutedEventArgs e)
        {
            SyncfusionPdfAdapter s = new SyncfusionPdfAdapter();
            //SyncfusionWordAdapter s = new SyncfusionWordAdapter();

            DocumentTypePicker(s);
        }

        void DocumentTypePicker(DocumentGeneratorInterface x)
        {
            x.CreateDocument(DocumentInput.Text);
        }
    }
}
