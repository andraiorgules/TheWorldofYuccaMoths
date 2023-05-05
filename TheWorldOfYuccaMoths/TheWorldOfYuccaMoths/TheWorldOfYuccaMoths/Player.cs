using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TheWorldOfYuccaMoths
{
    class Player : Person, Trade
    {
        public static List<Item> LoadPlayerInventory()
        {
            List<Item> tempInventory = new List<Item>();
            string path = "../../data/playerInventory.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList playerInventory = root.ChildNodes;

            foreach (XmlElement x in playerInventory)
            {
                tempInventory.Add(new Item()
                {
                    Name = x.GetAttribute("name"),
                    Description = x.GetAttribute("description"),
                    Amount = Convert.ToInt32(x.GetAttribute("amount"))
                });
            }

            return tempInventory;
        }

        public void Harvest()
        {
            //decrease number of yucca plants
            //put seeds into inventory
            Inventory.Add(Item.Seeds);
        }

        public void Plant()
        {
            //take seeds out of inventory 
            Inventory.Remove(Item.Seeds);
            //increase number of yucca plants
        }

        public void Feed()
        {
            //take food out of inventory 
            Inventory.Remove(Item.Food);
            //increase number of yucca moths
        }

        public void TradeItems()
        {
            Person.Buy(item);
            Person.Sell(item);
            throw new NotImplementedException();
        }
    }
}
