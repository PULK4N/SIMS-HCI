// File:    PrescriptionContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class PrescriptionContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;

public class PrescriptionContextDB : DbContext, IPrescriptionRepository
{
    public DbSet<Anamnesis> Anamnesis { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorsReferral> DoctorsReferrals { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<GuestPatient> GuestPatients { get; set; }
    public DbSet<HospitalClinic> HospitalClinics { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Referal> Referals { get; set; }
    public DbSet<RegisteredUser> RegisteredUsers { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Secretary> Secretaries { get; set; }

    public PrescriptionContextDB() : base("HospitalDB")
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool CreatePrescription(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public bool DeletePrescription(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public List<Prescription> GetAllPatientPrescriptions(long patientId)
    {
        throw new NotImplementedException();
    }

    public Prescription GetPrescription(long prescriptionId)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePrescription(Prescription prescription)
    {
        throw new NotImplementedException();
    }
}