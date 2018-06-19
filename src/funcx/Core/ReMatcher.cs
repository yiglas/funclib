using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FunctionalLibrary.Core
{
    public class ReMatcher :
        IFunction<object, object, object>
    {
        public object Invoke(object re, object s) =>
            new FunctionalLibrary.ReMatcher((Regex)re, (string)s);
    }
}
