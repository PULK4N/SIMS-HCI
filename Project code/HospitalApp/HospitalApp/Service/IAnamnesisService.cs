// File:    IAnamnesisService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:25:48 AM
// Purpose: Definition of Interface IAnamnesisService

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public interface IAnamnesisService : IEntityService<Anamnesis>
    {
        Anamnesis GetByPatientId(long patientId);
    }
}