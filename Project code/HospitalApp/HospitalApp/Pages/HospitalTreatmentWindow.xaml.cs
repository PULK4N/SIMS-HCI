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
using System.Windows.Shapes;

namespace HospitalApp.Pages
{
    /// <summary>
    /// Interaction logic for HospitalTreatmentWindow.xaml
    /// </summary>
    public partial class HospitalTreatmentWindow : Window
    {
        public Patient thisPatient { get; set; }
        public HospitalTreatmentWindow(Patient patient)
        {
            InitializeComponent();
            thisPatient = patient;
        }
    }
}
