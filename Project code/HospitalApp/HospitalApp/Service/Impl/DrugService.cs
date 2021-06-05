// File:    MedicineService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class MedicineService

using HospitalApp.Model;
using HospitalApp.Repository;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;

        public DrugService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public void Create(Drug drug)
        {
            _drugRepository.Create(drug);
        }

        public void Delete(long drugId)
        {
            _drugRepository.Delete(drugId);
        }

        public Drug Get(long drugId)
        {
            return _drugRepository.Get(drugId);
        }

        public List<Drug> GetAll()
        {
            return _drugRepository.GetAll();
        }

        public List<Drug> GetAllByPatient(Patient patient)
        {
            return _drugRepository.GetAllByPatient(patient);
        }

        public void Update(Drug drug)
        {
            var editedDrug = _drugRepository.Get(drug.DrugId);
            if (editedDrug != null)
            {
                editedDrug.Details = drug.Details;
                editedDrug.Name = drug.Name;
                editedDrug.DrugStatus = drug.DrugStatus;
                _drugRepository.Update(drug);
            }
        }
    }
}