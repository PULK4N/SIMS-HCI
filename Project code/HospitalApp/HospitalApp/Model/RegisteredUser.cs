// File:    RegisteredUser.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:05:47 AM
// Purpose: Definition of Class RegisteredUser

using Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RegisteredUser
{
    public RegisteredUser(RegisteredUser registeredUser)
    {
        this.Username = registeredUser.Username;
        this.Password = registeredUser.Password;
        this.UserType = registeredUser.UserType;
    }

    public RegisteredUser(string username, string password, UserType userType)
    {
        Username = username;
        Password = password;
        UserType = userType;
    }

    public RegisteredUser()
    {
    }

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