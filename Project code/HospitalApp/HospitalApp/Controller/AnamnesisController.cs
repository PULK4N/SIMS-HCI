// File:    AnamnesisController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 3:32:27 PM
// Purpose: Definition of Class AnamnesisController

using System;
using System.Collections.Generic;

public class AnamnesisController
{
    private readonly AnamnesisService _anamnesisService;

    public AnamnesisController(AnamnesisService anamnesisService)
    {
        _anamnesisService = anamnesisService;
    }

    public bool CreateAnamnesis(DateTime timeOf, String description)
    {
       throw new NotImplementedException();
    }
    
    public bool UpdateAnamnesis(DateTime timeOf, String description)
    {
       throw new NotImplementedException();
    }
    
    public bool DeleteAnamnesis(Anamnesis anamnesis)
    {
       throw new NotImplementedException();
    }
    
    public Anamnesis GetAnamnesis(long anamnesisId)
    {
       throw new NotImplementedException();
    }
    
    public List<Anamnesis> GetAllPatientAnamnesis(long patientId)
    {
       throw new NotImplementedException();
    }
    
}