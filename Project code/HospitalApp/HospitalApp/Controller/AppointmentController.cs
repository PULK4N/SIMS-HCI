// File:    AppointmentController.cs
// Author:  Nikola
// Created: Wednesday, April 14, 2021 11:06:07 PM
// Purpose: Definition of Class AppointmentController

using System;
using System.Collections.Generic;

public class AppointmentController
{
    private readonly AppointmentService _appointmentService;

    public AppointmentController(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public bool DoctorCreateAppointment(DateTime begining, DateTime end, Enums.AppointmentStatus appointmentStatus, Enums.AppointmentType appointmentType)
    {
       throw new NotImplementedException();
    }
    
    public bool DoctorUpdateAppointment(DateTime begining, DateTime end, Enums.AppointmentStatus appointmentStatus, Enums.AppointmentType appointmentType)
    {
       throw new NotImplementedException();
    }
    
    public bool DoctorDeleteAppointment(Appointment appointment)
    {
       throw new NotImplementedException();
    }
    
    public List<Appointment> DoctorListAppointments(long doctorId)
    {
       throw new NotImplementedException();
    }
    
    public Appointment GetById(long id)
    {
       throw new NotImplementedException();
    }
    
    public bool PatientScheduleAppointment(Appointment appointment)
    {
       throw new NotImplementedException();
    }
    
    public bool PatientCancelAppointment(Appointment appointment)
    {
       throw new NotImplementedException();
    }
    
    public bool PatientReScheduleAppointment(Appointment appointment)
    {
       throw new NotImplementedException();
    }
    
    public List<Appointment> PatentListAppointments(long patientID)
    {
       throw new NotImplementedException();
    }
    
    public List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment)
    {
       throw new NotImplementedException();
    }
    
}