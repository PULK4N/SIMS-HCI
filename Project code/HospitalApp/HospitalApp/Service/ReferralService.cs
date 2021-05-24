using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Service
{
    public class ReferralService : IReferralService
    {
        private readonly IReferralRepository _referralRepository;

        public ReferralService(IReferralRepository referralRepository)
        {
            _referralRepository = referralRepository;
        }

        public void Create(Referral referral)
        {
            _referralRepository.Create(referral);
        }

        public void Delete(long referralId)
        {
            _referralRepository.Delete(referralId);
        }

        public Referral Get(long referralId)
        {
            return _referralRepository.Get(referralId);
        }

        public List<Referral> GetAll()
        {
            return _referralRepository.GetAll();
        }

        public List<Referral> GetAllByPatientId(long patientId)
        {
            return _referralRepository.GetAllByPatientId(patientId);
        }

        public void Update(Referral referral)
        {
            _referralRepository.Update(referral);
        }
    }
}
