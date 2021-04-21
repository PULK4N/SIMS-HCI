// File:    IRoomService.cs
// Author:  Nikola
// Created: Monday, April 19, 2021 9:38:02 AM
// Purpose: Definition of Interface IRoomService

using System;
using System.Collections.Generic;

public interface IRoomService
{
   bool CreateRoom(Room room);
   
   bool UpdateRoom(Room room);
   
   bool DeleteRoom(Room room);
   
   Room GetRoom(long roomId);
   
   Room GetRoom(Room room);

   List<Room> GetRooms();

}