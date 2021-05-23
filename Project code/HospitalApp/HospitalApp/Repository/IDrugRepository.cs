// File:    IMedicineRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IMedicineRepository

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Repository
{
    public interface IDrugRepository : IEntityRepository<Drug>
    {

        List<Drug> GetAllByPatient(Patient patient);

    }
}