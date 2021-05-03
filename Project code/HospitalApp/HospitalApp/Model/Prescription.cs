// File:    Prescription.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:35:48 PM
// Purpose: Definition of Class Prescription

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Prescription
{
    [Key]
    public long PrescriptionId{ get; set; }
    public int Dosage{ get; set; }
    public string Usage{ get; set; }
    public string Period{ get; set; }
    public DateTime Date{ get; set; }

    public Drug Drug;


    public Prescription() {}

    public Prescription(/*long prescriptionId,*/ int dosage, string usage, string period, DateTime date, Drug drug)
    {
        //PrescriptionId = prescriptionId;
        Dosage = dosage;
        Usage = usage;
        Period = period;
        Date = date;
        Drug = drug;
    }
}