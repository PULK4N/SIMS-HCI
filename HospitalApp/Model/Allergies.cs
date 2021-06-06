using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Model
{
    public class Allergies
    {
        public Allergies()
        {
        }

        public Allergies(string allergieType)
        {
            AllergieType = allergieType;
        }

        [Key]
        public long AllergiesId { get; set; }
        public string AllergieType { get; set; }
    }
}
