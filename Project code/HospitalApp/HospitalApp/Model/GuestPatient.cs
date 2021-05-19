// File:    GuestPatient.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:45:48 AM
// Purpose: Definition of Class GuestPatient

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApp.Model
{
    public class GuestPatient
    {
        [Key]
        public int GuestPatientId { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        public string EmergencyInfo { get; set; }
        [Required]
        public Appointment Appointment { get; set; }
        [Required, Index("uniqueUserGuestUser", IsUnique = true)]
        public User User { get; set; }

    }
}