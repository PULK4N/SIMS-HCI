// File:    HospitalDB.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 4:28:07 PM
// Purpose: Definition of Class HospitalDB

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

public class HospitalDB : DbContext, IHospitalDB
{
    private static HospitalDB instance = null;
    private static readonly object padlock = new object();
    public DbSet<RegisteredUser> registeredUsers { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<Patient> patients { get; set; }
    public DbSet<Doctor> doctors { get; set; }
    public DbSet<Secretary> secretaries { get; set; }
    public DbSet<Appointment> appointments { get; set; }
    public DbSet<GuestPatient> guestPatients { get; set; }
    public static HospitalDB Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new HospitalDB();
                }
                return instance;
            }
        }
    }

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
            Instance.appointments.Add(appointment);
            Instance.SaveChanges();
            return true;
        }
        catch
        {
            MessageBox.Show("Error while creating new appointment");
        }
        return false;

    }

    public bool CreatePatient(Patient patient)
    {
        try
        {

            Instance.registeredUsers.Add(patient.User.RegisteredUser);
            Instance.users.Add(patient.User);

            Instance.patients.Add(patient);
            Instance.SaveChanges();

            return true;
        }
        catch
        {
            
        }
        return false;
    }

    public bool DeleteAppointment(long doctorID)
    {
        try
        {

            Instance.SaveChanges();

            return true;
        }
        catch
        {

        }
        return false;
    }

    public bool DeletePatient(Patient patient)
    {
        try
        {

            Instance.patients.Remove(patient);
            Instance.SaveChanges();

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
            return Instance.patients.ToList();
        }
        catch
        {
            MessageBox.Show("Error while getting patient list, returning null");
        }
        return null;
    }

    public List<Appointment> GetAppointmentByDateAndPatientID(DateTime date, long patientID)
    {
        throw new NotImplementedException();
    }

    public Appointment GetAppointmentByID(long appointmentID)
    {
        try
        {
            return Instance.appointments.Find(appointmentID);
            //Appointment appointment = (from a in Instance.appointments where a.appointmentId == appointmentID select a).FirstOrDefault<Appointment>();
            //return appointment;
        }
        catch
        {
            MessageBox.Show("We discovered an error while trying to acquire an appointment by Id");
        }
        return null;
    }

    public List<Appointment> GetAppointmentsByPatientID(long patientID)//TO DO: possible error
    {
        try
        {
            List<Appointment> appointments = (from a in Instance.appointments where a.Patient.PatientId == patientID select a).ToList<Appointment>();
            return appointments;
        }
        catch
        {
            MessageBox.Show("We discovered an error while trying to acquire an appointment by patientId");
        }
        return null;
    }

    public List<Patient> GetPatientsByDoctorID(long doctorID)
    {
        throw new NotImplementedException();
    }

    public Patient GetPatientByID(long patientID)
    {
        try
        {
            return Instance.patients.Find(patientID);
        }
        catch
        {
            MessageBox.Show("We discovered an error while trying to acquire an appointment by Id");
        }
        return null;
    }

    public bool ReScheduleAppointment(Appointment appointment)
    {

        return false;
    }

    public bool UpdatePatient(Patient patient)
    {
        Patient oldPatientInfo = Instance.patients.Find(patient.PatientId);
        if (oldPatientInfo != null)
        {
            oldPatientInfo.User.Address = patient.User.Address;
            oldPatientInfo.User.EMail = patient.User.EMail;
            oldPatientInfo.User.PhoneNumber = patient.User.PhoneNumber;
            Instance.SaveChanges();
        }
        return false;
    }

    public bool DeleteGuestPatient(GuestPatient guestPatient)
    {
        try
        {
            guestPatients.Remove(guestPatient);
            Instance.SaveChanges();
            return true;
        }
        catch
        {
            MessageBox.Show("Error while deleting a guest patient");
        }
        return false;
    }
}