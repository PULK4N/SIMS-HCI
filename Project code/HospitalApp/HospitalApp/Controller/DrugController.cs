// File:    MedicineController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:30:55 PM
// Purpose: Definition of Class MedicineController

using System;
using System.Collections.Generic;

public class DrugController
{
    private readonly IDrugService _drugService;

    public DrugController(IDrugService drugService)
    {
        _drugService = drugService;
    }

    public bool CreateDrug(Drug drug)
    {
        return _drugService.CreateDrug(drug);
    }

    public bool UpdateDrug(Drug drug)
    {
        return _drugService.UpdateDrug(drug);
    }

    public bool DeleteMedicine(Drug drug)
    {
        return _drugService.DeleteDrug(drug);
    }

    public Drug GetDrug(Drug drug)
    {
        return _drugService.GetDrug(drug);
    }

    public List<Drug> GetPatientDrugs(Patient patient)
    {
        return _drugService.GetPatientDrugs(patient);
    }

    public List<Drug> GetDrugs()
    {
        return _drugService.GetDrugs();
    }

    public List<Drug> GetDrugsForApproval()
    {
        return _drugService.GetDrugsForApproval();
    }

    public bool ApproveDrug(Drug drug)
    {
        return _drugService.ApproveDrug(drug);
    }

<<<<<<< Updated upstream
    public bool RejectDrug(Drug drug)
    {
        return _drugService.RejectDrug(drug);
=======
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
>>>>>>> Stashed changes
    }

}