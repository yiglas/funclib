using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class EnsureReduced :
        IFunction<object, object>
    {
        public object Invoke(object x) => x is Collections.Reduced r ? r.Deref() : x;
    }
}
