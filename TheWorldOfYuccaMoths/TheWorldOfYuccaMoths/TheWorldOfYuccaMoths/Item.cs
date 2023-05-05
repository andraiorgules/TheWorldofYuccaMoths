using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfYuccaMoths
{
    public class Item
    {
        public string name = "";
        public string description = "";
        public float amount;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public float Amount { get => amount; set => amount = value; }
    }

}
