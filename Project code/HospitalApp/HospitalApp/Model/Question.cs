// File:    Question.cs
// Author:  Nikola
// Created: Monday, March 29, 2021 5:39:39 PM
// Purpose: Definition of Class Question

using System;
using System.ComponentModel.DataAnnotations;

public class Question
{
    [Key]
    public long QuestionId{ get; set; }
    public string QuestionInformation{ get; set; }
    public string Answer{ get; set; }
    public DateTime CreationDate{ get; set; }

}