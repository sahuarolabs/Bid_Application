using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class Product : IProduct
    {
        public string ProductName { get; set; }
        public int ProductID {  get; set; }

        public string ItemName { get; set; }

        public int ItemID { get; set; }

        public DateTime TimeLeft { get; set; }




        public Product()
        {

        }
    }
}
