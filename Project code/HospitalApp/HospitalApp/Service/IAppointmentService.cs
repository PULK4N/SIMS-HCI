// File:    IAppointmentService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:24:48 AM
// Purpose: Definition of Interface IAppointmentService

using System;
using System.Collections.Generic;

public interface IAppointmentService
{
   bool DoctorCreateAppointment(Appointment appointment);
   
   bool DoctorUpdateAppointment(Appointment appointment);
   
   bool DoctorDeleteAppointment(Appointment appointment);
   
   List<Appointment> DoctorListAppointments(long doctorId);
   
   Appointment GetById(long id);
   
   bool PatientScheduleAppointment(Appointment appointment);
   
   bool PatientCancelAppointment(Appointment appointment);
   
   bool PatientReScheduleAppointment(Appointment appointment);
   
   List<Appointment> PatentListAppointments(long patientID);
   
   List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment);

}