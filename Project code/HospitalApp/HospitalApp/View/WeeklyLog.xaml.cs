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

namespace HospitalApp.View
{
    /// <summary>
    /// Interaction logic for WeeklyLog.xaml
    /// </summary>
    public partial class WeeklyLog : Page
    {
        private ViewModel.AppointmentsAndTherapy AppointmentsAndTherapyViewModel;
        public WeeklyLog()
        {
            InitializeComponent();
            AppointmentsAndTherapyViewModel = new ViewModel.AppointmentsAndTherapy();
            this.DataContext = AppointmentsAndTherapyViewModel;
        }
    }
}
