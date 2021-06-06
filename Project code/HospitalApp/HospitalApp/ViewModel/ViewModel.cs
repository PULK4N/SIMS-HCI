using ControlzEx.Theming;
using HospitalApp.View;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HospitalApp.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModel()
        {
            changeToHomeCommand = new RelayCommand(Executed_changeToHomeCommand, CanExecute_changeToHomeCommand);
            changeToAnamnesisCommand = new RelayCommand(Executed_changeToAnamnesisCommand, CanExecute_changeToAnamnesisCommand);
            changeToAppointmentsAndTherapyCommand = new RelayCommand(Executed_changeToAppointmentsAndTherapyCommand, CanExecute_changeToAppointmentsAndTherapyCommand);
            changeToPrescriptionsCommand = new RelayCommand(Executed_changeToPrescriptionsCommand, CanExecute_changeToPrescriptionsCommand);
            changeToRemindersCommand = new RelayCommand(Executed_changeToRemindersCommand, CanExecute_changeToRemindersCommand);
            changeToMedicalClinicsCommand = new RelayCommand(Executed_changeToMedicalClinicsCommand, CanExecute_changeToMedicalClinicsCommand);
            changeToDoctorsCommand = new RelayCommand(Executed_changeToDoctorsCommand, CanExecute_changeToDoctorsCommand);
            changeToHelpCommand = new RelayCommand(Executed_changeToHelpCommand, CanExecute_changeToHelpCommand);
            changeToSettingsCommand = new RelayCommand(Executed_changeToSettingsCommand, CanExecute_changeToSettingsCommand);
            changeToScheduleAppointmentCommand = new RelayCommand(Executed_changeToScheduleAppointmentCommand, CanExecute_changeToScheduleAppointmentCommand);
            logoutCommand = new RelayCommand(Executed_LogoutCommand, CanExecute_LogoutCommand);
            changeStyleCommand = new RelayCommand(Executed_ChangeStyleCommand, CanExecute_ChangeStyleCommand);
            changeLanguageCommand = new RelayCommand(Executed_ChangeLanguage, CanExecute_ChangeLanguage);
        }

        #region Commands

        #region Home Commands

        protected RelayCommand changeToHomeCommand;
        public RelayCommand ChangeToHomeCommand { get => changeToHomeCommand; set => changeToHomeCommand = value; }

        protected RelayCommand changeToAnamnesisCommand;
        public RelayCommand ChangeToAnamnesisCommand { get => changeToAnamnesisCommand; set => changeToAnamnesisCommand = value; }

        protected RelayCommand changeToAppointmentsAndTherapyCommand;
        public RelayCommand ChangeToAppointmentsAndTherapyCommand { get => changeToAppointmentsAndTherapyCommand; set => changeToAppointmentsAndTherapyCommand = value; }

        protected RelayCommand changeToPrescriptionsCommand;
        public RelayCommand ChangeToPrescriptionsCommand { get => changeToPrescriptionsCommand; set => changeToPrescriptionsCommand = value; }

        protected RelayCommand changeToRemindersCommand;
        public RelayCommand ChangeToRemindersCommand { get => changeToRemindersCommand; set => changeToRemindersCommand = value; }

        protected RelayCommand changeToMedicalClinicsCommand;
        public RelayCommand ChangeToMedicalClinicsCommand { get => changeToMedicalClinicsCommand; set => changeToMedicalClinicsCommand = value; }

        protected RelayCommand changeToDoctorsCommand;
        public RelayCommand ChangeToDoctorsCommand { get => changeToDoctorsCommand; set => changeToDoctorsCommand = value; }

        protected RelayCommand changeToHelpCommand;
        public RelayCommand ChangeToHelpCommand { get => changeToHelpCommand; set => changeToHelpCommand = value; }

        protected RelayCommand changeToScheduleAppointmentCommand;
        public RelayCommand ChangeToScheduleAppointmentCommand { get => changeToScheduleAppointmentCommand; set => changeToScheduleAppointmentCommand = value; }

        #endregion

        protected RelayCommand logoutCommand;
        public RelayCommand LogoutCommand { get => logoutCommand; set => logoutCommand = value; }

        protected RelayCommand changeToSettingsCommand;
        public RelayCommand ChangeToSettingsCommand { get => changeToSettingsCommand; set => changeToSettingsCommand = value; }

        protected RelayCommand changeStyleCommand;
        public RelayCommand ChangeStyleCommand { get => changeStyleCommand; set => changeStyleCommand = value; }

        protected RelayCommand changeLanguageCommand;
        public RelayCommand ChangeLanguageCommand { get => changeLanguageCommand; set => changeLanguageCommand = value; }


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
        //TO DO:
        public void Executed_LogoutCommand(object obj)
        {
            //CurrentPage.SetToSettings();
        }
        public bool CanExecute_LogoutCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------

        public void Executed_ChangeStyleCommand(object obj)
        {
            if (ThemeManager.Current.DetectTheme().Name.Equals("Dark.Blue"))
            {
                ThemeManager.Current.ChangeTheme(HospitalApp.App.Current, "Light.Blue");
            }
            else
            {
                ThemeManager.Current.ChangeTheme(HospitalApp.App.Current, "Dark.Blue");
            }
        }
        public bool CanExecute_ChangeStyleCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_ChangeLanguage(object obj)
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
        public bool CanExecute_ChangeLanguage(object obj)
        {
            return true;
        }
        #endregion
        
    }
}
