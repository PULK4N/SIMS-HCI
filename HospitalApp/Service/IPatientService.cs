// File:    IPatientService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:26:06 AM
// Purpose: Definition of Interface IPatientService

using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalApp.Service
{
    public interface IPatientService : IEntityService<Patient>
    {
        bool IsMalicious(Patient patient);
        void BanPatient(Patient patient);
        Task StartWeeklyAttemptsRestarting(CancellationToken cancellationToken);
    }
}