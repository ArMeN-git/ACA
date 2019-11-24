﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class SortBySize : IComparer<Airport>
    {
        public int Compare(Airport x, Airport y)
        {
            if (x.NumOfSize > y.NumOfSize)
                return 1;
            else if (x.NumOfSize < y.NumOfSize)
                return -1;
            return 0;
        }
    }
}
