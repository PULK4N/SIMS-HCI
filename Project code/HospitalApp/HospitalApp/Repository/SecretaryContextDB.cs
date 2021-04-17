// File:    SecretaryService.cs
// Author:  Lenovo_NB
// Created: cetvrtak, 28. maj 2020. 14:08:45
// Purpose: Definition of Class SecretaryService

using System;
using System.Collections.Generic;
using System.Data.Entity;

public class SecretaryContextDB : DbContext, ISecretaryRepository
{
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