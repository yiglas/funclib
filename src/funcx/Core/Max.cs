using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Max :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x) => x;
        public object Invoke(object x, object y) => Numbers.Max(x, y);
        public object Invoke(object x, object y, params object[] more) => 
            new Reduce1().Invoke(this, Invoke(x, y), more);
    }
}
