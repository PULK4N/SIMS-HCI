﻿using System;
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

namespace Bolnica
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void OpenPatientWindow(object sender, RoutedEventArgs e)
        {
            PatientWindow objPatientWindow = new PatientWindow();
            this.Visibility = Visibility.Hidden;
            objPatientWindow.Show();
        }

        private void OpenSecretaryWindow(object sender, RoutedEventArgs e)
        {
            SecretaryWindow objSecretaryWindow = new SecretaryWindow();
            this.Visibility = Visibility.Hidden;
            objSecretaryWindow.Show();
        }
    }
}
