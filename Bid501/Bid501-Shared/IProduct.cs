﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    public interface IProduct
    {
        string Name { get; set; }
        int ID { get; set; }

        DateTime Time { get; set; }

        bool Status { get; set; }
    }
}
