// File:    IMedicineService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:25:41 AM
// Purpose: Definition of Interface IMedicineService

using System;
using System.Collections.Generic;

public interface IMedicineService
{
   bool CreateMedicine(Prescription prescription);
   
   bool UpdateMedicine(Medicine medicine);
   
   bool DeleteMedicine(Medicine medicine);
   
   Medicine GetMedicine(Medicine medicine);
   
   List<Medicine> GetAllPatientMedicines(Medicine medicine);

}