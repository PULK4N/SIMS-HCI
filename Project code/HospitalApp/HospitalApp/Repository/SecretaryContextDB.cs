// File:    SecretaryService.cs
// Author:  Lenovo_NB
// Created: cetvrtak, 28. maj 2020. 14:08:45
// Purpose: Definition of Class SecretaryService

using System;
using System.Collections.Generic;
using System.Data.Entity;

public class SecretaryContextDB : DbContext, ISecretaryRepository
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

    public SecretaryContextDB() : base("HospitalDB")
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SecretaryContextDB, HospitalApp.Migrations.Configuration>());
    }

    public bool CreateSecretary(Secretary secretary)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(long secretaryId)
    {
        throw new NotImplementedException();
    }

    public List<Secretary> GetAllSecretaries()
    {
        throw new NotImplementedException();
    }

    public Secretary GetById(long secretaryId)
    {
        throw new NotImplementedException();
    }

    public Secretary GetSecretaryByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Secretary SaveSecretary(Secretary secretary)
    {
        throw new NotImplementedException();
    }

    public Secretary UpdateSecretary(Secretary secretary)
    {
        throw new NotImplementedException();
    }
}