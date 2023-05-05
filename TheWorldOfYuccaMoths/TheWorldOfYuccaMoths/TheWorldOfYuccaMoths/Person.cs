using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfYuccaMoths
{
    public class Person
    {
        public string Name = "";
        public List<Item> Inventory = new List<Item>();

        public void Buy(string item)
        {
            if (item == "Food")
            {
                Item Food = new Item()
                {
                    Name = "Food",
                    Amount = 1,
                    Description = "Used to increase yucca moth population"
                };
                Inventory.Add(Food);
            }
            if (item == "Seeds")
            {
                Item Seeds = new Item()
                {
                    Name = "Seeds",
                    Amount = 1,
                    Description = "Used to increase yucca plant population"
                };
                Inventory.Add(Seeds);
            }
        }

        public void Sell(string item)
        {
            //remove selected item from inventory
            Inventory.Remove(item);
        }
    }
}
