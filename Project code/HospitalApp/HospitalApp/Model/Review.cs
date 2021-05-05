// File:    Review.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:00:28 PM
// Purpose: Definition of Class Review

using System;
using System.ComponentModel.DataAnnotations;

public class Review
{
    [Key]
    public long ReviewId{ get; set; }
    public int Score{ get; set; }
    public String Comment{ get; set; }
    public Enums.ReviewType ReviewType { get; set; }
    public Appointment Appointment { get; set; }
}