// File:    GuestPatient.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:45:48 AM
// Purpose: Definition of Class GuestPatient

using System;
using System.ComponentModel.DataAnnotations;

public class GuestPatient
{
    [Key]
    public int GuestPatientId{ get; set; }
    [Required]
    public DateTime ArrivalDate{ get; set; }
    public String EmergencyInfo{ get; set; }
    [Required]
    public Appointment Appointment{ get; set; }
    [Required]
    public User User{ get; set; }

}