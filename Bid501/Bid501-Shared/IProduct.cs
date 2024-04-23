using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public enum Status { Available, Unavailable}
    public interface IProduct
    {
        List<Product> CurrentItems();

        List<Product> ServerUpdate();
        string GetItemName();
        List<int> GetBidList();
        double GetMinBid();
        DateTime GetTimeLeft();
        Status GetCurStatus();
    }
}
