// File:    Anamnesis.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 12:30:36 PM
// Purpose: Definition of Class Anamnesis

using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Model
{
    public class Anamnesis
    {
        [Key]
        public long AnamnesisId { get; set; }
        public DateTime TimeOf { get; set; }
        public string Description { get; set; }

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
            if (prescriptions == null)
                prescriptions = new System.Collections.Generic.List<Prescription>();
            if (!prescriptions.Contains(newPrescription))
                prescriptions.Add(newPrescription);
        }

        public void RemovePrescription(Prescription oldPrescription)
        {
            if (oldPrescription == null)
                return;
            if (prescriptions != null)
                if (prescriptions.Contains(oldPrescription))
                    prescriptions.Remove(oldPrescription);
        }

        public void RemoveAllPrescriptions()
        {
            if (prescriptions != null)
            {
                prescriptions.Clear();
            }
        }
    }
}