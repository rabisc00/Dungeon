using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public abstract class Consumable
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; } = 0;
        public Character? ItemOwner { get; set; } = null;

        public abstract void Consume();
    }
}
