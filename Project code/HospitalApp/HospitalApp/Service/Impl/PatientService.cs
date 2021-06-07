/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using Enums;
using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalApp.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void Create(Patient patient){
            _patientRepository.Create(patient);
        }

        public void Delete(long patientId)
        {
            _patientRepository.Delete(patientId);
        }

        public Patient Get(long patientId)
        {
            return _patientRepository.Get(patientId);
        }

        public void Update(Patient patient)
        {
            Patient oldPatient = _patientRepository.Get(patient.PatientId);
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
                patient.User.MaritalStatus = oldPatient.User.MaritalStatus;
                patient.User.Sex = oldPatient.User.Sex;
            }
            _patientRepository.Update(patient);
        }

        public List<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public bool IsMalicious(Patient patient)
        {
            ++patient.SchedulingAttempts;
            bool IsMalicious = _patientRepository.IsMalicious(patient);
            if (IsMalicious && IsNotBanned(patient))
            {
                BanPatient(patient);
            }
            return IsMalicious;
        }


        public async Task StartWeeklyAttemptsRestarting(CancellationToken cancellationToken)
        {

            await Task.Run(async () =>
            {
                List<Patient> patients = _patientRepository.GetWeekActivePatients();
                while (true)
                {
                    foreach (Patient patient in patients)
                    {
                        patient.SchedulingAttempts = 0;
                    }
                    HospitalDB.Instance.SaveChanges();
                    await Task.Delay(604800000, cancellationToken);
                    if (cancellationToken.IsCancellationRequested)
                        break;
                }
            });

        }

        public void BanPatient(Patient patient)
        {
            _patientRepository.BanPatient(patient);
        }
        private bool IsNotBanned(Patient patient)
        {
            return patient.User.RegisteredUser.UserType != UserType.BANNNED_USER;
        }

        public Patient GetPatientByUsername(string username)
        {
            return _patientRepository.GetPatientByUsername(username);
        }
    }
}