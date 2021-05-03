using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class SchedulingManager
{
    private static void GenerateNewAppointments(List<Appointment> appointments, SchedulingInformation schedulingInformation)
    {
        //Appointments must be at 15min. difference, so we need to set first appointment to either 00,15,30 or 45
        DateTime firstAppointmentTime = schedulingInformation.TimeIntervalBeginning.AddMinutes(schedulingInformation.TimeIntervalBeginning.Minute % 15);
        //generate appointments
        while(firstAppointmentTime < schedulingInformation.TimeIntervalEnd)
        {
            appointments.Add(new Appointment(firstAppointmentTime, firstAppointmentTime.AddMinutes(15),0, 0, schedulingInformation.Patient, schedulingInformation.Doctor,  schedulingInformation.Room));
            firstAppointmentTime = firstAppointmentTime.AddMinutes(15);
        }
    }
    private static void RemoveOverlappingAppointments(List<Appointment> appointmentsToSchedule, List<Appointment> appointmentsToRemove)
    {
        foreach(Appointment appointment in appointmentsToRemove)
        {
            appointmentsToSchedule.Remove(appointment);
        }
    }
    private static bool isOverlapping(Appointment appointment, Appointment scheduledAppointment)
    {
        //see if appointments starts after or at the same time as already scheduled one
        if(appointment.Beginning.Date==scheduledAppointment.Beginning.Date && 
            appointment.Beginning.TimeOfDay >= scheduledAppointment.Beginning.TimeOfDay 
            //and see if it begings before appointment ended
            && appointment.Beginning.TimeOfDay < scheduledAppointment.End.TimeOfDay)
        {
            return true;
        }
        return false;
    }
    private static bool appointmentOverlapping(Appointment appointment, List<Appointment> alreadyScheduledAppointments)
    {
        foreach(Appointment scheduledAppointment in alreadyScheduledAppointments)
        {
            if (isOverlapping(appointment, scheduledAppointment))
            {
                return true;
            }
        }
        return false;
    }


    private static void filterUnavilableAppointments(List<Appointment> appointmentsToSchedule, List<Appointment>  alreadyScheduled)
    {
        List<Appointment> appointmentsToRemove = new List<Appointment>();
        foreach(Appointment appointment in appointmentsToSchedule)
        {
            if (appointmentOverlapping(appointment,alreadyScheduled))
            {
                appointmentsToRemove.Add(appointment);
            }
        }
        RemoveOverlappingAppointments(appointmentsToSchedule, appointmentsToRemove);
    }



    //return List of appointments and bool true if priority was used
    private static List<Appointment> GeneratePriorityScheduledAppointments(List<Appointment> appointmentsToSchedule, List<Doctor> doctors, SchedulingInformation schedulingInformation)
    {
        foreach(Doctor doctor in doctors)
        {
            List<Appointment> alreadyScheduled = ControllerMapper.Instance.AppointmentController.DoctorListAppointments(doctor.DoctorId);
            schedulingInformation.Doctor = doctor;
            GenerateNewAppointments(appointmentsToSchedule,schedulingInformation);
            filterUnavilableAppointments(appointmentsToSchedule, alreadyScheduled);
        }
        return appointmentsToSchedule;
    }
    private static void GenerateAppointmentsAtDifferentTime(List<Appointment> appointmentsToSchedule, List<Appointment> alreadyScheduled, SchedulingInformation schedulingInformation)
    {
        schedulingInformation.TimeIntervalBeginning = schedulingInformation.Doctor.Employee.BeginWorkingHours;
        schedulingInformation.TimeIntervalEnd = schedulingInformation.Doctor.Employee.EndWorkingHours;
        GenerateNewAppointments(appointmentsToSchedule, schedulingInformation);
        filterUnavilableAppointments(appointmentsToSchedule, alreadyScheduled);
    }
public static (List<Appointment>,bool) GetAppointments(SchedulingInformation schedulingInformation)
    {
        bool priorityApplied = false;
        List<Appointment> alreadyScheduled = ControllerMapper.Instance.AppointmentController.DoctorListAppointments(schedulingInformation.Doctor.DoctorId);
        List<Appointment> appointmentsToSchedule = new List<Appointment>();
        GenerateNewAppointments(appointmentsToSchedule,schedulingInformation);
        filterUnavilableAppointments(appointmentsToSchedule, alreadyScheduled);
        if(appointmentsToSchedule.Count() == 0)
        {
            priorityApplied = true;
            if (schedulingInformation.PatientSchedulingPriority == Enums.PatientSchedulingPriority.DATE_TIME)
            {
                List<Doctor> doctors = ControllerMapper.Instance.DoctorController.GetAllDoctors(Enums.Specialization.NONE);
                appointmentsToSchedule = GeneratePriorityScheduledAppointments(appointmentsToSchedule, doctors,schedulingInformation);
            }
            else
            {
                GenerateAppointmentsAtDifferentTime(appointmentsToSchedule,alreadyScheduled, schedulingInformation);
            }
        }

        return (appointmentsToSchedule, priorityApplied);
    }

    public static (List<Appointment>, bool) GetAppointmentsToReschedule(SchedulingInformation schedulingInformation)
    {
        bool priorityApplied = false;
        List<Appointment> alreadyScheduled = ControllerMapper.Instance.AppointmentController.DoctorListAppointments(schedulingInformation.Doctor.DoctorId);
        List<Appointment> appointmentsToSchedule = new List<Appointment>();
        GenerateNewAppointments(appointmentsToSchedule, schedulingInformation);
        return (appointmentsToSchedule,priorityApplied);
    }
    private static bool isMoreThan2DaysAppart(SchedulingInformation schedulingInformation)
    {//Ako je istog dana
        if(schedulingInformation.Appointment.Beginning.AddDays(2).CompareTo(schedulingInformation.TimeIntervalBeginning) > 0
            && schedulingInformation.Appointment.Beginning.AddDays(-2).CompareTo(schedulingInformation.TimeIntervalBeginning) < 0)
        {
            if(DateTime.Now.AddDays(1).CompareTo(schedulingInformation.TimeIntervalBeginning) < 0 )
                return false;
        }

        return true;
    }
    private static bool startsInLessThan24Hours(SchedulingInformation schedulingInformation)
    {
        if (DateTime.Now.Date == schedulingInformation.Appointment.Beginning.Date)
        {
            return true;
        }else if(DateTime.Now.Date == schedulingInformation.Appointment.Beginning.AddDays(1).Date)
        {//Starts in les than 24 hours if timeOfDay now is bigger than timeOfDay tomorrow appointment
            if (DateTime.Now.Date.TimeOfDay > schedulingInformation.Appointment.Beginning.TimeOfDay)
                return true;
        }
        return false;
    }

    public static bool canReschedule(SchedulingInformation schedulingInformation)
    {
        if (startsInLessThan24Hours(schedulingInformation)) return false;
        if (isMoreThan2DaysAppart(schedulingInformation)) return false;

        return true;
    }


    public static bool ReSchedulingInformationValid(SchedulingInformation schedulingInformation)
    {
        if(canReschedule(schedulingInformation))
        {
            return true;
        }
        
        return false;
    }
}

public partial class SchedulingInformation
{
    public Room Room { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public Enums.PatientSchedulingPriority PatientSchedulingPriority { get; set; }
    public DateTime TimeIntervalBeginning { get; set; }
    public DateTime TimeIntervalEnd { get; set; }
    public Appointment Appointment { get; set; }
}

