using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Volatile_ :
        IFunction<object, object>
    {
        public object Invoke(object val) => new Volatile(val);
    }
}
