using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalApp.Repository
{
    public class ReferralRepository : IReferralRepository
    {
        public void Create(Referral referral)
        {
            try
            {
                HospitalDB.Instance.Referrals.Add(referral);
                HospitalDB.Instance.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }

        public void Delete(long referralId)
        {
            HospitalDB.Instance.Referrals.Remove(Get(referralId));
            HospitalDB.Instance.SaveChanges();
        }

        public Referral Get(long referralId)
        {
            return (from r in HospitalDB.Instance.Referrals where r.ReferralId == referralId select r)
                .Include(r => r.Patient)
                .FirstOrDefault();
        }

        public List<Referral> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Referral> GetAllByPatientId(long patientId)
        {
            return (from r in HospitalDB.Instance.Referrals where r.Patient.PatientId == patientId select r).ToList();
        }

        public void Update(Referral referral)
        {
            throw new NotImplementedException();
        }
    }
}
