// File:    Patient.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:00:30 AM
// Purpose: Definition of Class Patient

using System;

public class Patient
{
   private long patientId;
   
   public Patient(GuestPatient patient)
   {
      throw new NotImplementedException();
   }
   
   public MedicalRecord medicalRecord;
   public Appointment[] appointment;
   public User user;

}