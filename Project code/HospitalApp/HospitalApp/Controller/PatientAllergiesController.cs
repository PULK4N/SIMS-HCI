using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Controller
{
    public class PatientAllergiesController : IEntityController<PatientAllergies>
    {
        private readonly IPatientAllergiesService _allergiesService;

        public PatientAllergiesController(IPatientAllergiesService allergiesService)
        {
            _allergiesService = allergiesService;
        }

        public void Create(PatientAllergies tObject)
        {
            throw new NotImplementedException();
        }

        public void Update(PatientAllergies tObject)
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

        public List<PatientAllergies> GetAllByPatientId(long patientId)
        {
            return _allergiesService.GetAllByPatientId(patientId);
        }
    }
}
