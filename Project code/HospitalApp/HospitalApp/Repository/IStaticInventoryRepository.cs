<<<<<<< Updated upstream
﻿using System;
=======
﻿using HospitalApp.Model;
using System;
>>>>>>> Stashed changes
using System.Collections.Generic;

public interface IStaticInventoryRepository
{

    StaticInventory GetStaticItem(StaticInventory item);

    List<StaticInventory> GetStaticItemsFromRoom(Room room);

}
