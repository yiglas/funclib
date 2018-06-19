using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Deref :
        IFunction<object, object>
    {
        public object Invoke(object @ref) => @ref is IDeref d ? d.Deref() : null;
    }
}
