using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public interface IProducts
    {
        public List<Product> CurrentItems();

        public List<Product> ServerUpdate();

        public string GetItemName();

        public List<int> GetBidList();

        public double GetMinBid();

        public DateTime GettTimeLeft();

        public Status GetCurStatus();
    }
}
