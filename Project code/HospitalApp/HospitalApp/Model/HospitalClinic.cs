// File:    HospitalClinic.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 9:58:44 PM
// Purpose: Definition of Class HospitalClinic

using System;
using System.ComponentModel.DataAnnotations;

public class HospitalClinic
{
    [Key]
    public long HospitalClinicId{ get; set; }
    [Required]
    public String Name{ get; set; }
    [Required]
    public String Address{ get; set; }
    [Required]
    public String PhoneNumber{ get; set; }

}