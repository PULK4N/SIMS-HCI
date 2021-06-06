// File:    AppointmentManager.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 4:28:07 PM
// Purpose: Definition of Class AppointmentManager

using HospitalApp.Model;
using System;
using System.Collections.Generic;

public class AppointmentManager
{
   public bool DoctorCreateAppointment()
   {
      throw new NotImplementedException();
   }
   
   public bool DoctorUpdateAppointment()
   {
      throw new NotImplementedException();
   }
   
   public bool DoctorDeleteAppointment()
   {
      throw new NotImplementedException();
   }
   
   public void DoctorListAppointments()
   {
      throw new NotImplementedException();
   }
   
   public void GetById(long id)
   {
      throw new NotImplementedException();
   }
   
   public bool PatientScheduleAppointment(Appointment appointment)
   {
      throw new NotImplementedException();
   }
   
   public bool PatientCancelAppointment(Appointment appointment)
   {
      throw new NotImplementedException();
   }
   
   public bool PatientReScheduleAppointment(Appointment appointment)
   {
      throw new NotImplementedException();
   }
   
   public List<Appointment> PatentListAppointments(long patientID)
   {
      throw new NotImplementedException();
   }
   
   public List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment)
   {
      throw new NotImplementedException();
   }

}