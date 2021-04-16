// File:    MedicalRecord.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 4:13:07 PM
// Purpose: Definition of Class MedicalRecord

using System;

public class MedicalRecord
{
   public long medicalRecordId;
   public float lastMesuredHeight;
   public float lastMesuredWeight;
   
   public Prescription prescription;
   public System.Collections.Generic.List<Anamnesis> anamnesis;
   
   public System.Collections.Generic.List<Anamnesis> Anamnesis
   {
      get
      {
         if (anamnesis == null)
            anamnesis = new System.Collections.Generic.List<Anamnesis>();
         return anamnesis;
      }
      set
      {
         RemoveAllAnamnesis();
         if (value != null)
         {
            foreach (Anamnesis oAnamnesis in value)
               AddAnamnesis(oAnamnesis);
         }
      }
   }
   
   
   public void AddAnamnesis(Anamnesis newAnamnesis)
   {
      if (newAnamnesis == null)
         return;
      if (this.anamnesis == null)
         this.anamnesis = new System.Collections.Generic.List<Anamnesis>();
      if (!this.anamnesis.Contains(newAnamnesis))
         this.anamnesis.Add(newAnamnesis);
   }
   
   
   public void RemoveAnamnesis(Anamnesis oldAnamnesis)
   {
      if (oldAnamnesis == null)
         return;
      if (this.anamnesis != null)
         if (this.anamnesis.Contains(oldAnamnesis))
            this.anamnesis.Remove(oldAnamnesis);
   }
   
   public void RemoveAllAnamnesis()
   {
      if (anamnesis != null)
         anamnesis.Clear();
   }

}