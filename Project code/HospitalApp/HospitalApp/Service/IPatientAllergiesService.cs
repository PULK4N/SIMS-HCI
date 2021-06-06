using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Service
{
    public interface IPatientAllergiesService : IEntityService<PatientAllergies>
    {
        List<PatientAllergies> GetAllByPatientId(long patientId);
    }
}
