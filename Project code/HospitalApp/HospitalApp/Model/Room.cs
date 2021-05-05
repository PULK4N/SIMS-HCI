/***********************************************************************
 * Module:  Room.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Room
{
    [Key]
    public long RoomId{ get; set; }
    public String Name{ get; set; }
    public String RoomType{ get; set; }
    public List<Appointment> appointment;

    public List<Appointment> Appointment
    {
        get
        {
            if (appointment == null)
                appointment = new List<Appointment>();
            return appointment;
        }
        set
        {
            RemoveAllAppointment();
            if (value != null)
            {
                foreach (Appointment oAppointment in value)
                    AddAppointment(oAppointment);
            }
        }
    }

    public void AddAppointment(Appointment newAppointment)
    {
        if (newAppointment == null)
            return;
        if (this.appointment == null)
            this.appointment = new List<Appointment>();
        if (!this.appointment.Contains(newAppointment))
            this.appointment.Add(newAppointment);
    }


    public void RemoveAppointment(Appointment oldAppointment)
    {
        if (oldAppointment == null)
            return;
        if (this.appointment != null)
            if (this.appointment.Contains(oldAppointment))
                this.appointment.Remove(oldAppointment);
    }

    public void RemoveAllAppointment()
    {
        if (appointment != null)
            appointment.Clear();
    }

    public override string ToString()
    {
        return Name;
    }
}