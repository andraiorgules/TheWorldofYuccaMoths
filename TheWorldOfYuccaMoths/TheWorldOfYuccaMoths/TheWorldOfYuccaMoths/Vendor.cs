using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TheWorldOfYuccaMoths
{
    class Vendor : Person
    {
        public static List<Item> LoadVendorInventory()
        {
            List<Item> tempInventory = new List<Item>();
            string path = "../../data/vendorInventory.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList vendorInventory = root.ChildNodes;

            foreach (XmlElement x in vendorInventory)
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
    }
}
