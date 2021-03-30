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
            //User tUser = new User { firstName = "Nika", lastName = "Pupa", registeredUser = tRegisterUser, dateOfBirth = new DateTime(2015, 12, 25) };

            //Patient patient = new Patient { user = tUser };
            //hospitalDB.CreatePatient(patient);
            //List<Patient> patients = hospitalDB.GetAllPatients();
        }

        private void OpenPatientWindow(object sender, RoutedEventArgs e)
        {
            PatientWindow objPatientWindow = new PatientWindow();
            this.Visibility = Visibility.Hidden;
            objPatientWindow.Show();
        }

        private void OpenSecretaryWindow(object sender, RoutedEventArgs e)
        {
            SecretaryWindow objSecretaryWindow = new SecretaryWindow();
            this.Visibility = Visibility.Hidden;
            objSecretaryWindow.Show();
        }
    }
}
