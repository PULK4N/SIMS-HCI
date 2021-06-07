// File:    AnamnesisService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class AnamnesisService

using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public class AnamnesisService : IAnamnesisService
    {
        private readonly IAnamnesisRepository _anamnesisRepository;

        public AnamnesisService(IAnamnesisRepository anamnesisRepository)
        {
            _anamnesisRepository = anamnesisRepository;
        }

        public void Create(Anamnesis anamnesis)
        {
            _anamnesisRepository.Create(anamnesis);
        }

        public void Delete(long anamnesisId)
        {
            _anamnesisRepository.Delete(anamnesisId);
        }

        public Anamnesis GetByPatientId(long patientId)
        {
            return _anamnesisRepository.GetByPatient(patientId);
        }

        public Anamnesis Get(long anamnesisId)
        {
            return _anamnesisRepository.Get(anamnesisId);
        }

        public void Update(Anamnesis anamnesis)
        {
            Anamnesis oldAnamnesis = Get(anamnesis.AnamnesisId);
            if (oldAnamnesis != null)
            {
                oldAnamnesis.Description = anamnesis.Description;
                oldAnamnesis.TimeOf = DateTime.Now;
            }
            _anamnesisRepository.Update(anamnesis);
        }

        public List<Anamnesis> GetAll()
        {
            return _anamnesisRepository.GetAll();
        }
    }
}