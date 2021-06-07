using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace HospitalApp.View
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        public static PatientWindow Instance;
        public static Patient Patient;

        public PatientWindow(Patient patient)
        {
            Instance = this;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            //Home = new Home(load_frame);
            //AppointmentsAndTherapy = new AppointmentsAndTherapy(load_frame);
            //Anamnesis = new Anamnesis(load_frame);
            //Prescriptions = new Prescriptions(load_frame);
            //Reminders = new Reminders(load_frame);
            //MedicalClinics = new MedicalClinics(load_frame);
            //Doctors = new Doctors(load_frame);
            //Help = new Help(load_frame);
            //ScheduleAppointment = new ScheduleAppointment(load_frame);
            //Settings = new Settings(load_frame);
        }

        private void InitializeImages()
        {
            //load_frame.Content = new Home();
            //load_frame.Content = new Home();
            //HeaderImage.Source = Directory.GetCurrentDirectory();
        }

    }
}
