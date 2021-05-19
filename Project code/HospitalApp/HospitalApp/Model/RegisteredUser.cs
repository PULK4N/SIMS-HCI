// File:    RegisteredUser.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:05:47 AM
// Purpose: Definition of Class RegisteredUser

using Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApp.Model
{
    public class RegisteredUser
    {
        public RegisteredUser(RegisteredUser registeredUser)
        {
            Username = registeredUser.Username;
            Password = registeredUser.Password;
            UserType = registeredUser.UserType;
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
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public UserType UserType { get; set; }


    }
}