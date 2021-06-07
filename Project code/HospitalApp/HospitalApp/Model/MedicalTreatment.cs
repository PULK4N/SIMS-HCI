using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Model
{
    class MedicalTreatment
    {
        public MedicalTreatment(long medicalTreatmentId, MedicalTreatementPeriod period, DateTime beginning, DateTime end, string description)
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
        public MedicalTreatementPeriod Period { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return "Medical treatment beginning: " + Beginning.ToString()
                + "\n\n" + "Description: \n" + Description + "\n" + "\nTreatement period: " + Period.ToString() + 
                " \n \n" + "------------------------------------------------------------- \n \n" 
                         + "------------------------------------------------------------- \n \n";
        }

    }
}
