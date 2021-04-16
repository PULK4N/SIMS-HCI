// File:    MedicalRecordService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class MedicalRecordService

using System;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly IMedicalRecordRepository _medicalRecordRepository;

    public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
    {
        _medicalRecordRepository = medicalRecordRepository;
    }

    public bool CreateMedicalRecord(MedicalRecord medicalRecord)
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

    public bool UpdateMedicalRecord(MedicalRecord medicalRecord)
    {
        throw new NotImplementedException();
    }
}