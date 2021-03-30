// File:    Doctor.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 7:46:22 PM
// Purpose: Definition of Class Doctor

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Doctor
{
    [Key]
    public long doctorId { get; set; }
    public String aboutMe{ get; set; }
    
    public User user{ get; set; }

    public List<Prescription> prescription;
    public List<Appointment> appointment;
    
    public List<Prescription> Prescription
    {
       get
       {
          if (prescription == null)
             prescription = new List<Prescription>();
          return prescription;
       }
       set
       {
          RemoveAllPrescription();
          if (value != null)
          {
             foreach (Prescription oPrescription in value)
                AddPrescription(oPrescription);
          }
       }
    }

    public void AddPrescription(Prescription newPrescription)
    {
        if (newPrescription == null)
            return;
        if (this.prescription == null)
            this.prescription = new List<Prescription>();
        if (!this.prescription.Contains(newPrescription))
            this.prescription.Add(newPrescription);
    }


    public void RemovePrescription(Prescription oldPrescription)
    {
        if (oldPrescription == null)
            return;
        if (this.prescription != null)
            if (this.prescription.Contains(oldPrescription))
                this.prescription.Remove(oldPrescription);
    }

    public void RemoveAllPrescription()
    {
        if (prescription != null)
            prescription.Clear();
    }
    public List<Appointment> Appointment
    {
        get
        {
            if (appointment == null)
                appointment = new List<Appointment>();
            return appointment;
        }
        set
        {
            RemoveAllAppointment();
            if (value != null)
            {
                foreach (Appointment oAppointment in value)
                    AddAppointment(oAppointment);
            }
        }
    }

    public void AddAppointment(Appointment newAppointment)
    {
        if (newAppointment == null)
            return;
        if (this.appointment == null)
            this.appointment = new List<Appointment>();
        if (!this.appointment.Contains(newAppointment))
            this.appointment.Add(newAppointment);
    }


    public void RemoveAppointment(Appointment oldAppointment)
    {
        if (oldAppointment == null)
            return;
        if (this.appointment != null)
            if (this.appointment.Contains(oldAppointment))
                this.appointment.Remove(oldAppointment);
    }

    public void RemoveAllAppointment()
    {
        if (appointment != null)
            appointment.Clear();
    }

}