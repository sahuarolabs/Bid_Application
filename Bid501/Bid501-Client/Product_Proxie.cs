using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Bid501_Client
{
    public class Product_Proxie : IProductDB
    {
        public List<IProduct> ProductList { get; set; }
    }
}
