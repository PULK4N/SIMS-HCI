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
        COMPLETED,
        CANCELED,
        REVIEWED
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

    public enum ReferalSchedulingPriority
    {
        SPECIFIC_DOCTOR,
        SPECIALIST
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

    public enum UserType
    {
        PATIENT,
        DOCTOR,
        SECRETARY,
        BANNNED_USER
    }

    public enum RelationshipStatus
    {
        MARRIED,
        DIVORCED,
        WIDOWED,
        SINGLE,
        OTHER
    }

    public enum DrugStatus
    {
        APPROVED,
        REJECTED,
        PENDING
    }

    public enum ReviewType
    {
        DOCTOR,
        CLINIC
    }

    public enum HospitalTreatmentStatus
    {
        PENDING,
        ACTIVE,
        COMPLETED,
        CANCELED,
        REVIEWED
    }

}