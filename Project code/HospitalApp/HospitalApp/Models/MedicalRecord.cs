// File:    MedicalRecord.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 12:30:36 PM
// Purpose: Definition of Class MedicalRecord

using System;

public class MedicalRecord
{
   private long id;
   private DateTime timeOf;
   private String description;
   
   public Anamnesis anamnesis;
   
   public Anamnesis Anamnesis
   {
      get
      {
         return anamnesis;
      }
      set
      {
         if (this.anamnesis == null || !this.anamnesis.Equals(value))
         {
            if (this.anamnesis != null)
            {
               Anamnesis oldAnamnesis = this.anamnesis;
               this.anamnesis = null;
               oldAnamnesis.RemoveMedicalRecord(this);
            }
            if (value != null)
            {
               this.anamnesis = value;
               this.anamnesis.AddMedicalRecord(this);
            }
         }
      }
   }

}