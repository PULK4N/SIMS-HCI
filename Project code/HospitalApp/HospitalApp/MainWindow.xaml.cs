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

namespace Bolnica
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HospitalDB hospitalDB = new HospitalDB();
            RegisteredUser tRegisterUser = new RegisteredUser { encryptedID = "a121a",username = "regUsernamae" };
            User tUser = new User { firstName = "QQQQ", lastName = "PuRRRps", registeredUser = tRegisterUser, dateOfBirth = new DateTime(2015, 12, 25) };

            Patient patient = new Patient { user = tUser };
            hospitalDB.CreatePatient(patient);


            //List<Patient> patients = hospitalDB.GetAllPatients();
        }

        private void DoctorButton(object sender, RoutedEventArgs e)
        {
            var s = new Hospital.Pages.Doctor();
            s.Show();
        }

        private void SecretaryButton(object sender, RoutedEventArgs e)
        {
            var s = new Hospital.Pages.Secretary();
            s.Show();
        }

        private void PatientButton(object sender, RoutedEventArgs e)
        {
            var s = new Hospital.Pages.Patient();
            s.Show();
        }
    }
}
