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


/// <summary>
/// Interaction logic for ShowPatientPage.xaml
/// </summary>
public partial class ShowPatientPage : Window
{
    public ShowPatientPage()
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
    }

    private void WritePrescriptionButton_Click(object sender, RoutedEventArgs e)
    {
        var s = new PrescriptionWindow();
        s.Show();
    }
}
