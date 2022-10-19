using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Loot
    {
        public List<Consumable> Consumables { get; set; }
        public int Weight { get; set; }

        public Loot(List<Consumable> consumables, int weight)
        {
            Consumables = consumables;
            Weight = weight;
        }
    }
}
