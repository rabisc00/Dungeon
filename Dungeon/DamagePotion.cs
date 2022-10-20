using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    internal class DamagePotion : Consumable
    {
        // Constructors
        public DamagePotion(int quantity)
        {
            ItemName = "Damage Potion";
            Quantity = quantity;
        }

        // Methods
        public override void Consume()
        {
            if (ItemOwner != null)
            {
                ItemOwner.ChargePower = 1;
                ItemOwner._additionalDamage += 10;

                Console.WriteLine("Your next attack is powered!");
                Console.WriteLine();
            }
        }
    }
}
