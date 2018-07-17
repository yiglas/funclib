using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Peek :
        IFunction<object, object>
    {
        public object Invoke(object coll) => coll == null ? null : ((IStack)coll).Peek();
    }
}
