/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class DoctorService
 ***********************************************************************/

using System.Collections.Generic;

public interface IDoctorService
{
<<<<<<< Updated upstream
    Doctor SaveDoctor(Doctor doctor);

    Doctor UpdateDoctor(Doctor doctor);

    Doctor DeleteDoctor(Doctor doctor);

    Doctor GetDoctorById(long id);
   
    List<Doctor> GetAllDoctors();
    List<Doctor> GetAllDoctors(Enums.Specialization specialization);

    List<Doctor> GetAvailableDoctorsForTimeSpan(Appointment appointment);
=======
    public interface IDoctorService : IEntityService<Doctor>
    {
        List<Doctor> GetAllBySpecialization(Enums.Specialization specialization);
        Doctor GetByUsername(string Username);
    }
>>>>>>> Stashed changes
}