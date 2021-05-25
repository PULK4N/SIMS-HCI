/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class DoctorService
 ***********************************************************************/

using Enums;
using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

namespace HospitalApp.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        public DoctorRepository()
        {
        }

        public void Create(Doctor doctor)
        {
            HospitalDB.Instance.Doctors.Add(doctor);
            HospitalDB.Instance.SaveChanges();
        }

        public void Delete(long doctorId)
        {
            HospitalDB.Instance.Doctors.Remove(Get(doctorId));
            HospitalDB.Instance.SaveChanges();
        }

        public List<Doctor> GetAll()
        {
            return HospitalDB.Instance.Doctors.ToList();
        }
        //doesn't get doctors "RegisterUser" (username and pw information)
        public List<Doctor> GetAllBySpecialization(Specialization specialization)
        {
            return (from doctor in HospitalDB.Instance.Doctors
                    where doctor.Specialization == specialization
                    select doctor)
                    .Include(d => d.Employee)
                    .Include(d => d.Employee.User)
                    .ToList();
        }

        public Doctor Get(long id)
        {
            return (from doctor in HospitalDB.Instance.Doctors
                    where doctor.DoctorId == id
                    select doctor).Include(doc => doc.Employee)
                    .Include(doc => doc.Employee.User)
                    .Include(doc => doc.Employee.User.RegisteredUser).FirstOrDefault();
        }

        public void Update(Doctor doctor)
        {
            try
            {
                Doctor oldDoctor = HospitalDB.Instance.Doctors.Find(doctor.DoctorId);
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
                    doctor.Employee.User.RelationshipStatus = oldDoctor.Employee.User.RelationshipStatus;
                    doctor.Employee.User.Sex = oldDoctor.Employee.User.Sex;
                    HospitalDB.Instance.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Doctor repository updating error");
            }
        }

        public Doctor GetByUsername(string username)
        {
            try
            {
                return (from doc in HospitalDB.Instance.Doctors where doc.Employee.User.RegisteredUser.Username == username select doc)
                    .Include(doc => doc.Employee)
                    .Include(doc => doc.Employee.User)
                    .Include(doc => doc.Employee.User.RegisteredUser)
                    .First();
            }
            catch (InvalidOperationException op)
            {
                MessageBox.Show(op.ToString());
            }
            return null;
        }
    }
}