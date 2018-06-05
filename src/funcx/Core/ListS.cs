using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class ListS :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object>

    {
        public object Invoke(object args) => new Seq().Invoke(args);
        public object Invoke(object a, object args) => new Cons().Invoke(a, args);
        public object Invoke(object a, object b, object args) => new Cons().Invoke(a, new Cons().Invoke(b, args));
        public object Invoke(object a, object b, object c, object args) => new Cons().Invoke(a, new Cons().Invoke(b, new Cons().Invoke(c, args)));
        public object Invoke(object a, object b, object c, object d, params object[] more) => 
            new Cons().Invoke(a, new Cons().Invoke(b, new Cons().Invoke(c, new Cons().Invoke(d, new Spread().Invoke(more)))));
    }
}
