// File:    Reminder.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:13:50 PM
// Purpose: Definition of Class Reminder

using Microsoft.Win32.TaskScheduler;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace HospitalApp.Model
{
    public class Reminder
    {
        [Key]
        public long ReminderId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public short TimeInterval { get; set; }
        public DateTime Period { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
        private TaskDefinition Task;

        public Reminder(string name, DateTime startTime, short interval, DateTime period, string description, Patient patient)
        {
            Period = period;
            Name = name;
            StartTime = startTime;
            TimeInterval = interval;
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
                try
                {
                Map.TaskService.RootFolder.DeleteTask($"{Patient.User.RegisteredUser.Username}{ReminderId}");
                Task.Dispose();
                }catch(Exception E)
                {
                    MessageBox.Show(E.ToString());
                }
            }
        }

    }
}