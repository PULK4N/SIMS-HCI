// File:    IMedicineRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IMedicineRepository

using System;
using System.Collections.Generic;

public interface IDrugRepository
{
    bool CreateDrug(Drug drug);
    
    bool UpdateDrug(Drug drug);
    
    bool DeleteDrug(Drug drug);
    
    Drug GetDrug(Drug drug);
    
    List<Drug> GetDrugs();

    List<Drug> GetPatientDrugs(Patient patient);

}