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
            _drugRepository.Update(drug);
        }

        public List<Drug> GetDrugsForApproval()
        {
            List<Drug> allDrugs = _drugRepository.GetAll();
            return GetPendingDrugs(allDrugs);
        }

        private static List<Drug> GetPendingDrugs(List<Drug> allDrugs)
        {
            List<Drug> drugsForApproval = new List<Drug>();
            foreach (Drug d in allDrugs)
            {
                if (d.DrugStatus.Equals(Enums.DrugStatus.PENDING))
                    drugsForApproval.Add(d);
            }
            return drugsForApproval;
        }

        public bool ApproveDrug(Drug drug)
        {
            Drug selectedDrug = _drugRepository.Get(drug.DrugId);
            if (selectedDrug != null)
            {
                selectedDrug.DrugStatus = Enums.DrugStatus.APPROVED; //izvuci u f-ju
                HospitalDB.Instance.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RejectDrug(Drug drug)
        {
            Drug selectedDrug = _drugRepository.Get(drug.DrugId);
            if (selectedDrug != null)
            {
                selectedDrug.DrugStatus = Enums.DrugStatus.REJECTED; //izvuci u f-ju
                HospitalDB.Instance.SaveChanges();
                return true;
            }
            return false;
        }
    }
}