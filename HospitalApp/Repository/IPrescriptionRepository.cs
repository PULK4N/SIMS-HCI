// File:    IPrescriptionRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IPrescriptionRepository

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Repository
{
    public interface IPrescriptionRepository : IEntityRepository<Prescription>
    {

        List<Prescription> GetAllByPatient(long patientId);

        void DeleteAllByAnamnesis(Anamnesis anamnesis);

    }
}