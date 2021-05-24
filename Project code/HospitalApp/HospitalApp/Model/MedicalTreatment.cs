using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Model
{
    class MedicalTreatment
    {
        public MedicalTreatment(long medicalTreatmentId, int period, DateTime beginning, DateTime end, string description)
        {
            MedicalTreatmentId = medicalTreatmentId;
            Period = period;
            Beginning = beginning;
            End = end;
            Description = description;
        }
        public MedicalTreatment()
        {
        }

        long MedicalTreatmentId { get; set; }
        int Period { get; set; }
        DateTime Beginning { get; set; }
        DateTime End { get; set; }
        string Description { get; set; }

    }
}
