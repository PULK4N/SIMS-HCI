// File:    IAnamnesisService.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:25:48 AM
// Purpose: Definition of Interface IAnamnesisService

using System;
using System.Collections.Generic;

public interface IAnamnesisService
{
   bool CreateAnamnesis(Anamnesis anamnesis);
   
   bool UpdateAnamnesis(Anamnesis anamnesis);
   
   bool DeleteAnamnesis(Anamnesis anamnesis);
   
   Anamnesis GetAnamnesis(long anamnesisId);
    Anamnesis GetAnamnesis(Anamnesis anamnesis);


   List<Anamnesis> GetAllPatientAnamnesis(long patientId);

}