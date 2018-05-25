using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Identity<T> :
        IFunction<T, T>
    {
        public T Invoke(T x) => x;
    }
}
