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

    public String firstName{ get; set; }
    public String lastName{ get; set; }
    public DateTime dateOfBirth{ get; set; }
    public String address{ get; set; }
    public String phoneNumber{ get; set; }
    public int jmbg{ get; set; }
    public String eMail{ get; set; }
    public Enums.Sex sex{ get; set; }


    public RegisteredUser registeredUser{ get; set; }

}