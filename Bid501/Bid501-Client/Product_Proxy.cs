using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Bid501_Client
{
    public class Product_Proxy : IProduct
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
        public List<double> bidHistory { get; set; }
    }
}
