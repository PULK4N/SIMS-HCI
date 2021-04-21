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
        return _appointmentRepository.DoctorCreateAppointment(appointment);
    }

    public bool DoctorDeleteAppointment(Appointment appointment)
    {
        return _appointmentRepository.DoctorDeleteAppointment(appointment);
    }

    public List<Appointment> DoctorListAppointments(long doctorId)
    {
        return _appointmentRepository.DoctorListAppointments(doctorId);
    }

    public bool DoctorUpdateAppointment(Appointment appointment)
    {
        return _appointmentRepository.DoctorUpdateAppointment(appointment);
    }

    public Appointment GetById(long id)
    {
        throw new NotImplementedException();
    }

    public List<Appointment> PatientListAppointments(Patient patient)
    {
        return _appointmentRepository.PatientListAppointments(patient);
    }

    public bool PatientCancelAppointment(Appointment appointment)
    {
        return _appointmentRepository.PatientCancelAppointment(appointment);
    }

    public List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment)
    {
        throw new NotImplementedException();
    }

    public bool PatientReScheduleAppointment(Appointment appointment)
    {
        return _appointmentRepository.PatientReScheduleAppointment(appointment);
    }

    public bool PatientScheduleAppointment(Appointment appointment)
    {
        return _appointmentRepository.PatientScheduleAppointment(appointment);
    }
}