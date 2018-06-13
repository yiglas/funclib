﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Identity :
        IFunction<object, object>
    {
        public object Invoke(object x) => x;
    }
}
