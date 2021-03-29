// File:    IHospitalDB.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 4:28:07 PM
// Purpose: Definition of Interface IHospitalDB

using System;
using System.Collections.Generic;

public interface IHospitalDB
{
   bool CreateAppointment(Appointment appointment);
   
   bool DeleteAppointment(long doctorID);
   
   bool ReScheduleAppointment(Appointment appointment);
   
   Appointment GetAppointmentByID(long appointmentID);
   
   List<Appointment> GetAppointmentsByPatientID(long patientID);
   
   List<Appointment> GetAppointmentByDateAndPatientID(DateTime date, long patientID);
   
   bool ChangeAppointmentStatus(long appointMentID, Enums.AppointmentStatus status);
   
   bool CreatePatient();
   
   bool UpdatePatient();
   
   bool DeletePatient();
   
   Patient GetPatientByID(long patientID);
   
   List<Patient> GetPatientByDoctorID(long doctorID);
   
   List<Patient> GetAllPatients();

}