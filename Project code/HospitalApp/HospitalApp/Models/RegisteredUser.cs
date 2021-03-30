// File:    RegisteredUser.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 11:05:47 AM
// Purpose: Definition of Class RegisteredUser

using System;
using System.ComponentModel.DataAnnotations;

public class RegisteredUser
{
    [Key]
    public long regUserId { get; set; }
   public String encryptedID{ get; set; }
   public String username{ get; set; }
   public String password{ get; set; }
   
   //public User user{ get; set; }

}