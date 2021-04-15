// File:    Patient.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:00:30 AM
// Purpose: Definition of Class Patient

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Patient
{
    public Patient(){}
    public Patient(GuestPatient patient)
    {
        this.User = patient.User;
    }

    [Key]
    public long PatientId{ get; set; }

    public List<Appointment> appointment;
    public MedicalRecord MedicalRecord{ get; set; }

    [Required]
    public User User { get; set; }

    public List<Prescription> prescription;

    #region Getters and setters

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

    #endregion

}