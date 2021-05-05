// File:    IMedicineService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:25:41 AM
// Purpose: Definition of Interface IMedicineService

using System;
using System.Collections.Generic;

public interface IDrugService
{
    bool CreateDrug(Drug drug);
    
    bool UpdateDrug(Drug drug);
    
    bool DeleteDrug(Drug drug);
    
    Drug GetDrug(Drug drug);
    
    List<Drug> GetDrugs();

    List<Drug> GetPatientDrugs(Patient patient);

    List<Drug> GetDrugsForApproval();

    bool ApproveDrug(Drug drug);

    bool RejectDrug(Drug drug);
}