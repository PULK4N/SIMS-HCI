// File:    MedicalRecordController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:01:14 PM
// Purpose: Definition of Class MedicalRecordController

using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;

namespace HospitalApp.Controller
{
    public class MedicalRecordController : IEntityController<MedicalRecord>
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        public void Create(MedicalRecord medicalRecord)
        {
            _medicalRecordService.Create(medicalRecord);
        }

        public void Update(MedicalRecord medicalRecord)
        {
            _medicalRecordService.Update(medicalRecord);
        }

        public void Delete(long medicalRecordId)
        {
            _medicalRecordService.Delete(medicalRecordId);
        }

        public MedicalRecord Get(long medicalRecordId)
        {
            return _medicalRecordService.Get(medicalRecordId);
        }

        public List<MedicalRecord> GetAll()
        {
            return _medicalRecordService.GetAll();
        }
    }
}