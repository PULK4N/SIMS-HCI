// File:    IGuestPatientService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:26:09 AM
// Purpose: Definition of Interface IGuestPatientService

using System;

public interface IGuestPatientService
{
   bool CreatePatient(String firstName, String lastName, String dateOfBirth, String address, String phoneNumber, int jmbg, String eMail, Enums.Sex sex);
   
   Patient ReadPatient(Patient patient);
   
   bool UpdatePatient(Patient patient);
   
   bool DeletePatient(Patient patient);

}