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

    public System.Collections.Generic.List<Notification> notification;

    public System.Collections.Generic.List<Notification> Notification
    {
        get
        {
            if (notification == null)
                notification = new System.Collections.Generic.List<Notification>();
            return notification;
        }
        set
        {
            RemoveAllNotification();
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
        if (this.notification == null)
            this.notification = new System.Collections.Generic.List<Notification>();
        if (!this.notification.Contains(newNotification))
            this.notification.Add(newNotification);
    }


    public void RemoveNotification(Notification oldNotification)
    {
        if (oldNotification == null)
            return;
        if (this.notification != null)
            if (this.notification.Contains(oldNotification))
                this.notification.Remove(oldNotification);
    }

    public void RemoveAllNotification()
    {
        if (notification != null)
            notification.Clear();
    }
}