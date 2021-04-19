using System;

public class RoomController
{
   private IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public  bool CreateRoom(Room room)
    {
        return _roomService.CreateRoom(room);
    }
   
   public  bool UpdateRoom(Room room)
    {
        return _roomService.UpdateRoom(room);
    }
   
   public  bool DeleteRoom(Room room)
    {
        return _roomService.DeleteRoom(room);
    }
   
   public  Room GetRoom(long roomId)
    {
        return _roomService.GetRoom(roomId);
    }
   
   public  Room GetRoom(Room room)
    {
        return _roomService.GetRoom(room);
    }

}