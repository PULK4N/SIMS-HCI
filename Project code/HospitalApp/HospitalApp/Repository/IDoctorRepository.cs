// File:    IDoctorRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:36:32 AM
// Purpose: Definition of Interface IDoctorRepository

using System;
using System.Collections.Generic;

public interface IDoctorRepository
{
    Doctor CreateDoctor(Doctor doctor);
    Doctor SaveDoctor(Doctor doctor);

    Doctor UpdateDoctor(Doctor doctor);

    Doctor DeleteDoctor(Doctor doctor);

    Doctor GetDoctorById(long id);

    List<Doctor> GetAllDoctors();
    List<Doctor> GetAllDoctors(Enums.Specialization specialization);


    List<Doctor> GetAvailableDoctorsForTimeSpan(Appointment appointment);

}

