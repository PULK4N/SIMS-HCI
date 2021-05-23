/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class DoctorService
 ***********************************************************************/

using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;

namespace HospitalApp.Controller
{
    public class DoctorController : IEntityController<Doctor>
    {
        private IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public void Create(Doctor doctor)
        {
            _doctorService.Create(doctor);
        }

        public void Update(Doctor doctor)
        {
            _doctorService.Update(doctor);
        }

        public void Delete(long doctorId)
        {
            _doctorService.Delete(doctorId);
        }

        public Doctor Get(long id)
        {
            return _doctorService.Get(id);
        }


        public List<Doctor> GetAll()
        {
            return _doctorService.GetAll();
        }

        public List<Doctor> GetAllBySpecialization(Enums.Specialization specialization)
        {
            return _doctorService.GetAllBySpecialization(specialization);
        }


    }
}