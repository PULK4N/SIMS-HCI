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
using System.Windows.Shapes;

namespace Hospital.Pages
{
    /// <summary>
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        public Patient()
        {
            InitializeComponent();
        }

private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new SchedulePage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewPage();
        }
    }
}
