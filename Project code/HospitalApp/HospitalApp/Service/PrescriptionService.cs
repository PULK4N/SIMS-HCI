// File:    PrescriptionService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class PrescriptionService

using System;
using System.Collections.Generic;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }

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