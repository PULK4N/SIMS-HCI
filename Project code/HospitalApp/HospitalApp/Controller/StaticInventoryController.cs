<<<<<<< Updated upstream
﻿using System;
=======
﻿using HospitalApp.Model;
using System;
>>>>>>> Stashed changes
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StaticInventoryController
{
<<<<<<< Updated upstream
    private readonly StaticInventoryService _staticInventoryService;

    public StaticInventoryController(StaticInventoryService staticInventoryService)
=======
    private readonly IStaticInventoryService _staticInventoryService;

    public StaticInventoryController(IStaticInventoryService staticInventoryService)
>>>>>>> Stashed changes
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
