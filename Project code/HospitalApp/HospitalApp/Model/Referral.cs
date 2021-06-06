/***********************************************************************
 * Module:  Referal.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class Referal
 ***********************************************************************/

using System;

namespace HospitalApp.Model
{
    public class Referral
    {
        public long ReferralId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Patient Patient{ get; set; }

    }
}