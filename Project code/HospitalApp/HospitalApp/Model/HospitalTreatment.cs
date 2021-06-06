using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Model
{
    public class HospitalTreatment
    {
        public HospitalTreatment()
        {
        }

        public HospitalTreatment(DateTime beginning, DateTime end, HospitalTreatmentStatus hospitalTreatmentStatus, Patient patient, Room room, Bed bed)
        {
            Beginning = beginning;
            End = end;
            HospitalTreatmentStatus = hospitalTreatmentStatus;
            Patient = patient;
            Room = room;
            Bed = bed;
        }

        [Key]
        public long TreatmentId { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
        public HospitalTreatmentStatus HospitalTreatmentStatus { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public Bed Bed { get; set; }

    }
}
