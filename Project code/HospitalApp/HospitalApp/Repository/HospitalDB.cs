// File:    HospitalDB.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 4:28:07 PM
// Purpose: Definition of Class HospitalDB

using Enums;
using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace HospitalApp.Repository
{
    public class HospitalDB : DbContext, IHospitalDB
    {
        #region DbSets
        private static HospitalDB instance = null;
        private static readonly object padlock = new object();
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Anamnesis> Anamnesis { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bed> Bed { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorsReferral> DoctorsReferrals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GuestPatient> GuestPatients { get; set; }
        public DbSet<HospitalTreatment> HospitalTreatments { get; set; }
        public DbSet<HospitalClinic> HospitalClinics { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientAllergies> PatientsAllergies { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<StaticInventory> StaticInventories { get; set; }
        public static HospitalDB Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new HospitalDB();
                    }
                    return instance;
                }
            }
        }

        #endregion

        public HospitalDB() : base("HospitalDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalDB, Migrations.Configuration>());
        }

        public bool ChangeAppointmentStatus(long appointMentID, AppointmentStatus status)
        {
            throw new NotImplementedException();
        }

        public bool CreateAppointment(Appointment appointment)
        {
            try
            {
                Instance.Appointments.Add(appointment);
                Instance.SaveChanges();
                return true;
            }
            catch
            {
                MessageBox.Show("Error while creating new appointment");
            }
            return false;

        }

        public List<Appointment> DoctorListAppointments(long doctorId)
        {
            List<Appointment> appointments = (from app in Appointments where app.Doctor.DoctorId == doctorId select app).ToList();
            return appointments;
        }

        public bool CreatePatient(Patient patient)
        {
            try
            {

                Instance.RegisteredUsers.Add(patient.User.RegisteredUser);
                Instance.Users.Add(patient.User);

                Instance.Patients.Add(patient);
                Instance.SaveChanges();

                return true;
            }
            catch
            {
                MessageBox.Show("Error HospitalDB");
            }
            return false;
        }

        public bool DeleteAppointment(long doctorID)
        {
            try
            {

                Instance.SaveChanges();

                return true;
            }
            catch
            {
                MessageBox.Show("Error HospitalDB");
            }
            return false;
        }

        public bool DeletePatient(Patient patient)
        {
            try
            {

                Instance.Patients.Remove(patient);
                Instance.SaveChanges();

                return true;
            }
            catch
            {
                MessageBox.Show("Error HospitalDB");
            }
            return false;
        }

        public List<Patient> GetAllPatients()
        {
            try
            {
                return Instance.Patients.ToList();
            }
            catch
            {
                MessageBox.Show("Error while getting patient list, returning null");
            }
            return null;
        }

        public List<Appointment> GetAppointmentByDateAndPatientID(DateTime date, long patientID)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentByID(long appointmentID)
        {
            try
            {
                return Instance.Appointments.Find(appointmentID);
                //Appointment appointment = (from a in Instance.appointments where a.appointmentId == appointmentID select a).FirstOrDefault<Appointment>();
                //return appointment;
            }
            catch
            {
                MessageBox.Show("We discovered an error while trying to acquire an appointment by Id");
            }
            return null;
        }

        public List<Appointment> GetAppointmentsByPatientID(long patientID)//TO DO: possible error
        {
            try
            {
                List<Appointment> appointments = (from a in Instance.Appointments where a.Patient.PatientId == patientID select a).ToList();
                return appointments;
            }
            catch
            {
                MessageBox.Show("We discovered an error while trying to acquire an appointment by patientId");
            }
            return null;
        }

        public List<Patient> GetPatientsByDoctorID(long doctorID)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientByID(long patientID)
        {
            try
            {
                return Instance.Patients.Find(patientID);
            }
            catch
            {
                MessageBox.Show("We discovered an error while trying to acquire an appointment by Id");
            }
            return null;
        }

        public bool ReScheduleAppointment(Appointment appointment)
        {

            return false;
        }

        public bool UpdatePatient(Patient patient)
        {
            Patient oldPatientInfo = Instance.Patients.Find(patient.PatientId);
            if (oldPatientInfo != null)
            {
                oldPatientInfo.User.Address = patient.User.Address;
                oldPatientInfo.User.EMail = patient.User.EMail;
                oldPatientInfo.User.PhoneNumber = patient.User.PhoneNumber;
                Instance.SaveChanges();
            }
            return false;
        }

        public bool DeleteGuestPatient(GuestPatient guestPatient)
        {
            try
            {
                GuestPatients.Remove(guestPatient);
                Instance.SaveChanges();
                return true;
            }
            catch
            {
                MessageBox.Show("Error while deleting a guest patient");
            }
            return false;
        }

    }
}