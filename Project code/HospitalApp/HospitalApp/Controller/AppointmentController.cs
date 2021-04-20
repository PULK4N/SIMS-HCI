// File:    AppointmentController.cs
// Author:  Nikola
// Created: Wednesday, April 14, 2021 11:06:07 PM
// Purpose: Definition of Class AppointmentController

using System;
using System.Collections.Generic;

public class AppointmentController
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public bool DoctorCreateAppointment(Appointment appointment)
    {
        return _appointmentService.DoctorCreateAppointment(appointment);
    }
    
    public bool DoctorUpdateAppointment(Appointment appointment)
    {
        return _appointmentService.DoctorUpdateAppointment(appointment);
    }
    
    public bool DoctorDeleteAppointment(Appointment appointment)
    {
        return _appointmentService.DoctorDeleteAppointment(appointment);
    }
    
    public List<Appointment> DoctorListAppointments(long doctorId)
    {
        return _appointmentService.DoctorListAppointments(doctorId);
    }
    
    public Appointment GetById(long id)
    {
       throw new NotImplementedException();
    }
    
    public bool PatientScheduleAppointment(Appointment appointment)
    {
        return _appointmentService.PatientScheduleAppointment(appointment);
    }
    
    public bool PatientCancelAppointment(Appointment appointment)
    {
        return _appointmentService.PatientCancelAppointment(appointment);
    }
    
    public bool PatientReScheduleAppointment(Appointment appointment)
    {
        return  _appointmentService.PatientReScheduleAppointment(appointment);
    }
    
    public List<Appointment> PatientListAppointments(Patient patient)
    {
        return _appointmentService.PatientListAppointments(patient);
    }
    
    public List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment)
    {
       throw new NotImplementedException();
    }
    
}