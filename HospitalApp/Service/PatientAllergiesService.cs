using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Service
{
    public class PatientAllergiesService : IPatientAllergiesService
    {
        public readonly IPatientAllergiesRepository _allergiesRepository;

        public PatientAllergiesService(IPatientAllergiesRepository allergiesRepository)
        {
            _allergiesRepository = allergiesRepository;
        }

        public void Create(PatientAllergies tObject)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public PatientAllergies Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<PatientAllergies> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PatientAllergies tObject)
        {
            throw new NotImplementedException();
        }

        public List<PatientAllergies> GetAllByPatientId(long patientId)
        {
            return (from a in HospitalDB.Instance.PatientsAllergies where a.Patient.PatientId == patientId select a)
                .Include(p => p.Patient)
                .Include(p => p.Allergies).ToList();
        }
    }
}
