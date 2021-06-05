using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;


namespace HospitalApp.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Home();
        }

        public void Language_selectionChanged(object sender, RoutedEventArgs e)
        {

            if (TranslationSource.Instance.CurrentCulture.Name.Equals("sr-Latn"))
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr-LATN");
            }
        }
    }
}
