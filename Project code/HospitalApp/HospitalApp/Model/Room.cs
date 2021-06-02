/***********************************************************************
 * Module:  Room.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Model
{
    public class Room
    {
        [Key]
        public long RoomId { get; set; }
        public string Name { get; set; }
        public string RoomType { get; set; }
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
            if (appointment == null)
                appointment = new List<Appointment>();
            if (!appointment.Contains(newAppointment))
                appointment.Add(newAppointment);
        }


        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (appointment != null)
                if (appointment.Contains(oldAppointment))
                    appointment.Remove(oldAppointment);
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
}