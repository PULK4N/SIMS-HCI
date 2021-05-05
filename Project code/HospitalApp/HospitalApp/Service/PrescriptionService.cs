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
        return _prescriptionRepository.CreatePrescription(prescription);
    }

    public bool DeletePrescription(Prescription prescription)
    {
        return _prescriptionRepository.DeletePrescription(prescription);
    }

    public List<Prescription> GetPatientPrescriptions(long patientId)
    {
        return _prescriptionRepository.GetPatientPrescriptions(patientId);
    }

    public Prescription GetPrescription(long prescriptionId)
    {
        return _prescriptionRepository.GetPrescription(prescriptionId);
    }

    public bool UpdatePrescription(Prescription prescription)
    {
        return _prescriptionRepository.UpdatePrescription(prescription);
    }
}