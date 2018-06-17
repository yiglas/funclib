using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Peek :
        IFunction<object, object>
    {
        public object Invoke(object coll) => coll == null ? null : ((IStack)coll).Peek();
    }
}
