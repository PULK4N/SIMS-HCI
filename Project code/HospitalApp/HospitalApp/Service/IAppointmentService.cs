// File:    IAppointmentService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:24:48 AM
// Purpose: Definition of Interface IAppointmentService

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public interface IAppointmentService : IEntityService<Appointment>
    {
        List<Appointment> GetAllByDoctorId(long doctorId);

        bool PatientScheduleAppointment(Appointment appointment);

        bool PatientReScheduleAppointment(Appointment appointment);

        List<Appointment> GetAllByPatientId(long patientId);

        List<Appointment> GetAllCompletedByPatientId(long patientId);
        List<Appointment> GetAllByPatientRefered(long patientId);
        List<Appointment> GetAllCompletedOrReviewedByPatient(long patientId);
    }
}