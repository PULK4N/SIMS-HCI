// File:    Anamnesis.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 12:30:36 PM
// Purpose: Definition of Class Anamnesis

using System;
using System.ComponentModel.DataAnnotations;

public class Anamnesis
{
    [Key]
    public long AnamnesisId { get; set; }
    public DateTime TimeOf { get; set; }
    public String Description { get; set; }

    public System.Collections.Generic.List<Prescription> prescriptions;


    public System.Collections.Generic.List<Prescription> Prescriptions
    {
        get
        {
            if (prescriptions == null)
                prescriptions = new System.Collections.Generic.List<Prescription>();
            return prescriptions;
        }
        set
        {
            RemoveAllPrescriptions();
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
        if (this.prescriptions == null)
            this.prescriptions = new System.Collections.Generic.List<Prescription>();
        if (!this.prescriptions.Contains(newPrescription))
            this.prescriptions.Add(newPrescription);
    }

    public void RemovePrescription(Prescription oldPrescription)
    {
        if (oldPrescription == null)
            return;
        if (this.prescriptions != null)
            if (this.prescriptions.Contains(oldPrescription))
                this.prescriptions.Remove(oldPrescription);
    }

    public void RemoveAllPrescriptions()
    {
        if (prescriptions != null)
        {
            prescriptions.Clear();
        }
    }
}