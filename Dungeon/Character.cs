using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Character
    {
        // Fields
        public double _chargePower = 0;
        public int _additionalDamage = 0;

        // Properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public double Shield { get; private set; } = 0;
        public double ChargePower
        {
            get => _chargePower;
            set
            {
                if (value > 1) _chargePower = 1;
                else if (value < 0) _chargePower = 0;
                else _chargePower = value;
            }
        }
        public bool IsAlive { get; set; } = true;
        public int NextAttack => (int)(Damage * (1 + ChargePower) + _additionalDamage);
        public List<Consumable> Inventory { get; private set; } = new();

        // Constructors
        public Character(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            CollectItem(new List<Consumable>() { new HealthPotion(3), new DamagePotion(2) });
            CollectItem(new List<Consumable>() { new HealthPotion(3), new DamagePotion(2) });
        }

        // Methods
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
            ChargePower = 0;
        }
        public void GetHit(Enemy enemy)
        {
            Health -= enemy.NextAttack - (int)(enemy.NextAttack * Shield);
            Shield = 0;
        }
        public void Prepare()
        {
            Shield = 0.20;
            ChargePower = 0.10;
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
            }
        }
    }
}
