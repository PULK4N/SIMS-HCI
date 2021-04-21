/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using Enums;
using System;
using System.Collections.Generic;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public bool CreatePatient(string firstName, string lastName, string dateOfBirth, string address, string phoneNumber, int jmbg, string eMail, Sex sex)
    {
        throw new NotImplementedException();
    }

    public bool DeletePatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public Patient GetPatient(Patient patient)
    {
        return _patientRepository.GetPatient(patient);
    }

    public Patient GetPatient(long patientId)
    {
        return _patientRepository.GetPatient(patientId);
    }

    public bool UpdatePatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public List<Patient> GetPatients()
    {
        return _patientRepository.GetPatients();
    }
}