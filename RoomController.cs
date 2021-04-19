/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using System;

public abstract class RoomController
{
   private IRoomService _roomService;
   
   public abstract bool CreateRoom(Room room);
   
   public abstract bool UpdateRoom(Room room);
   
   public abstract bool DeleteRoom(Room room);
   
   public abstract Room GetRoom(long roomId);
   
   public abstract Room GetRoom(Room room);

}