using HospitalApp.Model;
using HospitalApp.Observers;
using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.ViewModel
{
    public class Reminders : ViewModel, IObserveAppointments
    {
        public ObservableCollection<Reminder> RemindersOC { get; set; }
        public ObservableCollection<Appointment> CompletedAppointmentsNotReviewed { get; set; }
        public Reminders() : base()
        {
            RemindersOC = new ObservableCollection<Reminder>(Map.ReminderController.GetAllByPatientId(PatientWindow.Patient.PatientId));
            CompletedAppointmentsNotReviewed = new ObservableCollection<Appointment>(Map.AppointmentController.GetAllCompletedByPatientId(PatientWindow.Patient.PatientId));
        }

        public void UpdateAppointmentsView()
        {
            CompletedAppointmentsNotReviewed.Clear();
            foreach(Appointment appointment in Map.AppointmentController.GetAllCompletedByPatientId(PatientWindow.Patient.PatientId))
            {
                CompletedAppointmentsNotReviewed.Add(appointment);
            }
        }
    }
}
