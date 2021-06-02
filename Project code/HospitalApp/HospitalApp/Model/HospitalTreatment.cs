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

        public HospitalTreatment(long treatmentId, DateTime beginning, DateTime end, AppointmentStatus appointmentStatus, Patient patient, Room room, long bed)
        {
            TreatmentId = treatmentId;
            Beginning = beginning;
            End = end;
            AppointmentStatus = appointmentStatus;
            Patient = patient;
            Room = room;
            Bed = bed;
        }

        [Key]
        public long TreatmentId { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }

        public Patient Patient { get; set; }

        public Room Room { get; set; }
        public long Bed { get; set; }
    }
}
