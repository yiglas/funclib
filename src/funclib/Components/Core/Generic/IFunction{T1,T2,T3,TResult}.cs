using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    public interface IFunction<T1, T2, T3, TResult> : IFunction
    {
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3);
    }

}
