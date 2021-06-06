// File:    Appointment.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 8:02:58 PM
// Purpose: Definition of Class Appointment

using Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Model
{
    public class Appointment
    {
        public Appointment()
        {
        }

        public Appointment(/*long appointmentId,*/ DateTime begining, DateTime end, AppointmentType appointmentType, AppointmentStatus appointmentStatus, Patient patient, Doctor doctor, Room room)
        {
            //AppointmentId = appointmentId;
            Beginning = begining;
            End = end;
            AppointmentType = appointmentType;
            AppointmentStatus = appointmentStatus;
            Patient = patient;
            Doctor = doctor;
            Room = room;
        }

        [Key]
        public long AppointmentId { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        //public GuestPatient GuestPatient { get; set; }

        public Room Room { get; set; }

    }
}