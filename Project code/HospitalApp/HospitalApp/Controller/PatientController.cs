using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HospitalApp.Controller
{
    public class PatientController : IEntityController<Patient>
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public void Create(Patient patient)
        {
            _patientService.Create(patient);
        }

        public Patient Get(long patientId)
        {
            return _patientService.Get(patientId);
        }

        public void Update(Patient patient)
        {
            _patientService.Update(patient);
        }

        public void Delete(long patientId)
        {
            _patientService.Delete(patientId);
        }

        public List<Patient> GetPatients()
        {
            return _patientService.GetAll();
        }

        public bool IsMalicious(Patient patient)
        {
            return _patientService.IsMalicious(patient);
        }

        public void StartWeeklyAttemptsRestarting(CancellationToken cancellationToken)
        {
            _patientService.StartWeeklyAttemptsRestarting(cancellationToken);
        }

        public List<Patient> GetAll()
        {
            return _patientService.GetAll();
        }
    }
}