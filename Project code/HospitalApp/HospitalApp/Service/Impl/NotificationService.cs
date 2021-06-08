using HospitalApp.Model;
using HospitalApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalApp.Service
{
    public class NotificationService
    {
        public async Task StartTimer(CancellationToken cancellationToken)
        {

            await Task.Run(async () =>
            {
                List<Prescription> prescriptions = new List<Prescription>();
                while (true)
                {
                    prescriptions.Clear();
                    foreach (Prescription prescription in Map.PrescriptionController.GetAllByPatientId(1/*PatientWindow.Patient.PatientId*/))
                    {
                        prescriptions.Add(prescription);
                    }
                    GenerateNotifications(prescriptions);
                    await Task.Delay(604800000, cancellationToken);
                    if (cancellationToken.IsCancellationRequested)
                        break;
                }
            });

        }

        private void GenerateNotifications(List<Prescription> prescriptions)
        {
            foreach (Prescription prescription in prescriptions)
            {
                if (prescription.Date.TimeOfDay.Hours < DateTime.Now.TimeOfDay.Hours + 5)
                {
                    MessageBox.Show("You are supposed to take " + prescription.Drug.Name + " in 5 hours or less");
                }
            }
        }
    }
}