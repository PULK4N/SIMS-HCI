using HospitalApp.Model;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public interface ISchedulingService
    {
        (List<Appointment>, bool) GetAppointments(SchedulingInformation schedulingInformation);
        bool ReSchedulingInformationValid(SchedulingInformation schedulingInformation);

    }
}