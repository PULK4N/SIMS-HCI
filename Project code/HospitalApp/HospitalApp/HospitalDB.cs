// File:    HospitalDB.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 4:28:07 PM
// Purpose: Definition of Class HospitalDB

using System;
using System.Collections.Generic;

public class HospitalDB : IHospitalDB
{
    public bool ChangeAppointmentStatus(long appointMentID, Enums.AppointmentStatus status)
    {
        throw new NotImplementedException();
    }

    public bool CreateAppointment(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public bool CreatePatient()
    {
        throw new NotImplementedException();
    }

    public bool DeleteAppointment(long doctorID)
    {
        throw new NotImplementedException();
    }

    public bool DeletePatient()
    {
        throw new NotImplementedException();
    }

    public List<Patient> GetAllPatients()
    {
        throw new NotImplementedException();
    }

    public List<Appointment> GetAppointmentByDateAndPatientID(DateTime date, long patientID)
    {
        throw new NotImplementedException();
    }

    public Appointment GetAppointmentByID(long appointmentID)
    {
        throw new NotImplementedException();
    }

    public List<Appointment> GetAppointmentsByPatientID(long patientID)
    {
        throw new NotImplementedException();
    }

    public List<Patient> GetPatientByDoctorID(long doctorID)
    {
        throw new NotImplementedException();
    }

    public Patient GetPatientByID(long patientID)
    {
        throw new NotImplementedException();
    }

    public bool ReScheduleAppointment(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePatient()
    {
        throw new NotImplementedException();
    }
}