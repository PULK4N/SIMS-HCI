/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HospitalApp.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public RoomRepository()
        {
        }

        public void Create(Room room)
        {
            throw new NotImplementedException();
        }

        public void Delete(long roomId)
        {
            throw new NotImplementedException();
        }

        public Room Get(long roomId)
        {
            return HospitalDB.Instance.Rooms.Find(roomId);
        }

        public Room Get(Room room)
        {
            return HospitalDB.Instance.Rooms.Find(room.RoomId);
        }

        public void Update(Room room)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAll()
        {
            return HospitalDB.Instance.Rooms.ToList();
        }
    }
}