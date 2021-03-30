// File:    Reminder.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:13:50 PM
// Purpose: Definition of Class Reminder

using System;

public class Reminder
{
    public long reminderId{ get; set; }
    public int name{ get; set; }
    public DateTime beginTime{ get; set; }
    public DateTime endTime{ get; set; }
    public String comment{ get; set; }

}