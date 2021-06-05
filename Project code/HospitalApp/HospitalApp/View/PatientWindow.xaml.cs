using MahApps.Metro.Controls;

namespace HospitalApp.View
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : MetroWindow
    {
        public PatientWindow()
        {
            InitializeComponent();
            CurrentPage.Frame = load_frame;
        }

    }
}
