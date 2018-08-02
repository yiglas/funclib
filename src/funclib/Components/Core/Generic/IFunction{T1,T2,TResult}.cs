using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    public interface IFunction<T1, T2, TResult> : IFunction
    {
        TResult Invoke(T1 arg1, T2 arg2);
    }
}
