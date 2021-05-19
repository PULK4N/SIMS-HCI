// File:    IPrescriptionService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:25:45 AM
// Purpose: Definition of Interface IPrescriptionService

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public interface IPrescriptionService : IEntityService<Prescription>
    {

        List<Prescription> GetAllByPatientId(long patientId);

    }
}