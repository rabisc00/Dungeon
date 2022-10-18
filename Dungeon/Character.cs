using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Character
    {
        protected double _chargePower = 0;

        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public double Shield { get; private set; } = 0;
        public bool IsAlive { get; set; } = true;
        public int NextAttack { get; private set; }
        public List<Consumable> Inventory { get; private set; } = new();

        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            NextAttack = Damage;
            CollectItem(new List<Consumable>() { new HealthPotion(3) });
        }

        public void DisplayInfo(Enemy enemy)
        {
            Console.WriteLine($"{Name}: {Health} Health | {Damage} Attack");
            Console.WriteLine("Your next attack will deal {0} damage.", NextAttack);
            Console.WriteLine("You'll take {0} damage next turn.", enemy.NextAttack - (int)(Shield * NextAttack));
            Console.WriteLine();
        }
        public void HitEnemy(Character whoToHit)
        {
            whoToHit.Health -= NextAttack - (int)(whoToHit.Shield * NextAttack);
            _chargePower = 0;
        }
        public void GetHit(Enemy enemy)
        {
            Health -= enemy.NextAttack - (int)(enemy.NextAttack * Shield);
            Shield = 0;
        }
        public void Prepare()
        {
            Shield = 0.20;
            _chargePower = 0.10;

            NextAttack = (int)(Damage * (1 + _chargePower));
        }
        public void ShowInventory()
        {
            foreach (Consumable item in Inventory)
            {
                if (item.Quantity > 1)
                {
                    Console.WriteLine(item.ItemName + " (x" + item.Quantity + ")");
                }     
            }
            Console.WriteLine();
        }
        public void ConsumeItem(string itemName)
        {
            foreach (Consumable item in Inventory)
            {
                if (item.ItemName.ToLower() == itemName)
                {
                    item.Consume();
                }
            }
        }
        public void CollectItem(List<Consumable> items)
        {
            foreach (Consumable item in items)
            {
                item.ItemOwner = this;
                Inventory.Add(item);
            }
        }
    }
}
