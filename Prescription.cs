// File:    Prescription.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:35:48 PM
// Purpose: Definition of Class Prescription

using System;

public class Prescription
{
   public long prescriotpionId;
   public int dosage;
   public string usage;
   public string period;
   public DateTime date;
   
   public System.Collections.Generic.List<Medicine> medicine;
   
   public System.Collections.Generic.List<Medicine> Medicine
   {
      get
      {
         if (medicine == null)
            medicine = new System.Collections.Generic.List<Medicine>();
         return medicine;
      }
      set
      {
         RemoveAllMedicine();
         if (value != null)
         {
            foreach (Medicine oMedicine in value)
               AddMedicine(oMedicine);
         }
      }
   }
   
   
   public void AddMedicine(Medicine newMedicine)
   {
      if (newMedicine == null)
         return;
      if (this.medicine == null)
         this.medicine = new System.Collections.Generic.List<Medicine>();
      if (!this.medicine.Contains(newMedicine))
         this.medicine.Add(newMedicine);
   }
   
   
   public void RemoveMedicine(Medicine oldMedicine)
   {
      if (oldMedicine == null)
         return;
      if (this.medicine != null)
         if (this.medicine.Contains(oldMedicine))
            this.medicine.Remove(oldMedicine);
   }
   
   public void RemoveAllMedicine()
   {
      if (medicine != null)
         medicine.Clear();
   }

}