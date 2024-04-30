using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;

namespace Bid501_Client
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
    }
}
