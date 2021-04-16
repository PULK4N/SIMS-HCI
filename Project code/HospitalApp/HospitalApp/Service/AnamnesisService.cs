// File:    AnamnesisService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class AnamnesisService

using System;
using System.Collections.Generic;

public class AnamnesisService : IAnamnesisService
{
    private IAnamnesisRepository _anamnesisRepository;

    public AnamnesisService(IAnamnesisRepository anamnesisRepository)
    {
        _anamnesisRepository = anamnesisRepository;
    }

    public bool CreateAnamnesis(Anamnesis anamnesis)
    {
        throw new NotImplementedException();
    }

    public bool DeleteAnamnesis(Anamnesis anamnesis)
    {
        throw new NotImplementedException();
    }

    public List<Anamnesis> GetAllPatientAnamnesis(long patientId)
    {
        throw new NotImplementedException();
    }

    public Anamnesis GetAnamnesis(long anamnesisId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateAnamnesis(Anamnesis anamnesis)
    {
        throw new NotImplementedException();
    }

}