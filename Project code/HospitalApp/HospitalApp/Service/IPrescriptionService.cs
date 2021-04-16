// File:    IPrescriptionService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:25:45 AM
// Purpose: Definition of Interface IPrescriptionService

using System;
using System.Collections.Generic;

public interface IPrescriptionService
{
   bool CreatePrescription(Prescription prescription);
   
   bool UpdatePrescription(Prescription prescription);
   
   bool DeletePrescription(Prescription prescription);
   
   Prescription GetPrescription(long prescriptionId);
   
   List<Prescription> GetAllPatientPrescriptions(long patientId);

}