using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static NotificationService notificationService { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }
        CancellationToken cancellationToken { get; set; }

        public PatientWindow(Patient patient)
        {
            Patient = patient;
            Instance = this;
            InitializeComponent();
            CurrentPage.Frame = load_frame;
            CancellationTokenSource = new CancellationTokenSource();
            cancellationToken = CancellationTokenSource.Token;
            notificationService = new NotificationService();
            notificationService.StartTimer(cancellationToken);
            Map.PatientController.StartWeeklyAttemptsRestarting(cancellationToken);
        }

    }
}
