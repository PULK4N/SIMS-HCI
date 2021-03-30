/***********************************************************************
 * Module:  Room.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using System;
using System.Collections.Generic;

public class Room
{
    public long roomId{ get; set; }
    public String name{ get; set; }
    public String roomType{ get; set; }
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


}