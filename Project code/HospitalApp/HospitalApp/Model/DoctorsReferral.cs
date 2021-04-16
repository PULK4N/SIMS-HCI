// File:    DoctorsReferral.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:38:22 PM
// Purpose: Definition of Class DoctorsReferral

using System;
using System.ComponentModel.DataAnnotations;

public class DoctorsReferral
{
    [Key]
    public long DoctorReferralId { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }

}