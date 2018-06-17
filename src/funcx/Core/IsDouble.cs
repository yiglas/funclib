using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsDouble :
        IFunction<object, object>
    {
        public object Invoke(object x) => new IsInstance().Invoke(typeof(double), x);
    }
}
