// File:    IPatientRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:36:32 AM
// Purpose: Definition of Interface IPatientRepository

using System;
using System.Collections.Generic;

public interface IPatientRepository
{
   bool CreatePatient(Patient patient);

    Patient GetPatient(Patient patient);

    Patient GetPatient(long patientId);

    bool UpdatePatient(Patient patient);
   
   bool DeletePatient(Patient patient);

    List<Patient> GetPatients();

}