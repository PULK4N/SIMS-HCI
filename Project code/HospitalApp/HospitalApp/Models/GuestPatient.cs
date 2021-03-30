// File:    GuestPatient.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:45:48 AM
// Purpose: Definition of Class GuestPatient

using System;
using System.ComponentModel.DataAnnotations;

public class GuestPatient
{
    [Key]
    public int guestPatientId{ get; set; }
    public DateTime arrivalDate{ get; set; }
    public String emergencyInfo{ get; set; }
    public Appointment appointment{ get; set; }
    public User user{ get; set; }

}