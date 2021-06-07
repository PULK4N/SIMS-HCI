using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Repository
{
    public class HospitalTreatmentRepository : IHospitalTreatmentRepository
    {
        public void Create(HospitalTreatment tObject)
        {
            HospitalDB.Instance.HospitalTreatments.Add(tObject);
            HospitalDB.Instance.SaveChanges();
        }

        public void Update(HospitalTreatment extendedHospitalTreatmnet)
        {
            HospitalTreatment oldHospitalTreatment = Get(extendedHospitalTreatmnet.TreatmentId);
            oldHospitalTreatment.Beginning = extendedHospitalTreatmnet.Beginning;
            oldHospitalTreatment.End = extendedHospitalTreatmnet.End;
            oldHospitalTreatment.HospitalTreatmentStatus = extendedHospitalTreatmnet.HospitalTreatmentStatus;
            oldHospitalTreatment.Patient = extendedHospitalTreatmnet.Patient;
            oldHospitalTreatment.Room = extendedHospitalTreatmnet.Room;
            oldHospitalTreatment.Bed = extendedHospitalTreatmnet.Bed;
            HospitalDB.Instance.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public HospitalTreatment Get(long id)
        {
            return (from ht in HospitalDB.Instance.HospitalTreatments where ht.TreatmentId == id select ht).FirstOrDefault();
        }

        public List<HospitalTreatment> GetAll()
        {
            throw new NotImplementedException();
        }

        public HospitalTreatment GetByPatientId(long patientId)
        {
            return (from h in HospitalDB.Instance.HospitalTreatments where h.Patient.PatientId == patientId select h)
                .Include(b=>b.Bed)
                .FirstOrDefault();
        }
    }
}
