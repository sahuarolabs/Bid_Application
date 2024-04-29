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

        public DateTime TimeLeft { get; set; }

        public bool CurrentStatus { get; set; }

        public List<Product> Products { get; set; }

        public Product(string productName, int productID, DateTime timeLeft, bool currentStatus )
        {
            ProductName = productName;
            ProductID = productID;
            TimeLeft = timeLeft;
            CurrentStatus = currentStatus;
            Products = CurrentItems();
//to be implemented 
        }


    }
}
