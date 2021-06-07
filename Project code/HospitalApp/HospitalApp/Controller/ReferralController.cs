using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Controller
{
    public class ReferralController : IEntityController<Referral>
    {
        private readonly IReferralService _referralService;

        public ReferralController(IReferralService referralService)
        {
            _referralService = referralService;
        }

        public void Create(Referral referral)
        {
            _referralService.Create(referral);
        }

        public void Delete(long referralId)
        {
            _referralService.Delete(referralId);
        }

        public Referral Get(long referralId)
        {
            return _referralService.Get(referralId);
        }

        public List<Referral> GetAll()
        {
            return _referralService.GetAll();
        }

        public void Update(Referral referral)
        {
            _referralService.Update(referral);
        }

        public List<Referral> GetAllByPatientId(long patientId)
        {
            return _referralService.GetAllByPatientId(patientId);
        }
    }
}
