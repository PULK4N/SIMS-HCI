/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class DoctorService
 ***********************************************************************/

using Enums;
using System;
using System.Collections.Generic;

public class DoctorService : IDoctorService
{
<<<<<<< Updated upstream
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public Doctor DeleteDoctor(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public List<Doctor> GetAllDoctors()
    {
        throw new NotImplementedException();
    }

    public List<Doctor> GetAllDoctors(Enums.Specialization specialization)
    {
        return _doctorRepository.GetAllDoctors(specialization);
    }

    public List<Doctor> GetAvailableDoctorsForTimeSpan(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public Doctor GetDoctorById(long id)
    {
        return _doctorRepository.GetDoctorById(id);
    }

    public Doctor SaveDoctor(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public Doctor UpdateDoctor(Doctor doctor)
    {
        throw new NotImplementedException();
=======
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

        public Doctor GetByUsername(string username)
        {
            return _doctorRepository.GetByUsername(username);
        }
>>>>>>> Stashed changes
    }
}