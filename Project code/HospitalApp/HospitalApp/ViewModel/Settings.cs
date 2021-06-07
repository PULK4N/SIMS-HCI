using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalApp.ViewModel
{
    class Settings : ViewModel  
    {
        private string newPassword;
        public string NewPassword { get => newPassword; set { newPassword = value; OnPropertyChanged(); } }

        private string repeatPassword;
        public string RepeatPassword { get => repeatPassword; set { repeatPassword = value; OnPropertyChanged(); }}
        
        private string feedback;
        public string Feedback { get => feedback; set { feedback = value; OnPropertyChanged(); } }

        private string passwordError;
        public string PasswordError { get { return passwordError; } set { OnPropertyChanged(); passwordError = value; } }


        public Settings() : base()
        {
            newPassword = "nova_lozinka";
            repeatPassword = "nova_lozinka";
            sendFeedbackCommand = new RelayCommand(Executed_SendFeedbackCommand, CanExecute_SendFeedbackCommand);
            changePasswordCommand = new RelayCommand(Executed_ChangePasswordCommand, CanExecute_ChangePasswordCommand);
        }
        private RelayCommand sendFeedbackCommand;
        public RelayCommand SendFeedbackCommand { get => sendFeedbackCommand; set => sendFeedbackCommand = value; }

        protected RelayCommand changePasswordCommand;
        public RelayCommand ChangePasswordCommand { get => changePasswordCommand; set => changePasswordCommand = value; }

        public void Executed_SendFeedbackCommand(object obj)
        {
            //CurrentPage.SetToHome();
        }
        public bool CanExecute_SendFeedbackCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_ChangePasswordCommand(object obj)
        {
            //passwordError = "";
        }
        public bool CanExecute_ChangePasswordCommand(object obj)
        {
            //if (newPassword.Equals(RepeatPassword) == false)
            //{
            //    PasswordError = "Passwords are different!";
            //    return false;
            //}
            //else if (newPassword.Length < 8)
            //{
            //    PasswordError = "Passwords must have at least 8 chars!";
            //    return false;
            //}
            return true;
        }
        //--------------------------------------------------------------
    }
}
