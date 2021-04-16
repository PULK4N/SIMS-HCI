// File:    User.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:59:52 AM
// Purpose: Definition of Class User

using System;

public class User
{
   public long userId;
   public String firstName;
   public String lastName;
   public DateTime dateOfBirth;
   public String address;
   public String phoneNumber;
   public ulong jmbg;
   public String eMail;
   public RelationshipStatus sex;
   public RelationshipStatus relationshipStatus;
   
   public RegisteredUser registeredUser;

}