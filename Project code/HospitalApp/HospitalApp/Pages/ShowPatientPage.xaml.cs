using HospitalApp.Model;
using HospitalApp.Pages;
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
using System.Windows.Shapes;


/// <summary>
/// Interaction logic for ShowPatientPage.xaml
/// </summary>
public partial class ShowPatientPage : Window
{
    public Patient thisPatient { get; set; }
    public ShowPatientPage(Patient patient)
    {
        InitializeComponent();
        Ime.Text = ScheduledAppointments.patient.User.FirstName;
        Prezime.Text = ScheduledAppointments.patient.User.LastName;
        Bday.Text = ScheduledAppointments.patient.User.DateOfBirth.ToString();
        Sex.Text = ScheduledAppointments.patient.User.Sex.ToString();
        Adress.Text = ScheduledAppointments.patient.User.Address;
        Email.Text = ScheduledAppointments.patient.User.EMail;
        Phone.Text = ScheduledAppointments.patient.User.PhoneNumber;
        JMBG.Text = ScheduledAppointments.patient.User.Jmbg.ToString();
        Anamnesis.Text = ScheduledAppointments.patient.MedicalRecord.Anamnesis.Description;
        thisPatient = patient;
    }

    private void WritePrescriptionButton_Click(object sender, RoutedEventArgs e)
    {
        var s = new PrescriptionWindow(thisPatient);
        s.Show();
    }

    private void UpdateAnamnesisButton_Click(object sender, RoutedEventArgs e)
    {
        Anamnesis UpdatedAnamnesis = ScheduledAppointments.patient.MedicalRecord.Anamnesis;
        UpdatedAnamnesis.Description = Anamnesis.Text;
        Map.AnamnesisController.Update(UpdatedAnamnesis);
        //ControllerMaapper.Instance.AnamnesisController.UpdateAnamnesis(UpdatedAnamnesis);
    }

    private void Anamnesis_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Anamnesis_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    private void ReferalScheduling_Click(object sender, RoutedEventArgs e)
    {
        var s = new ReferalSchedulingWindow(thisPatient);
        s.Show();
    }

    private void HospitalTreatment_Click(object sender, RoutedEventArgs e)
    {
        var s = new HospitalTreatmentWindow(thisPatient);
        s.Show();
    }
}
