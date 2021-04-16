// File:    IMedicalRecordRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IMedicalRecordRepository

using System;

public interface IMedicalRecordRepository
{
   bool CreateMedicalRecord(MedicalRecord medicalRecord);
   
   bool UpdateMedicalRecord(MedicalRecord medicalRecord);
   
   bool DeleteMedicalRecord(MedicalRecord medicalRecord);
   
   MedicalRecord GetMedicalRecord(long medicalRecordId);

}