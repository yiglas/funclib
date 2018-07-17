using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class NNext :
        IFunction<object, object>
    {
        public object Invoke(object x) => new Next().Invoke(new Next().Invoke(x));
    }
}
