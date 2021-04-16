// File:    GuestPatient.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:45:48 AM
// Purpose: Definition of Class GuestPatient

using System;

public class GuestPatient
{
   public long guestPatientId;
   public DateTime arrivalDate;
   public String emergencyInfo;
   
   public Appointment appointment;
   public User user;

}