using System;
﻿using Bid501_Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Drawing;

namespace Bid501_Shared
{
    public class Product //: //IProduct
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public TimeSpan Time { get; set; }

        public bool Status { get; set; }

        public double Price { get; set; }   
       // public List<Product> Products { get; set; }

        public Product(string productName, int productID, TimeSpan timeLeft, double p, bool currentStatus)
        {
            Price = p;
            Name = productName;
            ID = productID;
            Time = timeLeft;
            Status = currentStatus;
            //to be implemented 
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
