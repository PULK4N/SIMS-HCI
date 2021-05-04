// File:    MedicalRecordContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class MedicalRecordContextDB

using System;
using System.Data.Entity;
using System.Windows;

public class MedicalRecordContextDB : IMedicalRecordRepository
{
    public MedicalRecordContextDB()
    {
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
        return HospitalDB.Instance.MedicalRecords.Find(medicalRecordId);
    }

    public bool UpdateMedicalRecord(MedicalRecord medicalRecord)
    {
        try
        {
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        catch(Exception e)
        {
            MessageBox.Show(e.Message);
        }
        return false;
    }
}