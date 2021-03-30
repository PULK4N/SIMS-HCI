// File:    Anamnesis.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 4:13:07 PM
// Purpose: Definition of Class Anamnesis

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;

public class Anamnesis
{
    [Key]
    public long anamnesisId{ get; set; }
    public float lastMesuredHeight{ get; set; }
    public float lastMesuredWeight{ get; set; }
   
   public List<MedicalRecord> medicalRecord;
   
   public List<MedicalRecord> MedicalRecord
   {
      get
      {
         if (medicalRecord == null)
            medicalRecord = new List<MedicalRecord>();
         return medicalRecord;
      }
      set
      {
         RemoveAllMedicalRecord();
         if (value != null)
         {
            foreach (MedicalRecord oMedicalRecord in value)
               AddMedicalRecord(oMedicalRecord);
         }
      }
   }
   
   
   public void AddMedicalRecord(MedicalRecord newMedicalRecord)
   {
      if (newMedicalRecord == null)
         return;
      if (this.medicalRecord == null)
         this.medicalRecord = new List<MedicalRecord>();
      if (!this.medicalRecord.Contains(newMedicalRecord))
      {
         this.medicalRecord.Add(newMedicalRecord);
         newMedicalRecord.Anamnesis = this;
      }
   }
   
   
   public void RemoveMedicalRecord(MedicalRecord oldMedicalRecord)
   {
      if (oldMedicalRecord == null)
         return;
      if (this.medicalRecord != null)
         if (this.medicalRecord.Contains(oldMedicalRecord))
         {
            this.medicalRecord.Remove(oldMedicalRecord);
            oldMedicalRecord.Anamnesis = null;
         }
   }
   
   public void RemoveAllMedicalRecord()
   {
      if (medicalRecord != null)
      {
         ArrayList tmpMedicalRecord = new ArrayList();
         foreach (MedicalRecord oldMedicalRecord in medicalRecord)
            tmpMedicalRecord.Add(oldMedicalRecord);
         medicalRecord.Clear();
         foreach (MedicalRecord oldMedicalRecord in tmpMedicalRecord)
            oldMedicalRecord.Anamnesis = null;
         tmpMedicalRecord.Clear();
      }
   }
   public Patient patient;

}