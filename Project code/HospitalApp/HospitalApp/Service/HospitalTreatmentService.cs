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
            throw new NotImplementedException();
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

        public void Update(HospitalTreatment tObject)
        {
            throw new NotImplementedException();
        }
    }
}
