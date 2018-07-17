using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class Update :
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunction<object, object, object, object, object, object>,
        IFunction<object, object, object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object, object, object>
    {
        public object Invoke(object m, object k, object f) => new Assoc().Invoke(m, k, ((IFunction<object, object>)f).Invoke(new Get().Invoke(m, k)));
        public object Invoke(object m, object k, object f, object x) => 
            new Assoc().Invoke(m, k, ((IFunction<object, object, object>)f).Invoke(new Get().Invoke(m, k), x));
        public object Invoke(object m, object k, object f, object x, object y) =>
            new Assoc().Invoke(m, k, ((IFunction<object, object, object, object>)f).Invoke(new Get().Invoke(m, k), x, y));
        public object Invoke(object m, object k, object f, object x, object y, object z) =>
            new Assoc().Invoke(m, k, ((IFunction<object, object, object, object, object>)f).Invoke(new Get().Invoke(m, k), x, y, z));
        public object Invoke(object m, object k, object f, object x, object y, object z, params object[] more) =>
            new Assoc().Invoke(m, k, new Apply().Invoke(f, new Get().Invoke(m, k), x, y, z, more));
    }
}
