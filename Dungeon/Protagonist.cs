using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    internal class Protagonist : Character
    {
        // Constructors
        public Protagonist(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        // Methods
        public void DisplayInfo()
        {
            Console.WriteLine($"{Name}: {Health} Health | {Damage} Attack");
            Console.WriteLine("Your next attack will deal {0} damage.", NextAttack);
            Console.WriteLine();
        }
        public bool ShowInventory()
        {
            if (Inventory.Any())
            {
                foreach (Consumable item in Inventory)
                {
                    Console.WriteLine(item.ItemName + " (x" + item.Quantity + ")");
                }

                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine("Inventory is empty\n");
                return false;
            }
        }
        public void CollectItem(List<Consumable> items)
        {
            if (items.Any())
            {
                foreach (Consumable iNew in items)
                {
                    int matchIndex = Inventory.FindIndex(i => i.GetType() == iNew.GetType());

                    if (matchIndex != -1)
                    {
                        Inventory[matchIndex].Quantity += iNew.Quantity;
                    }
                    else
                    {
                        iNew.ItemOwner = this;
                        Inventory.Add(iNew);
                    }

                    Console.WriteLine($"{iNew.ItemName} (x{iNew.Quantity}) added to your inventory.");
                }
            }
            else
            {
                Console.WriteLine("The enemy didn't drop any items. Better luck next time!");
            }

            Console.WriteLine();
        }
    }
}
