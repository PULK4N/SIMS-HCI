// File:    Enumerations.cs
// Author:  Nikola
// Created: Sunday, March 28, 2021 7:49:47 PM
// Purpose: Definition of Class Enumerations

using System;

namespace Enums{ 
    public enum AppointmentStatus
    {
        PENDING,
        ACTIVE,
        COMPLETED
    }
    public enum RoomStatus
    {
        FREE,
        TAKEN,
        RENOVATION
    }

    public enum AppointmentType
    {
        MEDICAL_EXAMINATION,
        SURGERY
    }

    public enum PatientSchedulingPriority
    {
        DOCTOR,
        DATE_TIME
    }

    public enum Sex
    {
        MAN,
        WOMAN,
        HERMAPHRODITE,
        NONE
    }


    public enum RoomType
    {
        WAREHOUSE,
        OPERATING_THEATER,
        CHECKUP_ROOM
    }

    public enum Specialization
    {
        SURGEON,
        NONE
    }

    public enum Usertype
    {
        PATIENT,
        DOCTOR,
        SECRETARY
    }

    public enum RelationshipStatus
    {
        MARRIED,
        DIVORCED,
        WIDOWED,
        SINGLE,
        OTHER
    }
}