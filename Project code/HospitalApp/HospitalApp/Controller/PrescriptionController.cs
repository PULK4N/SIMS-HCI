// File:    PrescriptionController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:28:52 PM
// Purpose: Definition of Class PrescriptionController

using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;

namespace HospitalApp.Controller
{
    public class PrescriptionController : IEntityController<Prescription>
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        public void Create(Prescription prescription)
        {
            _prescriptionService.Create(prescription);
        }

        public void Update(Prescription prescription)
        {
            _prescriptionService.Update(prescription);
        }

        public void Delete(long prescriptionId)
        {
            _prescriptionService.Delete(prescriptionId);
        }

        public Prescription Get(long prescriptionId)
        {
            return _prescriptionService.Get(prescriptionId);
        }

        public List<Prescription> GetAllByPatientId(long patientId)
        {
            return _prescriptionService.GetAllByPatientId(patientId);
        }

        public List<Prescription> GetAll()
        {
            return _prescriptionService.GetAll();
        }
    }
}