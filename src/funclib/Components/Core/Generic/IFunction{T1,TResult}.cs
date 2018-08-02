using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    public interface IFunction<T1, TResult> : IFunction
    {
        TResult Invoke(T1 arg1);
    }
}
