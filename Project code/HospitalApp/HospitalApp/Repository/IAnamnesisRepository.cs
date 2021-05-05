// File:    IAnamnesisRepository.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 9:35:17 AM
// Purpose: Definition of Interface IAnamnesisRepository

using System;
using System.Collections.Generic;

public interface IAnamnesisRepository
{

   bool CreateAnamnesis(Anamnesis anamnesis);
   
   bool UpdateAnamnesis(Anamnesis anamnesis);
   
   bool DeleteAnamnesis(Anamnesis anamnesis);
   
   Anamnesis GetAnamnesis(long anamnesisId);
   Anamnesis GetAnamnesis(Anamnesis anamnesis);

    Anamnesis GetAnamnesisBy(Patient patient);
}