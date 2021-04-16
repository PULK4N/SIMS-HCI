// File:    MedicineContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class MedicineContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;

public class MedicineContextDB : DbContext, IMedicineRepository
{
    public DbSet<Medicine> Medicines { get; set; }

    public MedicineContextDB() : base()
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool CreateMedicine(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public bool DeleteMedicine(Medicine medicine)
    {
        throw new NotImplementedException();
    }

    public List<Medicine> GetAllPatientMedicines(Medicine medicine)
    {
        throw new NotImplementedException();
    }

    public Medicine GetMedicine(Medicine medicine)
    {
        throw new NotImplementedException();
    }

    public bool UpdateMedicine(Medicine medicine)
    {
        throw new NotImplementedException();
    }
}