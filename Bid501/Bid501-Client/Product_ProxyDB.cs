using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Client
{
    public class Product_ProxyDB : IProductDB
    {
        public List<IProduct> ProductList { get; set; }
        public List<Product_Proxy> PL{ get; set; }
    }
}
