/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class DoctorService
 ***********************************************************************/

using System;
using System.Collections.Generic;

public class DoctorController
{
   private IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public Doctor SaveDoctor(Doctor doctor)
   {
      throw new NotImplementedException();
   }
   
   public Doctor UpdateDoctor(String username, String password, Enums.UserType userType, String firstName, String lastName, DateTime dateOfBirth, String address, String phoneNumber, ulong jmbg, String eMail, Enums.RelationshipStatus sex, Enums.RelationshipStatus relationshpStatus, float salary, uint workingHours, int vacationTime, int sickLeave, String aboutMe, Enums.Specialization specialization)
   {
      throw new NotImplementedException();
   }
   
   public Doctor DeleteDoctor(Doctor doctor)
   {
      throw new NotImplementedException();
   }
   
   public Doctor GetDoctorById(long id)
   {
        return _doctorService.GetDoctorById(id);
   }
   
   
   public List<Doctor> GetAllDoctors()
   {
      throw new NotImplementedException();
   }

    public List<Doctor> GetAllDoctors(Enums.Specialization specialization)
    {
        return _doctorService.GetAllDoctors(specialization);
    }

<<<<<<< Updated upstream
    public List<Doctor> GetAvailableDoctorsForTimeSpan(Appointment appointment)
   {
      throw new NotImplementedException();
   }

=======
        public Doctor GetByUsername(string username)
        {
            return _doctorService.GetByUsername(username);
        }
    }
>>>>>>> Stashed changes
}