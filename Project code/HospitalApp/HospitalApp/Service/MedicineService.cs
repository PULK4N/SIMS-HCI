// File:    MedicineService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class MedicineService

using System;
using System.Collections.Generic;

public class MedicineService : IMedicineService
{
    private IMedicineRepository _medicineRepository;

    public MedicineService(IMedicineRepository medicineRepository)
    {
        _medicineRepository = medicineRepository;
    }

    public bool CreateMedicine(Prescription prescription)
    {
        throw new NotImplementedException();
    }

    public bool DeleteMedicine(Medicine medicine)
    {
        throw new NotImplementedException();
    }

    public List<Medicine> GetAllPatientMedicines(Medicine medicine)
    {
        throw new NotImplementedException();
    }

    public Medicine GetMedicine(Medicine medicine)
    {
        throw new NotImplementedException();
    }

    public bool UpdateMedicine(Medicine medicine)
    {
        throw new NotImplementedException();
    }
}