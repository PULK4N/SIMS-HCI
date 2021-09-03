using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalApp.Model;
using Microsoft.Win32.TaskScheduler;
using Enums;
using System.Windows;

namespace HospitalApp.Service
{
    public class ReminderSchedulingService : IReminderSchedulingService
    {
        private List<TaskDefinition> taskDefinitions;

        public ReminderSchedulingService()
        {
            taskDefinitions = new List<TaskDefinition>();
        }
        //TO DO: edit
        public void ScheduleReminder(Reminder reminder)
        {
            GenerateTaskByReminder(reminder);
        }

        public void ReScheduleReminder(Reminder reminder)
        {
            TaskDefinition task = reminder.GetTask();
            addTaskData(task, reminder);
        }
        private void GenerateTaskByReminder(Reminder reminder)
        {
            TaskDefinition task = Map.TaskService.NewTask();
            reminder.SetTask(task);

            addTaskData(task, reminder);
        }

        private void addTaskData(TaskDefinition task, Reminder reminder)
        {
            task.Triggers.Clear();
            task.RegistrationInfo.Description = reminder.Description;
            TimeTrigger timeTrigger = new TimeTrigger(reminder.StartTime);
            timeTrigger.Repetition.Duration = TimeSpan.Zero;
            timeTrigger.Repetition.Interval = TimeSpan.FromDays(reminder.TimeInterval);
            timeTrigger.EndBoundary = reminder.Period;
            task.Triggers.Add(timeTrigger);
            ShowMessageAction msg = new ShowMessageAction(reminder.Description, "Notification");
            task.Actions.Clear();
            task.Actions.Add(msg);
            Map.TaskService.RootFolder.RegisterTaskDefinition($"{reminder.Patient.User.RegisteredUser.Username}{reminder.ReminderId}", task);
        }

        public void UnScheduleReminder(Reminder reminder)
        {
            if (reminder.GetTask() != null)
            {
                Map.TaskService.RootFolder.DeleteTask($"{reminder.Patient.User.RegisteredUser.Username}{reminder.ReminderId}");
                reminder.GetTask().Dispose();
            }
        }

    }
}
