/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class DoctorService
 ***********************************************************************/

using System.Collections.Generic;

public interface IDoctorService
{
    Doctor SaveDoctor(Doctor doctor);

    Doctor UpdateDoctor(Doctor doctor);

    Doctor DeleteDoctor(Doctor doctor);

    Doctor GetDoctorById(long id);

    List<Doctor> GetAllDoctorsByRole(Enums.Specialization specialization);
   
    List<Doctor> GetAllDoctors();

    List<Doctor> GetAvailableDoctorsForTimeSpan(Appointment appointment);
}