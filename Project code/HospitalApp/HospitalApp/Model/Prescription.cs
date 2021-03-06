// File:    Prescription.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:35:48 PM
// Purpose: Definition of Class Prescription

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Model
{
    public class Prescription
    {
        [Key]
        public long PrescriptionId { get; set; }
        public int Dosage { get; set; }
        public string Usage { get; set; }
        public string Period { get; set; }
        public DateTime Date { get; set; }
        public Drug Drug { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime HandoutDate { get; set; }


        public Prescription()
        {
            HandoutDate = DateTime.Now;
        }

        public Prescription(/*long prescriptionId,*/ int dosage, string usage, string period, DateTime date, Drug drug, Doctor doctor)
        {
            //PrescriptionId = prescriptionId;
            Dosage = dosage;
            Usage = usage;
            Period = period;
            Date = date;
            Drug = drug;
            Doctor = doctor;
            HandoutDate = DateTime.Now;
        }
    }
}