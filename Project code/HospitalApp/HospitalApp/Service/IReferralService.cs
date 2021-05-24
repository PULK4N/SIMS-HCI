using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Service
{
    public interface IReferralService : IEntityService<Referral>
    {
        List<Referral> GetAllByPatientId(long patientId);
    }
}
