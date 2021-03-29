// File:    Doctor.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 7:46:22 PM
// Purpose: Definition of Class Doctor

using System;

public class Doctor
{
   private long id;
   private String aboutMe;
   
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
   public Appointment[] appointment;
   public User user;

}