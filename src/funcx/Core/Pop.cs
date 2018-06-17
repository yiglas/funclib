using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Pop :
        IFunction<object, object>
    {
        public object Invoke(object coll) => coll == null ? null : ((IStack)coll).Pop();
    }
}
