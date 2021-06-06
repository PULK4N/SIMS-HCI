using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HospitalApp.Repository
{
    public class AnamnesisRepository : IAnamnesisRepository
    {//TO DO: Try catch

        public AnamnesisRepository()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
        }

        public void Create(Anamnesis anamnesis)
        {
            HospitalDB.Instance.Anamnesis.Add(anamnesis);
            HospitalDB.Instance.SaveChanges();
        }

        public void Delete(long AnamnesisId)
        {
            Anamnesis anamnesis = Get(AnamnesisId);
            Map.PrescriptionRepository.DeleteAllByAnamnesis(anamnesis);
            anamnesis.RemoveAllPrescriptions();
            HospitalDB.Instance.Anamnesis.Remove(anamnesis);
        }

        public Anamnesis Get(long anamnesisId)
        {
            return (from a in HospitalDB.Instance.Anamnesis where a.AnamnesisId == anamnesisId select a)
                .Include(a => a.Prescriptions.Select(p => p.Drug))
                .FirstOrDefault();
        }

        public void Update(Anamnesis anamnesis)
        {
            Anamnesis oldAnamnesis = HospitalDB.Instance.Anamnesis.Find(anamnesis.AnamnesisId);
            if (oldAnamnesis != null)
            {
                oldAnamnesis.Description = anamnesis.Description;
                oldAnamnesis.TimeOf = DateTime.Now;
            }
        }

        public Anamnesis GetByPatient(long patientId)
        {
            return (from p in HospitalDB.Instance.Patients where p.PatientId == patientId select p.MedicalRecord.Anamnesis)
                .Include(a => a.Prescriptions.Select(p => p.Drug))
                .FirstOrDefault();
        }

        public List<Anamnesis> GetAll()
        {
            return (from a in HospitalDB.Instance.Anamnesis select a)
                .Include(a => a.Prescriptions.Select(p => p.Drug))
                .ToList();
        }
    }
}