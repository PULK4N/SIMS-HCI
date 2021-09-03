using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public void Create(Reminder reminder)
        {
            _reminderRepository.Create(reminder);
            Map.ReminderSchedulingService.ScheduleReminder(reminder);
        }

        public void Delete(long reminderId)
        {
            Map.ReminderSchedulingService.UnScheduleReminder(Get(reminderId));
            _reminderRepository.Delete(reminderId);
        }

        public Reminder Get(long reminderId)
        {
            return _reminderRepository.Get(reminderId);
        }

        public List<Reminder> GetAll()
        {
            return _reminderRepository.GetAll();
        }

        public List<Reminder> GetAllByPatientId(long patientId)
        {
            return _reminderRepository.GetAllByPatientId(patientId);
        }

        public void Update(Reminder reminder)
        {
            Reminder oldReminder = _reminderRepository.Get(reminder.ReminderId);
            oldReminder.Name = reminder.Name;
            oldReminder.Patient = reminder.Patient;
            oldReminder.TimeInterval = reminder.TimeInterval;
            oldReminder.StartTime = reminder.StartTime;
            oldReminder.Description = reminder.Description;
            _reminderRepository.Update(oldReminder);
            if (reminder.Period.CompareTo(DateTime.Now) > 0)
            {
                Map.ReminderSchedulingService.ReScheduleReminder(oldReminder);
            }
            else
            {
                Map.ReminderSchedulingService.UnScheduleReminder(oldReminder);
            }
        }
    }
}
