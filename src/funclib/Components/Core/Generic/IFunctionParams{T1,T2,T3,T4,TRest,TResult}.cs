using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    public interface IFunctionParams<T1, T2, T3, T4, TRest, TResult> : IFunctionParams
    {
        TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, params TRest[] rest);
    }
}
