using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApp.Model
{
    public class Secretary
    {
        [Key]
        public long SecretaryId { get; set; }

        [Required, Index("uniqueEmpSec", IsUnique = true)]
        public Employee Employee { get; set; }

    }
}