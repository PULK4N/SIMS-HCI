// File:    MedicalRecordService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class MedicalRecordService

using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public void Create(MedicalRecord medicalRecord)
        {
            _medicalRecordRepository.Create(medicalRecord);
        }

        public void Delete(long medicalRecordId)
        {
            _medicalRecordRepository.Delete(medicalRecordId);
        }

        public MedicalRecord Get(long medicalRecordId)
        {
            return _medicalRecordRepository.Get(medicalRecordId);
        }

        public List<MedicalRecord> GetAll()
        {
            return _medicalRecordRepository.GetAll();
        }

        public void Update(MedicalRecord medicalRecord)
        {
            MedicalRecord editedMedicalRecord = _medicalRecordRepository.Get(medicalRecord.MedicalRecordId);
            if (editedMedicalRecord != null)
            {
                editedMedicalRecord.LastMesuredHeight = medicalRecord.LastMesuredHeight;
                editedMedicalRecord.LastMesuredWeight = medicalRecord.LastMesuredWeight;
                editedMedicalRecord.Anamnesis = medicalRecord.Anamnesis;
                _medicalRecordRepository.Update(medicalRecord);
            }
        }
    }
}