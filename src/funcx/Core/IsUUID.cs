﻿using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsUUID :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsInstance().Invoke(typeof(Guid), x);
    }
}
