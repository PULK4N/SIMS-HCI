// File:    AppointmentController.cs
// Author:  Nikola
// Created: Wednesday, April 14, 2021 11:06:07 PM
// Purpose: Definition of Class AppointmentController

using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;

namespace HospitalApp.Controller
{
    public class AppointmentController : IEntityController<Appointment>
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public void Create(Appointment appointment)
        {
            _appointmentService.Create(appointment);
        }

        public void Update(Appointment appointment)
        {
            _appointmentService.Update(appointment);
        }

        public void Delete(long appointmentId)
        {
            _appointmentService.Delete(appointmentId);
        }

        public List<Appointment> GetAllByDoctorId(long doctorId)
        {
            return _appointmentService.GetAllByDoctorId(doctorId);
        }

        public Appointment Get(long appointmentId)
        {
            return _appointmentService.Get(appointmentId);
        }
        //TO DO: move to another class, refractor
        public bool PatientScheduleAppointment(Appointment appointment)
        {
            return _appointmentService.PatientScheduleAppointment(appointment);
        }


        public bool PatientReScheduleAppointment(Appointment appointment)
        {
            return _appointmentService.PatientReScheduleAppointment(appointment);
        }

        public List<Appointment> GetAllByPatientId(long patientId)
        {
            return _appointmentService.GetAllByPatientId(patientId);
        }

        public List<Appointment> GetAllCompletedByPatientId(long patientId)
        {
            return _appointmentService.GetAllCompletedByPatientId(patientId);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentService.GetAll();
        }
    }
}