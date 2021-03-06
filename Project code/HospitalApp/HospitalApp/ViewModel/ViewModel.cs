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
            changeToWeeklyLogCommand = new RelayCommand(Executed_ChangeToWeeklyLogCommand, CanExecute_changeToWeeklyLogCommand);
            changeToHomeCommand = new RelayCommand(Executed_changeToHomeCommand, CanExecute_changeToHomeCommand);
            changeToAnamnesisCommand = new RelayCommand(Executed_changeToAnamnesisCommand, CanExecute_changeToAnamnesisCommand);
            changeToAppointmentsAndTherapyCommand = new RelayCommand(Executed_changeToAppointmentsAndTherapyCommand, CanExecute_changeToAppointmentsAndTherapyCommand);
            changeToRemindersCommand = new RelayCommand(Executed_changeToRemindersCommand, CanExecute_changeToRemindersCommand);
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

        protected RelayCommand changeToRemindersCommand;
        public RelayCommand ChangeToRemindersCommand { get => changeToRemindersCommand; set => changeToRemindersCommand = value; }

        protected RelayCommand changeToHelpCommand;
        public RelayCommand ChangeToHelpCommand { get => changeToHelpCommand; set => changeToHelpCommand = value; }

        protected RelayCommand changeToScheduleAppointmentCommand;
        public RelayCommand ChangeToScheduleAppointmentCommand { get => changeToScheduleAppointmentCommand; set => changeToScheduleAppointmentCommand = value; }

        protected RelayCommand changeToWeeklyLogCommand;
        public RelayCommand ChangeToWeeklyLogCommand { get => changeToWeeklyLogCommand; set => changeToWeeklyLogCommand = value; }

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
        public bool CanExecute_changeToAnamnesisCommand(object obj)
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
        public void Executed_changeToRemindersCommand(object obj)
        {
            CurrentPage.SetToReminders();
        }
        public bool CanExecute_changeToRemindersCommand(object obj)
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
        public bool CanExecute_changeToSettingsCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        public void Executed_ChangeToWeeklyLogCommand(object obj)
        {
            CurrentPage.SetToWeeklyLog();
        }
        public bool CanExecute_changeToWeeklyLogCommand(object obj)
        {
            return true;
        }
        //--------------------------------------------------------------
        //TO DO:
        public void Executed_LogoutCommand(object obj)
        {
            new MainWindow().Show();
            PatientWindow.Instance.CancellationTokenSource.Cancel();
            PatientWindow.Instance.Close();
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
