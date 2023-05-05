using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfYuccaMoths
{
    //Example code from Prog201 in-class enum demo
    enum Environmentstatus
    {
        balanced,
        unbalanced,
        unsound
    }

    class Environment
    {
        private string name = "Mojave Desert Yucca Moth Ecosystem";
        public string Name { get => name; set => name = value; }

        //Example code from Prog201 in-class enum demo
        public Environmentstatus Status = Environmentstatus.balanced;

        //check example code for counter
        public int CurrentDay;

        public List<Entity> Entities = Entity.LoadEntityData();
    }
}
