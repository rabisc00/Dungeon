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
        // Properties
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public Character? ItemOwner { get; set; } = null;

        // Methods
        public abstract void Consume();
    }
}
