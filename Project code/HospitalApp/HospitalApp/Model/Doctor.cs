// File:    Doctor.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 7:46:22 PM
// Purpose: Definition of Class Doctor

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApp.Model
{
    public class Doctor
    {
        [Key]
        public long DoctorId { get; set; }
        public string AboutMe { get; set; }
        public Enums.Specialization Specialization { get; set; }
        [Required, Index("uniqueEmpDoc", IsUnique = true)]
        public Employee Employee { get; set; }

        public List<Prescription> prescription;
        public List<Appointment> appointment;

        public List<Prescription> Prescription
        {
            get
            {
                if (prescription == null)
                    prescription = new List<Prescription>();
                return prescription;
            }
            set
            {
                RemoveAllPrescription();
                if (value != null)
                {
                    foreach (Prescription oPrescription in value)
                        AddPrescription(oPrescription);
                }
            }
        }

        public void AddPrescription(Prescription newPrescription)
        {
            if (newPrescription == null)
                return;
            if (prescription == null)
                prescription = new List<Prescription>();
            if (!prescription.Contains(newPrescription))
                prescription.Add(newPrescription);
        }


        public void RemovePrescription(Prescription oldPrescription)
        {
            if (oldPrescription == null)
                return;
            if (prescription != null)
                if (prescription.Contains(oldPrescription))
                    prescription.Remove(oldPrescription);
        }

        public void RemoveAllPrescription()
        {
            if (prescription != null)
                prescription.Clear();
        }
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

    }
}