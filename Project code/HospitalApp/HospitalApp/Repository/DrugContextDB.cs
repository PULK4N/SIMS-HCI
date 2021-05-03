// File:    MedicineContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class MedicineContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public class DrugRepository : IDrugRepository
{
    public DrugRepository()
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool CreateDrug(Drug drug)
    {
        try
        {
            HospitalDB.Instance.Drugs.Add(drug);
            HospitalDB.Instance.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    public bool DeleteDrug(Drug drug)
    {
        try
        {
            HospitalDB.Instance.Drugs.Remove(drug);
            HospitalDB.Instance.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }

    public Drug GetDrug(Drug drug)
    {
        return HospitalDB.Instance.Drugs.Find(drug.DrugId);
    }

    public List<Drug> GetDrugs()
    {
        return HospitalDB.Instance.Drugs.ToList();
    }

    public List<Drug> GetPatientDrugs(Patient patient)
    {
        HashSet<Drug> DrugsUsedByPatient = new HashSet<Drug>();
        foreach(Prescription prescription in patient.MedicalRecord.Anamnesis.Prescriptions)
        {
            DrugsUsedByPatient.Add(prescription.Drug);
        }
        return DrugsUsedByPatient.ToList();
    }

    public bool UpdateDrug(Drug drug)
    {
        var editedDrug = HospitalDB.Instance.Drugs.Find(drug.DrugId);
        if (editedDrug != null)
        {
            editedDrug.Details = drug.Details;
            editedDrug.Name = drug.Name;
            editedDrug.DrugStatus = drug.DrugStatus;
            return true;
        }
        return false;
    }
}