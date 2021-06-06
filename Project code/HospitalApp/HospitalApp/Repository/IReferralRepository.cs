using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Repository
{
    public interface IReferralRepository : IEntityRepository<Referral>
    {
        List<Referral> GetAllByPatientId(long patientId);
    }
}
