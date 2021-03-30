// File:    Appointment.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 8:02:58 PM
// Purpose: Definition of Class Appointment

using System;
using System.ComponentModel.DataAnnotations;

public class Appointment
{
    [Key]
    public long appointmentId{ get; set; }
    public DateTime begining{ get; set; }
    public DateTime end{ get; set; }
    public Enums.AppointmentType appointmentType{ get; set; }
    public Enums.AppointmentStatus appointmentStatus{ get; set; }
    
    public Patient patient{ get; set; }
    public Doctor doctor{ get; set; }
    public long guestPatientId{ get; set; }
//    public Room room{ get; set; }

}