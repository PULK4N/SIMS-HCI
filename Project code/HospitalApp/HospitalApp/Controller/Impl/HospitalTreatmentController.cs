using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Controller
{
    public class HospitalTreatmentController : IEntityController<HospitalTreatment>
    {
        private readonly IHospitalTreatmentService _hospitalTreatmentService;

        public HospitalTreatmentController(IHospitalTreatmentService hospitalTreatmentService)
        {
            _hospitalTreatmentService = hospitalTreatmentService;
        }

        public void Create(HospitalTreatment tObject)
        {
            _hospitalTreatmentService.Create(tObject);
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
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
            return _hospitalTreatmentService.GetByPatientId(patientId);
        }

        public void Update(HospitalTreatment tObject)
        {
            throw new NotImplementedException();
        }

        public void ExtendHospitalTreatment(long treatmentId, DateTime newEnd)
        {
            _hospitalTreatmentService.ExtendHospitalTreatment(treatmentId, newEnd);
        }
    }
}
