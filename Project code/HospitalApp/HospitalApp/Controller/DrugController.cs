// File:    MedicineController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:30:55 PM
// Purpose: Definition of Class MedicineController

using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;

namespace HospitalApp.Controller
{
    public class DrugController : IEntityController<Drug>
    {
        private readonly IDrugService _drugService;

        public DrugController(IDrugService drugService)
        {
            _drugService = drugService;
        }

        public void Create(Drug drug)
        {
            _drugService.Create(drug);
        }

        public void Update(Drug drug)
        {
            _drugService.Update(drug);
        }

        public void Delete(long drugId)
        {
            _drugService.Delete(drugId);
        }

        public Drug Get(long drugId)
        {
            return _drugService.Get(drugId);
        }

        public List<Drug> GetAllByPatient(Patient patient)
        {
            return _drugService.GetAllByPatient(patient);
        }

        public List<Drug> GetAll()
        {
            return _drugService.GetAll();
        }

        public List<Drug> GetDrugsForApproval()
        {
            return _drugService.GetDrugsForApproval();
        }

        public bool ApproveDrug(Drug drug)
        {
            return _drugService.ApproveDrug(drug);
        }

        public bool RejectDrug(Drug drug)
        {
            return _drugService.RejectDrug(drug);
        }
        
        public Drug GetByName(string name)
        {
            return _drugService.GetByName(name);
        }
    }
}