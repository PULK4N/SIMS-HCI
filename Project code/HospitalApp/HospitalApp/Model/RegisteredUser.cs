// File:    RegisteredUser.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:05:47 AM
// Purpose: Definition of Class RegisteredUser

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RegisteredUser
{
    [Key]
    public long RegUserId { get; set; }
    public String EncryptedID{ get; set; }
    [Required]
    public String Username{ get; set; }
    [Required]
    public String Password{ get; set; }
    public Enums.UserType UserType { get; set; }

//    public User User{ get; set; }

}