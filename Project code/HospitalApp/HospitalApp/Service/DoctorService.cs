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
            Doctor oldDoctor = _doctorRepository.Get(doctor.DoctorId);
            if (oldDoctor != null)
            {
                doctor.Employee.User.RegisteredUser.Username = oldDoctor.Employee.User.RegisteredUser.Username;
                doctor.Employee.User.RegisteredUser.Password = oldDoctor.Employee.User.RegisteredUser.Password;

                doctor.Employee.User.Address = oldDoctor.Employee.User.Address;
                doctor.Employee.User.DateOfBirth = oldDoctor.Employee.User.DateOfBirth;
                doctor.Employee.User.EMail = oldDoctor.Employee.User.EMail;
                doctor.Employee.User.FirstName = oldDoctor.Employee.User.FirstName;
                doctor.Employee.User.Jmbg = oldDoctor.Employee.User.Jmbg;
                doctor.Employee.User.LastName = oldDoctor.Employee.User.LastName;
                doctor.Employee.User.PhoneNumber = oldDoctor.Employee.User.PhoneNumber;
                doctor.Employee.User.MaritalStatus = oldDoctor.Employee.User.MaritalStatus;
                doctor.Employee.User.Sex = oldDoctor.Employee.User.Sex;
            }
            _doctorRepository.Update(doctor);
        }

        public Doctor GetByUsername(string username)
        {
            return _doctorRepository.GetByUsername(username);
        }
    }
}