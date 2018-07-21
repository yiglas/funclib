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
            var next = new Next().Invoke(argList);
            if (next == null)
                return new Seq().Invoke(new First().Invoke(argList));

            return cons(new First().Invoke(argList), new Spread().Invoke(next));
        }
    }
}
