// File:    Appointment.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 8:02:58 PM
// Purpose: Definition of Class Appointment

using System;
using System.ComponentModel.DataAnnotations;

public class Appointment
{
    [Key]
    public long AppointmentId{ get; set; }
    public DateTime Begining{ get; set; }
    public DateTime End{ get; set; }
    public Enums.AppointmentType AppointmentType{ get; set; }
    public Enums.AppointmentStatus AppointmentStatus{ get; set; }
    
    public Patient Patient{ get; set; }
    public Doctor Doctor{ get; set; }
    public long GuestPatientId{ get; set; }

    public Room Room{ get; set; }

}