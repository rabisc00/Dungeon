using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public abstract class Enemy : Character, ILootable
    {
        // Properties
        public List<Loot> LootItems { get; } = new();

        // Methods
        public List<Consumable> DropLoot()
        {
            List<Consumable> output = new();

            // Getting a random value based on the total weight of the available loots
            int totalWeight = 0;
            foreach (Loot l in LootItems) totalWeight += l.Weight;

            Random rnd = new();
            int randomNumber = rnd.Next(0, totalWeight);
            Console.WriteLine(randomNumber);

            // Checking where the random value falls
            int processedWeight = 0;
            foreach (Loot l in LootItems)
            {
                processedWeight += l.Weight;
                if (processedWeight > randomNumber) 
                {
                    output = l.Consumables;
                    break;
                }
            }

            return output;
        }
    }
}
