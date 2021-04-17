// File:    AppointmentContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class AppointmentContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

public class AppointmentContextDB : DbContext, IAppointmentRepository
{
    public DbSet<Appointment> Appointments { get; set; }

    public AppointmentContextDB() : base("HospitalDB")
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool DoctorCreateAppointment(Appointment appointment)
    {
        try
        {
            Appointments.Add(appointment);
            SaveChanges();
            return true;
        }
        catch
        {

        }
        return false;
    }

    public bool DoctorDeleteAppointment(Appointment appointment)
    {
        try
        {
            Appointments.Remove(Appointments.Find(appointment.AppointmentId));
            SaveChanges();
            return true;
        }
        catch
        {

        }
        return false;
    }

    public List<Appointment> DoctorListAppointments(long doctorId)
    {
        List<Appointment> appointments = (from app in Appointments where app.Doctor.DoctorId == doctorId select app).ToList();
        return appointments;
    }

    public bool DoctorUpdateAppointment(Appointment appointment)
    {
        try
        {
            Appointment oldAppointment = Appointments.Find(appointment.AppointmentId);
            oldAppointment.Begining = appointment.Begining;
            oldAppointment.End = appointment.End;
            SaveChanges();
            return true;
        }
        catch
        {

        }
        return false;
    }

    public Appointment GetById(long appointmentId)
    {
        try
        {
            return Appointments.Find(appointmentId);
        }
        catch
        {
            MessageBox.Show("We discovered an error while trying to acquire an appointment by Id");
        }
        return null;
    }

    public List<Appointment> PatentListAppointments(long patientID)
    {
        try
        {//select appointments with the date, than select the ones of the patient
            return (from pApp in Appointments where pApp.Patient.PatientId == patientID select pApp).ToList();
        }
        catch
        {

        }
        return null;
    }

    public bool PatientCancelAppointment(Appointment appointment)
    {
        try
        {//select appointments with the date, than select the ones of the patient
            Appointments.Remove(Appointments.Find(appointment.AppointmentId));
            SaveChanges();
            return true;
        }
        catch
        {

        }
        return false;
    }

    public List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment)
    {
        try
        {//select appointments with the date, than select the ones of the patient
            return (from pApp in (from a in Appointments where a.Begining.Date == dateOfAppointment.Date select a) where pApp.Patient.PatientId == patientID select pApp).ToList();
        }
        catch
        {

        }
        return null;
    }

    public bool PatientReScheduleAppointment(Appointment appointment)
    {
        try
        {
            Appointment oldAppointment = Appointments.Find(appointment.AppointmentId);
            oldAppointment.Begining = appointment.Begining;
            oldAppointment.End = appointment.End;
            SaveChanges();
            return true;
        }
        catch
        {

        }
        return false;
    }

    public bool PatientScheduleAppointment(Appointment appointment)
    {
        try
        {
            Appointments.Add(appointment);
            SaveChanges();
            return true;
        }
        catch
        {

        }
        return false;
    }
}