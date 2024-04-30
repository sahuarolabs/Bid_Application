using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class ProductModel
    {

        private List<Product> products;
        public List<Product> hardcoded;
        public ProductModel()
        {
            products = new List<Product>();
            hardcoded = new List<Product>();
            OnOpen();
            TimeSpan ts1 = new TimeSpan(2, 14, 18);
            TimeSpan ts2 = new TimeSpan(10, 22, 11);
            TimeSpan ts3 = new TimeSpan(5, 21, 15);
            Product waterBottle = new Product("WaterBottle", 004, ts2, 15.27, true);
            Product calculator = new Product("Calculator", 006, ts1, 55.65, true);
            Product miniProjector = new Product("Mini Projector", 008,ts3, 104.20, true);
            Product ps4 = new Product("PS4", 008, ts1, 480.99, true);

            hardcoded.Add(waterBottle);
            hardcoded.Add(calculator);
            hardcoded.Add(miniProjector);
            hardcoded.Add(ps4);
        }

        public void OnOpen()
        {
            List<Product> templist = new List<Product>();
            if (File.Exists("..\\..\\products.txt"))
            {
                StreamReader streamReader = new StreamReader("..\\..\\products.txt");
                while (!streamReader.EndOfStream)
                {
                    string currentproduct = streamReader.ReadLine();
                    Product p = JsonConvert.DeserializeObject<Product>(currentproduct);            
                    templist.Add(p);
                    ProductModelAdd(p);
                }
                streamReader.Close();
            }
        }

        public List<Product> SyncHardcoded() { return this.hardcoded; }
        public List<Product> Sync() { return this.products; }
        public void RemoveHardcoded(Product p)
        {
            hardcoded.Remove(p);
        }
        public void ProductModelAdd(Product p)
        {
            products.Add(p);
        }

        /* ONLY USE IF CHANGING PRODUCTS THROW IN CONSTRUCTOR 
         TimeSpan ts4 = new TimeSpan(3, 19, 29);
            TimeSpan ts5 = new TimeSpan(1, 11, 11);
            TimeSpan ts6 = new TimeSpan(8, 11, 11);
            Product iphone = new Product("IPhone XS", 001, ts4, 670.00, true);
            Product coffeeMug = new Product("Coffee Mug", 002, ts5, 8.99, false);
            Product computer = new Product("Computer", 003, ts6,277.00, true);
            products.Add(computer);
            products.Add(iphone);
            products.Add(coffeeMug);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Product p in products)
            {
                string writeJson = JsonConvert.SerializeObject(p);
                stringBuilder.Append(writeJson + "\n");
            }
            File.WriteAllText("..\\..\\products.txt", stringBuilder.ToString());
         */
    }
}
