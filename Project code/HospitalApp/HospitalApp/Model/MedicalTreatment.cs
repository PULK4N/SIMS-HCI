using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Model
{
    public class MedicalTreatment
    {
        public MedicalTreatment(long medicalTreatmentId, Enums.MedicalTreatementPeriod period, DateTime beginning, DateTime end, string description)
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

        public long MedicalTreatmentId { get; set; }
        public Enums.MedicalTreatementPeriod Period { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }

    }
}
