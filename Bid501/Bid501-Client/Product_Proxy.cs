using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Client
{
    public class Product_Proxy : IProduct
    {
        public List<double> GetBidList() 
        {
            throw new NotImplementedException();
        }

        public Bid501_Shared.Status GetCurStatus()
        {
            throw new NotImplementedException();
        }

        public string GetItemName()
        {
            throw new NotImplementedException();
        }

        public double GetMinBid()
        {
            throw new NotImplementedException();
        }

        public DateTime GetTimeLeft()
        {
            throw new NotImplementedException();
        }

        public void ServerUpdate(List<IProduct> listProduct)
        {
            throw new NotImplementedException();
        }
    }
}
