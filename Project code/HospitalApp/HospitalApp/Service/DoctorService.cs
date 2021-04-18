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
    }
}