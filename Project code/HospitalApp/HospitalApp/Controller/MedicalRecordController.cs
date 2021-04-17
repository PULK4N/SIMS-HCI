// File:    MedicalRecordController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:01:14 PM
// Purpose: Definition of Class MedicalRecordController

using System;

public class MedicalRecordController
{
    private readonly IMedicalRecordService _medicalRecordService;

    public MedicalRecordController(IMedicalRecordService medicalRecordService)
    {
        _medicalRecordService = medicalRecordService;
    }

    public bool CreateMedicalRecord(float lastMeasuredHeight, float lastMeasuredWeight)
    {
       throw new NotImplementedException();
    }
    
    public bool UpdateMedicalRecord(float lastMeasuredHeight, float lastMeasuredWeight)
    {
       throw new NotImplementedException();
    }
    
    public bool DeleteMedicalRecord(MedicalRecord medicalRecord)
    {
       throw new NotImplementedException();
    }
    
    public MedicalRecord GetMedicalRecord(long medicalRecordId)
    {
       throw new NotImplementedException();
    }
}