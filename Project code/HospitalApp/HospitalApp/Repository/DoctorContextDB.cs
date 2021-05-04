/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class DoctorService
 ***********************************************************************/

using Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public class DoctorContextDB :  IDoctorRepository
{
    public DoctorContextDB() 
    {
    }

    public Doctor CreateDoctor(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public Doctor DeleteDoctor(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public List<Doctor> GetAllDoctors()
    {
        throw new NotImplementedException();
    }
    //doesn't get doctors "RegisterUser" (username and pw information) 
    public List<Doctor> GetAllDoctors(Enums.Specialization specialization)
    {
        return (from doctor in HospitalDB.Instance.Doctors
                where doctor.Specialization == specialization
                select doctor)
                .Include(d => d.Employee)
                .Include(d => d.Employee.User)
                .ToList();
    }
    public List<Doctor> GetAvailableDoctorsForTimeSpan(Appointment appointment)
    {
        throw new NotImplementedException();
    }

    public Doctor GetDoctorById(long id)
    {
        return (from doctor in HospitalDB.Instance.Doctors
                where doctor.DoctorId == id
                select doctor).Include(doc => doc.Employee)
                .Include(doc => doc.Employee.User)
                .Include(doc => doc.Employee.User.RegisteredUser).FirstOrDefault();
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