// File:    MedicalRecordContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class MedicalRecordContextDB

using System;
using System.Data.Entity;

public class MedicalRecordContextDB : DbContext, IMedicalRecordRepository
{
    public DbSet<MedicalRecord> MedicalRecords { get; set; }

    public MedicalRecordContextDB() : base("HospitalDB")
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

public bool CreateMedicalRecord(MedicalRecord medicalRecord)
    {
        throw new NotImplementedException();
    }

    public bool DeleteMedicalRecord(MedicalRecord medicalRecord)
    {
        throw new NotImplementedException();
    }

    public MedicalRecord GetMedicalRecord(long medicalRecordId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateMedicalRecord(MedicalRecord medicalRecord)
    {
        throw new NotImplementedException();
    }
}