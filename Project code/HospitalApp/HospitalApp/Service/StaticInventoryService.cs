using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StaticInventoryService : IStaticInventoryService
{
    private readonly IStaticInventoryRepository _staticInventoryRepository;

    public StaticInventoryService(IStaticInventoryRepository staticInventoryRepository)
    {
        _staticInventoryRepository = staticInventoryRepository;
    }

    public StaticInventory GetStaticItem(StaticInventory item)
    {
        return _staticInventoryRepository.GetStaticItem(item);
    }

    public List<StaticInventory> GetStaticItemsFromRoom(Room room)
    {
        return _staticInventoryRepository.GetStaticItemsFromRoom(room);
    }
}