// File:    IPatientRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:36:32 AM
// Purpose: Definition of Interface IPatientRepository

using System;

public interface IPatientRepository
{
   bool CreatePatient(Patient patient);
   
   Patient ReadPatient(Patient patient);
   
   bool UpdatePatient(Patient patient);
   
   bool DeletePatient(Patient patient);

}