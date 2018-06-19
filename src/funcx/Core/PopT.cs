using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class PopT :
        IFunction<object, object>
    {
        public object Invoke(object coll) => ((ITransientVector)coll).Pop();
    }
}
