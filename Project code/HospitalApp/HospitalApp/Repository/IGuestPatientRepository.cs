// File:    IGuestPatientRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:36:32 AM
// Purpose: Definition of Interface IGuestPatientRepository

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Repository
{
    public interface IGuestPatientRepository : IEntityRepository<GuestPatient>
    {
        

    }
}