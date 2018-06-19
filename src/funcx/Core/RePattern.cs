using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FunctionalLibrary.Core
{
    public class RePattern :
        IFunction<object, object>
    {
        public object Invoke(object s) =>
            (bool)new IsInstance().Invoke(typeof(Regex), s)
                ? s
                : new Regex((string)s);
    }
}
