// File:    Anamnesis.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 12:30:36 PM
// Purpose: Definition of Class Anamnesis

using System;
using System.ComponentModel.DataAnnotations;

public class Anamnesis
{
    [Key]
    public long AnamnesisId { get; set; }
    public DateTime TimeOf { get; set; }
    public String Description { get; set; }
    public Prescription Prescription { get; set; }

}