﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class BitShiftRight :
        IFunction<object, object, object>
    {
        public object Invoke(object x, object n) => Numbers.ShiftRight(x, n);
    }
}
