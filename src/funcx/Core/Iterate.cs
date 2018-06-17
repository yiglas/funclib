using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Iterate :
        IFunction<object, object, object>
    {
        public object Invoke(object f, object x) => Collections.Iterate.Create((IFunction<object, object>)f, x);
    }
}
