/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using System;

public class PatientController
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public bool CreatePatient(String username, String password, Enums.UserType userType, String firstName, String lastName, DateTime dateOfBirth, String address, String phoneNumber, ulong jmbg, String eMail, Enums.RelationshipStatus sex, Enums.RelationshipStatus relationshipStatus)
    {
       throw new NotImplementedException();
    }
    
    public Patient ReadPatient(Patient patient)
    {
       throw new NotImplementedException();
    }
    
    public bool UpdatePatient(String username, String password, Enums.UserType userType, String firstName, String lastName, DateTime dateOfBirth, String address, String phoneNumber, ulong jmbg, String eMail, Enums.RelationshipStatus sex, Enums.RelationshipStatus relationshipStatus)
    {
       throw new NotImplementedException();
    }
    
    public bool DeletePatient(Patient patient)
    {
       throw new NotImplementedException();
    }
}