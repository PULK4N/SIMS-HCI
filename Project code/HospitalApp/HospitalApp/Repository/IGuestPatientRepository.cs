// File:    IGuestPatientRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:36:32 AM
// Purpose: Definition of Interface IGuestPatientRepository

using System;

public interface IGuestPatientRepository
{
   bool CreatePatient(Patient patient);
   
   Patient ReadPatient(Patient patient);
   
   bool UpdatePatient(Patient patient);
   
   bool DeletePatient(Patient patient);

}