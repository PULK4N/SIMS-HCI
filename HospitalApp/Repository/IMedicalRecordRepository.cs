// File:    IMedicalRecordRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IMedicalRecordRepository

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Repository
{
    public interface IMedicalRecordRepository : IEntityRepository<MedicalRecord>
    {

    }
}