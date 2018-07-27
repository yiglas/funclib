using funclib.Collections;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    class Spread :
        IFunction<object, object>
    {
        public object Invoke(object argList)
        {
            if (argList is null) return null;
            var n = next(argList);
            if (n is null)
                return seq(first(argList));

            return cons(first(argList), Invoke(n));
        }
    }
}
