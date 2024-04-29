using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class Product
    {

        public string ItemName { get; set; }

        public int ItemID { get; set; }

        public DateTime TimeLeft { get; set; }

        public Status CurStatus { get; set; }

        public double MinBid { get; set; }

        public List<int> BidList { get; set; }

        public int GetHighestBid();

        public Product()
        {

        }
    }
}
