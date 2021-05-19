// File:    IRoomRepository.cs
// Author:  Nikola
// Created: Monday, April 19, 2021 9:34:36 AM
// Purpose: Definition of Interface IRoomRepository

using HospitalApp.Model;
using System;
using System.Collections.Generic;

namespace HospitalApp.Repository
{
    public interface IRoomRepository : IEntityRepository<Room>
    {
    }
}