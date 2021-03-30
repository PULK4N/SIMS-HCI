// File:    Prescription.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:35:48 PM
// Purpose: Definition of Class Prescription

using System;

public class Prescription
{
   public long prescriptionId{ get; set; }
   public int dosage{ get; set; }
   public string usage{ get; set; }
   public string period{ get; set; }
   public DateTime date{ get; set; }

}