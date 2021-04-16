// File:    AppointmentContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class AppointmentContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;

public class AppointmentContextDB : DbContext, IAppointmentRepository
{
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
        throw new NotImplementedException();
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