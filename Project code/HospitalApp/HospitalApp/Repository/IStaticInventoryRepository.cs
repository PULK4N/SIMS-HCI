using HospitalApp.Model;
using System;
using System.Collections.Generic;

public interface IStaticInventoryRepository
{

    StaticInventory GetStaticItem(StaticInventory item);

    List<StaticInventory> GetStaticItemsFromRoom(Room room);

}
