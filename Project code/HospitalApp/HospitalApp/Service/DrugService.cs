// File:    MedicineService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class MedicineService

using System;
using System.Collections.Generic;

public class DrugService : IDrugService
{
    private readonly IDrugRepository _drugRepository;

    public DrugService(IDrugRepository drugRepository)
    {
        _drugRepository = drugRepository;
    }

    public bool CreateDrug(Drug drug)
    {
        return _drugRepository.CreateDrug(drug);
    }

    public bool DeleteDrug(Drug drug)
    {
        return _drugRepository.DeleteDrug(drug);
    }

    public Drug GetDrug(Drug drug)
    {
        return _drugRepository.GetDrug(drug);
    }

    public List<Drug> GetDrugs()
    {
        return _drugRepository.GetDrugsForApproval();
    }

    public List<Drug> GetPatientDrugs(Patient patient)
    {
        return _drugRepository.GetPatientDrugs(patient);
    }

    public bool UpdateDrug(Drug drug)
    {
        return _drugRepository.UpdateDrug(drug);
    }

    public List<Drug> GetDrugsForApproval()
    {
        return _drugRepository.GetDrugsForApproval();
    }

    public bool ApproveDrug(Drug drug)
    {
        return _drugRepository.ApproveDrug(drug);
    }

    public bool RejectDrug(Drug drug)
    {
        return _drugRepository.RejectDrug(drug);
    }
}