using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsMap :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsInstance().Invoke(typeof(IMap), x);
    }
}
