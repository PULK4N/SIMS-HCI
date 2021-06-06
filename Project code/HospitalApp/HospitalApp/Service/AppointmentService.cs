// File:    AppointmentService.cs
// Author:  Nikola
// Created: Thursday, April 15, 2021 4:44:59 PM
// Purpose: Definition of Class AppointmentService

using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;

namespace HospitalApp.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void Create(Appointment appointment)
        {
            _appointmentRepository.Create(appointment);
        }

        public void Delete(long appointmentId)//TO DO: change to id
        {
            _appointmentRepository.Delete(appointmentId);
        }

        public List<Appointment> GetAllByDoctorId(long doctorId)
        {
            return _appointmentRepository.GetAllByDoctor(doctorId);
        }

        public void Update(Appointment appointment)
        {
            Appointment oldAppointmentData = Get(appointment.AppointmentId);
            if (oldAppointmentData != null)
            {
                oldAppointmentData.AppointmentStatus = appointment.AppointmentStatus;
                oldAppointmentData.AppointmentType = appointment.AppointmentType;
                oldAppointmentData.Beginning = appointment.Beginning;
                oldAppointmentData.End = appointment.End;
                oldAppointmentData.Room = appointment.Room;
            }
            _appointmentRepository.Update(appointment);
        }

        public Appointment Get(long id)
        {
            return _appointmentRepository.Get(id);
        }

        public List<Appointment> GetAllByPatientId(long patientId)
        {
            return _appointmentRepository.GetAllByPatient(patientId);
        }

        public bool PatientReScheduleAppointment(Appointment appointment)
        {
            if (new PatientService(new PatientRepository()).IsMalicious(appointment.Patient) == false)
                _appointmentRepository.Update(appointment);//TO DO: edit this function, change the location maybe
            else
            {
                return false;
            }
            return true;
        }

        public bool PatientScheduleAppointment(Appointment appointment)
        {
            PatientService patient = new PatientService(new PatientRepository());
            if (patient.IsMalicious(appointment.Patient) == false)
                _appointmentRepository.Create(appointment);
            else
            {
                return false;
            }
            return true;
        }

        public List<Appointment> GetAllCompletedByPatientId(long patientId)
        {
            return _appointmentRepository.GetAllCompletedByPatient(patientId);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public List<Appointment> GetAllByPatientRefered(long patientId)
        {
            return _appointmentRepository.GetAllByPatientRefered(patientId);
        }
    }
}