// File:    AppointmentService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public bool DoctorCreateAppointment(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public bool DoctorDeleteAppointment(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public List<Appointment> DoctorListAppointments(long doctorId)
    {
        return _appointmentRepository.DoctorListAppointments(doctorId);
    }

    public bool DoctorUpdateAppointment(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public Appointment GetById(long id)
    {
        throw new NotImplementedException();
    }

    public List<Appointment> PatentListAppointments(long patientID)
    {
        throw new NotImplementedException();
    }

    public bool PatientCancelAppointment(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment)
    {
        throw new NotImplementedException();
    }

    public bool PatientReScheduleAppointment(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public bool PatientScheduleAppointment(Appointment appointment)
    {
        throw new NotImplementedException();
    }
}