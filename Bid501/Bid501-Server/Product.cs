using System;
﻿using Bid501_Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Drawing;

namespace Bid501_Server
{
    public class Product
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public DateTime Time { get; set; }

        public bool Status { get; set; }

        public List<Product> Products { get; set; }

        public Product(string productName, int productID, DateTime timeLeft, bool currentStatus)
        {
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
