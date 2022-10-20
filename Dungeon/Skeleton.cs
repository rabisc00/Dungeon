using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Skeleton : Enemy
    {
        // Constructors
        public Skeleton()
        {
            Name = "Skeleton";
            Health = 20;
            Damage = 17;

            LootItems.AddRange(new List<Loot>
            {
                new Loot(new List<Consumable>
                {
                    new HealthPotion(1),
                }, 40),
                new Loot(new(), 37),
                new Loot(new List<Consumable>
                {
                    new HealthPotion(2),
                }, 15),
                new Loot(new List<Consumable>
                {
                    new HealthPotion(1),
                    new DamagePotion(1),
                }, 6),
                new Loot(new List<Consumable>
                {
                    new HealthPotion(1),
                    new DamagePotion(2),
                }, 2),
            });
        }
    }
}
