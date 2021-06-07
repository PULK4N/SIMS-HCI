/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;

namespace HospitalApp.Controller
{
    public class GuestPatientController : IEntityController<GuestPatient>
    {
        private readonly IGuestPatientService _guestPatientService;

        public GuestPatientController(IGuestPatientService guestPatientService)
        {
            _guestPatientService = guestPatientService;
        }

        public void Create(GuestPatient guestPatient)
        {
            _guestPatientService.Create(guestPatient);
        }

        public GuestPatient Get(long guestPatientId)
        {
            return _guestPatientService.Get(guestPatientId);
        }

        public void Update(GuestPatient guestPatient)
        {
            _guestPatientService.Update(guestPatient);
        }

        public void Delete(long guestPatientId)
        {
            _guestPatientService.Delete(guestPatientId);
        }

        public List<GuestPatient> GetAll()
        {
            return _guestPatientService.GetAll();
        }
    }
}