using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class ProductModel
    {

        private List<Product> products;
        Product iphone = new Product("IPhone XS", 001, DateTime.Now, true);
        Product coffeeMug = new Product("Coffee Mug", 002, DateTime.Now, false);
        Product computer = new Product("Computer", 003, DateTime.Now, true);
        public ProductModel()
        { 
            products = new List<Product>();
            products.Add(iphone);
            products.Add(coffeeMug);
            products.Add(computer);
        }
        public List<Product> Sync() { return this.products; }
        public void ProductModelAdd(Product p)
        {
            products.Add(p);
        }
    }
}
