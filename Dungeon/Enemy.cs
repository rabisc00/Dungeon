using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Enemy : Character, ILootable
    {
        // Properties
        public List<Loot> LootItems { get; } = new()
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
        };

        // Constructors
        public Enemy(string name, int health, int damage) : base(name, health, damage) {}

        // Methods
        public List<Consumable> DropLoot()
        {
            List<Consumable> output = new();

            // Getting a random value based on the total weight of the available loots
            int totalWeight = 0;
            foreach (Loot l in LootItems) totalWeight += l.Weight;

            Random rnd = new();
            int randomNumber = rnd.Next(0, totalWeight);

            // Checking where the random value falls
            int processedWeight = 0;
            foreach (Loot l in LootItems)
            {
                processedWeight += l.Weight;
                if (processedWeight > randomNumber) output = l.Consumables;
            }

            return output;
        }
    }
}
