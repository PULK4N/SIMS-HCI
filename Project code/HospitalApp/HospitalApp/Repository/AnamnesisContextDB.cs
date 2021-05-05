
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public class AnamnesisContextDB : IAnamnesisRepository
{

    public AnamnesisContextDB()
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool CreateAnamnesis(Anamnesis anamnesis)
    {
        throw new NotImplementedException();
    }

    public bool DeleteAnamnesis(Anamnesis anamnesis)
    {
        anamnesis.RemoveAllPrescriptions();
        anamnesis = HospitalDB.Instance.Anamnesis.Remove(anamnesis);
        return anamnesis != null;//if anamnesis is not found, it's gonna get deleted
    }

    public Anamnesis GetAnamnesis(long anamnesisId)
    {
        return (from a in HospitalDB.Instance.Anamnesis where a.AnamnesisId == anamnesisId select a)
            .Include(a => a.Prescriptions)
            .Include(a => a.Prescriptions)
            .FirstOrDefault();
    }

    public bool UpdateAnamnesis(Anamnesis anamnesis)
    {
        Anamnesis oldAnamnesis = HospitalDB.Instance.Anamnesis.Find(anamnesis.AnamnesisId);
        if(oldAnamnesis != null)
        {
            oldAnamnesis.Description = anamnesis.Description;
            oldAnamnesis.TimeOf = DateTime.Now;
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        return false;
    }

    public Anamnesis GetAnamnesisBy(Patient patient)
    {
        return (from p in HospitalDB.Instance.Patients where p.PatientId == patient.PatientId select p.MedicalRecord.Anamnesis)
            .Include(a => a.Prescriptions)
            .FirstOrDefault();
    }

    public Anamnesis GetAnamnesis(Anamnesis anamnesis)
    {
        return (from a in HospitalDB.Instance.Anamnesis where a.AnamnesisId == anamnesis.AnamnesisId select a)
            .Include(a => a.Prescriptions)
            .FirstOrDefault();
    }

}