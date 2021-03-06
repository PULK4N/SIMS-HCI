// File:    IMedicineService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:25:41 AM
// Purpose: Definition of Interface IMedicineService

using Enums;
using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public interface IDrugService : IEntityService<Drug>
    {
        List<Drug> GetAllByPatient(Patient patient);
        List<Drug> GetDrugsForApproval();
        Drug GetByName(string name);
        bool ValidateDrug(Drug drug, DrugStatus drugStatus);
    }
}