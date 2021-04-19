/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using System;

public class RoomService : IRoomService
{
    private IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
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
        return _roomRepository.GetRoom(roomId);
    }

    public Room GetRoom(Room room)
    {
        return _roomRepository.GetRoom(room);
    }

    public bool UpdateRoom(Room room)
    {
        throw new NotImplementedException();
    }
}