// File:    PrescriptionController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:28:52 PM
// Purpose: Definition of Class PrescriptionController

using System;
using System.Collections.Generic;

public class PrescriptionController
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    public bool CreatePrescription(int dosage, String usage, String period, DateTime date)
    {
       throw new NotImplementedException();
    }
    
    public bool UpdatePrescription(int dosage, String usage, String period, DateTime date)
    {
       throw new NotImplementedException();
    }
    
    public bool DeletePrescription(Prescription prescription)
    {
       throw new NotImplementedException();
    }
    
    public Prescription GetPrescription(long prescriptionId)
    {
       throw new NotImplementedException();
    }
    
    public List<Prescription> GetAllPatientPrescriptions(long patientId)
    {
       throw new NotImplementedException();
    }
}