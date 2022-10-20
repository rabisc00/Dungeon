using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public abstract class Character
    {
        // Fields
        public double _chargePower = 0;
        public int _additionalDamage = 0;

        // Properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; } = true;
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
        public int NextAttack => (int)(Damage * (1 + ChargePower) + _additionalDamage);
        public List<Consumable> Inventory { get; private set; } = new();

        // Methods
        public void GetHit(Character character)
        {
            Health -= character.NextAttack - (int)(character.NextAttack * Shield);
            Shield = 0;

            character._chargePower = 0;
            character._additionalDamage = 0;
        }
        public void Prepare()
        {
            Shield = 0.20;
            ChargePower = 0.10;
        }
        public void ConsumeItem(string itemName)
        {
            foreach (Consumable item in Inventory)
            {
                if (item.ItemName.ToLower() == itemName)
                {
                    item.Consume();
                    if (item.Quantity <= 0)
                    {
                        Inventory.Remove(item);
                    }

                    return;
                }
            }
        }
    }
}
