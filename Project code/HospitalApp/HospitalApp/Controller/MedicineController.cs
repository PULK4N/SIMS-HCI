// File:    MedicineController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:30:55 PM
// Purpose: Definition of Class MedicineController

using System;
using System.Collections.Generic;

public class MedicineController
{
    private readonly MedicineService _medicineService;

    public MedicineController(MedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    public bool CreateMedicine(String name, String description)
    {
       throw new NotImplementedException();
    }
    
    public bool UpdateMedicine(String name, String description)
    {
       throw new NotImplementedException();
    }
    
    public bool DeleteMedicine(Medicine medicine)
    {
       throw new NotImplementedException();
    }
    
    public Medicine GetMedicine(Medicine medicine)
    {
       throw new NotImplementedException();
    }
    
    public List<Medicine> GetAllPatientMedicines(Medicine medicine)
    {
       throw new NotImplementedException();
    }
    
}