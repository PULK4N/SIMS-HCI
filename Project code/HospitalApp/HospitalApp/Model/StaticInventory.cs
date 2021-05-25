<<<<<<< Updated upstream
﻿using System;
=======
﻿ using HospitalApp.Model;
using System;
>>>>>>> Stashed changes
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StaticInventory
{
    public StaticInventory()
    {
    }

    public StaticInventory(long staticItemId, Room room, string name, int amount)
    {
        StaticItemId = staticItemId;
        Room = room;
        Name = name;
        Amount = amount;
    }

    [Key]
    public long StaticItemId { get; set; }

    public Room Room { get; set; }

    public String Name { get; set; }

    public int Amount { get; set; }
}