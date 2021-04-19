// File:    IAppointmentRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IAppointmentRepository

using System;
using System.Collections.Generic;

public interface IAppointmentRepository
{
   bool DoctorCreateAppointment(Appointment appointment);
   
   bool DoctorUpdateAppointment(Appointment appointment);
   
   bool DoctorDeleteAppointment(Appointment appointment);
   
   List<Appointment> DoctorListAppointments(long doctorId);
   
   Appointment GetById(long id);
   
   bool PatientScheduleAppointment(Appointment appointment);
   
   bool PatientCancelAppointment(Appointment appointment);
   
   bool PatientReScheduleAppointment(Appointment appointment);
   
   List<Appointment> PatientListAppointments(Patient patient);
   
   List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment);

}