// File:    Reminder.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:13:50 PM
// Purpose: Definition of Class Reminder

using System;
using System.ComponentModel.DataAnnotations;

public class Reminder
{
    [Key]
    public long ReminderId{ get; set; }
    public int Name{ get; set; }
    public DateTime BeginTime{ get; set; }
    public DateTime EndTime{ get; set; }
    public String Comment{ get; set; }

}