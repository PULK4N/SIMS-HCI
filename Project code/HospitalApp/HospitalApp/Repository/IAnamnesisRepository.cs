// File:    IAnamnesisRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IAnamnesisRepository

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Repository
{
    public interface IAnamnesisRepository : IEntityRepository<Anamnesis>
    {
        Anamnesis GetByPatient(long patientId);

    }
}