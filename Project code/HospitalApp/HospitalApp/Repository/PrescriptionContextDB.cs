// File:    PrescriptionContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class PrescriptionContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;

public class PrescriptionContextDB : DbContext, IPrescriptionRepository
{
    public bool CreatePrescription(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public bool DeletePrescription(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public List<Prescription> GetAllPatientPrescriptions(long patientId)
    {
        throw new NotImplementedException();
    }

    public Prescription GetPrescription(long prescriptionId)
    {
        throw new NotImplementedException();
    }

    public bool UpdatePrescription(Prescription prescription)
    {
        throw new NotImplementedException();
    }
}