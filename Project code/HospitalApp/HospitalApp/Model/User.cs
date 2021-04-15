// File:    User.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:59:52 AM
// Purpose: Definition of Class User

using System;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public long UserId { get; set; }

    [Required]
    [StringLength(50)]
    public String FirstName{ get; set; }

    [Required]
    [StringLength(50)]
    public String LastName{ get; set; }

    [Required]
    public DateTime DateOfBirth{ get; set; }

    [Required]
    [StringLength(50)]
    public String Address{ get; set; }

    [Required]
    [StringLength(50)]
    public String PhoneNumber{ get; set; }

    [Required]
    public ulong Jmbg { get; set; }

    [Required]
    [StringLength(50)]
    public String EMail{ get; set; }

    [Required]
    public Enums.Sex Sex{ get; set; }

    [Required]
    public Enums.RelationshipStatus RelationshipStatus { get; set; }

    [Required]
    public RegisteredUser RegisteredUser{ get; set; }

}