// File:    Patient.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:00:30 AM
// Purpose: Definition of Class Patient

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApp.Model
{
    public class Patient
    {
        public Patient() { }
        public Patient(GuestPatient patient)
        {
            User = patient.User;
        }

        public Patient(long patientId, List<Appointment> appointments, MedicalRecord medicalRecord, User user, List<Appointment> newAppointments)
        {
            PatientId = patientId;
            Appointments = newAppointments;
            MedicalRecord = medicalRecord;
            User = user;
            Appointments = appointments;
            SchedulingAttempts = 0;
        }

        [Key]
        public long PatientId { get; set; }

        public int SchedulingAttempts { get; set; }
        public string alergies { get; set; }

        public List<Appointment> appointments;
        public MedicalRecord MedicalRecord { get; set; }

        [Required, Index("uniqueUserPat", IsUnique = true)]
        public User User { get; set; }


        public List<Appointment> Appointments
        {
            get
            {
                if (appointments == null)
                    appointments = new List<Appointment>();
                return appointments;
            }
            set
            {
                RemoveAllAppointments();
                if (value != null)
                {
                    foreach (Appointment Appointment in value)
                        AddAppointment(Appointment);
                }
            }
        }

        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (appointments == null)
                appointments = new List<Appointment>();
            if (!appointments.Contains(newAppointment))
                appointments.Add(newAppointment);
        }


        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (appointments != null)
                if (appointments.Contains(oldAppointment))
                    appointments.Remove(oldAppointment);
        }

        public void RemoveAllAppointments()
        {
            if (appointments != null)
                appointments.Clear();
        }

        public override string ToString()
        {
            return User.FirstName + " " + User.LastName;
        }
    }
}