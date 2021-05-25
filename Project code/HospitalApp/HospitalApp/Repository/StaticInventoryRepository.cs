using HospitalApp.Model;
using HospitalApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StaticInventoryRepository : IStaticInventoryRepository
{
    public StaticInventory GetStaticItem(StaticInventory item)
    {
        return HospitalDB.Instance.StaticInventories.Find(item);
    }

    public List<StaticInventory> GetStaticItemsFromRoom(Room room)
    {
        try
        {
            List<StaticInventory> staticItems = (from si in HospitalDB.Instance.StaticInventories where si.Room.RoomId == room.RoomId select si).ToList();
            return staticItems;
        }
        catch
        {

        }
        return null;
    }
}
