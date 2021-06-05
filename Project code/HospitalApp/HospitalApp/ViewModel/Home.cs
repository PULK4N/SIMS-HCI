using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HospitalApp.ViewModel
{
    class Home : ViewModel
    {
        public Home()
        {
            changeToHomeCommand = new RelayCommand(Executed_changeToHomeCommand, CanExecute_changeToHomeCommand);
            changeToAnamnesisCommand = new RelayCommand(Executed_changeToAnamnesisCommand, CanExecute_changeToAnamnesisCommand);
            changeToAppointmentsAndTherapyCommand = new RelayCommand(Executed_changeToAppointmentsAndTherapyCommand, CanExecute_changeToAppointmentsAndTherapyCommand);
            changeToPrescriptionsCommand = new RelayCommand(Executed_changeToPrescriptionsCommand,CanExecute_changeToPrescriptionsCommand);
            changeToRemindersCommand = new RelayCommand(Executed_changeToRemindersCommand, CanExecute_changeToRemindersCommand);
            changeToMedicalClinicsCommand = new RelayCommand(Executed_changeToMedicalClinicsCommand, CanExecute_changeToMedicalClinicsCommand);
            changeToDoctorsCommand = new RelayCommand(Executed_changeToDoctorsCommand, CanExecute_changeToDoctorsCommand);
            changeToHelpCommand = new RelayCommand(Executed_changeToHelpCommand, CanExecute_changeToHelpCommand);
            changeToSettingsCommand = new RelayCommand(Executed_changeToSettingsCommand, CanExecute_changeToSettingsCommand);
            logoutCommand = new RelayCommand(Executed_LogoutCommand, CanExecute_LogoutCommand);
        }

        #region Commands

        #region Home Commands

        private RelayCommand changeToHomeCommand;
        public RelayCommand ChangeToHomeCommand { get => changeToHomeCommand; set => changeToHomeCommand = value; }

        private RelayCommand changeToAnamnesisCommand;
        public RelayCommand ChangeToAnamnesisCommand { get => changeToAnamnesisCommand; set => changeToAnamnesisCommand = value; }
        
        private RelayCommand changeToAppointmentsAndTherapyCommand;
        public RelayCommand ChangeToAppointmentsAndTherapyCommand { get => changeToAppointmentsAndTherapyCommand; set => changeToAppointmentsAndTherapyCommand = value; }
        
        private RelayCommand changeToPrescriptionsCommand;
        public RelayCommand ChangeToPrescriptionsCommand { get => changeToPrescriptionsCommand; set => changeToPrescriptionsCommand = value; }

        private RelayCommand changeToRemindersCommand;
        public RelayCommand ChangeToRemindersCommand { get => changeToRemindersCommand; set => changeToRemindersCommand = value; }

        private RelayCommand changeToMedicalClinicsCommand;
        public RelayCommand ChangeToMedicalClinicsCommand { get => changeToMedicalClinicsCommand; set => changeToMedicalClinicsCommand = value; }
        
        private RelayCommand changeToDoctorsCommand;
        public RelayCommand ChangeToDoctorsCommand { get => changeToDoctorsCommand; set => changeToDoctorsCommand = value; }

        private RelayCommand changeToHelpCommand;
        public RelayCommand ChangeToHelpCommand { get => changeToHelpCommand; set => changeToHelpCommand = value; }

        private RelayCommand changeToScheduleAppointmentCommand;
        public RelayCommand ChangeToScheduleAppointmentCommand { get => changeToScheduleAppointmentCommand; set => changeToScheduleAppointmentCommand = value; }

        #endregion

        private RelayCommand logoutCommand;
        public RelayCommand LogoutCommand { get => logoutCommand; set => logoutCommand = value; }

        private RelayCommand changeToSettingsCommand;
        public RelayCommand ChangeToSettingsCommand { get => changeToSettingsCommand; set => changeToSettingsCommand = value; }

        #endregion

        #region Executed and canExecute methods
        public void Executed_changeToHomeCommand(object obj)
        {
            CurrentPage.SetToHome();
        }
        public bool CanExecute_changeToHomeCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_changeToAnamnesisCommand(object obj)
        {
            CurrentPage.SetToAnamnesis();
        }
        public bool CanExecute_changeToSettingsCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_changeToAppointmentsAndTherapyCommand(object obj)
        {
            CurrentPage.SetToAppointmentsAndTherapy();
        }
        public bool CanExecute_changeToAppointmentsAndTherapyCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_changeToPrescriptionsCommand(object obj)
        {
            CurrentPage.SetToPrescriptions();
        }
        public bool CanExecute_changeToPrescriptionsCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_changeToRemindersCommand(object obj)
        {
            CurrentPage.SetToReminders();
        }
        public bool CanExecute_changeToRemindersCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_changeToMedicalClinicsCommand(object obj)
        {
            CurrentPage.SetToMedicalClinics();
        }
        public bool CanExecute_changeToMedicalClinicsCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_changeToDoctorsCommand(object obj)
        {
            CurrentPage.SetToDoctors();
        }
        public bool CanExecute_changeToDoctorsCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_changeToHelpCommand(object obj)
        {
            CurrentPage.SetToHelp();
        }
        public bool CanExecute_changeToHelpCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_changeToScheduleAppointmentCommand(object obj)
        {
            CurrentPage.SetToScheduleAppointment();
        }
        public bool CanExecute_changeToScheduleAppointmentCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_changeToSettingsCommand(object obj)
        {
            CurrentPage.SetToSettings();
        }
        public bool CanExecute_changeToAnamnesisCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------

        public void Executed_LogoutCommand(object obj)
        {
            CurrentPage.SetToSettings();
        }
        public bool CanExecute_LogoutCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        #endregion


        private void Language_selectionChanged(object sender, RoutedEventArgs e)
        {
            if (TranslationSource.Instance.CurrentCulture != null)
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
            else
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
        }
    }
}
