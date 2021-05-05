// File:    AppointmentContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class AppointmentContextDB

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

public class AppointmentContextDB : IAppointmentRepository
{
    public AppointmentContextDB()
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool DoctorCreateAppointment(Appointment appointment)
    {
        try
        {
            Appointment newAppointment = new Appointment(appointment.Beginning,
                                                         appointment.End, 
                                                         appointment.AppointmentType, 
                                                         appointment.AppointmentStatus,
                                                         HospitalDB.Instance.Patients.Find(appointment.Patient.PatientId),
                                                         HospitalDB.Instance.Doctors.Find(appointment.Doctor.DoctorId),
                                                         HospitalDB.Instance.Rooms.Find(appointment.Room.RoomId));
            HospitalDB.Instance.Appointments.Add(newAppointment);
            HospitalDB.Instance.SaveChanges();
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
            HospitalDB.Instance.Appointments.Remove(HospitalDB.Instance.Appointments.Find(appointment.AppointmentId));
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        catch
        {

        }
        return false;
    }

    public List<Appointment> DoctorListAppointments(long doctorId)
    {
        List<Appointment> appointments = (from app in HospitalDB.Instance.Appointments where app.Doctor.DoctorId == doctorId select app).Include(a => a.Room).Include(a => a.Patient).ToList();
        return appointments;
    }

    public bool DoctorUpdateAppointment(Appointment appointment)
    {
        try
        {
            Appointment oldAppointment = HospitalDB.Instance.Appointments.Find(appointment.AppointmentId);
            oldAppointment.Beginning = appointment.Beginning;
            oldAppointment.End = appointment.End;
            oldAppointment.AppointmentType = appointment.AppointmentType;
            oldAppointment.Patient = appointment.Patient;
            oldAppointment.Room = appointment.Room;
            HospitalDB.Instance.SaveChanges();
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
            return HospitalDB.Instance.Appointments.Find(appointmentId);
        }
        catch
        {
            MessageBox.Show("We discovered an error while trying to acquire an appointment by Id");
        }
        return null;
    }

    public List<Appointment> PatientListAppointments(Patient patient)
    {
        try
        {//select appointments with the date, than select the ones of the patient
            return (from pApp in HospitalDB.Instance.Appointments where pApp.Patient.PatientId == patient.PatientId select pApp).Include(App => App.Doctor).ToList();
        }
        catch (DbEntityValidationException ex)
        {
            foreach (var entityValidationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in entityValidationErrors.ValidationErrors)
                {
                    MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                }
            }
        }
        return null;
    }

    public bool PatientCancelAppointment(Appointment appointment)
    {
        try
        {//select appointments with the date, than select the ones of the patient
            HospitalDB.Instance.Appointments.Remove(HospitalDB.Instance.Appointments.Find(appointment.AppointmentId));
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        catch (DbEntityValidationException ex)
        {
            foreach (var entityValidationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in entityValidationErrors.ValidationErrors)
                {
                    MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                }
            }
        }
        return false;
    }

    public List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment)
    {
        try
        {//select appointments with the date, than select the ones of the patient
            return (from pApp in (from a in HospitalDB.Instance.Appointments where a.Beginning.Date == dateOfAppointment.Date select a) where pApp.Patient.PatientId == patientID select pApp).ToList();
        }
        catch (DbEntityValidationException ex)
        {
            foreach (var entityValidationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in entityValidationErrors.ValidationErrors)
                {
                    MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                }
            }
        }
        return null;
    }

    public bool PatientReScheduleAppointment(Appointment appointment)
    {
        try
        {
            Appointment oldAppointment = HospitalDB.Instance.Appointments.Find(appointment.AppointmentId);
            oldAppointment.Beginning = appointment.Beginning;
            oldAppointment.End = appointment.End;
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        catch (DbEntityValidationException ex)
        {
            foreach (var entityValidationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in entityValidationErrors.ValidationErrors)
                {
                    MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                }
            }
        }
        return false;
    }

    public bool PatientScheduleAppointment(Appointment appointment)
    {
        try
        {//TO DO: EDIT THIS
            Appointment newAppointment = new Appointment(appointment.Beginning, appointment.End, 0, 0,
                HospitalDB.Instance.Patients.Find(appointment.Patient.PatientId), HospitalDB.Instance.Doctors.Find(appointment.Doctor.DoctorId)
                , HospitalDB.Instance.Rooms.Find(appointment.Room.RoomId)) ;
            newAppointment.Patient.AddAppointment(newAppointment);
            newAppointment.Doctor.AddAppointment(newAppointment);
            HospitalDB.Instance.Appointments.Add(newAppointment);
            HospitalDB.Instance.SaveChanges();
            return true;
        }
        catch (DbEntityValidationException ex)
        {
            foreach (var entityValidationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in entityValidationErrors.ValidationErrors)
                {
                    MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                }
            }
        }
        return false;
    }

    public List<Appointment> GetPatientCompletedAppointments(Patient patient)
    {
        try
        {//select appointments with the date, than select the ones of the patient
            return (from pApp in HospitalDB.Instance.Appointments 
                    where pApp.Patient.PatientId == patient.PatientId 
                    && pApp.AppointmentStatus == Enums.AppointmentStatus.COMPLETED 
                    select pApp).Include(App => App.Doctor).ToList();
        }
        catch (DbEntityValidationException ex)
        {
            foreach (var entityValidationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in entityValidationErrors.ValidationErrors)
                {
                    MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                }
            }
        }
        return null;
    }
}