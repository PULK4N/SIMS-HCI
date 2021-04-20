
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public class AnamnesisContextDB : DbContext, IAnamnesisRepository
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

    public AnamnesisContextDB() : base("HospitalDB")
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool CreateAnamnesis(Anamnesis anamnesis)
    {
        throw new NotImplementedException();
    }

    public bool DeleteAnamnesis(Anamnesis anamnesis)
    {
        throw new NotImplementedException();
    }

    public List<Anamnesis> GetAllPatientAnamnesis(long patientId)
    {
        throw new NotImplementedException();
    }

    public Anamnesis GetAnamnesis(long anamnesisId)
    {
        return Anamnesis.Include(a => a.Prescription).Where(a => a.AnamnesisId == anamnesisId).FirstOrDefault();
    }

    public bool UpdateAnamnesis(Anamnesis anamnesis)
    {
        throw new NotImplementedException();
    }

    public List<Anamnesis> GetPatientAnamnesis(Patient patient)
    {
        MedicalRecord medicalRecord = (from p in Patients where p.PatientId == patient.PatientId select p.MedicalRecord).FirstOrDefault();
        return (from m in MedicalRecords where m.MedicalRecordId == medicalRecord.MedicalRecordId select m.Anamnesis) as List<Anamnesis>;
        
    }

    public Anamnesis GetAnamnesis(Anamnesis anamnesis)
    {
        return Anamnesis.Include(a => a.Prescription).Where(a => a.AnamnesisId == anamnesis.AnamnesisId).FirstOrDefault();
    }
}