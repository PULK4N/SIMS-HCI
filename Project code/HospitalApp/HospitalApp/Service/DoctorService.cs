/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class DoctorService
 ***********************************************************************/

using Enums;
using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void Create(Doctor doctor)
        {
            _doctorRepository.Create(doctor);
        }

        public void Delete(long doctorId)
        {
            _doctorRepository.Delete(doctorId);
        }

        public List<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public List<Doctor> GetAllBySpecialization(Specialization specialization)
        {
            return _doctorRepository.GetAllBySpecialization(specialization);
        }

        public Doctor Get(long id)
        {
            return _doctorRepository.Get(id);
        }

        public void Update(Doctor doctor)
        {
            _doctorRepository.Update(doctor);
        }
    }
}