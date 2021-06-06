using HospitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IStaticInventoryService
{
    StaticInventory GetStaticItem(StaticInventory item);

    List<StaticInventory> GetStaticItemsFromRoom(Room room);
}
