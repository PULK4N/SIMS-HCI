// File:    AnamnesisContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class AnamnesisContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;

public class AnamnesisContextDB : DbContext, IAnamnesisRepository
{
    public DbSet<Anamnesis> Anamnesis { get; set; }

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
        throw new NotImplementedException();
    }

    public bool UpdateAnamnesis(Anamnesis anamnesis)
    {
        throw new NotImplementedException();
    }
}