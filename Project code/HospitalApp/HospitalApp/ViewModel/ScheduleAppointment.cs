using HospitalApp.Model;
using HospitalApp.Service;
using System.Collections.ObjectModel;

namespace HospitalApp.ViewModel
{
    class ScheduleAppointment : ViewModel 
    {

        public ScheduleAppointment() : base()
        {
            Initialize();
        }

        private void Initialize()
        {
            Doctors = new ObservableCollection<Doctor>(Map.DoctorController.GetAll());
            RecommendedAppointments = new ObservableCollection<Appointment>();
        }

        public ObservableCollection<Doctor> Doctors { get; set; }
        private ObservableCollection<Appointment> recommendedAppointments;
        public ObservableCollection<Appointment> RecommendedAppointments
        {
            get
            {
                return recommendedAppointments;
            }

            set
            {
                recommendedAppointments = value;
                OnPropertyChanged();
            }
        }


        public void GetMyAppointments(SchedulingInformation schedulingInformation)
        {
            var (appointmentList, priorityUsed) = Map.SchedulingService.GetAppointments(schedulingInformation);
            RecommendedAppointments.Clear();
            foreach (Appointment appointment in appointmentList)
            {
                RecommendedAppointments.Add(appointment);
            }
        }

        public void confirmSchedule(Appointment appointment)
        {
            Map.AppointmentController.PatientScheduleAppointment(appointment);
            RecommendedAppointments.Clear();
        }

    }
}
