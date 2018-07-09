using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsNumber :
        IFunction<object, object>
    {
        public object Invoke(object x) => Numbers.IsNumber(x);
    }
}
