// File:    IAppointmentRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IAppointmentRepository

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Repository
{
    public interface IAppointmentRepository : IEntityRepository<Appointment>
    {

        List<Appointment> GetAllByDoctor(long doctorId);

        List<Appointment> GetAllByPatient(long patientId);

        List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment);
        List<Appointment> GetAllCompletedByPatient(Patient patient);
    }
}