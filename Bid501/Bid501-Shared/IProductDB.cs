﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bid501_Shared
{
    public interface IProductDB
    {
        List<IProduct> ProductList { get; set; }
    }
}
