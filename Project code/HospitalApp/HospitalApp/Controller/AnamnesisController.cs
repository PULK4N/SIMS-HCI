// File:    AnamnesisController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 3:32:27 PM
// Purpose: Definition of Class AnamnesisController

using System;
using System.Collections.Generic;

public class AnamnesisController
{
    private readonly IAnamnesisService _anamnesisService;

    public AnamnesisController(IAnamnesisService anamnesisService)
    {
        _anamnesisService = anamnesisService;
    }

    public bool CreateAnamnesis(Anamnesis anamnesis)
    {
        return _anamnesisService.CreateAnamnesis(anamnesis);
    }
    
    public bool UpdateAnamnesis(Anamnesis anamnesis)
    {
        return _anamnesisService.UpdateAnamnesis(anamnesis);
    }
    
    public bool DeleteAnamnesis(Anamnesis anamnesis)
    {
        return _anamnesisService.DeleteAnamnesis(anamnesis);
    }
    
    public Anamnesis GetAnamnesis(long anamnesisId)
    {
        return _anamnesisService.GetAnamnesis(anamnesisId);
    }

    public Anamnesis GetAnamnesis(Anamnesis anamnesis)
    {
        return _anamnesisService.GetAnamnesis(anamnesis);
    }

    public List<Anamnesis> GetAllPatientAnamnesis(long patientId)
    {
       throw new NotImplementedException();
    }
    
}