using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface IStaticInventoryService
{
    StaticInventory GetStaticItem(StaticInventory item);

    List<StaticInventory> GetStaticItemsFromRoom(Room room);
}
