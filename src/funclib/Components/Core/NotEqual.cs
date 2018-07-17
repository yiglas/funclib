using System;
using System.Text;

namespace funclib.Components.Core
{
    public class NotEqual :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke(object x) => false;
        public object Invoke(object x, object y) => new Not().Invoke(new IsEqual().Invoke(x, y));
        public object Invoke(object x, object y, params object[] more) => new Not().Invoke(new Apply().Invoke(new IsEqual(), x, y, more));
    }
}
