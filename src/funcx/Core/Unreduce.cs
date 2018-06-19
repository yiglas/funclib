using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Unreduce :
        IFunction<object, object>
    {
        public object Invoke(object x) =>
            (bool)new IsReduced().Invoke(x)
                ? new Deref().Invoke(x)
                : x;
    }
}
