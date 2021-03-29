// File:    Patient.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:00:30 AM
// Purpose: Definition of Class Patient

using System;

public class Patient
{
   private long id;
   
   public Appointment[] appointment;
   public Anamnesis anamnesis;
   public System.Collections.Generic.List<Prescription> prescription;
   
   public System.Collections.Generic.List<Prescription> Prescription
   {
      get
      {
         if (prescription == null)
            prescription = new System.Collections.Generic.List<Prescription>();
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
         this.prescription = new System.Collections.Generic.List<Prescription>();
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
   public User user;

}