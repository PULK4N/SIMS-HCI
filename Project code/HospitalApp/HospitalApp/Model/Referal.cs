/***********************************************************************
 * Module:  Referal.cs
 * Author:  Korisnik
 * Purpose: Definition of the Class Referal
 ***********************************************************************/

using System;

namespace HospitalApp.Model
{
    public class Referal
    {
        public long ReferalId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public Appointment Appointment { get; set; }

    }
}