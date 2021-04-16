/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using Enums;
using System;

public class GuestPatientService : IGuestPatientService
{
    private readonly IGuestPatientRepository _guestPatientRepository;

    public GuestPatientService(IGuestPatientRepository guestPatientRepository)
    {
        _guestPatientRepository = guestPatientRepository;
    }

    public bool CreatePatient(string firstName, string lastName, string dateOfBirth, string address, string phoneNumber, int jmbg, string eMail, Sex sex)
    {
        throw new NotImplementedException();
    }

    public bool DeletePatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public Patient ReadPatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePatient(Patient patient)
    {
        throw new NotImplementedException();
    }
}