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

public class AppointmentContextDB : DbContext, IAppointmentRepository
{
    public DbSet<Anamnesis> Anamnesis { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorsReferral> DoctorsReferrals { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<GuestPatient> GuestPatients { get; set; }
    public DbSet<HospitalClinic> HospitalClinics { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Referal> Referals { get; set; }
    public DbSet<RegisteredUser> RegisteredUsers { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Secretary> Secretaries { get; set; }

    public AppointmentContextDB() : base("HospitalDB")
    {
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
    }

    public bool DoctorCreateAppointment(Appointment appointment)
    {
        try
        {
            Appointment newAppointment = new Appointment(appointment.Begining,
                                                         appointment.End, 
                                                         appointment.AppointmentType, 
                                                         appointment.AppointmentStatus, 
                                                         Patients.Find(appointment.Patient.PatientId), 
                                                         Doctors.Find(appointment.Doctor.DoctorId), 
                                                         Rooms.Find(appointment.Room.RoomId));
            Appointments.Add(newAppointment);
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
        List<Appointment> appointments = (from app in Appointments where app.Doctor.DoctorId == doctorId select app).Include(a => a.Room).Include(a => a.Patient).ToList();
        return appointments;
    }

    public bool DoctorUpdateAppointment(Appointment appointment)
    {
        try
        {
            Appointment oldAppointment = Appointments.Find(appointment.AppointmentId);
            oldAppointment.Begining = appointment.Begining;
            oldAppointment.End = appointment.End;
            oldAppointment.AppointmentType = appointment.AppointmentType;
            oldAppointment.Patient = appointment.Patient;
            oldAppointment.Room = appointment.Room;
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

    public List<Appointment> PatientListAppointments(Patient patient)
    {
        try
        {//select appointments with the date, than select the ones of the patient
            return (from pApp in Appointments where pApp.Patient.PatientId == patient.PatientId select pApp).Include(App => App.Doctor).ToList();
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
            Appointments.Remove(Appointments.Find(appointment.AppointmentId));
            SaveChanges();
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
            return (from pApp in (from a in Appointments where a.Begining.Date == dateOfAppointment.Date select a) where pApp.Patient.PatientId == patientID select pApp).ToList();
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
            Appointment oldAppointment = Appointments.Find(appointment.AppointmentId);
            oldAppointment.Begining = appointment.Begining;
            oldAppointment.End = appointment.End;
            SaveChanges();
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
            Appointment newAppointment = new Appointment(appointment.Begining, appointment.End, 0, 0,
                Patients.Find(appointment.Patient.PatientId),Doctors.Find(appointment.Doctor.DoctorId)
                ,Rooms.Find(appointment.Room.RoomId)) ;
            newAppointment.Patient.AddAppointment(newAppointment);
            newAppointment.Doctor.AddAppointment(newAppointment);
            Appointments.Add(newAppointment);
            SaveChanges();
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
}