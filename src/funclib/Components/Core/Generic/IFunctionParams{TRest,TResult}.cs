using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    public interface IFunctionParams<TRest, TResult> : IFunctionParams
    {
        TResult Invoke(params TRest[] rest);
    }
}
