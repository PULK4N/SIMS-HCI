// File:    PrescriptionService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class PrescriptionService

using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public void Create(Prescription prescription)
        {
            _prescriptionRepository.Create(prescription);
        }

        public void Delete(long prescriptionId)
        {
            _prescriptionRepository.Delete(prescriptionId);
        }

        public List<Prescription> GetAllByPatientId(long patientId)
        {
            return _prescriptionRepository.GetAllByPatient(patientId);
        }

        public Prescription Get(long prescriptionId)
        {
            return _prescriptionRepository.Get(prescriptionId);
        }

        public void Update(Prescription prescription)
        {
            _prescriptionRepository.Update(prescription);
        }

        public List<Prescription> GetAll()
        {
            return _prescriptionRepository.GetAll();
        }
    }
}