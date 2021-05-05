/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public class RoomContextDB : DbContext, IRoomRepository
{
    public RoomContextDB()
    {
    }

    public bool CreateRoom(Room room)
    {
        throw new NotImplementedException();
    }

    public bool DeleteRoom(Room room)
    {
        throw new NotImplementedException();
    }

    public Room GetRoom(long roomId)
    {
        return HospitalDB.Instance.Rooms.Find(roomId);
    }

    public Room GetRoom(Room room)
    {
        return HospitalDB.Instance.Rooms.Find(room.RoomId);
    }

    public bool UpdateRoom(Room room)
    {
        throw new NotImplementedException();
    }

    public List<Room> GetRooms()
    {
        return HospitalDB.Instance.Rooms.ToList();
    }
}