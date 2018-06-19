﻿using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsFunction :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsInstance().Invoke(typeof(IFunction), x);
    }
}
