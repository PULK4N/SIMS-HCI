// File:    PrescriptionContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class PrescriptionContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Validation;
using System.Windows;
using HospitalApp.Model;

namespace HospitalApp.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {

        public void Create(Prescription prescription)
        {
            try
            {
                HospitalDB.Instance.Prescriptions.Add(prescription);
                HospitalDB.Instance.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }

        public void Delete(long prescription)
        {
            HospitalDB.Instance.Prescriptions.Remove(Get(prescription));
            HospitalDB.Instance.SaveChanges();
        }

        public List<Prescription> GetAllByPatient(long patientId)
        {
            Patient patient = (from p in HospitalDB.Instance.Patients where p.PatientId == patientId select p)
                .Include(p => p.MedicalRecord).Include(p => p.MedicalRecord.Anamnesis)
                .Include(p => p.MedicalRecord.Anamnesis)
                .Include(p => p.MedicalRecord.Anamnesis.Prescriptions.Select(pre => pre.Drug))
                .FirstOrDefault();

            return patient.MedicalRecord.Anamnesis.Prescriptions;
        }

        public Prescription Get(long prescriptionId)
        {
            return (from p in HospitalDB.Instance.Prescriptions where p.PrescriptionId == prescriptionId select p)
                .Include(p => p.Drug)
                .FirstOrDefault();
        }

        public void Update(Prescription prescription)
        {
            Prescription prescriptionToEdit = (from p in HospitalDB.Instance.Prescriptions where p.PrescriptionId == prescription.PrescriptionId select p).FirstOrDefault();
            Drug prescriptionMedicine = (from m in HospitalDB.Instance.Drugs where m.DrugId == prescription.Drug.DrugId select m).FirstOrDefault();
            if (prescriptionToEdit != null)
            {
                prescriptionToEdit.Drug = prescriptionMedicine;
                prescriptionToEdit.Period = prescription.Period;
                prescriptionToEdit.Usage = prescription.Usage;
                HospitalDB.Instance.SaveChanges();
            }
        }

        public void DeleteAllByAnamnesis(Anamnesis anamnesis)
        {
            try
            {
                foreach (Prescription prescription in anamnesis.Prescriptions)
                {
                    HospitalDB.Instance.Prescriptions.Remove(prescription);
                }
                HospitalDB.Instance.SaveChanges();
            }
            catch
            {
            }
        }

        public List<Prescription> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}