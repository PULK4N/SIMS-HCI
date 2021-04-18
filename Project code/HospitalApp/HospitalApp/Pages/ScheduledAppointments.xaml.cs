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

namespace Hospital.Pages
{
    /// <summary>
    /// Interaction logic for ScheduledAppointments.xaml
    /// </summary>
    public partial class ScheduledAppointments : Page
    {
        private int colNum = 0;
        public ObservableCollection<Appointment> Appointments
        {
            get;
            set;
        }
        public ScheduledAppointments()
        {
            InitializeComponent();
            this.DataContext = this;
            Appointments = new ObservableCollection<Appointment>();
            Appointments.Add(new Appointment() { AppointmentId = 0, AppointmentStatus = Enums.AppointmentStatus.ACTIVE, AppointmentType = Enums.AppointmentType.MEDICAL_EXAMINATION, Doctor = null, Patient = null, Room = null, Begining = new DateTime(2015, 12, 25, 10, 0, 0), End = new DateTime(2015, 12, 25, 10, 0, 0) });
            Appointments.Add(new Appointment() { AppointmentId = 0, AppointmentStatus = Enums.AppointmentStatus.ACTIVE, AppointmentType = Enums.AppointmentType.MEDICAL_EXAMINATION, Doctor = null, Patient = null, Room = null, Begining = new DateTime(2015, 12, 25, 10, 0, 0), End = new DateTime(2015, 12, 25, 10, 0, 0) });
            Appointments.Add(new Appointment() { AppointmentId = 0, AppointmentStatus = Enums.AppointmentStatus.ACTIVE, AppointmentType = Enums.AppointmentType.MEDICAL_EXAMINATION, Doctor = null, Patient = null, Room = null, Begining = new DateTime(2015, 12, 25, 10, 0, 0), End = new DateTime(2015, 12, 25, 10, 0, 0) });
            Appointments.Add(new Appointment() { AppointmentId = 0, AppointmentStatus = Enums.AppointmentStatus.ACTIVE, AppointmentType = Enums.AppointmentType.MEDICAL_EXAMINATION, Doctor = null, Patient = null, Room = null, Begining = new DateTime(2015, 12, 25, 10, 0, 0), End = new DateTime(2015, 12, 25, 10, 0, 0) });
        }

        private void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 3)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void obrisiStudenta(object sender, RoutedEventArgs e)
        {
            if (Appointments.Count > 0)
            {
                Appointments.RemoveAt(Appointments.Count - 1);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
