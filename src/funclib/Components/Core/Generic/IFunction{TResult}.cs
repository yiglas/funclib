using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core.Generic
{
    public interface IFunction<TResult> : IFunction
    {
        TResult Invoke();
    }
}
