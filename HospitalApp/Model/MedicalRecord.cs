// File:    MedicalRecord.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 4:13:07 PM
// Purpose: Definition of Class MedicalRecord

using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Model
{
    public class MedicalRecord
    {
        [Key]
        public long MedicalRecordId { get; set; }
        public float LastMesuredHeight { get; set; }
        public float LastMesuredWeight { get; set; }

        public Anamnesis Anamnesis { get; set; }

    }
}