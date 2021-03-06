// File:    Review.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:00:28 PM
// Purpose: Definition of Class Review

using Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Model
{
    public class Review
    {
        public Review()
        {
        }

        public Review(int score, string comment, ReviewType reviewType, Appointment appointment)
        {
            Score = score;
            Comment = comment;
            ReviewType = reviewType;
            Appointment = appointment;
        }

        [Key]
        public long ReviewId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public ReviewType ReviewType { get; set; }
        public Appointment Appointment { get; set; }
    }
}