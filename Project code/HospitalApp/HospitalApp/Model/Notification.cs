// File:    Notification.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 2:04:31 PM
// Purpose: Definition of Class Notification

using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Model
{
    public class Notification
    {
        [Key]
        public long NotificationId { get; set; }
        [StringLength(1000)]
        public string Information { get; set; }
        public User User { get; set; }

    }
}