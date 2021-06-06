// File:    AppointmentContextDB.cs
// Author:  Nikola
// Created: Friday, April 16, 2021 10:26:56 AM
// Purpose: Definition of Class AppointmentContextDB

using Enums;
using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

namespace HospitalApp.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public AppointmentRepository()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, HospitalApp.Migrations.Configuration>());
        }

        public void Create(Appointment appointment)
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
                newAppointment.Patient.AddAppointment(newAppointment);
                newAppointment.Doctor.AddAppointment(newAppointment);
                HospitalDB.Instance.Appointments.Add(newAppointment);
                HospitalDB.Instance.SaveChanges();
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
        }
        public void Update(Appointment appointment)
        {
            try
            {
                Appointment oldAppointment = HospitalDB.Instance.Appointments.Find(appointment.AppointmentId);
                oldAppointment.Beginning = appointment.Beginning;
                oldAppointment.End = appointment.End;
                oldAppointment.AppointmentType = appointment.AppointmentType;
                oldAppointment.AppointmentStatus = appointment.AppointmentStatus;
                oldAppointment.Doctor = appointment.Doctor;
                oldAppointment.Patient = appointment.Patient;
                oldAppointment.Room = appointment.Room;
                HospitalDB.Instance.SaveChanges();
            }
            catch
            {

            }
        }

        public void Delete(long appointment)
        {
            try
            {
                HospitalDB.Instance.Appointments.Remove(HospitalDB.Instance.Appointments.Find(appointment));
                HospitalDB.Instance.SaveChanges();
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
        }

        public List<Appointment> GetAllByDoctor(long doctorId)
        {
            List<Appointment> appointments = (from app in HospitalDB.Instance.Appointments where app.Doctor.DoctorId == doctorId select app)
                .Include(a => a.Room)
                .Include(a => a.Patient)
                .Include(a => a.Patient.User)
                .Include(a => a.Patient.User.RegisteredUser)
                .Include(a => a.Patient.MedicalRecord)
                .Include(a => a.Patient.MedicalRecord.Anamnesis)
                .Include(a => a.Patient.MedicalRecord.Anamnesis.Prescriptions.Select(prsc => prsc.Drug)).ToList();
            return appointments;
        }


        public Appointment Get(long appointmentId)
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

        public List<Appointment> GetAllByPatient(long patientId)
        {
            try
            {//select appointments with the date, than select the ones of the patient
                return (from pApp in HospitalDB.Instance.Appointments where pApp.Patient.PatientId == patientId && pApp.AppointmentStatus == Enums.AppointmentStatus.PENDING select pApp).Include(App => App.Doctor).ToList();
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

        public List<Appointment> PatientListApointmentsByDay(long patientID, DateTime dateOfAppointment)
        {
            try
            {//select appointments with the date, than select the ones of the patient
                return (from pApp in from a in HospitalDB.Instance.Appointments where a.Beginning.Date == dateOfAppointment.Date select a where pApp.Patient.PatientId == patientID select pApp).ToList();
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

       
        public List<Appointment> GetAllCompletedByPatient(long patientId)
        {
            try
            {//select appointments with the date, than select the ones of the patient
                return (from pApp in HospitalDB.Instance.Appointments
                        where pApp.Patient.PatientId == patientId
                        && pApp.AppointmentStatus == Enums.AppointmentStatus.COMPLETED
                        select pApp)
                        .Include(App => App.Doctor)
                        .ToList();
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

        public List<Appointment> GetAll()
        {
            return (from a in HospitalDB.Instance.Appointments select a)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Room)
                .ToList();
        }
    }
}