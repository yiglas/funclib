using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsReduced :
        IFunction<object, object>
    {
        public object Invoke(object x) => x is Reduced;
    }
}
