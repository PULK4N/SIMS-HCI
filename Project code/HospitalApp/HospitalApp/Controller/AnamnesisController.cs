// File:    AnamnesisController.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 3:32:27 PM
// Purpose: Definition of Class AnamnesisController

using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;

namespace HospitalApp.Controller
{
    public class AnamnesisController : IEntityController<Anamnesis>
    {
        private readonly IAnamnesisService _anamnesisService;

        public AnamnesisController(IAnamnesisService anamnesisService)
        {
            _anamnesisService = anamnesisService;
        }

        public void Create(Anamnesis anamnesis)
        {
            _anamnesisService.Create(anamnesis);
        }

        public void Update(Anamnesis anamnesis)
        {
            _anamnesisService.Update(anamnesis);
        }

        public void Delete(long anamnesisId)
        {
            _anamnesisService.Delete(anamnesisId);
        }

        public Anamnesis Get(long anamnesisId)
        {
            return _anamnesisService.Get(anamnesisId);
        }

        public Anamnesis GetByPatientId(long patientId)
        {
            return _anamnesisService.GetByPatientId(patientId);
        }

        public List<Anamnesis> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}