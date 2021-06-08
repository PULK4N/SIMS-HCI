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
        public event VoidFuncNoParams RefreshAppointmentEventHandler;

        public void AddObserver(IObserveAppointments updateAppointments)
        {
            RefreshAppointmentEventHandler += updateAppointments.UpdateAppointmentsView;
        }

        public void RemoveObserver(IObserveAppointments updateAppointments)
        {
            RefreshAppointmentEventHandler -= updateAppointments.UpdateAppointmentsView;
        }

        public void NotifyObserver()
        {
            RefreshAppointmentEventHandler();
        }
    }
}
