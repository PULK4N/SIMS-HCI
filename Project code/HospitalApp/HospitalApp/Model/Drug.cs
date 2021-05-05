// File:    Medicine.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:13:02 PM
// Purpose: Definition of Class Medicine

using System;

public class Drug
{
    public long DrugId { get; set; }
    public String Name { get; set; }
    public String Details { get; set; }
    public Enums.DrugStatus DrugStatus { get; set; }
}