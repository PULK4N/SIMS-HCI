using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StaticInventoryController
{
    private readonly IStaticInventoryService _staticInventoryService;

    public StaticInventoryController(IStaticInventoryService staticInventoryService)
    {
        _staticInventoryService = staticInventoryService;
    }

    public StaticInventory GetStaticItem(StaticInventory item)
    {
        return _staticInventoryService.GetStaticItem(item);
    }

    public List<StaticInventory> GetStaticItemsFromRoom(Room room)
    {
        return _staticInventoryService.GetStaticItemsFromRoom(room);
    }
}
