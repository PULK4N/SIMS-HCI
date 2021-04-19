/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

public class PatientContextDB : DbContext, IPatientRepository
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

    public PatientContextDB() : base("HospitalDB")
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool CreatePatient(Patient patient)
    {
        try
        {

            RegisteredUsers.Add(patient.User.RegisteredUser);
            Users.Add(patient.User);

            Patients.Add(patient);
            SaveChanges();

            return true;
        }
        catch
        {
            MessageBox.Show("Error");
        }
        return false;
    }

    public bool DeletePatient(Patient patient)
    {
        try
        {
            RegisteredUsers.Remove(patient.User.RegisteredUser);
            Users.Remove(patient.User);
            if(patient.Appointments !=null)
            Patients.Remove(patient);
            SaveChanges();

            return true;
        }
        catch
        {
            MessageBox.Show("Error");
        }
        return false;
    }

    public Patient GetPatient(Patient patient)
    {
        try
        {
            Patient oldPatient = (from pat in Patients where pat.PatientId == patient.PatientId select pat).FirstOrDefault();
            return oldPatient;
        }
        catch
        {
            MessageBox.Show("Error");
        }
        return null;
    }

    public Patient GetPatient(long patientId)
    {
        try
        {
            Patient oldPatient = (from pat in Patients
                                  where pat.PatientId == patientId
                                  select pat).Include(patient => patient.User).Include(patient => patient.User.RegisteredUser).First();
            return oldPatient;
        }
        catch (Exception e)
        {

        }
        return null;
    }

    public bool UpdatePatient(Patient patient)
    {
        try
        {
            Patient oldPatient = Patients.Find(patient.PatientId);
            if(patient.PatientId == oldPatient.PatientId && patient.User.UserId == oldPatient.User.UserId && patient.User.RegisteredUser.RegUserId == oldPatient.User.RegisteredUser.RegUserId)
            {
                patient.User.RegisteredUser.Username = oldPatient.User.RegisteredUser.Username;
                patient.User.RegisteredUser.Password = oldPatient.User.RegisteredUser.Password;

                patient.User.Address = oldPatient.User.Address;
                patient.User.DateOfBirth = oldPatient.User.DateOfBirth;
                patient.User.EMail = oldPatient.User.EMail;
                patient.User.FirstName = oldPatient.User.FirstName;
                patient.User.Jmbg = oldPatient.User.Jmbg;
                patient.User.LastName = oldPatient.User.LastName;
                patient.User.PhoneNumber = oldPatient.User.PhoneNumber;
                patient.User.RelationshipStatus = oldPatient.User.RelationshipStatus;
                patient.User.Sex = oldPatient.User.Sex;
                return true;
            }
        }
        catch
        {
            MessageBox.Show("Error");
        }

        return false;
    }

    public List<Patient> GetAllPatients()
    {
        try
        {
            return Patients.ToList();
        }
        catch
        {
            MessageBox.Show("Error while getting patient list, returning null");
        }
        return null;
    }
    //TO DO: add this one and upper to diagram, implement this

}