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


<<<<<<< Updated upstream
interface IStaticInventoryService
=======
public interface IStaticInventoryService
>>>>>>> Stashed changes
{
    StaticInventory GetStaticItem(StaticInventory item);

    List<StaticInventory> GetStaticItemsFromRoom(Room room);
}
