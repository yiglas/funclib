using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Boolean :
        IFunction<object, object>
    {
        public object Invoke(object x) =>
            x is bool b
                ? b
                : x != null;
    }
}
