using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TheWorldOfYuccaMoths
{//Example code from PROG 201 Event Handlers class demo
    class Entity
    {
        private string name;
        private string species;
        private int amount;
        public string ImagePath;

        public string Status = "";
        public string Name { get => name; set => name = value; }
        public string Species { get => species; set => species = value; }
        public int Amount
        {

            get => amount;

            set
            {
                if (amount == value) return;
                if (value < 0) { amount = 0; return; }
                decimal oldAmount = amount;
                amount = value;
                OnAmountChanged(new AmountChangedEventArgs(oldAmount, amount));
            }
        }

        public event EventHandler<AmountChangedEventArgs> AmountChanged;

        protected virtual void OnAmountChanged(AmountChangedEventArgs e)
        {
            AmountChanged?.Invoke(this, e);
        }

        public void Entity_AmountChanged(object sender, AmountChangedEventArgs e)
        {
            if (e.LastAmount > e.NewAmount)
            {

                if (Species == "Prodoxidae")
                {
                    Status = "ALERT: Yucca Moth population is decreasing";
                }
            }
        }

        public class AmountChangedEventArgs : EventArgs
        {
            public readonly decimal LastAmount;
            public readonly decimal NewAmount;

            public AmountChangedEventArgs(decimal lastAmount, decimal newAmount)
            {
                LastAmount = lastAmount; NewAmount = newAmount;
            }
        }

        //code based on week 9 in-class demo
        public static List<Entity> LoadEntityData()
        {
            List<Entity> tempEntities = new List<Entity>();
            string path = "../../data/entities.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement root = doc.DocumentElement;
            XmlNodeList entities = root.ChildNodes;

            foreach (XmlElement x in entities)
            {
                tempEntities.Add(new Entity()
                {
                    Name = x.GetAttribute("name"),
                    Species = x.GetAttribute("species"),
                    ImagePath = "media/" + x.GetAttribute("imagepath") + ".png",
                    Amount = Convert.ToInt32(x.GetAttribute("amount"))
                });
            }

            return tempEntities;
        }
    }
}
