using funclib.Collections.Internal;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class PopT :
        IFunction<object, object>
    {
        public object Invoke(object coll) => ((ITransientVector)coll).Pop();
    }
}
