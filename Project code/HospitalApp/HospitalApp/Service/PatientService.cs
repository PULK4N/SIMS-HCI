/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public bool CreatePatient(string firstName, string lastName, string dateOfBirth, string address, string phoneNumber, int jmbg, string eMail, Sex sex)
    {
        throw new NotImplementedException();
    }

    public bool DeletePatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public Patient GetPatient(Patient patient)
    {
        return _patientRepository.GetPatient(patient);
    }

    public Patient GetPatient(long patientId)
    {
        return _patientRepository.GetPatient(patientId);
    }

    public bool UpdatePatient(Patient patient)
    {
        throw new NotImplementedException();
    }

    public List<Patient> GetPatients()
    {
        return _patientRepository.GetPatients();
    }

    public bool IncrementAttemptCounter(Patient patient)
    {
        ++patient.SchedulingAttempts;
        bool IsMalicious = _patientRepository.IncrementAttemptCounter(patient);
        if (IsMalicious && patient.User.RegisteredUser.UserType != UserType.BANNNED_USER)
        {
            BanPatient(patient);
        }
        return IsMalicious == false;
    }

    public async Task StartWeeklyAttemptsRestarting(CancellationToken cancellationToken)
    {

        await Task.Run(async () =>
        {
            List<Patient> patients = _patientRepository.GetPatientsWeekActivePatients();
            while (true)
            {
                foreach(Patient patient in patients)
                {
                    patient.SchedulingAttempts = 0;
                }
                HospitalDB.Instance.SaveChanges();
                await Task.Delay(604800000, cancellationToken);
                if (cancellationToken.IsCancellationRequested)
                    break;
            }
        });

    }

    public void BanPatient(Patient patient)
    {
        _patientRepository.BanPatient(patient);
    }
}