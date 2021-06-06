using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Model
{
    public class PatientAllergies
    {
        public PatientAllergies()
        {
        }

        public PatientAllergies(Patient patient, Allergies allergies)
        {
            this.Patient = patient;
            this.Allergies = allergies;
        }

        [Key]
        public long PatientAllergiesId { get; set; }
        public Patient Patient { get; set; }
        public Allergies Allergies { get; set; }

    }
}
