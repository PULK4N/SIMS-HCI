using Bolnica;
using HospitalApp.Model;
using HospitalApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;
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
/// Interaction logic for Doctor.xaml
/// </summary>
public partial class DoctorWindow : Window
{

    public static long activeDoctorId;
    public DoctorWindow(long doctorId)
    {
        InitializeComponent();
        activeDoctorId = doctorId;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ScheduledAppointments scheduledAppointments = new ScheduledAppointments(activeDoctorId);
        MainFrame.Content = scheduledAppointments;

    }

    private void Frame_Navigated(object sender, NavigationEventArgs e)
    {

    }

    private void ScheduledSurgeriesButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void CalendarButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void ValidateDrugs_Click(object sender, RoutedEventArgs e)
    {
        DrugValidation drugValidation = new DrugValidation();
        MainFrame.Content = drugValidation;
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        var s = new MainWindow();
        s.Show();
        this.Close();
    }
}
