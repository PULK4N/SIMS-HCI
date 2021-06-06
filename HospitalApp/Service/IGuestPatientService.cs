// File:    IGuestPatientService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:26:09 AM
// Purpose: Definition of Interface IGuestPatientService

using HospitalApp.Model;
using System;

namespace HospitalApp.Service
{
    public interface IGuestPatientService : IEntityService<GuestPatient>
    {

    }
}