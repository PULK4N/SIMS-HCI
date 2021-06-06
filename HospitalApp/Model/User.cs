// File:    User.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 10:59:52 AM
// Purpose: Definition of Class User

using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApp.Model
{
    public class User
    {


        [Key]
        public long UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        public long Jmbg { get; set; }

        [Required]
        [StringLength(50)]
        public string EMail { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public RelationshipStatus RelationshipStatus { get; set; }

        [Required, Index("uniqueRUser", IsUnique = true)]
        public RegisteredUser RegisteredUser { get; set; }

        public List<Notification> notifications;
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
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateOfBirth = user.DateOfBirth;
            Address = user.Address;
            PhoneNumber = user.PhoneNumber;
            Jmbg = user.Jmbg;
            EMail = user.EMail;
            Sex = user.Sex;
            RelationshipStatus = user.RelationshipStatus;
            RegisteredUser = user.RegisteredUser;
            Notifications = user.Notifications;
        }

        public User()
        {
        }

        public List<Notification> Notifications
        {
            get
            {
                if (notifications == null)
                    notifications = new List<Notification>();
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
            if (notifications == null)
                notifications = new List<Notification>();
            if (!notifications.Contains(newNotification))
                notifications.Add(newNotification);
        }


        public void RemoveNotification(Notification oldNotification)
        {
            if (oldNotification == null)
                return;
            if (notifications != null)
                if (notifications.Contains(oldNotification))
                    notifications.Remove(oldNotification);
        }

        public void RemoveAllNotifications()
        {
            if (notifications != null)
                notifications.Clear();
        }
    }
}