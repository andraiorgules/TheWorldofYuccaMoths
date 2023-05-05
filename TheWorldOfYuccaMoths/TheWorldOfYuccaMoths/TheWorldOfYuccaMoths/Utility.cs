using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace TheWorldOfYuccaMoths
{
    //Example code from Prog201 in-class demo 
    class Utility
    {
        public static void Print(string message)
        {
            WriteLine(message);
        }
        public static void Pause()
        {
            Print("Press any key to continue...");
            ReadKey();
        }

        public static string AllItemsInList(List<Item> items)
        {
            string output = "";
            foreach (Item i in items)
            {
                output += $"{i.Name} ({i.Description})";
            }

            return output;
        }

        public int RandomNumber()
        {
            //check example code
            //need this for weather event
        }
    }
}
