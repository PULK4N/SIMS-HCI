/***********************************************************************
 * Module:  PatientAccountManagement.cs
 * Author:  Aleksa
 * Purpose: Definition of the Class PatientAccountManagement
 ***********************************************************************/

using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalApp.Service
{
    public class RoomService : IRoomService
    {
        private IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Create(Room room)
        {
            _roomRepository.Create(room);
        }

        public void Delete(long roomId)
        {
            _roomRepository.Delete(roomId);
        }

        public Room Get(long roomId)
        {
            return _roomRepository.Get(roomId);
        }


        public List<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public void Update(Room room)
        {
            _roomRepository.Update(room);
        }

        public List<Room> GetAllAvailableForTreatment()
        {
            List<Bed> AllBeds = (from r in HospitalDB.Instance.Bed where r.IsAvailable select r).ToList();
            List<Room> filteredRooms = new List<Room>();
            foreach(Bed b in AllBeds)
            {
                if (!filteredRooms.Contains(_roomRepository.Get(b.RoomId))) 
                    filteredRooms.Add(_roomRepository.Get(b.RoomId));
            }
            return filteredRooms;
        }
    }
}