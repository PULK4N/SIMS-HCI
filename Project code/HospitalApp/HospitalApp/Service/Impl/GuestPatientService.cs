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

namespace HospitalApp.Service
{
    public class GuestPatientService : IGuestPatientService
    {
        private readonly IGuestPatientRepository _guestPatientRepository;

        public GuestPatientService(IGuestPatientRepository guestPatientRepository)
        {
            _guestPatientRepository = guestPatientRepository;
        }

        public void Create(GuestPatient guestPatient)
        {
            _guestPatientRepository.Create(guestPatient);
        }

        public void Delete(long patientId)
        {
            _guestPatientRepository.Delete(patientId);
        }

        public GuestPatient Get(long guestPatientId)
        {
            return _guestPatientRepository.Get(guestPatientId);
        }

        public List<GuestPatient> GetAll()
        {
            return _guestPatientRepository.GetAll();
        }

        public void Update(GuestPatient patient)
        {
            _guestPatientRepository.Update(patient);
        }
    }
}