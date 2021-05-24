using HospitalApp.Model;

namespace HospitalApp.Service
{
    public interface IReminderSchedulingService
    {
        void ScheduleReminder(Reminder reminder);
        void UnScheduleReminder(Reminder reminder);
        void ReScheduleReminder(Reminder reminder);
    }
}