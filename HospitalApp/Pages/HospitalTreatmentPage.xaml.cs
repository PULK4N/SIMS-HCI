using HospitalApp.Model;
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

namespace HospitalApp.Pages
{
    /// <summary>
    /// Interaction logic for HospitalTreatmentPage.xaml
    /// </summary>
    public partial class HospitalTreatmentPage : Page
    {
        private Patient thisPatient;
        private HospitalTreatment HospitalTreatment;
        public ObservableCollection<Room> TreatmentRoomsView { get; set; }
        public ObservableCollection<Bed> BedsFromRoomView { get; set; }
        public HospitalTreatmentPage(Patient ThisPatient)
        {
            BedsFromRoomView = new ObservableCollection<Bed>();

            InitializeComponent();

            this.DataContext = this;

            thisPatient = ThisPatient;

            GenerateRoomsList();

            UpdateHospitalTreatmentInfo();

        }

        private void GenerateRoomsList()
        {
            TreatmentRoomsView = new ObservableCollection<Room>();
            List<Room> AvailableRooms = Map.RoomController.GetAllAvailableForTreatment();
            foreach (Room r in AvailableRooms)
            {
                TreatmentRoomsView.Add(r);
            }
        }

        private void GenerateBedList()
        {
            Room selectedRoom = RoomsView.SelectedItem as Room;
            List<Bed> AllBeds = Map.BedController.GetGetAllWithRoomId(selectedRoom.RoomId);
            List<Bed> AvailableBeds = new List<Bed>();
            foreach (Bed b in AllBeds)
            {
                if (b.IsAvailable)
                    AvailableBeds.Add(b);
            }
            foreach(Bed b in AvailableBeds)
            {
                BedsFromRoomView.Add(b);
            }
        }

        private void RoomsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BedsFromRoomView.Clear();
            GenerateBedList();
        }

        private void ScheduleTreatment_Click(object sender, RoutedEventArgs e)
        {
            if (BeginDate.Text == "" || EndDate.Text == "" || RoomsView.SelectedItem == null || BedsView.SelectedItem == null)
                MessageBox.Show("Schedule failed, some are parameters missing");
            else
            {
                DateTime StartDate = DateTime.Parse(BeginDate.SelectedDate.Value.Date.ToString().Split(' ')[0]);
                DateTime FinnishDate = DateTime.Parse(EndDate.SelectedDate.Value.Date.ToString().Split(' ')[0]);
                Room selectedRoom = RoomsView.SelectedItem as Room;
                Bed selectedBed = BedsView.SelectedItem as Bed;
                Map.BedController.OccupyBed(selectedBed.BedId);

                HospitalTreatment newHospitalTreatment = new HospitalTreatment(StartDate, FinnishDate, Enums.HospitalTreatmentStatus.PENDING, thisPatient, selectedRoom, selectedBed);
                Map.HospitalTreatmentController.Create(newHospitalTreatment);

                MessageBox.Show("Hospital treatment successfully scheduled");

                UpdateHospitalTreatmentInfo();
            }
        }

        private void UpdateHospitalTreatmentInfo()
        {
            if(Map.HospitalTreatmentController.GetByPatientId(thisPatient.PatientId) != null)
            {
                HospitalTreatment ht = Map.HospitalTreatmentController.GetByPatientId(thisPatient.PatientId);
                BeginInfo.Text = ht.Beginning.Date.ToString().Split(' ')[0];
                EndInfo.Text = ht.End.Date.ToString().Split(' ')[0];
                RoomInfo.Text = ht.Room.ToString();
                BedInfo.Text = ht.Bed.ToString();
                ScheduleButton.IsEnabled = false;

                BeginDate.IsEnabled = false;
                EndDate.IsEnabled = false;
                RoomsView.IsEnabled = false;
                BedsView.IsEnabled = false;

                NewEndDatePicker.IsEnabled = true;
                ExtendTreatmentButton.IsEnabled = true;
            }
            else
            {
                NewEndDatePicker.IsEnabled = false;
                ExtendTreatmentButton.IsEnabled = false;
            }
        }

        private void ExtendTreatment_Click(object sender, RoutedEventArgs e)
        {
            if(NewEndDatePicker.Text != "")
            {
                DateTime newEnd = DateTime.Parse(NewEndDatePicker.SelectedDate.Value.Date.ToString().Split(' ')[0]);
                HospitalTreatment thisPatientsTreatment = Map.HospitalTreatmentController.GetByPatientId(thisPatient.PatientId);
                long hospitalTreatmentId = thisPatientsTreatment.TreatmentId;
                Map.HospitalTreatmentController.ExtendHospitalTreatment(hospitalTreatmentId, newEnd);
                MessageBox.Show("Hospital treatment successfully extended");
                UpdateHospitalTreatmentInfo();
            }
            MessageBox.Show("New date not selected");
        }
    }
}
