// File:    Reminder.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:13:50 PM
// Purpose: Definition of Class Reminder

using Microsoft.Win32.TaskScheduler;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Model
{
    public class Reminder
    {
        [Key]
        public long ReminderId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public short Period { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
        private TaskDefinition Task;

        public Reminder(string name, DateTime startTime, short period, string description, Patient patient)
        {
            Name = name;
            StartTime = startTime;
            Period = period;
            Description = description;
            Patient = patient;
        }

        public Reminder()
        {
        }

        ~Reminder()
        {
            CancelTask();
        }

        public void SetTask(TaskDefinition task)
        {
            Task = task;
        }

        public TaskDefinition GetTask()
        {
            return Task;
        }

        private void CancelTask()
        {
            if (Task != null && Patient != null)
            {
                Map.TaskService.RootFolder.DeleteTask($"{Patient.User.RegisteredUser.Username}{ReminderId}");
                Task.Dispose();
            }
        }

    }
}