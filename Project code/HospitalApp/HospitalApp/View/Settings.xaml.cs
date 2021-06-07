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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalApp.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        private ViewModel.Settings ViewModelSettings;
        public Settings()
        {
            InitializeComponent();
            ViewModelSettings = new ViewModel.Settings();
            this.DataContext = ViewModelSettings;
        }

        private void CheckPassword(object sender, RoutedEventArgs e)
        {
            if(NewPassword.Password.Equals(RepeatPassword.Password) == false)
            {
                ViewModelSettings.PasswordError = "Passwords are different!";
            }
            else if (NewPassword.Password.Length < 8)
            {
                ViewModelSettings.PasswordError = "Passwords must have at least 8 chars!";
            }
            else
            {
                ViewModelSettings.PasswordError = "";
            }
        }
    }
}
