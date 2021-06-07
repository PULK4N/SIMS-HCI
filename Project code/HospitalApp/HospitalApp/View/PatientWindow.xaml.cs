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
            Patient = patient;
            Instance = this;
            InitializeComponent();
            CurrentPage.Frame = load_frame;
        }

    }
}
