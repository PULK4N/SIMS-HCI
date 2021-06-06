using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Model
{
    public class Bed
    {
        public Bed()
        {
        }

        public Bed(long roomId)
        {
            RoomId = roomId;
            IsAvailable = true;
        }

        [Key]
        public long BedId { get; set; }
        public long RoomId { get; set; }
        public bool IsAvailable { get; set; }

        public override string ToString()
        {
            return BedId.ToString();
        }
    }
}
