using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Controller
{
    public class ReminderController : IEntityController<Reminder>
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public void Create(Reminder reminder)
        {
            _reminderService.Create(reminder);
        }

        public void Delete(long reminderId)
        {
            _reminderService.Delete(reminderId);
        }

        public Reminder Get(long reminderId)
        {
            return _reminderService.Get(reminderId);
        }

        public List<Reminder> GetAll()
        {
            return _reminderService.GetAll();
        }

        public void Update(Reminder reminder)
        {
            _reminderService.Update(reminder);
        }

        public List<Reminder> GetAllByPatientId(long patientId)
        {
            return _reminderService.GetAllByPatientId(patientId);
        }
    }
}
