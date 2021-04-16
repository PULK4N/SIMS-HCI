// File:    Appointment.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 8:02:58 PM
// Purpose: Definition of Class Appointment

using System;

public class Appointment
{
   public long appointmentId;
   public DateTime begining;
   public DateTime end;
   public AppointmentStatus appointmentStatus;
   public AppointmentType appointmentType;
   
   public Patient patient;
   public Doctor doctor;
   public GuestPatient guestPatient;
   public Room room;

}