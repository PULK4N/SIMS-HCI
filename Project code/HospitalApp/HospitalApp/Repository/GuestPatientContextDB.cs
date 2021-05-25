/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

<<<<<<< Updated upstream
using System;
=======
using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;
>>>>>>> Stashed changes
using System.Data.Entity;

public class GuestPatientContextDB : IGuestPatientRepository
{
    public GuestPatientContextDB() 
    {
    }

    public bool CreatePatient(Patient patient)
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
<<<<<<< Updated upstream
=======

    void IEntityRepository<GuestPatient>.Create(GuestPatient tObject)
    {
        throw new NotImplementedException();
    }

    void IEntityRepository<GuestPatient>.Delete(long id)
    {
        throw new NotImplementedException();
    }

    GuestPatient IEntityRepository<GuestPatient>.Get(long id)
    {
        throw new NotImplementedException();
    }

    List<GuestPatient> IEntityRepository<GuestPatient>.GetAll()
    {
        throw new NotImplementedException();
    }

    void IEntityRepository<GuestPatient>.Update(GuestPatient tObject)
    {
        throw new NotImplementedException();
    }
>>>>>>> Stashed changes
}