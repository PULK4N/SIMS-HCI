// File:    User.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:59:52 AM
// Purpose: Definition of Class User

using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public long Jmbg { get; set; }

    [Required]
    [StringLength(50)]
    public String EMail{ get; set; }

    [Required]
    public Enums.Sex Sex{ get; set; }

    [Required]
    public Enums.RelationshipStatus RelationshipStatus { get; set; }

    [Required,Index("uniqueRUser", IsUnique = true)]
    public RegisteredUser RegisteredUser{ get; set; }

    public System.Collections.Generic.List<Notification> notifications;
    //Possible error because of userId, but prefferable not to be set because of DB
    public User(long userId, string firstName, string lastName, DateTime dateOfBirth, string address, string phoneNumber, long jmbg, string eMail, Sex sex, RelationshipStatus relationshipStatus, RegisteredUser registeredUser, List<Notification> notifications)
    {
        //UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Address = address;
        PhoneNumber = phoneNumber;
        Jmbg = jmbg;
        EMail = eMail;
        Sex = sex;
        RelationshipStatus = relationshipStatus;
        RegisteredUser = registeredUser;
        Notifications = notifications;
    }

    public User(User user)
    {
        this.FirstName = user.FirstName;
        this.LastName = user.LastName;
        this.DateOfBirth = user.DateOfBirth;
        this.Address = user.Address;
        this.PhoneNumber = user.PhoneNumber;
        this.Jmbg = user.Jmbg;     
        this.EMail = user.EMail;
        this.Sex = user.Sex;
        this.RelationshipStatus = user.RelationshipStatus;
        this.RegisteredUser = user.RegisteredUser;
        this.Notifications = user.Notifications;
    }

    public User()
    {
    }

    public System.Collections.Generic.List<Notification> Notifications
    {
        get
        {
            if (notifications == null)
                notifications = new System.Collections.Generic.List<Notification>();
            return notifications;
        }
        set
        {
            RemoveAllNotifications();
            if (value != null)
            {
                foreach (Notification oNotification in value)
                    AddNotification(oNotification);
            }
        }
    }


    public void AddNotification(Notification newNotification)
    {
        if (newNotification == null)
            return;
        if (this.notifications == null)
            this.notifications = new System.Collections.Generic.List<Notification>();
        if (!this.notifications.Contains(newNotification))
            this.notifications.Add(newNotification);
    }


    public void RemoveNotification(Notification oldNotification)
    {
        if (oldNotification == null)
            return;
        if (this.notifications != null)
            if (this.notifications.Contains(oldNotification))
                this.notifications.Remove(oldNotification);
    }

    public void RemoveAllNotifications()
    {
        if (notifications != null)
            notifications.Clear();
    }
}