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
using System.Windows.Threading;

/// <summary>
/// Interaction logic for Doctor.xaml
/// </summary>
public partial class DoctorWindow : Window
{
    public static Frame mainFrame;

    public static long activeDoctorId;

    public bool isSubmitted = false;


    public DoctorWindow(long doctorId)
    {
        InitializeComponent();
        activeDoctorId = doctorId;
        mainFrame = MainFrame;

        mainFrame.Content = new HomePage(isSubmitted);

        DispatcherTimer LiveTime = new DispatcherTimer();
        LiveTime.Interval = TimeSpan.FromSeconds(1);
        LiveTime.Tick += timer_Tick;
        LiveTime.Start();
    }


    void timer_Tick(object sender, EventArgs e)
    {
        LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ScheduledAppointments scheduledAppointments = new ScheduledAppointments(activeDoctorId, mainFrame);
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

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        mainFrame.Content = new HomePage(isSubmitted);
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        if (mainFrame.NavigationService.CanGoBack)
            mainFrame.NavigationService.GoBack();
    }

    private void ForwardButton_Click(object sender, RoutedEventArgs e)
    {
        if (mainFrame.NavigationService.CanGoForward)
            mainFrame.NavigationService.GoForward();
    }

    private void Report_Click(object sender, RoutedEventArgs e)
    {
        DrugUsageReport drugUsageReport = new DrugUsageReport(activeDoctorId, this);
        mainFrame.Content = drugUsageReport;
    }
}
