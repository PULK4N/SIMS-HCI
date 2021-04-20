// File:    IPatientService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:26:06 AM
// Purpose: Definition of Interface IPatientService

using System;

public interface IPatientService
{
   bool CreatePatient(String firstName, String lastName, String dateOfBirth, String address, String phoneNumber, int jmbg, String eMail, Enums.Sex sex);

    Patient GetPatient(Patient patient);

    Patient GetPatient(long patientId);

    bool UpdatePatient(Patient patient);
   
   bool DeletePatient(Patient patient);

}