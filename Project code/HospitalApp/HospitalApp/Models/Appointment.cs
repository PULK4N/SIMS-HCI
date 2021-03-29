// File:    Appointment.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 8:02:58 PM
// Purpose: Definition of Class Appointment

using System;

public class Appointment
{
   public long id;
   public DateTime begining;
   public DateTime end;
   public Enums.AppointmentType appointmentType;
   public Enums.AppointmentStatus appointmentStatus;
   
   public Patient patient;
   public Doctor doctor;
   public GuestPatient guestPatient;
   public Room room;

}