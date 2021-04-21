// File:    IRoomRepository.cs
// Author:  Nikola
// Created: Monday, April 19, 2021 9:34:36 AM
// Purpose: Definition of Interface IRoomRepository

using System;
using System.Collections.Generic;

public interface IRoomRepository
{
   bool CreateRoom(Room room);
   
   bool UpdateRoom(Room room);
   
   bool DeleteRoom(Room room);
   
   Room GetRoom(long roomId);
   
   Room GetRoom(Room room);

   List<Room> GetRooms();
}