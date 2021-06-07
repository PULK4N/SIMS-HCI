using HospitalApp.Model;
using HospitalApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalApp.Controller
{
    public class RoomController : IEntityController<Room>
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public void Create(Room room)
        {
            _roomService.Create(room);
        }

        public void Update(Room room)
        {
            _roomService.Update(room);
        }

        public void Delete(long roomId)
        {
            _roomService.Delete(roomId);
        }

        public Room Get(long roomId)
        {
            return _roomService.Get(roomId);
        }

        public List<Room> GetAll()
        {
            return _roomService.GetAll();
        }

        public List<Room> GetAllAvailableForTreatment()
        {
            return _roomService.GetAllAvailableForTreatment();
        }
    }
}