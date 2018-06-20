using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Persistent :
        IFunction<object, object>
    {
        public object Invoke(object coll) => ((ITransientCollection)coll).ToPersistent();
    }
}
