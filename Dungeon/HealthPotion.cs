using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class HealthPotion : Consumable
    {
        public override void Consume()
        {
            if (ItemOwner != null)
            {
                ItemOwner.Health += 25;
                Quantity -= 1;

                Console.WriteLine("Your health has been restored by 25");
                Console.WriteLine();
            }
        }

        public HealthPotion(int quantity)
        {
            ItemName = "Health Potion";
            Quantity = quantity;
        }
    }
}
