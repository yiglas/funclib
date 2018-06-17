using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Key :
        IFunction<object, object>
    {
        public object Invoke(object e) => ((KeyValuePair)e).Key;
    }
}
