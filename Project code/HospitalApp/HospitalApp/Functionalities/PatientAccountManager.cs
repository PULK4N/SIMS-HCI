/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using HospitalApp.Model;
using System;

public class PatientAccountManager
{
   public bool CreatePatient(int id, String firstName, String lastName, String dateOfBirth, 
       String address, String phoneNumber, int jmbg, String eMail, Enums.Sex sex)
   {
      throw new NotImplementedException();
   }
   
   public bool ReadPatient(Patient patient)
   {
      throw new NotImplementedException();
   }
   
   public bool UpdatePatient(Patient patient)
   {
      throw new NotImplementedException();
   }
   
   public bool DeletePatient(Patient patient)
   {
      throw new NotImplementedException();
   }

}