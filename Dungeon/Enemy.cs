using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Enemy : Character
    {
        // Constructors
        public Enemy(string name, int health, int damage) : base(name, health, damage) {}
    }
}
