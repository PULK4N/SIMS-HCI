using HospitalApp.Model;
using MahApps.Metro.Controls;

namespace HospitalApp.View
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : MetroWindow
    {
        public static Patient Patient;
        public PatientWindow(Patient patient)
        {
            InitializeComponent();
            Patient = patient;
            CurrentPage.Frame = load_frame;
        }

    }
}
