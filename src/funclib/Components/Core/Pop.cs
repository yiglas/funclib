using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Pop :
        IFunction<object, object>
    {
        public object Invoke(object coll) => coll == null ? null : ((IStack)coll).Pop();
    }
}
