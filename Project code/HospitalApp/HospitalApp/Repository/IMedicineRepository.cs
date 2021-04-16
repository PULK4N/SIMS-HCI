// File:    IMedicineRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IMedicineRepository

using System;
using System.Collections.Generic;

public interface IMedicineRepository
{
   bool CreateMedicine(Prescription prescription);
   
   bool UpdateMedicine(Medicine medicine);
   
   bool DeleteMedicine(Medicine medicine);
   
   Medicine GetMedicine(Medicine medicine);
   
   List<Medicine> GetAllPatientMedicines(Medicine medicine);

}