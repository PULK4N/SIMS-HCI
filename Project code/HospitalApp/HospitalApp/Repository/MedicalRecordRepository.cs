// File:    MedicalRecordContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class MedicalRecordContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows;
using System.Linq;
using HospitalApp.Model;

namespace HospitalApp.Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        public MedicalRecordRepository()
        {
        }

        public void Create(MedicalRecord medicalRecord)
        {
            throw new NotImplementedException();
        }

        public void Delete(long medicalRecordId)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord Get(long medicalRecordId)
        {
            return HospitalDB.Instance.MedicalRecords.Find(medicalRecordId);
        }

        public List<MedicalRecord> GetAll()
        {
            return (from m in HospitalDB.Instance.MedicalRecords select m).ToList();
        }

        public void Update(MedicalRecord medicalRecord)//TO DO:
        {
            try
            {
                //oldMedicalRecord.Anamnesis = medicalRecord.Anamnesis; not gonna update this
                HospitalDB.Instance.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}