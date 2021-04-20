﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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


/// <summary>
/// Interaction logic for ScheduledAppointments.xaml
/// </summary>
public partial class ScheduledAppointments : Page
{
    private AppointmentController _appointmentController;
    private int colNum = 0;
    public static Patient patient;
    public static Appointment newAppointment;
    public ObservableCollection<Appointment> Appointments { get; set; }

    public ObservableCollection<Room> RoomsView { get; set; }

    public ObservableCollection<Patient> PatientsView { get; set; }

    public void UpdateAppointments()
    {
        List<Appointment> DoctorsAppointments = ControllerMapper.Instance.AppointmentController.DoctorListAppointments(DoctorWindow.doctor.DoctorId);
        Appointments.Clear();
        foreach (Appointment a in DoctorsAppointments)
            Appointments.Add(a);
    }

    public ScheduledAppointments()
    {
        InitializeComponent();

        this.DataContext = this;

        RoomsView = new ObservableCollection<Room>();
        List<Room> ListRoomRooms = ControllerMapper.Instance.RoomController.GetRooms();
        foreach (Room r in ListRoomRooms)
            RoomsView.Add(r);

        PatientsView = new ObservableCollection<Patient>();
        List<Patient> ListPatientPatients = ControllerMapper.Instance.PatientController.GetPatients();
        foreach (Patient p in ListPatientPatients)
            PatientsView.Add(p);

        Appointments = new ObservableCollection<Appointment>();
        UpdateAppointments();
    }

    private void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        colNum++;
        if (colNum == 3)
            e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        Appointment appointment = dataGridAppointments.SelectedItem as Appointment;
        ControllerMapper.Instance.AppointmentController.DoctorDeleteAppointment(appointment);
        Appointments.Remove(appointment);
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void ShowPatientButton_Click(object sender, RoutedEventArgs e)
    {
        patient = (dataGridAppointments.SelectedItem as Appointment).Patient;
        patient = ControllerMapper.Instance.PatientController.GetPatient(patient);
        var s = new ShowPatientPage();
        s.Show();
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {

    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        Enums.AppointmentType AppType;
        bool isChecked = (bool)Examination.IsChecked;
        if (isChecked)
            AppType = Enums.AppointmentType.MEDICAL_EXAMINATION;
        else
            AppType = Enums.AppointmentType.SURGERY;
        DateTime newAppointmentBegin = DateTime.Parse(AppointmentDate.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + BeginTime.Text);
        DateTime newAppointmentEnd = DateTime.Parse(AppointmentDate.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + EndTime.Text);
        
        newAppointment = new Appointment(newAppointmentBegin, newAppointmentEnd, AppType, Enums.AppointmentStatus.PENDING, PatientDropdown.SelectedItem as Patient, DoctorWindow.doctor, RoomDropdown.SelectedItem as Room);
        ControllerMapper.Instance.AppointmentController.DoctorCreateAppointment(newAppointment);
        Appointments.Add(newAppointment);

    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        Appointment appointment = dataGridAppointments.SelectedItem as Appointment;
        Enums.AppointmentType AppType;
        bool isChecked = (bool)Examination.IsChecked;
        if (isChecked)
            AppType = Enums.AppointmentType.MEDICAL_EXAMINATION;
        else
            AppType = Enums.AppointmentType.SURGERY;
        appointment.AppointmentType = AppType;
        appointment.Begining = DateTime.Parse(AppointmentDate.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + BeginTime.Text);
        appointment.End = DateTime.Parse(AppointmentDate.SelectedDate.Value.Date.ToString().Split(' ')[0] + " " + EndTime.Text);
        appointment.Patient = PatientDropdown.SelectedItem as Patient;
        appointment.Room = RoomDropdown.SelectedItem as Room;
        ControllerMapper.Instance.AppointmentController.DoctorUpdateAppointment(appointment);
        UpdateAppointments();
    }
}
