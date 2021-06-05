using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Repository
{
    class ReminderRepository : IReminderRepository
    {
        public void Create(Reminder reminder)
        {
            try
            {
                HospitalDB.Instance.Reminders.Add(reminder);
                HospitalDB.Instance.SaveChanges();
            }catch(Exception e)
            {

            }
        }

        public void Delete(long reminderId)
        {
            try
            {
                HospitalDB.Instance.Reminders.Remove(Get(reminderId));
                HospitalDB.Instance.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public Reminder Get(long reminderId)
        {
            try
            {
                return HospitalDB.Instance.Reminders.Find(reminderId);
            }
            catch (Exception e)
            {
            }
            return null;
        }

        public List<Reminder> GetAll()
        {
            return (from r in HospitalDB.Instance.Reminders select r).Include(r => r.Patient).ToList();
        }

        public List<Reminder> GetAllByPatientId(long patientId)
        {
            return (from r in HospitalDB.Instance.Reminders where r.Patient.PatientId == patientId select r).Include(r => r.Patient).ToList();
        }

        public void Update(Reminder reminder)
        {
            HospitalDB.Instance.SaveChanges();
        }
    }
}
