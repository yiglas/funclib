using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class NotEqual :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x) => false;
        public object Invoke(object x, object y) => new Not().Invoke(new Equals().Invoke(x, y));
        public object Invoke(object x, object y, params object[] more) => new Not().Invoke(new Apply().Invoke(new Equals(), x, y, more));
    }
}
