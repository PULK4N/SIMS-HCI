// File:    Medicine.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:13:02 PM
// Purpose: Definition of Class Medicine

using System;

namespace HospitalApp.Model
{
    public class Drug
    {
        public long DrugId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Enums.DrugStatus DrugStatus { get; set; }
    }
}