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

    public enum Sex
    {
        MAN,
        WOMAN,
        HERMAPHRODITE,
        NONE
    }
    public enum PatientSchedulingPriority
    {
        DOCTOR,
        DATE_TIME
    }
    public enum AppointmentType
    {
        MEDICAL_EXAMINATION,
        SURGERY
    }

}