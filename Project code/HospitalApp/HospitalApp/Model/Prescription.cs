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

    public System.Collections.Generic.List<Medicine> medicine;

    public System.Collections.Generic.List<Medicine> Medicine
    {
        get
        {
            if (medicine == null)
                medicine = new System.Collections.Generic.List<Medicine>();
            return medicine;
        }
        set
        {
            RemoveAllMedicine();
            if (value != null)
            {
                foreach (Medicine oMedicine in value)
                    AddMedicine(oMedicine);
            }
        }
    }


    public void AddMedicine(Medicine newMedicine)
    {
        if (newMedicine == null)
            return;
        if (this.medicine == null)
            this.medicine = new System.Collections.Generic.List<Medicine>();
        if (!this.medicine.Contains(newMedicine))
            this.medicine.Add(newMedicine);
    }


    public void RemoveMedicine(Medicine oldMedicine)
    {
        if (oldMedicine == null)
            return;
        if (this.medicine != null)
            if (this.medicine.Contains(oldMedicine))
                this.medicine.Remove(oldMedicine);
    }

    public void RemoveAllMedicine()
    {
        if (medicine != null)
            medicine.Clear();
    }

    public Prescription() {}

    public Prescription(/*long prescriptionId,*/ int dosage, string usage, string period, DateTime date, List<Medicine> medicine)
    {
        //PrescriptionId = prescriptionId;
        Dosage = dosage;
        Usage = usage;
        Period = period;
        Date = date;
        Medicine = medicine;
    }
}