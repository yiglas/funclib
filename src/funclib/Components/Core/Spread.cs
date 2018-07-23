using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    class Spread :
        IFunction<object, object>
    {
        public object Invoke(object argList)
        {
            if (argList == null) return null;
            var n = next(argList);
            if (n == null)
                return seq(first(argList));

            return cons(first(argList), Invoke(n));
        }
    }
}
