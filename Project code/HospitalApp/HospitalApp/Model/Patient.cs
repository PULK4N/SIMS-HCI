// File:    Patient.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:00:30 AM
// Purpose: Definition of Class Patient

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Patient
{
    public Patient(){}
    public Patient(GuestPatient patient)
    {
        this.User = patient.User;
    }

    [Key]
    public long PatientId{ get; set; }

    public List<Appointment> appointments;
    public MedicalRecord MedicalRecord{ get; set; }

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
        if (this.appointments == null)
            this.appointments = new List<Appointment>();
        if (!this.appointments.Contains(newAppointment))
            this.appointments.Add(newAppointment);
    }


    public void RemoveAppointment(Appointment oldAppointment)
    {
        if (oldAppointment == null)
            return;
        if (this.appointments != null)
            if (this.appointments.Contains(oldAppointment))
                this.appointments.Remove(oldAppointment);
    }

    public void RemoveAllAppointments()
    {
        if (appointments != null)
            appointments.Clear();
    }


}