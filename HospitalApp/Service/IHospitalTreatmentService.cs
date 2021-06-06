using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Service
{
    public interface IHospitalTreatmentService : IEntityService<HospitalTreatment>
    {
        HospitalTreatment GetByPatientId(long patientId);
        void ExtendHospitalTreatment(long treatmentId, DateTime newEnd);
    }
}
