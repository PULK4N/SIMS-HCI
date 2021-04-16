/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using System;
using System.Data.Entity;

public class PatientContextDB : DbContext, IPatientRepository
{
    public DbSet<Patient> Patients { get; set; }

    public PatientContextDB() : base()
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

public bool CreatePatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public bool DeletePatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public Patient ReadPatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePatient(Patient patient)
    {
        throw new NotImplementedException();
    }
}