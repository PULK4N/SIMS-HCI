// File:    IPatientRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:36:32 AM
// Purpose: Definition of Interface IPatientRepository

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Repository
{
    public interface IPatientRepository : IEntityRepository<Patient>
    {

        List<Patient> GetAllByDoctor(Doctor doctor);

        bool IsMalicious(Patient patient);
        void BanPatient(Patient patient);
        List<Patient> GetWeekActivePatients();
    }
}