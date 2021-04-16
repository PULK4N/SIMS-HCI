// File:    IMedicalRecordService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:25:51 AM
// Purpose: Definition of Interface IMedicalRecordService

using System;

public interface IMedicalRecordService
{
   bool CreateMedicalRecord(MedicalRecord medicalRecord);
   
   bool UpdateMedicalRecord(MedicalRecord medicalRecord);
   
   bool DeleteMedicalRecord(MedicalRecord medicalRecord);
   
   MedicalRecord GetMedicalRecord(long medicalRecordId);

}