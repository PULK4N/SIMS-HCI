using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

namespace HospitalApp.Repository
{
    public class PatientRepository : IPatientRepository
    {
        public PatientRepository()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
        }

        public void Create(Patient patient)
        {
            try
            {
                //order probably mathers
                HospitalDB.Instance.RegisteredUsers.Add(patient.User.RegisteredUser);
                HospitalDB.Instance.Users.Add(patient.User);
                HospitalDB.Instance.Anamnesis.Add(patient.MedicalRecord.Anamnesis);
                HospitalDB.Instance.MedicalRecords.Add(patient.MedicalRecord);
                HospitalDB.Instance.Patients.Add(patient);
                HospitalDB.Instance.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }


        public Patient Get(long patientId)
        {
            try
            {
                Patient oldPatient = (from pat in HospitalDB.Instance.Patients
                                      where pat.PatientId == patientId
                                      select pat)
                                      .Include(pat => pat.User)
                                      .Include(pat => pat.User.RegisteredUser)
                                      .Include(pat => pat.MedicalRecord)
                                      .Include(pat => pat.MedicalRecord.Anamnesis)
                                      .Include(pat => pat.MedicalRecord.Anamnesis.Prescriptions.Select(prsc => prsc.Drug))
                                      .First();
                return oldPatient;
            }
            catch (Exception e)
            {
                MessageBox.Show("error");
            }
            return null;
        }

        public void Update(Patient patient)
        {
            try
            {
                Patient oldPatient = HospitalDB.Instance.Patients.Find(patient.PatientId);
                if (oldPatient != null)
                {
                    patient.User.RegisteredUser.Username = oldPatient.User.RegisteredUser.Username;
                    patient.User.RegisteredUser.Password = oldPatient.User.RegisteredUser.Password;

                    patient.User.Address = oldPatient.User.Address;
                    patient.User.DateOfBirth = oldPatient.User.DateOfBirth;
                    patient.User.EMail = oldPatient.User.EMail;
                    patient.User.FirstName = oldPatient.User.FirstName;
                    patient.User.Jmbg = oldPatient.User.Jmbg;
                    patient.User.LastName = oldPatient.User.LastName;
                    patient.User.PhoneNumber = oldPatient.User.PhoneNumber;
                    patient.User.RelationshipStatus = oldPatient.User.RelationshipStatus;
                    patient.User.Sex = oldPatient.User.Sex;
                    HospitalDB.Instance.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("patient repository update Error");
            }
        }

        public List<Patient> GetAll()
        {
            try
            {
                return (from pat in HospitalDB.Instance.Patients select pat)
                    .Include(pat => pat.User)
                    .Include(pat => pat.User.RegisteredUser)
                    .Include(pat => pat.MedicalRecord)
                    .Include(pat => pat.MedicalRecord.Anamnesis)
                    .Include(pat => pat.MedicalRecord.Anamnesis.Prescriptions.Select(prsc => prsc.Drug))
                    .ToList();
            }
            catch
            {
                MessageBox.Show("Error while getting patient list, returning null");
            }
            return null;
        }

        public List<Patient> GetAllByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
        //TO DO: add this one and upper to diagram, implement this

        public bool IsMalicious(Patient patient)
        {
            HospitalDB.Instance.SaveChanges();
            return patient.SchedulingAttempts >= 10;
        }

        public void BanPatient(Patient patient)
        {
            patient.User.RegisteredUser.UserType = Enums.UserType.BANNNED_USER;
            foreach (Appointment appointment in patient.Appointments)
            {
                appointment.AppointmentStatus = Enums.AppointmentStatus.CANCELED;
            }
            HospitalDB.Instance.SaveChanges();
        }

        public List<Patient> GetWeekActivePatients()
        {
            return (from pat in HospitalDB.Instance.Patients
                    where pat.User.RegisteredUser.UserType != Enums.UserType.BANNNED_USER
&& pat.SchedulingAttempts != 0
                    select pat)
                    .Include(pat => pat.User)
                    .Include(pat => pat.User.RegisteredUser)
                    .Include(pat => pat.MedicalRecord)
                    .Include(pat => pat.MedicalRecord.Anamnesis)
                    .Include(pat => pat.MedicalRecord.Anamnesis.Prescriptions.Select(prsc => prsc.Drug))
                    .ToList();
        }

        public void Delete(long patientId)//TO DO: change the order, delete prescriptions also
        {
            try
            {
                Patient patient = Get(patientId);
                HospitalDB.Instance.RegisteredUsers.Remove(patient.User.RegisteredUser);
                HospitalDB.Instance.Users.Remove(patient.User);
                HospitalDB.Instance.Anamnesis.Remove(patient.MedicalRecord.Anamnesis);
                HospitalDB.Instance.MedicalRecords.Remove(patient.MedicalRecord);
                HospitalDB.Instance.Patients.Remove(patient);
                HospitalDB.Instance.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}