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

    public List<Drug> GetDrugsForApproval()
    {
        List<Drug> drugsForApproval = new List<Drug>();
        List<Drug> allDrugs = HospitalDB.Instance.Drugs.ToList();
        foreach(Drug d in allDrugs)
        {
            if (d.DrugStatus.Equals(Enums.DrugStatus.PENDING))
                drugsForApproval.Add(d);
        }
        return drugsForApproval;
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

    public bool ApproveDrug(Drug drug)
    {
        Drug selectedDrug = HospitalDB.Instance.Drugs.Find(drug.DrugId);
        if (selectedDrug != null)
        {
            selectedDrug.DrugStatus = Enums.DrugStatus.APPROVED;
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        return false;
    }

    public bool RejectDrug(Drug drug)
    {
        Drug selectedDrug = HospitalDB.Instance.Drugs.Find(drug.DrugId);
        if (selectedDrug != null)
        {
            selectedDrug.DrugStatus = Enums.DrugStatus.REJECTED;
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        return false;
    }
}