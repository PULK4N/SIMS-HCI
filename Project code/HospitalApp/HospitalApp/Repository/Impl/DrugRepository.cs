// File:    MedicineContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class MedicineContextDB

using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HospitalApp.Repository
{
    public class DrugRepository : IDrugRepository
    {
        public DrugRepository()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
        }

        public void Create(Drug drug)
        {
            try
            {
                HospitalDB.Instance.Drugs.Add(drug);
                HospitalDB.Instance.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void Delete(long drugId)
        {
            try
            {
                HospitalDB.Instance.Drugs.Remove(Get(drugId));
                HospitalDB.Instance.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public Drug Get(long drugId)
        {
            return HospitalDB.Instance.Drugs.Find(drugId);
        }

        public List<Drug> GetAll()
        {
            return HospitalDB.Instance.Drugs.ToList();
        }

        public List<Drug> GetAllByPatient(Patient patient)
        {
            HashSet<Drug> DrugsUsedByPatient = new HashSet<Drug>();
            foreach (Prescription prescription in patient.MedicalRecord.Anamnesis.Prescriptions)
            {
                DrugsUsedByPatient.Add(prescription.Drug);
            }
            return DrugsUsedByPatient.ToList();
        }

        public Drug GetByName(string name)
        {
            return (from d in HospitalDB.Instance.Drugs where d.Name == name select d).FirstOrDefault();
        }

        public List<Drug> GetDrugsForApproval()
        {
            List<Drug> allDrugs = GetAll();
            return GetPendingDrugs(allDrugs);
        }

        private List<Drug> GetPendingDrugs(List<Drug> allDrugs)
        {
            List<Drug> drugsForApproval = new List<Drug>();
            foreach (Drug d in allDrugs)
            {
                if (d.DrugStatus.Equals(Enums.DrugStatus.PENDING))
                    drugsForApproval.Add(d);
            }
            return drugsForApproval;
        }

        public void Update(Drug drug)
        {
            HospitalDB.Instance.SaveChanges();
        }
    }
}