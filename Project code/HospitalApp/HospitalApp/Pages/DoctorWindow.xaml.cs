<<<<<<< Updated upstream
﻿using System;
=======
﻿using HospitalApp.Model;
using HospitalApp.Pages;
using System;
>>>>>>> Stashed changes
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

    public static Doctor doctor;
    public DoctorWindow(long docId)
    {
        InitializeComponent();
<<<<<<< Updated upstream
        doctor = ControllerMapper.Instance.DoctorController.GetDoctorById(1);
=======
        doctor = Map.DoctorController.Get(docId);
>>>>>>> Stashed changes
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ScheduledAppointments scheduledAppointments = new ScheduledAppointments(doctor);
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
<<<<<<< Updated upstream
=======

    private void ReferalScheduling_Click(object sender, RoutedEventArgs e)
    {
        ReferalScheduling referalScheduling = new ReferalScheduling();
        MainFrame.Content = referalScheduling;
    }
>>>>>>> Stashed changes
}
