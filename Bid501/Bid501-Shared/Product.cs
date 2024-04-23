using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public class Product
    {
        public string ItemName { get; set; }
        public int ItemID { get; set; }
        public DateTime TimeLeft { get; set; }
        public Status CurStatus { get; set; }
        public double MinBid { get; set; }
        public List<int> BidList { get; set; }

        public int GetHighestBid()
        {
            int maxBid = 0;
            foreach(int i in BidList)
            {
                if (i > maxBid) maxBid = i;
            }
            return maxBid;
        }
    }
}
