/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class DoctorService
 ***********************************************************************/

using HospitalApp.Model;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public interface IDoctorService : IEntityService<Doctor>
    {
        List<Doctor> GetAllBySpecialization(Enums.Specialization specialization);
    }
}