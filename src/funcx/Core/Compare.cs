﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Compare :
        IFunction<object, object, int>
    {
        public int Invoke(object x, object y)
        {
            if (x == y) return 0;
            if (x != null)
            {
                if (y == null) return 1;
                if (Number.IsNumber(x) && Number.IsNumber(y))
                    return Number.Compare(x, y);

                return (x as IComparable).CompareTo(y);
            }

            return -1;
        }
    }
}
