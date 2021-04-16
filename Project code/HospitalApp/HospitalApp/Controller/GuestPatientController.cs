/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using System;

public class GuestPatientController
{
    private readonly GuestPatientService _guestPatientService;

    public GuestPatientController(GuestPatientService guestPatientService)
    {
        _guestPatientService = guestPatientService;
    }

    public bool CreateGuestPatient(String username, String password, Enums.UserType userType, String firstName, String lastName, DateTime dateofBirth, String address, String phoneNumber, ulong jmbg, String eMail, Enums.RelationshipStatus sex, Enums.RelationshipStatus relationshipStatus, DateTime arrivalDate, String emergencyInfo)
    {
       throw new NotImplementedException();
    }
    
    public Patient ReadGuestPatient(Patient patient)
    {
       throw new NotImplementedException();
    }
    
    public bool UpdateGuestPatient(String username, String password, Enums.UserType userType, String firstName, String lastName, DateTime dateofBirth, String address, String phoneNumber, ulong jmbg, String eMail, Enums.RelationshipStatus sex, Enums.RelationshipStatus relationshipStatus, DateTime arrivalDate, String emergencyInfo)
    {
       throw new NotImplementedException();
    }
    
    public bool DeleteGuestPatient(Patient patient)
    {
       throw new NotImplementedException();
    }
}