using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Service
{
    public class HospitalTreatmentService : IHospitalTreatmentService
    {
        private readonly IHospitalTreatmentRepository _hospitalTreatmentRepository;

        public HospitalTreatmentService(IHospitalTreatmentRepository hospitalTreatmentRepository)
        {
            _hospitalTreatmentRepository = hospitalTreatmentRepository;
        }

        public void Create(HospitalTreatment tObject)
        {
            _hospitalTreatmentRepository.Create(tObject);
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void ExtendHospitalTreatment(long treatmentId, DateTime newEnd)
        {
            HospitalTreatment treatmentToEdit = _hospitalTreatmentRepository.Get(treatmentId);
            treatmentToEdit.End = newEnd;
            _hospitalTreatmentRepository.Update(treatmentToEdit);
        }

        public HospitalTreatment Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<HospitalTreatment> GetAll()
        {
            throw new NotImplementedException();
        }

        public HospitalTreatment GetByPatientId(long patientId)
        {
            return _hospitalTreatmentRepository.GetByPatientId(patientId);
        }

        public void Update(HospitalTreatment tObject)
        {
            throw new NotImplementedException();
        }
    }
}
