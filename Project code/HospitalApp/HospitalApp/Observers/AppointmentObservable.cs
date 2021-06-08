using HospitalApp.Model;
using HospitalApp.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp
{
    public class AppointmentObservable
    {
        public delegate void VoidFuncNoParams();
        public event VoidFuncNoParams RefreshAppointmentEvent;

        public void AddObserver(IObserveAppointments updateAppointments)
        {
            RefreshAppointmentEvent += updateAppointments.UpdateAppointmentsView;
        }

        public void RemoveObserver(IObserveAppointments updateAppointments)
        {
            RefreshAppointmentEvent -= updateAppointments.UpdateAppointmentsView;
        }

        public void NotifyObserver()
        {
            RefreshAppointmentEvent();
        }
    }
}
