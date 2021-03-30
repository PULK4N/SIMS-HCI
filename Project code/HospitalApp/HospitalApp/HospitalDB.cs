// File:    HospitalDB.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 4:28:07 PM
// Purpose: Definition of Class HospitalDB

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public class HospitalDB : DbContext, IHospitalDB
{
    public DbSet<RegisteredUser> registeredUsers { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<Patient> patients { get; set; }
    public DbSet<Doctor> doctors { get; set; }
    public DbSet<Secretary> secretaries { get; set; }
    public DbSet<Appointment> appointments { get; set; }
    public DbSet<GuestPatient> guestPatients { get; set; }

    public HospitalDB() : base()
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool ChangeAppointmentStatus(long appointMentID, Enums.AppointmentStatus status)
    {
        throw new NotImplementedException();
    }

    public bool CreateAppointment(Appointment appointment)
    {
        try
        {
            using (var ctx = new HospitalDB())
            {
                ctx.appointments.Add(appointment);

                ctx.SaveChanges();
            }
            return true;
        }
        catch
        {

        }
        return false;
    }

    public bool CreatePatient(Patient patient)
    {
        try
        {
            using (var ctx = new HospitalDB())
            {
                ctx.registeredUsers.Add(patient.user.registeredUser);
                ctx.users.Add(patient.user);

                ctx.patients.Add(patient);
                ctx.SaveChanges();
            }
            return true;
        }
        catch
        {
            
        }
        return false;
    }

    public bool DeleteAppointment(long doctorID)
    {
        throw new NotImplementedException();
    }

    public bool DeletePatient(Patient patient)
    {
        try
        {
            using (var ctx = new HospitalDB())
            {
                ctx.patients.Remove(patient);
                ctx.SaveChanges();
            }
            return true;
        }
        catch
        {

        }
        return false;
    }

    public List<Patient> GetAllPatients()
    {
        try
        {
            using (var ctx = new HospitalDB())
            {
//                return ctx.patients.
            }
        }
        catch
        {

        }
        return null;
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

    public bool UpdatePatient(Patient patient)
    {
        throw new NotImplementedException();
    }
}