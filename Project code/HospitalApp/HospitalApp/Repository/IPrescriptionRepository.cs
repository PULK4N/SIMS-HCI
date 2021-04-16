// File:    IPrescriptionRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IPrescriptionRepository

using System;
using System.Collections.Generic;

public interface IPrescriptionRepository
{
   bool CreatePrescription(Prescription prescription);
   
   bool UpdatePrescription(Prescription prescription);
   
   bool DeletePrescription(Prescription prescription);
   
   Prescription GetPrescription(long prescriptionId);
   
   List<Prescription> GetAllPatientPrescriptions(long patientId);

}