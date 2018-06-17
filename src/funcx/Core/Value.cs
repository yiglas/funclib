using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Value :
        IFunction<object, object>
    {
        public object Invoke(object e) => ((KeyValuePair)e).Value;
    }
}
